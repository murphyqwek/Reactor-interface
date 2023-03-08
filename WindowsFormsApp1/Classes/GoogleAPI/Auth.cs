using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Drive;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace Reactor_Interface.Classes.GoogleAPI
{
    static class Auth
    {
        static public async void test2()
        {
            UserCredential credential;

            CancellationTokenSource cts = new CancellationTokenSource();
            cts.CancelAfter(TimeSpan.FromSeconds(20));
            CancellationToken ct = cts.Token;

            credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    new ClientSecrets
                    {
                        ClientId = "997122256546-2e47oljkf15j5pr0k2lg831slsk7e47i.apps.googleusercontent.com",
                        ClientSecret = "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"
                    },
                    new[] { DriveService.Scope.DriveFile },
                    "user",
                    ct,
                    new FileDataStore("Reactor.GoogleDrive.API.store")
            ).Result;

            if (ct.IsCancellationRequested) return;
        }
        static public async void test()
        {
            CancellationToken cancellation = new CancellationToken();
            cancellation.ThrowIfCancellationRequested();
            while(!GoogleWebAuthorizationBroker.AuthorizeAsync(
                            new ClientSecrets
                            {
                                ClientId = "HHHHH",//"997122256546-2e47oljkf15j5pr0k2lg831slsk7e47i.apps.googleusercontent.com",
                                ClientSecret = "q412412eergeqr"//"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"
                            },
                            new[] { DriveService.Scope.DriveFile },
                            "user",
                            cancellation, new FileDataStore("data.STORE")).IsFaulted)
            {
                
            }
            
            

            //var credential = new UserCredential(apiCodeFlow, yourEMail, tokenResponse);

            var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                            new ClientSecrets
                            {
                                ClientId = "HHHHH",//"997122256546-2e47oljkf15j5pr0k2lg831slsk7e47i.apps.googleusercontent.com",
                                ClientSecret = "q412412eergeqr"//"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"
                            },
            new[] { DriveService.Scope.DriveFile },
                            "user",
                            cancellation, new FileDataStore("data.STORE")).Result;
            var service = new DriveService(new BaseClientService.Initializer() { HttpClientInitializer = credential });//, ApplicationName = "TPU Reactor" });
            var res1 = service.Files.List().Execute();
            //return;
            //File folder = new File();
            var stream = System.IO.File.OpenRead("C://Users//qweka//Desktop//Данные//789.xlsx");
            
            //folder.Name = "Крутые графики";
            //folder.MimeType = "application/vnd.google-apps.spreadsheet";
            //folder.Name = "1";
            //folder.MimeType = "application/vnd.google-apps.folder";
            //var res = await service.Files.Create(folder).ExecuteAsync();
            //var res = await service.Files.Create(folder, stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet").UploadAsync();
            
            string id = "2";
        }
    }
}
