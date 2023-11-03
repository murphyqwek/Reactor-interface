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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XRDKoeffMenu));
            this.label1 = new System.Windows.Forms.Label();
            this.orderTokTxtBx = new System.Windows.Forms.TextBox();
            this.windowSizeTokTxtBx = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.windowSizeVoltTxtBx = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.orderVoltTxtBx = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ContinueButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(369, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Размер окна для тока";
            // 
            // orderTokTxtBx
            // 
            this.orderTokTxtBx.Location = new System.Drawing.Point(388, 106);
            this.orderTokTxtBx.Name = "orderTokTxtBx";
            this.orderTokTxtBx.Size = new System.Drawing.Size(158, 26);
            this.orderTokTxtBx.TabIndex = 1;
            // 
            // windowSizeTokTxtBx
            // 
            this.windowSizeTokTxtBx.Location = new System.Drawing.Point(388, 44);
            this.windowSizeTokTxtBx.Name = "windowSizeTokTxtBx";
            this.windowSizeTokTxtBx.Size = new System.Drawing.Size(158, 26);
            this.windowSizeTokTxtBx.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(320, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Степень полинома для тока";
            // 
            // windowSizeVoltTxtBx
            // 
            this.windowSizeVoltTxtBx.Location = new System.Drawing.Point(12, 44);
            this.windowSizeVoltTxtBx.Name = "windowSizeVoltTxtBx";
            this.windowSizeVoltTxtBx.Size = new System.Drawing.Size(158, 26);
            this.windowSizeVoltTxtBx.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(234, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Размер окна для напряжения";
            // 
            // orderVoltTxtBx
            // 
            this.orderVoltTxtBx.Location = new System.Drawing.Point(12, 106);
            this.orderVoltTxtBx.Name = "orderVoltTxtBx";
            this.orderVoltTxtBx.Size = new System.Drawing.Size(158, 26);
            this.orderVoltTxtBx.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(283, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Степень полинома для напряжения";
            // 
            // ContinueButton
            // 
            this.ContinueButton.BackColor = System.Drawing.Color.GreenYellow;
            this.ContinueButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.ContinueButton.Location = new System.Drawing.Point(13, 161);
            this.ContinueButton.Name = "ContinueButton";
            this.ContinueButton.Size = new System.Drawing.Size(157, 40);
            this.ContinueButton.TabIndex = 8;
            this.ContinueButton.Text = "Продолжить";
            this.ContinueButton.UseVisualStyleBackColor = false;
            this.ContinueButton.Click += new System.EventHandler(this.ContinueButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.BackColor = System.Drawing.Color.Tomato;
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(389, 161);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(157, 40);
            this.CancelButton.TabIndex = 9;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // XRDKoeffMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 213);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ContinueButton);
            this.Controls.Add(this.orderVoltTxtBx);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.windowSizeVoltTxtBx);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.windowSizeTokTxtBx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.orderTokTxtBx);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "XRDKoeffMenu";
            this.Text = "Введите коэффицинеты";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox orderTokTxtBx;
        private System.Windows.Forms.TextBox windowSizeTokTxtBx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox windowSizeVoltTxtBx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox orderVoltTxtBx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ContinueButton;
        private System.Windows.Forms.Button CancelButton;
    }
}