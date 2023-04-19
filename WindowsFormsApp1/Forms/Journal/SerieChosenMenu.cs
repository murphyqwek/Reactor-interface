using Microsoft.VisualBasic;
using Reactor_Interface.Classes;
using Reactor_Interface.Classes.GoogleAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reactor_Interface.Forms.Journal
{
    public partial class SerieChosenMenu : Form
    {
        private Jounral_menu journal;

        public SerieChosenMenu(Jounral_menu JournalMenu)
        {
            InitializeComponent();
            journal = JournalMenu;
            this.Cursor = Cursors.WaitCursor;
            UploadSeries();
            this.Cursor = Cursors.Default;
        }

        private async void UploadSeries()
        {
            if (!Internet_checker.CheckInternet())
            {
                MessageBox.Show("Отсутсвует подклчение к интернету", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            var Series = await Google_service.GetSeries();
            SeriesTreeView.Nodes.Clear();

            foreach (var serie in Series.Values)
            {
                var folderNode = SeriesTreeView.Nodes.Add(serie[0].Name);
                folderNode.Tag = serie[0];

                folderNode.ContextMenuStrip = SerieContextMenuStrip;

                folderNode.ImageIndex = 0;
                folderNode.StateImageIndex = 0;
                folderNode.SelectedImageIndex = 0;

                for (int i = 1; i < serie.Count; i++)
                {
                    var excelNode = folderNode.Nodes.Add(serie[i].Name);
                    excelNode.Tag = serie[i];

                    excelNode.ImageIndex = 1;
                    excelNode.StateImageIndex = 1;
                    excelNode.SelectedImageIndex = 1;
                }
            }
        }

        private void ChooseSerieBtn_Click(object sender, EventArgs e)
        {
            var Folder = (FileData)SeriesTreeView.SelectedNode.Tag;
            journal.set_serie(Folder);
            this.Close();
        }

        private async void CreateNewSerieBtn_Click(object sender, EventArgs e)
        {
            string folderName = Interaction.InputBox("Введите название серии экспериментов", "Новая серия экспериментов");

            folderName = folderName.Trim();

            if(string.IsNullOrEmpty(folderName))
            {
                MessageBox.Show("Пустое название", "Ошибка", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            if(await Google_service.IsFolderExist(folderName))
            {
                MessageBox.Show("Серия экспериментов с таким названием уже существует", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            string id = await Google_service.CreateFolder(folderName);

            FileData newFolder = new FileData(folderName, id, "application/vnd.google-apps.folder");

            var newNode = SeriesTreeView.Nodes.Add(folderName);

            newNode.Tag = newFolder;

            newNode.ContextMenuStrip = SerieContextMenuStrip;

            newNode.ImageIndex = 0;
            newNode.SelectedImageIndex = 0;
            newNode.StateImageIndex = 0;
        }

        private void UpdateSeriesBtn_Click(object sender, EventArgs e)
        {
            UploadSeries();
        }
    }
}
