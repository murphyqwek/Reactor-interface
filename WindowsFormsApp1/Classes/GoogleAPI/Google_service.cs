using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util;
using Google.Apis.Util.Store;

namespace Reactor_Interface.Classes.GoogleAPI
{
    static class Google_service
    {
        static public DriveService service = null;
        static public bool Conecnted = false;
        static public bool finished = false;
        static private string file_store = "Reactor.GoogleDrive.API.store";

        static private void Can_connect(string client_id, string client_secret)
        {
            var r = GoogleWebAuthorizationBroker.AuthorizeAsync(
                                new ClientSecrets
                                {
                                    ClientId = client_id,
                                    ClientSecret = client_secret
                                },
                                new[] { DriveService.Scope.DriveFile },
                                "user",
                                CancellationToken.None,
                                new FileDataStore(file_store));
            r.Wait();
        }

        static public async void Connect(string client_id, string client_secret)
        {
            //Can_connect(client_id, client_secret);
            try
            {
                var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                                new ClientSecrets
                                {
                                    ClientId = client_id,
                                    ClientSecret = client_secret
                                },
                                new[] { DriveService.Scope.DriveFile },
                                "erwerwerqewtwet",
                                CancellationToken.None,
                                new FileDataStore(file_store));
                //TaskStatus.WaitingForActivation
                var accessToken = await credential.GetAccessTokenForRequestAsync();

                //service = new DriveService(new BaseClientService.Initializer() { HttpClientInitializer = credential });
                Conecnted = true;
            }
            catch(Exception)
            {
                Conecnted = false;
                return;
            }
            finished = true;
        }
    }
}
