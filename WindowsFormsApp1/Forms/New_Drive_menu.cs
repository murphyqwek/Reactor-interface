using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reactor_Interface.Classes;
using Reactor_Interface.Classes.GoogleAPI;

namespace Reactor_Interface.Forms
{
    public partial class New_Drive_menu : Form
    {
        public New_Drive_menu()
        {
            InitializeComponent();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void create_btn_Click(object sender, EventArgs e)
        {
            string name = drive_name_txtbx.Text.Trim();
            string client_id = client_id_txtbx.Text.Replace(" ", "");
            string client_secret = client_secret_txtbx.Text.Replace(" ", "");

            string data_error_text = Error_message.DriveDataInvalidError(name, client_id, client_secret);
            if (data_error_text != "")
            {
                MessageBox.Show(data_error_text, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            DialogResult result = MessageBox.Show("Вы точно хотите создать диск?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.No)
                return;

            var connect_result = Google_service.Connect(client_id, client_secret, name);

            this.Focus();
            string connect_error_text = Error_message.ConnectionError(connect_result);

            if (connect_error_text != "")
            {
                MessageBox.Show(connect_error_text, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            Google_data.Create_drive(name, client_id, client_secret);
            Drive.Upload(name);
            MessageBox.Show("Диск успешно создан", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
