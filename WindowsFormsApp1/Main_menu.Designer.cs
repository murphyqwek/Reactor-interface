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
            this.SerialPort = new System.IO.Ports.SerialPort(this.components);
            this.setting_groupbox = new System.Windows.Forms.GroupBox();
            this.cold_lbl = new System.Windows.Forms.Label();
            this.cold_bar = new System.Windows.Forms.TrackBar();
            this.fire_lbl = new System.Windows.Forms.Label();
            this.fire_bar = new System.Windows.Forms.TrackBar();
            this.iteration_label = new System.Windows.Forms.Label();
            this.iteration_counter = new System.Windows.Forms.NumericUpDown();
            this.time_syntes_lable = new System.Windows.Forms.Label();
            this.time_bar = new System.Windows.Forms.TrackBar();
            this.stop_btn = new System.Windows.Forms.Button();
            this.start_btn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.impulse_rdbtn = new System.Windows.Forms.RadioButton();
            this.duga_rdbtn = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.voilok_rdbtn = new System.Windows.Forms.RadioButton();
            this.tigel_rdbtn = new System.Windows.Forms.RadioButton();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.settings_menu_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.port_menu_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.speed_menu_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.commands_menu_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.debug_menu_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.graphic_menu_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.left_btn = new System.Windows.Forms.Button();
            this.down_btn = new System.Windows.Forms.Button();
            this.right_btn = new System.Windows.Forms.Button();
            this.up_btn = new System.Windows.Forms.Button();
            this.mode_groupbox = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.anod_move_lbl = new System.Windows.Forms.Label();
            this.state_lbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.port_checking = new System.Windows.Forms.Timer(this.components);
            this.setting_groupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cold_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fire_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iteration_counter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.time_bar)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.menu.SuspendLayout();
            this.mode_groupbox.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // SerialPort
            // 
            this.SerialPort.DiscardNull = true;
            this.SerialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort_DataReceived);
            // 
            // setting_groupbox
            // 
            this.setting_groupbox.Controls.Add(this.cold_lbl);
            this.setting_groupbox.Controls.Add(this.cold_bar);
            this.setting_groupbox.Controls.Add(this.fire_lbl);
            this.setting_groupbox.Controls.Add(this.fire_bar);
            this.setting_groupbox.Controls.Add(this.iteration_label);
            this.setting_groupbox.Controls.Add(this.iteration_counter);
            this.setting_groupbox.Controls.Add(this.time_syntes_lable);
            this.setting_groupbox.Controls.Add(this.time_bar);
            this.setting_groupbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.setting_groupbox.Location = new System.Drawing.Point(11, 275);
            this.setting_groupbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.setting_groupbox.Name = "setting_groupbox";
            this.setting_groupbox.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.setting_groupbox.Size = new System.Drawing.Size(711, 252);
            this.setting_groupbox.TabIndex = 1;
            this.setting_groupbox.TabStop = false;
            this.setting_groupbox.Text = "Настройки режима";
            // 
            // cold_lbl
            // 
            this.cold_lbl.AutoSize = true;
            this.cold_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cold_lbl.Location = new System.Drawing.Point(439, 153);
            this.cold_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cold_lbl.Name = "cold_lbl";
            this.cold_lbl.Size = new System.Drawing.Size(221, 25);
            this.cold_lbl.TabIndex = 7;
            this.cold_lbl.Text = "Время остывания: 1 с.";
            // 
            // cold_bar
            // 
            this.cold_bar.AllowDrop = true;
            this.cold_bar.Location = new System.Drawing.Point(444, 183);
            this.cold_bar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cold_bar.Maximum = 20;
            this.cold_bar.Minimum = 1;
            this.cold_bar.Name = "cold_bar";
            this.cold_bar.Size = new System.Drawing.Size(259, 69);
            this.cold_bar.TabIndex = 6;
            this.cold_bar.Value = 1;
            this.cold_bar.Scroll += new System.EventHandler(this.cold_bar_Scroll);
            // 
            // fire_lbl
            // 
            this.fire_lbl.AutoSize = true;
            this.fire_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fire_lbl.Location = new System.Drawing.Point(8, 153);
            this.fire_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fire_lbl.Name = "fire_lbl";
            this.fire_lbl.Size = new System.Drawing.Size(195, 25);
            this.fire_lbl.TabIndex = 5;
            this.fire_lbl.Text = "Время горения: 1 с.";
            // 
            // fire_bar
            // 
            this.fire_bar.AllowDrop = true;
            this.fire_bar.Location = new System.Drawing.Point(7, 183);
            this.fire_bar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fire_bar.Maximum = 20;
            this.fire_bar.Minimum = 1;
            this.fire_bar.Name = "fire_bar";
            this.fire_bar.Size = new System.Drawing.Size(259, 69);
            this.fire_bar.TabIndex = 4;
            this.fire_bar.Value = 1;
            this.fire_bar.Scroll += new System.EventHandler(this.fire_bar_Scroll);
            // 
            // iteration_label
            // 
            this.iteration_label.AutoSize = true;
            this.iteration_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.iteration_label.Location = new System.Drawing.Point(423, 59);
            this.iteration_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.iteration_label.Name = "iteration_label";
            this.iteration_label.Size = new System.Drawing.Size(277, 29);
            this.iteration_label.TabIndex = 3;
            this.iteration_label.Text = "Количество итераций:";
            this.iteration_label.Visible = false;
            // 
            // iteration_counter
            // 
            this.iteration_counter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.iteration_counter.Location = new System.Drawing.Point(626, 102);
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
            this.iteration_counter.Size = new System.Drawing.Size(75, 35);
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
            this.time_syntes_lable.AutoSize = true;
            this.time_syntes_lable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.time_syntes_lable.Location = new System.Drawing.Point(8, 59);
            this.time_syntes_lable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.time_syntes_lable.Name = "time_syntes_lable";
            this.time_syntes_lable.Size = new System.Drawing.Size(238, 29);
            this.time_syntes_lable.TabIndex = 1;
            this.time_syntes_lable.Text = "Время синтеза: 5 с.";
            // 
            // time_bar
            // 
            this.time_bar.AllowDrop = true;
            this.time_bar.Location = new System.Drawing.Point(8, 93);
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
            // stop_btn
            // 
            this.stop_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.stop_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.stop_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stop_btn.Location = new System.Drawing.Point(326, 593);
            this.stop_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.stop_btn.Name = "stop_btn";
            this.stop_btn.Size = new System.Drawing.Size(304, 160);
            this.stop_btn.TabIndex = 3;
            this.stop_btn.Text = "Стоп";
            this.stop_btn.UseVisualStyleBackColor = false;
            this.stop_btn.Click += new System.EventHandler(this.stop_btn_Click);
            // 
            // start_btn
            // 
            this.start_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.start_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.start_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.start_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.start_btn.Location = new System.Drawing.Point(12, 593);
            this.start_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(304, 160);
            this.start_btn.TabIndex = 4;
            this.start_btn.Text = "Старт";
            this.start_btn.UseVisualStyleBackColor = false;
            this.start_btn.Click += new System.EventHandler(this.start_btn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.impulse_rdbtn);
            this.groupBox2.Controls.Add(this.duga_rdbtn);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(9, 52);
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
            this.impulse_rdbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.impulse_rdbtn.Location = new System.Drawing.Point(9, 120);
            this.impulse_rdbtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.impulse_rdbtn.Name = "impulse_rdbtn";
            this.impulse_rdbtn.Size = new System.Drawing.Size(160, 37);
            this.impulse_rdbtn.TabIndex = 1;
            this.impulse_rdbtn.Text = "Импульс";
            this.impulse_rdbtn.UseVisualStyleBackColor = true;
            this.impulse_rdbtn.CheckedChanged += new System.EventHandler(this.impulse_rdbtn_CheckedChanged);
            // 
            // duga_rdbtn
            // 
            this.duga_rdbtn.AutoSize = true;
            this.duga_rdbtn.Checked = true;
            this.duga_rdbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.duga_rdbtn.Location = new System.Drawing.Point(9, 52);
            this.duga_rdbtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.duga_rdbtn.Name = "duga_rdbtn";
            this.duga_rdbtn.Size = new System.Drawing.Size(104, 37);
            this.duga_rdbtn.TabIndex = 0;
            this.duga_rdbtn.TabStop = true;
            this.duga_rdbtn.Text = "Дуга";
            this.duga_rdbtn.UseVisualStyleBackColor = true;
            this.duga_rdbtn.CheckedChanged += new System.EventHandler(this.duga_rdbtn_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.voilok_rdbtn);
            this.groupBox3.Controls.Add(this.tigel_rdbtn);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(453, 52);
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
            this.voilok_rdbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.voilok_rdbtn.Location = new System.Drawing.Point(106, 112);
            this.voilok_rdbtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.voilok_rdbtn.Name = "voilok_rdbtn";
            this.voilok_rdbtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.voilok_rdbtn.Size = new System.Drawing.Size(139, 37);
            this.voilok_rdbtn.TabIndex = 2;
            this.voilok_rdbtn.Text = "Войлок";
            this.voilok_rdbtn.UseVisualStyleBackColor = true;
            // 
            // tigel_rdbtn
            // 
            this.tigel_rdbtn.AutoSize = true;
            this.tigel_rdbtn.Checked = true;
            this.tigel_rdbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tigel_rdbtn.Location = new System.Drawing.Point(110, 52);
            this.tigel_rdbtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tigel_rdbtn.Name = "tigel_rdbtn";
            this.tigel_rdbtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tigel_rdbtn.Size = new System.Drawing.Size(133, 37);
            this.tigel_rdbtn.TabIndex = 1;
            this.tigel_rdbtn.TabStop = true;
            this.tigel_rdbtn.Text = "Тигель";
            this.tigel_rdbtn.UseVisualStyleBackColor = true;
            this.tigel_rdbtn.CheckedChanged += new System.EventHandler(this.tigel_rdbtn_CheckedChanged);
            // 
            // menu
            // 
            this.menu.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settings_menu_btn,
            this.debug_menu_btn,
            this.graphic_menu_btn});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1664, 40);
            this.menu.TabIndex = 7;
            this.menu.Text = "menu";
            // 
            // settings_menu_btn
            // 
            this.settings_menu_btn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.port_menu_btn,
            this.speed_menu_btn,
            this.commands_menu_btn});
            this.settings_menu_btn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.settings_menu_btn.Name = "settings_menu_btn";
            this.settings_menu_btn.Size = new System.Drawing.Size(148, 36);
            this.settings_menu_btn.Text = "Настройки";
            this.settings_menu_btn.DropDownOpened += new System.EventHandler(this.settings_menu_btn_DropDownOpened);
            // 
            // port_menu_btn
            // 
            this.port_menu_btn.Name = "port_menu_btn";
            this.port_menu_btn.Size = new System.Drawing.Size(291, 40);
            this.port_menu_btn.Text = "Порт:";
            this.port_menu_btn.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.port_menu_btn_DropDownItemClicked);
            // 
            // speed_menu_btn
            // 
            this.speed_menu_btn.Name = "speed_menu_btn";
            this.speed_menu_btn.Size = new System.Drawing.Size(291, 40);
            this.speed_menu_btn.Text = "Скорость: ";
            this.speed_menu_btn.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.speed_menu_btn_DropDownItemClicked);
            // 
            // commands_menu_btn
            // 
            this.commands_menu_btn.Name = "commands_menu_btn";
            this.commands_menu_btn.Size = new System.Drawing.Size(291, 40);
            this.commands_menu_btn.Text = "Формат команд";
            this.commands_menu_btn.Click += new System.EventHandler(this.commands_menu_btn_Click);
            // 
            // debug_menu_btn
            // 
            this.debug_menu_btn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.debug_menu_btn.Name = "debug_menu_btn";
            this.debug_menu_btn.Size = new System.Drawing.Size(95, 36);
            this.debug_menu_btn.Text = "Дебаг";
            this.debug_menu_btn.Visible = false;
            this.debug_menu_btn.Click += new System.EventHandler(this.debug_menu_btn_Click);
            // 
            // graphic_menu_btn
            // 
            this.graphic_menu_btn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.graphic_menu_btn.Name = "graphic_menu_btn";
            this.graphic_menu_btn.Size = new System.Drawing.Size(109, 36);
            this.graphic_menu_btn.Text = "График";
            this.graphic_menu_btn.Click += new System.EventHandler(this.graphic_menu_btn_Click);
            // 
            // left_btn
            // 
            this.left_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.left_btn.BackColor = System.Drawing.Color.Silver;
            this.left_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.left_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.left_btn.Location = new System.Drawing.Point(1083, 640);
            this.left_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.left_btn.Name = "left_btn";
            this.left_btn.Size = new System.Drawing.Size(182, 112);
            this.left_btn.TabIndex = 8;
            this.left_btn.Text = "<";
            this.left_btn.UseVisualStyleBackColor = false;
            this.left_btn.Click += new System.EventHandler(this.button3_Click);
            // 
            // down_btn
            // 
            this.down_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.down_btn.BackColor = System.Drawing.Color.Silver;
            this.down_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.down_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.down_btn.Location = new System.Drawing.Point(1274, 640);
            this.down_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.down_btn.Name = "down_btn";
            this.down_btn.Size = new System.Drawing.Size(182, 112);
            this.down_btn.TabIndex = 12;
            this.down_btn.Text = "˅";
            this.down_btn.UseVisualStyleBackColor = false;
            // 
            // right_btn
            // 
            this.right_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.right_btn.BackColor = System.Drawing.Color.Silver;
            this.right_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.right_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.right_btn.Location = new System.Drawing.Point(1464, 640);
            this.right_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.right_btn.Name = "right_btn";
            this.right_btn.Size = new System.Drawing.Size(182, 112);
            this.right_btn.TabIndex = 13;
            this.right_btn.Text = ">";
            this.right_btn.UseVisualStyleBackColor = false;
            // 
            // up_btn
            // 
            this.up_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.up_btn.BackColor = System.Drawing.Color.Silver;
            this.up_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.up_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.up_btn.Location = new System.Drawing.Point(1274, 519);
            this.up_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.up_btn.Name = "up_btn";
            this.up_btn.Size = new System.Drawing.Size(182, 112);
            this.up_btn.TabIndex = 14;
            this.up_btn.Text = "˄";
            this.up_btn.UseVisualStyleBackColor = false;
            // 
            // mode_groupbox
            // 
            this.mode_groupbox.BackColor = System.Drawing.SystemColors.Control;
            this.mode_groupbox.Controls.Add(this.groupBox2);
            this.mode_groupbox.Controls.Add(this.groupBox3);
            this.mode_groupbox.Controls.Add(this.setting_groupbox);
            this.mode_groupbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mode_groupbox.Location = new System.Drawing.Point(12, 46);
            this.mode_groupbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mode_groupbox.Name = "mode_groupbox";
            this.mode_groupbox.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mode_groupbox.Size = new System.Drawing.Size(730, 537);
            this.mode_groupbox.TabIndex = 15;
            this.mode_groupbox.TabStop = false;
            this.mode_groupbox.Text = "Запуск реактора";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox5.Controls.Add(this.anod_move_lbl);
            this.groupBox5.Controls.Add(this.state_lbl);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox5.Location = new System.Drawing.Point(1028, 66);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox5.Size = new System.Drawing.Size(635, 321);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Информация о реакторе";
            // 
            // anod_move_lbl
            // 
            this.anod_move_lbl.AutoSize = true;
            this.anod_move_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.anod_move_lbl.Location = new System.Drawing.Point(15, 229);
            this.anod_move_lbl.Name = "anod_move_lbl";
            this.anod_move_lbl.Size = new System.Drawing.Size(453, 37);
            this.anod_move_lbl.TabIndex = 2;
            this.anod_move_lbl.Text = "Направление движение анода:";
            // 
            // state_lbl
            // 
            this.state_lbl.AutoSize = true;
            this.state_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.state_lbl.ForeColor = System.Drawing.Color.Red;
            this.state_lbl.Location = new System.Drawing.Point(199, 84);
            this.state_lbl.Name = "state_lbl";
            this.state_lbl.Size = new System.Drawing.Size(198, 37);
            this.state_lbl.TabIndex = 1;
            this.state_lbl.Text = "Не работает";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(15, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Состояние:";
            // 
            // port_checking
            // 
            this.port_checking.Tick += new System.EventHandler(this.port_checking_Tick);
            // 
            // Main_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1664, 771);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.mode_groupbox);
            this.Controls.Add(this.up_btn);
            this.Controls.Add(this.right_btn);
            this.Controls.Add(this.down_btn);
            this.Controls.Add(this.left_btn);
            this.Controls.Add(this.start_btn);
            this.Controls.Add(this.stop_btn);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Main_menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Интерфейс реактора";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_menu_FormClosing);
            this.setting_groupbox.ResumeLayout(false);
            this.setting_groupbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cold_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fire_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iteration_counter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.time_bar)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.mode_groupbox.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort SerialPort;
        private System.Windows.Forms.GroupBox setting_groupbox;
        private System.Windows.Forms.TrackBar time_bar;
        private System.Windows.Forms.Label time_syntes_lable;
        private System.Windows.Forms.Button stop_btn;
        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton impulse_rdbtn;
        private System.Windows.Forms.RadioButton duga_rdbtn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton voilok_rdbtn;
        private System.Windows.Forms.RadioButton tigel_rdbtn;
        private System.Windows.Forms.Label iteration_label;
        private System.Windows.Forms.NumericUpDown iteration_counter;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem settings_menu_btn;
        private System.Windows.Forms.ToolStripMenuItem port_menu_btn;
        private System.Windows.Forms.ToolStripMenuItem speed_menu_btn;
        private System.Windows.Forms.ToolStripMenuItem debug_menu_btn;
        private System.Windows.Forms.Button left_btn;
        private System.Windows.Forms.Button down_btn;
        private System.Windows.Forms.Button right_btn;
        private System.Windows.Forms.Button up_btn;
        private System.Windows.Forms.GroupBox mode_groupbox;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ToolStripMenuItem commands_menu_btn;
        private System.Windows.Forms.ToolStripMenuItem graphic_menu_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label state_lbl;
        private System.Windows.Forms.Timer port_checking;
        private System.Windows.Forms.Label anod_move_lbl;
        private System.Windows.Forms.TrackBar fire_bar;
        private System.Windows.Forms.Label fire_lbl;
        private System.Windows.Forms.Label cold_lbl;
        private System.Windows.Forms.TrackBar cold_bar;
    }
}

