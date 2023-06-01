using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Windows.Forms;
using Microsoft.Office.Core;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Reactor_Interface.Classes.Experiment;
using Reactor_Interface.Classes.Templates;

namespace Reactor_Interface.Classes.Serie
{
    public class SerieSystem
    {
        private static readonly string NOTFOUND = "Not Found";
        static private string getNewSeriePath()
        {
            string seriepath = null;

            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result != DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
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
                string serieName = Interaction.InputBox("Введите название серии", "Создание новой серии");
                if (string.IsNullOrEmpty(serieName))
                {
                    MessageBox.Show("Пустое название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button1);
                    continue;
                }

                string tempPath = Path.Combine(seriePath, serieName);

                if (Directory.Exists(tempPath))
                {
                    MessageBox.Show("Серия с таким названием уже существует. Выберите другое название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button1);
                    continue;
                }

                seriePath = tempPath;
                isSerieNameChosen = true;
            }

            return seriePath;
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

            if (!SaveNewSerieJSON(newSerie, seriePath))
            {
                DeleteSerieFolder(seriePath);
                return null;
            }

            return newSerie;
        }

        private static bool CopyTemplateToTempletesFolder(string templatePath, string seriePath)
        {
            string templateName = Path.GetFileName(templatePath);
            if (!File.Exists(templatePath))
            {
                MessageBox.Show("Не существует шаблона по пути: " + templatePath, "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }

            if(File.Exists(seriePath + "\\Шаблоны\\" + templateName))
            {
                MessageBox.Show("Шаблон с таким же названием уже существует", "Ошибка",
                                                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }

            try
            {
                File.Copy(templatePath, seriePath + "\\Шаблоны\\" + templateName);
                return true;
            }
            catch
            {
                MessageBox.Show("Ошибка при создании шаблона", "Ошибка",
                                                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
        }

        public static bool SaveNewSerieJSON(SerieData serie, string seriePath)
        {
            try
            {
                string serializedSerie = JsonConvert.SerializeObject(serie);
                string file = Path.Combine(seriePath, serie.GetSerieFileName());

                using (FileStream fstream = new FileStream(file, FileMode.Create))
                {
                    // преобразуем строку в байты
                    byte[] buffer = Encoding.Default.GetBytes(serializedSerie);
                    // запись массива байтов в файл
                    fstream.Write(buffer, 0, buffer.Length);
                }
                return true;
            }
            catch
            {
                MessageBox.Show("Ошибка при создании серии. Попробуйте выбрать новую папку серии", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
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
                MessageBox.Show("Не удалось удалить папку серии", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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
                MessageBox.Show("Ошибка при создании серии. Попробуйте выбрать другую папку", "Ошибка", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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
            return File.Exists(serie.SeriePath);
        }

        private static void CheckTemplates(SerieData serieData)
        {
            foreach(var template in serieData.SerieTemplates)
            {
                if (template.TemplateName == NOTFOUND)
                    continue;
            }
        }
    }
}