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

                string rawData = "";
                for (int i = 0; i < text_bytes.Length; i++)
                {
                    rawData += text_bytes[i].ToString();
                }

                rawData = rawData.Remove(7, rawData.Length - 7); //Удаляем лишние символы?

                char[] rawDataChars = rawData.ToCharArray();
                Array.Reverse(rawDataChars);
                rawData = new string(rawDataChars); //Получаем наше число без разделительного знака

                string int_part = rawData.Substring(0, 3).TrimStart('0'); 
                int_part = (int_part == "") ? "0" : int_part;
                string fraction = rawData.Substring(3, rawData.Length - 3);

                string mass = int_part + "." + fraction;

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