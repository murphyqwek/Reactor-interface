using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;

namespace Reactor_Interface.Classes.GoogleAPI
{
    static class Auth
    {
        static public async void test()
        {
            UserCredential credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                            new ClientSecrets
                            {
                                ClientId = "997122256546-2e47oljkf15j5pr0k2lg831slsk7e47i.apps.googleusercontent.com",
                                ClientSecret = "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"
                            },
                            new[] { DriveService.Scope.DriveFile },
                            "user",
                            CancellationToken.None);
            var service = new DriveService(new BaseClientService.Initializer() { HttpClientInitializer = credential });//, ApplicationName = "TPU Reactor" });

            File folder = new File();
            var stream = System.IO.File.OpenRead("C://Users//qweka//Desktop//Данные//789.xlsx");
            
            folder.Name = "Крутые графики";
            folder.MimeType = "application/vnd.google-apps.spreadsheet";
            //folder.Name = "MEGA PAPKA1";
            //folder.MimeType = "application/vnd.google-apps.folder";

            var res = await service.Files.Create(folder, stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet").UploadAsync();
           
            string id = "2";
        }
    }
}
