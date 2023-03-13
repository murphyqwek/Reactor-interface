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
using Reactor_Interface.Classes.GoogleAPI;

namespace Reactor_Interface.Forms
{
    public partial class New_Drive_menu : Form
    {
        public New_Drive_menu()
        {
            InitializeComponent();
        }

        private bool check()
        {
            string name = drive_name_txtbx.Text.Trim();
            string client_id = client_id_txtbx.Text.Replace(" ", "");
            string client_secret = client_secret_txtbx.Text.Replace(" ", "");

            if (name.Length > 12)
            {
                MessageBox.Show("Имя диска должно быть меньше 12 символов", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return false; 
            }
            if (Google_data.Is_name_taken(name))
            {
                MessageBox.Show("Диск с таким именем уже существует. Выберите другое имя", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return false;
            }
            if (name.Length == 0)
            {
                MessageBox.Show("Укажите имя диска", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return false;
            }
            if (client_id.Length == 0)
            {
                MessageBox.Show("Укажите client id", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return false;
            }
            if (client_secret.Length == 0)
            {
                MessageBox.Show("Укажите client secret", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return false;
            }

            return true;
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

            if (!check())
                return;
            DialogResult result = MessageBox.Show("Вы точно хотите создать диск?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.No)
                return;

            if (!Google_service.Connect(client_id, client_secret, name)) 
            {
                MessageBox.Show("Неверный client id или client secret", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            Google_data.Create_drive(name, client_id, client_secret);
            Drive.Upload(name);
            MessageBox.Show("Диск успешно создан", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
