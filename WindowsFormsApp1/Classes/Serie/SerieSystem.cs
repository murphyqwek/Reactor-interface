using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Windows.Forms;
using Microsoft.Office.Core;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Reactor_Interface.Classes.Exceptions;
using Reactor_Interface.Classes.Experiment;
using Reactor_Interface.Classes.Message;
using Reactor_Interface.Classes.Templates;
using Reactor_Interface.Forms.Journal;

namespace Reactor_Interface.Classes.Serie
{
    public class SerieSystem
    {
        static private string getNewSeriePath()
        {
            string seriepath = null;

            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Выберите папку серии";

                DialogResult result = fbd.ShowDialog();

                if (result != DialogResult.OK || string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    return null;

                seriepath = fbd.SelectedPath;
            }

            return seriepath;
        }

        static private string getNewSerieName(string seriePath)
        {
            bool isSerieNameChosen = false;
            while (!isSerieNameChosen)
            {
                string serieName;
                using (InputFormMenu inputForm = new InputFormMenu("Создание новой серии", "Введите название серии"))
                {
                    var result = inputForm.ShowDialog();

                    if (result != DialogResult.OK)
                        return null;

                    serieName = inputForm.OutputValue;
                }

                if (string.IsNullOrEmpty(serieName))
                {
                    ErrorMessage.Show("Пустое название");
                    continue;
                }

                string tempPath = Path.Combine(seriePath, serieName);

                if (Directory.Exists(tempPath))
                {
                    ErrorMessage.Show("Серия с таким названием уже существует. Выберите другое название");
                    continue;
                }

                seriePath = tempPath;
                isSerieNameChosen = true;
            }

            return seriePath;
        }

        static public void AddNewTemplateToSerie(SerieData serie, ExperimentData template, string templatePath, string newTemplateName = null)
        {
            string templateName = newTemplateName;

            if (!File.Exists(templatePath))
            {
                ErrorMessage.Show("Шаблон был удалён");
                return;
            }

            if (!File.Exists(serie.SerieFilePath))
            {
                ErrorMessage.Show("Файл серии удалён");
                return;
            }

            if (!Directory.Exists(serie.TemplatesPath))
                Directory.CreateDirectory(serie.TemplatesPath);

            if (newTemplateName == null)
                templateName = Path.GetFileName(templatePath);

            if (!templateName.EndsWith(TemplateSystem.EXTENSION))
                templateName += TemplateSystem.EXTENSION;

            if(File.Exists(Path.Combine(serie.TemplatesPath, templateName)))
            {
                ErrorMessage.Show("Шаблон с таким же названием уже существует");
                return;
            }

            try
            {
                File.Copy(templatePath, Path.Combine(serie.TemplatesPath, templateName), true);
                string templateNameWihtouExtension = Path.GetFileNameWithoutExtension(templatePath);

                if (serie.SerieTemplates.ContainsKey(templateNameWihtouExtension))
                {
                    var DeletedTemplate = serie.SerieTemplates[templateNameWihtouExtension];
                    if (DeletedTemplate.IsExperimentCapabledWithTemplate(template))
                    {
                        serie.SerieTemplates[templateNameWihtouExtension] = new SerieTemplate(template.GetAllFields(), template.ConnectedFields, templatePath);
                        InfoMessage.Show("В базе данных был найден индентичный удалённый шаблон. Он был заменён на данный");
                    }
                    else
                    {
                        ErrorMessage.Show("В базе шаблонов присутсвует удалённый шаблон с таким же именем. Переименутйе данный шаблон");
                        return;
                    }
                }
                else
                    serie.AddNewTemplate(template, Path.Combine(serie.TemplatesPath, templateName));

                SaveSerieJSON(serie);
                SuccesMessage.Show("Новый шаблон загружен");
            }
            catch
            {
                File.Delete(Path.Combine(serie.TemplatesPath, templateName));
                ErrorMessage.Show("Ошибка при добавлении нового шаблона в серию");
            }
        }

        static public SerieData CreateNewSerie(ExperimentData template, string templatePath)
        {
            string seriePath = getNewSeriePath();

            if(string.IsNullOrEmpty(seriePath)) 
                return null;

            seriePath = getNewSerieName(seriePath);

            if (!setupSerieFolder(seriePath))
                return null;

            if (!CopyTemplateToTempletesFolder(templatePath, seriePath))
            {
                DeleteSerieFolder(seriePath);
                return null;
            }

            string name = GetSerieNameFromPath(seriePath);

            SerieData newSerie = new SerieData(template, templatePath, name, seriePath);

            try
            {
                SaveSerieJSON(newSerie);
                return newSerie;
            }
            catch
            {
                ErrorMessage.Show("Ошибка при создании серии. Попробуйте выбрать новую папку серии");
                DeleteSerieFolder(seriePath);
                return null;
            }
        }

        private static bool CopyTemplateToTempletesFolder(string templatePath, string seriePath)
        {
            string templateName = Path.GetFileName(templatePath);
            if (!File.Exists(templatePath))
            {
                ErrorMessage.Show("Не существует шаблона по пути: " + templatePath);
                return false;
            }

            if(File.Exists(seriePath + "\\Шаблоны\\" + templateName))
            {
                ErrorMessage.Show("Шаблон с таким же названием уже существует");
                return false;
            }

            try
            {
                File.Copy(templatePath, seriePath + "\\Шаблоны\\" + templateName);
                return true;
            }
            catch
            {
                ErrorMessage.Show("Ошибка при создании шаблона");
                return false;
            }
        }

        public static void SaveSerieJSON(SerieData serie)
        {
            string serializedSerie = JsonConvert.SerializeObject(serie);

            using (FileStream fstream = new FileStream(serie.SerieFilePath, FileMode.Create))
            {
                // преобразуем строку в байты
                byte[] buffer = Encoding.Default.GetBytes(serializedSerie);
                // запись массива байтов в файл
                fstream.Write(buffer, 0, buffer.Length);
            }
        }

        public static void DeleteSerieFolder(string seriePath)
        {
            try
            {
                Directory.Delete(seriePath, true);
            }
            catch
            {
                ErrorMessage.Show("Не удалось удалить папку серии");
            }
        }

        public static string GetSerieNameFromPath(string seriepath)
        {
            return Path.GetFileNameWithoutExtension(seriepath);
        }

        private static bool setupSerieFolder(string seriePath)
        {
            try
            {
                Directory.CreateDirectory(seriePath);
                Directory.CreateDirectory(seriePath + "\\Отчёты");
                Directory.CreateDirectory(seriePath + "\\Эксперименты");
                Directory.CreateDirectory(seriePath + "\\Шаблоны");
                return true;
            }
            catch
            {
                ErrorMessage.Show("Ошибка при создании серии. Попробуйте выбрать другую папку");
                return false;
            }
        }

        public static SerieData GetSerie()
        {
            string seriePath;
            using (OpenFileDialog fd  = new OpenFileDialog())
            {
                fd.Filter = string.Format("Serie files (*{0})|*{0}", SerieData.EXTENSION);
                fd.Multiselect = false;

                if (fd.ShowDialog() != DialogResult.OK)
                    return null;

                 seriePath = fd.FileName;
            }

            return UploadSerie(seriePath);
        }
        
        private static string ReadSerieFile(string seriePath)
        {
            string JSONserie;
            using (FileStream fstream = new FileStream(seriePath, FileMode.Open))
            {
                // выделяем массив для считывания данных из файла
                byte[] buffer = new byte[fstream.Length];
                // считываем данные
                fstream.Read(buffer, 0, buffer.Length);
                // декодируем байты в строку
                JSONserie = Encoding.Default.GetString(buffer);
            }

            return JSONserie;
        }

        public static SerieData UploadSerie(string seriePath)
        {
            string JSONserie = ReadSerieFile(seriePath);
            SerieData serieData;
            try
            {
                serieData = JsonConvert.DeserializeObject<SerieData>(JSONserie);
            }
            catch
            {
                return null;
            }

            serieData.SetSeriePath(seriePath);

            //CheckTemplates(serieData);

            return serieData;
        }

        public static bool IsSerieExists(SerieData serie)
        {
            return File.Exists(serie.SerieFilePath);
        }

        public static void DeleteTemplate(SerieData serie, string templateName)
        {
            if (!serie.SerieTemplates.ContainsKey(templateName))
                return;

            serie.SerieTemplates[templateName].SetDeleted(true);

            string templatePath = Path.Combine(serie.TemplatesPath, serie.SerieTemplates[templateName].GetTemplateFileName());

            if (File.Exists(templatePath))
                File.Delete(templatePath);

            if (serie.Experiments != null)
            {
                if (!serie.Experiments.ContainsKey(templateName))
                    serie.SerieTemplates.Remove(templateName);
            }
            else
                serie.SerieTemplates.Remove(templateName);

            SaveSerieJSON(serie);
        }

        public static void AddExistedExperiment(SerieData serie, ExperimentData experiment, string templateName, string experimentPath)
        {
            string experimentFolderPath = Directory.GetParent(experimentPath).FullName;
            string oldExperimentName = Path.GetFileNameWithoutExtension(experimentPath);
            string experimentName = serie.Name + "_" + (serie.GetLastExpIndex() + 1).ToString();
            experiment.Rename(experimentName);

            SerieExperimentMetaData serieExperimentMetaData = new SerieExperimentMetaData()
            {
                ExperimentName = experimentName,
                TemplateName = templateName
            };

            AddExperiment(serie, experiment, serieExperimentMetaData);

            foreach(string file in ExperimentSystem.AppFileName.Values)
            {
                string oldAppFilePath = Path.Combine(experimentFolderPath, oldExperimentName + file);

                if (File.Exists(oldAppFilePath))
                {
                    string newAppFilePath = Path.Combine(GetExperimentFolderPath(serie, serieExperimentMetaData), experimentName + file);
                    File.Copy(oldAppFilePath, newAppFilePath);
                }
            }

        }

        public static void AddExperiment(SerieData serie, ExperimentData experiment, SerieExperimentMetaData experimentMetaData)
        {
            if(!Directory.Exists(serie.ExperimentPath))
                Directory.CreateDirectory(serie.ExperimentPath);

            var template = serie.SerieTemplates[experimentMetaData.TemplateName];

            if(template == null)
            {
                throw new NullTemplateException();
            }
            if (!template.IsExperimentCapabledWithTemplate(experiment))
            {
                throw new ExperimentIsNotCapableWithTemplateExcpetion();
            }

            serie.AddExperiment(experimentMetaData);
            if (!Directory.Exists(serie.ExperimentPath + "\\" + experimentMetaData.ExperimentName))
                Directory.CreateDirectory(serie.ExperimentPath + "\\" + experimentMetaData.ExperimentName);

            ExperimentSystem.SaveExperiment(experiment, serie.GetExperimentFilePath(experimentMetaData.ExperimentName));
            SaveSerieJSON(serie);
        }

        public static string GetExperimentFolderPath(SerieData serie, SerieExperimentMetaData experimentMetaData)
        {
            return GetExperimentFolderPath(serie, experimentMetaData.ExperimentName);
        }

        public static string GetExperimentFolderPath(SerieData serie, string experimentName)
        {
            return Path.Combine(serie.ExperimentPath, experimentName);
        }

        public static string GetExperimentFilePath(SerieData serie, SerieExperimentMetaData experimentMetaData)
        {
            string folderPath = GetExperimentFolderPath(serie, experimentMetaData.ExperimentName);
            string outFolderExpPath = Path.Combine(serie.ExperimentPath, experimentMetaData.GetExperimentFileName());
            string experimentExpPath = Path.Combine(folderPath, experimentMetaData.GetExperimentFileName());
            
            if (!Directory.Exists(folderPath) && File.Exists(outFolderExpPath))
            {
                Directory.CreateDirectory(folderPath);
                File.Move(outFolderExpPath, experimentExpPath);
            }

            return experimentExpPath;
        }

        public static ExperimentData UploadExperiment(SerieData serie, SerieExperimentMetaData metaData)
        {
            if (!Directory.Exists(serie.ExperimentPath))
            {
                ErrorMessage.Show("Файл эксперимента не существует");
                return null;
            }

            if(!serie.SerieTemplates.ContainsKey(metaData.TemplateName))
            {
                ErrorMessage.Show("Отсутсвует шаблон эксперимента в базе шаблонов");
                return null;

            }

            string experimentPath = GetExperimentFilePath(serie, metaData);

            if(!File.Exists(experimentPath))
            {
                ErrorMessage.Show("Файл эксперимента не существует");
                return null;
            }

            ExperimentData experiment = ExperimentSystem.UploadExperiment(experimentPath, false);

            var template = serie.SerieTemplates[metaData.TemplateName];

            if (!template.IsExperimentCapabledWithTemplate(experiment))
            {
                ErrorMessage.Show("Эксперимент не соответсвует шаблону");
                return null;
            }

            return experiment;
        }

        public static void DeleteExperiment(SerieData serie, string templateKey, string experimentName)
        {
            if (!serie.Experiments.ContainsKey(templateKey))
                return;

            int experimentsCount = serie.Experiments[templateKey].Count;

            bool deleted = false;

            for (int i = 0; i < experimentsCount; i++)
            {
                var experiment = serie.Experiments[templateKey][i];
                if(experiment.ExperimentName == experimentName)
                {
                    File.Delete(Path.Combine(serie.ExperimentPath, experiment.ExperimentName));
                    serie.Experiments[templateKey].RemoveAt(i);

                    int experimentNumer = experiment.GetExperimentNumer();

                    if (serie.LastExperimentIndex == experimentNumer)
                        serie.DecrementLastExperimentIndex();

                    deleted = true;
                    break;
                }
            }

            if (deleted)
                SaveSerieJSON(serie);
        }

        public static bool RenameTemplate(SerieData serie, string oldName) 
        {
            string newName;

            using(InputFormMenu inputForm = new InputFormMenu("Переименование шаблона", "Введите новое название шаблона", oldName))
            {
                if (inputForm.ShowDialog() != DialogResult.OK)
                    return false;

                newName = inputForm.OutputValue.Trim();
            }

            string newPath = Path.Combine(serie.TemplatesPath, newName + TemplateSystem.EXTENSION);
            string oldPath = Path.Combine(serie.TemplatesPath, oldName + TemplateSystem.EXTENSION);


            if(newName == oldName)
            {
                ErrorMessage.Show("Новое название совпадает со старым");
                return false;
            }

            if (!File.Exists(oldPath))
            {
                ErrorMessage.Show("Файл шаблона был удалён или перемешён");
                return true;
            }

            if(File.Exists(newPath) || serie.Experiments.ContainsKey(newName))
            {
                ErrorMessage.Show("Шаблон с таким названием уже существует. Выберите другое");
                return false;
            }


            File.Move(oldPath, newPath);

            var template = serie.SerieTemplates[oldName];
            template.SetTemplateName(newName);
            serie.SerieTemplates.Remove(oldName);
            serie.SerieTemplates.Add(newName, template);

            var experiments = serie.Experiments[oldName];

            for(int i = 0; i < experiments.Count; i++)
            {
                var experiment = experiments[i];
                experiment.TemplateName = newName;
                experiments[i] = experiment;
            }

            serie.Experiments.Remove(oldName);
            serie.Experiments.Add(newName, experiments);
            SaveSerieJSON(serie);

            return true;
        }

    }
}