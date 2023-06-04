namespace Reactor_Interface.Forms.Journal.SerieMenus
{
    partial class SerieExperimentsMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SerieExperimentsMenu));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SerieTree = new System.Windows.Forms.TreeView();
            this.IconList = new System.Windows.Forms.ImageList(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SelectedExperimentLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ExcelExportBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenExperimentFolderBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteExperimentBtn = new System.Windows.Forms.Button();
            this.OpenExperimentBtn = new System.Windows.Forms.Button();
            this.UpdateListViewBtn = new System.Windows.Forms.Button();
            this.UploadTemplateBtn = new System.Windows.Forms.Button();
            this.uploadtemplatetip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SerieTree);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(429, 402);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Эксперименты серии";
            // 
            // SerieTree
            // 
            this.SerieTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SerieTree.ImageIndex = 0;
            this.SerieTree.ImageList = this.IconList;
            this.SerieTree.Location = new System.Drawing.Point(3, 24);
            this.SerieTree.Name = "SerieTree";
            this.SerieTree.SelectedImageIndex = 0;
            this.SerieTree.ShowNodeToolTips = true;
            this.SerieTree.Size = new System.Drawing.Size(423, 375);
            this.SerieTree.TabIndex = 0;
            this.SerieTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.SerieTree_AfterSelect);
            // 
            // IconList
            // 
            this.IconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IconList.ImageStream")));
            this.IconList.TransparentColor = System.Drawing.Color.Transparent;
            this.IconList.Images.SetKeyName(0, "serie.png");
            this.IconList.Images.SetKeyName(1, "damaged.png");
            this.IconList.Images.SetKeyName(2, "changed.png");
            this.IconList.Images.SetKeyName(3, "missed.png");
            this.IconList.Images.SetKeyName(4, "experiment.png");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SelectedExperimentLabel);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(447, 36);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(341, 92);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Выбранный эксперимент";
            // 
            // SelectedExperimentLabel
            // 
            this.SelectedExperimentLabel.AutoSize = true;
            this.SelectedExperimentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SelectedExperimentLabel.Location = new System.Drawing.Point(7, 41);
            this.SelectedExperimentLabel.Name = "SelectedExperimentLabel";
            this.SelectedExperimentLabel.Size = new System.Drawing.Size(193, 20);
            this.SelectedExperimentLabel.TabIndex = 0;
            this.SelectedExperimentLabel.Text = "Эксперимент не выбран";
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExcelExportBtn,
            this.OpenExperimentFolderBtn});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 33);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ExcelExportBtn
            // 
            this.ExcelExportBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ExcelExportBtn.Name = "ExcelExportBtn";
            this.ExcelExportBtn.Size = new System.Drawing.Size(220, 29);
            this.ExcelExportBtn.Text = "Экспортировать в Excel";
            // 
            // OpenExperimentFolderBtn
            // 
            this.OpenExperimentFolderBtn.Name = "OpenExperimentFolderBtn";
            this.OpenExperimentFolderBtn.Size = new System.Drawing.Size(285, 29);
            this.OpenExperimentFolderBtn.Text = "Открыть папку экспериментов ";
            this.OpenExperimentFolderBtn.Click += new System.EventHandler(this.OpenExperimentFolderBtn_Click);
            // 
            // DeleteExperimentBtn
            // 
            this.DeleteExperimentBtn.BackColor = System.Drawing.Color.Tomato;
            this.DeleteExperimentBtn.Location = new System.Drawing.Point(667, 298);
            this.DeleteExperimentBtn.Name = "DeleteExperimentBtn";
            this.DeleteExperimentBtn.Size = new System.Drawing.Size(121, 65);
            this.DeleteExperimentBtn.TabIndex = 0;
            this.DeleteExperimentBtn.Text = "Удалить эксперимент";
            this.DeleteExperimentBtn.UseVisualStyleBackColor = false;
            this.DeleteExperimentBtn.Visible = false;
            // 
            // OpenExperimentBtn
            // 
            this.OpenExperimentBtn.BackColor = System.Drawing.Color.GreenYellow;
            this.OpenExperimentBtn.Location = new System.Drawing.Point(458, 298);
            this.OpenExperimentBtn.Name = "OpenExperimentBtn";
            this.OpenExperimentBtn.Size = new System.Drawing.Size(121, 65);
            this.OpenExperimentBtn.TabIndex = 3;
            this.OpenExperimentBtn.Text = "Открыть эксперимент";
            this.OpenExperimentBtn.UseVisualStyleBackColor = false;
            this.OpenExperimentBtn.Visible = false;
            this.OpenExperimentBtn.Click += new System.EventHandler(this.OpenExperimentBtn_Click);
            // 
            // UpdateListViewBtn
            // 
            this.UpdateListViewBtn.BackColor = System.Drawing.SystemColors.Control;
            this.UpdateListViewBtn.Location = new System.Drawing.Point(667, 373);
            this.UpdateListViewBtn.Name = "UpdateListViewBtn";
            this.UpdateListViewBtn.Size = new System.Drawing.Size(121, 65);
            this.UpdateListViewBtn.TabIndex = 4;
            this.UpdateListViewBtn.Text = "Обновить список";
            this.UpdateListViewBtn.UseVisualStyleBackColor = false;
            this.UpdateListViewBtn.Click += new System.EventHandler(this.UpdateListViewBtn_Click);
            // 
            // UploadTemplateBtn
            // 
            this.UploadTemplateBtn.BackColor = System.Drawing.Color.Gold;
            this.UploadTemplateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UploadTemplateBtn.Location = new System.Drawing.Point(458, 373);
            this.UploadTemplateBtn.Name = "UploadTemplateBtn";
            this.UploadTemplateBtn.Size = new System.Drawing.Size(121, 65);
            this.UploadTemplateBtn.TabIndex = 5;
            this.UploadTemplateBtn.Text = "Добавить в базу шаблонов";
            this.uploadtemplatetip.SetToolTip(this.UploadTemplateBtn, "Создать на основе эксперимента шаблон");
            this.UploadTemplateBtn.UseVisualStyleBackColor = false;
            this.UploadTemplateBtn.Visible = false;
            // 
            // SerieExperimentsMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.UploadTemplateBtn);
            this.Controls.Add(this.UpdateListViewBtn);
            this.Controls.Add(this.OpenExperimentBtn);
            this.Controls.Add(this.DeleteExperimentBtn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SerieExperimentsMenu";
            this.Text = "Эксперименты серии";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView SerieTree;
        private System.Windows.Forms.ImageList IconList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label SelectedExperimentLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ExcelExportBtn;
        private System.Windows.Forms.ToolStripMenuItem OpenExperimentFolderBtn;
        private System.Windows.Forms.Button DeleteExperimentBtn;
        private System.Windows.Forms.Button OpenExperimentBtn;
        private System.Windows.Forms.Button UpdateListViewBtn;
        private System.Windows.Forms.Button UploadTemplateBtn;
        private System.Windows.Forms.ToolTip uploadtemplatetip;
    }
}