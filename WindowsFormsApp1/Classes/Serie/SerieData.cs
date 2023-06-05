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
            return ExperimentName + ExperimentSystem.experimentExtension;
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

        [JsonConstructor]
        public SerieData(Dictionary<string, SerieTemplate> serieTemplates, Dictionary<string, List<SerieExperimentMetaData>> experiments, string name, string seriePath, int lastExperimentIndex)
        {
            SerieTemplates = serieTemplates == null ? new Dictionary<string, SerieTemplate>() : serieTemplates;
            Experiments = experiments == null ? new Dictionary<string, List<SerieExperimentMetaData>>() : experiments;
            Name = name;
            FolderPath = seriePath;
            LastExperimentIndex = lastExperimentIndex;
        }

        public SerieData(ExperimentData template, string templatePath, string name, string folderPath)
        {
            SerieTemplate serieTemplate = new SerieTemplate(template.GetAllFields(), template.ConnectedFields, templatePath);
            SerieTemplates = new Dictionary<string, SerieTemplate>()
            {
                { serieTemplate.TemplateName, serieTemplate },
            };
            Experiments = new Dictionary<string, List<SerieExperimentMetaData>>();
            Name = name;
            FolderPath = folderPath;
            LastExperimentIndex = 0;
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

        public void AddNewTemplate(ExperimentData template, string templatePath)
        {
            var serieTemplate = new SerieTemplate(template.GetAllFields(), template.ConnectedFields, templatePath);
            SerieTemplates.Add(serieTemplate.TemplateName, serieTemplate);
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
            experimentName = experimentName.EndsWith(ExperimentSystem.experimentExtension) ? experimentName : experimentName + ExperimentSystem.experimentExtension;
            return Path.Combine(ExperimentPath, experimentName);
        }
    }
}