using Reactor_Interface.Classes.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reactor_Interface.Classes.Experiment
{
    public class ExperimentDataСomp
    {
        public string Name { get; private set; }
        public Dictionary<string, List<FieldData>> Pages { get; private set; }
        public string Comments { get; private set; }
        public List<ConnectedFields> ConnectedFields { get; private set; }

        public ExperimentDataСomp(string name, Dictionary<string, List<FieldData>> pages, string comments = null, List<ConnectedFields> connectedFields = null)
        {
            Pages = pages;
            Name = name;
            Comments = comments;
            ConnectedFields = connectedFields;
        }

    }
}