using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using WindowsFormsApp1.Classes;
using Reactor_Interface.Classes;
using Reactor_Interface.Forms.Template;
using Reactor_Interface.Classes.Templates;
using Reactor_Interface.Classes.GoogleAPI;
using System.IO;

namespace Reactor_Interface.Forms.Experiment
{
    public partial class Template_menu : Form
    {
        private string chosen_template_text = "Выбранный шаблон:\r";
        //private string using_template_text = "Используемый шаблон:\r";
        private string template_not_chosen = "Шаблон не выбран";

        private string[] templates_array = new string[0];

        private Jounral_menu jounral_menu;

        public Template_menu(Jounral_menu jounral_menu)
        {
            InitializeComponent();
            Load_templates();
            template_view.Columns[0].Width = template_view.Width;
            this.jounral_menu = jounral_menu;
        }

        public void Load_templates(string selected_template = "")
        {
            templates_array = TemplateSystem.GetTemplatesArray();

            template_view.Items.Clear();
            template_view.DoubleClick += Template_view_DoubleClick;

            foreach (string template in templates_array)
                template_view.Items.Add(template);

            if (selected_template != "")
            {
                if (templates_array.Contains(selected_template))
                    update_chosen_lbl(selected_template);
            }
        }

        private void Template_view_DoubleClick(object sender, EventArgs e)
        {
            //UploadTemplate();
        }

        public void update_chosen_lbl(string template)
        {
            chosen_template_lbl.Text = chosen_template_text + template;
            chosen_template_lbl.Tag = template;
        }

        private void create_btn_Click(object sender, EventArgs e)
        {
            
        }
        private void template_view_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (template_view.SelectedItems.Count > 0)
                update_chosen_lbl(template_view.SelectedItems[0].Text);
        }

        private string get_chosen_template()
        {
            if (chosen_template_lbl.Tag == null)
                return null;

            return chosen_template_lbl.Tag.ToString();
        }

        private void template_contextmenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "delete_btn":
                    delete_btn_Clicked();
                    break;
            }
        }

        private void delete_btn_Clicked()
        {
            DialogResult result = MessageBox.Show("Вы точно хотите удалить шалбон?", "Пердупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);


            if (result == DialogResult.Yes)
            {
                TemplateSystem.Delete_template(get_chosen_template());
                Load_templates();
                chosen_template_lbl.Text = chosen_template_text + template_not_chosen;
            }
        }

        private void change_btn_Click(object sender, EventArgs e)
        {
            string templateName = get_chosen_template();
            ExperimentData template = TemplateSystem.Upload_template(templateName);
            Create_template_menu modify_Template_menu = new Create_template_menu(this, template, templateName);
            this.Hide();
            modify_Template_menu.Show();
        }

        private void UploadTemplate()
        {
            if (jounral_menu.NeedToCancel())
            {
                return;
            }


            string chosen_template_name = get_chosen_template();

            if (chosen_template_name == null)
            {
                MessageBox.Show("Шаблон не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            ExperimentData template = TemplateSystem.Upload_template(chosen_template_name);

            if (template == null)
            {
                ErrorMessage.Show("Данный шаблон был повреждён либо удалён");
            }

            else
            {
                jounral_menu.upload_template(template);
                SuccesMessage.Show("Шаблон загружен");
                this.Close();
            }
        }

        private void UploadTemplateBtn_Click(object sender, EventArgs e)
        {
            UploadTemplate();
        }

        private void CreateNewTemplateBtn_Click(object sender, EventArgs e)
        {
            Create_template_menu create_menu = new Create_template_menu(this);
            this.Hide();
            create_menu.Show();
        }

        private void AddTemplateBtn_Click(object sender, EventArgs e)
        {
            using (FileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "Template files (*.template)|*.template";

                if (fileDialog.ShowDialog() != DialogResult.OK)
                    return;

                var templates = fileDialog.FileNames;

                TemplateSystem.UploadTemplates(templates);

                Load_templates();

                SuccesMessage.Show("Шаблон загружен");
            }
        }

        private void UpdateTemplateBtn_Click(object sender, EventArgs e)
        {
            Load_templates();
        }
    }
}