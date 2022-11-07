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
            this.iteration_label = new System.Windows.Forms.Label();
            this.iteration_counter = new System.Windows.Forms.NumericUpDown();
            this.time_syntes_lable = new System.Windows.Forms.Label();
            this.time_bar = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.impulse_rdbtn = new System.Windows.Forms.RadioButton();
            this.duga_rdbtn = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.voilok_rdbtn = new System.Windows.Forms.RadioButton();
            this.tigel_rdbtn = new System.Windows.Forms.RadioButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settings_menu_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.портToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.скоростьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.дебагToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button3 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iteration_counter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.time_bar)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.iteration_label);
            this.groupBox1.Controls.Add(this.iteration_counter);
            this.groupBox1.Controls.Add(this.time_syntes_lable);
            this.groupBox1.Controls.Add(this.time_bar);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(535, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(474, 117);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки режима";
            // 
            // iteration_label
            // 
            this.iteration_label.AutoSize = true;
            this.iteration_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.iteration_label.Location = new System.Drawing.Point(259, 35);
            this.iteration_label.Name = "iteration_label";
            this.iteration_label.Size = new System.Drawing.Size(213, 24);
            this.iteration_label.TabIndex = 3;
            this.iteration_label.Text = "Количество итераций:";
            this.iteration_label.Visible = false;
            // 
            // iteration_counter
            // 
            this.iteration_counter.Location = new System.Drawing.Point(417, 62);
            this.iteration_counter.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.iteration_counter.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.iteration_counter.Name = "iteration_counter";
            this.iteration_counter.Size = new System.Drawing.Size(50, 35);
            this.iteration_counter.TabIndex = 2;
            this.iteration_counter.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.iteration_counter.Visible = false;
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
            // time_bar
            // 
            this.time_bar.AllowDrop = true;
            this.time_bar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.time_bar.Location = new System.Drawing.Point(6, 66);
            this.time_bar.Maximum = 60;
            this.time_bar.Minimum = 5;
            this.time_bar.Name = "time_bar";
            this.time_bar.Size = new System.Drawing.Size(461, 45);
            this.time_bar.SmallChange = 5;
            this.time_bar.TabIndex = 0;
            this.time_bar.Value = 5;
            this.time_bar.Scroll += new System.EventHandler(this.time_syntes_bar_Scroll);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(217, 203);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(203, 104);
            this.button1.TabIndex = 3;
            this.button1.Text = "Стоп";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(8, 203);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(203, 104);
            this.button2.TabIndex = 4;
            this.button2.Text = "Старт";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.impulse_rdbtn);
            this.groupBox2.Controls.Add(this.duga_rdbtn);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(14, 32);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(167, 117);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Режим";
            // 
            // impulse_rdbtn
            // 
            this.impulse_rdbtn.AutoSize = true;
            this.impulse_rdbtn.Location = new System.Drawing.Point(6, 78);
            this.impulse_rdbtn.Name = "impulse_rdbtn";
            this.impulse_rdbtn.Size = new System.Drawing.Size(117, 29);
            this.impulse_rdbtn.TabIndex = 1;
            this.impulse_rdbtn.Text = "Импульс";
            this.impulse_rdbtn.UseVisualStyleBackColor = true;
            this.impulse_rdbtn.CheckedChanged += new System.EventHandler(this.impulse_rdbtn_CheckedChanged);
            // 
            // duga_rdbtn
            // 
            this.duga_rdbtn.AutoSize = true;
            this.duga_rdbtn.Checked = true;
            this.duga_rdbtn.Location = new System.Drawing.Point(6, 34);
            this.duga_rdbtn.Name = "duga_rdbtn";
            this.duga_rdbtn.Size = new System.Drawing.Size(77, 29);
            this.duga_rdbtn.TabIndex = 0;
            this.duga_rdbtn.TabStop = true;
            this.duga_rdbtn.Text = "Дуга";
            this.duga_rdbtn.UseVisualStyleBackColor = true;
            this.duga_rdbtn.CheckedChanged += new System.EventHandler(this.duga_rdbtn_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.voilok_rdbtn);
            this.groupBox3.Controls.Add(this.tigel_rdbtn);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(187, 32);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(171, 117);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Конфигурация";
            // 
            // voilok_rdbtn
            // 
            this.voilok_rdbtn.AutoSize = true;
            this.voilok_rdbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.voilok_rdbtn.Location = new System.Drawing.Point(6, 78);
            this.voilok_rdbtn.Name = "voilok_rdbtn";
            this.voilok_rdbtn.Size = new System.Drawing.Size(117, 33);
            this.voilok_rdbtn.TabIndex = 2;
            this.voilok_rdbtn.Text = "Войлок";
            this.voilok_rdbtn.UseVisualStyleBackColor = true;
            // 
            // tigel_rdbtn
            // 
            this.tigel_rdbtn.AutoSize = true;
            this.tigel_rdbtn.Checked = true;
            this.tigel_rdbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tigel_rdbtn.Location = new System.Drawing.Point(6, 30);
            this.tigel_rdbtn.Name = "tigel_rdbtn";
            this.tigel_rdbtn.Size = new System.Drawing.Size(115, 33);
            this.tigel_rdbtn.TabIndex = 1;
            this.tigel_rdbtn.TabStop = true;
            this.tigel_rdbtn.Text = "Тигель";
            this.tigel_rdbtn.UseVisualStyleBackColor = true;
            this.tigel_rdbtn.CheckedChanged += new System.EventHandler(this.tigel_rdbtn_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settings_menu_btn,
            this.дебагToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1021, 29);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settings_menu_btn
            // 
            this.settings_menu_btn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.портToolStripMenuItem,
            this.скоростьToolStripMenuItem});
            this.settings_menu_btn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.settings_menu_btn.Name = "settings_menu_btn";
            this.settings_menu_btn.Size = new System.Drawing.Size(99, 25);
            this.settings_menu_btn.Text = "Настройки";
            // 
            // портToolStripMenuItem
            // 
            this.портToolStripMenuItem.Name = "портToolStripMenuItem";
            this.портToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.портToolStripMenuItem.Text = "Порт:";
            // 
            // скоростьToolStripMenuItem
            // 
            this.скоростьToolStripMenuItem.Name = "скоростьToolStripMenuItem";
            this.скоростьToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.скоростьToolStripMenuItem.Text = "Скорость: ";
            // 
            // дебагToolStripMenuItem
            // 
            this.дебагToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.дебагToolStripMenuItem.Name = "дебагToolStripMenuItem";
            this.дебагToolStripMenuItem.Size = new System.Drawing.Size(64, 25);
            this.дебагToolStripMenuItem.Text = "Дебаг";
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.Color.Silver;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(634, 234);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(121, 73);
            this.button3.TabIndex = 8;
            this.button3.Text = "<";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button7.BackColor = System.Drawing.Color.Silver;
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button7.Location = new System.Drawing.Point(761, 234);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(121, 73);
            this.button7.TabIndex = 12;
            this.button7.Text = "˅";
            this.button7.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackColor = System.Drawing.Color.Silver;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(888, 234);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(121, 73);
            this.button4.TabIndex = 13;
            this.button4.Text = ">";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.BackColor = System.Drawing.Color.Silver;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(761, 155);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(121, 73);
            this.button5.TabIndex = 14;
            this.button5.Text = "˄";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // Main_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 319);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main_menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Интерфейс реактора";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iteration_counter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.time_bar)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TrackBar time_bar;
        private System.Windows.Forms.Label time_syntes_lable;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton impulse_rdbtn;
        private System.Windows.Forms.RadioButton duga_rdbtn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton voilok_rdbtn;
        private System.Windows.Forms.RadioButton tigel_rdbtn;
        private System.Windows.Forms.Label iteration_label;
        private System.Windows.Forms.NumericUpDown iteration_counter;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settings_menu_btn;
        private System.Windows.Forms.ToolStripMenuItem портToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem скоростьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem дебагToolStripMenuItem;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}

