using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Collections.Concurrent;
using Reactor_Interface.Classes.Templates;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace Reactor_Interface.Classes.Weigher
{
    public class WeigherReader
    {
        //SerialPort _weigherSerialPort = null;

        ConcurrentQueue<string> dataQueue = new ConcurrentQueue<string>();
        public delegate void dataChange(string data);

        public dataChange OnMassGet;

        static byte[] text_bytes;

        private SerialPort _weigherSerialPort;

        public WeigherReader(SerialPort serialPort)
        {
            _weigherSerialPort = serialPort;
        }

        public string GetMass()
        {
            try
            {
                _weigherSerialPort.Open();

                _weigherSerialPort.WriteLine(" ");
                while (_weigherSerialPort.BytesToRead < 10) { }
            
                string text = _weigherSerialPort.ReadExisting();
                _weigherSerialPort.DiscardInBuffer();
                text_bytes = Encoding.UTF8.GetBytes(text);

                string j = "";
                for (int i = 0; i < text_bytes.Length; i++)
                {
                    j += text_bytes[i].ToString();
                }

                j = j.Remove(7, j.Length - 7);

                char[] jchars = j.ToCharArray();
                Array.Reverse(jchars);
                j = new string(jchars);

                string int_part = j.Substring(0, 3).TrimStart('0');
                int_part = (int_part == "") ? "0" : int_part;

                string mass = int_part + "." + j.Substring(3, j.Length - 3);

                _weigherSerialPort.Close();

                return mass;
            }
            catch
            {

            }
            return null;
        }

        public void UpdateMass()
        {
            //string data = GetMass();

            //OnMassGet(data);
        }
    

        public void TRead()
        {
            return;
            /*
            if (_weigherSerialPort == null)
                return;

            int i = 0;
            byte[] bytesRead;
            while (true)
            {
                while (_weigherSerialPort.BytesToRead == 0) { }
                bytesRead = new byte[_weigherSerialPort.BytesToRead];
                try
                {
                    string text = _weigherSerialPort.ReadExisting();
                    _weigherSerialPort.DiscardInBuffer();
                    text_bytes = Encoding.UTF8.GetBytes(text);

                    string j = "";
                    for(i = 0; i < text_bytes.Length; i++)
                    {
                        j += text_bytes[i].ToString();
                    }

                    MessageBox.Show(j);
                    OnMassGet(j);
                }
                catch (ThreadAbortException)
                {
                    return;
                }
                catch
                {
                    MessageBox.Show("ERROR");
                }
            }
            */
        }
    }
}