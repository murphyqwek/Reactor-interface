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
    public partial class Serie_exp_menu : Form
    {
        private Jounral_menu exp_menu;
        public Serie_exp_menu(Jounral_menu exp_menu)
        {
            InitializeComponent();
            serie_textbx.Text = exp_menu.get_serie();
            this.exp_menu = exp_menu;
        }
        
        private void save_btn_Click(object sender, EventArgs e)
        {
            string serie = serie_textbx.Text.Trim();
            exp_menu.set_serie(serie);
            this.Close();
        }
    }
}
