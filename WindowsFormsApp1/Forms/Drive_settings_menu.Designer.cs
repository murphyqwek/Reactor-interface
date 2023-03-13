namespace Reactor_Interface.Forms
{
    partial class Drive_settings_menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Drive_settings_menu));
            this.cancel_btn = new System.Windows.Forms.Button();
            this.save_btn = new System.Windows.Forms.Button();
            this.client_secret_txtbx = new System.Windows.Forms.TextBox();
            this.client_id_txtbx = new System.Windows.Forms.TextBox();
            this.drive_name_txtbx = new System.Windows.Forms.TextBox();
            this.client_secret_lbl = new System.Windows.Forms.Label();
            this.client_id_lbl = new System.Windows.Forms.Label();
            this.drive_name_lbl = new System.Windows.Forms.Label();
            this.delete_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cancel_btn
            // 
            this.cancel_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel_btn.Location = new System.Drawing.Point(159, 205);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(125, 36);
            this.cancel_btn.TabIndex = 15;
            this.cancel_btn.Text = "Отмена";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // save_btn
            // 
            this.save_btn.BackColor = System.Drawing.Color.YellowGreen;
            this.save_btn.Location = new System.Drawing.Point(11, 205);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(125, 36);
            this.save_btn.TabIndex = 14;
            this.save_btn.Text = "Сохранить";
            this.save_btn.UseVisualStyleBackColor = false;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // client_secret_txtbx
            // 
            this.client_secret_txtbx.Location = new System.Drawing.Point(16, 165);
            this.client_secret_txtbx.Name = "client_secret_txtbx";
            this.client_secret_txtbx.Size = new System.Drawing.Size(414, 26);
            this.client_secret_txtbx.TabIndex = 13;
            // 
            // client_id_txtbx
            // 
            this.client_id_txtbx.Location = new System.Drawing.Point(16, 99);
            this.client_id_txtbx.Name = "client_id_txtbx";
            this.client_id_txtbx.Size = new System.Drawing.Size(414, 26);
            this.client_id_txtbx.TabIndex = 12;
            // 
            // drive_name_txtbx
            // 
            this.drive_name_txtbx.Location = new System.Drawing.Point(16, 32);
            this.drive_name_txtbx.Name = "drive_name_txtbx";
            this.drive_name_txtbx.Size = new System.Drawing.Size(414, 26);
            this.drive_name_txtbx.TabIndex = 11;
            // 
            // client_secret_lbl
            // 
            this.client_secret_lbl.AutoSize = true;
            this.client_secret_lbl.Location = new System.Drawing.Point(12, 142);
            this.client_secret_lbl.Name = "client_secret_lbl";
            this.client_secret_lbl.Size = new System.Drawing.Size(97, 20);
            this.client_secret_lbl.TabIndex = 10;
            this.client_secret_lbl.Text = "Client secret";
            // 
            // client_id_lbl
            // 
            this.client_id_lbl.AutoSize = true;
            this.client_id_lbl.Location = new System.Drawing.Point(12, 76);
            this.client_id_lbl.Name = "client_id_lbl";
            this.client_id_lbl.Size = new System.Drawing.Size(65, 20);
            this.client_id_lbl.TabIndex = 9;
            this.client_id_lbl.Text = "Client id";
            // 
            // drive_name_lbl
            // 
            this.drive_name_lbl.AutoSize = true;
            this.drive_name_lbl.Location = new System.Drawing.Point(12, 9);
            this.drive_name_lbl.Name = "drive_name_lbl";
            this.drive_name_lbl.Size = new System.Drawing.Size(89, 20);
            this.drive_name_lbl.TabIndex = 8;
            this.drive_name_lbl.Text = "Имя диска";
            // 
            // delete_btn
            // 
            this.delete_btn.BackColor = System.Drawing.Color.Brown;
            this.delete_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.delete_btn.ForeColor = System.Drawing.Color.Black;
            this.delete_btn.Location = new System.Drawing.Point(305, 205);
            this.delete_btn.Name = "delete_btn";
            this.delete_btn.Size = new System.Drawing.Size(125, 36);
            this.delete_btn.TabIndex = 17;
            this.delete_btn.Text = "Удалить";
            this.delete_btn.UseVisualStyleBackColor = false;
            this.delete_btn.Click += new System.EventHandler(this.delete_btn_Click);
            // 
            // Drive_settings_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 257);
            this.Controls.Add(this.delete_btn);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.client_secret_txtbx);
            this.Controls.Add(this.client_id_txtbx);
            this.Controls.Add(this.drive_name_txtbx);
            this.Controls.Add(this.client_secret_lbl);
            this.Controls.Add(this.client_id_lbl);
            this.Controls.Add(this.drive_name_lbl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Drive_settings_menu";
            this.Text = "Настройки диска";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.TextBox client_secret_txtbx;
        private System.Windows.Forms.TextBox client_id_txtbx;
        private System.Windows.Forms.TextBox drive_name_txtbx;
        private System.Windows.Forms.Label client_secret_lbl;
        private System.Windows.Forms.Label client_id_lbl;
        private System.Windows.Forms.Label drive_name_lbl;
        private System.Windows.Forms.Button delete_btn;
    }
}