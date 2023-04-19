namespace Reactor_Interface.Forms.Journal
{
    partial class SerieChosenMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SerieChosenMenu));
            this.SeriesTreeView = new System.Windows.Forms.TreeView();
            this.UpdateSerieMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.UpdateSerieMenuBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeIconImageList = new System.Windows.Forms.ImageList(this.components);
            this.SerieContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ChooseSerieBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateSeriesBtn = new System.Windows.Forms.Button();
            this.CreateNewSerieBtn = new System.Windows.Forms.Button();
            this.UpdateSerieMenu.SuspendLayout();
            this.SerieContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // SeriesTreeView
            // 
            this.SeriesTreeView.ContextMenuStrip = this.UpdateSerieMenu;
            this.SeriesTreeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.SeriesTreeView.ImageIndex = 0;
            this.SeriesTreeView.ImageList = this.TreeIconImageList;
            this.SeriesTreeView.Location = new System.Drawing.Point(0, 0);
            this.SeriesTreeView.Name = "SeriesTreeView";
            this.SeriesTreeView.SelectedImageIndex = 0;
            this.SeriesTreeView.Size = new System.Drawing.Size(361, 320);
            this.SeriesTreeView.TabIndex = 0;
            // 
            // UpdateSerieMenu
            // 
            this.UpdateSerieMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.UpdateSerieMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UpdateSerieMenuBtn});
            this.UpdateSerieMenu.Name = "UpdateSerieMenu";
            this.UpdateSerieMenu.Size = new System.Drawing.Size(280, 36);
            // 
            // UpdateSerieMenuBtn
            // 
            this.UpdateSerieMenuBtn.Name = "UpdateSerieMenuBtn";
            this.UpdateSerieMenuBtn.Size = new System.Drawing.Size(279, 32);
            this.UpdateSerieMenuBtn.Text = "Обновить список серий";
            // 
            // TreeIconImageList
            // 
            this.TreeIconImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TreeIconImageList.ImageStream")));
            this.TreeIconImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.TreeIconImageList.Images.SetKeyName(0, "FolderIcon.png");
            this.TreeIconImageList.Images.SetKeyName(1, "ExcelIcon.png");
            // 
            // SerieContextMenuStrip
            // 
            this.SerieContextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.SerieContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChooseSerieBtn});
            this.SerieContextMenuStrip.Name = "SerieContextMenuStrip";
            this.SerieContextMenuStrip.Size = new System.Drawing.Size(342, 36);
            // 
            // ChooseSerieBtn
            // 
            this.ChooseSerieBtn.Name = "ChooseSerieBtn";
            this.ChooseSerieBtn.Size = new System.Drawing.Size(341, 32);
            this.ChooseSerieBtn.Text = "Выбрать серию экспериментов";
            this.ChooseSerieBtn.Click += new System.EventHandler(this.ChooseSerieBtn_Click);
            // 
            // UpdateSeriesBtn
            // 
            this.UpdateSeriesBtn.Location = new System.Drawing.Point(437, 251);
            this.UpdateSeriesBtn.Name = "UpdateSeriesBtn";
            this.UpdateSeriesBtn.Size = new System.Drawing.Size(100, 57);
            this.UpdateSeriesBtn.TabIndex = 2;
            this.UpdateSeriesBtn.Text = "Обновить";
            this.UpdateSeriesBtn.UseVisualStyleBackColor = true;
            this.UpdateSeriesBtn.Click += new System.EventHandler(this.UpdateSeriesBtn_Click);
            // 
            // CreateNewSerieBtn
            // 
            this.CreateNewSerieBtn.Location = new System.Drawing.Point(437, 188);
            this.CreateNewSerieBtn.Name = "CreateNewSerieBtn";
            this.CreateNewSerieBtn.Size = new System.Drawing.Size(100, 57);
            this.CreateNewSerieBtn.TabIndex = 3;
            this.CreateNewSerieBtn.Text = "Новая серия";
            this.CreateNewSerieBtn.UseVisualStyleBackColor = true;
            this.CreateNewSerieBtn.Click += new System.EventHandler(this.CreateNewSerieBtn_Click);
            // 
            // SerieChosenMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 320);
            this.Controls.Add(this.CreateNewSerieBtn);
            this.Controls.Add(this.UpdateSeriesBtn);
            this.Controls.Add(this.SeriesTreeView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SerieChosenMenu";
            this.Text = "Серия эксперимента";
            this.UpdateSerieMenu.ResumeLayout(false);
            this.SerieContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView SeriesTreeView;
        private System.Windows.Forms.ImageList TreeIconImageList;
        private System.Windows.Forms.ContextMenuStrip SerieContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ChooseSerieBtn;
        private System.Windows.Forms.ContextMenuStrip UpdateSerieMenu;
        private System.Windows.Forms.ToolStripMenuItem UpdateSerieMenuBtn;
        private System.Windows.Forms.Button UpdateSeriesBtn;
        private System.Windows.Forms.Button CreateNewSerieBtn;
    }
}