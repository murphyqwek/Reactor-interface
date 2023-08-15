namespace Reactor_Interface.Forms.Journal
{
    partial class XRDKoeffMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.PorogMinTxtBx = new System.Windows.Forms.TextBox();
            this.PorogMaxTxtBx = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.minPeakSizeTxtBx = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.procentTxtBx = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(174, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "WindowSize Local";
            // 
            // PorogMinTxtBx
            // 
            this.PorogMinTxtBx.Location = new System.Drawing.Point(212, 208);
            this.PorogMinTxtBx.Name = "PorogMinTxtBx";
            this.PorogMinTxtBx.Size = new System.Drawing.Size(100, 26);
            this.PorogMinTxtBx.TabIndex = 1;
            // 
            // PorogMaxTxtBx
            // 
            this.PorogMaxTxtBx.Location = new System.Drawing.Point(212, 271);
            this.PorogMaxTxtBx.Name = "PorogMaxTxtBx";
            this.PorogMaxTxtBx.Size = new System.Drawing.Size(100, 26);
            this.PorogMaxTxtBx.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 247);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Order Local";
            // 
            // minPeakSizeTxtBx
            // 
            this.minPeakSizeTxtBx.Location = new System.Drawing.Point(12, 44);
            this.minPeakSizeTxtBx.Name = "minPeakSizeTxtBx";
            this.minPeakSizeTxtBx.Size = new System.Drawing.Size(100, 26);
            this.minPeakSizeTxtBx.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(252, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Минимальная высота перепада";
            // 
            // procentTxtBx
            // 
            this.procentTxtBx.Location = new System.Drawing.Point(12, 106);
            this.procentTxtBx.Name = "procentTxtBx";
            this.procentTxtBx.Size = new System.Drawing.Size(100, 26);
            this.procentTxtBx.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(257, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Минимальная глубина перепада";
            // 
            // XRDKoeffMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 302);
            this.Controls.Add(this.procentTxtBx);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.minPeakSizeTxtBx);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PorogMaxTxtBx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PorogMinTxtBx);
            this.Controls.Add(this.label1);
            this.Name = "XRDKoeffMenu";
            this.Text = "XRDKoeffMenu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.XRDKoeffMenu_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PorogMinTxtBx;
        private System.Windows.Forms.TextBox PorogMaxTxtBx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox minPeakSizeTxtBx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox procentTxtBx;
        private System.Windows.Forms.Label label4;
    }
}