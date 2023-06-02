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
    public partial class InputFormMenu : Form
    {
        public string OutputValue;
        public InputFormMenu(string winTitle, string prompt, string startedString = null)
        {
            InitializeComponent();
            Text = winTitle;
            PromptLabel.Text = prompt;
            Size winSize = this.Size;
            MinimumSize = winSize;
            MaximumSize = winSize;

            InputTextBox.Text = startedString;
            InputTextBox.Focus();
            InputTextBox.Select();
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            OutputValue = InputTextBox.Text;
        }
    }
}
