using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
            ConnectAsync();
        }

        public static void UploadFileOnDrive(string path, string serie, string numer)
        {
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(path);
            string file_name = serie + "_" + numer;
            FileStream stream = new FileStream(path, FileMode.Open);
            Google_service.UploadFile(file_name, stream, serie);
        }

        public static void Update(string new_name, string client_id, string client_secret)
        {
            if (Drive.client_id == client_id && Drive.client_secret == client_secret && Drive.name != new_name) 
                Google_service.UpdateNameTokenFile(name, new_name);
            else
                Google_service.DeleteTokenFile(name);

            Google_data.Update_drive(name, new_name, client_id, client_secret);
            Drive.name = new_name;
            Drive.client_id = client_id;
            Drive.client_secret = client_secret;
        }

        public static void Delete()
        {
            Google_service.DeleteTokenFile(name);
            Google_data.Delete_drive(name);
            name = "";
            client_id = "";
            client_secret = "";
        }

        private static void ConnectAsync()
        {
            Google_service.ConnectAsync(client_id, client_secret, name);
        }

        public static Google_service.RequestResult Connect()
        {
            return Google_service.Connect(client_id, client_secret, name);
        }
    }
}
