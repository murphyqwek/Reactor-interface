using Reactor_Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Classes
{
    static class Data
    {
        //Инициализация обмен данных
        static private readonly byte[] atq =
        {
            65, 84, 81
        };

        //Получить данные
        static private readonly byte[] atr =
        {
            65, 84, 82
        };

        //Остановка обмена данных
        static private readonly byte[] atu =
        {
            65, 84, 85
        };

        static public byte[] init_command()
        {
            return atq;
        }

        static public byte[] read_command()
        {
            return atr;
        }

        static public byte[] stop_command()
        {
            return atu;
        }

        static public string is_IR_value_valid(string data)
        {
            if (data.Length >= 9)
            {
                foreach(char frame in data)
                {
                    
                }

                return "";
            }

            else return "";
        }
    }
}
