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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Пирометр");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("XRD");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Осциллограф");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Осциллограф(картинка)");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UploadingApplicienceDataMenu));
            this.appDataContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteDataBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.rewriteDataBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.AppViewList = new System.Windows.Forms.ListView();
            this.piroChBx = new System.Windows.Forms.CheckBox();
            this.xrdChBx = new System.Windows.Forms.CheckBox();
            this.osciChBx = new System.Windows.Forms.CheckBox();
            this.oscPicChBx = new System.Windows.Forms.CheckBox();
            this.appDataContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // appDataContextMenu
            // 
            this.appDataContextMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.appDataContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteDataBtn,
            this.rewriteDataBtn});
            this.appDataContextMenu.Name = "appDataContextMenu";
            this.appDataContextMenu.Size = new System.Drawing.Size(272, 68);
            this.appDataContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.appDataContextMenu_Opening);
            // 
            // deleteDataBtn
            // 
            this.deleteDataBtn.Name = "deleteDataBtn";
            this.deleteDataBtn.Size = new System.Drawing.Size(271, 32);
            this.deleteDataBtn.Text = "Удалить данные";
            this.deleteDataBtn.Click += new System.EventHandler(this.deleteDataBtn_Click);
            // 
            // rewriteDataBtn
            // 
            this.rewriteDataBtn.Name = "rewriteDataBtn";
            this.rewriteDataBtn.Size = new System.Drawing.Size(271, 32);
            this.rewriteDataBtn.Text = "Перезаписать записать";
            this.rewriteDataBtn.Click += new System.EventHandler(this.rewriteDataBtn_Click);
            // 
            // AppViewList
            // 
            this.AppViewList.ContextMenuStrip = this.appDataContextMenu;
            this.AppViewList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AppViewList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AppViewList.HideSelection = false;
            listViewItem1.StateImageIndex = 0;
            listViewItem2.StateImageIndex = 0;
            listViewItem3.StateImageIndex = 0;
            this.AppViewList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4});
            this.AppViewList.Location = new System.Drawing.Point(0, 0);
            this.AppViewList.MultiSelect = false;
            this.AppViewList.Name = "AppViewList";
            this.AppViewList.Size = new System.Drawing.Size(291, 136);
            this.AppViewList.TabIndex = 2;
            this.AppViewList.UseCompatibleStateImageBehavior = false;
            this.AppViewList.View = System.Windows.Forms.View.List;
            this.AppViewList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.AppViewList_MouseDoubleClick);
            // 
            // piroChBx
            // 
            this.piroChBx.AutoCheck = false;
            this.piroChBx.AutoSize = true;
            this.piroChBx.Location = new System.Drawing.Point(105, 5);
            this.piroChBx.Name = "piroChBx";
            this.piroChBx.Size = new System.Drawing.Size(22, 21);
            this.piroChBx.TabIndex = 3;
            this.piroChBx.UseVisualStyleBackColor = true;
            // 
            // xrdChBx
            // 
            this.xrdChBx.AutoCheck = false;
            this.xrdChBx.AutoSize = true;
            this.xrdChBx.Location = new System.Drawing.Point(48, 30);
            this.xrdChBx.Name = "xrdChBx";
            this.xrdChBx.Size = new System.Drawing.Size(22, 21);
            this.xrdChBx.TabIndex = 4;
            this.xrdChBx.UseVisualStyleBackColor = true;
            // 
            // osciChBx
            // 
            this.osciChBx.AutoCheck = false;
            this.osciChBx.AutoSize = true;
            this.osciChBx.Location = new System.Drawing.Point(138, 58);
            this.osciChBx.Name = "osciChBx";
            this.osciChBx.Size = new System.Drawing.Size(22, 21);
            this.osciChBx.TabIndex = 5;
            this.osciChBx.UseVisualStyleBackColor = true;
            // 
            // oscPicChBx
            // 
            this.oscPicChBx.AutoCheck = false;
            this.oscPicChBx.AutoSize = true;
            this.oscPicChBx.Location = new System.Drawing.Point(234, 86);
            this.oscPicChBx.Name = "oscPicChBx";
            this.oscPicChBx.Size = new System.Drawing.Size(22, 21);
            this.oscPicChBx.TabIndex = 6;
            this.oscPicChBx.UseVisualStyleBackColor = true;
            // 
            // UploadingApplicienceDataMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(291, 136);
            this.Controls.Add(this.oscPicChBx);
            this.Controls.Add(this.osciChBx);
            this.Controls.Add(this.xrdChBx);
            this.Controls.Add(this.piroChBx);
            this.Controls.Add(this.AppViewList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UploadingApplicienceDataMenu";
            this.Text = "Внесение данных";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UploadingApplicienceDataMenu_FormClosing);
            this.appDataContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip appDataContextMenu;
        private System.Windows.Forms.ToolStripMenuItem deleteDataBtn;
        private System.Windows.Forms.ToolStripMenuItem rewriteDataBtn;
        private System.Windows.Forms.ListView AppViewList;
        private System.Windows.Forms.CheckBox piroChBx;
        private System.Windows.Forms.CheckBox xrdChBx;
        private System.Windows.Forms.CheckBox osciChBx;
        private System.Windows.Forms.CheckBox oscPicChBx;
    }
}