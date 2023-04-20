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

namespace Reactor_Interface.Classes.Experiment
{
    static class ExperimentSystem
    {
        public static readonly string experimentExtension = ".exp";

        public static ExperimentData FormNewExperiment(TabControl dataPages, string experimentName, string comments, Chart chart = null)
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
                    int Column = Convert.ToInt32(tablePosition[0]), Row = Convert.ToInt32(tablePosition[1]);
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
            ExperimentData experiment = new ExperimentData(experimentName, experimentData, chart, comments);

            return experiment;
        }

        public static void SaveExperiment(ExperimentData experiment, string filePath)
        {
            string experimentSerialized = JsonConvert.SerializeObject(experiment);
            using (FileStream fstream = new FileStream(filePath, FileMode.Create))
            {
                byte[] buffer = Encoding.Default.GetBytes(experimentSerialized);
                fstream.Write(buffer, 0, buffer.Length);
            }

            Interface_settings.set_current_experiment(filePath);
        }

        public static ExperimentData UploadCurrentExperiment()
        {
            string currentExperimentPath = Interface_settings.get_current_experiment();

            if (string.IsNullOrEmpty(currentExperimentPath))
                return null;

            return UploadExperiment(currentExperimentPath);
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

            var experiment = JsonConvert.DeserializeObject<ExperimentData>(textFromFile);

            if (isExperimentDamaged(experiment, experimentPath))
                return null;

            return experiment; 
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
    }
}
