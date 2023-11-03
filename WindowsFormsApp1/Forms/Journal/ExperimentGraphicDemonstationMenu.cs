using OfficeOpenXml.ConditionalFormatting;
using OfficeOpenXml.Packaging.Ionic.Zlib;
using Reactor_Interface.Classes;
using Reactor_Interface.Classes.Experiment;
using Reactor_Interface.Classes.Message;
using Reactor_Interface.Classes.Oscillograph;
using Reactor_Interface.Classes.Templates;
using Reactor_Interface.Classes.XRD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        string _experimentFilePath;

        Dictionary<string, string> SeriesName = new Dictionary<string, string>()
        {
            { "Температура", "temperature" },
            { "Средний ток", "aver_tok" },
            { "Ток", "tok" },
            { "Шаг", "step" },
            { "XRD", "xrd" },
            { "Осциллограф", "oscillograph" }
        };

        Dictionary<string, string[]> AxisLabel = new Dictionary<string, string[]>()
        {
            { "xrd", new string[] { "Интеснивность, у. е.", "2θ градусы" } },
            { "temperature", new string[] { "Температура, °C", "Время, мс" } }
        };

        const string ExperimentChartArea = "ExperimentChartArea";
        const string HiddenSerieArea = "HiddenSeriesArea";

        int windowSize = 35;
        int order = 3;
        int windowSizeTok = 8, orderTok = 3;
        int windowSizeVolt = 35, orderVolt = 3;

        public ExperimentGraphicDemonstationMenu(ExperimentData experiment, string experimentFilePath)
        {
            InitializeComponent();
            _experiment = experiment;
            _experimentFilePath = experimentFilePath;
            if (!_experiment.ApplianceData.ContainsKey("kVtH") && _experiment.ApplianceData.ContainsKey("OSC_CH1"))
            {
                var kVtHSerie = OscillographParser.CountKVtHSerie(_experiment.ApplianceData["OSC_CH1"].Data,
                                                              _experiment.ApplianceData["OSC_CH2"].Data);
                ExperimentSystem.UploadApplianceData(kVtHSerie, Color.FromArgb(0, 255, 157),
                                                                 "Потребление энергии, кВт*ч", "oscillograph", "kVtH", ref _experiment);
                ExperimentSystem.SaveExperiment(experiment, experimentFilePath);
            }
            foreach(string serie in _experiment.ApplianceData.Keys)
            {
                try
                {
                    foreach (GraphPoint point in _experiment.ApplianceData[serie].Data)
                    {
                        Graphic.Series[serie].Points.AddXY(point.X, point.Y);
                    }
                    Graphic.Series[serie].LegendText = _experiment.ApplianceData[serie].LegendText;
                    Graphic.Series[serie].Color = _experiment.ApplianceData[serie].SerieColor;
                }
                catch { }
            }

            DataStripMenu.Text = "Данные: " + Graphic.Series[0].LegendText;
            Graphic.Series[0].IsVisibleInLegend = true;
            Graphic.Series[0].ChartArea = ExperimentChartArea;
            /*
            Graphic.Series.Add(new Series("XRD Peaks"));
            Graphic.Series["XRD Peaks"].ChartType = SeriesChartType.Point;
            Graphic.Series["XRD Peaks"].Color = Color.Red;
            Graphic.Series["XRD Peaks"].LegendText = "Максимальная точка пика";
            Graphic.Series["XRD Peaks"].BorderWidth = 3;
            Graphic.Series.Add(new Series("XRD Smooth"));
            Graphic.Series["XRD Smooth"].ChartType = SeriesChartType.FastLine;
            Graphic.Series["XRD Smooth"].Color = Color.Green;
            Graphic.Series["XRD Smooth"].Legend = "ExperimentLegend";
            Graphic.Series["XRD Smooth"].LegendText = "XRD. Сглаженный шум";
            Graphic.Series["XRD Smooth"].BorderWidth = 2;
            */
        }

        private void DataStripMenu_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Сделать скриншот графика")
            {
                SaveImage();
                return;
            }
            if (e.ClickedItem.Text == "Коэфф")
                return;

            string serie = SeriesName[e.ClickedItem.Text];

            DataStripMenu.Text = "Данные: " + e.ClickedItem.Text;

            hideDataBtn.Visible = false;
            

            for(int i = 0; i < Graphic.Series.Count; i++)
            {
                string currentSerieName = Graphic.Series[i].Name;
                Graphic.Series[i].ChartArea = currentSerieName == serie ? ExperimentChartArea : HiddenSerieArea;
                Graphic.Series[i].IsVisibleInLegend = (currentSerieName == serie);
                string[] axis;
                if (AxisLabel.TryGetValue(Graphic.Series[i].Name, out axis) && currentSerieName == serie)
                {
                    Graphic.ChartAreas[ExperimentChartArea].AxisX.Title = axis[1];
                    Graphic.ChartAreas[ExperimentChartArea].AxisY.Title = axis[0];
                }
            }
            Graphic.ChartAreas[ExperimentChartArea].AxisY2.Enabled = AxisEnabled.False;
            SmoothOSC.Visible = false;
            if (serie == "oscillograph")
            {
                ShowOSCChart();
                //Graphic.Series[serie].IsVisibleInLegend = false;
            }

            Graphic.ChartAreas[ExperimentChartArea].RecalculateAxesScale();
            Graphic.Series["xrd"].IsVisibleInLegend = false;
        }

        private void ShowOSCChart()
        {
            if (Graphic.Series["OSC_CH1"].Points.Count == 0)
            {
                hideDataBtn.Visible = false;
                SmoothOSC.Visible = false;
                UploadOriginalOSCButton.Visible = false;
            }
            else
            {
                hideDataBtn.Visible = true;
                SmoothOSC.Visible = true;
                UploadOriginalOSCButton.Visible = true;
            }
            Graphic.Series["OSC_CH1"].ChartArea = ExperimentChartArea;
            Graphic.Series["OSC_CH2"].ChartArea = ExperimentChartArea;
            Graphic.Series["P"].ChartArea = ExperimentChartArea;
            Graphic.Series["kVtH"].ChartArea = ExperimentChartArea;
            //Graphic.ChartAreas[ExperimentChartArea].AxisY2 = Graphic.ChartAreas[ExperimentChartArea].AxisY;
            Graphic.ChartAreas[ExperimentChartArea].AxisX.Title = "Время, с";
            Graphic.ChartAreas[ExperimentChartArea].AxisY.Title = "Напряжение, В\nМощность, кВт";
            Graphic.ChartAreas[ExperimentChartArea].AxisY2.Title = "Потребление тока, кВт*ч\nСила тока, А";
            Graphic.ChartAreas[ExperimentChartArea].AxisY2.IsMarginVisible = true;
            Graphic.ChartAreas[ExperimentChartArea].AxisY2.Enabled = AxisEnabled.True;
            Graphic.ChartAreas[ExperimentChartArea].AxisY2.LineColor = Color.Transparent;
            Graphic.ChartAreas[ExperimentChartArea].AxisY2.TitleFont = Graphic.ChartAreas[ExperimentChartArea].AxisY.TitleFont;
            Graphic.ChartAreas[ExperimentChartArea].AxisY2.LabelStyle.Font = Graphic.ChartAreas[ExperimentChartArea].AxisY.LabelStyle.Font;
            Graphic.ChartAreas[ExperimentChartArea].AxisY2.LabelAutoFitMaxFontSize = Graphic.ChartAreas[ExperimentChartArea].AxisY.LabelAutoFitMaxFontSize;
            Graphic.ChartAreas[ExperimentChartArea].AxisY2.LabelAutoFitMinFontSize = Graphic.ChartAreas[ExperimentChartArea].AxisY2.LabelAutoFitMaxFontSize;
            Graphic.Series["OSC_CH1"].IsVisibleInLegend = true;
            Graphic.Series["OSC_CH2"].IsVisibleInLegend = true;
            Graphic.Series["P"].IsVisibleInLegend = true;
            Graphic.Series["kVtH"].IsVisibleInLegend = true;
        }

        private void hideDataBtn_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string serieName = e.ClickedItem.Name;
            bool state = !Graphic.Series[serieName].IsVisibleInLegend;

            Graphic.Series[serieName].ChartArea = state ? ExperimentChartArea : HiddenSerieArea;
            Graphic.Series[serieName].IsVisibleInLegend = state;
            var item = menuStrip1.Items.Find(serieName, true)[0] as ToolStripMenuItem;
            item.Checked = serieName == "kVtH" ? state : !state;
        }

        private void FindPeaksBtn_Click(object sender, EventArgs e)
        {
            if(order >= windowSize)
            {
                ErrorMessage.Show("Ордер >= windowsSize");
                return;
            }
            if (Graphic.Series["xrd"].ChartArea == ExperimentChartArea)
            {
                Graphic.Series["XRD Peaks"].ChartArea = ExperimentChartArea;
                Graphic.Series["XRD Smooth"].ChartArea = ExperimentChartArea;
                Graphic.Series["xrd"].LegendText = "Дифрактограмма окалины";
                //Graphic.Series["XRD Peaks"].IsVisibleInLegend = true;
                //Graphic.Series["XRD Smooth"].IsVisibleInLegend = true;
                Graphic.Series["xrd"].IsVisibleInLegend = false;
                Graphic.Series["XRD Smooth"].LegendText = "Массив экстремумов, обработанный функцией Гаусса";
                
                XRDParser.SetPeaks(ref Graphic, _experiment.ApplianceData["xrd"].Data, windowSize, order, windowSizeVolt, orderVolt, windowSizeTok, orderTok);
                //SaveGraphPointFile.CreateExcelExperiment("C:\\Data\\DiffArray(Гаусс).xlsx", points);
            }
            else
            {
                /*
                var oscPaesed = OscillographParser.SmoothOscillograph(null, _experiment.ApplianceData["OSC_CH1"].Data, _experiment.ApplianceData["OSC_CH2"].Data, order, windowSize);
                putGraphPointToChart(oscPaesed[0], "OSC_CH1");
                putGraphPointToChart(oscPaesed[1], "OSC_CH2");
                putGraphPointToChart(oscPaesed[2], "P");
                string FolderPath = "D:\\XRD Parsed\\OSC";
                Graphic.SaveImage(Path.Combine(FolderPath, "10.png"), ChartImageFormat.Png);
                ParseOSC();*/
                //SaveGraphPointFile.CreateExcelExperiment("C:\\Data\\Температура.xls", GetPoints("temperature"));
            }
        }

        private List<GraphPoint> GetPoints(string serie)
        {
            List<GraphPoint> points = new List<GraphPoint>();
            for (int i = 0; i < Graphic.Series[serie].Points.Count; i++)
            {
                points.Add(new GraphPoint(Graphic.Series[serie].Points[i].XValue, Graphic.Series[serie].Points[i].YValues[0]));
            }
            return points;
        }

        public void ParseOSC()
        {
            List<OscillographParser.FilterMethod> filterMethods = new List<OscillographParser.FilterMethod>()
            {
                SimpleMovingAvarege.Filter,
                ExponentialMovingAvarage.Calculate,
                MedianFilter.ApplyMedianFilter,
            };
            string[] series = new string[] { "OSC_CH1", "OSC_CH2", "P"};
            for (int i = 0; i < filterMethods.Count; i++)
            {
                //var oscPaesed = OscillographParser.SmoothOscillograph(null, _experiment.ApplianceData["OSC_CH1"].Data, _experiment.ApplianceData["OSC_CH2"].Data, order, windowSize);
                //putGraphPointToChart(oscPaesed[0], "OSC_CH1");
                //putGraphPointToChart(oscPaesed[1], "OSC_CH2");
                //putGraphPointToChart(oscPaesed[2], "P");
                string FolderPath = "D:\\XRD Parsed\\OSC";
                foreach(string serie in series)
                {
                    var points = GetPoints(serie);
                    SaveGraphPointFile.CreateExcelExperiment("C:\\Data\\Осциллограф\\Исходные данные" + serie + ".xls", points);
                }
                break;
                //Graphic.SaveImage(Path.Combine(FolderPath, i.ToString() + ".png"), ChartImageFormat.Png);
            }
        }

        private void putGraphPointToChart(List<GraphPoint> points, string Serie)
        {
            Graphic.Series[Serie].Points.Clear();
            foreach(var point in points)
            {
                Graphic.Series[Serie].Points.AddXY(point.X, point.Y);
            }
        }

        private void показатьспрятатьXRDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphic.Series["xrd"].Color = Graphic.Series["xrd"].Color == Color.Transparent ? Color.Blue : Color.Transparent;
            Graphic.Series["xrd"].IsVisibleInLegend = false;//Graphic.Series["xrd"].Color != Color.Transparent;
            Graphic.Series["XRD Peaks"].IsVisibleInLegend = false;
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

        private void SaveImage()
        {
            using(SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                DataStripMenu.HideDropDown();
                saveFileDialog.FileName = string.Format("Скриншот графика({0})", DataStripMenu.Text.Split(' ')[1]);
                saveFileDialog.DefaultExt = "png";
                saveFileDialog.ValidateNames = true;
                saveFileDialog.Filter = "Png Image (.png)|*.png";
                var save = saveFileDialog.ShowDialog();

                if (save != DialogResult.OK)
                    return;

                try
                {
                    Graphic.SaveImage(saveFileDialog.FileName, ChartImageFormat.Png);
                    if (ConfirmMessageBox.Show("График сохранен. Открыть папку скриншота?", "Успешно", MessageBoxIcon.Information))
                    {
                        Process.Start("explorer.exe", Path.GetDirectoryName(saveFileDialog.FileName));
                    }
                }
                catch
                {
                    ErrorMessage.Show("Невозможно сохранить график");
                }
            }
        }

        private void CheckSerie_Click(object sender, EventArgs e)
        {
            SaveImage();
        }

        private void SmoothOSC_Click(object sender, EventArgs e)
        {
            if (!UpdateCoeffs())
                return;

            if(Math.Max(orderTok, orderVolt) > 5)
            {
                if (!ConfirmMessageBox.Show("Степень полинома высокая. Фильтрация может занять очень много времени.\nВы уверены в данных коэффициентаъ?"))
                    return;
            }

            var oscParsed = OscillographParser.SmoothOscillograph(_experiment.ApplianceData["OSC_CH1"].Data, 
                                                                  _experiment.ApplianceData["OSC_CH2"].Data,
                                                                  windowSizeTok, orderTok,
                                                                  windowSizeVolt, orderVolt);
            putGraphPointToChart(oscParsed[0], "OSC_CH1");
            putGraphPointToChart(oscParsed[1], "OSC_CH2");
            putGraphPointToChart(oscParsed[2], "P");
            putGraphPointToChart(oscParsed[3], "kVtH");
            SaveOSCGraphic.Visible = true;
            SuccesMessage.Show("Данные графика сглажены");
        }

        private void SaveKoeff()
        {
            using (StreamWriter writer = new StreamWriter("D:\\XRD Parsed\\koeff.txt"))
            {
                writer.WriteLine(string.Format("MinDropHeight = {0}, MinDropDepth = {1}", windowSizeVolt, orderVolt));
                writer.WriteLine("Window Size = " + windowSize.ToString() + " Order = " + order.ToString());
            }
        }

        private void UploadOriginalOSCButton_Click(object sender, EventArgs e)
        {
            string originalOSCData = Path.Combine(_experimentFilePath, _experiment.Name + " (Осциллограф).csv");
            if (!File.Exists(originalOSCData))
            {
                ErrorMessage.Show("Исходные данные отсутствуют в папке эксперимента");
                return;
            }

            var data = UploadingApplicienceDataMenu.GetOSCData(_experimentFilePath, _experiment, false, originalOSCData);

            foreach(var appData in data)
            {
                _experiment.ApplianceData[appData.Key] = appData.Value;
                putGraphPointToChart(appData.Value.Data, appData.Key);
            }

            ExperimentSystem.SaveExperiment(_experiment, _experimentFilePath);
        }

        private void SaveOSCGraphic_Click(object sender, EventArgs e)
        {
            foreach(string serie in new string[] {"OSC_CH1", "OSC_CH2", "P", "kVtH" })
            {
                ApplianceData newApp = new ApplianceData(GetPoints(serie),
                                                         _experiment.ApplianceData[serie].SerieColor,
                                                         _experiment.ApplianceData[serie].LegendText,
                                                         _experiment.ApplianceData[serie].SerieName);
                _experiment.ApplianceData[serie] = newApp;
            }
            ExperimentSystem.SaveExperiment(_experiment, _experimentFilePath);
            SuccesMessage.Show("График сохранён");
            SaveOSCGraphic.Visible = false;
        }

        private void Graphic_AxisViewChanged(object sender, ViewEventArgs e)
        {
            Graphic.ChartAreas[ExperimentChartArea].AxisY2.ScaleView = Graphic.ChartAreas[ExperimentChartArea].AxisY.ScaleView;
            /*Graphic.ChartAreas[ExperimentChartArea].AxisY2.Minimum = Graphic.ChartAreas[ExperimentChartArea].AxisY.ScaleView.ViewMinimum;
            Graphic.ChartAreas[ExperimentChartArea].AxisY2.Maximum = Graphic.ChartAreas[ExperimentChartArea].AxisY.ScaleView.ViewMaximum;
            Graphic.ChartAreas[ExperimentChartArea].AxisY2.Interval = Graphic.ChartAreas[ExperimentChartArea].AxisY.Interval;
            Graphic.ChartAreas[ExperimentChartArea].AxisY2.IntervalOffset = Graphic.ChartAreas[ExperimentChartArea].AxisY.IntervalOffset;
            */Graphic.ChartAreas[ExperimentChartArea].AxisY2.IsMarginVisible = true;
        }

        private void SaveGraphicImageButton_Click(object sender, EventArgs e)
        {
            SaveImage();
        }

        private void коэффToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateCoeffs();
        }

        private bool UpdateCoeffs()
        {
            using (XRDKoeffMenu menu = new XRDKoeffMenu(windowSizeTok, orderTok, windowSizeVolt, orderVolt))
            {
                var result = menu.ShowDialog();
                if (result != DialogResult.Yes)
                    return false;

                if (menu.finished == false)
                {
                    ErrorMessage.Show("Ошибка коэффициентов");
                    return false;
                }
                if (menu.windowSizeTok <= menu.orderTok || menu.windowsSizeVolt <= menu.orderVolt)
                {
                    ErrorMessage.Show("Размер окна должен быть строго меньше степени полинома");
                    return false;
                }
                windowSizeTok = menu.windowSizeTok;
                orderTok = menu.orderTok;
                windowSizeVolt = menu.windowsSizeVolt;
                orderVolt = menu.orderVolt;
            }
            return true;
        }
    }
}
/*
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
                    XRDParser.SetPeaks(ref Graphic, points, windowSize, order, windowSizeVolt, orderVolt, windowSizeTok, orderTok);
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
*/