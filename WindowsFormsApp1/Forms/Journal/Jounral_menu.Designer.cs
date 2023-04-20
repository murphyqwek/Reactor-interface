namespace Reactor_Interface
{
    partial class Jounral_menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Jounral_menu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.experiment_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.облачноеХранилищеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.googleDriveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.change_serie_menubtn = new System.Windows.Forms.ToolStripMenuItem();
            this.save_menubtn = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveOnComp_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.googleDriveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.weigher_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.data_groupbox = new System.Windows.Forms.GroupBox();
            this.data_control = new System.Windows.Forms.TabControl();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comments_txtbx = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.clear_btn = new System.Windows.Forms.Button();
            this.context_menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.weigh_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.get_mass_btn = new System.Windows.Forms.Button();
            this.CreateNewExperimentBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.UploadExperimentBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.UploadExperimentComputerBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.сОблачногоХранилищаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveExperimentBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.data_groupbox.SuspendLayout();
            this.context_menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.experiment_btn,
            this.облачноеХранилищеToolStripMenuItem,
            this.save_menubtn,
            this.weigher_btn});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1304, 36);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // experiment_btn
            // 
            this.experiment_btn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateNewExperimentBtn,
            this.UploadExperimentBtn,
            this.SaveExperimentBtn});
            this.experiment_btn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.experiment_btn.Name = "experiment_btn";
            this.experiment_btn.Size = new System.Drawing.Size(153, 32);
            this.experiment_btn.Text = "Эксперимент:";
            this.experiment_btn.DropDownOpening += new System.EventHandler(this.experiment_btn_DropDownOpening);
            // 
            // облачноеХранилищеToolStripMenuItem
            // 
            this.облачноеХранилищеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.googleDriveToolStripMenuItem,
            this.change_serie_menubtn});
            this.облачноеХранилищеToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.облачноеХранилищеToolStripMenuItem.Name = "облачноеХранилищеToolStripMenuItem";
            this.облачноеХранилищеToolStripMenuItem.Size = new System.Drawing.Size(230, 32);
            this.облачноеХранилищеToolStripMenuItem.Text = "Облачное хранилище";
            // 
            // googleDriveToolStripMenuItem
            // 
            this.googleDriveToolStripMenuItem.Name = "googleDriveToolStripMenuItem";
            this.googleDriveToolStripMenuItem.Size = new System.Drawing.Size(259, 36);
            this.googleDriveToolStripMenuItem.Text = "Google Drive:";
            this.googleDriveToolStripMenuItem.Click += new System.EventHandler(this.googleDriveToolStripMenuItem_DropDownItemClicked);
            // 
            // change_serie_menubtn
            // 
            this.change_serie_menubtn.Name = "change_serie_menubtn";
            this.change_serie_menubtn.Size = new System.Drawing.Size(259, 36);
            this.change_serie_menubtn.Text = "Выбрать серию:";
            this.change_serie_menubtn.Click += new System.EventHandler(this.change_serie_menubtn_Click);
            // 
            // save_menubtn
            // 
            this.save_menubtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.save_menubtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveOnComp_btn,
            this.googleDriveToolStripMenuItem1});
            this.save_menubtn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.save_menubtn.Name = "save_menubtn";
            this.save_menubtn.Size = new System.Drawing.Size(279, 32);
            this.save_menubtn.Text = "Сохранить эксперимент на:";
            this.save_menubtn.Click += new System.EventHandler(this.save_menubtn_Click);
            // 
            // SaveOnComp_btn
            // 
            this.SaveOnComp_btn.Name = "SaveOnComp_btn";
            this.SaveOnComp_btn.Size = new System.Drawing.Size(270, 36);
            this.SaveOnComp_btn.Text = "Компьютер";
            this.SaveOnComp_btn.Click += new System.EventHandler(this.SaveOnComp_btn_Click);
            // 
            // googleDriveToolStripMenuItem1
            // 
            this.googleDriveToolStripMenuItem1.Name = "googleDriveToolStripMenuItem1";
            this.googleDriveToolStripMenuItem1.Size = new System.Drawing.Size(270, 36);
            this.googleDriveToolStripMenuItem1.Text = "Google Drive";
            this.googleDriveToolStripMenuItem1.Click += new System.EventHandler(this.save_to_drive_btn_Click);
            // 
            // weigher_btn
            // 
            this.weigher_btn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.weigher_btn.Name = "weigher_btn";
            this.weigher_btn.Size = new System.Drawing.Size(136, 32);
            this.weigher_btn.Text = "Порт весов:";
            this.weigher_btn.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.weigher_btn_DropDownItemClicked);
            this.weigher_btn.Click += new System.EventHandler(this.weigher_btn_Click);
            // 
            // data_groupbox
            // 
            this.data_groupbox.Controls.Add(this.data_control);
            this.data_groupbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.data_groupbox.Location = new System.Drawing.Point(12, 39);
            this.data_groupbox.Name = "data_groupbox";
            this.data_groupbox.Size = new System.Drawing.Size(734, 458);
            this.data_groupbox.TabIndex = 1;
            this.data_groupbox.TabStop = false;
            this.data_groupbox.Text = "Данные эксперимента";
            // 
            // data_control
            // 
            this.data_control.Dock = System.Windows.Forms.DockStyle.Fill;
            this.data_control.Location = new System.Drawing.Point(3, 26);
            this.data_control.Name = "data_control";
            this.data_control.SelectedIndex = 0;
            this.data_control.Size = new System.Drawing.Size(728, 429);
            this.data_control.TabIndex = 0;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.richTextBox1.Location = new System.Drawing.Point(2948, 198);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(432, 236);
            this.richTextBox1.TabIndex = 13;
            this.richTextBox1.Text = "";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(2930, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(313, 25);
            this.label2.TabIndex = 14;
            this.label2.Text = "Комментарии по эксперименту";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button1.Location = new System.Drawing.Point(3794, 1461);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(182, 78);
            this.button1.TabIndex = 15;
            this.button1.Text = "Очитстить эксперимент";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // comments_txtbx
            // 
            this.comments_txtbx.Location = new System.Drawing.Point(900, 69);
            this.comments_txtbx.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comments_txtbx.Name = "comments_txtbx";
            this.comments_txtbx.Size = new System.Drawing.Size(391, 206);
            this.comments_txtbx.TabIndex = 16;
            this.comments_txtbx.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(895, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 25);
            this.label1.TabIndex = 17;
            this.label1.Text = "Комментарии к эксперименту";
            // 
            // clear_btn
            // 
            this.clear_btn.AutoEllipsis = true;
            this.clear_btn.Location = new System.Drawing.Point(1107, 402);
            this.clear_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.clear_btn.Name = "clear_btn";
            this.clear_btn.Size = new System.Drawing.Size(184, 86);
            this.clear_btn.TabIndex = 18;
            this.clear_btn.Text = "Очистить эксперимент";
            this.clear_btn.UseVisualStyleBackColor = true;
            // 
            // context_menu
            // 
            this.context_menu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.context_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.weigh_btn});
            this.context_menu.Name = "context_menu";
            this.context_menu.Size = new System.Drawing.Size(286, 36);
            // 
            // weigh_btn
            // 
            this.weigh_btn.Name = "weigh_btn";
            this.weigh_btn.Size = new System.Drawing.Size(285, 32);
            this.weigh_btn.Text = "Произвести взешивание";
            this.weigh_btn.Click += new System.EventHandler(this.weigh_btn_Click);
            // 
            // get_mass_btn
            // 
            this.get_mass_btn.Location = new System.Drawing.Point(764, 402);
            this.get_mass_btn.Name = "get_mass_btn";
            this.get_mass_btn.Size = new System.Drawing.Size(155, 86);
            this.get_mass_btn.TabIndex = 20;
            this.get_mass_btn.Text = "Получить массу";
            this.get_mass_btn.UseVisualStyleBackColor = true;
            this.get_mass_btn.Click += new System.EventHandler(this.get_mass_btn_Click);
            // 
            // CreateNewExperimentBtn
            // 
            this.CreateNewExperimentBtn.Name = "CreateNewExperimentBtn";
            this.CreateNewExperimentBtn.Size = new System.Drawing.Size(334, 36);
            this.CreateNewExperimentBtn.Text = "Шаблоны";
            this.CreateNewExperimentBtn.Click += new System.EventHandler(this.CreateNewExperimentBtn_Click);
            // 
            // UploadExperimentBtn
            // 
            this.UploadExperimentBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UploadExperimentComputerBtn,
            this.сОблачногоХранилищаToolStripMenuItem});
            this.UploadExperimentBtn.Name = "UploadExperimentBtn";
            this.UploadExperimentBtn.Size = new System.Drawing.Size(334, 36);
            this.UploadExperimentBtn.Text = "Загрузить эксперимент";
            // 
            // UploadExperimentComputerBtn
            // 
            this.UploadExperimentComputerBtn.Name = "UploadExperimentComputerBtn";
            this.UploadExperimentComputerBtn.Size = new System.Drawing.Size(340, 36);
            this.UploadExperimentComputerBtn.Text = "С компьютера";
            this.UploadExperimentComputerBtn.Click += new System.EventHandler(this.UploadExperimentComputerBtn_Click);
            // 
            // сОблачногоХранилищаToolStripMenuItem
            // 
            this.сОблачногоХранилищаToolStripMenuItem.Name = "сОблачногоХранилищаToolStripMenuItem";
            this.сОблачногоХранилищаToolStripMenuItem.Size = new System.Drawing.Size(340, 36);
            this.сОблачногоХранилищаToolStripMenuItem.Text = "С облачного хранилища";
            // 
            // SaveExperimentBtn
            // 
            this.SaveExperimentBtn.Name = "SaveExperimentBtn";
            this.SaveExperimentBtn.Size = new System.Drawing.Size(334, 36);
            this.SaveExperimentBtn.Text = "Сохранить эксперимент";
            this.SaveExperimentBtn.Visible = false;
            this.SaveExperimentBtn.Click += new System.EventHandler(this.SaveExperimentBtn_Click);
            // 
            // Jounral_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1304, 500);
            this.Controls.Add(this.get_mass_btn);
            this.Controls.Add(this.clear_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comments_txtbx);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.data_groupbox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Jounral_menu";
            this.Text = "Журнал. Серия:";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.data_groupbox.ResumeLayout(false);
            this.context_menu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.GroupBox data_groupbox;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem save_menubtn;
        private System.Windows.Forms.ToolStripMenuItem SaveOnComp_btn;
        private System.Windows.Forms.ToolStripMenuItem googleDriveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem experiment_btn;
        private System.Windows.Forms.TabControl data_control;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox comments_txtbx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clear_btn;
        private System.Windows.Forms.ContextMenuStrip context_menu;
        private System.Windows.Forms.Button get_mass_btn;
        private System.Windows.Forms.ToolStripMenuItem weigher_btn;
        private System.Windows.Forms.ToolStripMenuItem weigh_btn;
        private System.Windows.Forms.ToolStripMenuItem облачноеХранилищеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem googleDriveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem change_serie_menubtn;
        private System.Windows.Forms.ToolStripMenuItem CreateNewExperimentBtn;
        private System.Windows.Forms.ToolStripMenuItem UploadExperimentBtn;
        private System.Windows.Forms.ToolStripMenuItem UploadExperimentComputerBtn;
        private System.Windows.Forms.ToolStripMenuItem сОблачногоХранилищаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveExperimentBtn;
    }
}