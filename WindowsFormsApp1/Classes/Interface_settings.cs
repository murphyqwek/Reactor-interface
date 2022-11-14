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
            return port;
        }

        static public int get_speed()
        {
            int speed;
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Reactor Interface TPU"))
            {
                speed = Convert.ToInt32(key?.GetValue("Speed"));
            }
            return speed;
        }

        static public void save(string port)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Reactor Interface TPU"))
            {
                key.SetValue("Port", port);
            }
        }

        static public void save(int speed)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Reactor Interface TPU"))
            {
                key.SetValue("Speed", speed);
            }
        }

        static public void save(string port, int speed)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Reactor Interface TPU"))
            {
                key.SetValue("port", port);
                key.SetValue("Speed", speed);
            }
        }
    }
}
