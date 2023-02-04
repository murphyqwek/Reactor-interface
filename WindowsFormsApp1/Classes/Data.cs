using Reactor_Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace WindowsFormsApp1.Classes
{
    static class Data
    {
        static string[] presset_data = new string[4];
        /*
         * 0 - Режим работы
         * 1 - Конфигурация
         * 2 - Ток
         * 3 - Прерывание
         */

        static string[] mode_data = new string[4];
        /*
         * 0 - Время синтеза
         * 1 - Время горения
         * 2 - Время остывания
         * 3 - Количество итераций
         */

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
        //time_left=2;tok=2.94\r 25790
        //
        //2.72
        public static string get_tok_mode(string mode)
        {
            switch (mode)
            {
                case "50 А":
                    return "0";
                case "100 А":
                    return "1";
                case "150 А":;
                    return "2";
                case "200 А":
                    return "3";

                default: return "0";
            }
        }

        public static void enter_mode(string mode)
        {
            presset_data[0] = mode;
        }

        public static void enter_configuration(string conf)
        {
            presset_data[1] = conf;
        }

        public static void enter_tok(string tok)
        {
            presset_data[2] = tok;
        }

        public static void enter_break(string brk)
        {
            presset_data[3] = brk;
        }

        public static void enter_time_synth(string time)
        {
            mode_data[0] = time;
        }

        public static void enter_time_fire(string time)
        {
            mode_data[1] = time;
        }

        public static void enter_time_cold(string time)
        {
            mode_data[2] = time;
        }

        public static void enter_iter(string iter)
        {
            mode_data[3] = iter;
        }

        public static string get_mode()
        {
            return presset_data[0];
        }

        public static string get_configuration()
        {
            return presset_data[1];
        }

        public static string get_tok()
        {
            return presset_data[2];
        }

        public static string get_break()
        {
            return presset_data[3];
        }

        public static string get_time_synth()
        {
            return mode_data[0];
        }

        public static string get_time_fire()
        {
            return mode_data[1];
        }

        public static string get_time_cold()
        {
            return mode_data[2];
        }

        public static string get_iter()
        {
            return mode_data[3];
        }


        public static void clear_datas()
        {
            presset_data = new string[4];
            mode_data = new string[4];
        }
    }
}
