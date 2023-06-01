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

namespace Reactor_Interface.Classes.Serie
{
    public struct SerieExperiment
    {
        public string ExperimentName;
        public int TemplateIndex;
    }

    public class SerieData
    {
        public static readonly string EXTENSION = ".serie";

        public readonly List<SerieTemplate> SerieTemplates;
        public readonly Dictionary<int, List<SerieExperiment>> Experiments;
        public readonly string Name;
        private string FolderPath;
        public string SeriePath { get { return Path.Combine(FolderPath, Name + EXTENSION); } }
        public string ExperimentPath { get { return Path.Combine(FolderPath, "Эксперименты"); } }
        public string ReportPath { get { return Path.Combine(FolderPath, "Отчёты"); } }
        public string TemplatesPath { get { return Path.Combine(FolderPath, "Шаблоны"); } }

        [JsonConstructor]
        public SerieData(List<SerieTemplate> serieTemplates, Dictionary<int, List<SerieExperiment>> experiments, string name, string seriePath)
        {
            SerieTemplates = serieTemplates;
            Experiments = experiments;
            Name = name;
            FolderPath = seriePath;
        }

        public SerieData(ExperimentData template, string templatePath, string name, string seriePath)
        {
            SerieTemplates = new List<SerieTemplate>()
            {
                new SerieTemplate(template.GetAllFields(), template.ConnectedFields, templatePath),
            };
            Name = name;
            FolderPath = Path.GetDirectoryName(seriePath);
        }

        public string GetSerieFileName()
        {
            return Name + EXTENSION;
        }

        public bool AddNewExperiment(string experimentPath, ExperimentData experiment, int templateIndex)
        {
            if (!SerieTemplates[templateIndex].IsExperimentCapabledWithTemplate(experiment))
                return false;

            //Experiments.Add();
            return true;
        }

        public void SetSeriePath(string seriePath)
        {
            if(!File.Exists(seriePath))
                throw new NotExistedSeriePathException(seriePath);


            FolderPath = Path.GetDirectoryName(seriePath);
        }
    }
}