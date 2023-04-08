using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace WindowsFormsApp1.Classes
{
    static class Interface_settings
    {
        static public string get_weigher_port()
        {
            string port;
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Reactor Interface TPU"))
            {
                port = key?.GetValue("Weigher port")?.ToString();
            }

            if (!Port.get_ports().Contains(port)) port = null;

            return port;
        }

        static public void save_weigher_port(string port)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Reactor Interface TPU"))
            {
                key.SetValue("Weigher port", port);
            }
        }

        static public string get_port()
        {
            string port;
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Reactor Interface TPU"))
            {
                port = key?.GetValue("Port")?.ToString();
            }

            if (!Port.get_ports().Contains(port)) port = null;

            return port;
        }

        static public int get_speed()
        {
            int speed;
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Reactor Interface TPU"))
            {
                speed = Convert.ToInt32(key?.GetValue("Speed"));
            }
            if (speed == 0)
            {
                save_speed(115200);
                speed = 115200;
            } 

            return speed;
        }

        static public string get_IR_port()
        {
            string IR_port;
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Reactor Interface TPU"))
            {
                IR_port = key?.GetValue("IR port")?.ToString();
            }

            if (!Port.get_ports().Contains(IR_port)) IR_port = null;

            return IR_port;
        }

        static public void save_port(string port)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Reactor Interface TPU"))
            {
                key.SetValue("Port", port);
            }
        }

        static public void save_speed(int speed)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Reactor Interface TPU"))
            {
                key.SetValue("Speed", speed);
            }
        }
        static public void save_IR_port(string IR_port)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Reactor Interface TPU"))
            {
                key.SetValue("IR port", IR_port);
            }
        }

        static public Dictionary<string, string[]> get_drives()
        {
            Dictionary<string, string[]> drives = new Dictionary<string, string[]>();

            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Reactor Interface TPU\Drives"))
            {
                string [] reg_drives = key.GetValueNames();
                foreach(string drive_name in reg_drives)
                {
                    string[] data = key.GetValue(drive_name).ToString().Split(' ');
                    drives.Add(drive_name, data);
                }
            }

            return drives;
        }

        static public void save_drives(string name, string client_id, string client_secret)
        {
            string data = client_id + " " + client_secret;

            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Reactor Interface TPU\Drives"))
            {
                key.SetValue(name, data);
                //TODO: сделать безопасность
            }
        }

        static public string get_current_drive()
        {
            string drive;
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Reactor Interface TPU"))
            {
                drive = key?.GetValue("Current drive")?.ToString();
            }

            return drive;
        }

        static public void save_current_drive(string current_drive)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Reactor Interface TPU"))
            {
                key.SetValue("Current drive", current_drive);
            }
        }

        static public void update_drive(string old_name, string new_name, string client_id, string client_secret)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Reactor Interface TPU\Drives"))
            {
                string data = client_id + " " + client_secret;
                if (old_name == new_name)
                {
                    key.SetValue(old_name, data);
                }
                else
                {
                    key.DeleteValue(old_name);
                    key.SetValue(new_name, data);
                }
            }
        }

        public static void delete_drive(string name)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Reactor Interface TPU\Drives"))
            {
                key.DeleteValue(name);
            }
        }

        public static string get_using_template()
        {
            string template;
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Reactor Interface TPU"))
            {
                template = key?.GetValue("Using Template")?.ToString();
            }
            return template;
        }

        static public void save_using_template(string using_template)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Reactor Interface TPU"))
            {
                key.SetValue("Using Template", using_template);
            }
        }
    }
}