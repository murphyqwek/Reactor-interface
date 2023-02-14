using Reactor_Interface.Classes;
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
using System.Xml.Serialization;
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
                Graph.BeginInvoke((MethodInvoker)(() => this.Graph.ChartAreas["tok_area"].AxisX.Minimum = this.Graph.ChartAreas["tok_area"].AxisX.Minimum <= 0 ? time : 0));
                Graph.BeginInvoke((MethodInvoker)(() => this.Graph.Series["aver_tok"].Points.AddXY(time, aver_tok)));
            }
        }

        public void update_tok(long time, double tok)
        {
            if (Graph != null && is_drawing && IsHandleCreated)
            {
                Graph.BeginInvoke((MethodInvoker)(() => this.Graph.ChartAreas["tok_area"].AxisX.Minimum = this.Graph.ChartAreas["tok_area"].AxisX.Minimum <= 0 ? time : 0));
                Graph.BeginInvoke((MethodInvoker)(() => this.Graph.Series["tok"].Points.AddXY(time, tok)));
            }
        }

        public void update_temperature(long time, int temp)
        {
            if (Graph != null && is_drawing)
            {
                Graph.BeginInvoke((MethodInvoker)(() => this.Graph.ChartAreas["temperature_area"].AxisX.Minimum = this.Graph.ChartAreas["temperature_area"].AxisX.Minimum <= 0 ? time : 0));
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
            Clear_Graphic();
        }

        public void Clear_Graphic()
        {
            if (!is_drawing)
            {
                foreach (var series in Graph.Series)
                {
                    series.Points.Clear();
                }
                Graph.Series["step"].Points.Add(new DataPoint { IsEmpty = true });
                Graph.Series["tok"].Points.Add(new DataPoint { IsEmpty = true });
            }
        }

        private void какExcelТаблицуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = "";
            using (SaveFileDialog sf = new SaveFileDialog())
            {
                sf.Title = "Сохранить файл как...";
                sf.FileName = "График";
                sf.Filter = "*.xls|*.xls;";
                sf.DefaultExt = ".xls";

                if (sf.ShowDialog() == DialogResult.OK)
                {
                    path = sf.FileName;
                }
                else
                {
                    return;
                }

                if (check_if_file_is_open(path))
                {
                    MessageBox.Show("Данный файл уже открыт", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Exl.Save_Excel(path, Graph);
                MessageBox.Show("Excel файл сохранен", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool check_if_file_is_open(string file)
        {
            try
            {
                using (FileStream fileStream = File.Open(file, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
                {
                    if (fileStream != null) fileStream.Close(); 
                }
                return false;
            }
            catch (IOException) 
            {
                return true; 
            }
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

        private void save_as_txt_file_stipbtn_Click(object sender, EventArgs e)
        {
            string path = "";
            using (SaveFileDialog sf = new SaveFileDialog())
            {
                sf.Title = "Сохранить файл как...";
                sf.Filter = "*.txt|*.txt;";
                sf.FileName = "Текст";
                sf.DefaultExt = ".txt";

                if (sf.ShowDialog() == DialogResult.OK)
                {
                    path = sf.FileName;
                }
                else 
                {
                    return;
                }
            }

            using (StreamWriter f = new StreamWriter(path))
            {
                for(int i = 0; i < Graph.Series.Count; i++)
                {
                    f.Write(Graph.Series[i].LegendText + "\n");      
                    for(int j = 0; j < Graph.Series[i].Points.Count; j++)
                    {
                        string info = Graph.Series[i].Points[j].XValue.ToString() + " " + Graph.Series[i].Points[j].YValues[0].ToString();
                        f.WriteLine(info);
                    }
                    f.WriteLine("");
                }
            }

            MessageBox.Show("Данные были сохранены", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }
    }
}
