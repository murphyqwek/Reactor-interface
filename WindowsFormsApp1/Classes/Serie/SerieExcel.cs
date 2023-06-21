using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions;
using OfficeOpenXml.Style;
using Reactor_Interface.Classes.Experiment;
using Reactor_Interface.Classes.Templates;
using Reactor_Interface.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reactor_Interface.Classes.Serie
{
    public class SerieExcel
    {
        const int FONTSIZE = 11;
        const string FONTNAME = "Times New Roman";
        const double koef = 10.0;

        private static Dictionary<string, int> AppColumns = new Dictionary<string, int>()
        {
            {"Данные реактора", 0},
            {"Данные пирометра", 0},
            {"Данные XRD", 0},
            {"Данные осциллографа", 0}
        };

        private static readonly Dictionary<string, string> AppHeaders = new Dictionary<string, string>()
        {
            {"Данные реактора", "aver_tok"},
            {"Данные пирометра", "temperature"},
            {"Данные XRD", "xrd"},
            {"Данные осциллографа", "OSC_CH1"}
        };

        private static bool checkSerieData(SerieData serieData)
        {
            if (serieData.Experiments?.Count == 0 || !Directory.Exists(serieData.ExperimentPath))
            {
                ErrorMessage.Show("В базе среии нет ни одного эксперимента");
                return false;
            }

            return true;
        }

        private static string CreateReportFolder(SerieData serieData)
        {
            if (!Directory.Exists(serieData.ReportPath))
                Directory.CreateDirectory(serieData.ReportPath);

            string path = serieData.ReportPath;


            path = Path.Combine(path, DateTime.Today.ToString("dd/MM/yyyy"));

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            Directory.CreateDirectory(path);

            return path;
        }

        private static int GetCountOfExperiment(SerieData serieData)
        {
            int countExperiment = 0;

            foreach(var experiments in serieData.Experiments.Values) 
            {
                countExperiment += experiments.Count;
            }

            return countExperiment;
        }

        public static void CreateSerieExcel(SerieData serieData)
        {
            string reportPath = CreateReportFolder(serieData);

            if (!checkSerieData(serieData))
            {
                Directory.Delete(reportPath);
                reportPath = Directory.GetParent(reportPath).FullName;

                if (Directory.GetFiles(reportPath).Length == 0)
                    Directory.Delete(reportPath);

                return;
            }

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            int step = GetCountOfExperiment(serieData);

            step = step == 0 ? 1 : 100 / step;

            using (ExcelPackage serieExcel = new ExcelPackage())
            {
                foreach(string serieTemplateKey in serieData.Experiments.Keys)
                {
                    SerieTemplate serieTemplate = serieData.SerieTemplates[serieTemplateKey];
                    List<SerieExperimentMetaData> serieExperiments = serieData.Experiments[serieTemplateKey];

                    AddNewWorkSheetExperiments(serieExcel, serieTemplate, serieExperiments, serieData.ExperimentPath);
                }

                serieExcel.SaveAs(Path.Combine(reportPath, serieData.Name + ".xlsx"));
            }

            OpenReportFolder(reportPath);
        }

        private static void OpenReportFolder(string reportPath)
        {
            var result = MessageBox.Show("Отчёт создан. Хотите открыть папку с отчётом?", "Успешно", MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (result != DialogResult.Yes)
                return;

            Process.Start("explorer", reportPath);
        }

        private static void SetupCell(ExcelRange cell, bool autofit)
        {
            cell.Style.Font.Name = FONTNAME;
            cell.Style.Font.Size = FONTSIZE;
            cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            cell.Style.Border.BorderAround(ExcelBorderStyle.Thin);
            cell.Style.WrapText = true;
            if(autofit)
                cell.AutoFitColumns();
        }

        private static Dictionary<string, int> SetupWorkSheetTemplate(ExcelWorksheet serieWorksSheet, SerieTemplate serieTemplate)
        {
            SerieTemplate template = serieTemplate;
            Dictionary<string, int> templateFieldsCells = new Dictionary<string, int>();
            var ExperimentCodeCell = serieWorksSheet.Cells[1, 1, 2, 1];

            ExperimentCodeCell.Merge = true;
            ExperimentCodeCell.Value = "Код эксперимента";
            SetupCell(ExperimentCodeCell, false);
            ExperimentCodeCell.Style.WrapText = false;
            serieWorksSheet.Columns[1].Width = serieWorksSheet.Columns[1].Width * 2;
            serieWorksSheet.Rows[1].Height = serieWorksSheet.Rows[1].Height * 2;

            int column = 2;
            foreach(var field in template.Fields.Keys)
            {
                if (templateFieldsCells.ContainsKey(field))
                    continue;

                string firstField = null;
                string secondField = null;

                foreach(var conFields in template.ConnectedFieldsList)
                {
                    if(conFields.firstFieldName == field)
                    {
                        firstField = field;
                        secondField = conFields.secondFieldName;
                        break;
                    }
                    if(conFields.secondFieldName == field)
                    {
                        firstField = conFields.firstFieldName;
                        secondField = conFields.secondFieldName;
                        break;
                    }
                }

                if(firstField == null)
                {
                    InsertValueAndAutoSizeMergedCells(field, 1, column, 2, column, serieWorksSheet);
                    var cell = serieWorksSheet.Cells[1, column, 2, column];
                    SetupCell(cell, true);
                    templateFieldsCells.Add(field, column);
                }
                else
                {
                    string connectedFieldsText = firstField.Remove(firstField.LastIndexOf('д') - 1);
                    InsertValueAndAutoSizeMergedCells(connectedFieldsText, 1, column, 1, column + 1, serieWorksSheet);
                    SetupCell(serieWorksSheet.Cells[1, column, 1, column + 1], false);

                    var cell = serieWorksSheet.Cells[2, column];
                    cell.Value = "до";
                    SetupCell(cell, true);
                    templateFieldsCells.Add(firstField, column);

                    column++;

                    cell = serieWorksSheet.Cells[2, column];
                    cell.Value = "после";
                    SetupCell(cell, true);
                    templateFieldsCells.Add(secondField, column);
                }
                column++;
            }

            AddAppFields(column, serieWorksSheet);

            return templateFieldsCells;
        }

        private static void AddAppFields(int column, ExcelWorksheet serieWorksSheet)
        {
            Dictionary<string, int> NewAppColumns = new Dictionary<string, int>();

            foreach (var key in AppColumns.Keys)
            {
                NewAppColumns.Add(key, column);
                var cell = serieWorksSheet.Cells[1, column, 2, column];
                serieWorksSheet.Columns[column].Width += koef;
                cell.Merge = true;
                cell.Value = key;
                SetupCell(cell, false);
                column++;
            }

            AppColumns = NewAppColumns;
        }

        private static void InsertValueAndAutoSizeMergedCells(string value, int fromRow, int fromColumn, int toRow, int toColumn, ExcelWorksheet serieWorksSheet)
        {
            serieWorksSheet.Cells[fromRow, fromColumn].Value = value;
            double currentCellWidth = serieWorksSheet.Columns[fromColumn].Width;
            serieWorksSheet.Cells[fromRow, fromColumn].AutoFitColumns();
            double newCellWidth = serieWorksSheet.Columns[fromColumn].Width;
            serieWorksSheet.Columns[fromColumn].Width = currentCellWidth;
            serieWorksSheet.Cells[fromRow, fromColumn, toRow, toColumn].Merge = true;
            double summedWidth = 0;
            for(int i = fromColumn; i < toColumn; i++)
            {
                summedWidth += serieWorksSheet.Columns[i].Width;
            }
            newCellWidth -= summedWidth;
            serieWorksSheet.Columns[fromColumn].Width = newCellWidth + koef;
        }

        private static void AddNewWorkSheetExperiments(ExcelPackage serieExcel, SerieTemplate serieTemplate, List<SerieExperimentMetaData> serieExperiments, string ExperimentsPath)
        {
            var serieWorkSheet = serieExcel.Workbook.Worksheets.Add(serieTemplate.TemplateName);
            var templateFieldsCells = SetupWorkSheetTemplate(serieWorkSheet, serieTemplate);

            int row = 3;

            foreach (var experimentMetaData in serieExperiments)
            {
                string experimentPath = Path.Combine(ExperimentsPath + "\\" + experimentMetaData.ExperimentName, experimentMetaData.GetExperimentFileName());
                ExperimentData experiment = ExperimentSystem.UploadExperiment(experimentPath, true);

                if (experiment == null)
                    continue;

                if (!serieTemplate.IsExperimentCapabledWithTemplate(experiment))
                    continue;

                var cell = serieWorkSheet.Cells[row, 1];
                cell.Value = experimentMetaData.ExperimentName;
                SetupCell(cell, false);

                foreach(var field in experiment.GetAllFields())
                {
                    int column = templateFieldsCells[field.FieldName];
                    cell = serieWorkSheet.Cells[row, column];
                    if (int.TryParse(field.FieldValue, out int n))
                        cell.Value = n;
                    else if(double.TryParse(field.FieldValue, out double d))
                        cell.Value = d;
                    else
                        cell.Value = field.FieldValue;
                    SetupCell(cell, true);
                }

                PutAppData(experimentPath, row, serieWorkSheet);

                row++;
            }
        }

        private static void PutAppData(string experimentPath, int row, ExcelWorksheet serieWorkSheet)
        {
            string experimentText = ExperimentSystem.GetExperimentText(experimentPath);

            int AppDataIndex = experimentText.IndexOf(",\"" + "ApplianceData" + "\"" + ":{");
            int ConnectedFieldsIndex = experimentText.IndexOf(",\"ConnectedFields\":");

            bool HasAppData = AppDataIndex != -1;

            if (ConnectedFieldsIndex > AppDataIndex && AppDataIndex != -1 && ConnectedFieldsIndex != -1)
            {
                ExperimentSystem.ResaveExperiment(experimentPath);
                experimentText = ExperimentSystem.GetExperimentText(experimentPath);
                AppDataIndex = experimentText.IndexOf(",\"" + "ApplianceData" + "\"" + ":{");
            }

            foreach (string AppColumn in AppColumns.Keys)
            {
                int column = AppColumns[AppColumn];

                var cell = serieWorkSheet.Cells[row, column];

                SetupCell(cell, false);
                cell.Style.Font.Bold = true;
                cell.Style.Fill.PatternType = ExcelFillStyle.Solid;

                if (!HasAppData)
                {
                    cell.Value = "-";
                    cell.Style.Fill.BackgroundColor.SetColor(Color.Red);
                    continue;
                }

                string AppSerieName = AppHeaders[AppColumn];
                int AppHeaderIndex = experimentText.IndexOf(AppSerieName);

                if (AppHeaderIndex == -1 || AppHeaderIndex < AppDataIndex)
                {
                    cell.Value = "-";
                    cell.Style.Fill.BackgroundColor.SetColor(Color.Red);
                }
                else
                {
                    cell.Value = "+";
                    cell.Style.Fill.BackgroundColor.SetColor(Color.Lime);
                }
            }
        }
    }
}