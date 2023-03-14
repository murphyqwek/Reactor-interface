using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Bson;
using Reactor_Interface.Classes;
using Reactor_Interface.Classes.GoogleAPI;
using Reactor_Interface.Forms;
using Reactor_Interface.Forms.Experiment;

namespace Reactor_Interface
{
    public partial class Experiment_menu : Form
    {
        public string serie = "";
        public string numer = "";
        public Experiment_menu()
        {
            InitializeComponent();
            googleDriveToolStripMenuItem.Text = "Google Drive: " + Drive.name;
            upload_drives();
        }

        private void upload_drives()
        {
            foreach(string drive in Google_data.Get_drives())
            {
                googleDriveToolStripMenuItem.DropDownItems.Add(drive);
            }
        }

        private void googleDriveToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string drive_name = e.ClickedItem.Text;
            Drive.Upload(drive_name);
            googleDriveToolStripMenuItem.Text = "Google Drive: " + Drive.name;
        }
        
        private void save_to_drive_btn_Click(object sender, EventArgs e)
        {
            var connect_result = Drive.Connect();

            string connect_error_text = Error_message.ConnectionError(connect_result);
            if(connect_error_text != "")
            {
                MessageBox.Show(connect_error_text, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            if(serie == "")
            {
                MessageBox.Show("Не указана серия экспериментов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            Numer_menu numer_menu = new Numer_menu(this);
            numer_menu.ShowDialog();

            if (numer == "")
            {
                MessageBox.Show("Не указан номер эксперимента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            Drive.UploadFileOnDrive("C:\\Users\\qweka\\Desktop\\Данные\\Крутые Графики.xlsx", serie, numer);
        }

        private void change_serie_menubtn_Click(object sender, EventArgs e)
        {
            Serie_exp_menu serie = new Serie_exp_menu(this);
            serie.ShowDialog();
        }

        public string get_serie()
        {
            return serie;
        }

        public void set_numer(string numer)
        {
            this.numer = numer;
        }
        public void set_serie(string serie)
        {
            this.serie = serie;
            this.Text = "Эксперимент. Серия: " + serie;
        }
    }
}
