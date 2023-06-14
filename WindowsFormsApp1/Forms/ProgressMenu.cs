using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reactor_Interface.Forms
{
    public partial class ProgressMenu : Form
    {
        public ProgressMenu(string title, int setProgress)
        {
            InitializeComponent();

            Text = title;
            ProgressBar.Step = setProgress;
        }

        public void SetTask(string task)
        {
            TaskProcessingLabel.Text = task;
        }

        public void PerformStep()
        {
            ProgressBar.PerformStep();
        }
    }
}
