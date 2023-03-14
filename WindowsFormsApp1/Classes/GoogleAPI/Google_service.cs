using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Requests;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Http;
using Google.Apis.Services;
using Google.Apis.Util;
using Google.Apis.Util.Store;
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices.ComTypes;

namespace Reactor_Interface.Classes.GoogleAPI
{
    static class Google_service
    {
        static public DriveService service = null;
        static public bool Conecnted = false;
        static public bool finished = false;
        static private readonly string file_store = "Reactor.GoogleDrive.API.store";
        static private readonly string file_prefix = "Google.Apis.Auth.OAuth2.Responses.TokenResponse";

        public enum RequestResult
        {
            Succses,
            WrongClientId,
            WrongClientSecret,
            NoInternet,
            RunOutOfTime
        }

        static public void DeleteTokenFile(string name)
        {
            string path = String.Format("{0}\\{1}\\{2}-{3}",
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                file_store,
                file_prefix,
                name
                );

            if (!System.IO.File.Exists(path))
                return;

            System.IO.File.Delete(path);
        }

        static public void UpdateNameTokenFile(string old_name, string new_name)
        {
            string path = String.Format("{0}\\{1}\\{2}-",
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                file_store,
                file_prefix
                );
            if(!System.IO.File.Exists(path+old_name))
                return;
            System.IO.File.Move(path + old_name, path + new_name);
        }

        static public async void UploadFile(string name, FileStream stream, string folder_name)
        {
            string q = String.Format("mimeType = 'application/vnd.google-apps.folder' and name = '{0}' and trashed = false", folder_name);
            string folder_id;

            var request = service.Files.List();
            request.Q = q;
            var result = await request.ExecuteAsync();

            if (result.Files.Count == 0)
            {
                var folder_file_body = new Google.Apis.Drive.v3.Data.File();
                folder_file_body.MimeType = "application/vnd.google-apps.folder";
                folder_file_body.Name = folder_name;

                var res_temp = await service.Files.Create(folder_file_body).ExecuteAsync();
                folder_id = res_temp.Id;
            }
            else
                folder_id = result.Files.First().Id;

            var file_body = new Google.Apis.Drive.v3.Data.File();
            file_body.MimeType = "application/vnd.google-apps.spreadsheet";
            file_body.Name = name;
            file_body.Parents = new List<string> { folder_id };

            await service.Files.Create(file_body, stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet").UploadAsync();
        }

        static public async void ConnectAsync(string client_id, string client_secret, string name)
        {
            try
            {
                if (!Internet_checker.CheckInternet())
                    return;
                if (!Client_data_check.IsClientIdValid(client_id))
                    return;

                var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                                new ClientSecrets
                                {
                                    ClientId = client_id,
                                    ClientSecret = client_secret
                                },
                                new[] { DriveService.Scope.DriveFile },
                                name,
                                CancellationToken.None,
                                new FileDataStore(file_store)
                                );

                service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                });
            }
            catch (Exception)
            {
                service = null;
            }
        }

        static public RequestResult Connect(string client_id, string client_secret, string name)
        {
            try
            {
                if (!Internet_checker.CheckInternet())
                    return RequestResult.NoInternet;

                if (!Client_data_check.IsClientIdValid(client_id))
                    return RequestResult.WrongClientId;

                CancellationTokenSource cts = new CancellationTokenSource();
                cts.CancelAfter(TimeSpan.FromSeconds(60));
                CancellationToken ct = cts.Token;

                var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                                new ClientSecrets
                                {
                                    ClientId = client_id,
                                    ClientSecret = client_secret
                                },
                                new[] { DriveService.Scope.DriveFile },
                                name,
                                ct,
                                new FileDataStore(file_store)
                                ).Result;
                
                service = new DriveService(new BaseClientService.Initializer() 
                { 
                    HttpClientInitializer = credential,
                    
                });
            }
            catch(Exception)
            {
                service = null;
                return RequestResult.WrongClientSecret;
            }
            return RequestResult.Succses;
        }
    }
}
