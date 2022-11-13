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
            "115200", 
            "1200", 
            "2400", 
            "4800", 
            "9600", 
            "19200", 
            "38400", 
            "57600" };
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
