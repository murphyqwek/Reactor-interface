using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Classes;

namespace Reactor_Interface.Classes.GoogleAPI
{
    static class Google_data
    {
        private static Dictionary<string, string[]> Drives = new Dictionary<string, string[]>();
        public static void Upload_data()
        {
            Drives = Interface_settings.get_drives();
        }

        public static void Save_drive(string name, string client_id, string client_secret)
        {
            Interface_settings.save_drives(name, client_id, client_secret);
        }
    }
}
