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
                    CreateCopyofTemplateBtn.Visible = false;
                    RenameBtn.Visible = false;
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
            UpdateTemplateList();
        }

        private void UpdateTemplateList()
        {
            SerieTemplateListView.Items.Clear();

            if (!Directory.Exists(Serie.ExperimentPath))
                return;

            foreach (var i in Serie.SerieTemplates.Keys)
            {
                var template = Serie.SerieTemplates[i];
                string templatePath = Path.Combine(Serie.TemplatesPath, template.GetTemplateFileName());
                UploadTemplateOnListView(template, i, templatePath);
            }
        }

        private void AddMissingTemplate(string templateName, string templateKey)
        {
            var Item = SerieTemplateListView.Items.Add(templateName, 1);
            Item.Tag = templateKey;
            Item.ToolTipText = MISSINGTIP;
        }

        private void AddChangedTemplate(string templateName, string templateKey)
        {
            var Item = SerieTemplateListView.Items.Add(templateName, 0);
            Item.Tag = templateKey;
            Item.ToolTipText = CHANGEDTIP;
        }

        private void AddTemplate(string templateName, string templateKey)
        {
            var Item = SerieTemplateListView.Items.Add(templateName);
            Item.Tag = templateKey;
        }

        private void AddDamagedTemplate(string templateName, string templateKey)
        {
            var Item = SerieTemplateListView.Items.Add(templateName, 2);
            Item.Tag = templateKey;
            Item.ToolTipText = DAMAGEDTIP;
        }

        private void UploadTemplateOnListView(SerieTemplate template, string templateKey, string templatePath)
        {
            if (template.IsDeleted)
                return;

            if (!File.Exists(templatePath))
            {
                AddMissingTemplate(template.TemplateName, templateKey);
                return;
            }

            var templateOnComp = ExperimentSystem.UploadExperiment(templatePath, true);

            if (templateOnComp == null) 
            {
                AddDamagedTemplate(template.TemplateName, templateKey);
                return;
            }

            if(!template.IsExperimentCapabledWithTemplate(templateOnComp))
            {
                AddChangedTemplate(template.TemplateName, templateKey);
                return;
            }

            AddTemplate(template.TemplateName, templateKey);
        }

        private void SerieTemplateListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreateExperimentBtn.Visible = false;
            DeleteTemplateBtn.Visible = false;
            UploadNewTemplateBtn.Visible = false;
            CreateCopyofTemplateBtn.Visible = false;
            RenameBtn.Visible = false;

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
                    RenameBtn.Visible = true;
                    CreateCopyofTemplateBtn.Visible = true;
                    break;
            }
        }

        private void UpdateListTemplatesBtn_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            UpdateTemplateList();
            this.Cursor = Cursors.Default;
        }

        private void UploadNewTemplateBtn_Click(object sender, EventArgs e)
        {
            var Item = SelectedTemplate;

            string templateName = Item.Text;
            string templateKey = Item.Tag.ToString();
            string newNameTemplate;

            string templatePath = Path.Combine(Serie.TemplatesPath, Serie.SerieTemplates[templateKey].GetTemplateFileName());

            if (!File.Exists(templatePath))
            {
                ErrorMessage.Show("Шаблона был удалён");
                UpdateTemplateList();
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

            var uploadingTemplate = ExperimentSystem.UploadExperiment(templatePath, true);

            SerieSystem.AddNewTemplateToSerie(Serie, uploadingTemplate, templatePath, newNameTemplate);
            UpdateTemplateList();
        }

        private void DeleteTemplateBtn_Click(object sender, EventArgs e)
        {
            bool confirm = ConfirmMessageBox.Show("Вы точно хотите удалить шаблон? Все эксперементы, которые были созданы по этому шаблону, не удалятся");

            if (!confirm)
                return;

            string templateKey = SelectedTemplate.Tag.ToString();

            SerieSystem.DeleteTemplate(Serie, templateKey);
            SelectedTemplate = null;
            UpdateTemplateList();
        }

        private void CreateExperimentBtn_Click(object sender, EventArgs e)
        {
            string templateKey = SelectedTemplate.Tag.ToString();
            ExperimentData newExperiment = CreateExperimentFromTemplate(Serie.SerieTemplates[templateKey]);

            if(newExperiment  == null)
            {
                ErrorMessage.Show("Не удалось создать эксперимент");
                UpdateTemplateList();
                return;
            }

            SerieExperimentMetaData newSerieExperiment;
            newSerieExperiment.TemplateName = templateKey;
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

            return ExperimentSystem.UploadExperiment(templatePath, false);
        }

        private void CreateCopyofTemplateBtn_Click(object sender, EventArgs e)
        {
            string templateName = SelectedTemplate.Text;
            string templatePath = Path.Combine(Serie.TemplatesPath, Serie.SerieTemplates[templateName].GetTemplateFileName());
            
            if (!File.Exists(templatePath))
            {
                ErrorMessage.Show("Файл шаблона не найден");
                UpdateTemplateList();
                return;
            }

            string newName;
            using (InputFormMenu inputForm = new InputFormMenu("Создание копии шаблона", "Введите новое название шаблона", templateName))
            {
                if (inputForm.ShowDialog() != DialogResult.OK)
                    return;

                newName = inputForm.OutputValue.Trim();
            }

            if (string.IsNullOrEmpty(newName))
            {
                ErrorMessage.Show("Пустое название");
                return;
            }

            if(templateName == newName)
            {
                ErrorMessage.Show("Название копии совпадает с названием оригинала");
                return;
            }

            if(Serie.SerieTemplates.ContainsKey(newName) ||
                Serie.Experiments.ContainsKey(newName)) 
            {
                ErrorMessage.Show("Шаблон с таким же именем уже существует");
                return;
            }

            var newTamplate = ExperimentSystem.UploadExperiment(templatePath, false);

            newTamplate.Rename(newName);

            templatePath = Path.Combine(Serie.TemplatesPath, newName + TemplateSystem.EXTENSION);

            ExperimentSystem.SaveExperiment(newTamplate, templatePath);

            Serie.AddNewTemplate(newTamplate, templatePath);

            SerieSystem.SaveSerieJSON(Serie);

            UpdateTemplateList();
            SuccesMessage.Show("Копия успешно создана");
        }

        private void RenameBtn_Click(object sender, EventArgs e)
        {
            if (SerieSystem.RenameTemplate(Serie, SerieTemplateListView.SelectedItems[0].Text))
                UpdateTemplateList();
        }
    }
}