using Microsoft.Office.Interop.Excel;
using Reactor_Interface.Classes.Experiment;
using Reactor_Interface.Classes.Templates;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reactor_Interface.Forms.Journal
{
    public partial class ExperimentGraphicDemonstationMenu : Form
    {
        Dictionary<string, string> SeriesName = new Dictionary<string, string>()
        {
            { "Температура", "temperature" },
            { "Средний ток", "aver_tok" },
            { "Ток", "tok" },
            { "Шаг", "step" },
            { "XRD", "xrd" }
        };

        const string ExperimentChartArea = "ExperimentChartArea";
        const string HiddenSerieArea = "HiddenSeriesArea";

        public ExperimentGraphicDemonstationMenu(ExperimentData experiment)
        {
            InitializeComponent();
            foreach(string serie in experiment.ApplianceData.Keys)
            {
                try
                {
                    foreach (GraphPoint point in experiment.ApplianceData[serie].Data)
                    {
                        Graphic.Series[serie].Points.AddXY(point.X, point.Y);
                    }
                }
                catch { }
            }

            DataStripMenu.Text = "Данные: " + Graphic.Series[0].LegendText;
            Graphic.Series[0].IsVisibleInLegend = true;
            Graphic.Series[0].ChartArea = ExperimentChartArea;
        }

        private void DataStripMenu_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string serie = SeriesName[e.ClickedItem.Text];

            DataStripMenu.Text = "Данные: " + e.ClickedItem.Text;

            for(int i = 0; i < Graphic.Series.Count; i++)
            {
                string currentSerieName = Graphic.Series[i].Name;
                Graphic.Series[i].ChartArea = currentSerieName == serie ? ExperimentChartArea : HiddenSerieArea;
                Graphic.Series[i].IsVisibleInLegend = (currentSerieName == serie);
            }

            Graphic.ChartAreas[ExperimentChartArea].RecalculateAxesScale();
        }
    }
}
