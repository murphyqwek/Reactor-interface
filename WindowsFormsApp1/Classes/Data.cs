using Reactor_Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Management;
using System.Windows.Forms;

namespace WindowsFormsApp1.Classes
{
    static class Data
    {
        static public readonly string stop_anod_command = "stop";

        static private Dictionary<string, string> anod_commands = new Dictionary<string, string>
        {
            { "W", "forward" },
            { "A", "left" },
            { "S", "back" },
            { "D", "right" },
            { "U", "up" },
            { "J", "down" },
        };

        static public readonly string hold_anod_command = "_hold"; //Это строка припысыается к основной команде, если мы зажимаем кнопку

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


        static private Dictionary<Keys, string> keys = new Dictionary<Keys, string>
        {
            { Keys.W, "W" },
            { Keys.A, "A" },
            { Keys.S, "S" },
            { Keys.D, "D" },
            { Keys.U, "U" },
            { Keys.J, "J" },
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

        public static int get_tok_mode(string mode)
        {
            switch (mode)
            {
                case "25 А":
                    return 0;
                case "50 А":
                    return 1;
                case "75 А":
                    return 2;
                case "100 А":
                    return 3;
                case "150 А":;
                    return 4;
                case "200 А":
                    return 5;

                default: return 0;
            }
        }

        static public string get_anod_command(string pressed_key)
        {
            string command;
            return anod_commands.TryGetValue(pressed_key, out command) ? command : "not_exist";
        }

        static public string get_key(Keys key_code)
        {
            string key;
            return keys.TryGetValue(key_code, out key) ? key : "-";
        }
    }
}