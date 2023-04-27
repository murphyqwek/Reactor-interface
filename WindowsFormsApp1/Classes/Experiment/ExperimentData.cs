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
        public string Name { get; private set; }
        public Dictionary<string, List<FieldData>> Pages { get; private set; }
        public Dictionary<string, ApplianceData> ApplianceData { get; private set; }
        public string Comments { get; private set; }
        public ExperimentData(string name, Dictionary<string, List<FieldData>> pages, Dictionary<string, ApplianceData> applianceData = null, string comments = null)
        {
            Pages = pages;
            Name = name;
            ApplianceData = applianceData;
            Comments = comments;
        }

        public void ClearApplianceData()
        {
            ApplianceData = null;
        }

        public void SetNewApplianceData(Dictionary<string, ApplianceData> newAppData)
        {
            ApplianceData = newAppData;
        }

        internal void Rename(string newExperimentName)
        {
            Name = newExperimentName;
        }
    }
}
