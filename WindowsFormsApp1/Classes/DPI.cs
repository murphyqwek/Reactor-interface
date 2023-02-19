using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reactor_Interface.Classes
{
    static public class DPI
    {
        static private SizeF factor;
        static public void ScaleGroupbox(GroupBox groupBox)
        {
            groupBox.Width = (int)Math.Round(groupBox.Width * factor.Width);
            groupBox.Height = (int)Math.Round(groupBox.Height * factor.Height);
        }

        static public void ResizeGroupbox(GroupBox box, Size new_size)
        {
            box.Size = new_size;
            ScaleGroupbox(box);
        }

        static public void SetFactor(SizeF factor)
        {
            DPI.factor = factor;
        }
    }
}
