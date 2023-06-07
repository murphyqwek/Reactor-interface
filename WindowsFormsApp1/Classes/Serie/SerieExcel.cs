using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions;
using OfficeOpenXml.Style;
using Reactor_Interface.Classes.Experiment;
using Reactor_Interface.Classes.Templates;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reactor_Interface.Classes.Serie
{
    public class SerieExcel
    {
        const int FONTSIZE = 11;
        const string FONTNAME = "Times New Roman";
        const double koef = 10.0;

        private static bool checkSerieData(SerieData serieData)
        {
            if (serieData.Experiments?.Count == 0 || !Directory.Exists(serieData.ExperimentPath))
            {
                ErrorMessage.Show("В базе среии нет ни одного эксперимента");
                return false;
            }

            return true;
        }

        public static void CreateSerieExcel(SerieData serieData)
        {
            if (!Directory.Exists(serieData.ReportPath))
                Directory.CreateDirectory(serieData.ReportPath);

            if (!checkSerieData(serieData))
                return;

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage serieExcel = new ExcelPackage())
            {
                foreach(string serieTemplateKey in serieData.Experiments.Keys)
                {
                    SerieTemplate serieTemplate = serieData.SerieTemplates[serieTemplateKey];
                    List<SerieExperimentMetaData> serieExperiments = serieData.Experiments[serieTemplateKey];

                    AddNewWorkSheetExperiments(serieExcel, serieTemplate, serieExperiments, serieData.ExperimentPath);
                }

                serieExcel.SaveAs(Path.Combine(serieData.ReportPath, "Тест.xlsx"));
            }

            SuccesMessage.Show("Отчёт создан");
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
                    //TODO Сделать это
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

            return templateFieldsCells;
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
                string experimentPath = Path.Combine(ExperimentsPath, experimentMetaData.GetExperimentFileName());
                ExperimentData experiment = ExperimentSystem.UploadExperiment(experimentPath);

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
                    cell.Value = field.FieldValue;
                    /* TODO
                    if (int.TryParse(field.FieldValue, out int n))
                        cell.Style.Numberformat.Format = "0";
                    */
                    SetupCell(cell, true);
                }

                row++;
            }
        }
    }
}