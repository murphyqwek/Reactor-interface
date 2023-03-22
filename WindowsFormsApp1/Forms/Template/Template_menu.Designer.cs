namespace Reactor_Interface.Forms.Experiment
{
    partial class Template_menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Template_menu));
            this.template_gorupbox = new System.Windows.Forms.GroupBox();
            this.template_list = new System.Windows.Forms.ListBox();
            this.find_groupbx = new System.Windows.Forms.GroupBox();
            this.find_btn = new System.Windows.Forms.Button();
            this.find_txtbx = new System.Windows.Forms.RichTextBox();
            this.used_template_lbl = new System.Windows.Forms.Label();
            this.upload_btn = new System.Windows.Forms.Button();
            this.create_btn = new System.Windows.Forms.Button();
            this.template_gorupbox.SuspendLayout();
            this.find_groupbx.SuspendLayout();
            this.SuspendLayout();
            // 
            // template_gorupbox
            // 
            this.template_gorupbox.Controls.Add(this.template_list);
            this.template_gorupbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.template_gorupbox.Location = new System.Drawing.Point(12, 12);
            this.template_gorupbox.Name = "template_gorupbox";
            this.template_gorupbox.Size = new System.Drawing.Size(432, 426);
            this.template_gorupbox.TabIndex = 1;
            this.template_gorupbox.TabStop = false;
            this.template_gorupbox.Text = "Шаблоны";
            // 
            // template_list
            // 
            this.template_list.FormattingEnabled = true;
            this.template_list.ItemHeight = 25;
            this.template_list.Location = new System.Drawing.Point(6, 25);
            this.template_list.Name = "template_list";
            this.template_list.Size = new System.Drawing.Size(420, 379);
            this.template_list.TabIndex = 0;
            // 
            // find_groupbx
            // 
            this.find_groupbx.Controls.Add(this.find_txtbx);
            this.find_groupbx.Controls.Add(this.find_btn);
            this.find_groupbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.find_groupbx.Location = new System.Drawing.Point(450, 25);
            this.find_groupbx.Name = "find_groupbx";
            this.find_groupbx.Size = new System.Drawing.Size(338, 79);
            this.find_groupbx.TabIndex = 2;
            this.find_groupbx.TabStop = false;
            this.find_groupbx.Text = "Поиск";
            // 
            // find_btn
            // 
            this.find_btn.Location = new System.Drawing.Point(222, 32);
            this.find_btn.Name = "find_btn";
            this.find_btn.Size = new System.Drawing.Size(110, 37);
            this.find_btn.TabIndex = 1;
            this.find_btn.Text = "Найти";
            this.find_btn.UseVisualStyleBackColor = true;
            // 
            // find_txtbx
            // 
            this.find_txtbx.Location = new System.Drawing.Point(7, 32);
            this.find_txtbx.Name = "find_txtbx";
            this.find_txtbx.Size = new System.Drawing.Size(196, 37);
            this.find_txtbx.TabIndex = 2;
            this.find_txtbx.Text = "";
            // 
            // used_template_lbl
            // 
            this.used_template_lbl.AutoSize = true;
            this.used_template_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.used_template_lbl.Location = new System.Drawing.Point(445, 219);
            this.used_template_lbl.Name = "used_template_lbl";
            this.used_template_lbl.Size = new System.Drawing.Size(235, 25);
            this.used_template_lbl.TabIndex = 3;
            this.used_template_lbl.Text = "Используемый шаблон:";
            // 
            // upload_btn
            // 
            this.upload_btn.Location = new System.Drawing.Point(450, 342);
            this.upload_btn.Name = "upload_btn";
            this.upload_btn.Size = new System.Drawing.Size(153, 74);
            this.upload_btn.TabIndex = 4;
            this.upload_btn.Text = "Загрузить шаблон";
            this.upload_btn.UseVisualStyleBackColor = true;
            // 
            // create_btn
            // 
            this.create_btn.Location = new System.Drawing.Point(648, 342);
            this.create_btn.Name = "create_btn";
            this.create_btn.Size = new System.Drawing.Size(140, 74);
            this.create_btn.TabIndex = 5;
            this.create_btn.Text = "Создать новый шаблон";
            this.create_btn.UseVisualStyleBackColor = true;
            this.create_btn.Click += new System.EventHandler(this.create_btn_Click);
            // 
            // Template_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 444);
            this.Controls.Add(this.create_btn);
            this.Controls.Add(this.upload_btn);
            this.Controls.Add(this.used_template_lbl);
            this.Controls.Add(this.find_groupbx);
            this.Controls.Add(this.template_gorupbox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Template_menu";
            this.Text = "Шаблоны";
            this.template_gorupbox.ResumeLayout(false);
            this.find_groupbx.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox template_gorupbox;
        private System.Windows.Forms.ListBox template_list;
        private System.Windows.Forms.GroupBox find_groupbx;
        private System.Windows.Forms.RichTextBox find_txtbx;
        private System.Windows.Forms.Button find_btn;
        private System.Windows.Forms.Label used_template_lbl;
        private System.Windows.Forms.Button upload_btn;
        private System.Windows.Forms.Button create_btn;
    }
}