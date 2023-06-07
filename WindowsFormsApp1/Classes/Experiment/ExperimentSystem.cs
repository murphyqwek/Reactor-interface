using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web.UI;
using Reactor_Interface.Classes.Templates;
using WindowsFormsApp1.Classes;
using System.Windows.Forms;
using Reactor_Interface.Forms.Template;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using Reactor_Interface.Classes.GoogleAPI;

namespace Reactor_Interface.Classes.Experiment
{
    static class ExperimentSystem
    {
        public static readonly string experimentExtension = ".exp";

        public enum ExperimentStorePlace
        {
            OnComputer,
            OnDisk
        }

        public static ExperimentData FormNewExperiment(TabControl dataPages, string experimentName, string comments, Dictionary<string, ApplianceData> applianceDatas, List<ConnectedFields> connectedFields)
        {
            var experiment = FormNewExperiment(dataPages, experimentName, comments, connectedFields, applianceDatas);

            return experiment;
        }

        private static ExperimentData FormNewExperiment(TabControl dataPages, string experimentName, string comments, List<ConnectedFields> connectedFields, Dictionary<string, ApplianceData> applianceDatas)
        {
            Dictionary<string, List<FieldData>> experimentData = new Dictionary<string, List<FieldData>>();

            foreach (TabPage page in dataPages.TabPages)
            {
                string pageName = page.Text;

                List<FieldData> fields = new List<FieldData>();

                foreach(RichTextBox field in page.Controls.OfType<RichTextBox>())
                {
                    string metadata = field.BackColor == Color.LightGray ? Create_template_menu.weigherTag : "";
                    var tablePosition = field.Name.Split('_');
                    int Column = Convert.ToInt32(tablePosition[1]), Row = Convert.ToInt32(tablePosition[0]);
                    fields.Add(new FieldData(
                                    field.Tag.ToString(),
                                    metadata,
                                    field.Text,
                                    Row,
                                    Column
                                    ));
                }
                experimentData.Add(pageName, fields);
            }

            ExperimentData experiment = new ExperimentData(experimentName, experimentData, applianceDatas, comments, connectedFields);//, comments);

            return experiment;
        }

        public static void UploadApplianceDataToExperiment(ref ExperimentData experimentData, SeriesCollection series) 
        { 
            var appData = UploadApplianceData(series);

            experimentData.SetNewApplianceData(appData);
        }

        private static Dictionary<string, ApplianceData> UploadApplianceData(SeriesCollection series)
        {
            Dictionary<string, ApplianceData> appData = new Dictionary<string, ApplianceData>();

            foreach (var serie in series)
            {
                if(serie.Name != "temperature")
                    appData.Add(serie.Name, GetApplianceData(serie));
            }

            return appData;
        }

        private static ApplianceData GetApplianceData(Series serie)
        {
            List<GraphPoint> points = new List<GraphPoint>();

            foreach (var point in serie.Points)
            {
                points.Add(new GraphPoint(point.XValue, point.YValues[0]));
            }

            return new ApplianceData(points, serie.Color, serie.LegendText, serie.Name);
        }

        public static string GetCurrentExperimentPath()
        {
            return Interface_settings.get_current_experiment();
        }

        public static void SaveExperimentOnComputer(ExperimentData experiment, string filePath)
        {
            SaveExperiment(experiment, filePath);

            Interface_settings.set_current_experiment(filePath);
        }

        public static void SaveExperiment(ExperimentData experiment, string filePath)
        {
            string experimentSerialized = JsonConvert.SerializeObject(experiment);

            if (!filePath.EndsWith(experimentExtension))
                filePath = Path.Combine(filePath, experiment.Name + experimentExtension);

            using (FileStream fstream = new FileStream(filePath, FileMode.Create))
            {
                byte[] buffer = Encoding.Default.GetBytes(experimentSerialized);
                fstream.Write(buffer, 0, buffer.Length);
            }
        }

        public static ExperimentData UploadCurrentExperiment()
        {
            string currentExperimentPath = Interface_settings.get_current_experiment();

            if (string.IsNullOrEmpty(currentExperimentPath))
                return null;

            if (!IsExperimentExists(currentExperimentPath))
            {
                Interface_settings.set_current_experiment("");
                return null;
            }

            return UploadExperiment(currentExperimentPath);
        }

        private static bool IsExperimentExists(string fullPath)
        {
            return File.Exists(fullPath);
        }

        public static void SetCurrentExperimentIntoRegister(string experimentPath)
        {
            Interface_settings.set_current_experiment(experimentPath);
        }

        public static ExperimentData UploadExperiment(string experimentPath)
        {
            if (!File.Exists(experimentPath))
                return null;

            string textFromFile = "";

            using (FileStream fstream = new FileStream(experimentPath, FileMode.Open))
            {
                byte[] buffer = new byte[fstream.Length];
                fstream.Read(buffer, 0, buffer.Length);
                textFromFile = Encoding.Default.GetString(buffer);
            }

            string experimentDeserializedString;
            ExperimentData experiment;

            try
            {
                experimentDeserializedString = JsonConvert.DeserializeObject(textFromFile).ToString();

                experiment = JsonConvert.DeserializeObject<ExperimentData>(experimentDeserializedString);
            }
            catch
            {
                return null;
            }

            if (isExperimentDamaged(experiment, experimentPath))
                return null;
            
            //Interface_settings.set_current_experiment(experimentPath);
            return experiment; 
        }

        static private bool isExperimentExistOnComputer(string path, string fileName)
        {
            path = Path.Combine(path, fileName + experimentExtension);

            return File.Exists(path);
        }

        private static bool isExperimentExistOnDisk(string path, string fileName)
        {
            fileName += experimentExtension;

            return Drive.isFileExist(fileName, path);
        }

        static public bool IsExperimentExists(string path, string fileName, ExperimentStorePlace storePlace)
        {
            if (storePlace == ExperimentStorePlace.OnComputer)
                return isExperimentExistOnComputer(path, fileName);

            else
                return isExperimentExistOnDisk(path, fileName);
        }

        private static bool isExperimentDamaged(ExperimentData experiment, string experimentPath)
        {
            if (experiment == null)
            {
                string currentExperiment = Interface_settings.get_current_experiment();

                if (currentExperiment == experimentPath && !string.IsNullOrEmpty(currentExperiment))
                    Interface_settings.set_current_experiment("");

                return true;
            }
            return false;
        }

        public static void SaveExperimentOnDisk(ExperimentData experiment, string path)
        {
            throw new NotImplementedException();
        }

        private static string RenameExperimentOnComputer(string experimentName, string newExperimentName, string path)
        {
            string newPath = Path.Combine(path, newExperimentName + experimentExtension);
            string oldPath = Path.Combine(path, experimentName + experimentExtension);

            if (File.Exists(oldPath))
            {
                File.Move(oldPath, newPath);
                return path;
            }
            else
            {
                return null;
            }
        }

        private static string RenameExperimentOnDisk(string name, string newExperimentName, string path)
        {
            throw new NotImplementedException();
        }

        public static string RenameExperiment(ExperimentData experiment, string newExperimentName, string path, ExperimentStorePlace place)
        {
            if (experiment.Name  == newExperimentName)
                return path;

            if (place == ExperimentStorePlace.OnComputer)
                return RenameExperimentOnComputer(experiment.Name, newExperimentName, path);

            else
                return RenameExperimentOnDisk(experiment.Name, newExperimentName, path);
        }
    }
}