using OfficeOpenXml;
using Reactor_Interface.Classes.Message;
using Reactor_Interface.Classes.Templates;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reactor_Interface.Classes.Experiment
{
    public class SaveGraphPointFile
    {
        public static void CreateExcelExperiment(string path, List<GraphPoint> graphPoints)
        {
            if (ReportFileChecker.IsReportOpen(path))
            {
                ErrorMessage.Show("Файл отчёта открыт. Закройте, чтобы сохранить текущий эксперимент");
                return;
            }
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                //Set some properties of the Excel document
                excelPackage.Workbook.Properties.Author = "Reactor Interface TPU";
                excelPackage.Workbook.Properties.Created = DateTime.Now;

                //Create the WorkSheet
                ExcelWorksheet mainSheet = excelPackage.Workbook.Worksheets.Add("Данные");
                
                for(int i = 0; i < graphPoints.Count; i++) 
                {
                    mainSheet.Cells[i + 1, 1].Value = graphPoints[i].X;
                    mainSheet.Cells[i + 1, 2].Value = graphPoints[i].Y;
                }

                //Save your file
                //FileInfo fi = new FileInfo(path);
                excelPackage.SaveAs(path);
            }

            SuccesMessage.Show("Файл сохранён");
        }
    }
}
