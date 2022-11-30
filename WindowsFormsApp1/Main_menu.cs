using Reactor_Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.VisualStyles;
using System.Windows.Threading;
using WindowsFormsApp1.Classes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;



namespace WindowsFormsApp1
{
    public partial class Main_menu : Form
    {
        Size time_bar_max_size;

        string port;
        int speed;

        int count = 1;

        bool is_working = false;

        Graphic_menu graphic_menu = new Graphic_menu();

        double at;
        public Main_menu()
        {
            InitializeComponent();

            mode_groupbox.Size = new Size(730, 438);
            setting_groupbox.Size = new Size(711, 153);

            port = Interface_settings.get_port();
            if (!Port.get_ports().Contains(port)) port = null; 

            speed = Interface_settings.get_speed();
            if (!Convert.ToBoolean(speed))
            {
                speed = 9600;
                Interface_settings.save(speed);
            }

            port_checking.Start();
            this.time_bar_max_size = time_bar.Size;
        }

        private void time_syntes_bar_Scroll(object sender, EventArgs e)
        {
            time_syntes_lable.Text = "Время синтеза: " + time_bar.Value.ToString() + " c.";
        }

        private void duga_rdbtn_CheckedChanged(object sender, EventArgs e)
        {
            //730; 438
            if (duga_rdbtn.Checked){
                time_bar.Size = this.time_bar_max_size;
                time_syntes_lable.Text = "Время синтеза: 5 с.";
                time_bar.Value = time_bar.Minimum;
                time_bar.Maximum = 60;

                mode_groupbox.Size = new Size(730, 438);
                setting_groupbox.Size = new Size(711, 153);

                iteration_label.Visible = false;
                iteration_counter.Visible = false; 
            }
        }

        private void impulse_rdbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (impulse_rdbtn.Checked){
                time_bar.Size = new Size(259, 45);
                time_syntes_lable.Text = "Время выдержки: 5 с.";
                time_bar.Value = time_bar.Minimum; 
                time_bar.Maximum = 20;

                mode_groupbox.Size = new Size(730, 537);

                cold_bar.Value = cold_bar.Minimum;
                fire_bar.Value = fire_bar.Minimum;

                setting_groupbox.Size = new Size(711, 252);

                iteration_counter.Value = 2;
                iteration_label.Visible = true;
                iteration_counter.Visible = true;
            }
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
                MessageBox.Show("Нельзя менять порт во время работы реактора");
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
                ShowError("Нельзя менять значение скорости во время работы реактора");
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

                SerialPort.PortName = port.Split(' ')[0];
                SerialPort.BaudRate = speed;

                try
                {
                    graphic_menu = new Graphic_menu();
                    graphic_menu.Show();
                    SerialPort.Open();
                    SerialPort.WriteLine(working_mode + "_" + configuration + "_" + time + "_" + iteration);

                    state_lbl.ForeColor = Color.Green;
                    state_lbl.Text = "Работает";
                }
                catch (UnauthorizedAccessException)
                {
                    ShowError("Порт уже занят");
                    is_working = false;
                }
                catch (IOException)
                {
                    ShowError("Не существует такого порта. Проверьте подключение к реактору");
                    port = null;
                }
            }
            else if (port == null)
            {
                ShowError("Порт не выбран");
            }
            else if (is_working && !Port.get_ports().Contains(port))
            {
                ShowError("Порт не выбран");
                port = null;
            }
        }

        private void stop_btn_Click(object sender, EventArgs e)
        {
            if (is_working)
            {
                is_working = false;
                ClosePort();

                state_lbl.ForeColor = Color.Red;
                state_lbl.Text = "Не работает";

                anod_move_lbl.Text = "Направление движение анода: ";
            }
        }

        private string[] ParseInData(string indata)
        {
            indata = indata.Trim();
            int len = indata.Length;
            if (indata[0] == '#' && indata[len - 1] == '!')
            {
                indata = indata.Substring(1, len-2);
                string[] splitted_data = indata.Split(' ');
                if (splitted_data.Length == 4)
                {
                    string[] data = new string[4];

                    for(int i = 0; i < 4; i++)
                    {
                        data[i] = splitted_data[i].Split(':')[1].Replace('.', ',');
                    }
                    return data;
                }
            }
            return null;
        }

        private void setNewPonit(string indata)
        {

        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort recived = (SerialPort)sender;
            try
            {
                string indata = recived.ReadLine();
                string[] data = ParseInData(indata);

                if (data != null && graphic_menu != null && !graphic_menu.IsDisposed)
                {
                    Random rnd = new Random();
                    double t = 0;
                    //int time = Convert.ToInt32(data[2]);
                    if (count >= 50 && count <= 1000) {
                        t = 40;
                        double k = (rnd.NextDouble() + rnd.NextDouble()) * 3;
                        if (Convert.ToBoolean(rnd.Next(0, 1))) k = -k;
                        this.at = 30 + k;
                    }
                    if (count > 1000) this.at = 0;
                    t += this.at;
                    at /= 100;
                    t /= 100;
                    //Convert.ToDouble(data[1
                    //Convert.ToDouble(data[3]);

                    string move = data[0];

                    if (move == "up") anod_move_lbl.BeginInvoke((MethodInvoker)(() => this.anod_move_lbl.Text = "Направление движение анода:" + "вверх"));
                    if (move == "down") anod_move_lbl.BeginInvoke((MethodInvoker)(() => this.anod_move_lbl.Text = "Направление движение анода:" + "вниз"));

                    graphic_menu.update_graph("AT", count, this.at);
                    graphic_menu.update_graph("T", count, t);

                    count++;
                }

            }
            catch (Exception ex)
            {
                //TODO: испрвить это безобразие
            }
        }

        private void Main_menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(is_working)
            {
                ShowError("Реактор ещё работает. Прежде чем закрыть программу, остановите реактор");
                e.Cancel = true;
            }
            else
            {
                ClosePort();
                e.Cancel = false;
            }
        }

        private void debug_menu_btn_Click(object sender, EventArgs e)
        {
            if (!is_working)
            {
                Debug_menu debug = new Debug_menu();
                debug.Show();
            }
        }

        private void commands_menu_btn_Click(object sender, EventArgs e)
        {
            if (!is_working && !isFormOpen("Commands_menu"))
            {
                Commands_menu commands = new Commands_menu();
                commands.Show();
            }
        }

        private void ClosePort()
        {
            while (SerialPort.IsOpen)
            {
                try
                {
                    SerialPort.Close();
                }
                catch { };
            }
        }

        private void graphic_menu_btn_Click(object sender, EventArgs e)
        {
            if (!isFormOpen("Graphic_menu"))
            {
                graphic_menu = new Graphic_menu();
                graphic_menu.Show();
            }
        }

        private void ShowError(string text)
        { 
            if (!graphic_menu.IsDisposed) graphic_menu.setChartVisible(false);
            MessageBox.Show(
                    text,
                    "Ошибка запуска",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            if (!graphic_menu.IsDisposed) graphic_menu.setChartVisible(true);
        }

        private bool isFormOpen(string name)
        {
            foreach(Form form in Application.OpenForms)
            {
                if (form.Name == name) return true;
            }
            return false;
        }

        private void port_checking_Tick(object sender, EventArgs e)
        {
            if (port != null && !Port.get_ports().Contains(port) && !is_working) port = null;

            if (is_working && !SerialPort.IsOpen )
            {
                is_working = false;
                port = null;

                state_lbl.ForeColor = Color.Red;
                state_lbl.Text = "Не работает";

                anod_move_lbl.Text = "Направление движение анода: ";
            }
        }

        private void fire_bar_Scroll(object sender, EventArgs e)
        {
            fire_lbl.Text = "Время горения: " + fire_bar.Value.ToString() + " с.";
        }

        private void cold_bar_Scroll(object sender, EventArgs e)
        {
            cold_lbl.Text = "Время остывания: " + cold_bar.Value.ToString() + " с.";
        }
    }
}
