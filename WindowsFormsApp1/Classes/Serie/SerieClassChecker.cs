using Reactor_Interface.Classes.Experiment;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reactor_Interface.Classes.Serie
{
    public class SerieClassChecker
    {
        public static bool IsAllSerieTemplatesOK(SerieData serieData)
        {
            foreach(var template in serieData.SerieTemplates)
            {
                if (!IsSerieTemplateOK(template, Path.Combine(serieData.TemplatesPath, template.TemplateName)))
                    return false;
            }

            return true;
        }

        public static bool IsSerieTemplateOK(SerieTemplate serieTemplate, string serieTemplatePath) 
        {
            var experiment = ExperimentSystem.UploadExperiment(serieTemplatePath);

            return serieTemplate.IsExperimentCapabledWithTemplate(experiment);
        }
    }
}
