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
using Reactor_Interface.Classes.GoogleAPI;

namespace Reactor_Interface
{
    public partial class Experiment : Form
    {
        public Experiment()
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
            Drive.UploadFileOnDrive("C:\\Users\\qweka\\Desktop\\Данные\\Крутые Графики.xlsx");
        }
    }
}
