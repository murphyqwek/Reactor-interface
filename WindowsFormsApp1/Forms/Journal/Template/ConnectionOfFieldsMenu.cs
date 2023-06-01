using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reactor_Interface.Forms.Journal.Template
{
    public partial class ConnectionOfFieldsMenu : Form
    {
        int _usingTxtBoxX, _usingTxtBoxY;
        TabControl _pages;

        public ConnectionOfFieldsMenu(TabControl pages, int usingTxtBoxX, int usingTxtBoxY)
        {
            InitializeComponent();
            _pages = pages;
            _usingTxtBoxX = usingTxtBoxX;
            _usingTxtBoxY = usingTxtBoxY;
        }

        void ParsePages()
        {
            foreach(TabPage page in _pages.TabPages) 
            {
                ParsePage(page);
            }
        }

        private void ParsePage(TabPage page)
        {

            foreach (RichTextBox field in page.Controls.OfType<RichTextBox>())
            {
                if (field.BackColor != Color.White || !field.Visible)
                    continue;


            }
        }
    }
}
