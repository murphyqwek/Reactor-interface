using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Classes
{
    static class Data
    {
        //Инициализация обмен данных
        static private byte[] atq =
        {
            65, 84, 81
        };

        //Получить данные
        static private byte[] atr =
        {
            65, 84, 82
        };

        //Остановка обмена данных
        static private byte[] atu =
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
    }
}
