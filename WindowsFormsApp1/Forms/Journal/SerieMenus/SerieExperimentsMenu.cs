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
using Reactor_Interface.Classes;
using Reactor_Interface.Classes.Experiment;
using Reactor_Interface.Classes.Message;
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

        Action<SerieExperimentMetaData, ExperimentData, bool, string> _returnExperiment;
        SerieData Serie;
        string currentExperimnetName;

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

        public SerieExperimentsMenu(SerieData serieData, Action<SerieExperimentMetaData, ExperimentData, bool, string> returnExperimentFunc, string CurrentExperimentName)
        {
            InitializeComponent();
            _returnExperiment = returnExperimentFunc;
            Serie = serieData;
            currentExperimnetName = CurrentExperimentName;
            UpdateSerieTree();
        }

        public void UpdateSerieTree()
        {
            SerieTree.Nodes.Clear();

            if (Serie.Experiments.Count == 0 || !Directory.Exists(Serie.ExperimentPath))
                return;

            foreach(string templateKey in Serie.Experiments.Keys)
            {
                string templateName = Serie.SerieTemplates[templateKey].TemplateName;

                TreeNode serieNode = new TreeNode(templateName, 0, 0);
                serieNode.Tag = templateKey;
                serieNode.ToolTipText = TEMPLATETIPTEXT;
                serieNode.ContextMenuStrip = TemplateSeireContextMenu;

                SerieTree.Nodes.Add(serieNode);

                if (Serie.Experiments[templateKey].Count == 0)
                    continue;

                AddExperimentsToSerieNode(serieNode, Serie.Experiments[templateKey]);
            }
        }
        private void AddExperimentsToSerieNode(TreeNode serieNode, List<SerieExperimentMetaData> serieExperiments)
        {
            foreach(var ExperimentMetaData in serieExperiments)
            {
                string experimentPath = SerieSystem.GetExperimentFilePath(Serie, ExperimentMetaData);

                if (!File.Exists(experimentPath))
                {
                    AddMissingExperiment(serieNode, ExperimentMetaData.ExperimentName);
                    continue;
                }

                var expData = ExperimentSystem.UploadExperiment(experimentPath, true);

                string templateKey = ExperimentMetaData.TemplateName;

                if (expData == null)
                    AddDamagedExperiment(serieNode, ExperimentMetaData.ExperimentName);
                else if (!Serie.SerieTemplates[templateKey].IsExperimentCapabledWithTemplate(expData))
                    AddChangedExperiment(serieNode, ExperimentMetaData.ExperimentName);
                else
                    AddExperiment(serieNode, ExperimentMetaData.ExperimentName);
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
            OpenExperiment();
        }

        private void OpenExperiment()
        {
            string tamplateKey = SelectedExperiment.Parent.Tag.ToString();
            string experimentName = SelectedExperiment.Text;

            SerieExperimentMetaData metaData = new SerieExperimentMetaData()
            {
                ExperimentName = experimentName,
                TemplateName = tamplateKey
            };

            ExperimentData experiment = SerieSystem.UploadExperiment(Serie, metaData);

            if (experiment == null)
            {
                ErrorMessage.Show("Эксперимент " + experimentName + " был удалён либо повреждён.\nНевозможно загрузить");
                UpdateSerieTree();
                return;
            }

            string experimentPath = SerieSystem.GetExperimentFolderPath(Serie, metaData);

            _returnExperiment(metaData, experiment, true, experimentPath);
            this.Close();
        }

        private void ExcelExportBtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            SerieExcel.CreateSerieExcel(Serie);
            Cursor = Cursors.Default;
        }

        private void DeleteExperimentBtn_Click(object sender, EventArgs e)
        {
            string templateKey = SelectedExperiment.Parent.Tag as string;

            string experimentName = SelectedExperiment.Text;

            if (!ConfirmMessageBox.Show("Вы точно хотите удалить эксперимент? Восстановить эксперимент после удаления невозможно"))
                return;

            SerieSystem.DeleteExperiment(Serie, templateKey, experimentName);

            if (experimentName == currentExperimnetName)
                _returnExperiment(new SerieExperimentMetaData(), null, true, null);

            SelectedExperiment = null;

            UpdateSerieTree();
        }

        private void UploadTemplateBtn_Click(object sender, EventArgs e)
        {

        }

        private void AddNewExperimentBtn_Click(object sender, EventArgs e)
        {
            string TemplateName = SerieTree.SelectedNode.Text;

            if (!ConfirmMessageBox.Show("Вы уверены, что хотите добавить эксперимент в серию " + TemplateName))
                return;

            string path = ExperimentSystem.GetExperimentPath();

            if (path == null)
                return;

            var Experiment = ExperimentSystem.UploadExperiment(path, true);

            if (Experiment == null)
            {
                ErrorMessage.Show("Файл эксперимента удалён либо повреждён");
                return;
            }

            SerieTemplate Template;

            Serie.SerieTemplates.TryGetValue(TemplateName, out Template);

            if (Template == null) return;

            if (!Template.IsExperimentCapabledWithTemplate(Experiment))
            {
                ErrorMessage.Show("Эксперимент не подходит по шаблону");
                return;
            }

            try
            {
                SerieSystem.AddExistedExperiment(Serie, Experiment, TemplateName, path);
                SuccesMessage.Show("Эксперимент был добавлен в серию");
            }
            catch (Exception ex)
            {
                ErrorMessage.Show("Произошла ошибка:\n" + ex.Message);
            }

            UpdateSerieTree();
        }

        private void SerieTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (SerieTree.SelectedNode.ImageIndex <= 0)
                return;

            OpenExperiment();
        }
    }
}