using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis;
using Google.Apis.Drive.v3;
using Google.Apis.Services;

namespace Reactor_Interface.Classes.GoogleAPI
{
    //api_key = AIzaSyBi2-yZOolgSgh5xGlkHmM0w8I6de343CI
    static class Auth
    {
        static string api_key = "AIzaSyBi2-yZOolgSgh5xGlkHmM0w8I6de343CI";
        static DriveService GoogleDriveService = new DriveService(new BaseClientService.Initializer
        {
            ApiKey = api_key,
        });

    }
}
