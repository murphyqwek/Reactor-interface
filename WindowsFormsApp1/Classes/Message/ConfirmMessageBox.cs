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
        public static bool Show(string text, string title = "Внимание", MessageBoxIcon messageBoxIcon = MessageBoxIcon.Warning)
        {
            var result = MessageBox.Show(text, title,
                                          MessageBoxButtons.YesNoCancel, messageBoxIcon, MessageBoxDefaultButton.Button3);

            if (result == DialogResult.Yes)
                return true;
            else
                return false;
        }
    }
}
