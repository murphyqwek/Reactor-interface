using OfficeOpenXml.Packaging.Ionic.Zlib;
using Reactor_Interface.Classes;
using Reactor_Interface.Classes.Experiment;
using Reactor_Interface.Classes.Templates;
using Reactor_Interface.Classes.XRD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Reactor_Interface.Forms.Journal
{
    public partial class ExperimentGraphicDemonstationMenu : Form
    {
        ExperimentData _experiment;

        Dictionary<string, string> SeriesName = new Dictionary<string, string>()
        {
            { "Температура", "temperature" },
            { "Средний ток", "aver_tok" },
            { "Ток", "tok" },
            { "Шаг", "step" },
            { "XRD", "xrd" },
            { "Осциллограф", "oscillograph" }
        };

        const string ExperimentChartArea = "ExperimentChartArea";
        const string HiddenSerieArea = "HiddenSeriesArea";

        int windowSize = 35;
        int order = 3;
        int windowSizeLocal = 2, orderLocal = 2;
        int minDropHeight = 15, minDropDepth = -10;

        public ExperimentGraphicDemonstationMenu(ExperimentData experiment)
        {
            InitializeComponent();
            _experiment = experiment;
            foreach(string serie in experiment.ApplianceData.Keys)
            {
                try
                {
                    foreach (GraphPoint point in experiment.ApplianceData[serie].Data)
                    {
                        Graphic.Series[serie].Points.AddXY(point.X, point.Y);
                    }
                    Graphic.Series[serie].LegendText = experiment.ApplianceData[serie].LegendText;
                    Graphic.Series[serie].Color = experiment.ApplianceData[serie].SerieColor;
                }
                catch { }
            }

            DataStripMenu.Text = "Данные: " + Graphic.Series[0].LegendText;
            Graphic.Series[0].IsVisibleInLegend = true;
            Graphic.Series[0].ChartArea = ExperimentChartArea;
            Graphic.Series.Add(new Series("XRD Peaks"));
            Graphic.Series["XRD Peaks"].ChartType = SeriesChartType.Point;
            Graphic.Series["XRD Peaks"].Color = Color.Red;
            //Graphic.Series["XRD Peaks"].MarkerSize = 10000;
            Graphic.Series.Add(new Series("XRD Smooth"));
            Graphic.Series["XRD Smooth"].ChartType = SeriesChartType.FastLine;
            Graphic.Series["XRD Smooth"].Color = Color.Green;
            Graphic.Series["XRD Smooth"].Legend = "ExperimentLegend";
            Graphic.Series["XRD Smooth"].LegendText = "XRD. Сглаженный шум";
        }

        private void DataStripMenu_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Сделать серию" || e.ClickedItem.Text == "Коэфф")
                return;

            string serie = SeriesName[e.ClickedItem.Text];

            DataStripMenu.Text = "Данные: " + e.ClickedItem.Text;

            hideDataBtn.Visible = false;
            

            for(int i = 0; i < Graphic.Series.Count; i++)
            {
                string currentSerieName = Graphic.Series[i].Name;
                Graphic.Series[i].ChartArea = currentSerieName == serie ? ExperimentChartArea : HiddenSerieArea;
                Graphic.Series[i].IsVisibleInLegend = (currentSerieName == serie);
            }

            if(serie == "oscillograph")
            {
                ShowOSCChart();
            }

            Graphic.ChartAreas[ExperimentChartArea].RecalculateAxesScale();
        }

        private void ShowOSCChart()
        {
            hideDataBtn.Visible = true;

            Graphic.Series["OSC_CH1"].ChartArea = ExperimentChartArea;
            Graphic.Series["OSC_CH2"].ChartArea = ExperimentChartArea;
            Graphic.Series["P"].ChartArea = ExperimentChartArea;

            Graphic.Series["OSC_CH1"].IsVisibleInLegend = true;
            Graphic.Series["OSC_CH2"].IsVisibleInLegend = true;
            Graphic.Series["P"].IsVisibleInLegend = true;
        }

        private void hideDataBtn_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string serieName = e.ClickedItem.Name;
            bool state = !Graphic.Series[serieName].IsVisibleInLegend;

            Graphic.Series[serieName].ChartArea = state ? ExperimentChartArea : HiddenSerieArea;
            Graphic.Series[serieName].IsVisibleInLegend = state;
        }

        private void FindPeaksBtn_Click(object sender, EventArgs e)
        {
            if(order >= windowSize)
            {
                ErrorMessage.Show("Ордер >= windowsSize");
                return;
            }
            Graphic.Series["XRD Peaks"].ChartArea = ExperimentChartArea;
            Graphic.Series["XRD Smooth"].ChartArea = ExperimentChartArea;
            XRDParser.SetPeaks(ref Graphic, _experiment.ApplianceData["xrd"].Data, windowSize, order, minDropHeight, minDropDepth, windowSizeLocal, orderLocal);
        }

        private void показатьспрятатьXRDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphic.Series["xrd"].Color = Graphic.Series["xrd"].Color == Color.Transparent ? Color.Blue : Color.Transparent;
        }

        private int getValue()
        {
            using (InputFormMenu menu = new InputFormMenu("Window Size", ""))
            {
                menu.ShowDialog(this);

                int i = 0;
                if (Int32.TryParse(menu.OutputValue, out i))
                    return i;
                else
                    return -1;
            }
        }

        private void winowSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            windowSize = getValue();
            if(windowSize == -1)
            {
                ErrorMessage.Show("Халял!!!");
                windowSize = 0;
            }
            winowSizeToolStripMenuItem.Text = "WindowSize: " + windowSize.ToString();
        }

        private void orderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            order = getValue();
            if (order == -1)
            {
                ErrorMessage.Show("Халял!!!");
                order = 0;
            }
            orderToolStripMenuItem.Text = "Order: " + order.ToString();
        }

        private void SaveImage(int imageIndex, string experimentName)
        {
            string FolderPath = "D:\\XRD Parsed";
            Graphic.SaveImage(Path.Combine(FolderPath, imageIndex.ToString() + " (" + experimentName + ").png"), ChartImageFormat.Png);
        }

        private void CheckSerie_Click(object sender, EventArgs e)
        {
            string FileFolder = "C:\\Users\\qweka\\Desktop\\ИСХОДНЫЕ МАТЕРИАЛЫ";
            int i = 1;
            SaveImage(i, "SimpleMovingAvarage");
            return;
            foreach(string path in Directory.GetDirectories(FileFolder))
            {
                string ExperimentName = Path.GetFileNameWithoutExtension(path);
                string FullPath = Path.Combine(path, ExperimentName + ".txt");
                if (File.Exists(FullPath))
                {
                    Graphic.Series["xrd"].Points.Clear();
                    Graphic.Series["XRD Peaks"].Points.Clear();
                    Graphic.Series["XRD Smooth"].Points.Clear();
                    Graphic.Series["XRD Peaks"].ChartArea = ExperimentChartArea;
                    Graphic.Series["XRD Smooth"].ChartArea = ExperimentChartArea;
                    Console.WriteLine(FullPath);
                    var points = XRDParser.ParseXRDToGraphPoints(FullPath);
                    foreach (GraphPoint point in points)
                    {
                        Graphic.Series["xrd"].Points.AddXY(point.X, point.Y);
                    }
                    XRDParser.SetPeaks(ref Graphic, points, windowSize, order, minDropHeight, minDropDepth, windowSizeLocal, orderLocal);
                    SaveImage(i, ExperimentName);
                    Graphic.Series["xrd"].Color = Graphic.Series["xrd"].Color == Color.Transparent ? Color.Blue : Color.Transparent;
                    i++;
                    SaveImage(i, ExperimentName);
                    Graphic.Series["xrd"].Color = Graphic.Series["xrd"].Color == Color.Transparent ? Color.Blue : Color.Transparent;
                    i++;
                    //return;
                }
                SaveKoeff();
            }

            SuccesMessage.Show("Finished");
        }

        private void SaveKoeff()
        {
            using (StreamWriter writer = new StreamWriter("D:\\XRD Parsed\\koeff.txt"))
            {
                writer.WriteLine(string.Format("MinDropHeight = {0}, MinDropDepth = {1}", minDropHeight, minDropDepth));
                writer.WriteLine("Window Size = " + windowSize.ToString() + " Order = " + order.ToString());
            }
        }

        private void коэффToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(XRDKoeffMenu menu = new XRDKoeffMenu(windowSizeLocal, orderLocal, minDropHeight, minDropDepth))
            {
                menu.ShowDialog();
                if (menu.finished == false)
                {
                    ErrorMessage.Show("Ошибка коэффициентов");
                    return;
                }
                windowSizeLocal = menu.windowSizeLocal;
                orderLocal = menu.orderLocal;
                minDropHeight = menu.minPeakSize;
                minDropDepth = menu.procent;
            }
        }
    }
}
