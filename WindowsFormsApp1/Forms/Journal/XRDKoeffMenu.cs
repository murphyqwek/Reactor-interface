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
    public partial class XRDKoeffMenu : Form
    {
        public int windowSizeTok, orderTok;
        public int windowsSizeVolt, orderVolt;
        public bool finished = true;

        private void ContinueButton_Click(object sender, EventArgs e)
        {
            if (!Int32.TryParse(windowSizeTokTxtBx.Text, out windowSizeTok))
                finished = false;
            if (!Int32.TryParse(orderTokTxtBx.Text, out orderTok))
                finished = false;
            if (!Int32.TryParse(windowSizeVoltTxtBx.Text, out windowsSizeVolt))
                finished = false;
            if (!Int32.TryParse(orderVoltTxtBx.Text, out orderVolt))
                finished = false;

            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public XRDKoeffMenu(int windowSizeTok, int orderTok, int windowSizeVolt, int orderVolt)
        {
            InitializeComponent();
            this.windowSizeTok = windowSizeTok;
            this.orderTok = orderTok;
            this.windowsSizeVolt = windowSizeVolt;
            this.orderVolt = orderVolt;
            windowSizeTokTxtBx.Text = windowSizeTok.ToString();
            orderTokTxtBx.Text = orderTok.ToString();
            windowSizeVoltTxtBx.Text = windowSizeVolt.ToString();
            orderVoltTxtBx.Text = orderVolt.ToString();
        }
    }
}
