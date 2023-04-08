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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;
using System.Data;
using Microsoft.Office.Interop.Excel;
using OfficeOpenXml.Drawing.Chart;
using System.Drawing;
using FormChart = System.Windows.Forms.DataVisualization.Charting;
using OfficeOpenXml.Drawing.Chart.Style;

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
        };

        static readonly Dictionary<string, string> YAxisLabel = new Dictionary<string, string>
        {
            {"Температура", "Температура, °C"},
            {"Средний ток", "Средний ток, А" },
            {"Ток", "Ток, А" },
            {"Шаг", "Шаг" }
        };

        public static void CreateExcelExperiment(string path, Dictionary<string, List<Pair>> fields, FormChart.Chart chart = null, string comments = null)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                //Set some properties of the Excel document
                excelPackage.Workbook.Properties.Author = "Reactor Interface TPU";
                excelPackage.Workbook.Properties.Created = DateTime.Now;

                //Create the WorkSheet
                ExcelWorksheet mainSheet = excelPackage.Workbook.Worksheets.Add("Отчёт");
                ExcelWorksheet dataSheet = excelPackage.Workbook.Worksheets.Add("Данные с оборудования");
                ExcelWorksheet graphicsSheet = excelPackage.Workbook.Worksheets.Add("Графики");

                //Fill the Sheets
                FillMainSheet(mainSheet, fields, comments);
                if(chart != null)
                {
                    FillDataIntoSheets(graphicsSheet, dataSheet, chart);
                }

                //Save your file
                FileInfo fi = new FileInfo(path);
                excelPackage.SaveAs(fi);
            }

        }

        public static void CreateTable(ExcelWorksheet workSheet, int y0, int y)
        {
            var table = workSheet.Cells[y0, 1, y, 2];
            table.Style.Border.BorderAround(ExcelBorderStyle.Medium);
        }

        private static void fillSerie(ExcelWorksheet dataSheet, DataPointCollection points, int firstCellColumn)
        {
            int y = 2;
            int x = firstCellColumn;
            for (int i = 0; i < points.Count; i++)
            {
                dataSheet.Cells[y, x].Value = points[i].XValue;
                dataSheet.Cells[y, x + 1].Value = points[i].YValues[0];
                y++;
            }
            dataSheet.Columns[firstCellColumn].AutoFit();
            dataSheet.Columns[firstCellColumn + 1].AutoFit();
        }

        private static void FillGraphicsSheet(ExcelWorksheet graphicsSheet, ExcelWorksheet dataSheet, int startCellColumn, int lastCellRow)
        {
            string dataName = dataSheet.Cells[1, startCellColumn + 1].Value.ToString();
            var graphic = graphicsSheet.Drawings.AddLineChart(dataName, eLineChartType.Line);
            graphic.SetSize(600, 300);
            graphic.SetPosition((startCellColumn / 4) * 300, 0);

            graphic.StyleManager.SetChartStyle(ePresetChartStyle.LineChartStyle1, ePresetChartColors.ColorfulPalette1);

            ExcelRange timeRange = dataSheet.Cells[2, startCellColumn, lastCellRow + 1, startCellColumn];
            Console.WriteLine(timeRange.ToString());
            ExcelRange dataRange = dataSheet.Cells[2, startCellColumn + 1, lastCellRow + 1, startCellColumn + 1];
            
            graphic.Series.Add(dataRange, timeRange);

            //graphic.Series[0].XSeries = dataRange.ToString();
            graphic.Series[0].Border.Fill.Color = name_axe_to_color[dataName];
            graphic.XAxis.AddGridlines();
            graphic.XAxis.Title.Text = "Время, мс";

            graphic.YAxis.Title.Text = YAxisLabel[dataName];
            graphic.YAxis.Title.TextBody.VerticalText = OfficeOpenXml.Drawing.eTextVerticalType.Vertical270;

            graphic.Title.Text = dataName;
            graphic.Series[0].Header = dataName;
            graphic.Legend.Position = eLegendPosition.TopRight;
        }

        public static void FillDataIntoSheets(ExcelWorksheet graphicSheet, ExcelWorksheet dataSheet, FormChart.Chart chart)
        {
            int start_cell = 1;
            for (int i = 0; i < chart.Series.Count; i++)
            {
                //Заполнение заголовков
                dataSheet.Cells[1, start_cell].Value = "Время";
                dataSheet.Cells[1, start_cell+1].Value = chart.Series[i].LegendText;

                //Заполение стоблцов данными для графиков
                fillSerie(dataSheet, chart.Series[i].Points, start_cell);
                //if(i == 0)
                    FillGraphicsSheet(graphicSheet, dataSheet, start_cell, chart.Series[i].Points.Count);
                start_cell += 3;
            }
        }

        public static void FillMainSheet(ExcelWorksheet mainSheet, Dictionary<string, List<Pair>> fields, string comments)
        {
            int y = 1;

            bool AutoSizeSecondColumn = false;

            var comment_title = mainSheet.Cells["D1:J2"];
            var comment_section = mainSheet.Cells["D3:J12"];

            comment_title.Merge = true;
            comment_title.Value = "Комментарии к эксперименту";
            comment_title.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            comment_title.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            comment_section.Merge = true;
            comment_section.Value = comments;
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
                    mainSheet.Cells[y, 1].Value = data.First;

                    if (data.Second != null)
                    {
                        mainSheet.Cells[y, 2].Value = data.Second;
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
