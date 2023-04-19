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
        private string using_template_text = "Используемый шаблон:\r";
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
            using_template_lbl.Text = using_template_text;
            templates_array = Template_system.get_template_array();

            template_view.Items.Clear();
            foreach (string template in templates_array)
                template_view.Items.Add(template);

            string using_template = Interface_settings.get_using_template();

            if (!templates_array.Contains(using_template))
            {
                using_template_lbl.Text += template_not_chosen;
                Interface_settings.save_using_template("");
            }
            else if (using_template == "" || using_template == null)
            {
                using_template_lbl.Text += template_not_chosen;
            }
            else
            {
                using_template_lbl.Text += using_template;
            }

            if (selected_template != "")
            {
                if (templates_array.Contains(selected_template))
                    update_chosen_lbl(selected_template);
            }
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

        public void upload_template(string new_template, string old_template)
        {
            string chosen_template = using_template_lbl.Text.Split('\r')[1];

            if (old_template != chosen_template && chosen_template != template_not_chosen)
                return;

            Classes.Templates.Template template = Template_system.Upload_template(new_template);
            Template_system.Save_using_template_registry(template.Name);
            jounral_menu.upload_template(template);
            using_template_lbl.Text = using_template_text + template.Name;
        }

        private void upload_btn_Click(object sender, EventArgs e)
        {
            
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
                Template_system.Delete_template(get_chosen_template());
                Load_templates();
                chosen_template_lbl.Text = chosen_template_text + template_not_chosen;
            }
        }

        private void change_btn_Click(object sender, EventArgs e)
        {
            Classes.Templates.Template template = Template_system.Upload_template(get_chosen_template());
            Create_template_menu modify_Template_menu = new Create_template_menu(this, template);
            this.Hide();
            modify_Template_menu.Show();
        }

        private void UploadTemplateBtn_Click(object sender, EventArgs e)
        {
            string chosen_template_name = get_chosen_template();

            if (chosen_template_name == null)
            {
                MessageBox.Show("Шаблон не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            if (Interface_settings.get_using_template() == chosen_template_name)
                return;

            Classes.Templates.Template template = Template_system.Upload_template(chosen_template_name);

            if (template == null)
            {
                MessageBox.Show("Данный шаблон был повреждён либо удалён", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {
                Template_system.Save_using_template_registry(template.Name);
                jounral_menu.upload_template(template);
                using_template_lbl.Text = using_template_text + template.Name;
                MessageBox.Show("Шаблон загружен", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.Close();
            }
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

                Template_system.UploadTemplates(templates);

                Load_templates();

                MessageBox.Show("Шаблоны загружены", "Успешно", 
                                MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void UpdateTemplateBtn_Click(object sender, EventArgs e)
        {
            Load_templates();
        }
    }
}