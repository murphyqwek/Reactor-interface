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
    }
}
