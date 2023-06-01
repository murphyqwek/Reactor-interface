namespace Reactor_Interface.Forms.Journal.Template
{
    partial class ConnectionOfFieldsMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionOfFieldsMenu));
            this.FieldsPageContorls = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.FieldsPageContorls.SuspendLayout();
            this.SuspendLayout();
            // 
            // FieldsPageContorls
            // 
            this.FieldsPageContorls.Controls.Add(this.tabPage1);
            this.FieldsPageContorls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FieldsPageContorls.Location = new System.Drawing.Point(0, 0);
            this.FieldsPageContorls.Name = "FieldsPageContorls";
            this.FieldsPageContorls.SelectedIndex = 0;
            this.FieldsPageContorls.Size = new System.Drawing.Size(800, 450);
            this.FieldsPageContorls.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 417);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ConnectionOfFieldsMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.FieldsPageContorls);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConnectionOfFieldsMenu";
            this.Text = "к";
            this.FieldsPageContorls.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl FieldsPageContorls;
        private System.Windows.Forms.TabPage tabPage1;
    }
}