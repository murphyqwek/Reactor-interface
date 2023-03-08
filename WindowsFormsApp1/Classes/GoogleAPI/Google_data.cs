using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Classes;

namespace Reactor_Interface.Classes.GoogleAPI
{
    static class Google_data
    {
        private static readonly int drive_storage_max = 10;

        private static Dictionary<string, string[]> Drives = new Dictionary<string, string[]>();

        public static bool Is_name_taken(string drive_name)
        {
            return Drives.ContainsKey(drive_name);
        }

        public static bool Is_drive_storage_full()
        {
            return (Drives.Count == drive_storage_max);
        }

        public static string Get_current_drive()
        {
            return Interface_settings.get_current_drive();
        }

        public static void Save_current_drive(string drive_name)
        {
            Interface_settings.save_current_drive(drive_name);
        }

        public static string Get_client_id(string drive_name)
        {
            return Drives[drive_name][0];
        }

        public static string Get_client_secret(string drive_name)
        {
            return Drives[drive_name][1];
        }

        public static void Upload_data()
        {
            Drives = Interface_settings.get_drives();
        }

        public static void Delete_drive(string drive_name)
        {
            Interface_settings.save_current_drive("");
            Interface_settings.delete_drive(drive_name);
            Drives.Remove(drive_name);
        }

        public static void Update_drive(string old_name, string new_name, string client_id, string client_secret)
        {
            Interface_settings.update_drive(old_name, new_name, client_id, client_secret);

            Interface_settings.save_current_drive(new_name);
            Drives.Remove(old_name);

            string[] data = { client_id, client_id };
            Drives.Add(new_name, data);
        }

        public static void Create_drive(string name, string client_id, string client_secret)
        {
            Interface_settings.save_drives(name, client_id, client_secret);
            string[] data = { client_id, client_secret };
            Drives.Add(name, data);
        }

        public static string[] Get_drives()
        {
            return Drives.Keys.ToArray();
        } 
    }
}
