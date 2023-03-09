using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Classes;

namespace Reactor_Interface.Classes.GoogleAPI
{
    static class Drive
    {
        public static string name = "";
        public static string client_id = "", client_secret = "";

        public static void Upload(string drive_name)
        {
            if (drive_name == null || drive_name == "")
                return;

            name = drive_name;
            client_id = Google_data.Get_client_id(drive_name);
            client_secret = Google_data.Get_client_secret(drive_name);
            Google_data.Save_current_drive(name);
        }

        public static void Update(string new_name, string client_id, string client_secret)
        {
            Google_data.Update_drive(name, new_name, client_id, client_secret);

            if (name != new_name)
            {
                name = new_name;
                Google_data.Save_current_drive(new_name);
            }
            Drive.client_id = client_id;
            Drive.client_secret = client_secret;
        }

        public static void Delete()
        {
            Google_data.Delete_drive(name);
            name = "";
            client_id = "";
            client_secret = "";
        }

        public static bool Connect()
        {
            Google_service.Connect(client_id, client_secret);
            /*if (Google_service.Connect(client_id, client_secret))
                return true;
            else
                return false;*/

            return Google_service.Conecnted;
        }
    }
}
