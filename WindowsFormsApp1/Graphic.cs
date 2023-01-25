using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;
using WindowsFormsApp1;

using Excel = Microsoft.Office.Interop.Excel;

namespace Reactor_Interface
{
    public partial class Graphic_menu : Form
    {
        public bool is_drawing = false;
        public Graphic_menu()
        {
            InitializeComponent();
        }


        public void update_aver_tok(long time, double aver_tok)
        {
            if (Graph != null && is_drawing && IsHandleCreated)
            {
                Graph.BeginInvoke((MethodInvoker)(() => this.Graph.Series["aver_tok"].Points.AddXY(time, aver_tok)));
            }
        }

        public void update_tok(long time, double tok)
        {
            if (Graph != null && is_drawing && IsHandleCreated)
            {
                Graph.BeginInvoke((MethodInvoker)(() => this.Graph.Series["tok"].Points.AddXY(time, tok)));
            }
        }

        public void update_temperature(long time, int temp)
        {
            if (Graph != null && is_drawing)
            {
                Graph.BeginInvoke((MethodInvoker)(() => Graph.Series["temperature"].Points.AddXY(time, temp)));
            }
        }

        public void update_step(long time, int step)
        {
            if (Graph != null && is_drawing)
            {
                Graph.BeginInvoke((MethodInvoker)(() => this.Graph.Series["step"].Points.AddXY(time, step)));
            }
        }

        public void setChartVisible(bool isVisible)
        {
            if (Graph != null) Graph.Visible = isVisible;
        }

        private void какКартинкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sf = new SaveFileDialog())
            {
                sf.Title = "Сохранить файл как...";
                sf.Filter = "*.png|*.png;";
                sf.FileName = "График";
                sf.DefaultExt = ".png";

                if (sf.ShowDialog() == DialogResult.OK)
                {
                    Graph.SaveImage(sf.FileName, ChartImageFormat.Png);
                }
            }
        }

        private void Graphic_menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void очиститьГрафикToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!is_drawing) {
                foreach (var series in Graph.Series)
                {
                    series.Points.Clear();
                }
            }
            Graph.Series["step"].Points.Add(new DataPoint { IsEmpty = true });
            Graph.Series["tok"].Points.Add(new DataPoint { IsEmpty = true });
        }

        

        private void какExcelТаблицуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path;
            using (SaveFileDialog sf = new SaveFileDialog())
            {
                sf.Title = "Сохранить файл как...";
                sf.FileName = "График";

                if (sf.ShowDialog() == DialogResult.OK)
                {
                    path = sf.FileName;
                }
            }


            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            for (int i = 0; i < Graph.Series.Count; i++)
            {
                xlWorkSheet.Cells[1, 1] = "";
                xlWorkSheet.Cells[1, 2] = "DateTime";//put your column heading here
                xlWorkSheet.Cells[1, 3] = "Data";// put your column heading here

                for (int j = 0; j < Graph.Series[i].Points.Count; j++)
                {
                    xlWorkSheet.Cells[j + 2, 2] = Graph.Series[i].Points[j].XValue;
                    xlWorkSheet.Cells[j + 2, 3] = Graph.Series[i].Points[j].YValues[0];
                }
            }

            Excel.Range chartRange;

            Excel.ChartObjects xlCharts = (Excel.ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
            Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(10, 80, 300, 250);
            Excel.Chart chartPage = myChart.Chart;

            chartRange = xlWorkSheet.get_Range("B2", "c5");//update the range here
            chartPage.SetSourceData(chartRange, misValue);
            chartPage.ChartType = Excel.XlChartType.xlColumnClustered;

            xlWorkBook.SaveAs("csharp.net-informations.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            //releaseObject(xlWorkSheet);
            //releaseObject(xlWorkBook);
            //releaseObject(xlApp);

        }

        private void menubtn_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem button = (ToolStripMenuItem)sender;

            switch (button.Tag)
            {
                case "tok":
                    Graph.Series["tok"].Color = button.Checked ? Color.SkyBlue : Color.Transparent;
                    break;

                case "aver_tok":
                    Graph.Series["aver_tok"].Color = button.Checked ? Color.MidnightBlue : Color.Transparent;
                    break;

                case "temperature":
                    Graph.Series["temperature"].Color = button.Checked ?  Color.Red : Color.Transparent;
                    break;

                case "step":
                    Graph.Series["step"].Color = button.Checked ?  Color.SaddleBrown : Color.Transparent;
                    break;
            }
            Graph.ChartAreas["tok_area"].Visible = (!(Graph.Series["tok"].Color == Color.Transparent) || !(Graph.Series["aver_tok"].Color == Color.Transparent));
            Graph.ChartAreas["temperature_area"].Visible = !(Graph.Series["temperature"].Color == Color.Transparent);
            Graph.Series[Convert.ToString(button.Tag)].IsVisibleInLegend = button.Checked;
        }

    }
}
