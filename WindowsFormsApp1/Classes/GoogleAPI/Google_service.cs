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
using OfficeOpenXml.Style;

namespace Reactor_Interface.Classes.GoogleAPI
{
    public enum FileTypes
    {
        Exl,
        Text,
        Folder
    }

    static class Google_service
    {
        static public DriveService service = null;
        static public bool Conecnted = false;
        static public bool finished = false;
        static private readonly string file_store = "Reactor.GoogleDrive.API.store";
        static private readonly string file_prefix = "Google.Apis.Auth.OAuth2.Responses.TokenResponse";
        static private readonly string temp_folder_name = "TEMP";

        private static readonly Dictionary<FileTypes, string> mimeTypes = new Dictionary<FileTypes, string>
        {
            { FileTypes.Text, "application/vnd.google-apps.file" },
            { FileTypes.Exl, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" },
            { FileTypes.Folder, "application/vnd.google-apps.folder" }
        };

        public enum RequestResult
        {
            Succses,
            WrongClientId,
            WrongClientSecret,
            NoInternet,
            RunOutOfTime
        }

        static public string GetFileTempFolderPath()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + file_store;
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            path += "\\" + temp_folder_name;

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return path;
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

        static public async Task<string> CreateFolder(string folderName)
        {
            var folder_file_body = new Google.Apis.Drive.v3.Data.File();
            folder_file_body.MimeType = mimeTypes[FileTypes.Folder];
            folder_file_body.Name = folderName;

            var result = await service.Files.Create(folder_file_body).ExecuteAsync();
            return result.Id;
        }

        static public async Task<bool> IsFolderExist(string folderName)
        {
            string q = string.Format("mimeType = '{0}' and name = '{1}' and trashed = false", mimeTypes[FileTypes.Folder], folderName);

            var list = service.Files.List();
            list.Q = q;

            var files = await list.ExecuteAsync();

            return files.Files.Count > 0;
        }
        
        static public bool IsFileExist(string fileName, string parent)
        {
            string q = string.Format("name = '{1}' and '{2}' in parents and trashed = false", fileName, parent);
            var list = service.Files.List();

            list.Q = q;

            var files = list.Execute();

            return files.Files.Count > 0;
        }


        static public async void UploadFile(string fileName, FileStream stream, FileData folder)
        {
            //string q = String.Format("id = {0} and trashed = false", folder.ID);
            string folder_id;

            var request = service.Files.Get(folder.ID);

            if(folder.ID == null)
            {
                folder_id = await CreateFolder(folder.Name);
            }
            else
            {
                try
                {
                    var result = await request.ExecuteAsync();
                    folder_id = folder.ID;
                }
                catch
                {
                    folder_id = await CreateFolder(folder.Name);
                }                    
            }

            var file_body = new Google.Apis.Drive.v3.Data.File();
            file_body.MimeType = "application/vnd.google-apps.spreadsheet";
            file_body.Name = fileName;
            file_body.Parents = new List<string> { folder_id };

            await service.Files.Create(file_body, stream, mimeTypes[FileTypes.Exl]).UploadAsync();
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

        public static async Task<Dictionary<string, List<FileData>>> GetSeries()
        {
            Dictionary<string, List<FileData>> Series = new Dictionary<string, List<FileData>>();

            if (!Internet_checker.CheckInternet() || service == null)
                return null;

            string q = string.Format("(mimeType = '{0}' or mimeType = 'application/vnd.google-apps.spreadsheet' or mimeType = '{1}') and trashed = false and 'me' in owners", mimeTypes[FileTypes.Folder], mimeTypes[FileTypes.Exl]);
            string orderBy = "folder";
            string fields = "files(id, name, parents, mimeType)";
            var getFilseFunc = service.Files.List();

            getFilseFunc.Q = q;
            getFilseFunc.OrderBy = orderBy;
            getFilseFunc.Fields = fields;

            string nextPage = null;
            do
            {
                var file_list = await getFilseFunc.ExecuteAsync();
                nextPage = file_list.NextPageToken;

                foreach (var file in file_list.Files)
                {
                    FileData fileData = new FileData(file.Name, file.Id, file.MimeType);
                    if (file.MimeType == mimeTypes[FileTypes.Folder])
                    {
                        if (!Series.ContainsKey(file.Id))
                            Series.Add(file.Id, new List<FileData> { fileData });
                        continue;
                    }

                    if (Series.ContainsKey(file.Parents.Last()))
                    {
                        Series[file.Parents.Last()].Add(fileData);
                    }
                }
            }
            while (!string.IsNullOrEmpty(nextPage));

            return Series;
        }
    }
}
