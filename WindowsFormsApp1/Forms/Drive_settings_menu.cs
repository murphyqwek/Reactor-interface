using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reactor_Interface.Classes.GoogleAPI;

namespace Reactor_Interface.Forms
{
    public partial class Drive_settings_menu : Form
    {
        public Drive_settings_menu()
        {
            InitializeComponent();
            drive_name_txtbx.Text = Google_data.current_drive;
            client_id_txtbx.Text = Google_data.client_id;
            client_secret_txtbx.Text = Google_data.client_secret;
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            string name = drive_name_txtbx.Text.Trim();
            string client_id = client_id_txtbx.Text.Replace(" ", ""); 
            string client_secret = client_secret_txtbx.Text.Replace(" ", "");

            if (name.Length > 12)
            {
                MessageBox.Show("Имя диска должно быть меньше 12 символов", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
            if (name.Length == 0)
            {
                MessageBox.Show("Укажите имя диска", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
            if (client_id.Replace(" ", "").Length == 0)
            {
                MessageBox.Show("Укажите client id", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
            if (client_secret.Replace(" ", "").Length == 0)
            {
                MessageBox.Show("Укажите client secret", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            DialogResult result = MessageBox.Show("Вы точно хотите изменить этот диск?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                Google_data.Update_drive(Google_data.current_drive, name, client_id, client_secret);
                MessageBox.Show("Диск успешно изменён", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
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
                Google_data.Delete_drive(Google_data.current_drive);
                MessageBox.Show("Диск успешно удалён", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
