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

namespace Reactor_Interface.Forms.Template
{
    public partial class Create_template_menu : Form
    {
        private const int max_count_tabs = 4;
        private const int a_d_button_size = 30;
        private const int add_button_x = 396, add_button_y = 6;
        private const int delete_button_x = 355, delete_button_y = 6;

        private const int button_height = 120, button_width = 60;
        private const int space_y = 80;
        private const int space_x = 302;
        private const int x = 6;
        private const int y_start = 40;

        private const int max_txtbx_len = 30;

        Template_menu template_menu;
        public Create_template_menu(Template_menu template)
        {
            InitializeComponent();
            template_menu = template;
            setup_new_tab(template_control.TabPages[0]);
            template_control.TabPages[0].Text = "Основные настройки";
        }

        private void Create_template_menu_FormClosed(object sender, FormClosedEventArgs e)
        {
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

        private void delte_btn_Click(object sender, EventArgs e)
        {
            template_control.TabPages.Remove(template_control.SelectedTab);
        }

        private void field_btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            string[] btn_loc = btn.Tag.ToString().Split(';');
            Point location = new Point(Convert.ToInt32(btn_loc[0]), Convert.ToInt32(btn_loc[1]));

            TextBox textbx = new TextBox();
            textbx.Location = location;
            textbx.MaxLength = max_txtbx_len;

            btn.Visible = false;

            template_control.SelectedTab.Controls.Add(textbx);
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
            for(int i = 0; i < 2; i++)
            {
                for(int y = 0; y < 4; y++)
                {
                    Button btn = new Button();

                    btn.Location= new Point(x + i * space_x, y_start + y * space_y);
                    btn.Size = new Size(button_height, button_width);
                    btn.Text = "Добавить поле";
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