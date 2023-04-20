using Reactor_Interface.Classes.Experiment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms.DataVisualization.Charting;

namespace Reactor_Interface.Classes.Templates
{
    public class ExperimentData
    {
        public string Name { get; }
        public Dictionary<string, List<FieldData>> Pages { get; }
        public Chart Chart { get; }
        public string Comments { get; }
        public ExperimentData(string name, Dictionary<string, List<FieldData>> pages, Chart chart = null, string comments = null)
        {
            Pages = pages;
            Name = name;
            Chart = chart;
            Comments = comments;
        }
    }
}
