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

namespace Reactor_Interface.Classes.GoogleAPI
{
    static class Google_service
    {
        static public DriveService service = null;
        static public bool Conecnted = false;
        static public bool finished = false;
        static private string file_store = "Reactor.GoogleDrive.API.store";

        static public bool Connect(string client_id, string client_secret)
        {
            try
            {
                if (!Client_data_check.IsClientIdValid(client_id))
                    return false;
                TokenResponse token = new TokenResponse();
                token.RefreshToken = "1//0cs-zC7Sad5RXCgYIARAAGAwSNwF-L9Ir7aV64-CBi_SyPr9uz8U7H0jyyAGbI6rwhL8CvKM_dPLyIow-TIKfeh6gcii0IposdR0";
                TokenRequest token1 = new TokenRequest();
                var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                                new ClientSecrets
                                {
                                    ClientId = client_id,
                                    ClientSecret = client_secret
                                },
                                new[] { DriveService.Scope.DriveFile },
                                Environment.UserName,
                                CancellationToken.None,
                                new FileDataStore(file_store)
                                ).Result;
                var accessToken = credential.GetAccessTokenForRequestAsync().Result;
                
                service = new DriveService(new BaseClientService.Initializer() 
                { 
                    HttpClientInitializer = credential,
                    
                });
            }
            catch(Exception e)
            {
                return false;
            }
            return true;
        }
    }
}
