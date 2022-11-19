namespace Reactor_Interface
{
    partial class Graphic_menu
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.graphic_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.graphic_chart)).BeginInit();
            this.SuspendLayout();
            // 
            // graphic_chart
            // 
            this.graphic_chart.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.graphic_chart.ChartAreas.Add(chartArea1);
            this.graphic_chart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.graphic_chart.Legends.Add(legend1);
            this.graphic_chart.Location = new System.Drawing.Point(0, 0);
            this.graphic_chart.Name = "graphic_chart";
            this.graphic_chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.graphic_chart.Series.Add(series1);
            this.graphic_chart.Size = new System.Drawing.Size(1187, 590);
            this.graphic_chart.TabIndex = 0;
            this.graphic_chart.Text = "График";
            // 
            // Graphic_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 590);
            this.Controls.Add(this.graphic_chart);
            this.Name = "Graphic_menu";
            this.Text = "Графики";
            ((System.ComponentModel.ISupportInitialize)(this.graphic_chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart graphic_chart;
    }
}