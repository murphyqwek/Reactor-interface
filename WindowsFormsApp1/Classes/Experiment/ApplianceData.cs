using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Reactor_Interface.Classes.Experiment
{
    public class ApplianceData
    {
        public List<GraphPoint> Data { get;}
        public Color SerieColor { get; }
        public string LegendText { get; }
        public string SerieName { get; }

        public ApplianceData(List<GraphPoint> data, Color serieColor, string legendText, string serieName)
        {
            Data = data;
            SerieColor = serieColor;
            LegendText = legendText;
            SerieName = serieName;
        }
    }
}
