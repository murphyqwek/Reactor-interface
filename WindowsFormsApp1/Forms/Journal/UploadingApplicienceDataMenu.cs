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

namespace Reactor_Interface.Forms.Journal
{
    public partial class UploadingApplicienceDataMenu : Form
    {
        Chart _chart;
        ExperimentData _experiment;
        bool changed = false;
        bool uploadingCheckState = false;

        readonly Dictionary<string, string> SerieName = new Dictionary<string, string>
        {
            {"Термометр", "temperature"},
            {"XRD", "xrd"}
        };

        public UploadingApplicienceDataMenu(Chart chart, ExperimentData experiment)
        {
            InitializeComponent();
            _chart = chart;
            _experiment = experiment;

            if (_experiment.ApplianceData == null)
                return;

            uploadingCheckState = true;
            for(int i = 0; i < appDataGetList.Items.Count; i++)
            {
                string item = appDataGetList.Items[i].ToString();
                string dataName = SerieName[item];
                if (_experiment.ApplianceData.ContainsKey(dataName))
                    appDataGetList.SetItemCheckState(i, CheckState.Checked);
            }
            uploadingCheckState = false;
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

        private ApplianceData GetXRDData()
        {
            List<GraphPoint> xrdPoints = new List<GraphPoint>();
            using (OpenFileDialog dlg = new OpenFileDialog())
            {

                dlg.Title = "Выберите файл рентгена";
                dlg.Filter = "Файл Ренгтена (*.txt)|*.txt|All files (*.*)|*.*";
                dlg.Multiselect = false;

                dlg.ShowDialog();
                if (string.IsNullOrEmpty(dlg.FileName))
                        return null;

                xrdPoints = XRDParser.ParseXRDToGraphPoints(dlg.FileName);
            }

            if (xrdPoints == null)
            {
                MessageBox.Show("Файл повреждён", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return null;
            }

            return new ApplianceData(xrdPoints, Color.DarkCyan, "XRD", "xrd");
        }

        private void UploadingApplicienceDataMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (changed)
                DialogResult = DialogResult.Yes;
            else
                DialogResult = DialogResult.No;
        }

        private void appDataGetList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (uploadingCheckState)
                return;

            var item = e.CurrentValue;
            string itemText = appDataGetList.Items[e.Index].ToString();

            var experimentData = _experiment.ApplianceData;
            string serieName = SerieName[itemText];

            e.NewValue = CheckState.Checked;

            if (experimentData == null)
                experimentData = new Dictionary<string, ApplianceData>();

            if (item == CheckState.Checked)
            {
                DialogResult result = DialogResult.Cancel;

                if (experimentData.ContainsKey(itemText))
                {
                    result = MessageBox.Show("Данные уже загружены. Вы хотите их презаписать?", "Внимание", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);

                    if (result == DialogResult.Yes)
                    {
                        var appData = experimentData[itemText];
                        if (itemText == "XRD")
                        {
                            var data = GetXRDData();
                            if (data != null)
                            {
                                experimentData[serieName] = data;
                                _experiment.SetNewApplianceData(experimentData);
                                changed = true;
                                UploadedMessageBoxShow();
                            }
                            e.NewValue = CheckState.Checked;
                            return;
                        }
                        experimentData[itemText] = GetNewApplianceData(appData.SerieColor, appData.LegendText, appData.SerieName);
                        _experiment.SetNewApplianceData(experimentData);
                        changed = true;
                        e.NewValue = CheckState.Checked;
                        UploadedMessageBoxShow();
                    }

                    return;
                }
            }
            else
            {
                if (itemText == "XRD")
                {
                    var data = GetXRDData();
                    if (data != null)
                    {
                        experimentData.Add(serieName, data);
                        _experiment.SetNewApplianceData(experimentData);
                        UploadedMessageBoxShow();
                        changed = true;
                        e.NewValue = CheckState.Checked;
                    }
                    return;
                }

                experimentData[serieName] = GetNewApplianceData(_chart.Series[serieName].Color,
                                                                _chart.Series[serieName].LegendText,
                                                                serieName);
                _experiment.SetNewApplianceData(experimentData);
                e.NewValue = CheckState.Checked;
                UploadedMessageBoxShow();
                changed = true;
            }
        }

        private void UploadedMessageBoxShow()
        {
            MessageBox.Show("Данные загружены", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }
    }
}