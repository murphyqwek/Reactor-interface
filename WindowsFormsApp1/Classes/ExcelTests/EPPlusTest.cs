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

namespace Reactor_Interface.Classes.ExcelTests
{
    public class EPPlusTestExcel
    {
        public static void CreateExcelExperiment(string path)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                //Set some properties of the Excel document
                excelPackage.Workbook.Properties.Author = "Reactor Interface TPU";
                excelPackage.Workbook.Properties.Created = DateTime.Now;

                //Create the WorkSheet
                ExcelWorksheet mainSheet = excelPackage.Workbook.Worksheets.Add("Тест");

                for (int i = 0; i < 50; i++)
                {
                    for (int j = 0; j < 50; j += 2)
                    {
                        mainSheet.Cells[i + 1, j + 1, i + 1, j + 2].Value = "Hello";
                    }
                }

                //Save your file
                FileInfo fi = new FileInfo(path);
                excelPackage.SaveAs(fi);
            }
        }
    }
}
