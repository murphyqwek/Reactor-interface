namespace Reactor_Interface
{
    partial class Experiment_menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Experiment_menu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.template_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.change_serie_menubtn = new System.Windows.Forms.ToolStripMenuItem();
            this.googleDriveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.save_menubtn = new System.Windows.Forms.ToolStripMenuItem();
            this.компьютерToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.googleDriveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.data_groupbox = new System.Windows.Forms.GroupBox();
            this.data_control = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.data_groupbox.SuspendLayout();
            this.data_control.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.template_btn,
            this.change_serie_menubtn,
            this.googleDriveToolStripMenuItem,
            this.save_menubtn});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1419, 36);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // template_btn
            // 
            this.template_btn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.template_btn.Name = "template_btn";
            this.template_btn.Size = new System.Drawing.Size(108, 32);
            this.template_btn.Text = "Шаблон:";
            this.template_btn.Click += new System.EventHandler(this.template_btn_Click);
            // 
            // change_serie_menubtn
            // 
            this.change_serie_menubtn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.change_serie_menubtn.Name = "change_serie_menubtn";
            this.change_serie_menubtn.Size = new System.Drawing.Size(173, 32);
            this.change_serie_menubtn.Text = "Выбрать серию:";
            this.change_serie_menubtn.Click += new System.EventHandler(this.change_serie_menubtn_Click);
            // 
            // googleDriveToolStripMenuItem
            // 
            this.googleDriveToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.googleDriveToolStripMenuItem.Name = "googleDriveToolStripMenuItem";
            this.googleDriveToolStripMenuItem.Size = new System.Drawing.Size(148, 32);
            this.googleDriveToolStripMenuItem.Text = "Google Drive:";
            this.googleDriveToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.googleDriveToolStripMenuItem_DropDownItemClicked);
            // 
            // save_menubtn
            // 
            this.save_menubtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.save_menubtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.компьютерToolStripMenuItem,
            this.googleDriveToolStripMenuItem1});
            this.save_menubtn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.save_menubtn.Name = "save_menubtn";
            this.save_menubtn.Size = new System.Drawing.Size(279, 32);
            this.save_menubtn.Text = "Сохранить эксперимент на:";
            // 
            // компьютерToolStripMenuItem
            // 
            this.компьютерToolStripMenuItem.Name = "компьютерToolStripMenuItem";
            this.компьютерToolStripMenuItem.Size = new System.Drawing.Size(230, 36);
            this.компьютерToolStripMenuItem.Text = "Компьютер";
            // 
            // googleDriveToolStripMenuItem1
            // 
            this.googleDriveToolStripMenuItem1.Name = "googleDriveToolStripMenuItem1";
            this.googleDriveToolStripMenuItem1.Size = new System.Drawing.Size(230, 36);
            this.googleDriveToolStripMenuItem1.Text = "Google Drive";
            this.googleDriveToolStripMenuItem1.Click += new System.EventHandler(this.save_to_drive_btn_Click);
            // 
            // data_groupbox
            // 
            this.data_groupbox.Controls.Add(this.data_control);
            this.data_groupbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.data_groupbox.Location = new System.Drawing.Point(12, 50);
            this.data_groupbox.Name = "data_groupbox";
            this.data_groupbox.Size = new System.Drawing.Size(755, 490);
            this.data_groupbox.TabIndex = 1;
            this.data_groupbox.TabStop = false;
            this.data_groupbox.Text = "Данные эксперимента";
            // 
            // data_control
            // 
            this.data_control.Controls.Add(this.tabPage1);
            this.data_control.Location = new System.Drawing.Point(7, 28);
            this.data_control.Name = "data_control";
            this.data_control.SelectedIndex = 0;
            this.data_control.Size = new System.Drawing.Size(742, 456);
            this.data_control.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(734, 418);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(975, 78);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(432, 237);
            this.richTextBox1.TabIndex = 13;
            this.richTextBox1.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(970, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(313, 25);
            this.label2.TabIndex = 14;
            this.label2.Text = "Комментарии по эксперименту";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1226, 452);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(181, 78);
            this.button1.TabIndex = 15;
            this.button1.Text = "Очитстить эксперимент";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Experiment_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1419, 550);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.data_groupbox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Experiment_menu";
            this.Text = "Эксперимент. Серия:";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.data_groupbox.ResumeLayout(false);
            this.data_control.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem googleDriveToolStripMenuItem;
        private System.Windows.Forms.GroupBox data_groupbox;
        private System.Windows.Forms.ToolStripMenuItem change_serie_menubtn;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem save_menubtn;
        private System.Windows.Forms.ToolStripMenuItem компьютерToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem googleDriveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem template_btn;
        private System.Windows.Forms.TabControl data_control;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button1;
    }
}