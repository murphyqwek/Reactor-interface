using Microsoft.Office.Interop.Excel;
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

        public static string current_drive = "";
        public static string client_id = "", client_secret = "";

        public static void Upload_drive(string drive_name)
        {
            if (drive_name == null || drive_name == "")
                return;

            Interface_settings.save_current_drive(drive_name);
            current_drive = drive_name;
            client_id = Drives[drive_name][0];
            client_secret = Drives[drive_name][1];
        }

        public static void Upload_data()
        {
            Drives = Interface_settings.get_drives();
            current_drive = Interface_settings.get_current_drive();
            Upload_drive(current_drive);
        }

        public static void Delete_drive(string drive_name)
        {
            Interface_settings.save_current_drive("");
            Interface_settings.delete_drive(drive_name);
            Drives.Remove(drive_name);

            current_drive = "";
            client_id = "";
            client_secret = "";
        }

        public static void Update_drive(string old_name, string new_name, string client_id, string client_secret)
        {
            Interface_settings.update_drive(old_name, new_name, client_id, client_secret);

            Interface_settings.save_current_drive(new_name);
            Drives.Remove(old_name);

            string[] data = { client_id, client_id };
            Drives.Add(new_name, data);
            Upload_drive(new_name);
        }

        public static void Create_drive(string name, string client_id, string client_secret)
        {
            Interface_settings.save_drives(name, client_id, client_secret);
            string[] data = { client_id, client_id };
            Drives.Add(name, data);
            Upload_drive(name);
        }

        public static string[] Get_drives()
        {
            return Drives.Keys.ToArray();
        } 
    }
}
