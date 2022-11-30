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
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Graphic_menu));
            this.Graph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.save_graphic_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.какКартинкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.какExcelТаблицуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.Graph)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Graph
            // 
            this.Graph.BackColor = System.Drawing.SystemColors.Control;
            chartArea1.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea1.AxisX.MaximumAutoSize = 50F;
            chartArea1.AxisX.Title = "Время, мс";
            chartArea1.AxisX2.Title = "Сила тока, А";
            chartArea1.Name = "ChartArea1";
            chartArea1.ShadowColor = System.Drawing.Color.Red;
            this.Graph.ChartAreas.Add(chartArea1);
            this.Graph.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.BackColor = System.Drawing.SystemColors.Control;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.IsEquallySpacedItems = true;
            legend1.IsTextAutoFit = false;
            legend1.ItemColumnSeparator = System.Windows.Forms.DataVisualization.Charting.LegendSeparatorStyle.Line;
            legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;
            legend1.Name = "aver_st";
            legend1.ShadowColor = System.Drawing.Color.Red;
            legend1.TableStyle = System.Windows.Forms.DataVisualization.Charting.LegendTableStyle.Tall;
            legend2.BackColor = System.Drawing.SystemColors.Control;
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend2.ItemColumnSeparator = System.Windows.Forms.DataVisualization.Charting.LegendSeparatorStyle.Line;
            legend2.LegendItemOrder = System.Windows.Forms.DataVisualization.Charting.LegendItemOrder.SameAsSeriesOrder;
            legend2.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;
            legend2.MaximumAutoSize = 40F;
            legend2.Name = "st";
            legend2.Position.Auto = false;
            legend2.Position.Height = 6.375227F;
            legend2.Position.Width = 20F;
            legend2.Position.X = 20F;
            legend2.Position.Y = 3F;
            legend2.TableStyle = System.Windows.Forms.DataVisualization.Charting.LegendTableStyle.Tall;
            this.Graph.Legends.Add(legend1);
            this.Graph.Legends.Add(legend2);
            this.Graph.Location = new System.Drawing.Point(0, 42);
            this.Graph.Name = "Graph";
            this.Graph.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Red;
            series1.Legend = "aver_st";
            series1.LegendText = "Сила тока";
            series1.Name = "AT";
            series1.ShadowColor = System.Drawing.Color.Red;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            series2.Legend = "st";
            series2.LegendText = "Среднее напряжение";
            series2.Name = "T";
            this.Graph.Series.Add(series1);
            this.Graph.Series.Add(series2);
            this.Graph.Size = new System.Drawing.Size(1187, 548);
            this.Graph.TabIndex = 1;
            this.Graph.Text = "Графики";
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.save_graphic_btn});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1187, 42);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // save_graphic_btn
            // 
            this.save_graphic_btn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.какКартинкуToolStripMenuItem,
            this.какExcelТаблицуToolStripMenuItem});
            this.save_graphic_btn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.save_graphic_btn.Name = "save_graphic_btn";
            this.save_graphic_btn.Size = new System.Drawing.Size(230, 36);
            this.save_graphic_btn.Text = "Сохранить график";
            this.save_graphic_btn.Click += new System.EventHandler(this.save_graphic_btn_Click);
            // 
            // какКартинкуToolStripMenuItem
            // 
            this.какКартинкуToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.какКартинкуToolStripMenuItem.Name = "какКартинкуToolStripMenuItem";
            this.какКартинкуToolStripMenuItem.Size = new System.Drawing.Size(276, 36);
            this.какКартинкуToolStripMenuItem.Text = "Как картинку";
            // 
            // какExcelТаблицуToolStripMenuItem
            // 
            this.какExcelТаблицуToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.какExcelТаблицуToolStripMenuItem.Name = "какExcelТаблицуToolStripMenuItem";
            this.какExcelТаблицуToolStripMenuItem.Size = new System.Drawing.Size(276, 36);
            this.какExcelТаблицуToolStripMenuItem.Text = "Как Excel таблицу";
            // 
            // Graphic_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 590);
            this.Controls.Add(this.Graph);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Graphic_menu";
            this.Text = "Графики";
            ((System.ComponentModel.ISupportInitialize)(this.Graph)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart Graph;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem save_graphic_btn;
        private System.Windows.Forms.ToolStripMenuItem какКартинкуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem какExcelТаблицуToolStripMenuItem;
    }
}