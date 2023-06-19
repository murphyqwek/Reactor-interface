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
using Microsoft.Office.Interop.Access.Dao;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Reactor_Interface.Classes.Message;
using Reactor_Interface.Classes;

namespace Reactor_Interface.Forms.Journal
{
    public partial class UploadingApplicienceDataMenu : Form
    {
        Chart _chart;
        ExperimentData _experiment;
        bool changed = false;
        string experimentPath;

        readonly Dictionary<string, string> SerieName = new Dictionary<string, string>
        {
            {"Пирометр", "temperature"},
            {"XRD", "xrd"},
            {"Осциллограф", "oscillograph"}
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

            if (_experiment.ApplianceData == null)
                return;

            for (int i = 0; i < AppViewList.Items.Count; i++)
            {
                var item = AppViewList.Items[i];
                string dataName = SerieName[item.Text];
                if (_experiment.ApplianceData.ContainsKey(dataName))
                    AppCheckBoxes[AppViewList.Items[i].Text].Checked = true;
            }

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
            string newXRDpath = "";
            string oldXRDpath = "";
            using (OpenFileDialog dlg = new OpenFileDialog())
            {

                dlg.Title = "Выберите файл рентгена";
                dlg.Filter = "Файл Ренгтена (*.txt)|*.txt|All files (*.*)|*.*";
                dlg.Multiselect = false;

                dlg.ShowDialog();
                if (string.IsNullOrEmpty(dlg.FileName))
                        return null;

                xrdPoints = XRDParser.ParseXRDToGraphPoints(dlg.FileName);
                if (Directory.Exists(experimentPath))
                {
                    newXRDpath = _experiment.Name + ExperimentSystem.AppFileName["xrd"];
                    oldXRDpath = dlg.FileName;
                }
            }

            if (xrdPoints == null)
            {
                MessageBox.Show("Файл повреждён", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return null;
            }

            if (newXRDpath != "")
            {
                newXRDpath = Path.Combine(experimentPath, newXRDpath);
                if (File.Exists(newXRDpath))
                    File.Delete(newXRDpath);
                File.Copy(oldXRDpath, newXRDpath);
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

        private void AppViewList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            
        }

        private void UploadXRDData(ListViewItem item, Dictionary<string, ApplianceData> experimentData, string serieName)
        {
            var data = GetXRDData();
            if (data != null)
            {
                if (experimentData.ContainsKey(serieName))
                    experimentData[serieName] = data;
                else
                    experimentData.Add(serieName, data);
                _experiment.SetNewApplianceData(experimentData);
                UploadedMessageBoxShow();
                changed = true;
                item.Checked = true;
                AppCheckBoxes[item.Text].Checked = true;
            }
            else
                item.Checked = false;
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
                UploadXRDData(item, experimentData, serieName);
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