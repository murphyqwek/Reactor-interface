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
using Reactor_Interface.Classes.Templates;

namespace Reactor_Interface.Forms.Journal.SerieMenus
{
    public partial class GetTemplateMenu : Form
    {
        Jounral_menu _journal;

        public GetTemplateMenu(Jounral_menu journal, string templatesFolder = null)
        {
            InitializeComponent();
            _journal = journal;
            UploadTemplates(templatesFolder);
        }

        private void UploadTemplates(string templatesFolder)
        {
            string[] templates_array;

            if (templatesFolder == null)
                templates_array = TemplateSystem.GetTemplatesPathesArrayFromOrigin();
            else
                templates_array = TemplateSystem.GetTemplatesPathesArray(templatesFolder);

            TemplateListBox.Items.Clear();
            TemplateListBox.DoubleClick += TemplateListBox_SelectedIndexChanged;

            foreach (string template in templates_array)
            {
                var Item = TemplateListBox.Items.Add(Path.GetFileNameWithoutExtension(template));
                Item.Tag = template;
            }
        }

        private void UploadTemplate(string templateName, string templatePath)
        {
            ExperimentData template = TemplateSystem.Upload_template(templateName);

            if (template == null)
            {
                MessageBox.Show("Данный шаблон был повреждён либо удалён", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

            else
            {
                _journal.CreateNewSerie(template, templatePath);
                this.Close();
            }
        }

        private void TemplateListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string templateName = TemplateListBox.SelectedItems[0].Text;
            string templatePath = TemplateListBox.SelectedItems[0].Tag as string;
            if(!string.IsNullOrEmpty(templateName))
                UploadTemplate(templateName, templatePath);
        }
    }
}