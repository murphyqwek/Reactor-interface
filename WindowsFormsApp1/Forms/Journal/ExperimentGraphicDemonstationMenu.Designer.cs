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
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExperimentGraphicDemonstationMenu));
            this.Graphic = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.DataStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.температураToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.среднийТокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.токToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.шагToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.XRDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oscDataBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveGraphicImageButton = new System.Windows.Forms.ToolStripMenuItem();
            this.коэффToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideDataBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.OSC_CH1 = new System.Windows.Forms.ToolStripMenuItem();
            this.OSC_CH2 = new System.Windows.Forms.ToolStripMenuItem();
            this.P = new System.Windows.Forms.ToolStripMenuItem();
            this.kVtH = new System.Windows.Forms.ToolStripMenuItem();
            this.FindPeaksBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.SmoothOSC = new System.Windows.Forms.ToolStripMenuItem();
            this.UploadOriginalOSCButton = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveOSCGraphic = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.Graphic)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Graphic
            // 
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelAutoFitMaxFontSize = 16;
            chartArea1.AxisX.LabelAutoFitMinFontSize = 16;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.LabelAutoFitMaxFontSize = 16;
            chartArea1.AxisY.LabelAutoFitMinFontSize = 16;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea1.AxisY2.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.CursorY.IsUserSelectionEnabled = true;
            chartArea1.Name = "ExperimentChartArea";
            chartArea2.Name = "HiddenSeriesArea";
            chartArea2.Visible = false;
            this.Graphic.ChartAreas.Add(chartArea1);
            this.Graphic.ChartAreas.Add(chartArea2);
            this.Graphic.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.DockedToChartArea = "ExperimentChartArea";
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            legend1.IsTextAutoFit = false;
            legend1.Name = "ExperimentLegend";
            legend1.TableStyle = System.Windows.Forms.DataVisualization.Charting.LegendTableStyle.Wide;
            legend1.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Graphic.Legends.Add(legend1);
            this.Graphic.Location = new System.Drawing.Point(0, 40);
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
            series6.BorderWidth = 3;
            series6.ChartArea = "HiddenSeriesArea";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.IsVisibleInLegend = false;
            series6.Legend = "ExperimentLegend";
            series6.LegendText = "Напряжение";
            series6.Name = "OSC_CH1";
            series7.BorderWidth = 3;
            series7.ChartArea = "HiddenSeriesArea";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.IsVisibleInLegend = false;
            series7.Legend = "ExperimentLegend";
            series7.Name = "OSC_CH2";
            series8.BorderWidth = 3;
            series8.ChartArea = "HiddenSeriesArea";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series8.IsVisibleInLegend = false;
            series8.Legend = "ExperimentLegend";
            series8.Name = "P";
            series9.BorderWidth = 3;
            series9.ChartArea = "HiddenSeriesArea";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series9.IsVisibleInLegend = false;
            series9.Legend = "ExperimentLegend";
            series9.Name = "kVtH";
            this.Graphic.Series.Add(series1);
            this.Graphic.Series.Add(series2);
            this.Graphic.Series.Add(series3);
            this.Graphic.Series.Add(series4);
            this.Graphic.Series.Add(series5);
            this.Graphic.Series.Add(series6);
            this.Graphic.Series.Add(series7);
            this.Graphic.Series.Add(series8);
            this.Graphic.Series.Add(series9);
            this.Graphic.Size = new System.Drawing.Size(1060, 409);
            this.Graphic.TabIndex = 0;
            this.Graphic.AxisViewChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ViewEventArgs>(this.Graphic_AxisViewChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DataStripMenu,
            this.hideDataBtn,
            this.FindPeaksBtn,
            this.SmoothOSC,
            this.UploadOriginalOSCButton,
            this.SaveOSCGraphic});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1060, 40);
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
            this.XRDToolStripMenuItem,
            this.oscDataBtn,
            this.SaveGraphicImageButton,
            this.коэффToolStripMenuItem});
            this.DataStripMenu.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.DataStripMenu.Name = "DataStripMenu";
            this.DataStripMenu.Size = new System.Drawing.Size(114, 36);
            this.DataStripMenu.Text = "Данные:";
            this.DataStripMenu.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.DataStripMenu_DropDownItemClicked);
            // 
            // температураToolStripMenuItem
            // 
            this.температураToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.температураToolStripMenuItem.Name = "температураToolStripMenuItem";
            this.температураToolStripMenuItem.Size = new System.Drawing.Size(391, 38);
            this.температураToolStripMenuItem.Text = "Температура";
            // 
            // среднийТокToolStripMenuItem
            // 
            this.среднийТокToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.среднийТокToolStripMenuItem.Name = "среднийТокToolStripMenuItem";
            this.среднийТокToolStripMenuItem.Size = new System.Drawing.Size(391, 38);
            this.среднийТокToolStripMenuItem.Text = "Средний ток";
            // 
            // токToolStripMenuItem
            // 
            this.токToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.токToolStripMenuItem.Name = "токToolStripMenuItem";
            this.токToolStripMenuItem.Size = new System.Drawing.Size(391, 38);
            this.токToolStripMenuItem.Text = "Ток";
            // 
            // шагToolStripMenuItem
            // 
            this.шагToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.шагToolStripMenuItem.Name = "шагToolStripMenuItem";
            this.шагToolStripMenuItem.Size = new System.Drawing.Size(391, 38);
            this.шагToolStripMenuItem.Text = "Шаг";
            // 
            // XRDToolStripMenuItem
            // 
            this.XRDToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.XRDToolStripMenuItem.Name = "XRDToolStripMenuItem";
            this.XRDToolStripMenuItem.Size = new System.Drawing.Size(391, 38);
            this.XRDToolStripMenuItem.Text = "XRD";
            // 
            // oscDataBtn
            // 
            this.oscDataBtn.Name = "oscDataBtn";
            this.oscDataBtn.Size = new System.Drawing.Size(391, 38);
            this.oscDataBtn.Text = "Осциллограф";
            // 
            // SaveGraphicImageButton
            // 
            this.SaveGraphicImageButton.Name = "SaveGraphicImageButton";
            this.SaveGraphicImageButton.Size = new System.Drawing.Size(391, 38);
            this.SaveGraphicImageButton.Text = "Сделать скриншот графика";
            // 
            // коэффToolStripMenuItem
            // 
            this.коэффToolStripMenuItem.Name = "коэффToolStripMenuItem";
            this.коэффToolStripMenuItem.Size = new System.Drawing.Size(391, 38);
            this.коэффToolStripMenuItem.Text = "Коэфф";
            this.коэффToolStripMenuItem.Visible = false;
            this.коэффToolStripMenuItem.Click += new System.EventHandler(this.коэффToolStripMenuItem_Click);
            // 
            // hideDataBtn
            // 
            this.hideDataBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.hideDataBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OSC_CH1,
            this.OSC_CH2,
            this.P,
            this.kVtH});
            this.hideDataBtn.Name = "hideDataBtn";
            this.hideDataBtn.Size = new System.Drawing.Size(88, 34);
            this.hideDataBtn.Text = "Скрыть";
            this.hideDataBtn.Visible = false;
            this.hideDataBtn.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.hideDataBtn_DropDownItemClicked);
            // 
            // OSC_CH1
            // 
            this.OSC_CH1.Checked = true;
            this.OSC_CH1.CheckOnClick = true;
            this.OSC_CH1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OSC_CH1.Name = "OSC_CH1";
            this.OSC_CH1.Size = new System.Drawing.Size(263, 34);
            this.OSC_CH1.Text = "Напряжение";
            // 
            // OSC_CH2
            // 
            this.OSC_CH2.Checked = true;
            this.OSC_CH2.CheckOnClick = true;
            this.OSC_CH2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OSC_CH2.Name = "OSC_CH2";
            this.OSC_CH2.Size = new System.Drawing.Size(263, 34);
            this.OSC_CH2.Text = "Ток";
            // 
            // P
            // 
            this.P.Checked = true;
            this.P.CheckOnClick = true;
            this.P.CheckState = System.Windows.Forms.CheckState.Checked;
            this.P.Name = "P";
            this.P.Size = new System.Drawing.Size(263, 34);
            this.P.Text = "Мощность";
            // 
            // kVtH
            // 
            this.kVtH.Checked = true;
            this.kVtH.CheckState = System.Windows.Forms.CheckState.Checked;
            this.kVtH.Name = "kVtH";
            this.kVtH.Size = new System.Drawing.Size(263, 34);
            this.kVtH.Text = "Потребление тока";
            // 
            // FindPeaksBtn
            // 
            this.FindPeaksBtn.Name = "FindPeaksBtn";
            this.FindPeaksBtn.Size = new System.Drawing.Size(121, 34);
            this.FindPeaksBtn.Text = "Найти пики";
            this.FindPeaksBtn.Visible = false;
            this.FindPeaksBtn.Click += new System.EventHandler(this.FindPeaksBtn_Click);
            // 
            // SmoothOSC
            // 
            this.SmoothOSC.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.SmoothOSC.Name = "SmoothOSC";
            this.SmoothOSC.Size = new System.Drawing.Size(196, 34);
            this.SmoothOSC.Text = "Сгладить график";
            this.SmoothOSC.Visible = false;
            this.SmoothOSC.Click += new System.EventHandler(this.SmoothOSC_Click);
            // 
            // UploadOriginalOSCButton
            // 
            this.UploadOriginalOSCButton.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.UploadOriginalOSCButton.Name = "UploadOriginalOSCButton";
            this.UploadOriginalOSCButton.Size = new System.Drawing.Size(315, 34);
            this.UploadOriginalOSCButton.Text = "Загрузить исходные данные";
            this.UploadOriginalOSCButton.Visible = false;
            this.UploadOriginalOSCButton.Click += new System.EventHandler(this.UploadOriginalOSCButton_Click);
            // 
            // SaveOSCGraphic
            // 
            this.SaveOSCGraphic.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.SaveOSCGraphic.Name = "SaveOSCGraphic";
            this.SaveOSCGraphic.Size = new System.Drawing.Size(213, 34);
            this.SaveOSCGraphic.Text = "Сохранить график";
            this.SaveOSCGraphic.Visible = false;
            this.SaveOSCGraphic.Click += new System.EventHandler(this.SaveOSCGraphic_Click);
            // 
            // ExperimentGraphicDemonstationMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 449);
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
        private System.Windows.Forms.ToolStripMenuItem oscDataBtn;
        private System.Windows.Forms.ToolStripMenuItem hideDataBtn;
        private System.Windows.Forms.ToolStripMenuItem OSC_CH1;
        private System.Windows.Forms.ToolStripMenuItem OSC_CH2;
        private System.Windows.Forms.ToolStripMenuItem P;
        private System.Windows.Forms.ToolStripMenuItem FindPeaksBtn;
        private System.Windows.Forms.ToolStripMenuItem SaveGraphicImageButton;
        private System.Windows.Forms.ToolStripMenuItem коэффToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kVtH;
        private System.Windows.Forms.ToolStripMenuItem SmoothOSC;
        private System.Windows.Forms.ToolStripMenuItem UploadOriginalOSCButton;
        private System.Windows.Forms.ToolStripMenuItem SaveOSCGraphic;
    }
}