using Reactor_Interface;
using Reactor_Interface.Classes;
using Reactor_Interface.Classes.GoogleAPI;
using Reactor_Interface.Classes.Weigher;
using Reactor_Interface.Forms;
using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security.RightsManagement;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.VisualStyles;
using System.Windows.Threading;
using WindowsFormsApp1.Classes;
using Label = System.Windows.Forms.Label;

namespace WindowsFormsApp1
{
    public partial class Main_menu : Form
    {
        Size time_bar_max_size;

        string port;
        int speed;

        string IR_port;

        static int step = 0;

        static bool is_reactor_working = false;
        static bool is_IR_working = false;

        static readonly double koef = 0.0029;

        static Stopwatch stopwatch = new Stopwatch();

        static Graphic_menu graphic_menu = new Graphic_menu();

        Thread Reactor_reading_thread;
        Thread Parsing_data_thread;
        Thread IR_reading_thread;

        static ConcurrentQueue<string> dataQueue = new ConcurrentQueue<string>();
        //static bool Wait = false;

        string pressed_button = " ";
        public Main_menu()
        {
            InitializeComponent();

            graphic_menu = new Graphic_menu();
            graphic_menu.Clear_Graphic();

            IntPtr intPtr = graphic_menu.Handle; //Создаётся Handle, без этой строчки данные с реактора не смогут отображаться на графике, когда окно закрыто

            DPI.ResizeGroupbox(reactor_box, new Size(780, 438));
            DPI.ResizeGroupbox(mode_settings_box, new Size(711, 153));

            port = Interface_settings.get_port();
            speed = Interface_settings.get_speed();
            IR_port = Interface_settings.get_IR_port();

            port_checking.Start();

            this.time_bar_max_size = time_bar.Size;
        }

        protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
        {
            base.ScaleControl(factor, specified);
            DPI.SetFactor(factor);
            this.Size = new Size((int)((button2.Location.X + button2.Size.Width * 1.4) * factor.Width), (int)((stop_btn.Location.Y + stop_btn.Size.Height * 1.4) * factor.Height));
        }

        private void time_syntes_bar_Scroll(object sender, EventArgs e)
        {
            time_syntes_lable.Text = "Время синтеза: " + time_bar.Value.ToString() + " c.";
        }

        private void duga_rdbtn_CheckedChanged(object sender, EventArgs e)
        {
            //730; 438
            if (duga_rdbtn.Checked)
            {
                time_bar.Size = this.time_bar_max_size;
                time_syntes_lable.Text = "Время синтеза: 5 с.";
                time_bar.Value = time_bar.Minimum;
                time_bar.Maximum = 60;

                DPI.ResizeGroupbox(reactor_box, new Size(780, 438));
                DPI.ResizeGroupbox(mode_settings_box, new Size(711, 153));

                iteration_label.Visible = false;
                iteration_counter.Visible = false;

            }
        }

        private void impulse_rdbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (impulse_rdbtn.Checked)
            {
                time_bar.Size = new Size(259, 45);
                time_syntes_lable.Text = "Время выдержки: 5 с.";
                time_bar.Value = time_bar.Minimum;
                time_bar.Maximum = 20;

                DPI.ResizeGroupbox(reactor_box, new Size(780, 537));

                cold_bar.Value = cold_bar.Minimum;
                fire_bar.Value = fire_bar.Minimum;

                DPI.ResizeGroupbox(mode_settings_box, new Size(751, 252));

                iteration_counter.Value = 2;
                iteration_label.Visible = true;
                iteration_counter.Visible = true;
            }
        }

        private void settings_menu_btn_DropDownOpened(object sender, EventArgs e)
        {
            upload_ports();
            upload_speeds();
            upload_drives();
        }

        private void upload_drives()
        {
            google_drive_menu_btn.DropDown.Items.Clear();

            google_drive_menu_btn.Text = "Google drive: " + Drive.name;

            foreach (string drive in Google_data.Get_drives())
            {
                google_drive_menu_btn.DropDownItems.Add(drive);
            }

            google_drive_menu_btn.DropDownItems.Add("Добавить новый диск").Tag = "add";
        }

        private void upload_speeds()
        {
            speed_menu_btn.DropDownItems.Clear();
            speed_menu_btn.Text = "Скорость: " + speed;

            foreach (string speed in Port.get_speeds())
            {
                speed_menu_btn.DropDownItems.Add(speed);
            }
        }

        private void upload_ports()
        {
            port_menu_btn.DropDown.Items.Clear();
            IR_port_menu_btn.DropDownItems.Clear();

            port_menu_btn.Text = "Порт реактора: ";
            if (Port.get_ports().Contains(port))
            {
                port_menu_btn.Text += port;
            }

            foreach(string port in Port.get_ports())
            {
                port_menu_btn.DropDownItems.Add(port);
                IR_port_menu_btn.DropDownItems.Add(port);
            }

            IR_port_menu_btn.Text = "IR порт: ";
            if (Port.get_ports().Contains(IR_port))
            {
                IR_port_menu_btn.Text += IR_port;
            }

            if (Port.get_ports().Length == 0)
            {
                port_menu_btn.DropDownItems.Add("Портов не найдено");
                IR_port_menu_btn.DropDownItems.Add("Портов не найдено");
            }
        }

        private void port_menu_btn_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text != "Портов не найдено" && e.ClickedItem.Text != IR_port && !is_reactor_working)
            {
                port = e.ClickedItem.Text;
                Interface_settings.save_port(port);
            }
            else if (is_reactor_working || is_IR_working)
            {
                ShowError("Нельзя менять порт во время работы реактора");
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
            else if (is_IR_working || is_reactor_working)
            {
                MessageBox.Show("Нельзя менять порт во время работы термометра");
            }
            else if (e.ClickedItem.Text == port)
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

        private void google_drive_btn_DropDownItem(object sender, EventArgs e)
        {
            if (Drive.name != null && Drive.name != "")
            {
                Drive_settings_menu drive_settings = new Drive_settings_menu();
                drive_settings.ShowDialog();
            }
        }

        private string get_params()
        {
            string param = "1";

            param += time_bar.Value.ToString() + "n";

            param += Data.get_tok_mode(tok_mode_list.Text);
            if (tigel_rdbtn.Checked)
                param += "0";
            else
                param += "1";

            if (duga_rdbtn.Checked)
            {
                param += "es";
            }
            else
            {
                param += "es";
            }

            return param;
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            if (!is_reactor_working && port != null)
            {
                dataQueue = new ConcurrentQueue<string>(); //очищаем очередь
                start_stopwatch();

                step = 0;

                is_reactor_working = true;

                string param = get_params();

                SerialPort.PortName = port.Split(' ')[0];
                SerialPort.BaudRate = speed;
                try
                {
                    
                    graphic_menu.Clear_Graphic();
                    graphic_menu.is_drawing = true;

                    Parsing_data_thread = new Thread(() => Parsing_data(state_lbl, SerialPort));
                    Parsing_data_thread.IsBackground = true;
                    Parsing_data_thread.Priority = ThreadPriority.Highest;

                    Parsing_data_thread.Start();

                    SerialPort.Open();
                    SerialPort.Write(param);
                    
                    state_lbl.ForeColor = Color.Green;
                    state_lbl.Text = "Работает";

                    Reactor_reading_thread = new Thread(() => Reading_Reactor_Port(SerialPort));
                    Reactor_reading_thread.IsBackground = true;
                    Reactor_reading_thread.Priority = ThreadPriority.Highest;
                    Reactor_reading_thread.Start();
                }
                catch (UnauthorizedAccessException)
                {
                    ShowError("Порт реактора уже занят");
                    is_reactor_working = false;
                    stop_stopwatch();
                }
                catch (IOException)
                {
                    ShowError("Не существует такого порта. Проверьте подключение к реактору");
                    port = null;
                    stop_stopwatch();
                }
            }
            else if (port == null)
            {
                ShowError("Порт реактора не выбран");
            }
            else if (is_reactor_working && !Port.get_ports().Contains(port))
            {
                ShowError("Порт реактора не выбран");
                port = null;
            }
        }

        private void stop_btn_Click(object sender, EventArgs e)
        {
            if (is_reactor_working)
            {
                SerialPort.Write("d");
                Stop_reactor(state_lbl, SerialPort, false);
            }
        }


        private static void Reading_Reactor_Port(SerialPort serialPort)
        {
            //TODO: доделать приём данных
            try
            {
                while (is_reactor_working)
                {
                    try
                    {
                        string data = serialPort.ReadLine();
                        data += " " + stopwatch.ElapsedMilliseconds.ToString();
                        dataQueue.Enqueue(data);
                    }
                    catch { }
                }
            }
            catch (ThreadInterruptedException)
            {
                //int k = 0;
            }
        }

        private static void Parsing_data(Label state_lbl, SerialPort Reactor_port)
        {
            string temp;
            try
            {
                while (is_reactor_working)
                {
                    if (dataQueue.TryDequeue(out temp))
                    {
                        //try
                        //{
                        string[] data = temp.Split(' ');
                        data[0] = data[0].Replace("\r", "");

                        string[] reactor_data = data[0].Split(';');

                        long time = Convert.ToInt64(data[data.Length - 1]);

                        foreach (string sub_data in reactor_data)
                        {
                            if (sub_data.Contains('='))
                            {
                                string[] parametr = sub_data.Split('=');

                                double value;
                                parametr[1] = parametr[1].Replace('.', ',');

                                switch (parametr[0])
                                {
                                    case "tok":
                                        value = (Convert.ToDouble(parametr[1]) - 2.20) / koef;
                                        graphic_menu.update_tok(time, value);
                                        break;
                                    case "aver_tok":
                                        value = (Convert.ToDouble(parametr[1]) - 2.20) / koef;
                                        graphic_menu.update_aver_tok(time, value);
                                        break;
                                    case "step":
                                        if (parametr[1] == "1")
                                            step += 1;
                                        else if (parametr[1] == "-1")
                                            step -= 1;
                                        graphic_menu.update_step(time, step);
                                        break;
                                }
                            }
                            else if (data[0] == "end")
                            {
                                Stop_reactor(state_lbl, Reactor_port, true);
                                break;
                            }

                        }
                    }
                }
            }
            catch (ThreadInterruptedException)
            {
                //int k = 0;

            }
            catch { }
        }

        static void Stop_reactor(Label state_lbl, SerialPort Reactor_port, bool ShowMessageStop)
        {
            if (!is_IR_working)
            {
                graphic_menu.is_drawing = false;
                stop_stopwatch();
            }

            state_lbl.Invoke((MethodInvoker)delegate
            {
                state_lbl.Text = "Не работает";
                state_lbl.ForeColor = Color.Red;
            });

            while (Reactor_port.IsOpen)
            {
                try
                {
                    Reactor_port.Close();
                }
                catch { };
            }
            is_reactor_working = false;

            if (ShowMessageStop)
            {
                MessageBox.Show("Синтез закончен", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

        private void Close_Reactor_Port()
        {
            while (SerialPort.IsOpen)
            {
                try
                {
                    if (pressed_button != " ")
                    {
                        SerialPort.WriteLine(Data.stop_anod_command);
                        pressed_button = " ";
                    }
                        
                    SerialPort.Close();
                }
                catch { };
            }
        }

        private void Close_IR_Port()
        {
            while (IR_Serial_Port.IsOpen)
            {
                try
                {
                    IR_Serial_Port.Close();
                }
                catch { };
            }
        }

        private void graphic_menu_btn_Click(object sender, EventArgs e)
        {
            graphic_menu.Show(); 
            graphic_menu.Focus();
        }

        private void ShowError(string text)
        {
            if (!graphic_menu.IsDisposed) graphic_menu.setChartVisible(false);
            MessageBox.Show(
                    text,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            if (!graphic_menu.IsDisposed) graphic_menu.setChartVisible(true);
        }

        private bool isFormOpen(string name)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == name) return true;
            }
            return false;
        }

        private void port_checking_Tick(object sender, EventArgs e)
        {
            if (port != null && !Port.get_ports().Contains(port) && !is_reactor_working) port = null;

            if (IR_port != null && !Port.get_ports().Contains(IR_port) && !is_IR_working) IR_port = null;

            if (is_reactor_working && !SerialPort.IsOpen)
            {
                is_reactor_working = false;
                port = null;

                state_lbl.ForeColor = Color.Red;
                state_lbl.Text = "Не работает";

                ShowError("Порт реактора отсоединился");
            }
            if (is_IR_working && !IR_Serial_Port.IsOpen)
            {
                is_IR_working = false;
                IR_port = null;

                IR_button.Text = "Начать";
                Interval_IR_counter.ReadOnly = false;
                ShowError("Порт термометра отсоединился");
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

        private static void IR_reading(SerialPort IR_Serial_Port, int interval)
        {
            while (is_IR_working)
            {
                Thread.Sleep(interval);
                string inf;
                if (IR_Serial_Port.IsOpen)
                {
                    do
                    {
                        IR_Serial_Port.Write(Data.read_command(), 0, 3);
                        inf = IR_Serial_Port.ReadExisting();
                        inf = Data.is_IR_value_valid(inf);
                    }
                    while (inf == "-1");
                    if (inf != "")
                    {
                        int temp = Convert.ToInt32(inf);
                        long time = stopwatch.ElapsedMilliseconds;

                        graphic_menu.update_temperature(time, temp);
                    }
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
            else if (is_IR_working)
            {
                ShowError("Термометр ещё работает. Прежде чем закрыть программу, остановите термометр");
                e.Cancel = true;
            }
            else
            {
                Close_Reactor_Port();
                e.Cancel = false;
            }
        }

        private void IR_button_Click(object sender, EventArgs e)
        {
            if (!is_IR_working && IR_port != null)
            {
                graphic_menu.is_drawing = true;
                Interval_IR_counter.ReadOnly = true;

                start_stopwatch();

                is_IR_working = true;

                IR_Serial_Port.PortName = IR_port;
                IR_Serial_Port.Open();
                IR_Serial_Port.Write(Data.init_command(), 0, 3);

                IR_button.Text = "Остановить измерения";

                int time = Convert.ToInt32(Interval_IR_counter.Value) * 500;
                IR_reading_thread = new Thread(() => IR_reading(IR_Serial_Port, time));
                IR_reading_thread.IsBackground = true;
                IR_reading_thread.Priority = ThreadPriority.Highest;
                IR_reading_thread.Start();
            }
            else if (is_IR_working && IR_port != null)
            {
                graphic_menu.is_drawing = false;
                is_IR_working = false;
                Interval_IR_counter.ReadOnly = false;

                stop_stopwatch();

                if (IR_Serial_Port.IsOpen)
                {
                    IR_Serial_Port.Write(Data.stop_command(), 0, 3);
                    Close_IR_Port();
                }

                IR_button.Text = "Начать измерения";
            }
            else if (IR_port == null)
            {
                ShowError("Порт термометра не выбран");
            }
        }

        private static void start_stopwatch()
        {
            if (!is_IR_working && !is_reactor_working)
            {
                stopwatch.Restart();
                stopwatch.Start();
            }
        }

        private static void stop_stopwatch()
        {
            if (!is_IR_working && !is_reactor_working)
            {
                stopwatch.Stop();
            }
        }

        private void Main_menu_KeyDown(object sender, KeyEventArgs e)
        {
            string key = Data.get_key(e.KeyCode);
            string command = Data.get_anod_command(key);
            button_down_anod(command, key);
        }

        private void arrow_btn_down(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Button btn = (Button)sender;

            string key = btn.Tag.ToString();
            string command = Data.get_anod_command(key);
            pressed_button = key;
            button_down_anod(command, key);
        }

        private void button_down_anod(string command, string key)
        {
            if (!SerialPort.IsOpen) { return; } //TODO: Не забудь поставить !
            if (command == "not_exist") { return; }

            if (pressed_button == " ")
            {
                pressed_button = key;
                SerialPort.WriteLine(command);
                //tem_lbl.Text = pressed_button + " was pressed";
            }
            else if (pressed_button == key)
            {
                //tem_lbl.Text = pressed_button + " is held down";
                SerialPort.WriteLine(command + Data.hold_anod_command);
                pressed_button = pressed_button + "P";
            }
        }

        private void Main_menu_KeyUp(object sender, KeyEventArgs e)
        {
            string key = Data.get_key(e.KeyCode);
            button_up_anod(key);
        }

        private void arrow_btn_up(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;

            string key = btn.Tag.ToString();
            button_up_anod(key);
        }

        private void button_up_anod(string key)
        {
            if (key != pressed_button[0].ToString()) { return; }
            if (SerialPort.IsOpen)
            {
                SerialPort.WriteLine(Data.stop_anod_command);
            }
            pressed_button = " ";
        }

        private void send_experiment_btn_Click(object sender, EventArgs e)
        {
            //Auth.test();
            //Internet_checker.IsConnectedToInternet();
            /*if (Drive.Connect())
                MessageBox.Show("Успешно!");
            else
                MessageBox.Show("Ошибка");*/
            Jounral_menu exp = new Jounral_menu(graphic_menu.GetChart());
            exp.ShowDialog();
        }

        private void google_drive_menu_btn_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string drive_name = e.ClickedItem.Text;

            if (e.ClickedItem.Tag != null) {
                if (Google_data.Is_drive_storage_full())
                {
                    MessageBox.Show("Хранилище заполнено", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    return;
                }
                New_Drive_menu new_drive_menu = new New_Drive_menu();
                new_drive_menu.ShowDialog();
            } 
            else
                Drive.Upload(drive_name);
        }

        private void settings_menu_btn_Click(object sender, EventArgs e)
        {

        }
    }
}