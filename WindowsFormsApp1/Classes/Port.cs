using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Management;

namespace WindowsFormsApp1
{
    static class Port
    {
        static private string[] speeds = {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "28800",
            "31250",
            "38400",
            "57600",
            "115200",
        };
        static public string[] get_ports()
        {
            //List<string> ports = new List<string>();
            string[] ports = SerialPort.GetPortNames();
            
            return ports;
        }

        static public string get_speeds1()
        {
            ManagementScope connectionScope = new ManagementScope();
            SelectQuery serialQuery = new SelectQuery("SELECT * FROM Win32_PnPEntity");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(connectionScope, serialQuery);

            try
            {
                ManagementObjectCollection items = searcher.Get();
                foreach (ManagementObject item in items)
                {
                    string desc = item["Description"].ToString();
                    string deviceId = item["DeviceID"].ToString();

                    if (desc.Contains("Arduino"))
                    {
                        return deviceId;
                    }
                }
            }
            catch (ManagementException e)
            {
                /* Do Nothing */
            }

            return null;
        }

        static public string[] get_speeds() 
        {
            return speeds;
        }
    }
}
