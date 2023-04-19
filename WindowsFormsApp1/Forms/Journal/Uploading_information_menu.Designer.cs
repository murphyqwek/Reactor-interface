namespace Reactor_Interface.Forms.Journal
{
    partial class Uploading_information_menu
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
            this.uploading_bar = new System.Windows.Forms.ProgressBar();
            this.uploading_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // uploading_bar
            // 
            this.uploading_bar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.uploading_bar.Location = new System.Drawing.Point(12, 43);
            this.uploading_bar.Name = "uploading_bar";
            this.uploading_bar.Size = new System.Drawing.Size(442, 39);
            this.uploading_bar.TabIndex = 0;
            // 
            // uploading_lbl
            // 
            this.uploading_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.uploading_lbl.AutoSize = true;
            this.uploading_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.uploading_lbl.Location = new System.Drawing.Point(12, 15);
            this.uploading_lbl.Name = "uploading_lbl";
            this.uploading_lbl.Size = new System.Drawing.Size(156, 25);
            this.uploading_lbl.TabIndex = 1;
            this.uploading_lbl.Text = "Загрузка: 100%";
            // 
            // Uploading_information_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 94);
            this.Controls.Add(this.uploading_lbl);
            this.Controls.Add(this.uploading_bar);
            this.Name = "Uploading_information_menu";
            this.Text = "Загрузка эксперимента";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar uploading_bar;
        private System.Windows.Forms.Label uploading_lbl;
    }
}