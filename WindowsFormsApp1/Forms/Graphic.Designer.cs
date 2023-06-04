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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(57D, 290D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(100D, 100D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(120D, -3D);
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint5 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint6 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(28D, 90D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint7 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(140D, 34D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint8 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(150D, 290D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint9 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(200D, 53D);
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint10 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint11 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Graphic_menu));
            this.graphic_setting_toolbar = new System.Windows.Forms.ToolStripMenuItem();
            this.tok_menubtn = new System.Windows.Forms.ToolStripMenuItem();
            this.aver_tok_menubtn = new System.Windows.Forms.ToolStripMenuItem();
            this.temp_menu_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.step_menubtn = new System.Windows.Forms.ToolStripMenuItem();
            this.save_graphic_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.какКартинкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.какExcelТаблицуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.save_as_txt_file_stipbtn = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearGraphBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Graph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Graph)).BeginInit();
            this.SuspendLayout();
            // 
            // graphic_setting_toolbar
            // 
            this.graphic_setting_toolbar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.graphic_setting_toolbar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tok_menubtn,
            this.aver_tok_menubtn,
            this.temp_menu_btn,
            this.step_menubtn});
            this.graphic_setting_toolbar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.graphic_setting_toolbar.Name = "graphic_setting_toolbar";
            this.graphic_setting_toolbar.Size = new System.Drawing.Size(244, 36);
            this.graphic_setting_toolbar.Text = "Настройки графика";
            // 
            // tok_menubtn
            // 
            this.tok_menubtn.Checked = true;
            this.tok_menubtn.CheckOnClick = true;
            this.tok_menubtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tok_menubtn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tok_menubtn.Name = "tok_menubtn";
            this.tok_menubtn.Size = new System.Drawing.Size(234, 36);
            this.tok_menubtn.Tag = "tok";
            this.tok_menubtn.Text = "Ток";
            this.tok_menubtn.Click += new System.EventHandler(this.menubtn_Click);
            // 
            // aver_tok_menubtn
            // 
            this.aver_tok_menubtn.Checked = true;
            this.aver_tok_menubtn.CheckOnClick = true;
            this.aver_tok_menubtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.aver_tok_menubtn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.aver_tok_menubtn.Name = "aver_tok_menubtn";
            this.aver_tok_menubtn.Size = new System.Drawing.Size(234, 36);
            this.aver_tok_menubtn.Tag = "aver_tok";
            this.aver_tok_menubtn.Text = "Средний Ток";
            this.aver_tok_menubtn.Click += new System.EventHandler(this.menubtn_Click);
            // 
            // temp_menu_btn
            // 
            this.temp_menu_btn.Checked = true;
            this.temp_menu_btn.CheckOnClick = true;
            this.temp_menu_btn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.temp_menu_btn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.temp_menu_btn.Name = "temp_menu_btn";
            this.temp_menu_btn.Size = new System.Drawing.Size(234, 36);
            this.temp_menu_btn.Tag = "temperature";
            this.temp_menu_btn.Text = "Температура";
            this.temp_menu_btn.Click += new System.EventHandler(this.menubtn_Click);
            // 
            // step_menubtn
            // 
            this.step_menubtn.CheckOnClick = true;
            this.step_menubtn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.step_menubtn.Name = "step_menubtn";
            this.step_menubtn.Size = new System.Drawing.Size(234, 36);
            this.step_menubtn.Tag = "step";
            this.step_menubtn.Text = "Шаг";
            this.step_menubtn.Click += new System.EventHandler(this.menubtn_Click);
            // 
            // save_graphic_btn
            // 
            this.save_graphic_btn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.какКартинкуToolStripMenuItem,
            this.какExcelТаблицуToolStripMenuItem,
            this.save_as_txt_file_stipbtn});
            this.save_graphic_btn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.save_graphic_btn.Name = "save_graphic_btn";
            this.save_graphic_btn.Size = new System.Drawing.Size(230, 36);
            this.save_graphic_btn.Text = "Сохранить график";
            // 
            // какКартинкуToolStripMenuItem
            // 
            this.какКартинкуToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.какКартинкуToolStripMenuItem.Name = "какКартинкуToolStripMenuItem";
            this.какКартинкуToolStripMenuItem.Size = new System.Drawing.Size(299, 36);
            this.какКартинкуToolStripMenuItem.Text = "Как картинку";
            this.какКартинкуToolStripMenuItem.Click += new System.EventHandler(this.какКартинкуToolStripMenuItem_Click);
            // 
            // какExcelТаблицуToolStripMenuItem
            // 
            this.какExcelТаблицуToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.какExcelТаблицуToolStripMenuItem.Name = "какExcelТаблицуToolStripMenuItem";
            this.какExcelТаблицуToolStripMenuItem.Size = new System.Drawing.Size(299, 36);
            this.какExcelТаблицуToolStripMenuItem.Text = "Как Excel таблицу";
            this.какExcelТаблицуToolStripMenuItem.Click += new System.EventHandler(this.какExcelТаблицуToolStripMenuItem_Click);
            // 
            // save_as_txt_file_stipbtn
            // 
            this.save_as_txt_file_stipbtn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.save_as_txt_file_stipbtn.Name = "save_as_txt_file_stipbtn";
            this.save_as_txt_file_stipbtn.Size = new System.Drawing.Size(299, 36);
            this.save_as_txt_file_stipbtn.Text = "Как текстовый файл";
            this.save_as_txt_file_stipbtn.Click += new System.EventHandler(this.save_as_txt_file_stipbtn_Click);
            // 
            // ClearGraphBtn
            // 
            this.ClearGraphBtn.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ClearGraphBtn.Name = "ClearGraphBtn";
            this.ClearGraphBtn.Size = new System.Drawing.Size(217, 36);
            this.ClearGraphBtn.Text = "Очистить график";
            this.ClearGraphBtn.Click += new System.EventHandler(this.очиститьГрафикToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.graphic_setting_toolbar,
            this.save_graphic_btn,
            this.ClearGraphBtn});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1187, 40);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Graph
            // 
            this.Graph.BackColor = System.Drawing.SystemColors.Control;
            this.Graph.BorderlineColor = System.Drawing.Color.Transparent;
            this.Graph.BorderlineWidth = 0;
            chartArea1.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea1.AxisX.MaximumAutoSize = 50F;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.Title = "Время, мс";
            chartArea1.AxisX2.Title = "Сила тока, А";
            chartArea1.AxisY.Title = "Температура (°C)";
            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.CursorY.IsUserEnabled = true;
            chartArea1.CursorY.IsUserSelectionEnabled = true;
            chartArea1.Name = "temperature_area";
            chartArea2.AxisX.Minimum = 0D;
            chartArea2.AxisX.Title = "Время (мс)";
            chartArea2.AxisY.Title = "Сила тока (А)";
            chartArea2.CursorX.IsUserEnabled = true;
            chartArea2.CursorX.IsUserSelectionEnabled = true;
            chartArea2.CursorY.IsUserEnabled = true;
            chartArea2.CursorY.IsUserSelectionEnabled = true;
            chartArea2.Name = "tok_area";
            this.Graph.ChartAreas.Add(chartArea1);
            this.Graph.ChartAreas.Add(chartArea2);
            this.Graph.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Graph.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "temperature_legend";
            legend1.Position.Auto = false;
            legend1.Position.Height = 6.375227F;
            legend1.Position.Width = 14.50253F;
            legend1.Position.X = 3F;
            legend1.Position.Y = 90F;
            legend2.Alignment = System.Drawing.StringAlignment.Far;
            legend2.BackColor = System.Drawing.Color.Transparent;
            legend2.DockedToChartArea = "temperature_area";
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend2.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend2.MaximumAutoSize = 100F;
            legend2.Name = "tok_legend";
            legend2.Position.Auto = false;
            legend2.Position.Height = 6.375227F;
            legend2.Position.Width = 28.75211F;
            legend2.Position.X = 64.83216F;
            legend2.Position.Y = 90F;
            legend2.TableStyle = System.Windows.Forms.DataVisualization.Charting.LegendTableStyle.Wide;
            this.Graph.Legends.Add(legend1);
            this.Graph.Legends.Add(legend2);
            this.Graph.Location = new System.Drawing.Point(0, 40);
            this.Graph.Name = "Graph";
            this.Graph.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.BorderWidth = 3;
            series1.ChartArea = "temperature_area";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Red;
            series1.Legend = "temperature_legend";
            series1.LegendText = "Температура";
            series1.Name = "temperature";
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            series1.Points.Add(dataPoint3);
            series1.Points.Add(dataPoint4);
            series2.BorderWidth = 3;
            series2.ChartArea = "tok_area";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.MidnightBlue;
            series2.Legend = "tok_legend";
            series2.LegendText = "Средний ток";
            series2.MarkerBorderWidth = 3;
            series2.Name = "aver_tok";
            series2.Points.Add(dataPoint5);
            series2.Points.Add(dataPoint6);
            series2.Points.Add(dataPoint7);
            series2.Points.Add(dataPoint8);
            series2.Points.Add(dataPoint9);
            series3.BorderWidth = 3;
            series3.ChartArea = "tok_area";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.SkyBlue;
            series3.Legend = "tok_legend";
            series3.LegendText = "Ток";
            series3.Name = "tok";
            dataPoint10.IsEmpty = true;
            series3.Points.Add(dataPoint10);
            series4.BorderWidth = 5;
            series4.ChartArea = "temperature_area";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series4.Color = System.Drawing.Color.Transparent;
            series4.IsVisibleInLegend = false;
            series4.Legend = "tok_legend";
            series4.LegendText = "Шаг";
            series4.Name = "step";
            dataPoint11.IsEmpty = true;
            series4.Points.Add(dataPoint11);
            this.Graph.Series.Add(series1);
            this.Graph.Series.Add(series2);
            this.Graph.Series.Add(series3);
            this.Graph.Series.Add(series4);
            this.Graph.Size = new System.Drawing.Size(1187, 550);
            this.Graph.TabIndex = 1;
            this.Graph.Text = "Графики";
            // 
            // Graphic_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1187, 590);
            this.Controls.Add(this.Graph);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Graphic_menu";
            this.Text = "Графики";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Graphic_menu_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Graph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem graphic_setting_toolbar;
        private System.Windows.Forms.ToolStripMenuItem tok_menubtn;
        private System.Windows.Forms.ToolStripMenuItem aver_tok_menubtn;
        private System.Windows.Forms.ToolStripMenuItem step_menubtn;
        private System.Windows.Forms.ToolStripMenuItem temp_menu_btn;
        private System.Windows.Forms.ToolStripMenuItem save_graphic_btn;
        private System.Windows.Forms.ToolStripMenuItem какКартинкуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem какExcelТаблицуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClearGraphBtn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.DataVisualization.Charting.Chart Graph;
        private System.Windows.Forms.ToolStripMenuItem save_as_txt_file_stipbtn;
    }
}