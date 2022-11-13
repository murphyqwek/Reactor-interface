using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

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

        static public string[] get_speeds() 
        {
            return speeds;
        }
    }
}
