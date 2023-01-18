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
            //ATR03120Z
            if (data.Length == 9)
            {
                string atr = data.Substring(0, 3);
                string endline = data.Substring(7);
                if (atr != "ATR" || endline != "0Z") return "-1";

                return data.Substring(3, 4);
            }
            else if (data == "") return "";
            else return "-1";
        }
    }
}
