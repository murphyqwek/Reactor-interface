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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Template_menu));
            this.template_gorupbox = new System.Windows.Forms.GroupBox();
            this.template_view = new System.Windows.Forms.ListView();
            this.MainColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.template_contextmenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.change_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.delete_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.find_groupbx = new System.Windows.Forms.GroupBox();
            this.find_txtbx = new System.Windows.Forms.RichTextBox();
            this.find_btn = new System.Windows.Forms.Button();
            this.chosen_template_lbl = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.AddTemplateBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.UploadTemplateBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateNewTemplateBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateTemplateBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.template_gorupbox.SuspendLayout();
            this.template_contextmenu.SuspendLayout();
            this.find_groupbx.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // template_gorupbox
            // 
            this.template_gorupbox.Controls.Add(this.template_view);
            this.template_gorupbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.template_gorupbox.Location = new System.Drawing.Point(12, 36);
            this.template_gorupbox.Name = "template_gorupbox";
            this.template_gorupbox.Size = new System.Drawing.Size(432, 426);
            this.template_gorupbox.TabIndex = 1;
            this.template_gorupbox.TabStop = false;
            this.template_gorupbox.Text = "Шаблоны";
            // 
            // template_view
            // 
            this.template_view.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MainColumn});
            this.template_view.ContextMenuStrip = this.template_contextmenu;
            this.template_view.FullRowSelect = true;
            this.template_view.HideSelection = false;
            this.template_view.Location = new System.Drawing.Point(6, 29);
            this.template_view.MultiSelect = false;
            this.template_view.Name = "template_view";
            this.template_view.ShowGroups = false;
            this.template_view.Size = new System.Drawing.Size(420, 391);
            this.template_view.TabIndex = 7;
            this.template_view.UseCompatibleStateImageBehavior = false;
            this.template_view.View = System.Windows.Forms.View.List;
            this.template_view.SelectedIndexChanged += new System.EventHandler(this.template_view_SelectedIndexChanged);
            // 
            // MainColumn
            // 
            this.MainColumn.Text = "";
            // 
            // template_contextmenu
            // 
            this.template_contextmenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.template_contextmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.change_btn,
            this.delete_btn});
            this.template_contextmenu.Name = "template_contextmenu";
            this.template_contextmenu.Size = new System.Drawing.Size(232, 68);
            this.template_contextmenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.template_contextmenu_ItemClicked);
            // 
            // change_btn
            // 
            this.change_btn.Name = "change_btn";
            this.change_btn.Size = new System.Drawing.Size(231, 32);
            this.change_btn.Text = "Изменить шаблон";
            this.change_btn.Click += new System.EventHandler(this.change_btn_Click);
            // 
            // delete_btn
            // 
            this.delete_btn.Name = "delete_btn";
            this.delete_btn.Size = new System.Drawing.Size(231, 32);
            this.delete_btn.Text = "Удалить шаблон";
            // 
            // find_groupbx
            // 
            this.find_groupbx.Controls.Add(this.find_txtbx);
            this.find_groupbx.Controls.Add(this.find_btn);
            this.find_groupbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.find_groupbx.Location = new System.Drawing.Point(455, 36);
            this.find_groupbx.Name = "find_groupbx";
            this.find_groupbx.Size = new System.Drawing.Size(338, 79);
            this.find_groupbx.TabIndex = 2;
            this.find_groupbx.TabStop = false;
            this.find_groupbx.Text = "Поиск";
            // 
            // find_txtbx
            // 
            this.find_txtbx.Location = new System.Drawing.Point(7, 32);
            this.find_txtbx.Name = "find_txtbx";
            this.find_txtbx.Size = new System.Drawing.Size(196, 37);
            this.find_txtbx.TabIndex = 2;
            this.find_txtbx.Text = "";
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
            // chosen_template_lbl
            // 
            this.chosen_template_lbl.AutoSize = true;
            this.chosen_template_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chosen_template_lbl.Location = new System.Drawing.Point(459, 135);
            this.chosen_template_lbl.Name = "chosen_template_lbl";
            this.chosen_template_lbl.Size = new System.Drawing.Size(199, 50);
            this.chosen_template_lbl.TabIndex = 7;
            this.chosen_template_lbl.Text = "Выбранный шаблон:\r\nШаблон не выбран ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UploadTemplateBtn,
            this.AddTemplateBtn,
            this.CreateNewTemplateBtn,
            this.UpdateTemplateBtn});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(821, 33);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // AddTemplateBtn
            // 
            this.AddTemplateBtn.Name = "AddTemplateBtn";
            this.AddTemplateBtn.Size = new System.Drawing.Size(174, 29);
            this.AddTemplateBtn.Text = "Добавить шаблон";
            this.AddTemplateBtn.Click += new System.EventHandler(this.AddTemplateBtn_Click);
            // 
            // UploadTemplateBtn
            // 
            this.UploadTemplateBtn.Name = "UploadTemplateBtn";
            this.UploadTemplateBtn.Size = new System.Drawing.Size(202, 29);
            this.UploadTemplateBtn.Text = "Создать эксперимент";
            this.UploadTemplateBtn.Click += new System.EventHandler(this.UploadTemplateBtn_Click);
            // 
            // CreateNewTemplateBtn
            // 
            this.CreateNewTemplateBtn.Name = "CreateNewTemplateBtn";
            this.CreateNewTemplateBtn.Size = new System.Drawing.Size(220, 29);
            this.CreateNewTemplateBtn.Text = "Создать новый шаблон";
            this.CreateNewTemplateBtn.Click += new System.EventHandler(this.CreateNewTemplateBtn_Click);
            // 
            // UpdateTemplateBtn
            // 
            this.UpdateTemplateBtn.Name = "UpdateTemplateBtn";
            this.UpdateTemplateBtn.Size = new System.Drawing.Size(190, 29);
            this.UpdateTemplateBtn.Text = "Обновить шаблоны";
            this.UpdateTemplateBtn.Click += new System.EventHandler(this.UpdateTemplateBtn_Click);
            // 
            // Template_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 464);
            this.Controls.Add(this.chosen_template_lbl);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.find_groupbx);
            this.Controls.Add(this.template_gorupbox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Template_menu";
            this.Text = "Выберите шаблон";
            this.template_gorupbox.ResumeLayout(false);
            this.template_contextmenu.ResumeLayout(false);
            this.find_groupbx.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox template_gorupbox;
        private System.Windows.Forms.GroupBox find_groupbx;
        private System.Windows.Forms.RichTextBox find_txtbx;
        private System.Windows.Forms.Button find_btn;
        private System.Windows.Forms.ContextMenuStrip template_contextmenu;
        private System.Windows.Forms.ToolStripMenuItem change_btn;
        private System.Windows.Forms.ToolStripMenuItem delete_btn;
        private System.Windows.Forms.ListView template_view;
        private System.Windows.Forms.ColumnHeader MainColumn;
        private System.Windows.Forms.Label chosen_template_lbl;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem AddTemplateBtn;
        private System.Windows.Forms.ToolStripMenuItem UploadTemplateBtn;
        private System.Windows.Forms.ToolStripMenuItem CreateNewTemplateBtn;
        private System.Windows.Forms.ToolStripMenuItem UpdateTemplateBtn;
    }
}