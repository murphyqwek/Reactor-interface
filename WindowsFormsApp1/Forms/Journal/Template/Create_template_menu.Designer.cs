namespace Reactor_Interface.Forms.Template
{
    partial class Create_template_menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Create_template_menu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.save_menu_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.rename_page_menu_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.template_control = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.menuStrip1.SuspendLayout();
            this.template_control.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.save_menu_btn,
            this.rename_page_menu_btn});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(803, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // save_menu_btn
            // 
            this.save_menu_btn.Name = "save_menu_btn";
            this.save_menu_btn.Size = new System.Drawing.Size(182, 29);
            this.save_menu_btn.Text = "Сохранить шаблон";
            this.save_menu_btn.Click += new System.EventHandler(this.save_menu_btn_Click);
            // 
            // rename_page_menu_btn
            // 
            this.rename_page_menu_btn.Name = "rename_page_menu_btn";
            this.rename_page_menu_btn.Size = new System.Drawing.Size(238, 29);
            this.rename_page_menu_btn.Text = "Переименовать страницу";
            this.rename_page_menu_btn.Click += new System.EventHandler(this.rename_page_menu_btn_Click);
            // 
            // template_control
            // 
            this.template_control.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.template_control.Controls.Add(this.tabPage1);
            this.template_control.Location = new System.Drawing.Point(0, 36);
            this.template_control.Name = "template_control";
            this.template_control.SelectedIndex = 0;
            this.template_control.Size = new System.Drawing.Size(803, 378);
            this.template_control.TabIndex = 0;
            this.template_control.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.template_control_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(795, 345);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Основные данные";
            // 
            // Create_template_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(803, 414);
            this.Controls.Add(this.template_control);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Create_template_menu";
            this.Text = "Создание шаблонов";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Create_template_menu_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.template_control.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem save_menu_btn;
        private System.Windows.Forms.ToolStripMenuItem rename_page_menu_btn;
        private System.Windows.Forms.TabControl template_control;
        private System.Windows.Forms.TabPage tabPage1;
    }
}