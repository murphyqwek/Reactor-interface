namespace Reactor_Interface.Forms.Journal.SerieMenus
{
    partial class GetTemplateMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetTemplateMenu));
            this.TemplateListBox = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // TemplateListBox
            // 
            this.TemplateListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TemplateListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TemplateListBox.HideSelection = false;
            this.TemplateListBox.Location = new System.Drawing.Point(0, 0);
            this.TemplateListBox.Name = "TemplateListBox";
            this.TemplateListBox.Size = new System.Drawing.Size(533, 242);
            this.TemplateListBox.TabIndex = 0;
            this.TemplateListBox.UseCompatibleStateImageBehavior = false;
            this.TemplateListBox.View = System.Windows.Forms.View.List;
            // 
            // GetTemplateMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 242);
            this.Controls.Add(this.TemplateListBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GetTemplateMenu";
            this.Text = "Выберите шаблон серии";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView TemplateListBox;
    }
}