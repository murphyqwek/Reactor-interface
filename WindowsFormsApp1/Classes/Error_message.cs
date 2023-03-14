using Reactor_Interface.Classes.GoogleAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reactor_Interface.Classes
{
    static class Error_message
    {
        static private readonly int max_name_len = 12;
        public static string DriveDataInvalidError(string name, string client_id, string client_secret)
        {
            string error_name = "";
            if (name.Length > max_name_len)
                error_name = String.Format("Имя диска должно быть меньше {0} символов", max_name_len);

            else if (name.Length == 0)
                error_name = "Укажите имя диска";

            else if (client_id.Length == 0)
                error_name = "Укажите client id";

            else if (client_secret.Length == 0)
                error_name = "Укажите client secret";

            return error_name;
        }

        public static string ConnectionError(Google_service.RequestResult result)
        {
            string error_name = "";
            switch (result)
            {
                case Google_service.RequestResult.WrongClientId:
                    error_name = "Неверный Client Id";
                    break;

                case Google_service.RequestResult.WrongClientSecret:
                    error_name = "Неверный Client Secret";
                    break;

                case Google_service.RequestResult.NoInternet:
                    error_name = "Отсутствует подключение к интернету";
                    break;

                case Google_service.RequestResult.RunOutOfTime:
                    error_name = "Время на авторизацую истекло";
                    break;
            }

            return error_name;
        }
    }
}
