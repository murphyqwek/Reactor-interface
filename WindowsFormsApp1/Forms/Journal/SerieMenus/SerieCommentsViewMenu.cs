using Reactor_Interface.Classes.Message;
using Reactor_Interface.Classes.Serie;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reactor_Interface.Forms.Journal.SerieMenus
{
    public partial class SerieCommentsViewMenu : Form
    {
        const string MENUTITLE = "Просмотр комментариев к серии";

        bool _saved;

        bool isSaved
        {
            get { return _saved; }

            set
            {
                this.Text = MENUTITLE;

                if (!value)
                    this.Text += "*";

                _saved = value;
            }
        }

        SerieData _serie;

        public SerieCommentsViewMenu(SerieData serie)
        {
            InitializeComponent();
            _serie = serie;

            isSaved = true;

            SerieSystem.SetNewSerieComments(_serie, _serie.SerieComments);

            CommentsTextBox.Text = _serie.SerieComments;
        }

        private void SerieCommentsViewMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isSaved)
            {
                e.Cancel = false;
                return;
            }

            var result = MessageBox.Show("Вы хотите сохранить новый комменатрий?", "Внимание", MessageBoxButtons.YesNoCancel,
                                             MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);

            if (result == DialogResult.Yes)
            {
                SerieSystem.SetNewSerieComments(_serie, CommentsTextBox.Text);
                e.Cancel = false;
                return;
            }

            if(result == DialogResult.No)
            {
                e.Cancel = false;
                return;
            }

            e.Cancel = true;
        }

        private void CommentsTextBox_TextChanged(object sender, EventArgs e)
        {
            isSaved = _serie.SerieComments.Equals(CommentsTextBox.Text);
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (!isSaved)
            {
                if(ConfirmMessageBox.Show("Вы точно хотите сохранить изменения?"))
                {
                    isSaved = true;
                    SerieSystem.SetNewSerieComments(_serie, CommentsTextBox.Text);
                }

            }
        }
    }
}
