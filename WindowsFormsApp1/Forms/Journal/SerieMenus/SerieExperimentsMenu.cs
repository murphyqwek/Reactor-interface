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
using Reactor_Interface.Classes.Experiment;
using Reactor_Interface.Classes.Serie;
using Reactor_Interface.Classes.Templates;

namespace Reactor_Interface.Forms.Journal.SerieMenus
{
    public partial class SerieExperimentsMenu : Form
    {
        const string TEMPLATETIPTEXT = "Шаблон экспериментов";
        const string EXPERIMENTTIPTEXT = "Эксперимент серии";
        const string CHANGEDTIPTEXT = "Шаблон эксперимента был изменён. Добавьте его шаблон в базу шаблонов";
        const string DAMAGEDTIPTEXT = "Эксперимент был повреждён";
        const string MISSINGTIPTEXT = "Эксперимент отсутсвует в папке экспериментов";

        Action<SerieExperimentMetaData, ExperimentData, bool> _returnExperiment;
        SerieData Serie;


        TreeNode _selectedNode;
        TreeNode SelectedExperiment
        {
            get { return _selectedNode; }
            set
            {
                if (value == null)
                {
                    SelectedExperimentLabel.Text = "Эксперимент не выбран";
                    OpenExperimentBtn.Visible = false;
                    DeleteExperimentBtn.Visible = false;
                    UploadTemplateBtn.Visible = false;
                }
                else
                    SelectedExperimentLabel.Text = value.Text;

                _selectedNode = value;
            }
        }

        public SerieExperimentsMenu(SerieData serieData, Action<SerieExperimentMetaData, ExperimentData, bool> returnExperimentFunc)
        {
            InitializeComponent();
            _returnExperiment = returnExperimentFunc;
            Serie = serieData;
            UpdateSerieTree();
        }

        public void UpdateSerieTree()
        {
            SerieTree.Nodes.Clear();

            if (Serie.Experiments.Count == 0 || !Directory.Exists(Serie.ExperimentPath))
                return;

            foreach(int templateIndex in Serie.Experiments.Keys)
            {
                if (Serie.Experiments[templateIndex].Count == 0)
                    continue;

                string templateName = Serie.SerieTemplates[templateIndex].TemplateName;

                TreeNode serieNode = new TreeNode(templateName, 0, 0);
                serieNode.Tag = templateIndex;
                serieNode.ToolTipText = TEMPLATETIPTEXT;

                SerieTree.Nodes.Add(serieNode);
                AddExperimentsToSerieNode(serieNode, Serie.Experiments[templateIndex]);
            }
        }
        private void AddExperimentsToSerieNode(TreeNode serieNode, List<SerieExperimentMetaData> serieExperiments)
        {
            foreach(var Experiment in serieExperiments)
            {
                string experimentPath = Path.Combine(Serie.ExperimentPath, Experiment.GetExperimentFileName());
                if(!File.Exists(experimentPath))
                    AddMissingExperiment(serieNode, Experiment.ExperimentName);

                var expData = ExperimentSystem.UploadExperiment(experimentPath);

                int templateIndex = Experiment.TemplateIndex;

                if (expData == null)
                    AddDamagedExperiment(serieNode, Experiment.ExperimentName);
                else if (!Serie.SerieTemplates[templateIndex].IsExperimentCapabledWithTemplate(expData))
                    AddChangedExperiment(serieNode, Experiment.ExperimentName);
                else
                    AddExperiment(serieNode, Experiment.ExperimentName);
            }
        }

        private void AddMissingExperiment(TreeNode serieNode, string experimentName)
        {
            var ExperimentNode = new TreeNode(experimentName, 3, 3);
            ExperimentNode.ToolTipText = MISSINGTIPTEXT;
            serieNode.Nodes.Add(ExperimentNode);
        }

        private void AddDamagedExperiment(TreeNode serieNode, string experimentName)
        {
            var ExperimentNode = new TreeNode(experimentName, 1, 1);
            ExperimentNode.ToolTipText = DAMAGEDTIPTEXT;
            serieNode.Nodes.Add(ExperimentNode);
        }

        private void AddChangedExperiment(TreeNode serieNode, string experimentName)
        {
            var ExperimentNode = new TreeNode(experimentName, 2, 2);
            ExperimentNode.ToolTipText = CHANGEDTIPTEXT;
            serieNode.Nodes.Add(ExperimentNode);
        }

        private void AddExperiment(TreeNode serieNode, string experimentName)
        {
            var ExperimentNode = new TreeNode(experimentName, 4, 4);
            ExperimentNode.ToolTipText = EXPERIMENTTIPTEXT;
            serieNode.Nodes.Add(ExperimentNode);
        }

        private void UpdateListViewBtn_Click(object sender, EventArgs e)
        {
            UpdateSerieTree();
        }

        private void OpenExperimentFolderBtn_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(Serie.ExperimentPath))
                Directory.CreateDirectory(Serie.ExperimentPath);

            System.Diagnostics.Process.Start("explorer", Serie.ExperimentPath);
        }

        private void SerieTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var Node = e.Node;

            SelectedExperiment = null;
            SelectedExperiment = Node;

            if (Node == null)
                return;

            switch (Node.ImageIndex)
            {
                case 0:
                    SelectedExperiment = null;
                    break;
                case 1:
                    DeleteExperimentBtn.Visible = true;
                    break;
                case 2:
                    DeleteExperimentBtn.Visible = true;
                    UploadTemplateBtn.Visible = true;
                    break;
                case 3:
                    DeleteExperimentBtn.Visible = true;
                    break;
                case 4:
                    OpenExperimentBtn.Visible = true;
                    DeleteExperimentBtn.Visible = true;
                    break;
            }
        }

        private void OpenExperimentBtn_Click(object sender, EventArgs e)
        {
            int tamplateIndex = Convert.ToInt32(SelectedExperiment.Parent.Tag);
            string experimentName = SelectedExperiment.Text;

            SerieExperimentMetaData metaData = new SerieExperimentMetaData()
            {
                ExperimentName = experimentName,
                TemplateIndex = tamplateIndex
            };

            ExperimentData experiment = SerieSystem.UploadExperiment(Serie, metaData);

            if (experiment == null)
            {
                UpdateSerieTree();
                return;
            }

            _returnExperiment(metaData, experiment, true);
            this.Close();
        }
    }
}
