using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Classes;

//size 365; 117
//size 1188; 570
namespace WindowsFormsApp1
{
    public partial class Main_menu : Form
    {
        Size time_bar_max_size;
        string port;
        int speed;
        public Main_menu()
        {
            InitializeComponent();
            port = Interface_settings.get_port();
            speed = Interface_settings.get_speed();

            this.time_bar_max_size = time_bar.Size;
        }

        private void time_syntes_bar_Scroll(object sender, EventArgs e)
        {
            time_syntes_lable.Text = "Время синтеза: " + time_bar.Value.ToString() + " c.";
        }

        private void duga_rdbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (duga_rdbtn.Checked){
                time_bar.Size = this.time_bar_max_size;
                time_syntes_lable.Text = "Время синтеза: 5 с.";
                time_bar.Value = 5;
                time_bar.Maximum = 60;

                iteration_label.Visible = false;
                iteration_counter.Visible = false; 
            }
            //if(!duga_rdbtn.Checked && !impulse_rdbtn.Checked) duga_rdbtn.Checked = true;
        }

        private void impulse_rdbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (impulse_rdbtn.Checked){
                time_bar.Size = new Size(259, 45);
                time_syntes_lable.Text = "Время импульса: 5 с.";
                time_bar.Value = 5;
                time_bar.Maximum = 20;

                iteration_counter.Value = 2;
                iteration_label.Visible = true;
                iteration_counter.Visible = true;
            }
            //if (!duga_rdbtn.Checked && !impulse_rdbtn.Checked) impulse_rdbtn.Checked = true;
        }

        private void tigel_rdbtn_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void settings_menu_btn_DropDownOpened(object sender, EventArgs e)
        {
            port_menu_btn.Text = "Порт: ";
            if (Port.get_ports().Contains(port))
            {
                port_menu_btn.Text += port;
            }
            speed_menu_btn.Text = "Скорость: " + speed;

            foreach(string port in Port.get_ports())
            {
                port_menu_btn.DropDownItems.Add(port);
            }
            if (Port.get_ports().Length == 0) port_menu_btn.DropDownItems.Add("Портов не найдено");

            foreach (string speed in Port.get_speeds())
            {
                speed_menu_btn.DropDownItems.Add(speed);
            }
        }
    }
}
