using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using Reactor_Interface.Classes;
using Reactor_Interface.Classes.Experiment;
using Reactor_Interface.Classes.Serie;
using Reactor_Interface.Classes.Message;
using Reactor_Interface.Classes.Templates;

namespace Reactor_Interface.Forms.Journal.SerieMenus
{
    public partial class CreateNewSerieExperiment : Form
    {
        SerieData Serie;
        ListViewItem _selectedItem;

        ListViewItem SelectedTemplate
        {
            get
            {
                return _selectedItem;
            }

            set
            {
                if (value != null)
                    SelectedTemplateLabel.Text = value.Text;
                else
                {
                    SelectedTemplateLabel.Text = "Шаблон не выбран";
                    CreateExperimentBtn.Visible = false;
                    DeleteTemplateBtn.Visible = false;
                    UploadNewTemplateBtn.Visible = false;
                }

                _selectedItem = value;
            }
        }

        private const string MISSINGTIP = "Шаблон не был найден в папке шаблонов. Невозможно создать эксперимент";
        private const string CHANGEDTIP = "Шаблон был изменён. Добавьте его в базу шаблонов серии";
        private const string DAMAGEDTIP = "Шаблон был повреждён. Невозможно создать эксперимент";

        private Action<SerieExperimentMetaData, ExperimentData, bool> returnExperiment;

        public CreateNewSerieExperiment(SerieData serie, Action<SerieExperimentMetaData, ExperimentData, bool> returnExperimentFunc)
        {
            InitializeComponent();
            SelectedTemplateLabel.Text = "Шаблон не выбран";
            Serie = serie;
            returnExperiment = returnExperimentFunc;
            if(!File.Exists(serie.SerieFilePath)) 
            {
                MessageBox.Show("Файл эксперимента был удалён", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            UploadTemplates();
        }

        private void UploadTemplates()
        {
            SerieTemplateListView.Items.Clear();

            if (!Directory.Exists(Serie.ExperimentPath))
                return;

            for (int i = 0; i < Serie.SerieTemplates.Count; i++)
            {
                var template = Serie.SerieTemplates[i];
                string templatePath = Path.Combine(Serie.TemplatesPath, template.GetTemplateFileName());
                UploadTemplateOnListView(template, i, templatePath);
            }
        }

        private void AddMissingTemplate(string templateName, int index)
        {
            var Item = SerieTemplateListView.Items.Add(templateName, 1);
            Item.Tag = index;
            Item.ToolTipText = MISSINGTIP;
        }

        private void AddChangedTemplate(string templateName, int index)
        {
            var Item = SerieTemplateListView.Items.Add(templateName, 0);
            Item.Tag = index;
            Item.ToolTipText = CHANGEDTIP;
        }

        private void AddTemplate(string templateName, int index)
        {
            var Item = SerieTemplateListView.Items.Add(templateName);
            Item.Tag = index;
        }

        private void AddDamagedTemplate(string templateName, int index)
        {
            var Item = SerieTemplateListView.Items.Add(templateName, 2);
            Item.Tag = index;
            Item.ToolTipText = DAMAGEDTIP;
        }

        private void UploadTemplateOnListView(SerieTemplate template, int index, string templatePath)
        {
            if (template.IsDeleted)
                return;

            if (!File.Exists(templatePath))
            {
                AddMissingTemplate(template.TemplateName, index);
                return;
            }

            var templateOnComp = ExperimentSystem.UploadExperiment(templatePath);

            if (templateOnComp == null) 
            {
                AddDamagedTemplate(template.TemplateName, index);
                return;
            }

            if(!template.IsExperimentCapabledWithTemplate(templateOnComp))
            {
                AddChangedTemplate(template.TemplateName, index);
                return;
            }

            AddTemplate(template.TemplateName, index);
        }

        private void SerieTemplateListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreateExperimentBtn.Visible = false;
            DeleteTemplateBtn.Visible = false;
            UploadNewTemplateBtn.Visible = false;

            if (SerieTemplateListView.SelectedItems.Count == 0)
            {
                SelectedTemplate = null;
                return;
            }

            var Item = SerieTemplateListView.SelectedItems[0];

            SelectedTemplate = Item;

            SelectedTemplateLabel.Text = Item.Text;
            DeleteTemplateBtn.Visible = true;

            switch (Item.ImageIndex) 
            {
                case 0:
                    UploadNewTemplateBtn.Visible = true;
                    break;
                case -1:
                    CreateExperimentBtn.Visible = true;
                    break;
            }
        }

        private void UpdateListTemplatesBtn_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            UploadTemplates();
            this.Cursor = Cursors.Default;
        }

        private void UploadNewTemplateBtn_Click(object sender, EventArgs e)
        {
            var Item = SelectedTemplate;

            string templateName = Item.Text;
            int index = Convert.ToInt32(Item.Tag);
            string newNameTemplate;

            string templatePath = Path.Combine(Serie.TemplatesPath, Serie.SerieTemplates[index].GetTemplateFileName());

            if (!File.Exists(templatePath))
            {
                ErrorMessage.Show("Шаблона был удалён");
                UploadTemplates();
                return;
            }

            using (InputFormMenu inputForm = new InputFormMenu("Сохранение шаблона", "Введите новое название шаблона"))
            {
                var result = inputForm.ShowDialog();

                if (result != DialogResult.OK)
                    return;

                newNameTemplate = inputForm.OutputValue;
            }

            newNameTemplate = newNameTemplate.Trim();

            if (string.IsNullOrEmpty(newNameTemplate))
            {
                ErrorMessage.Show("Введено пустое название");
                return;
            }

            if(newNameTemplate == templateName)
            {
                ErrorMessage.Show("Новое название не должно совпадать со старым");
                return;
            }

            var uploadingTemplate = ExperimentSystem.UploadExperiment(templatePath);

            SerieSystem.AddNewTemplateToSerie(Serie, uploadingTemplate, templatePath, newNameTemplate);
            UploadTemplates();
        }

        private void DeleteTemplateBtn_Click(object sender, EventArgs e)
        {
            bool confirm = ConfirmMessageBox.Show("Вы точно хотите удалить шаблон? Все эксперементы, которые были созданы по этому шаблону, не удалятся");

            if (!confirm)
                return;

            int templateIndex = Convert.ToInt32(SelectedTemplate.Tag);

            SerieSystem.DeleteTemplate(Serie, templateIndex);
            SelectedTemplate = null;
            UploadTemplates();
        }

        private void CreateExperimentBtn_Click(object sender, EventArgs e)
        {
            int templateIndex = Convert.ToInt32(SelectedTemplate.Tag);
            ExperimentData newExperiment = CreateExperimentFromTemplate(Serie.SerieTemplates[templateIndex]);

            if(newExperiment  == null)
            {
                ErrorMessage.Show("Не удалось создать эксперимент");
                UploadTemplates();
                return;
            }

            SerieExperimentMetaData newSerieExperiment;
            newSerieExperiment.TemplateIndex = templateIndex;
            newSerieExperiment.ExperimentName = Serie.Name + "_" + (Serie.GetLastExpIndex() + 1).ToString();
            newExperiment.Rename(newSerieExperiment.ExperimentName);

            returnExperiment(newSerieExperiment, newExperiment, false);
            this.Close();
        }

        private ExperimentData CreateExperimentFromTemplate(SerieTemplate serieTemplate)
        {
            string templatePath = Path.Combine(Serie.TemplatesPath, serieTemplate.GetTemplateFileName());
            if (!File.Exists(templatePath))
                return null;

            return ExperimentSystem.UploadExperiment(templatePath);
        }
    }
}