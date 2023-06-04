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
        public int TemplateIndex;

        public string GetExperimentFileName()
        {
            return ExperimentName + ExperimentSystem.experimentExtension;
        }
    }

    public class SerieData
    {
        public static readonly string EXTENSION = ".serie";

        public readonly List<SerieTemplate> SerieTemplates;
        public readonly Dictionary<int, List<SerieExperimentMetaData>> Experiments;
        public readonly string Name;

        public int LastExperimentIndex { get; private set;  }

        private string FolderPath;
        public string SerieFilePath { get { return Path.Combine(FolderPath, Name + EXTENSION); } }
        public string ExperimentPath { get { return Path.Combine(FolderPath, "Эксперименты"); } }
        public string ReportPath { get { return Path.Combine(FolderPath, "Отчёты"); } }
        public string TemplatesPath { get { return Path.Combine(FolderPath, "Шаблоны"); } }

        [JsonConstructor]
        public SerieData(List<SerieTemplate> serieTemplates, Dictionary<int, List<SerieExperimentMetaData>> experiments, string name, string seriePath, int lastExperimentIndex)
        {
            SerieTemplates = serieTemplates == null ? new List<SerieTemplate>() : serieTemplates;
            Experiments = experiments == null ? new Dictionary<int, List<SerieExperimentMetaData>>() : experiments;
            Name = name;
            FolderPath = seriePath;
            LastExperimentIndex = lastExperimentIndex;
        }

        public SerieData(ExperimentData template, string templatePath, string name, string folderPath)
        {
            SerieTemplates = new List<SerieTemplate>()
            {
                new SerieTemplate(template.GetAllFields(), template.ConnectedFields, templatePath),
            };
            Experiments = new Dictionary<int, List<SerieExperimentMetaData>>();
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
            SerieTemplates.Add(serieTemplate);
        }

        public int GetLastExpIndex()
        {
            return LastExperimentIndex;
        }

        public void AddExperiment(SerieExperimentMetaData metaData)
        {
            int templateIndex = metaData.TemplateIndex;

            if (SerieTemplates.Count <= templateIndex)
                throw new NullTemplateException();

            if (!Experiments.ContainsKey(templateIndex))
            {
                Experiments.Add(templateIndex, new List<SerieExperimentMetaData>() { metaData });
                LastExperimentIndex++;
                return;
            }

            int experimentIndex = Experiments[templateIndex].IndexOf(metaData);

            if (experimentIndex == -1) 
            {
                Experiments[templateIndex].Add(metaData);
                LastExperimentIndex++;
            }

            else
                Experiments[templateIndex][experimentIndex] = metaData;
        }

        public string GetExperimentFilePath(string experimentName)
        {
            experimentName = experimentName.EndsWith(ExperimentSystem.experimentExtension) ? experimentName : experimentName + ExperimentSystem.experimentExtension;
            return Path.Combine(ExperimentPath, experimentName);
        }
    }
}