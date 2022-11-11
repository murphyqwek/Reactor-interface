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
            this.port_menu_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.speed_menu_btn = new System.Windows.Forms.ToolStripMenuItem();
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
            this.groupBox1.Location = new System.Drawing.Point(802, 49);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(711, 180);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки режима";
            // 
            // iteration_label
            // 
            this.iteration_label.AutoSize = true;
            this.iteration_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.iteration_label.Location = new System.Drawing.Point(388, 54);
            this.iteration_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.iteration_label.Name = "iteration_label";
            this.iteration_label.Size = new System.Drawing.Size(315, 33);
            this.iteration_label.TabIndex = 3;
            this.iteration_label.Text = "Количество итераций:";
            this.iteration_label.Visible = false;
            // 
            // iteration_counter
            // 
            this.iteration_counter.Location = new System.Drawing.Point(626, 95);
            this.iteration_counter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
            this.iteration_counter.Size = new System.Drawing.Size(75, 48);
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
            this.time_syntes_lable.Location = new System.Drawing.Point(9, 68);
            this.time_syntes_lable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.time_syntes_lable.Name = "time_syntes_lable";
            this.time_syntes_lable.Size = new System.Drawing.Size(281, 33);
            this.time_syntes_lable.TabIndex = 1;
            this.time_syntes_lable.Text = "Время синтеза: 5 с.";
            // 
            // time_bar
            // 
            this.time_bar.AllowDrop = true;
            this.time_bar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.time_bar.Location = new System.Drawing.Point(9, 102);
            this.time_bar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.time_bar.Maximum = 60;
            this.time_bar.Minimum = 5;
            this.time_bar.Name = "time_bar";
            this.time_bar.Size = new System.Drawing.Size(692, 69);
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
            this.button1.Location = new System.Drawing.Point(326, 312);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(304, 160);
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
            this.button2.Location = new System.Drawing.Point(12, 312);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(304, 160);
            this.button2.TabIndex = 4;
            this.button2.Text = "Старт";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.impulse_rdbtn);
            this.groupBox2.Controls.Add(this.duga_rdbtn);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(21, 49);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(250, 180);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Режим";
            // 
            // impulse_rdbtn
            // 
            this.impulse_rdbtn.AutoSize = true;
            this.impulse_rdbtn.Location = new System.Drawing.Point(9, 120);
            this.impulse_rdbtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.impulse_rdbtn.Name = "impulse_rdbtn";
            this.impulse_rdbtn.Size = new System.Drawing.Size(165, 41);
            this.impulse_rdbtn.TabIndex = 1;
            this.impulse_rdbtn.Text = "Импульс";
            this.impulse_rdbtn.UseVisualStyleBackColor = true;
            this.impulse_rdbtn.CheckedChanged += new System.EventHandler(this.impulse_rdbtn_CheckedChanged);
            // 
            // duga_rdbtn
            // 
            this.duga_rdbtn.AutoSize = true;
            this.duga_rdbtn.Checked = true;
            this.duga_rdbtn.Location = new System.Drawing.Point(9, 52);
            this.duga_rdbtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.duga_rdbtn.Name = "duga_rdbtn";
            this.duga_rdbtn.Size = new System.Drawing.Size(108, 41);
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
            this.groupBox3.Location = new System.Drawing.Point(280, 49);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(256, 180);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Конфигурация";
            // 
            // voilok_rdbtn
            // 
            this.voilok_rdbtn.AutoSize = true;
            this.voilok_rdbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.voilok_rdbtn.Location = new System.Drawing.Point(9, 120);
            this.voilok_rdbtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.voilok_rdbtn.Name = "voilok_rdbtn";
            this.voilok_rdbtn.Size = new System.Drawing.Size(165, 44);
            this.voilok_rdbtn.TabIndex = 2;
            this.voilok_rdbtn.Text = "Войлок";
            this.voilok_rdbtn.UseVisualStyleBackColor = true;
            // 
            // tigel_rdbtn
            // 
            this.tigel_rdbtn.AutoSize = true;
            this.tigel_rdbtn.Checked = true;
            this.tigel_rdbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tigel_rdbtn.Location = new System.Drawing.Point(9, 46);
            this.tigel_rdbtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tigel_rdbtn.Name = "tigel_rdbtn";
            this.tigel_rdbtn.Size = new System.Drawing.Size(158, 44);
            this.tigel_rdbtn.TabIndex = 1;
            this.tigel_rdbtn.TabStop = true;
            this.tigel_rdbtn.Text = "Тигель";
            this.tigel_rdbtn.UseVisualStyleBackColor = true;
            this.tigel_rdbtn.CheckedChanged += new System.EventHandler(this.tigel_rdbtn_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settings_menu_btn,
            this.дебагToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1532, 42);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settings_menu_btn
            // 
            this.settings_menu_btn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.port_menu_btn,
            this.speed_menu_btn});
            this.settings_menu_btn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.settings_menu_btn.Name = "settings_menu_btn";
            this.settings_menu_btn.Size = new System.Drawing.Size(148, 36);
            this.settings_menu_btn.Text = "Настройки";
            // 
            // port_menu_btn
            // 
            this.port_menu_btn.Name = "port_menu_btn";
            this.port_menu_btn.Size = new System.Drawing.Size(270, 40);
            this.port_menu_btn.Text = "Порт:";
            // 
            // speed_menu_btn
            // 
            this.speed_menu_btn.Name = "speed_menu_btn";
            this.speed_menu_btn.Size = new System.Drawing.Size(270, 40);
            this.speed_menu_btn.Text = "Скорость: ";
            // 
            // дебагToolStripMenuItem
            // 
            this.дебагToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.дебагToolStripMenuItem.Name = "дебагToolStripMenuItem";
            this.дебагToolStripMenuItem.Size = new System.Drawing.Size(95, 36);
            this.дебагToolStripMenuItem.Text = "Дебаг";
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.Color.Silver;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(951, 360);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(182, 112);
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
            this.button7.Location = new System.Drawing.Point(1142, 360);
            this.button7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(182, 112);
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
            this.button4.Location = new System.Drawing.Point(1332, 360);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(182, 112);
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
            this.button5.Location = new System.Drawing.Point(1142, 238);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(182, 112);
            this.button5.TabIndex = 14;
            this.button5.Text = "˄";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // Main_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1532, 491);
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
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
        private System.Windows.Forms.ToolStripMenuItem port_menu_btn;
        private System.Windows.Forms.ToolStripMenuItem speed_menu_btn;
        private System.Windows.Forms.ToolStripMenuItem дебагToolStripMenuItem;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}

