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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Xml.Linq;

namespace Reactor_Interface
{
    public partial class Graphic_menu : Form
    {
        bool isdrawing = true;
        public Graphic_menu()
        {
            InitializeComponent();
        }

        public void update_graph(string serie, int time, double y)
        {
            if (Graph != null && isdrawing)
            {
                Graph.BeginInvoke((MethodInvoker)(() => this.Graph.Series[serie].Points.AddXY(time, y)));
                //Graph.Series[serie].Points.AddXY(x, y);
            }
        }

        public void setChartVisible(bool isVisible)
        {
            if (Graph != null) Graph.Visible = isVisible;
        }
    }
}
