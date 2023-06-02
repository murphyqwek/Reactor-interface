using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reactor_Interface.Classes.Message
{
    public class ConfirmMessageBox
    {
        public static bool Show(string text, string title = "Внимание")
        {
            var result = MessageBox.Show(text, title,
                                          MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);

            if (result == DialogResult.Yes)
                return true;
            else
                return false;
        }
    }
}
