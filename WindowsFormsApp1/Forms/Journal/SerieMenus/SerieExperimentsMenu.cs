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
using Reactor_Interface.Classes.Serie;
using Reactor_Interface.Classes.Templates;

namespace Reactor_Interface.Forms.Journal.SerieMenus
{
    public partial class SerieExperimentsMenu : Form
    {
        Action<ExperimentData, string> _returnExperiment;
        SerieData Serie;

        public SerieExperimentsMenu(SerieData serieData, Action<ExperimentData, string> returnExperimentFunc)
        {
            InitializeComponent();
            _returnExperiment = returnExperimentFunc;
            Serie = serieData;
            UpdateSerieTree();
        }

        public void UpdateSerieTree()
        {
            if (Serie.Experiments == null)
                return;
            if (Serie.Experiments.Count == 0 || !Directory.Exists(Serie.ExperimentPath))
                return;


            foreach(int templateIndex in Serie.Experiments.Keys)
            {
                if (Serie.Experiments[templateIndex].Count == 0)
                    continue;

                string templateName = Serie.SerieTemplates[templateIndex].TemplateName;

                TreeNode serieNode = new TreeNode(templateName, 0, 0);
                serieNode.Tag = templateIndex;

                SerieTree.Nodes.Add(serieNode);
                AddExperimentsToSerieNode(serieNode, Serie.Experiments[templateIndex]);
            }
        }
        private void AddExperimentsToSerieNode(TreeNode serieNode, List<SerieExperiment> serieExperiments)
        {
            foreach(var Experiment in serieExperiments)
            {
                var ExperimentNode = new TreeNode(Experiment.ExperimentName, -1, -1);
                serieNode.Nodes.Add(ExperimentNode);
            }
        }
    }
}
