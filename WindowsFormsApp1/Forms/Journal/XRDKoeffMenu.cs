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
        public int windowSizeLocal, orderLocal;
        public int minPeakSize, procent;
        public bool finished = true;

        private void XRDKoeffMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Int32.TryParse(PorogMaxTxtBx.Text, out windowSizeLocal))
                finished = false;
            if (!Int32.TryParse(PorogMinTxtBx.Text, out orderLocal))
                finished = false;
            if (!Int32.TryParse(minPeakSizeTxtBx.Text, out minPeakSize))
                finished = false;
            if (!Int32.TryParse(procentTxtBx.Text, out procent))
                finished = false;
        }

        public XRDKoeffMenu(int windowSizeLocal, int orderLocal, int minPeakSize, int procent)
        {
            InitializeComponent();
            this.windowSizeLocal = windowSizeLocal;
            this.orderLocal = orderLocal;
            this.minPeakSize = minPeakSize;
            this.procent = procent;
            PorogMaxTxtBx.Text = windowSizeLocal.ToString();
            PorogMinTxtBx.Text = orderLocal.ToString();
            minPeakSizeTxtBx.Text = minPeakSize.ToString();
            procentTxtBx.Text = procent.ToString();
        }
    }
}
