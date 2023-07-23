using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reactor_Interface.Classes.Experiment;
using Reactor_Interface.Classes.Templates;
using Reactor_Interface.Classes.Exceptions;
using Newtonsoft.Json;
using System.Web.UI.WebControls;

namespace Reactor_Interface.Classes.Serie
{
    public struct SerieExperimentMetaData
    {
        public string ExperimentName;
        public string TemplateName;

        public string GetExperimentFileName()
        {
            return ExperimentName + ExperimentSystem.EXTENSION;
        }

        public int GetExperimentNumer()
        {
            return Convert.ToInt32(ExperimentName.Split('_').Last());
        }
    }

    public class SerieData
    {
        public static readonly string EXTENSION = ".serie";

        public readonly Dictionary<string, SerieTemplate> SerieTemplates;
        public readonly Dictionary<string, List<SerieExperimentMetaData>> Experiments;
        public readonly string Name;

        public int LastExperimentIndex { get; private set;  }

        private string FolderPath;
        public string SerieFilePath { get { return Path.Combine(FolderPath, Name + EXTENSION); } }
        public string ExperimentPath { get { return Path.Combine(FolderPath, "Эксперименты"); } }
        public string ReportPath { get { return Path.Combine(FolderPath, "Отчёты"); } }
        public string TemplatesPath { get { return Path.Combine(FolderPath, "Шаблоны"); } }
        public string SerieComments { get; private set; }

        [JsonConstructor]
        public SerieData(Dictionary<string, SerieTemplate> serieTemplates, Dictionary<string, List<SerieExperimentMetaData>> experiments, string name, string seriePath, int lastExperimentIndex, string serieComments)
        {
            SerieTemplates = serieTemplates ?? new Dictionary<string, SerieTemplate>();
            Experiments = experiments ?? new Dictionary<string, List<SerieExperimentMetaData>>();
            Name = name;
            FolderPath = seriePath;
            SerieComments = serieComments == null ? "" : serieComments;
            LastExperimentIndex = lastExperimentIndex;
        }

        public SerieData(ExperimentData template, string templatePath, string name, string folderPath)
        {
            SerieTemplate serieTemplate = new SerieTemplate(template.GetAllFields(), template.ConnectedFields, templatePath);
            SerieTemplates = new Dictionary<string, SerieTemplate>();
            Experiments = new Dictionary<string, List<SerieExperimentMetaData>>();
            Name = name;
            FolderPath = folderPath;
            LastExperimentIndex = 0;
            AddNewTemplate(template, templatePath);
        }

        public string GetSerieFileName()
        {
            return Name + EXTENSION;
        }

        public void SetSeriePath(string seriePath)
        {
            if(!File.Exists(seriePath))
                throw new NotExistedSeriePathException(seriePath);


            FolderPath = Path.GetDirectoryName(seriePath);
        }

        public void SetCommets(string comments)
        {
            SerieComments = comments;
        }

        public void AddNewTemplate(ExperimentData template, string templatePath)
        {
            var serieTemplate = new SerieTemplate(template.GetAllFields(), template.ConnectedFields, templatePath);
            SerieTemplates.Add(serieTemplate.TemplateName, serieTemplate);
            Experiments.Add(serieTemplate.TemplateName, new List<SerieExperimentMetaData>());
        }

        public int GetLastExpIndex()
        {
            return LastExperimentIndex;
        }

        public void AddExperiment(SerieExperimentMetaData metaData)
        {
            string templateName = metaData.TemplateName;

            if (!SerieTemplates.ContainsKey(templateName))
                throw new NullTemplateException();

            if (!Experiments.ContainsKey(templateName))
            {
                Experiments.Add(templateName, new List<SerieExperimentMetaData>() { metaData });
                LastExperimentIndex++;
                return;
            }

            int experimentIndex = Experiments[templateName].IndexOf(metaData);

            if (experimentIndex == -1) 
            {
                Experiments[templateName].Add(metaData);
                LastExperimentIndex++;
            }

            else
                Experiments[templateName][experimentIndex] = metaData;
        }

        public string GetExperimentFilePath(string experimentName)
        {
            experimentName = experimentName.EndsWith(ExperimentSystem.EXTENSION) ? experimentName : experimentName + ExperimentSystem.EXTENSION;
            string path = Path.Combine(ExperimentPath, experimentName.Substring(0, experimentName.Length - ExperimentSystem.EXTENSION.Length));
            return Path.Combine(path, experimentName);
        }

        public void DecrementLastExperimentIndex()
        {
            LastExperimentIndex--;
        }
    }
}