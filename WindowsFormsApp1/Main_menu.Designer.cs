namespace WindowsFormsApp1
{
    partial class Main_menu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_menu));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.time_syntes_lable = new System.Windows.Forms.Label();
            this.time_syntes_bar = new System.Windows.Forms.TrackBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settings_menubtn = new System.Windows.Forms.ToolStripMenuItem();
            this.com_menubtn = new System.Windows.Forms.ToolStripMenuItem();
            this.speed_menubtn = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.impules_checkbox = new System.Windows.Forms.CheckBox();
            this.duga_checkbox = new System.Windows.Forms.CheckBox();
            this.tigel_checkbox = new System.Windows.Forms.CheckBox();
            this.voilok_checkbox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.time_syntes_bar)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.time_syntes_lable);
            this.groupBox1.Controls.Add(this.time_syntes_bar);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 199);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(365, 117);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки режима";
            // 
            // time_syntes_lable
            // 
            this.time_syntes_lable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.time_syntes_lable.AutoSize = true;
            this.time_syntes_lable.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.time_syntes_lable.Location = new System.Drawing.Point(6, 44);
            this.time_syntes_lable.Name = "time_syntes_lable";
            this.time_syntes_lable.Size = new System.Drawing.Size(185, 24);
            this.time_syntes_lable.TabIndex = 1;
            this.time_syntes_lable.Text = "Время синтеза: 5 с.";
            // 
            // time_syntes_bar
            // 
            this.time_syntes_bar.AllowDrop = true;
            this.time_syntes_bar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.time_syntes_bar.Location = new System.Drawing.Point(6, 71);
            this.time_syntes_bar.Maximum = 60;
            this.time_syntes_bar.Minimum = 5;
            this.time_syntes_bar.Name = "time_syntes_bar";
            this.time_syntes_bar.Size = new System.Drawing.Size(259, 45);
            this.time_syntes_bar.SmallChange = 5;
            this.time_syntes_bar.TabIndex = 0;
            this.time_syntes_bar.Value = 5;
            this.time_syntes_bar.Scroll += new System.EventHandler(this.time_syntes_bar_Scroll);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settings_menubtn});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(850, 29);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settings_menubtn
            // 
            this.settings_menubtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.com_menubtn,
            this.speed_menubtn});
            this.settings_menubtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.settings_menubtn.Name = "settings_menubtn";
            this.settings_menubtn.Size = new System.Drawing.Size(99, 25);
            this.settings_menubtn.Text = "Настройки";
            // 
            // com_menubtn
            // 
            this.com_menubtn.Name = "com_menubtn";
            this.com_menubtn.Size = new System.Drawing.Size(180, 26);
            this.com_menubtn.Text = "Порт:        ";
            // 
            // speed_menubtn
            // 
            this.speed_menubtn.Name = "speed_menubtn";
            this.speed_menubtn.Size = new System.Drawing.Size(180, 26);
            this.speed_menubtn.Text = "Скорость:";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(635, 205);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(203, 104);
            this.button1.TabIndex = 3;
            this.button1.Text = "Стоп";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(426, 205);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(203, 104);
            this.button2.TabIndex = 4;
            this.button2.Text = "Старт";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.splitContainer1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(12, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(365, 164);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Режимы работы";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 31);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.impules_checkbox);
            this.splitContainer1.Panel1.Controls.Add(this.duga_checkbox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tigel_checkbox);
            this.splitContainer1.Panel2.Controls.Add(this.voilok_checkbox);
            this.splitContainer1.Size = new System.Drawing.Size(359, 130);
            this.splitContainer1.SplitterDistance = 168;
            this.splitContainer1.TabIndex = 0;
            // 
            // impules_checkbox
            // 
            this.impules_checkbox.AutoSize = true;
            this.impules_checkbox.Location = new System.Drawing.Point(7, 85);
            this.impules_checkbox.Name = "impules_checkbox";
            this.impules_checkbox.Size = new System.Drawing.Size(134, 33);
            this.impules_checkbox.TabIndex = 1;
            this.impules_checkbox.Text = "Импульс";
            this.impules_checkbox.UseVisualStyleBackColor = true;
            // 
            // duga_checkbox
            // 
            this.duga_checkbox.AutoSize = true;
            this.duga_checkbox.Checked = true;
            this.duga_checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.duga_checkbox.Location = new System.Drawing.Point(7, 20);
            this.duga_checkbox.Name = "duga_checkbox";
            this.duga_checkbox.Size = new System.Drawing.Size(83, 33);
            this.duga_checkbox.TabIndex = 0;
            this.duga_checkbox.Text = "Дуга";
            this.duga_checkbox.UseVisualStyleBackColor = true;
            // 
            // tigel_checkbox
            // 
            this.tigel_checkbox.AutoSize = true;
            this.tigel_checkbox.Checked = true;
            this.tigel_checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tigel_checkbox.Location = new System.Drawing.Point(66, 85);
            this.tigel_checkbox.Name = "tigel_checkbox";
            this.tigel_checkbox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tigel_checkbox.Size = new System.Drawing.Size(116, 33);
            this.tigel_checkbox.TabIndex = 2;
            this.tigel_checkbox.Text = "Тигель";
            this.tigel_checkbox.UseVisualStyleBackColor = true;
            // 
            // voilok_checkbox
            // 
            this.voilok_checkbox.AutoSize = true;
            this.voilok_checkbox.Location = new System.Drawing.Point(66, 20);
            this.voilok_checkbox.Name = "voilok_checkbox";
            this.voilok_checkbox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.voilok_checkbox.Size = new System.Drawing.Size(118, 33);
            this.voilok_checkbox.TabIndex = 1;
            this.voilok_checkbox.Text = "Войлок";
            this.voilok_checkbox.UseVisualStyleBackColor = true;
            // 
            // Main_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 328);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(866, 367);
            this.MinimumSize = new System.Drawing.Size(866, 367);
            this.Name = "Main_menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Интерфейс реактора";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.time_syntes_bar)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settings_menubtn;
        private System.Windows.Forms.ToolStripMenuItem com_menubtn;
        private System.Windows.Forms.ToolStripMenuItem speed_menubtn;
        private System.Windows.Forms.TrackBar time_syntes_bar;
        private System.Windows.Forms.Label time_syntes_lable;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox impules_checkbox;
        private System.Windows.Forms.CheckBox duga_checkbox;
        private System.Windows.Forms.CheckBox tigel_checkbox;
        private System.Windows.Forms.CheckBox voilok_checkbox;
    }
}

