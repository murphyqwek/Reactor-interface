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
        static public SizeF factor;
        static private void ScaleGroupbox(GroupBox groupBox)
        {
            groupBox.Width = (int)Math.Round(groupBox.Width * factor.Width);
            groupBox.Height = (int)Math.Round(groupBox.Height * factor.Height);
        }

        static public void ResizeFont(Font font)
        {
            //font.Size = (int)Math.Round(font.Size * factor.);
        }

        static public void ResizeGroupbox(GroupBox box, Size new_size)
        {
            box.Size = new_size;
            ScaleGroupbox(box);
        }
        static public void ResizeButton(Button button) 
        {
            button.Width = (int)Math.Round(button.Width * factor.Width);
            button.Height = (int)Math.Round(button.Height * factor.Height);
        }

        static public void ResizeRichTextBox(RichTextBox richTextBox)
        {
            richTextBox.Width = (int)Math.Round(richTextBox.Width * factor.Width);
            richTextBox.Height = (int)Math.Round(richTextBox.Height * factor.Height);
        }

        static public void SetFactor(SizeF factor)
        {
            DPI.factor = factor;
        }
    }
}
