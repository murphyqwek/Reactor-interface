namespace Reactor_Interface.Forms.Journal.SerieMenus
{
    partial class CreateNewSerieExperiment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateNewSerieExperiment));
            this.SerieTemplateListView = new System.Windows.Forms.ListView();
            this.TemplatesStatusIcons = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ButtonsGroupBox = new System.Windows.Forms.GroupBox();
            this.CreateExperimentBtn = new System.Windows.Forms.Button();
            this.DeleteTemplateBtn = new System.Windows.Forms.Button();
            this.UploadNewTemplateBtn = new System.Windows.Forms.Button();
            this.UpdateListTemplatesBtn = new System.Windows.Forms.Button();
            this.SelectedTemplateLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.ButtonsGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // SerieTemplateListView
            // 
            this.SerieTemplateListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SerieTemplateListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SerieTemplateListView.HideSelection = false;
            this.SerieTemplateListView.Location = new System.Drawing.Point(3, 28);
            this.SerieTemplateListView.MultiSelect = false;
            this.SerieTemplateListView.Name = "SerieTemplateListView";
            this.SerieTemplateListView.ShowItemToolTips = true;
            this.SerieTemplateListView.Size = new System.Drawing.Size(392, 328);
            this.SerieTemplateListView.SmallImageList = this.TemplatesStatusIcons;
            this.SerieTemplateListView.TabIndex = 0;
            this.SerieTemplateListView.UseCompatibleStateImageBehavior = false;
            this.SerieTemplateListView.View = System.Windows.Forms.View.List;
            this.SerieTemplateListView.SelectedIndexChanged += new System.EventHandler(this.SerieTemplateListView_SelectedIndexChanged);
            // 
            // TemplatesStatusIcons
            // 
            this.TemplatesStatusIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TemplatesStatusIcons.ImageStream")));
            this.TemplatesStatusIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.TemplatesStatusIcons.Images.SetKeyName(0, "changed.png");
            this.TemplatesStatusIcons.Images.SetKeyName(1, "missed.png");
            this.TemplatesStatusIcons.Images.SetKeyName(2, "damaged.png");
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.SerieTemplateListView);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(398, 359);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Шаблоны серии";
            // 
            // ButtonsGroupBox
            // 
            this.ButtonsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonsGroupBox.Controls.Add(this.UpdateListTemplatesBtn);
            this.ButtonsGroupBox.Controls.Add(this.UploadNewTemplateBtn);
            this.ButtonsGroupBox.Controls.Add(this.DeleteTemplateBtn);
            this.ButtonsGroupBox.Controls.Add(this.CreateExperimentBtn);
            this.ButtonsGroupBox.Location = new System.Drawing.Point(416, 200);
            this.ButtonsGroupBox.Name = "ButtonsGroupBox";
            this.ButtonsGroupBox.Size = new System.Drawing.Size(289, 171);
            this.ButtonsGroupBox.TabIndex = 2;
            this.ButtonsGroupBox.TabStop = false;
            // 
            // CreateExperimentBtn
            // 
            this.CreateExperimentBtn.BackColor = System.Drawing.Color.GreenYellow;
            this.CreateExperimentBtn.Location = new System.Drawing.Point(6, 25);
            this.CreateExperimentBtn.Name = "CreateExperimentBtn";
            this.CreateExperimentBtn.Size = new System.Drawing.Size(139, 52);
            this.CreateExperimentBtn.TabIndex = 0;
            this.CreateExperimentBtn.Text = "Создать эксперимент";
            this.CreateExperimentBtn.UseVisualStyleBackColor = false;
            this.CreateExperimentBtn.Visible = false;
            this.CreateExperimentBtn.Click += new System.EventHandler(this.CreateExperimentBtn_Click);
            // 
            // DeleteTemplateBtn
            // 
            this.DeleteTemplateBtn.BackColor = System.Drawing.Color.Tomato;
            this.DeleteTemplateBtn.Location = new System.Drawing.Point(151, 25);
            this.DeleteTemplateBtn.Name = "DeleteTemplateBtn";
            this.DeleteTemplateBtn.Size = new System.Drawing.Size(132, 52);
            this.DeleteTemplateBtn.TabIndex = 1;
            this.DeleteTemplateBtn.Text = "Удалить шаблон";
            this.DeleteTemplateBtn.UseVisualStyleBackColor = false;
            this.DeleteTemplateBtn.Visible = false;
            this.DeleteTemplateBtn.Click += new System.EventHandler(this.DeleteTemplateBtn_Click);
            // 
            // UploadNewTemplateBtn
            // 
            this.UploadNewTemplateBtn.BackColor = System.Drawing.Color.Gold;
            this.UploadNewTemplateBtn.Location = new System.Drawing.Point(6, 104);
            this.UploadNewTemplateBtn.Name = "UploadNewTemplateBtn";
            this.UploadNewTemplateBtn.Size = new System.Drawing.Size(139, 52);
            this.UploadNewTemplateBtn.TabIndex = 2;
            this.UploadNewTemplateBtn.Text = "Загрузить в базу шаблонов";
            this.UploadNewTemplateBtn.UseVisualStyleBackColor = false;
            this.UploadNewTemplateBtn.Visible = false;
            this.UploadNewTemplateBtn.Click += new System.EventHandler(this.UploadNewTemplateBtn_Click);
            // 
            // UpdateListTemplatesBtn
            // 
            this.UpdateListTemplatesBtn.BackColor = System.Drawing.SystemColors.Control;
            this.UpdateListTemplatesBtn.Location = new System.Drawing.Point(151, 104);
            this.UpdateListTemplatesBtn.Name = "UpdateListTemplatesBtn";
            this.UpdateListTemplatesBtn.Size = new System.Drawing.Size(132, 52);
            this.UpdateListTemplatesBtn.TabIndex = 3;
            this.UpdateListTemplatesBtn.Text = "Обновить список";
            this.UpdateListTemplatesBtn.UseVisualStyleBackColor = false;
            this.UpdateListTemplatesBtn.Click += new System.EventHandler(this.UpdateListTemplatesBtn_Click);
            // 
            // SelectedTemplateLabel
            // 
            this.SelectedTemplateLabel.AutoSize = true;
            this.SelectedTemplateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SelectedTemplateLabel.Location = new System.Drawing.Point(6, 28);
            this.SelectedTemplateLabel.Name = "SelectedTemplateLabel";
            this.SelectedTemplateLabel.Size = new System.Drawing.Size(150, 20);
            this.SelectedTemplateLabel.TabIndex = 0;
            this.SelectedTemplateLabel.Text = "Шаблон не выбран";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SelectedTemplateLabel);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(422, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(283, 84);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Выбранный шаблон";
            // 
            // CreateNewSerieExperiment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 383);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ButtonsGroupBox);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreateNewSerieExperiment";
            this.Text = "Создание нового эксперимента";
            this.groupBox1.ResumeLayout(false);
            this.ButtonsGroupBox.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView SerieTemplateListView;
        private System.Windows.Forms.ImageList TemplatesStatusIcons;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox ButtonsGroupBox;
        private System.Windows.Forms.Button UpdateListTemplatesBtn;
        private System.Windows.Forms.Button UploadNewTemplateBtn;
        private System.Windows.Forms.Button DeleteTemplateBtn;
        private System.Windows.Forms.Button CreateExperimentBtn;
        private System.Windows.Forms.Label SelectedTemplateLabel;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}