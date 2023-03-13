namespace Reactor_Interface
{
    partial class Experiment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Experiment));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.изменитьНомерToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.googleDriveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.data_groupbox = new System.Windows.Forms.GroupBox();
            this.after_groupbox = new System.Windows.Forms.GroupBox();
            this.tigel_after_txtbox = new System.Windows.Forms.TextBox();
            this.tigel_after_lbl = new System.Windows.Forms.Label();
            this.deposit_txtbox = new System.Windows.Forms.TextBox();
            this.deposit_lbl = new System.Windows.Forms.Label();
            this.katod_after_txtbox = new System.Windows.Forms.TextBox();
            this.katod_after_lbl = new System.Windows.Forms.Label();
            this.anod_after_txtbox = new System.Windows.Forms.TextBox();
            this.anod_after_lbl = new System.Windows.Forms.Label();
            this.mass_power_txtbox = new System.Windows.Forms.TextBox();
            this.mass_power_lbl = new System.Windows.Forms.Label();
            this.before_groupbox = new System.Windows.Forms.GroupBox();
            this.tigel_before_txtbox = new System.Windows.Forms.TextBox();
            this.tigel_before_lbl = new System.Windows.Forms.Label();
            this.lid_txtbox = new System.Windows.Forms.TextBox();
            this.lid_lbl = new System.Windows.Forms.Label();
            this.katod_before_txtbox = new System.Windows.Forms.TextBox();
            this.katod_before_lbl = new System.Windows.Forms.Label();
            this.anod_before_txtbox = new System.Windows.Forms.TextBox();
            this.anod_before_lbl = new System.Windows.Forms.Label();
            this.mass_txtbox = new System.Windows.Forms.TextBox();
            this.mass_lbl = new System.Windows.Forms.Label();
            this.general_groupbox = new System.Windows.Forms.GroupBox();
            this.t_txtbox = new System.Windows.Forms.TextBox();
            this.t_lbl = new System.Windows.Forms.Label();
            this.t_plan_txtbox = new System.Windows.Forms.TextBox();
            this.t_plan_lbl = new System.Windows.Forms.Label();
            this.tok_txtbox = new System.Windows.Forms.TextBox();
            this.tok_lbl = new System.Windows.Forms.Label();
            this.name_txtbox = new System.Windows.Forms.TextBox();
            this.name_lbl = new System.Windows.Forms.Label();
            this.reagents_txtbox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.save_to_drive_btn = new System.Windows.Forms.Button();
            this.save_on_computer_btn = new System.Windows.Forms.Button();
            this.clear_exp_btn = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.data_groupbox.SuspendLayout();
            this.after_groupbox.SuspendLayout();
            this.before_groupbox.SuspendLayout();
            this.general_groupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.изменитьНомерToolStripMenuItem,
            this.googleDriveToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1419, 36);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // изменитьНомерToolStripMenuItem
            // 
            this.изменитьНомерToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.изменитьНомерToolStripMenuItem.Name = "изменитьНомерToolStripMenuItem";
            this.изменитьНомерToolStripMenuItem.Size = new System.Drawing.Size(183, 32);
            this.изменитьНомерToolStripMenuItem.Text = "Изменить номер";
            // 
            // googleDriveToolStripMenuItem
            // 
            this.googleDriveToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.googleDriveToolStripMenuItem.Name = "googleDriveToolStripMenuItem";
            this.googleDriveToolStripMenuItem.Size = new System.Drawing.Size(148, 32);
            this.googleDriveToolStripMenuItem.Text = "Google Drive:";
            this.googleDriveToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.googleDriveToolStripMenuItem_DropDownItemClicked);
            // 
            // data_groupbox
            // 
            this.data_groupbox.Controls.Add(this.after_groupbox);
            this.data_groupbox.Controls.Add(this.before_groupbox);
            this.data_groupbox.Controls.Add(this.general_groupbox);
            this.data_groupbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.data_groupbox.Location = new System.Drawing.Point(12, 39);
            this.data_groupbox.Name = "data_groupbox";
            this.data_groupbox.Size = new System.Drawing.Size(508, 501);
            this.data_groupbox.TabIndex = 1;
            this.data_groupbox.TabStop = false;
            this.data_groupbox.Text = "Данные эксперимента";
            // 
            // after_groupbox
            // 
            this.after_groupbox.Controls.Add(this.tigel_after_txtbox);
            this.after_groupbox.Controls.Add(this.tigel_after_lbl);
            this.after_groupbox.Controls.Add(this.deposit_txtbox);
            this.after_groupbox.Controls.Add(this.deposit_lbl);
            this.after_groupbox.Controls.Add(this.katod_after_txtbox);
            this.after_groupbox.Controls.Add(this.katod_after_lbl);
            this.after_groupbox.Controls.Add(this.anod_after_txtbox);
            this.after_groupbox.Controls.Add(this.anod_after_lbl);
            this.after_groupbox.Controls.Add(this.mass_power_txtbox);
            this.after_groupbox.Controls.Add(this.mass_power_lbl);
            this.after_groupbox.Location = new System.Drawing.Point(253, 194);
            this.after_groupbox.Name = "after_groupbox";
            this.after_groupbox.Size = new System.Drawing.Size(249, 303);
            this.after_groupbox.TabIndex = 2;
            this.after_groupbox.TabStop = false;
            this.after_groupbox.Text = "После эксперимента";
            // 
            // tigel_after_txtbox
            // 
            this.tigel_after_txtbox.Location = new System.Drawing.Point(71, 265);
            this.tigel_after_txtbox.Name = "tigel_after_txtbox";
            this.tigel_after_txtbox.Size = new System.Drawing.Size(162, 28);
            this.tigel_after_txtbox.TabIndex = 11;
            // 
            // tigel_after_lbl
            // 
            this.tigel_after_lbl.AutoSize = true;
            this.tigel_after_lbl.Location = new System.Drawing.Point(47, 242);
            this.tigel_after_lbl.Name = "tigel_after_lbl";
            this.tigel_after_lbl.Size = new System.Drawing.Size(193, 22);
            this.tigel_after_lbl.TabIndex = 10;
            this.tigel_after_lbl.Text = "Тигель со всем после";
            // 
            // deposit_txtbox
            // 
            this.deposit_txtbox.Location = new System.Drawing.Point(71, 213);
            this.deposit_txtbox.Name = "deposit_txtbox";
            this.deposit_txtbox.Size = new System.Drawing.Size(162, 28);
            this.deposit_txtbox.TabIndex = 9;
            // 
            // deposit_lbl
            // 
            this.deposit_lbl.AutoSize = true;
            this.deposit_lbl.Location = new System.Drawing.Point(75, 190);
            this.deposit_lbl.Name = "deposit_lbl";
            this.deposit_lbl.Size = new System.Drawing.Size(167, 22);
            this.deposit_lbl.TabIndex = 8;
            this.deposit_lbl.Text = "Катодный депозит";
            // 
            // katod_after_txtbox
            // 
            this.katod_after_txtbox.Location = new System.Drawing.Point(71, 161);
            this.katod_after_txtbox.Name = "katod_after_txtbox";
            this.katod_after_txtbox.Size = new System.Drawing.Size(162, 28);
            this.katod_after_txtbox.TabIndex = 7;
            // 
            // katod_after_lbl
            // 
            this.katod_after_lbl.AutoSize = true;
            this.katod_after_lbl.Location = new System.Drawing.Point(64, 138);
            this.katod_after_lbl.Name = "katod_after_lbl";
            this.katod_after_lbl.Size = new System.Drawing.Size(176, 22);
            this.katod_after_lbl.TabIndex = 6;
            this.katod_after_lbl.Text = "Катод пустой после";
            // 
            // anod_after_txtbox
            // 
            this.anod_after_txtbox.Location = new System.Drawing.Point(71, 106);
            this.anod_after_txtbox.Name = "anod_after_txtbox";
            this.anod_after_txtbox.Size = new System.Drawing.Size(162, 28);
            this.anod_after_txtbox.TabIndex = 5;
            // 
            // anod_after_lbl
            // 
            this.anod_after_lbl.AutoSize = true;
            this.anod_after_lbl.Location = new System.Drawing.Point(135, 83);
            this.anod_after_lbl.Name = "anod_after_lbl";
            this.anod_after_lbl.Size = new System.Drawing.Size(107, 22);
            this.anod_after_lbl.TabIndex = 4;
            this.anod_after_lbl.Text = "Анод после";
            // 
            // mass_power_txtbox
            // 
            this.mass_power_txtbox.Location = new System.Drawing.Point(71, 54);
            this.mass_power_txtbox.Name = "mass_power_txtbox";
            this.mass_power_txtbox.Size = new System.Drawing.Size(162, 28);
            this.mass_power_txtbox.TabIndex = 3;
            // 
            // mass_power_lbl
            // 
            this.mass_power_lbl.AutoSize = true;
            this.mass_power_lbl.Location = new System.Drawing.Point(100, 31);
            this.mass_power_lbl.Name = "mass_power_lbl";
            this.mass_power_lbl.Size = new System.Drawing.Size(140, 22);
            this.mass_power_lbl.TabIndex = 2;
            this.mass_power_lbl.Text = "Масса порошка";
            // 
            // before_groupbox
            // 
            this.before_groupbox.Controls.Add(this.tigel_before_txtbox);
            this.before_groupbox.Controls.Add(this.tigel_before_lbl);
            this.before_groupbox.Controls.Add(this.lid_txtbox);
            this.before_groupbox.Controls.Add(this.lid_lbl);
            this.before_groupbox.Controls.Add(this.katod_before_txtbox);
            this.before_groupbox.Controls.Add(this.katod_before_lbl);
            this.before_groupbox.Controls.Add(this.anod_before_txtbox);
            this.before_groupbox.Controls.Add(this.anod_before_lbl);
            this.before_groupbox.Controls.Add(this.mass_txtbox);
            this.before_groupbox.Controls.Add(this.mass_lbl);
            this.before_groupbox.Location = new System.Drawing.Point(7, 194);
            this.before_groupbox.Name = "before_groupbox";
            this.before_groupbox.Size = new System.Drawing.Size(240, 303);
            this.before_groupbox.TabIndex = 1;
            this.before_groupbox.TabStop = false;
            this.before_groupbox.Text = "До эксперимента";
            // 
            // tigel_before_txtbox
            // 
            this.tigel_before_txtbox.Location = new System.Drawing.Point(11, 265);
            this.tigel_before_txtbox.Name = "tigel_before_txtbox";
            this.tigel_before_txtbox.Size = new System.Drawing.Size(162, 28);
            this.tigel_before_txtbox.TabIndex = 17;
            // 
            // tigel_before_lbl
            // 
            this.tigel_before_lbl.AutoSize = true;
            this.tigel_before_lbl.Location = new System.Drawing.Point(7, 242);
            this.tigel_before_lbl.Name = "tigel_before_lbl";
            this.tigel_before_lbl.Size = new System.Drawing.Size(165, 22);
            this.tigel_before_lbl.TabIndex = 16;
            this.tigel_before_lbl.Text = "Тигель со всем до";
            // 
            // lid_txtbox
            // 
            this.lid_txtbox.Location = new System.Drawing.Point(11, 213);
            this.lid_txtbox.Name = "lid_txtbox";
            this.lid_txtbox.Size = new System.Drawing.Size(162, 28);
            this.lid_txtbox.TabIndex = 15;
            // 
            // lid_lbl
            // 
            this.lid_lbl.AutoSize = true;
            this.lid_lbl.Location = new System.Drawing.Point(7, 190);
            this.lid_lbl.Name = "lid_lbl";
            this.lid_lbl.Size = new System.Drawing.Size(104, 22);
            this.lid_lbl.TabIndex = 14;
            this.lid_lbl.Text = "Крышка до";
            // 
            // katod_before_txtbox
            // 
            this.katod_before_txtbox.Location = new System.Drawing.Point(11, 161);
            this.katod_before_txtbox.Name = "katod_before_txtbox";
            this.katod_before_txtbox.Size = new System.Drawing.Size(162, 28);
            this.katod_before_txtbox.TabIndex = 13;
            // 
            // katod_before_lbl
            // 
            this.katod_before_lbl.AutoSize = true;
            this.katod_before_lbl.Location = new System.Drawing.Point(7, 138);
            this.katod_before_lbl.Name = "katod_before_lbl";
            this.katod_before_lbl.Size = new System.Drawing.Size(87, 22);
            this.katod_before_lbl.TabIndex = 12;
            this.katod_before_lbl.Text = "Катод до";
            // 
            // anod_before_txtbox
            // 
            this.anod_before_txtbox.Location = new System.Drawing.Point(11, 109);
            this.anod_before_txtbox.Name = "anod_before_txtbox";
            this.anod_before_txtbox.Size = new System.Drawing.Size(162, 28);
            this.anod_before_txtbox.TabIndex = 11;
            // 
            // anod_before_lbl
            // 
            this.anod_before_lbl.AutoSize = true;
            this.anod_before_lbl.Location = new System.Drawing.Point(7, 86);
            this.anod_before_lbl.Name = "anod_before_lbl";
            this.anod_before_lbl.Size = new System.Drawing.Size(79, 22);
            this.anod_before_lbl.TabIndex = 10;
            this.anod_before_lbl.Text = "Анод до";
            // 
            // mass_txtbox
            // 
            this.mass_txtbox.Location = new System.Drawing.Point(11, 54);
            this.mass_txtbox.Name = "mass_txtbox";
            this.mass_txtbox.Size = new System.Drawing.Size(162, 28);
            this.mass_txtbox.TabIndex = 9;
            // 
            // mass_lbl
            // 
            this.mass_lbl.AutoSize = true;
            this.mass_lbl.Location = new System.Drawing.Point(7, 31);
            this.mass_lbl.Name = "mass_lbl";
            this.mass_lbl.Size = new System.Drawing.Size(146, 22);
            this.mass_lbl.TabIndex = 8;
            this.mass_lbl.Text = "Масса исходная";
            // 
            // general_groupbox
            // 
            this.general_groupbox.Controls.Add(this.t_txtbox);
            this.general_groupbox.Controls.Add(this.t_lbl);
            this.general_groupbox.Controls.Add(this.t_plan_txtbox);
            this.general_groupbox.Controls.Add(this.t_plan_lbl);
            this.general_groupbox.Controls.Add(this.tok_txtbox);
            this.general_groupbox.Controls.Add(this.tok_lbl);
            this.general_groupbox.Controls.Add(this.name_txtbox);
            this.general_groupbox.Controls.Add(this.name_lbl);
            this.general_groupbox.Location = new System.Drawing.Point(7, 26);
            this.general_groupbox.Name = "general_groupbox";
            this.general_groupbox.Size = new System.Drawing.Size(495, 150);
            this.general_groupbox.TabIndex = 0;
            this.general_groupbox.TabStop = false;
            this.general_groupbox.Text = "Общие настройки";
            // 
            // t_txtbox
            // 
            this.t_txtbox.Location = new System.Drawing.Point(317, 112);
            this.t_txtbox.Name = "t_txtbox";
            this.t_txtbox.Size = new System.Drawing.Size(162, 28);
            this.t_txtbox.TabIndex = 7;
            // 
            // t_lbl
            // 
            this.t_lbl.AutoSize = true;
            this.t_lbl.Location = new System.Drawing.Point(427, 89);
            this.t_lbl.Name = "t_lbl";
            this.t_lbl.Size = new System.Drawing.Size(52, 22);
            this.t_lbl.TabIndex = 6;
            this.t_lbl.Text = "T, °C";
            // 
            // t_plan_txtbox
            // 
            this.t_plan_txtbox.Location = new System.Drawing.Point(317, 49);
            this.t_plan_txtbox.Name = "t_plan_txtbox";
            this.t_plan_txtbox.Size = new System.Drawing.Size(162, 28);
            this.t_plan_txtbox.TabIndex = 5;
            // 
            // t_plan_lbl
            // 
            this.t_plan_lbl.AutoSize = true;
            this.t_plan_lbl.Location = new System.Drawing.Point(412, 26);
            this.t_plan_lbl.Name = "t_plan_lbl";
            this.t_plan_lbl.Size = new System.Drawing.Size(74, 22);
            this.t_plan_lbl.TabIndex = 4;
            this.t_plan_lbl.Text = "tплан, с";
            // 
            // tok_txtbox
            // 
            this.tok_txtbox.Location = new System.Drawing.Point(11, 112);
            this.tok_txtbox.Name = "tok_txtbox";
            this.tok_txtbox.Size = new System.Drawing.Size(162, 28);
            this.tok_txtbox.TabIndex = 3;
            // 
            // tok_lbl
            // 
            this.tok_lbl.AutoSize = true;
            this.tok_lbl.Location = new System.Drawing.Point(7, 89);
            this.tok_lbl.Name = "tok_lbl";
            this.tok_lbl.Size = new System.Drawing.Size(46, 22);
            this.tok_lbl.TabIndex = 2;
            this.tok_lbl.Text = "Ia, A";
            // 
            // name_txtbox
            // 
            this.name_txtbox.Location = new System.Drawing.Point(11, 49);
            this.name_txtbox.Name = "name_txtbox";
            this.name_txtbox.Size = new System.Drawing.Size(162, 28);
            this.name_txtbox.TabIndex = 1;
            // 
            // name_lbl
            // 
            this.name_lbl.AutoSize = true;
            this.name_lbl.Location = new System.Drawing.Point(7, 26);
            this.name_lbl.Name = "name_lbl";
            this.name_lbl.Size = new System.Drawing.Size(136, 22);
            this.name_lbl.TabIndex = 0;
            this.name_lbl.Text = "Наименование";
            // 
            // reagents_txtbox
            // 
            this.reagents_txtbox.Location = new System.Drawing.Point(526, 78);
            this.reagents_txtbox.Name = "reagents_txtbox";
            this.reagents_txtbox.Size = new System.Drawing.Size(432, 237);
            this.reagents_txtbox.TabIndex = 2;
            this.reagents_txtbox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(526, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "Состав и массы реагентов";
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
            // save_to_drive_btn
            // 
            this.save_to_drive_btn.Location = new System.Drawing.Point(1216, 448);
            this.save_to_drive_btn.Name = "save_to_drive_btn";
            this.save_to_drive_btn.Size = new System.Drawing.Size(191, 92);
            this.save_to_drive_btn.TabIndex = 15;
            this.save_to_drive_btn.Text = "Сохранить на диск";
            this.save_to_drive_btn.UseVisualStyleBackColor = true;
            this.save_to_drive_btn.Click += new System.EventHandler(this.save_to_drive_btn_Click);
            // 
            // save_on_computer_btn
            // 
            this.save_on_computer_btn.Location = new System.Drawing.Point(1019, 448);
            this.save_on_computer_btn.Name = "save_on_computer_btn";
            this.save_on_computer_btn.Size = new System.Drawing.Size(191, 92);
            this.save_on_computer_btn.TabIndex = 16;
            this.save_on_computer_btn.Text = "Сохранить на компьютер";
            this.save_on_computer_btn.UseVisualStyleBackColor = true;
            // 
            // clear_exp_btn
            // 
            this.clear_exp_btn.Location = new System.Drawing.Point(531, 448);
            this.clear_exp_btn.Name = "clear_exp_btn";
            this.clear_exp_btn.Size = new System.Drawing.Size(191, 92);
            this.clear_exp_btn.TabIndex = 17;
            this.clear_exp_btn.Text = "Очистить эксперимент";
            this.clear_exp_btn.UseVisualStyleBackColor = true;
            // 
            // Experiment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1419, 550);
            this.Controls.Add(this.clear_exp_btn);
            this.Controls.Add(this.save_on_computer_btn);
            this.Controls.Add(this.save_to_drive_btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reagents_txtbox);
            this.Controls.Add(this.data_groupbox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Experiment";
            this.Text = "Эксперимент";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.data_groupbox.ResumeLayout(false);
            this.after_groupbox.ResumeLayout(false);
            this.after_groupbox.PerformLayout();
            this.before_groupbox.ResumeLayout(false);
            this.before_groupbox.PerformLayout();
            this.general_groupbox.ResumeLayout(false);
            this.general_groupbox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem googleDriveToolStripMenuItem;
        private System.Windows.Forms.GroupBox data_groupbox;
        private System.Windows.Forms.GroupBox after_groupbox;
        private System.Windows.Forms.GroupBox before_groupbox;
        private System.Windows.Forms.GroupBox general_groupbox;
        private System.Windows.Forms.TextBox t_txtbox;
        private System.Windows.Forms.Label t_lbl;
        private System.Windows.Forms.TextBox t_plan_txtbox;
        private System.Windows.Forms.Label t_plan_lbl;
        private System.Windows.Forms.TextBox tok_txtbox;
        private System.Windows.Forms.Label tok_lbl;
        private System.Windows.Forms.TextBox name_txtbox;
        private System.Windows.Forms.Label name_lbl;
        private System.Windows.Forms.TextBox deposit_txtbox;
        private System.Windows.Forms.Label deposit_lbl;
        private System.Windows.Forms.TextBox katod_after_txtbox;
        private System.Windows.Forms.Label katod_after_lbl;
        private System.Windows.Forms.TextBox anod_after_txtbox;
        private System.Windows.Forms.Label anod_after_lbl;
        private System.Windows.Forms.TextBox mass_power_txtbox;
        private System.Windows.Forms.Label mass_power_lbl;
        private System.Windows.Forms.TextBox tigel_before_txtbox;
        private System.Windows.Forms.Label tigel_before_lbl;
        private System.Windows.Forms.TextBox lid_txtbox;
        private System.Windows.Forms.Label lid_lbl;
        private System.Windows.Forms.TextBox katod_before_txtbox;
        private System.Windows.Forms.Label katod_before_lbl;
        private System.Windows.Forms.TextBox anod_before_txtbox;
        private System.Windows.Forms.Label anod_before_lbl;
        private System.Windows.Forms.TextBox mass_txtbox;
        private System.Windows.Forms.Label mass_lbl;
        private System.Windows.Forms.TextBox tigel_after_txtbox;
        private System.Windows.Forms.Label tigel_after_lbl;
        private System.Windows.Forms.ToolStripMenuItem изменитьНомерToolStripMenuItem;
        private System.Windows.Forms.RichTextBox reagents_txtbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button save_to_drive_btn;
        private System.Windows.Forms.Button save_on_computer_btn;
        private System.Windows.Forms.Button clear_exp_btn;
    }
}