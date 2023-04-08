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
        SerialPort port = null;

        ConcurrentQueue<string> dataQueue = new ConcurrentQueue<string>();
        public delegate void dataChange(string data);

        public dataChange OnMassGet;

        static byte[] text_bytes;

        public WeigherReader(SerialPort port)
        {
            this.port = port;
        }

        public void Test()
        {
            OnMassGet("190");
        }

        public string GetMass()
        {
            if (port == null)
                return null;

            if (!port.IsOpen)
                return null;

            port.Write(" ");
            while (port.BytesToRead == 0) { }
            var bytesRead = new byte[port.BytesToRead];
            try
            {
                string text = port.ReadExisting();
                port.DiscardInBuffer();
                text_bytes = Encoding.UTF8.GetBytes(text);

                string j = "";
                for (int i = 0; i < text_bytes.Length; i++)
                {
                    j += text_bytes[i].ToString();
                }

                return j;
            }
            catch
            {

            }
            return null;
        }

        public void UpdateMass()
        {
            string data = GetMass();

            OnMassGet(data);
        }
    

        public void TRead()
        {
            if (port == null)
                return;

            int i = 0;
            byte[] bytesRead;
            while (true)
            {
                while (port.BytesToRead == 0) { }
                bytesRead = new byte[port.BytesToRead];
                try
                {
                    string text = port.ReadExisting();
                    port.DiscardInBuffer();
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
        }

        private void Event_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            
        }

        public void ReadFromQueue()
        {
            ;
            using (FileStream fstream = new FileStream("vesy.txt", FileMode.Create))
            {
                // преобразуем строку в байты
                byte[] buffer = Encoding.Default.GetBytes(dataQueue.ToString());
                // запись массива байтов в файл
                fstream.Write(buffer, 0, buffer.Length);
            }
        }
    }
}