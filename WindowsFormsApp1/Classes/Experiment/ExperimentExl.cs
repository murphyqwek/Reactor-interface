using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Data.SqlTypes;
using System.Runtime.CompilerServices;
using System.Globalization;
using System.Web.UI.WebControls;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Data;
using OfficeOpenXml.Drawing.Chart;
using System.Drawing;
using FormChart = System.Windows.Forms.DataVisualization.Charting;
using OfficeOpenXml.Drawing.Chart.Style;
using Reactor_Interface.Classes.Templates;
using Reactor_Interface.Classes.Experiment;
using System.ServiceProcess.Design;

namespace Reactor_Interface.Classes
{
    public static class ExperimentExl
    {
        static readonly Dictionary<string, Color> name_axe_to_color = new Dictionary<string, Color>
        {
            {"Температура", Color.Red},
            {"Средний ток", Color.MidnightBlue },
            {"Ток", Color.SkyBlue },
            {"Шаг", Color.SandyBrown },
            {"XRD", Color.Indigo }
        };

        static readonly Dictionary<string, string[]> AxisesLabel = new Dictionary<string, string[]>
        {
            {"Температура", new string[] {"Время, мс", "Температура, °C",} },
            {"Средний ток", new string[] {"Время, мс", "Средний ток, А" } },
            {"Ток", new string[] {"Время, мс", "Ток, А" } },
            {"Шаг", new string[] {"Время, мс", "Шаг" } },
            {"XRD", new string[] { "2θ градусов", "Интенсивность" } },
        };

        public static void CreateExcelExperiment(string path, ExperimentData experiment)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                //Set some properties of the Excel document
                excelPackage.Workbook.Properties.Author = "Reactor Interface TPU";
                excelPackage.Workbook.Properties.Created = DateTime.Now;

                //Create the WorkSheet
                ExcelWorksheet mainSheet = excelPackage.Workbook.Worksheets.Add("Отчёт");
                ExcelWorksheet dataSheet = excelPackage.Workbook.Worksheets.Add("Данные с оборудованиия");
                ExcelWorksheet graphicsSheet = excelPackage.Workbook.Worksheets.Add("Графики");


                //Fill the Sheets
                FillMainSheet(mainSheet, experiment.Pages, experiment.Comments);
                if(experiment.ApplianceData != null)
                {
                    ExcelWorksheet xrdSheet = null;
                    if (experiment.ApplianceData.ContainsKey("xrd"))
                        xrdSheet = excelPackage.Workbook.Worksheets.Add("Рентген");

                    FillDataIntoSheets(graphicsSheet, dataSheet, xrdSheet, experiment.ApplianceData);
                }

                //Save your file
                FileInfo fi = new FileInfo(path);
                excelPackage.SaveAs(fi);
            }

        }

        private static void CreateTable(ExcelWorksheet workSheet, int y0, int y)
        {
            var table = workSheet.Cells[y0, 1, y, 2];
            table.Style.Border.BorderAround(ExcelBorderStyle.Medium);
        }

        private static void fillSerie(ExcelWorksheet dataSheet, List<GraphPoint> points, int firstCellColumn)
        {
            int y = 2;
            int x = firstCellColumn;
            for (int i = 0; i < points.Count; i++)
            {
                dataSheet.Cells[y, x].Value = points[i].X;
                dataSheet.Cells[y, x + 1].Value = points[i].Y;
                y++;
            }
            dataSheet.Columns[firstCellColumn].AutoFit();
            dataSheet.Columns[firstCellColumn + 1].AutoFit();
        }

        private static void FillGraphicsSheet(ExcelWorksheet graphicsSheet, ExcelWorksheet dataSheet, int startCellColumn, int lastCellRow, int chartColumn)
        {
            string dataName = dataSheet.Cells[1, startCellColumn + 1].Value.ToString();
            var graphic = graphicsSheet.Drawings.AddLineChart(dataName, eLineChartType.Line);
            graphic.SetSize(900, 450);
            graphic.SetPosition(chartColumn / 3 * 450, 0);

            graphic.StyleManager.SetChartStyle(ePresetChartStyle.LineChartStyle1, ePresetChartColors.ColorfulPalette1);

            ExcelRange timeRange = dataSheet.Cells[2, startCellColumn, lastCellRow + 1, startCellColumn];
            Console.WriteLine(timeRange.ToString());
            ExcelRange dataRange = dataSheet.Cells[2, startCellColumn + 1, lastCellRow + 1, startCellColumn + 1];
            
            graphic.Series.Add(dataRange, timeRange);

            string[] AxisesNames = AxisesLabel[dataName];

            graphic.Series[0].Border.Fill.Color = name_axe_to_color[dataName];
            graphic.XAxis.AddGridlines();
            graphic.XAxis.Title.Text = AxisesNames[0];

            graphic.YAxis.Title.Text = AxisesNames[1];
            graphic.YAxis.Title.TextBody.VerticalText = OfficeOpenXml.Drawing.eTextVerticalType.Vertical270;

            graphic.Title.Text = dataName;
            graphic.Series[0].Header = dataName;
            graphic.Legend.Position = eLegendPosition.TopRight;

            graphic.YAxis.Crosses = 0;
        }

        private static void FillDataIntoSheets(ExcelWorksheet graphicSheet, ExcelWorksheet dataSheet, ExcelWorksheet xrdSheet, Dictionary<string, ApplianceData> applianceData)
        {
            int start_cell = 1;
            foreach (var serie in applianceData.Keys)
            {
                //Заполнение заголовков
                dataSheet.Cells[1, start_cell].Value = serie == "XRD" ? "2θ градусов" : "Время";
                dataSheet.Cells[1, start_cell+1].Value = applianceData[serie].LegendText;

                //Заполение стоблцов данными для графиков
                fillSerie(dataSheet, applianceData[serie].Data, start_cell);
                //if(i == 0)
                if (serie == "xrd")
                {
                    FillGraphicsSheet(xrdSheet, dataSheet, start_cell, applianceData[serie].Data.Count, 1);
                    continue;
                }

                FillGraphicsSheet(graphicSheet, dataSheet, start_cell, applianceData[serie].Data.Count, start_cell);
                start_cell += 3;
            }
        }

        private static void FillMainSheet(ExcelWorksheet mainSheet, Dictionary<string, List<FieldData>> fields, string comments)
        {
            int y = 1;

            bool AutoSizeSecondColumn = false;

            var comment_title = mainSheet.Cells["D1:J2"];
            var comment_section = mainSheet.Cells["D3:J20"];

            comment_title.Merge = true;
            comment_title.Value = "Комментарии к эксперименту";
            comment_title.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            comment_title.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            comment_section.Merge = true;
            comment_section.Value = comments;
            comment_section.Style.WrapText = true;
            comment_section.Style.VerticalAlignment = ExcelVerticalAlignment.Top;

            foreach (var table_name in fields.Keys)
            {
                int y0 = y;

                mainSheet.Cells[y, 1].Value = table_name;
                mainSheet.Cells[y, 1, y, 2].Merge = true;
                mainSheet.Cells[y, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                mainSheet.Cells[y, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                y++;
                foreach (var data in fields[table_name])
                {
                    y++;
                    mainSheet.Cells[y, 1].Value = data.FieldName;

                    if (!string.IsNullOrEmpty(data.FieldValue))
                    {
                        mainSheet.Cells[y, 2].Value = data.FieldValue;
                        AutoSizeSecondColumn = true;
                    }
                }
                CreateTable(mainSheet, y0, y);
                y += 2;
            }
            mainSheet.Columns[1].AutoFit();
            if(AutoSizeSecondColumn)
                mainSheet.Columns[2].AutoFit();
        }
    }
}