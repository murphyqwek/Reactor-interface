namespace Reactor_Interface.Forms.Experiment
{
    partial class Numer_menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Numer_menu));
            this.next_btn = new System.Windows.Forms.Button();
            this.numer_textbx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // next_btn
            // 
            this.next_btn.BackColor = System.Drawing.Color.YellowGreen;
            this.next_btn.Location = new System.Drawing.Point(12, 89);
            this.next_btn.Name = "next_btn";
            this.next_btn.Size = new System.Drawing.Size(283, 30);
            this.next_btn.TabIndex = 5;
            this.next_btn.Text = "Далее";
            this.next_btn.UseVisualStyleBackColor = false;
            this.next_btn.Click += new System.EventHandler(this.next_btn_Click);
            // 
            // numer_textbx
            // 
            this.numer_textbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numer_textbx.Location = new System.Drawing.Point(12, 40);
            this.numer_textbx.Name = "numer_textbx";
            this.numer_textbx.Size = new System.Drawing.Size(283, 26);
            this.numer_textbx.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Номер эксперимента:";
            // 
            // Numer_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 141);
            this.Controls.Add(this.next_btn);
            this.Controls.Add(this.numer_textbx);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Numer_menu";
            this.ShowInTaskbar = false;
            this.Text = "Эксперимент";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button next_btn;
        private System.Windows.Forms.TextBox numer_textbx;
        private System.Windows.Forms.Label label1;
    }
}