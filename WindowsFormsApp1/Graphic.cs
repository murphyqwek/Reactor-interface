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

namespace Reactor_Interface
{
    public partial class Graphic_menu : Form
    {
        public bool is_drawing = false;
        public Graphic_menu()
        {
            InitializeComponent();
        }

        public void update_graph(long time, double y)
        {
            if (Graph != null && is_drawing && IsHandleCreated)
            {
                
                Graph.BeginInvoke((MethodInvoker)(() => this.Graph.Series["st_aver"].Points.AddXY(time, y)));
                //Graph.Series[serie].Points.AddXY(x, y);
                //Graph.Series["st_aver"].Points.AddXY(time, y);
            }
        }


        public void update_temperature(long time, double temp)
        {
            if (Graph != null && is_drawing)
            {
                Graph.Series["temperature_points"].Points.AddXY(time, temp);
                //Graph.Series[serie].Points.AddXY(x, y);
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
        }
    }
}
