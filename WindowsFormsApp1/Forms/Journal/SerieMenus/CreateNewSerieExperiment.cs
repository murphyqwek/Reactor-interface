using Reactor_Interface.Classes.Experiment;
using Reactor_Interface.Classes.Serie;
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

namespace Reactor_Interface.Forms.Journal.SerieMenus
{
    public partial class CreateNewSerieExperiment : Form
    {
        SerieData Serie;

        private const string MISSINGTIP = "Шаблон не был найден в папке шаблонов. Невозможно создать эксперимент";
        private const string DAMAGEDTIP = "Шаблон был повреждён. Невозможно создать эксперимент";

        public CreateNewSerieExperiment(SerieData serie)
        {
            InitializeComponent();
            Serie = serie;
            if(!File.Exists(serie.SeriePath)) 
            {
                MessageBox.Show("Файл эксперимента был удалён", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            UploadTemplates();
        }

        private void UploadTemplates()
        {
            if (!Directory.Exists(Serie.ExperimentPath))
                return;

            for (int i = 0; i < Serie.SerieTemplates.Count; i++)
            {
                var template = Serie.SerieTemplates[i];
                string templatePath = Path.Combine(Serie.TemplatesPath, template.GetTemplateFileName());
                UploadTemplate(template, i, templatePath);
            }
        }

        private void AddMissingTemplate(string template, int index)
        {
            var Item = SerieTemplateListView.Items.Add(template, 1);
            Item.Tag = index;
            Item.ToolTipText = MISSINGTIP;
        }

        private void AddDamagedTemplate(string template, int index)
        {
            var Item = SerieTemplateListView.Items.Add(template, 0);
            Item.Tag = index;
            Item.ToolTipText = DAMAGEDTIP;
        }

        private void AddTemplate(string template, int index)
        {
            var Item = SerieTemplateListView.Items.Add(template);
            Item.Tag = index;
        }

        private void UploadTemplate(SerieTemplate template, int index, string templatePath)
        {
            if (!File.Exists(templatePath))
            {
                AddMissingTemplate(template.TemplateName, index);
                return;
            }

            var templateOnComp = ExperimentSystem.UploadExperiment(templatePath);

            if(!template.IsExperimentCapabledWithTemplate(templateOnComp))
            {
                AddDamagedTemplate(template.TemplateName, index);
                return;
            }

            AddTemplate(template.TemplateName, index);
        }
    }
}
