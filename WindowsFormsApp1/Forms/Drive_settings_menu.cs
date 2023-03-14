using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using Microsoft.Office.Interop.Excel;
using Reactor_Interface.Classes;
using Reactor_Interface.Classes.GoogleAPI;

namespace Reactor_Interface.Forms
{
    public partial class Drive_settings_menu : Form
    {
        public Drive_settings_menu()
        {
            InitializeComponent();
            drive_name_txtbx.Text = Drive.name;
            client_id_txtbx.Text = Drive.client_id;
            client_secret_txtbx.Text = Drive.client_secret;
        }

        protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
        {
            base.ScaleControl(factor, specified);
            this.MinimumSize = this.MaximumSize = this.Size;
        }
        private void save_btn_Click(object sender, EventArgs e)
        {
            string name = drive_name_txtbx.Text.Trim();
            string client_id = client_id_txtbx.Text.Replace(" ", "");
            string client_secret = client_secret_txtbx.Text.Replace(" ", "");

            if (name == Drive.name && client_id == Drive.client_id && client_secret == Drive.client_secret)
                return;

            string data_error_text = Error_message.DriveDataInvalidError(name, client_id, client_secret);
            if (data_error_text != "") {
                MessageBox.Show(data_error_text, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            DialogResult result = MessageBox.Show("Вы точно хотите изменить этот диск?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.No)
                return;
            
            if(client_id == Drive.client_id && client_secret == Drive.client_secret)
            {
                Drive.Update(name, client_id, client_secret);
                MessageBox.Show("Диск успешно изменён", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

            var connect_result = Google_service.Connect(client_id, client_secret, name);

            this.Focus();

            string connect_error_text = Error_message.ConnectionError(connect_result);

            if(connect_error_text != "")
            {
                if (connect_result == Google_service.RequestResult.WrongClientId
                || connect_result == Google_service.RequestResult.WrongClientSecret)
                    Google_service.DeleteTokenFile(name);

                MessageBox.Show(connect_error_text, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            Google_service.DeleteTokenFile(Drive.name);
            Drive.Update(name, client_id, client_secret);
            MessageBox.Show("Диск успешно изменён", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы точно хотите удалить этот диск?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if(result == DialogResult.Yes)
            {
                Drive.Delete();
                MessageBox.Show("Диск успешно удалён", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
