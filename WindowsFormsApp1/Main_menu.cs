using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
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

        bool is_working = false;
        public Main_menu()
        {
            InitializeComponent();
            port = Interface_settings.get_port();
            if (!Port.get_ports().Contains(port)) port = null; 

            speed = Interface_settings.get_speed();
            if (!Convert.ToBoolean(speed))
            {
                speed = 9600;
                Interface_settings.save(speed);
            }
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
            port_menu_btn.DropDown.Items.Clear();
            speed_menu_btn.DropDownItems.Clear();

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

        private void port_menu_btn_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text != "Портов не найдено" && !is_working)
            {
                port = e.ClickedItem.Text;
                Interface_settings.save(port);
            }
            else if (is_working)
            {
                MessageBox.Show(
                        "Нельзя менять порт во время работы реактора",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }

        private void speed_menu_btn_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (!is_working)
            {
                speed = Convert.ToInt32(e.ClickedItem.Text);
                Interface_settings.save(speed);
            }
            else
            {
                MessageBox.Show(
                        "Нельзя менять значение скорости во время работы реактора",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            if (!is_working && port != null)
            {
                is_working = true;

                string working_mode = "M:";
                string configuration = "C:";
                string time = "T:";
                string iteration = "I:";

                if (duga_rdbtn.Checked)
                {
                    working_mode += "duga";
                    iteration = "";
                }
                else
                {
                    working_mode += "impulse";
                    iteration += iteration_counter.Value.ToString();
                }

                if (tigel_rdbtn.Checked) configuration += "tigel";
                else configuration += "voilok";

                time += time_bar.Value.ToString();

                SerialPort.PortName = port;
                SerialPort.BaudRate = speed;

                try
                {
                    SerialPort.Open();
                    SerialPort.WriteLine(working_mode + "_" + configuration + "_" + time + "_" + iteration);
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show(
                            "Порт уже занят",
                            "Ошибка отправки данных",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    is_working = false;
                }
            }
            else if (port == null)
            {
                MessageBox.Show(
                            "Порт не выбран",
                            "Ошибка запуска",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void stop_btn_Click(object sender, EventArgs e)
        {
            if (is_working)
            {
                is_working = false;
                SerialPort.Close();
            }
        }

        private void SerialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            SerialPort recived = (SerialPort)sender;
            try
            {
                string indata = recived.ReadTo("!");
                if (indata != "\r") label1.BeginInvoke((MethodInvoker)(() => this.label1.Text = indata));
            }
            catch
            {
                //TODO: испрвить это безобразие
            }
        }

        private void Main_menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(is_working)
            {
                MessageBox.Show(
                    "Реактор ещё работает. Прежде чем закрыть программу, остановите реактор",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                e.Cancel = true;
            }
            else
            {
                SerialPort.Close();
                e.Cancel = false;
            }
        }
    }
}
