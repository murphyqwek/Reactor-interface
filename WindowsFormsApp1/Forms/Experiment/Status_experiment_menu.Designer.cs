namespace Reactor_Interface.Forms.Experiment
{
    partial class Status_experiment_menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Status_experiment_menu));
            this.progress_bar = new System.Windows.Forms.ProgressBar();
            this.proccess_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progress_bar
            // 
            this.progress_bar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progress_bar.ForeColor = System.Drawing.Color.Chartreuse;
            this.progress_bar.Location = new System.Drawing.Point(12, 36);
            this.progress_bar.Name = "progress_bar";
            this.progress_bar.Size = new System.Drawing.Size(386, 34);
            this.progress_bar.TabIndex = 0;
            // 
            // proccess_lbl
            // 
            this.proccess_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.proccess_lbl.AutoSize = true;
            this.proccess_lbl.Location = new System.Drawing.Point(13, 10);
            this.proccess_lbl.Name = "proccess_lbl";
            this.proccess_lbl.Size = new System.Drawing.Size(196, 20);
            this.proccess_lbl.TabIndex = 1;
            this.proccess_lbl.Text = "Создание Excel таблицы";
            // 
            // Status_experiment_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 82);
            this.Controls.Add(this.proccess_lbl);
            this.Controls.Add(this.progress_bar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Status_experiment_menu";
            this.Text = "Загрузка эксперимента";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progress_bar;
        private System.Windows.Forms.Label proccess_lbl;
    }
}