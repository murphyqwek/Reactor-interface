using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reactor_Interface.Forms.Experiment;
using Microsoft.VisualBasic;
using Reactor_Interface.Classes;
using WindowsFormsApp1.Classes;
using Templates = Reactor_Interface.Classes.Templates;
using Reactor_Interface.Classes.Templates;
using System.Web.UI;
using System.Data.Common;
using Microsoft.Office.Interop.Access.Dao;
using Reactor_Interface.Classes.Experiment;

namespace Reactor_Interface.Forms.Template
{
    public partial class Create_template_menu : Form
    {
        static private bool is_created_new_template = false;

        static public readonly int columns = 3;
        static public readonly int rows = 4;

        static public readonly int max_count_tabs = 4;
        static public readonly int a_d_button_size = (int)(DPI.factor.Width * 30);
        static public readonly int add_button_x = (int)(DPI.factor.Width * 761), add_button_y = 6;
        static public readonly int delete_button_x = (int)(DPI.factor.Width * 722), delete_button_y = 6;

        static public readonly int button_height = (int)(DPI.factor.Height * 120), button_width = (int)(DPI.factor.Width * 60);
        static public readonly int space_y = (int)(DPI.factor.Height * 80);
        static public readonly int space_x = (int)(DPI.factor.Width * 302);
        static public readonly int button_x = 6;
        static public readonly int button_y = 25;
        static public readonly string button_item_suffix = "_btn";

        static public readonly int max_txtbx_len = 30;
        static public readonly int txtbx_width = (int)(DPI.factor.Width * 180), txtbx_height = (int)(DPI.factor.Height * 30);
        static public readonly int space_txtbx_delete_filed_btn = 20;
        static public readonly string text_box_item_suffix = "_txtbx";

        static public readonly string weigherTag = "$МАССА$";

        private string template_name = "";
        private bool Ismodifying = false;

        Template_menu template_menu;
        public Create_template_menu(Template_menu template_menu, ExperimentData template = null, string templateName = null)
        {
            InitializeComponent();
            this.template_menu = template_menu;

            if (template == null)
                setup_new_template();
            else
                parse_template(template, templateName);
        }

        private void parse_template(ExperimentData template, string templateName)
        {
            template_control.TabPages.Clear();

            template_name = templateName;

            Ismodifying = true;

            this.Text = "Редактирование шаблона: " + template_name;

            foreach (string page_name in template.Pages.Keys)
            {
                TabPage page = new TabPage
                {
                    Text = page_name,
                    BackColor = Color.White
                };

                Dictionary<string, FieldData> fields = new Dictionary<string, FieldData>();

                foreach(var field in template.Pages[page_name])
                {
                    fields.Add(field.Row.ToString() + "_" + field.Column.ToString(), field);
                }

                for (int column = 0; column < columns; column++)
                {
                    for (int row = 0; row < rows; row++)
                    {
                        FieldData field;

                        if(!fields.TryGetValue(row.ToString() + "_" + column.ToString(), out field))
                        {
                            create_new_field(column, row, page);
                            continue;
                        }

                        string box_type = field.MetaData.ToString();
                        string field_name = field.FieldName.ToString();

                        add_created_textbox(column, row, template, box_type, field_name, page);
                    }
                }

                template_control.TabPages.Add(page);
            }
        }

        private void create_new_field(int column, int row, TabPage page, bool IsVisible = true)
        {
            Button btn = new Button
            {
                Location = new Point(button_x + column * space_x, button_y + row * space_y),
                Size = new Size(button_height, button_width),
                Text = "Добавить поле",
                Name = column.ToString() + row.ToString() + button_item_suffix,
                BackColor = Color.YellowGreen,
                ForeColor = Color.Black,
                Visible = IsVisible
            };

            btn.Tag = btn.Location.X.ToString() + ";" + btn.Location.Y.ToString();
            btn.Click += field_btn_Click;

            page.Controls.Add(btn);
        }

        private void create_add_page_btn(TabPage page)
        {
            Button add_ = new Button
            {
                Text = "+",
                Name = "add_btn",
                FlatStyle = FlatStyle.Popup,
                BackColor = Color.Lime,
                Size = new Size(a_d_button_size, a_d_button_size),
                Location = new Point(add_button_x, add_button_y),
                Font = new Font("Microsoft Sans Serif", 10),
            };

            add_.Click += add_btn_Click;

            page.Controls.Add(add_);
        }

        private void add_created_textbox(int column, int row, Templates.ExperimentData template, string type, string field_name, TabPage page)
        {
            string item_ind = string.Format("{0}{1}", column, row);
            Point location = new Point(column * space_x + button_x, button_y + row * space_y + button_width / 4);

            create_new_field(column, row, page, false);
            create_add_page_btn(page);

            RichTextBox textBox = new RichTextBox
            {
                Text = field_name,
                Location = location,
                Size = new Size(txtbx_width, txtbx_height),
                Font = new Font("Microsoft Sans Serif", 8),
                MaxLength = max_txtbx_len,
                Name = item_ind + text_box_item_suffix,
                Tag = type,
                ContextMenuStrip = context_menu,
                Multiline = false
            };

            if (!string.IsNullOrEmpty(type))
            {
                textBox.BackColor = Color.LightGray;
            }

            if (column < columns - 1)
                location.X += txtbx_width + space_txtbx_delete_filed_btn;
            else
                location.X -= (txtbx_height + space_txtbx_delete_filed_btn);

            Button delete_field_btn = new Button
            {
                Location = location,
                Text = "-",
                Name = item_ind,
                Font = new Font("Microsoft Sans Serif", 10),
                FlatStyle = FlatStyle.Popup,
                BackColor = Color.Red,
                Size = new Size(txtbx_height, txtbx_height),
            };

            delete_field_btn.Click += delete_field_btn_Click;

            page.Controls.Add(delete_field_btn);
            page.Controls.Add(textBox);
        }

        private void setup_new_template()
        {
            is_created_new_template = false;
            setup_new_tab(template_control.TabPages[0]);
            template_control.TabPages[0].Text = "Основные настройки";
        }

        protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
        {
            base.ScaleControl(factor, specified);
            //DPI.SetFactor(factor);
        }

        private void Create_template_menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(!is_created_new_template)
                template_menu.Load_templates();
            template_menu.Show();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            if(template_control.TabCount == max_count_tabs)
            {
                MessageBox.Show("Достигнут лимит страниц", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            TabPage tab = new TabPage();
            tab.BackColor = Color.White;
            template_control.TabPages.Add(tab);
            setup_new_tab(tab);
            template_control.SelectedTab = tab;
        }

        private void delete_field_btn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string item_ind = button.Name;

            var text_box = template_control.SelectedTab.Controls.Find(item_ind + text_box_item_suffix, true).First();
            template_control.SelectedTab.Controls.Remove(text_box);
            template_control.SelectedTab.Controls.Remove(button);

            template_control.SelectedTab.Controls.Find(item_ind + button_item_suffix, true).FirstOrDefault().Visible = true;
        }

        private void delte_btn_Click(object sender, EventArgs e)
        {
            template_control.TabPages.Remove(template_control.SelectedTab);
        }

        private void field_btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            string[] btn_loc = btn.Tag.ToString().Split(';');
            string item_ind = btn.Name.Split('_')[0];
            int x = Convert.ToInt32(btn_loc[0]), y = Convert.ToInt32(btn_loc[1]);
            Point location = new Point(x, y + button_width / 4);

            RichTextBox textbx = new RichTextBox {
                Location = location,
                Font = new Font("Microsoft Sans Serif", 8),
                MaxLength = max_txtbx_len,
                Multiline = false,
                Size = new Size(txtbx_width, txtbx_height),
                Name = item_ind + text_box_item_suffix,
                ContextMenuStrip = context_menu,
                Tag = ""
            };

            btn.Visible = false;

            if ((x - button_x) / space_x < columns - 1)
                location.X += txtbx_width + space_txtbx_delete_filed_btn;
            else
                location.X -= (txtbx_height + space_txtbx_delete_filed_btn);

            Button delete_field_btn = new Button {
                Location = location,
                Text = "-",
                Name = item_ind,
                Font = new Font("Microsoft Sans Serif", 10),
                FlatStyle = FlatStyle.Popup,
                BackColor = Color.Red,
                Size = new Size(txtbx_height, txtbx_height),
            };

            delete_field_btn.Click += delete_field_btn_Click;

            template_control.SelectedTab.Controls.Add(textbx);
            template_control.SelectedTab.Controls.Add(delete_field_btn);
        }

        private void show_result(TemplateSystem.Save_result result)
        {
            string msg_text = "", msg_title = "";
            MessageBoxIcon msg_icon = MessageBoxIcon.Information;

            switch (result)
            {
                case TemplateSystem.Save_result.EmptyFiled:
                    msg_text = "Одно или несколько полей были не заполнены";
                    msg_title = "Ошибка";
                    msg_icon = MessageBoxIcon.Error;
                    break;
                case TemplateSystem.Save_result.CreationError:
                    msg_text = "Ошибка при сохранении шаблона";
                    msg_title = "Ошибка";
                    msg_icon = MessageBoxIcon.Error;
                    break;
                case TemplateSystem.Save_result.EmptyPages:
                    msg_text = "Все страницы пусты";
                    msg_title = "Ошибка";
                    msg_icon = MessageBoxIcon.Error;
                    break;
                case TemplateSystem.Save_result.Saved:
                    msg_text = "Шаблон сохранён";
                    msg_title = "Успешно";
                    msg_icon = MessageBoxIcon.Information;
                    break;
            }

            MessageBox.Show(msg_text, msg_title, MessageBoxButtons.OK, msg_icon, MessageBoxDefaultButton.Button1);
        }

        private void save_menu_btn_Click(object sender, EventArgs e)
        {
            string old_template_name = this.template_name;
            string template_name = Interaction.InputBox("Введите название шаблона", "Сохранение шаблона", this.template_name);

            if(template_name.Trim() == "")
            {
                MessageBox.Show("Ввёденно пустое название шаблона", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            if (TemplateSystem.IsTemplateCreated(template_name) && !Ismodifying)
            {
                bool recreated = Recreate_template(template_name);
                if (!recreated)
                    return;
            }

            if (Ismodifying)
                TemplateSystem.Delete_template(this.template_name);

            TemplateSystem.Save_result result = TemplateSystem.Create_template_json(template_control, template_name);

            show_result(result);

            if (result == TemplateSystem.Save_result.Saved)
            {
                template_menu.Load_templates(template_name);
                is_created_new_template = true;
                this.Close();
            }
        }

        private bool Recreate_template(string template_name)
        {
            var result = MessageBox.Show("Шалбон с таким названием существует. Перезаписать шаблон?", 
                                        "Внимание", 
                                        MessageBoxButtons.YesNoCancel, 
                                        MessageBoxIcon.Error, 
                                        MessageBoxDefaultButton.Button3);

            if(result == DialogResult.Yes) 
            { 
                TemplateSystem.Delete_template(template_name);
                return true;
            }

            return false;
        }

        private void rename_page_menu_btn_Click(object sender, EventArgs e)
        {
            string page_name = Interaction.InputBox("Введите название вкладки", "Изменение вклакди", template_control.SelectedTab.Text);
            page_name = page_name == "" ? template_control.SelectedTab.Text : page_name;
            template_control.SelectedTab.Text = page_name;
        }

        private void template_control_Selecting(object sender, TabControlCancelEventArgs e)
        {
            add_delete_buttons(e.TabPage);
        }

        private void select_weigh_btn_Click(object sender, EventArgs e)
        {
            var textbox = getRichTextBoxFromContextMenuStrip((ToolStripItem)sender);

            if (textbox == null)
                return;

            textbox.BackColor = Color.LightGray;
            textbox.Tag += ";" + weigherTag;
        }

        private void unselect_weigh_btn_Click(object sender, EventArgs e)
        {
            var textbox = getRichTextBoxFromContextMenuStrip((ToolStripItem)sender);

            if (textbox == null)
                return;

            textbox.BackColor = Color.White;
            textbox.Tag = textbox.Tag.ToString().Replace(";" + weigherTag, "");
        }

        public void add_delete_buttons(TabPage page)
        {
            Button delete_btn = (page.Controls.Find("delete_btn", true).FirstOrDefault() as Button);
            page.Controls.Remove(delete_btn);
            if (template_control.TabCount > 1)
            {
                delete_btn = new Button { 
                    Name = "delete_btn",
                    Text = "-",
                    FlatStyle = FlatStyle.Popup,
                    BackColor = Color.Red,
                    Size = new Size(a_d_button_size, a_d_button_size),
                    Font = new Font("Microsoft Sans Serif", 10),
                    Location = new Point(delete_button_x, delete_button_y)
                };

                delete_btn.Click += delte_btn_Click;
                page.Controls.Add(delete_btn);
            }
        }

        public void setup_new_tab(TabPage page)
        {
            page.Text = "Новое окно";
            for (int column = 0; column < columns; column++)
            {
                for (int row = 0; row < rows; row++)
                {
                    create_new_field(column, row, page);
                }
            }

            create_add_page_btn(page);
        }

        private RichTextBox getRichTextBoxFromContextMenuStrip(ToolStripItem toolStripItem)
        {
            if (toolStripItem == null)
                return null;

            ContextMenuStrip owner = toolStripItem.Owner as ContextMenuStrip;

            if (owner == null)
                return null;

            RichTextBox textbox = (RichTextBox)owner.SourceControl;

            return textbox;
        }

        private void context_menu_Opening(object sender, CancelEventArgs e)
        {
            RichTextBox textbox = (RichTextBox)context_menu.SourceControl;

            if (textbox == null)
                return;

            string tag = textbox.Tag.ToString();
            bool isWeigherfield = tag.Contains(weigherTag);

            context_menu.Items[0].Visible = !isWeigherfield;
            context_menu.Items[1].Visible = isWeigherfield;

            e.Cancel = false;
        }

    }
}