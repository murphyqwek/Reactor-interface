namespace Reactor_Interface.Forms
{
    partial class New_Drive_menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(New_Drive_menu));
            this.drive_name_lbl = new System.Windows.Forms.Label();
            this.client_id_lbl = new System.Windows.Forms.Label();
            this.client_secret_lbl = new System.Windows.Forms.Label();
            this.drive_name_txtbx = new System.Windows.Forms.TextBox();
            this.client_id_txtbx = new System.Windows.Forms.TextBox();
            this.client_secret_txtbx = new System.Windows.Forms.TextBox();
            this.create_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // drive_name_lbl
            // 
            this.drive_name_lbl.AutoSize = true;
            this.drive_name_lbl.Location = new System.Drawing.Point(13, 13);
            this.drive_name_lbl.Name = "drive_name_lbl";
            this.drive_name_lbl.Size = new System.Drawing.Size(89, 20);
            this.drive_name_lbl.TabIndex = 0;
            this.drive_name_lbl.Text = "Имя диска";
            // 
            // client_id_lbl
            // 
            this.client_id_lbl.AutoSize = true;
            this.client_id_lbl.Location = new System.Drawing.Point(13, 80);
            this.client_id_lbl.Name = "client_id_lbl";
            this.client_id_lbl.Size = new System.Drawing.Size(65, 20);
            this.client_id_lbl.TabIndex = 1;
            this.client_id_lbl.Text = "Client id";
            // 
            // client_secret_lbl
            // 
            this.client_secret_lbl.AutoSize = true;
            this.client_secret_lbl.Location = new System.Drawing.Point(13, 146);
            this.client_secret_lbl.Name = "client_secret_lbl";
            this.client_secret_lbl.Size = new System.Drawing.Size(97, 20);
            this.client_secret_lbl.TabIndex = 2;
            this.client_secret_lbl.Text = "Client secret";
            // 
            // drive_name_txtbx
            // 
            this.drive_name_txtbx.Location = new System.Drawing.Point(17, 36);
            this.drive_name_txtbx.Name = "drive_name_txtbx";
            this.drive_name_txtbx.Size = new System.Drawing.Size(265, 26);
            this.drive_name_txtbx.TabIndex = 3;
            // 
            // client_id_txtbx
            // 
            this.client_id_txtbx.Location = new System.Drawing.Point(17, 103);
            this.client_id_txtbx.Name = "client_id_txtbx";
            this.client_id_txtbx.Size = new System.Drawing.Size(265, 26);
            this.client_id_txtbx.TabIndex = 4;
            // 
            // client_secret_txtbx
            // 
            this.client_secret_txtbx.Location = new System.Drawing.Point(17, 169);
            this.client_secret_txtbx.Name = "client_secret_txtbx";
            this.client_secret_txtbx.Size = new System.Drawing.Size(265, 26);
            this.client_secret_txtbx.TabIndex = 5;
            // 
            // create_btn
            // 
            this.create_btn.BackColor = System.Drawing.Color.YellowGreen;
            this.create_btn.Location = new System.Drawing.Point(12, 209);
            this.create_btn.Name = "create_btn";
            this.create_btn.Size = new System.Drawing.Size(125, 36);
            this.create_btn.TabIndex = 6;
            this.create_btn.Text = "Создать";
            this.create_btn.UseVisualStyleBackColor = false;
            this.create_btn.Click += new System.EventHandler(this.create_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.BackColor = System.Drawing.Color.Brown;
            this.cancel_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel_btn.Location = new System.Drawing.Point(157, 209);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(125, 36);
            this.cancel_btn.TabIndex = 7;
            this.cancel_btn.Text = "Отмена";
            this.cancel_btn.UseVisualStyleBackColor = false;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // New_Drive_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.cancel_btn;
            this.ClientSize = new System.Drawing.Size(297, 257);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.create_btn);
            this.Controls.Add(this.client_secret_txtbx);
            this.Controls.Add(this.client_id_txtbx);
            this.Controls.Add(this.drive_name_txtbx);
            this.Controls.Add(this.client_secret_lbl);
            this.Controls.Add(this.client_id_lbl);
            this.Controls.Add(this.drive_name_lbl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "New_Drive_menu";
            this.ShowInTaskbar = false;
            this.Text = "Новый диск";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label drive_name_lbl;
        private System.Windows.Forms.Label client_id_lbl;
        private System.Windows.Forms.Label client_secret_lbl;
        private System.Windows.Forms.TextBox drive_name_txtbx;
        private System.Windows.Forms.TextBox client_id_txtbx;
        private System.Windows.Forms.TextBox client_secret_txtbx;
        private System.Windows.Forms.Button create_btn;
        private System.Windows.Forms.Button cancel_btn;
    }
}