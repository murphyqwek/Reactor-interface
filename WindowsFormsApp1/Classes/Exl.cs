using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;
using Microsoft.Office.Interop.Excel;
using Reactor_Interface;

using Excel = Microsoft.Office.Interop.Excel;

namespace Reactor_Interface.Classes
{

    static class Exl
    {
        static readonly int stolbec_dannih = 25;
        static readonly double WIDTH = 300;
        static readonly double HEIGHT = 250;
        static public void Save_Excel(string path, System.Windows.Forms.DataVisualization.Charting.Chart Graph)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlApp.DisplayAlerts = false;
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            xlWorkSheet.Cells[stolbec_dannih, 1] = "Время";
            xlWorkSheet.Cells[stolbec_dannih, 2] = "Температура";


            xlWorkSheet.Cells[stolbec_dannih, 4] = "Время";
            xlWorkSheet.Cells[stolbec_dannih, 5] = "Средний ток";

            xlWorkSheet.Cells[stolbec_dannih, 7] = "Время";
            xlWorkSheet.Cells[stolbec_dannih, 8] = "Ток";

            xlWorkSheet.Cells[stolbec_dannih, 10] = "Время";
            xlWorkSheet.Cells[stolbec_dannih, 11] = "Шаг";

            int start_cell = 1;
            for (int i = 0; i < Graph.Series.Count; i++)
            {
                put_with_values(xlWorkSheet, Graph.Series[i].Points, start_cell);

                Excel.Chart chartPage = create_chart(xlWorkSheet, (start_cell - 1) * 100 + 10, 40);

                Excel.Range c1 = xlWorkSheet.Cells[stolbec_dannih, start_cell];
                Excel.Range c2 = xlWorkSheet.Cells[stolbec_dannih + Graph.Series[i].Points.Count, start_cell + 1];
                var data = xlWorkSheet.get_Range(c1, c2);

                chartPage.SetSourceData(data, XlRowCol.xlColumns);
                set_data_to_chart(xlWorkSheet, chartPage, stolbec_dannih, start_cell, stolbec_dannih + 2, start_cell + 1);

                start_cell += 3;
            } 
            /*
            put_with_values(xlWorkSheet, Graph.Series["temperature"].Points, 1);
            Excel.Chart chartPage = create_chart(xlWorkSheet);
            var data = xlWorkSheet.get_Range("A25", "B27");
            chartPage.SetSourceData(data, XlRowCol.xlColumns);
            set_data_to_chart(xlWorkSheet, chartPage, stolbec_dannih, 1, stolbec_dannih + 2, 2);
            //chartPage.SeriesCollection(0).XValues = (Excel.Range)xlWorkSheet.Range[xlWorkSheet.Cells[stolbec_dannih+1, 1], xlWorkSheet.Cells[stolbec_dannih+2, 1]].Cells;
            //chartPage.SeriesCollection(0).Values = (Excel.Range)xlWorkSheet.Range[xlWorkSheet.Cells[stolbec_dannih+1, 2], xlWorkSheet.Cells[stolbec_dannih+2, 2]].Cells;
            */

            //chartRange = xlWorkSheet.get_Range("A25", "B27");//update the range here
            //chartRange = xlWorkSheet.get_Range();

            //TODO: Рассмотреть случай, когда таблица уже открыта
            xlWorkBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
        }

        static void put_with_values(Excel.Worksheet xlWorkSheet, DataPointCollection Points, int start_cell)
        {
            for (int j = 0; j < Points.Count; j++)
            {
                xlWorkSheet.Cells[stolbec_dannih + j + 1, start_cell] = Points[j].XValue;
                xlWorkSheet.Cells[stolbec_dannih + j + 1, start_cell + 1] = Points[j].YValues[0];
            }
        }

        static void set_data_to_chart(Excel.Worksheet xlWorkSheet, Excel.Chart chart, int y1, int x1, int y2, int x2)
        {
            Excel.Series s1 = (Excel.Series)chart.SeriesCollection(1);
            //Excel.Series s2 = (Excel.Series)chart.SeriesCollection(2);

            Excel.Range c1 = xlWorkSheet.Cells[y1, x1];
            Excel.Range c2 = xlWorkSheet.Cells[y2, x1];
            s1.XValues = xlWorkSheet.get_Range(c1, c2);

            c1 = xlWorkSheet.Cells[y1, x2];
            c2 = xlWorkSheet.Cells[y2, x2];
            s1.Values = xlWorkSheet.get_Range(c1, c2);
            //s1.Name = s2.Name;

            //s2.Delete();
        }

        static Excel.Chart create_chart(Excel.Worksheet xlWorkSheet, int x, int y)
        {
            Excel.ChartObjects xlCharts = (Excel.ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
            Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(x, y, WIDTH, HEIGHT);
            Excel.Chart chartPage = myChart.Chart;

            chartPage.ChartType = XlChartType.xlXYScatterLinesNoMarkers;
            //chartPage.ChartArea.
            return chartPage;
        }

        static private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
