using Reactor_Interface.Forms.Template;
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
    public partial class Template_menu : Form
    {
        public Template_menu()
        {
            InitializeComponent();
        }

        private void create_btn_Click(object sender, EventArgs e)
        {
            Create_template_menu create_menu = new Create_template_menu(this);
            this.Hide();
            create_menu.Show();
        }
    }
}
