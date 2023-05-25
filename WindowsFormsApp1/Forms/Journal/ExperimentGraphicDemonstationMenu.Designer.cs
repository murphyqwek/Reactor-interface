namespace Reactor_Interface.Forms.Journal
{
    partial class ExperimentGraphicDemonstationMenu
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExperimentGraphicDemonstationMenu));
            this.Graphic = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.DataStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.температураToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.среднийТокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.токToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.шагToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.XRDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.Graphic)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Graphic
            // 
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.CursorY.IsUserSelectionEnabled = true;
            chartArea1.Name = "ExperimentChartArea";
            chartArea2.Name = "HiddenSeriesArea";
            chartArea2.Visible = false;
            this.Graphic.ChartAreas.Add(chartArea1);
            this.Graphic.ChartAreas.Add(chartArea2);
            this.Graphic.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "ExperimentLegend";
            this.Graphic.Legends.Add(legend1);
            this.Graphic.Location = new System.Drawing.Point(0, 38);
            this.Graphic.Name = "Graphic";
            series1.BorderWidth = 3;
            series1.ChartArea = "HiddenSeriesArea";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Red;
            series1.IsVisibleInLegend = false;
            series1.Legend = "ExperimentLegend";
            series1.LegendText = "Температура";
            series1.Name = "temperature";
            series2.BorderWidth = 3;
            series2.ChartArea = "HiddenSeriesArea";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.MidnightBlue;
            series2.IsVisibleInLegend = false;
            series2.Legend = "ExperimentLegend";
            series2.LegendText = "Средний Ток";
            series2.Name = "aver_tok";
            series3.BorderWidth = 3;
            series3.ChartArea = "HiddenSeriesArea";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.SkyBlue;
            series3.IsVisibleInLegend = false;
            series3.Legend = "ExperimentLegend";
            series3.LegendText = "Ток";
            series3.Name = "tok";
            series4.BorderWidth = 3;
            series4.ChartArea = "HiddenSeriesArea";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series4.Color = System.Drawing.Color.SaddleBrown;
            series4.IsVisibleInLegend = false;
            series4.Legend = "ExperimentLegend";
            series4.LegendText = "Шаг";
            series4.Name = "step";
            series5.BorderWidth = 3;
            series5.ChartArea = "HiddenSeriesArea";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Color = System.Drawing.Color.Indigo;
            series5.IsVisibleInLegend = false;
            series5.Legend = "ExperimentLegend";
            series5.LegendText = "XRD";
            series5.Name = "xrd";
            this.Graphic.Series.Add(series1);
            this.Graphic.Series.Add(series2);
            this.Graphic.Series.Add(series3);
            this.Graphic.Series.Add(series4);
            this.Graphic.Series.Add(series5);
            this.Graphic.Size = new System.Drawing.Size(946, 412);
            this.Graphic.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DataStripMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(946, 38);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // DataStripMenu
            // 
            this.DataStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.температураToolStripMenuItem,
            this.среднийТокToolStripMenuItem,
            this.токToolStripMenuItem,
            this.шагToolStripMenuItem,
            this.XRDToolStripMenuItem});
            this.DataStripMenu.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.DataStripMenu.Name = "DataStripMenu";
            this.DataStripMenu.Size = new System.Drawing.Size(114, 34);
            this.DataStripMenu.Text = "Данные:";
            this.DataStripMenu.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.DataStripMenu_DropDownItemClicked);
            // 
            // температураToolStripMenuItem
            // 
            this.температураToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.температураToolStripMenuItem.Name = "температураToolStripMenuItem";
            this.температураToolStripMenuItem.Size = new System.Drawing.Size(270, 36);
            this.температураToolStripMenuItem.Text = "Температура";
            // 
            // среднийТокToolStripMenuItem
            // 
            this.среднийТокToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.среднийТокToolStripMenuItem.Name = "среднийТокToolStripMenuItem";
            this.среднийТокToolStripMenuItem.Size = new System.Drawing.Size(270, 36);
            this.среднийТокToolStripMenuItem.Text = "Средний ток";
            // 
            // токToolStripMenuItem
            // 
            this.токToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.токToolStripMenuItem.Name = "токToolStripMenuItem";
            this.токToolStripMenuItem.Size = new System.Drawing.Size(270, 36);
            this.токToolStripMenuItem.Text = "Ток";
            // 
            // шагToolStripMenuItem
            // 
            this.шагToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.шагToolStripMenuItem.Name = "шагToolStripMenuItem";
            this.шагToolStripMenuItem.Size = new System.Drawing.Size(270, 36);
            this.шагToolStripMenuItem.Text = "Шаг";
            // 
            // XRDToolStripMenuItem
            // 
            this.XRDToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.XRDToolStripMenuItem.Name = "XRDToolStripMenuItem";
            this.XRDToolStripMenuItem.Size = new System.Drawing.Size(270, 36);
            this.XRDToolStripMenuItem.Text = "XRD";
            // 
            // ExperimentGraphicDemonstationMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 450);
            this.Controls.Add(this.Graphic);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ExperimentGraphicDemonstationMenu";
            this.Text = "Просмотр данных эксперимента";
            ((System.ComponentModel.ISupportInitialize)(this.Graphic)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart Graphic;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem DataStripMenu;
        private System.Windows.Forms.ToolStripMenuItem температураToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem среднийТокToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem токToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem шагToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem XRDToolStripMenuItem;
    }
}