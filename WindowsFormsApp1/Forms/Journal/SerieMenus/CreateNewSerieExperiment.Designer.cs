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
            this.MissingTemplateTip = new System.Windows.Forms.ToolTip(this.components);
            this.DamagedTemplateTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SerieTemplateListView
            // 
            this.SerieTemplateListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SerieTemplateListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SerieTemplateListView.HideSelection = false;
            this.SerieTemplateListView.Location = new System.Drawing.Point(3, 28);
            this.SerieTemplateListView.Name = "SerieTemplateListView";
            this.SerieTemplateListView.ShowItemToolTips = true;
            this.SerieTemplateListView.Size = new System.Drawing.Size(392, 395);
            this.SerieTemplateListView.SmallImageList = this.TemplatesStatusIcons;
            this.SerieTemplateListView.TabIndex = 0;
            this.SerieTemplateListView.UseCompatibleStateImageBehavior = false;
            this.SerieTemplateListView.View = System.Windows.Forms.View.List;
            // 
            // TemplatesStatusIcons
            // 
            this.TemplatesStatusIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TemplatesStatusIcons.ImageStream")));
            this.TemplatesStatusIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.TemplatesStatusIcons.Images.SetKeyName(0, "deleteIcon.png");
            this.TemplatesStatusIcons.Images.SetKeyName(1, "missingIcon.png");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SerieTemplateListView);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(398, 426);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Шаблоны серии";
            // 
            // MissingTemplateTip
            // 
            this.MissingTemplateTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.MissingTemplateTip.ToolTipTitle = "Внимание!";
            // 
            // DamagedTemplateTip
            // 
            this.DamagedTemplateTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Error;
            this.DamagedTemplateTip.ToolTipTitle = "Ошибка";
            // 
            // CreateNewSerieExperiment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreateNewSerieExperiment";
            this.Text = "Создание нового эксперимента";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView SerieTemplateListView;
        private System.Windows.Forms.ImageList TemplatesStatusIcons;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolTip MissingTemplateTip;
        private System.Windows.Forms.ToolTip DamagedTemplateTip;
    }
}