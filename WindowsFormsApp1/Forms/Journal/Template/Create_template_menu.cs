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

namespace Reactor_Interface.Forms.Template
{
    public partial class Create_template_menu : Form
    {
        static private bool is_created_new_template = false;

        static public readonly int columns = 3;
        static public readonly int rows = 4;

        static public readonly int max_count_tabs = 4;
        static public readonly int a_d_button_size = 30;
        static public readonly int add_button_x = 761, add_button_y = 6;
        static public readonly int delete_button_x = 722, delete_button_y = 6;

        static public readonly int button_height = 120, button_width = 60;
        static public readonly int space_y = 80;
        static public readonly int space_x = 302;
        static public readonly int button_x = 6;
        static public readonly int button_y = 40;
        static public readonly string button_item_suffix = "_btn";

        static public readonly int max_txtbx_len = 30;
        static public readonly int txtbx_width = 180, txtbx_height = 30;
        static public readonly int space_txtbx_delete_filed_btn = 20;
        static public readonly string text_box_item_suffix = "_txtbx";

        Template_menu template_menu;
        public Create_template_menu(Template_menu template)
        {
            InitializeComponent();
            is_created_new_template = false;
            template_menu = template;
            setup_new_tab(template_control.TabPages[0]);
            template_control.TabPages[0].Text = "Основные настройки";
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

            RichTextBox textbx = new RichTextBox();
            textbx.Location = location;
            textbx.Font = new Font("Microsoft Sans Serif", 8);
            textbx.MaxLength = max_txtbx_len;
            textbx.Multiline = false;
            textbx.Size = new Size(txtbx_width, txtbx_height);
            textbx.Name = item_ind + text_box_item_suffix;
            btn.Visible = false;
            
            Button delete_field_btn = new Button();
            if ((x - button_x) / space_x < columns - 1) location.X += txtbx_width + space_txtbx_delete_filed_btn;
            else location.X -= (txtbx_height + space_txtbx_delete_filed_btn);
            delete_field_btn.Location = location;
            delete_field_btn.Text = "-";
            delete_field_btn.Name = item_ind;
            delete_field_btn.Font =  new Font("Microsoft Sans Serif", 10);
            delete_field_btn.FlatStyle = FlatStyle.Popup;
            delete_field_btn.BackColor = Color.Red;
            delete_field_btn.Size = new Size(txtbx_height, txtbx_height);
            delete_field_btn.Click += delete_field_btn_Click;

            template_control.SelectedTab.Controls.Add(textbx);
            template_control.SelectedTab.Controls.Add(delete_field_btn);
        }

        private void save_menu_btn_Click(object sender, EventArgs e)
        {
            string template_name = Interaction.InputBox("Введите название шаблона", "Сохранение шаблона", "");

            if(template_name.Trim() == "")
            {
                MessageBox.Show("Ввёденно пустое название шаблона", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            if (Template_system.IsTemplateCreated(template_name))
            {
                MessageBox.Show("Шалбон с таким названием существует. Выберите другое название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            Template_system.Save_result result = Template_system.Create_template_json(template_control, template_name);

            string msg_text = "", msg_title = "";
            MessageBoxIcon msg_icon = MessageBoxIcon.Information;

            this.UseWaitCursor = true;
            switch (result)
            {
                case Template_system.Save_result.EmptyFiled:
                    msg_text = "Одно или несколько полей были не заполнены";
                    msg_title = "Ошибка";
                    msg_icon = MessageBoxIcon.Error;
                    break;
                case Template_system.Save_result.CreationError:
                    msg_text = "Ошибка при сохранении шаблона";
                    msg_title = "Ошибка";
                    msg_icon = MessageBoxIcon.Error;
                    break;
                case Template_system.Save_result.EmptyPages:
                    msg_text = "Все страницы пусты";
                    msg_title = "Ошибка";
                    msg_icon = MessageBoxIcon.Error;
                    break;
                case Template_system.Save_result.Saved:
                    msg_text = "Шаблон сохранён";
                    msg_title = "Успешно";
                    msg_icon = MessageBoxIcon.Information;
                    break;
            }

            this.UseWaitCursor = false;
            MessageBox.Show(msg_text, msg_title, MessageBoxButtons.OK, msg_icon, MessageBoxDefaultButton.Button1);

            if (result == Template_system.Save_result.Saved)
            {
                template_menu.Load_templates(template_name);
                is_created_new_template = true;
                this.Close();
            }
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

        public void add_delete_buttons(TabPage page)
        {
            Button delete_btn = (page.Controls.Find("delete_btn", true).FirstOrDefault() as Button);
            page.Controls.Remove(delete_btn);
            if (template_control.TabCount > 1)
            {
                delete_btn = new Button();
                delete_btn.Name = "delete_btn";
                delete_btn.Text = "-";
                delete_btn.FlatStyle = FlatStyle.Popup;
                delete_btn.BackColor = Color.Red;
                delete_btn.Size = new Size(a_d_button_size, a_d_button_size);
                delete_btn.Font = new Font("Microsoft Sans Serif", 10);
                delete_btn.Location = new Point(delete_button_x, delete_button_y);
                delete_btn.Click += delte_btn_Click;
                page.Controls.Add(delete_btn);
            }
        }

        public void setup_new_tab(TabPage page)
        {
            page.Text = "Новое окно";
            for(int i = 0; i < columns; i++)
            {
                for(int y = 0; y < rows; y++)
                {
                    Button btn = new Button();

                    btn.Location= new Point(button_x + i * space_x, button_y + y * space_y);
                    btn.Size = new Size(button_height, button_width);
                    btn.Text = "Добавить поле";
                    btn.Name = i.ToString() + y.ToString() + button_item_suffix;
                    btn.BackColor = Color.YellowGreen;
                    btn.ForeColor = Color.Black;
                    btn.Tag = btn.Location.X.ToString() + ";" + btn.Location.Y.ToString();
                    btn.Visible = true;
                    btn.Click += field_btn_Click;
                    page.Controls.Add(btn);
                }
            }
            Button add_ = new Button();
            add_.Text = "+";
            add_.Name = "add_btn";
            add_.FlatStyle = FlatStyle.Popup;
            add_.BackColor = Color.Lime;
            add_.Size = new Size(a_d_button_size, a_d_button_size);
            add_.Location = new Point(add_button_x, add_button_y);
            add_.Font = new Font("Microsoft Sans Serif", 10);
            add_.Click += add_btn_Click;
            page.Controls.Add(add_);
        }
    }
}