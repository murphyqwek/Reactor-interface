using Reactor_Interface.Classes.Experiment;
using Reactor_Interface.Classes.XRD;
using Reactor_Interface.Classes.Templates;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using Reactor_Interface.Classes.Message;
using Reactor_Interface.Classes;
using Reactor_Interface.Classes.Oscillograph;

namespace Reactor_Interface.Forms.Journal
{
    public partial class UploadingApplicienceDataMenu : Form
    {
        Chart _chart;
        ExperimentData _experiment;
        bool changed = false;
        string experimentPath;

        enum DataType
        {
            XRD,
            OSC,
            OSC_PIC
        }

        readonly Dictionary<string, string> SerieName = new Dictionary<string, string>
        {
            {"Пирометр", "temperature"},
            {"XRD", "xrd"},
            {"Осциллограф", "oscillograph"},
            {"Осциллограф(картинка)", "oscillograph(pic)"}
        };

        readonly Dictionary<string, CheckBox> AppCheckBoxes = new Dictionary<string, CheckBox>();

        public UploadingApplicienceDataMenu(Chart chart, ExperimentData experiment, string ExperimentPath)
        {
            InitializeComponent();
            _chart = chart;
            _experiment = experiment;
            experimentPath = ExperimentPath;

            AppCheckBoxes.Add("Пирометр", piroChBx);
            AppCheckBoxes.Add("XRD", xrdChBx);
            AppCheckBoxes.Add("Осциллограф", osciChBx);
            AppCheckBoxes.Add("Осциллограф(картинка)", oscPicChBx);

            if (_experiment.ApplianceData == null)
                return;

            for (int i = 0; i < AppViewList.Items.Count; i++)
            {
                var item = AppViewList.Items[i];
                string dataName = SerieName[item.Text];
                if (_experiment.ApplianceData.ContainsKey(dataName))
                    AppCheckBoxes[AppViewList.Items[i].Text].Checked = true;
            }

            if (_experiment.ApplianceData.ContainsKey("OSC_CH1"))
                osciChBx.Checked = true;

            if(ExperimentSystem.HasOSCPic(experiment, ExperimentPath))
                oscPicChBx.Checked = true;

        }

        private List<GraphPoint> GetPointsFromChart(string serieName)
        {
            List<GraphPoint> points = new List<GraphPoint>();

            foreach (var point in _chart.Series[serieName].Points)
                points.Add(new GraphPoint(point.XValue, point.YValues[0]));

            return points;
        }

        private ApplianceData GetNewApplianceData(Color SerieColor, string legendText, string serieName)
        {
            return new ApplianceData(GetPointsFromChart(serieName), SerieColor, legendText, serieName);
        }

        private Dictionary<string, ApplianceData> GetXRDData()
        {
            List<GraphPoint> xrdPoints;
            string oldXRDpath;

            oldXRDpath = XRDParser.GetXRDFilePath();

            if (oldXRDpath == null)
                return null;

            xrdPoints = XRDParser.ParseXRDToGraphPoints(oldXRDpath);

            string seriename = SerieName["XRD"];

            if (xrdPoints == null)
            {
                MessageBox.Show("Файл повреждён", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return null;
            }

            ExperimentSystem.MoveAppFileToExperimentDirectory(experimentPath, _experiment, oldXRDpath, SerieName["XRD"]);

            return new Dictionary<string, ApplianceData>(){
                {seriename, new ApplianceData(xrdPoints, Color.DarkCyan, "XRD", seriename) }
            };
        }

        private void UploadingApplicienceDataMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (changed)
                DialogResult = DialogResult.Yes;
            else
                DialogResult = DialogResult.No;
        }

        private void UploadData(ListViewItem item, Dictionary<string, ApplianceData> experimentData, DataType dataType)
        {
            Dictionary<string, ApplianceData> data = null;

            switch (dataType) 
            {
                case DataType.XRD:
                    data = GetXRDData();
                break;

                case DataType.OSC:
                    data = GetOSCData();
                break;

                case DataType.OSC_PIC:
                    GetOSCPic();
                    return;
            }

            if (data != null)
            {
                foreach (var appDataName in data.Keys)
                {
                    if (experimentData.ContainsKey(appDataName))
                        experimentData[appDataName] = data[appDataName];
                    else
                        experimentData.Add(appDataName, data[appDataName]);
                }
                _experiment.SetNewApplianceData(experimentData);
                UploadedMessageBoxShow();
                changed = true;
                item.Checked = true;
                AppCheckBoxes[item.Text].Checked = true;
            }
            else
                item.Checked = false;
        }

        private void GetOSCPic()
        {
            string oldOSCPicPath = OscillographParser.GetOSCPicPath();

            string seriename = SerieName["Осциллограф(картинка)"];

            ExperimentSystem.MoveAppFileToExperimentDirectory(experimentPath, _experiment, oldOSCPicPath, seriename);
            
            oscPicChBx.Checked = true;
            UploadedMessageBoxShow();
        }

        private Dictionary<string, ApplianceData> GetOSCData()
        {
            string oldOSCpath;

            oldOSCpath = OscillographParser.GetOSCFilePath();

            if (oldOSCpath == null)
                return null;

            var OSCSeries = OscillographParser.ParseOscillographToGraphPoints(oldOSCpath);

            if (OSCSeries == null)
            {
                MessageBox.Show("Файл повреждён", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return null;
            }

            string seriename = SerieName["Осциллограф"];

            ExperimentSystem.MoveAppFileToExperimentDirectory(experimentPath, _experiment, oldOSCpath, seriename);

            ApplianceData applianceData1 = new ApplianceData(OSCSeries[0], 
                                                            Color.FromArgb(255, 0, 165, 165), 
                                                            "Напряжение, В", seriename);

            ApplianceData applianceData2 = new ApplianceData(OSCSeries[1],
                                                            Color.FromArgb(255, 165, 165, 0),
                                                            "Ток, А", seriename);

            ApplianceData applianceData3 = new ApplianceData(OSCSeries[2],
                                                            Color.FromArgb(255, 248, 111, 3),
                                                            "Мощность, КВт", seriename);

            return new Dictionary<string, ApplianceData>() 
            { 
                { "OSC_CH1", applianceData1 },
                { "OSC_CH2", applianceData2 },
                { "P", applianceData3 },
            };
        }

        private void UploadedMessageBoxShow()
        {
            MessageBox.Show("Данные загружены", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private void appDataContextMenu_Opening(object sender, CancelEventArgs e)
        {
            if (AppViewList.SelectedIndices.Count == 0) 
            {
                e.Cancel = true;
                return;
            }

            int itemIndex = AppViewList.SelectedIndices[0];

            deleteDataBtn.Visible = false;
            rewriteDataBtn.Visible = false;

            if (AppCheckBoxes[AppViewList.Items[itemIndex].Text].Checked)
            {
                deleteDataBtn.Visible = true;
                rewriteDataBtn.Visible = true;
            }
            else
                e.Cancel = true;
        }

        private void AppViewList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            ListViewHitTestInfo info = AppViewList.HitTest(e.X, e.Y);
            ListViewItem item = info.Item;

            if (item.Checked == true)
                return;

            uploadAppData(item);
        }

        private void uploadAppData(ListViewItem item)
        {
            var experimentData = _experiment.ApplianceData;
            string serieName = SerieName[item.Text];

            if (experimentData == null)
                experimentData = new Dictionary<string, ApplianceData>();

            if (serieName == "xrd")
            {
                UploadData(item, experimentData, DataType.XRD);
                return;
            }
            
            if(serieName == "oscillograph")
            {
                UploadData(item, experimentData, DataType.OSC);
                return;
            }

            if(serieName == "oscillograph(pic)")
            {
                UploadData(item, experimentData, DataType.OSC_PIC);
                return;
            }

            experimentData[serieName] = GetNewApplianceData(_chart.Series[serieName].Color,
                                                            _chart.Series[serieName].LegendText,
                                                            serieName);
            _experiment.SetNewApplianceData(experimentData);
            item.Checked = true;
            AppCheckBoxes[item.Text].Checked = true;
            UploadedMessageBoxShow();
            changed = true;
        }

        private void deleteDataBtn_Click(object sender, EventArgs e)
        {
            if (!ConfirmMessageBox.Show("Вы действительно хотите удалить данные?"))
                return;

            changed = true;

            if (!Directory.Exists(experimentPath))
            {
                ErrorMessage.Show("Папка эксперимента была удалена");
                return;
            }

            ExperimentSystem.DeleteAppData(_experiment, experimentPath, SerieName[AppViewList.SelectedItems[0].Text]);

            AppCheckBoxes[AppViewList.SelectedItems[0].Text].Checked = false;

            SuccesMessage.Show("Данные были удалены");
        }

        private void rewriteDataBtn_Click(object sender, EventArgs e)
        {
            if (!ConfirmMessageBox.Show("Вы действительно хотите перезаписать данные?"))
                return;

            var item = AppViewList.SelectedItems[0];

            uploadAppData(item);
        }
    }
}