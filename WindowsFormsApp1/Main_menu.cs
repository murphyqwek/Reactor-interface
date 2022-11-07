using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//size 365; 117
//size 1188; 570
namespace WindowsFormsApp1
{
    public partial class Main_menu : Form
    {

        public Main_menu()
        {
            InitializeComponent();
        }

        private void time_syntes_bar_Scroll(object sender, EventArgs e)
        {
            time_syntes_lable.Text = "Время синтеза: " + time_bar.Value.ToString() + " c.";
        }

        private void duga_rdbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (duga_rdbtn.Checked){
                time_bar.Size = new Size(461, 45);
                time_syntes_lable.Text = "Время синтеза: 5 с.";
                time_bar.Value = 5;
                time_bar.Maximum = 60;

                iteration_label.Visible = false;
                iteration_counter.Visible = false; 
            }
            //if(!duga_rdbtn.Checked && !impulse_rdbtn.Checked) duga_rdbtn.Checked = true;
        }

        private void impulse_rdbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (impulse_rdbtn.Checked){
                time_bar.Size = new Size(259, 45);
                time_syntes_lable.Text = "Время импульса: 5 с.";
                time_bar.Value = 5;
                time_bar.Maximum = 20;

                iteration_counter.Value = 2;
                iteration_label.Visible = true;
                iteration_counter.Visible = true;
            }
            //if (!duga_rdbtn.Checked && !impulse_rdbtn.Checked) impulse_rdbtn.Checked = true;
        }

        private void tigel_rdbtn_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
