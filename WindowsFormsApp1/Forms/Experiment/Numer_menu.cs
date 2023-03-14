using Reactor_Interface.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reactor_Interface.Forms.Experiment
{
    public partial class Numer_menu : Form
    {
        private Experiment_menu exp_menu;
        public Numer_menu(Experiment_menu exp_menu)
        {
            InitializeComponent();
            this.exp_menu = exp_menu;
        }

        private void next_btn_Click(object sender, EventArgs e)
        {
            string numer = numer_textbx.Text.Trim();

            if(numer.Length == 0 )
            {
                MessageBox.Show("Номер не должен быть пустым", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            exp_menu.set_numer(numer);
            this.Close();
        }
    }
}
