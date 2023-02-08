using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
        static readonly int stolbec_dannih = 78;
        static readonly double WIDTH = 500;
        static readonly double HEIGHT = 252;
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
                //Заполение стоблцов данными для графиков
                put_with_values(xlWorkSheet, Graph.Series[i].Points, start_cell);

                Excel.Chart chartPage = create_chart(xlWorkSheet,  10, (start_cell - 1) * 84 + 40);

                //Получение данных
                Excel.Range c1 = xlWorkSheet.Cells[stolbec_dannih, start_cell];
                Excel.Range c2 = xlWorkSheet.Cells[stolbec_dannih + Graph.Series[i].Points.Count, start_cell + 1];
                var data = xlWorkSheet.get_Range(c1, c2);

                //Заполение графика данных
                chartPage.SetSourceData(data, XlRowCol.xlColumns);
                //string Axis_label = get_axis_label(Graph.Series[i].LegendText);
                set_data_to_chart(xlWorkSheet, chartPage, "Тест", stolbec_dannih, start_cell, stolbec_dannih + Graph.Series[i].Points.Count, start_cell + 1);

                start_cell += 3;
            }
            xlWorkBook.SaveAs(path, Excel.XlFileFormat.xlAddIn, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
        }

        private static string get_axis_label()
        {
            return "";
        }

        static Excel.Range get_Range(Excel.Worksheet xlWorkSheet,int y1, int x1, int y2, int x2)
        {
            Excel.Range c1 = xlWorkSheet.Cells[y1, x1];
            Excel.Range c2 = xlWorkSheet.Cells[y2, x2];

            return xlWorkSheet.get_Range(c1, c2);
        }

        static void put_with_values(Excel.Worksheet xlWorkSheet, DataPointCollection Points, int start_cell)
        {
            int y1 = stolbec_dannih + 1, x1 = start_cell, y2 = stolbec_dannih + Points.Count + 1, x2 = start_cell + 1;
            Excel.Range range = get_Range(xlWorkSheet, y1, x1, y2, x2);

            object[,] values = new object[Points.Count, 2];

            for (int j = 0; j < Points.Count; j++)
            {
                values[j, 0] = Points[j].XValue;
                values[j, 1] = Points[j].YValues[0];
            }

            range.set_Value(XlRangeValueDataType.xlRangeValueDefault, values);
            Marshal.ReleaseComObject(range);
        }

        static void set_data_to_chart(Excel.Worksheet xlWorkSheet, Excel.Chart chart, string name_of_axis, int y1, int x1, int y2, int x2)
        {
            y1 += 1; //Чтобы Excel не считывал название данных за данные 
            Excel.Series s1 = (Excel.Series)chart.SeriesCollection(1);

            Excel.Range c1 = xlWorkSheet.Cells[y1, x1];
            Excel.Range c2 = xlWorkSheet.Cells[y2, x1];
            s1.XValues = xlWorkSheet.get_Range(c1, c2);

            c1 = xlWorkSheet.Cells[y1, x2];
            c2 = xlWorkSheet.Cells[y2, x2];
            s1.Values = xlWorkSheet.get_Range(c1, c2);
            Excel.Axis horizontal = chart.Axes(Excel.XlAxisType.xlValue, XlAxisGroup.xlPrimary);

            horizontal.HasTitle = true;
            horizontal.AxisTitle.Text = name_of_axis;
        }

        static Excel.Chart create_chart(Excel.Worksheet xlWorkSheet, int x, int y)
        {
            Excel.ChartObjects xlCharts = (Excel.ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
            Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(x, y, WIDTH, HEIGHT);
            Excel.Chart chartPage = myChart.Chart;

            chartPage.ChartType = XlChartType.xlXYScatterLinesNoMarkers;
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
