namespace Reactor_Interface.Forms.Journal
{
    partial class UploadingApplicienceDataMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UploadingApplicienceDataMenu));
            this.appDataGetList = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // appDataGetList
            // 
            this.appDataGetList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.appDataGetList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.appDataGetList.FormattingEnabled = true;
            this.appDataGetList.Items.AddRange(new object[] {
            "Термометр",
            "XRD"});
            this.appDataGetList.Location = new System.Drawing.Point(0, 0);
            this.appDataGetList.Name = "appDataGetList";
            this.appDataGetList.Size = new System.Drawing.Size(391, 173);
            this.appDataGetList.TabIndex = 0;
            this.appDataGetList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.appDataGetList_ItemCheck);
            // 
            // UploadingApplicienceDataMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 173);
            this.Controls.Add(this.appDataGetList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UploadingApplicienceDataMenu";
            this.Text = "Внесение данных";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UploadingApplicienceDataMenu_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox appDataGetList;
    }
}