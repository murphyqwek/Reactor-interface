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
            this.mode_settings_box = new System.Windows.Forms.GroupBox();
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
            this.mode_box = new System.Windows.Forms.GroupBox();
            this.impulse_rdbtn = new System.Windows.Forms.RadioButton();
            this.duga_rdbtn = new System.Windows.Forms.RadioButton();
            this.conf_box = new System.Windows.Forms.GroupBox();
            this.voilok_rdbtn = new System.Windows.Forms.RadioButton();
            this.tigel_rdbtn = new System.Windows.Forms.RadioButton();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.settings_menu_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.port_menu_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.speed_menu_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.IR_port_menu_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.google_drive_menu_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.graphic_menu_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.send_experiment_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.KoeffMenuBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.left_btn = new System.Windows.Forms.Button();
            this.down_btn = new System.Windows.Forms.Button();
            this.right_btn = new System.Windows.Forms.Button();
            this.up_btn = new System.Windows.Forms.Button();
            this.reactor_box = new System.Windows.Forms.GroupBox();
            this.tok_mode_box = new System.Windows.Forms.GroupBox();
            this.tok_mode_list = new System.Windows.Forms.DomainUpDown();
            this.info_box = new System.Windows.Forms.GroupBox();
            this.ComandLabel = new System.Windows.Forms.Label();
            this.UpdatePresetListBtn = new System.Windows.Forms.Button();
            this.presetsList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.state_lbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tem_lbl = new System.Windows.Forms.Label();
            this.port_checking = new System.Windows.Forms.Timer(this.components);
            this.IR_Serial_Port = new System.IO.Ports.SerialPort(this.components);
            this.IR_box = new System.Windows.Forms.GroupBox();
            this.Interval_IR_counter = new System.Windows.Forms.NumericUpDown();
            this.IR_button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.PresetToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.mode_settings_box.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cold_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fire_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iteration_counter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.time_bar)).BeginInit();
            this.mode_box.SuspendLayout();
            this.conf_box.SuspendLayout();
            this.menu.SuspendLayout();
            this.reactor_box.SuspendLayout();
            this.tok_mode_box.SuspendLayout();
            this.info_box.SuspendLayout();
            this.IR_box.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Interval_IR_counter)).BeginInit();
            this.SuspendLayout();
            // 
            // SerialPort
            // 
            this.SerialPort.BaudRate = 19200;
            this.SerialPort.RtsEnable = true;
            // 
            // mode_settings_box
            // 
            this.mode_settings_box.Controls.Add(this.cold_lbl);
            this.mode_settings_box.Controls.Add(this.cold_bar);
            this.mode_settings_box.Controls.Add(this.fire_lbl);
            this.mode_settings_box.Controls.Add(this.fire_bar);
            this.mode_settings_box.Controls.Add(this.iteration_label);
            this.mode_settings_box.Controls.Add(this.iteration_counter);
            this.mode_settings_box.Controls.Add(this.time_syntes_lable);
            this.mode_settings_box.Controls.Add(this.time_bar);
            this.mode_settings_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mode_settings_box.Location = new System.Drawing.Point(11, 275);
            this.mode_settings_box.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mode_settings_box.Name = "mode_settings_box";
            this.mode_settings_box.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mode_settings_box.Size = new System.Drawing.Size(751, 144);
            this.mode_settings_box.TabIndex = 1;
            this.mode_settings_box.TabStop = false;
            this.mode_settings_box.Text = "Настройки режима";
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
            // mode_box
            // 
            this.mode_box.Controls.Add(this.impulse_rdbtn);
            this.mode_box.Controls.Add(this.duga_rdbtn);
            this.mode_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mode_box.Location = new System.Drawing.Point(9, 52);
            this.mode_box.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mode_box.Name = "mode_box";
            this.mode_box.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mode_box.Size = new System.Drawing.Size(250, 180);
            this.mode_box.TabIndex = 5;
            this.mode_box.TabStop = false;
            this.mode_box.Text = "Режим";
            // 
            // impulse_rdbtn
            // 
            this.impulse_rdbtn.AutoSize = true;
            this.impulse_rdbtn.Enabled = false;
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
            // conf_box
            // 
            this.conf_box.Controls.Add(this.voilok_rdbtn);
            this.conf_box.Controls.Add(this.tigel_rdbtn);
            this.conf_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.conf_box.Location = new System.Drawing.Point(267, 52);
            this.conf_box.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.conf_box.Name = "conf_box";
            this.conf_box.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.conf_box.Size = new System.Drawing.Size(256, 180);
            this.conf_box.TabIndex = 6;
            this.conf_box.TabStop = false;
            this.conf_box.Text = "Конфигурация";
            // 
            // voilok_rdbtn
            // 
            this.voilok_rdbtn.AutoSize = true;
            this.voilok_rdbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.voilok_rdbtn.Location = new System.Drawing.Point(100, 112);
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
            this.tigel_rdbtn.Location = new System.Drawing.Point(106, 52);
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
            this.graphic_menu_btn,
            this.send_experiment_btn,
            this.KoeffMenuBtn});
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
            this.IR_port_menu_btn,
            this.google_drive_menu_btn});
            this.settings_menu_btn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.settings_menu_btn.Name = "settings_menu_btn";
            this.settings_menu_btn.Size = new System.Drawing.Size(148, 36);
            this.settings_menu_btn.Text = "Настройки";
            this.settings_menu_btn.DropDownOpened += new System.EventHandler(this.settings_menu_btn_DropDownOpened);
            this.settings_menu_btn.Click += new System.EventHandler(this.settings_menu_btn_Click);
            // 
            // port_menu_btn
            // 
            this.port_menu_btn.Name = "port_menu_btn";
            this.port_menu_btn.Size = new System.Drawing.Size(286, 40);
            this.port_menu_btn.Text = "Порт реактора:";
            this.port_menu_btn.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.port_menu_btn_DropDownItemClicked);
            // 
            // speed_menu_btn
            // 
            this.speed_menu_btn.Name = "speed_menu_btn";
            this.speed_menu_btn.Size = new System.Drawing.Size(286, 40);
            this.speed_menu_btn.Text = "Скорость: ";
            this.speed_menu_btn.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.speed_menu_btn_DropDownItemClicked);
            // 
            // IR_port_menu_btn
            // 
            this.IR_port_menu_btn.Name = "IR_port_menu_btn";
            this.IR_port_menu_btn.Size = new System.Drawing.Size(286, 40);
            this.IR_port_menu_btn.Text = "Порт IR:";
            this.IR_port_menu_btn.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.IR_port_menu_btn_DropDownItemClicked);
            // 
            // google_drive_menu_btn
            // 
            this.google_drive_menu_btn.Name = "google_drive_menu_btn";
            this.google_drive_menu_btn.Size = new System.Drawing.Size(286, 40);
            this.google_drive_menu_btn.Text = "Google Drive:";
            this.google_drive_menu_btn.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.google_drive_menu_btn_DropDownItemClicked);
            this.google_drive_menu_btn.Click += new System.EventHandler(this.google_drive_btn_DropDownItem);
            // 
            // graphic_menu_btn
            // 
            this.graphic_menu_btn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.graphic_menu_btn.Name = "graphic_menu_btn";
            this.graphic_menu_btn.Size = new System.Drawing.Size(109, 36);
            this.graphic_menu_btn.Text = "График";
            this.graphic_menu_btn.Click += new System.EventHandler(this.graphic_menu_btn_Click);
            // 
            // send_experiment_btn
            // 
            this.send_experiment_btn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.send_experiment_btn.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.send_experiment_btn.Name = "send_experiment_btn";
            this.send_experiment_btn.Size = new System.Drawing.Size(366, 36);
            this.send_experiment_btn.Text = "Открыть электронный журнал";
            this.send_experiment_btn.Click += new System.EventHandler(this.send_experiment_btn_Click);
            // 
            // KoeffMenuBtn
            // 
            this.KoeffMenuBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KoeffMenuBtn.Name = "KoeffMenuBtn";
            this.KoeffMenuBtn.Size = new System.Drawing.Size(432, 36);
            this.KoeffMenuBtn.Text = "Просмотр пресетов коэффициентов";
            this.KoeffMenuBtn.Click += new System.EventHandler(this.KoefRedactorMenuShowbtn_Click);
            // 
            // left_btn
            // 
            this.left_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.left_btn.BackColor = System.Drawing.Color.Silver;
            this.left_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.left_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.left_btn.Location = new System.Drawing.Point(1068, 640);
            this.left_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.left_btn.Name = "left_btn";
            this.left_btn.Size = new System.Drawing.Size(182, 112);
            this.left_btn.TabIndex = 8;
            this.left_btn.Tag = "A";
            this.left_btn.Text = "<";
            this.left_btn.UseVisualStyleBackColor = false;
            this.left_btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.arrow_btn_down);
            this.left_btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.arrow_btn_up);
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
            this.down_btn.Tag = "S";
            this.down_btn.Text = "˅";
            this.down_btn.UseVisualStyleBackColor = false;
            this.down_btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.arrow_btn_down);
            this.down_btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.arrow_btn_up);
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
            this.right_btn.Tag = "D";
            this.right_btn.Text = ">";
            this.right_btn.UseVisualStyleBackColor = false;
            this.right_btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.arrow_btn_down);
            this.right_btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.arrow_btn_up);
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
            this.up_btn.Tag = "W";
            this.up_btn.Text = "˄";
            this.up_btn.UseVisualStyleBackColor = false;
            this.up_btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.arrow_btn_down);
            this.up_btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.arrow_btn_up);
            // 
            // reactor_box
            // 
            this.reactor_box.BackColor = System.Drawing.SystemColors.Control;
            this.reactor_box.Controls.Add(this.tok_mode_box);
            this.reactor_box.Controls.Add(this.mode_box);
            this.reactor_box.Controls.Add(this.conf_box);
            this.reactor_box.Controls.Add(this.mode_settings_box);
            this.reactor_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reactor_box.Location = new System.Drawing.Point(12, 46);
            this.reactor_box.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.reactor_box.Name = "reactor_box";
            this.reactor_box.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.reactor_box.Size = new System.Drawing.Size(936, 432);
            this.reactor_box.TabIndex = 15;
            this.reactor_box.TabStop = false;
            this.reactor_box.Text = "Запуск реактора";
            // 
            // tok_mode_box
            // 
            this.tok_mode_box.Controls.Add(this.tok_mode_list);
            this.tok_mode_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tok_mode_box.Location = new System.Drawing.Point(530, 52);
            this.tok_mode_box.Name = "tok_mode_box";
            this.tok_mode_box.Size = new System.Drawing.Size(232, 98);
            this.tok_mode_box.TabIndex = 7;
            this.tok_mode_box.TabStop = false;
            this.tok_mode_box.Text = "Режим тока";
            // 
            // tok_mode_list
            // 
            this.tok_mode_list.Items.Add("200 А");
            this.tok_mode_list.Items.Add("150 А");
            this.tok_mode_list.Items.Add("100 А");
            this.tok_mode_list.Items.Add("75 А");
            this.tok_mode_list.Items.Add("50 А");
            this.tok_mode_list.Items.Add("25 А");
            this.tok_mode_list.Location = new System.Drawing.Point(101, 50);
            this.tok_mode_list.Name = "tok_mode_list";
            this.tok_mode_list.ReadOnly = true;
            this.tok_mode_list.Size = new System.Drawing.Size(125, 39);
            this.tok_mode_list.TabIndex = 0;
            this.tok_mode_list.Text = "200 А";
            this.tok_mode_list.SelectedItemChanged += new System.EventHandler(this.tok_mode_list_SelectedItemChanged);
            // 
            // info_box
            // 
            this.info_box.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.info_box.BackColor = System.Drawing.SystemColors.Control;
            this.info_box.Controls.Add(this.ComandLabel);
            this.info_box.Controls.Add(this.UpdatePresetListBtn);
            this.info_box.Controls.Add(this.presetsList);
            this.info_box.Controls.Add(this.label2);
            this.info_box.Controls.Add(this.state_lbl);
            this.info_box.Controls.Add(this.label1);
            this.info_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.info_box.Location = new System.Drawing.Point(1083, 66);
            this.info_box.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.info_box.Name = "info_box";
            this.info_box.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.info_box.Size = new System.Drawing.Size(563, 259);
            this.info_box.TabIndex = 16;
            this.info_box.TabStop = false;
            this.info_box.Text = "Информация о реакторе";
            // 
            // ComandLabel
            // 
            this.ComandLabel.AutoSize = true;
            this.ComandLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ComandLabel.Location = new System.Drawing.Point(17, 55);
            this.ComandLabel.Name = "ComandLabel";
            this.ComandLabel.Size = new System.Drawing.Size(122, 29);
            this.ComandLabel.TabIndex = 21;
            this.ComandLabel.Text = "Команда:";
            // 
            // UpdatePresetListBtn
            // 
            this.UpdatePresetListBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UpdatePresetListBtn.Location = new System.Drawing.Point(22, 196);
            this.UpdatePresetListBtn.Name = "UpdatePresetListBtn";
            this.UpdatePresetListBtn.Size = new System.Drawing.Size(254, 45);
            this.UpdatePresetListBtn.TabIndex = 2;
            this.UpdatePresetListBtn.Text = "Обновить список пресетов";
            this.UpdatePresetListBtn.UseVisualStyleBackColor = true;
            this.UpdatePresetListBtn.Click += new System.EventHandler(this.UpdatePresetListBtn_Click);
            // 
            // presetsList
            // 
            this.presetsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.presetsList.FormattingEnabled = true;
            this.presetsList.Location = new System.Drawing.Point(381, 144);
            this.presetsList.Name = "presetsList";
            this.presetsList.Size = new System.Drawing.Size(175, 37);
            this.presetsList.TabIndex = 20;
            this.presetsList.SelectedValueChanged += new System.EventHandler(this.presetsList_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label2.Location = new System.Drawing.Point(15, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(349, 37);
            this.label2.TabIndex = 4;
            this.label2.Text = "Пресет коэффициентов";
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
            // tem_lbl
            // 
            this.tem_lbl.AutoSize = true;
            this.tem_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.tem_lbl.Location = new System.Drawing.Point(955, 330);
            this.tem_lbl.Name = "tem_lbl";
            this.tem_lbl.Size = new System.Drawing.Size(227, 37);
            this.tem_lbl.TabIndex = 3;
            this.tem_lbl.Text = "Температура: ";
            this.tem_lbl.Visible = false;
            // 
            // port_checking
            // 
            this.port_checking.Tick += new System.EventHandler(this.port_checking_Tick);
            // 
            // IR_Serial_Port
            // 
            this.IR_Serial_Port.BaudRate = 19200;
            // 
            // IR_box
            // 
            this.IR_box.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IR_box.Controls.Add(this.Interval_IR_counter);
            this.IR_box.Controls.Add(this.IR_button);
            this.IR_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.IR_box.Location = new System.Drawing.Point(1217, 333);
            this.IR_box.Name = "IR_box";
            this.IR_box.Size = new System.Drawing.Size(435, 100);
            this.IR_box.TabIndex = 17;
            this.IR_box.TabStop = false;
            this.IR_box.Text = "Термометр";
            // 
            // Interval_IR_counter
            // 
            this.Interval_IR_counter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Interval_IR_counter.Location = new System.Drawing.Point(352, 50);
            this.Interval_IR_counter.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.Interval_IR_counter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Interval_IR_counter.Name = "Interval_IR_counter";
            this.Interval_IR_counter.Size = new System.Drawing.Size(71, 39);
            this.Interval_IR_counter.TabIndex = 1;
            this.Interval_IR_counter.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // IR_button
            // 
            this.IR_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IR_button.Location = new System.Drawing.Point(6, 47);
            this.IR_button.Name = "IR_button";
            this.IR_button.Size = new System.Drawing.Size(215, 45);
            this.IR_button.TabIndex = 0;
            this.IR_button.Text = "Начать";
            this.IR_button.UseVisualStyleBackColor = true;
            this.IR_button.Click += new System.EventHandler(this.IR_button_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Silver;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(1479, 447);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 55);
            this.button1.TabIndex = 18;
            this.button1.Tag = "U";
            this.button1.Text = "U";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.arrow_btn_down);
            this.button1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.arrow_btn_up);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.Silver;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(1569, 447);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 55);
            this.button2.TabIndex = 19;
            this.button2.Tag = "J";
            this.button2.Text = "D";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.arrow_btn_down);
            this.button2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.arrow_btn_up);
            // 
            // Main_menu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1664, 771);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.IR_box);
            this.Controls.Add(this.tem_lbl);
            this.Controls.Add(this.info_box);
            this.Controls.Add(this.reactor_box);
            this.Controls.Add(this.up_btn);
            this.Controls.Add(this.right_btn);
            this.Controls.Add(this.down_btn);
            this.Controls.Add(this.left_btn);
            this.Controls.Add(this.start_btn);
            this.Controls.Add(this.stop_btn);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menu;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Main_menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Интерфейс реактора";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_menu_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_menu_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Main_menu_KeyUp);
            this.mode_settings_box.ResumeLayout(false);
            this.mode_settings_box.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cold_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fire_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iteration_counter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.time_bar)).EndInit();
            this.mode_box.ResumeLayout(false);
            this.mode_box.PerformLayout();
            this.conf_box.ResumeLayout(false);
            this.conf_box.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.reactor_box.ResumeLayout(false);
            this.tok_mode_box.ResumeLayout(false);
            this.info_box.ResumeLayout(false);
            this.info_box.PerformLayout();
            this.IR_box.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Interval_IR_counter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort SerialPort;
        private System.Windows.Forms.GroupBox mode_settings_box;
        private System.Windows.Forms.TrackBar time_bar;
        private System.Windows.Forms.Label time_syntes_lable;
        private System.Windows.Forms.Button stop_btn;
        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.GroupBox mode_box;
        private System.Windows.Forms.RadioButton impulse_rdbtn;
        private System.Windows.Forms.RadioButton duga_rdbtn;
        private System.Windows.Forms.GroupBox conf_box;
        private System.Windows.Forms.RadioButton voilok_rdbtn;
        private System.Windows.Forms.RadioButton tigel_rdbtn;
        private System.Windows.Forms.Label iteration_label;
        private System.Windows.Forms.NumericUpDown iteration_counter;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem settings_menu_btn;
        private System.Windows.Forms.ToolStripMenuItem port_menu_btn;
        private System.Windows.Forms.ToolStripMenuItem speed_menu_btn;
        private System.Windows.Forms.ToolStripMenuItem KoeffMenuBtn;
        private System.Windows.Forms.Button left_btn;
        private System.Windows.Forms.Button down_btn;
        private System.Windows.Forms.Button right_btn;
        private System.Windows.Forms.Button up_btn;
        private System.Windows.Forms.GroupBox reactor_box;
        private System.Windows.Forms.GroupBox info_box;
        private System.Windows.Forms.ToolStripMenuItem graphic_menu_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label state_lbl;
        private System.Windows.Forms.Timer port_checking;
        private System.Windows.Forms.TrackBar fire_bar;
        private System.Windows.Forms.Label fire_lbl;
        private System.Windows.Forms.Label cold_lbl;
        private System.Windows.Forms.TrackBar cold_bar;
        private System.IO.Ports.SerialPort IR_Serial_Port;
        private System.Windows.Forms.ToolStripMenuItem IR_port_menu_btn;
        private System.Windows.Forms.GroupBox IR_box;
        private System.Windows.Forms.NumericUpDown Interval_IR_counter;
        private System.Windows.Forms.Button IR_button;
        private System.Windows.Forms.Label tem_lbl;
        private System.Windows.Forms.DomainUpDown tok_mode_list;
        private System.Windows.Forms.GroupBox tok_mode_box;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem send_experiment_btn;
        private System.Windows.Forms.ToolStripMenuItem google_drive_menu_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox presetsList;
        private System.Windows.Forms.ToolTip PresetToolTip;
        private System.Windows.Forms.Button UpdatePresetListBtn;
        private System.Windows.Forms.Label ComandLabel;
    }
}

