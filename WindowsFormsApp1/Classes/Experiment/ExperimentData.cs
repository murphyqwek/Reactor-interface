using Reactor_Interface.Classes.Experiment;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms.DataVisualization.Charting;

namespace Reactor_Interface.Classes.Templates
{
    public struct ConnectedFields
    {
        public string firstFieldName;
        public string secondFieldName;
        public Color color;

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if(obj == null || !(obj is ConnectedFields)) return false;

            ConnectedFields secondcnFields = (ConnectedFields)obj;

            if(firstFieldName == secondcnFields.firstFieldName &&
                secondFieldName == secondcnFields.secondFieldName)
                return true;

            return false;
        }
    }

    public class ExperimentData
    {
        public string Name { get; private set; }
        public Dictionary<string, List<FieldData>> Pages { get; private set; }
        public Dictionary<string, ApplianceData> ApplianceData { get; private set; }
        public string Comments { get; private set; }
        public List<ConnectedFields> ConnectedFields { get; private set; }
        public ExperimentData(string name, Dictionary<string, List<FieldData>> pages, Dictionary<string, ApplianceData> applianceData = null, string comments = null, List<ConnectedFields> connectedFields = null)
        {
            Pages = pages;
            Name = name;
            ApplianceData = applianceData;
            Comments = comments;
            ConnectedFields = connectedFields;
        }

        public List<FieldData> GetAllFields()
        {
            List<FieldData> fields = new List<FieldData>();
            foreach(var key in Pages.Keys)
            {
                foreach (var field in Pages[key])
                    fields.Add(field);
            }

            return fields;
        }

        public void ClearApplianceData()
        {
            ApplianceData = null;
        }

        public void SetNewApplianceData(Dictionary<string, ApplianceData> newAppData)
        {
            ApplianceData = newAppData;
        }

        public void Rename(string newExperimentName)
        {
            Name = newExperimentName;
        }
    }
}
