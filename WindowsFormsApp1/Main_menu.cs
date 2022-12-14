﻿using Reactor_Interface;
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
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.VisualStyles;
using System.Windows.Threading;
using WindowsFormsApp1.Classes;
namespace WindowsFormsApp1
{
    public partial class Main_menu : Form
    {
        Size time_bar_max_size;

        string port;
        int speed;

        string IR_port;

        bool is_reactor_working = false;
        bool is_IR_working = false;

        int time = 0;

        Graphic_menu graphic_menu = new Graphic_menu();

        public Queue<string> dataQueue = new Queue<string>();
        public Main_menu()
        {
            InitializeComponent();
            graphic_menu = new Graphic_menu();
            mode_groupbox.Size = new Size(730, 438);
            setting_groupbox.Size = new Size(711, 153);

            port = Interface_settings.get_port();
            if (!Port.get_ports().Contains(port)) port = null; 

            speed = Interface_settings.get_speed();
            if (!Convert.ToBoolean(speed))
            {
                speed = 9600;
                Interface_settings.save_speed(speed);
            }

            IR_port = Interface_settings.get_IR_port();

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

        private void settings_menu_btn_DropDownOpened(object sender, EventArgs e)
        {
            port_menu_btn.DropDown.Items.Clear();
            speed_menu_btn.DropDownItems.Clear();
            IR_port_menu_btn.DropDownItems.Clear();

            port_menu_btn.Text = "Порт: ";
            if (Port.get_ports().Contains(port))
            {
                port_menu_btn.Text += port;
            }

            IR_port_menu_btn.Text = "IR порт: ";
            if (Port.get_ports().Contains(IR_port))
            {
                IR_port_menu_btn.Text += IR_port;
            }

            speed_menu_btn.Text = "Скорость: " + speed;

            foreach(string port in Port.get_ports())
            {
                port_menu_btn.DropDownItems.Add(port);
                IR_port_menu_btn.DropDownItems.Add(port);
            }
            if (Port.get_ports().Length == 0) port_menu_btn.DropDownItems.Add("Портов не найдено");
            if (Port.get_ports().Length == 0) IR_port_menu_btn.DropDownItems.Add("Портов не найдено");

            foreach (string speed in Port.get_speeds())
            {
                speed_menu_btn.DropDownItems.Add(speed);
            }
        }

        private void port_menu_btn_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text != "Портов не найдено" && e.ClickedItem.Text != IR_port && !is_reactor_working )
            {
                port = e.ClickedItem.Text;
                Interface_settings.save_port(port);
            }
            else if (is_reactor_working)
            {
                MessageBox.Show("Нельзя менять порт во время работы реактора");
            }
            else if (e.ClickedItem.Text == IR_port)
            {
                port = e.ClickedItem.Text;
                IR_port = "";
                Interface_settings.save_IR_port(IR_port);
                Interface_settings.save_port(port);
            }
        }

        private void IR_port_menu_btn_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text != "Портов не найдено" && e.ClickedItem.Text != port && !is_IR_working)
            {
                IR_port = e.ClickedItem.Text;
                Interface_settings.save_IR_port(IR_port);
            }
            else if (is_IR_working)
            {
                MessageBox.Show("Нельзя менять порт во время работы термометра");
            }
            else if(e.ClickedItem.Text == port)
            {
                IR_port = e.ClickedItem.Text;
                port = "";
                Interface_settings.save_IR_port(IR_port);
                Interface_settings.save_port(port);
            }
        }

        private void speed_menu_btn_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (!is_reactor_working)
            {
                speed = Convert.ToInt32(e.ClickedItem.Text);
                Interface_settings.save_speed(speed);
            }
            else
            {
                ShowError("Нельзя менять значение скорости во время работы реактора");
            }
        }

        private string get_param()
        {
            string param;

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

            param = working_mode + "_" + configuration + "_" + time + "_" + iteration;

            return param;
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            if (!is_reactor_working && port != null)
            {
                is_reactor_working = true;

                string param = get_param();

                SerialPort.PortName = port.Split(' ')[0];
                SerialPort.BaudRate = speed;

                try
                {
                    SerialPort.Open();

                    state_lbl.ForeColor = Color.Green;
                    state_lbl.Text = "Работает";
                }
                catch (UnauthorizedAccessException)
                {
                    ShowError("Порт уже занят");
                    is_reactor_working = false;
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
            else if (is_reactor_working && !Port.get_ports().Contains(port))
            {
                ShowError("Порт не выбран");
                port = null;
            }
        }

        private void stop_btn_Click(object sender, EventArgs e)
        {
            if (is_reactor_working)
            {
                is_reactor_working = false;
                ClosePort();

                state_lbl.ForeColor = Color.Red;
                state_lbl.Text = "Не работает";

                anod_move_lbl.Text = "Направление движение анода: ";
            }
        }

        private void GetData()
        {
            while (true) 
            {
                if(dataQueue.Count > 0)
                {
                    string data = dataQueue.Dequeue();
                    graphic_menu.BeginInvoke((MethodInvoker)(() => graphic_menu.update_graph("Data", 1, 1.0)));
                }
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                SerialPort recived = (SerialPort)sender;
                dataQueue.Enqueue(recived.ReadLine());
            }
            catch { }
        }

        private void debug_menu_btn_Click(object sender, EventArgs e)
        {
            if (!is_reactor_working)
            {
                Debug_menu debug = new Debug_menu();
                debug.Show();
            }
        }

        private void commands_menu_btn_Click(object sender, EventArgs e)
        {
            if (!is_reactor_working && !isFormOpen("Commands_menu"))
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
            graphic_menu.Show();
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
            if (port != null && !Port.get_ports().Contains(port) && !is_reactor_working) port = null;

            if (is_reactor_working && !SerialPort.IsOpen )
            {
                is_reactor_working = false;
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

        private void IR_timer_Tick(object sender, EventArgs e)
        {
            if (IR_Serial_Port.IsOpen)
            {
                IR_Serial_Port.Write(Data.read_command(), 0, 3);
                string inf = IR_Serial_Port.ReadExisting();
                if (inf.Length >= 9)
                {
                    inf = inf.Remove(inf.Length - 2);
                    inf = inf.Remove(0, 4);
                    tem_lbl.Text = "Температура: " + inf;
                    double temperature = Convert.ToDouble(inf);
                    graphic_menu.update_temperature(time, temperature);
                    time += 1;
                }
            }
        }

        private void Main_menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (is_reactor_working)
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

        private void IR_button_Click(object sender, EventArgs e)
        { 
            if (!is_IR_working && IR_port != "")
            {
                is_IR_working = !is_IR_working;
                IR_Serial_Port.PortName = IR_port;
                IR_Serial_Port.Open();
                IR_Serial_Port.Write(Data.init_command(), 0, 3);

                IR_button.Text = "Остановить измерения";

                IR_timer.Interval = Convert.ToInt32(Interval_IR_counter.Value) * 1000;
                Interval_IR_counter.ReadOnly = true;
                IR_timer.Start();
            }
            else if (is_IR_working && IR_port != "") 
            {
                is_IR_working = !is_IR_working;
                IR_Serial_Port.Write(Data.stop_command(), 0, 3);
                IR_Serial_Port.Close();

                IR_button.Text = "Начать измерения";
                Interval_IR_counter.ReadOnly = false;

                IR_timer.Stop();
            }
            else if (IR_port == "")
            {
                ShowError("Порт термометра не выбран");
            }
        }
    }
}