namespace Reactor_Interface.Forms.Journal
{
    partial class Fill_mass_field_menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fill_mass_field_menu));
            this.get_mass_btn = new System.Windows.Forms.Button();
            this.fields_control = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // get_mass_btn
            // 
            this.get_mass_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.get_mass_btn.Location = new System.Drawing.Point(368, 252);
            this.get_mass_btn.Name = "get_mass_btn";
            this.get_mass_btn.Size = new System.Drawing.Size(142, 52);
            this.get_mass_btn.TabIndex = 1;
            this.get_mass_btn.Text = "Измерить массу";
            this.get_mass_btn.UseVisualStyleBackColor = true;
            this.get_mass_btn.Click += new System.EventHandler(this.get_mass_btn_Click);
            // 
            // fields_control
            // 
            this.fields_control.Location = new System.Drawing.Point(13, 13);
            this.fields_control.Name = "fields_control";
            this.fields_control.SelectedIndex = 0;
            this.fields_control.Size = new System.Drawing.Size(340, 291);
            this.fields_control.TabIndex = 2;
            // 
            // Fill_mass_field_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 316);
            this.Controls.Add(this.fields_control);
            this.Controls.Add(this.get_mass_btn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Fill_mass_field_menu";
            this.Text = "Заполнение массы";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button get_mass_btn;
        private System.Windows.Forms.TabControl fields_control;
    }
}