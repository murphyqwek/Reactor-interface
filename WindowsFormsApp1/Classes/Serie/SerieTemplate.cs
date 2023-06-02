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
    public class SerieTemplate
    {
        public readonly Dictionary<string, bool> Fields;
        public readonly List<ConnectedFields> ConnectedFieldsList;
        public string TemplateName { get; private set; }
        public bool IsDeleted { get; private set; }

        [JsonConstructor]
        public SerieTemplate(Dictionary<string, bool> fields, List<ConnectedFields> connectedFieldsList, string templateName, bool isDeleted = false)
        {
            Fields = fields;
            ConnectedFieldsList = connectedFieldsList;
            TemplateName = templateName;
            IsDeleted = isDeleted;
        }

        public SerieTemplate(List<string> fields, List<ConnectedFields> connectedFieldsList, string templatePath)
        {
            if (!File.Exists(templatePath))
                throw new TemplateDoesNotExistExcpetion(templatePath);

            Fields = ConvertListToDictionary(fields);
            ConnectedFieldsList = connectedFieldsList;
            TemplateName = templatePath;
        }

        public SerieTemplate(List<FieldData> fields, List<ConnectedFields> connectedFieldsList, string templatePath) 
        {
            if (!File.Exists(templatePath))
                throw new TemplateDoesNotExistExcpetion(templatePath);

            var temp = ConvertFieldsToStrings(fields);
            Fields = ConvertListToDictionary(temp);
            ConnectedFieldsList = connectedFieldsList;
            TemplateName = Path.GetFileNameWithoutExtension(templatePath);
        }

        public string GetTemplateFileName()
        {
            return TemplateName + TemplateSystem.EXTENSION;
        }

        private Dictionary<string, bool> ConvertListToDictionary(List<string> fields)
        {
            Dictionary<string, bool> newFields = new Dictionary<string, bool>();
            foreach(string field in fields)
            {
                newFields.Add(field, true);
            }
            return newFields;
        }

        public bool IsExperimentCapabledWithTemplate(ExperimentData experiment)
        {
            bool l;
            foreach(var field in experiment.GetAllFields())
            {
                if (!Fields.TryGetValue(field.FieldName, out l))
                    return false;
            }

            var ExpConFields = experiment.ConnectedFields == null ? new List<ConnectedFields>() : experiment.ConnectedFields;
            var СonFields = ConnectedFieldsList == null ? new List<ConnectedFields>() : ConnectedFieldsList;

            if (experiment.ConnectedFields == null &&
                ConnectedFieldsList == null)
                return true;

            if ((experiment.ConnectedFields != null &&
                ConnectedFieldsList == null) ||
                (experiment.ConnectedFields == null &&
                ConnectedFieldsList != null))
                return false;

            foreach (var pair in ExpConFields)
            {
                foreach(var secondPair in СonFields)
                {
                    if(pair.firstFieldName != secondPair.firstFieldName || 
                        pair.secondFieldName != secondPair.secondFieldName)
                        return false;
                }
            }

            return true;
        }

        private List<string> ConvertFieldsToStrings(List<FieldData> fields)
        {
            List<string> convertedStrings = new List<string>();
            foreach (var field in fields)
            {
                convertedStrings.Add(field.FieldName);
            }
            return convertedStrings;
        }

        public void SetTemplateName(string newNameTemplate)
        {
            TemplateName = newNameTemplate;
        }

        public void SetDeleted(bool deleted)
        {
            IsDeleted = deleted;
        }
    }
}