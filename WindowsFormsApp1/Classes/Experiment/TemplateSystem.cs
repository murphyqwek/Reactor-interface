using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reactor_Interface.Forms;
using Reactor_Interface.Forms.Template;
using Newtonsoft.Json;
using Reactor_Interface.Classes.Templates;
using Microsoft.Office.Interop.Excel;
using WindowsFormsApp1.Classes;
using System.Web.UI;
using Reactor_Interface.Classes.Experiment;
using Reactor_Interface.Classes.GoogleAPI;
using Reactor_Interface.Classes.Exceptions;

namespace Reactor_Interface.Classes
{
    static class TemplateSystem
    {
        static private readonly string templates_folder = Environment.GetFolderPath(
                                                            Environment.SpecialFolder.ApplicationData) 
                                                          + "\\Journal templates\\";

        static public readonly string EXTENSION = ".template";

        public enum Save_result {
            EmptyFiled,
            EmptyPages,
            CreationError,
            Saved
        }
        
        static private string get_full_path(string name)
        {
            return templates_folder + name + EXTENSION;
        }

        static private void Create_folder()
        {
            Directory.CreateDirectory(templates_folder);
        }

        static public void UploadTemplates(string[] templates)
        {
            foreach(var template in templates)
            {
                string filename =Path.GetFileName(template);
                Create_folder();
                File.Copy(template, templates_folder + filename);
            }
        }

        static public bool IsTemplateCreated(string name)
        {
            Directory.CreateDirectory(templates_folder);

            return File.Exists(get_full_path(name));
        }

        static public ExperimentData ChagneExperimentTemplate(TabControl control, ExperimentData modifyingExperiment)
        {
            ExperimentData tempExperiment = CreateTemplate(control, modifyingExperiment.Name);
            tempExperiment.SetNewApplianceData(modifyingExperiment.ApplianceData);

            var Pages = tempExperiment.Pages;

            foreach(var page in modifyingExperiment.Pages.Keys)
            {
                foreach(var Field in modifyingExperiment.Pages[page])
                {
                    for(int i = 0; i < tempExperiment.Pages[page].Count; i++)
                    {
                        if (tempExperiment.Pages[page][i].Column == Field.Column && tempExperiment.Pages[page][i].Row == Field.Row)
                        {
                            FieldData updetedField = new FieldData(tempExperiment.Pages[page][i].FieldName,
                                                                   tempExperiment.Pages[page][i].MetaData,
                                                                   Field.FieldValue,
                                                                   tempExperiment.Pages[page][i].Row,
                                                                   tempExperiment.Pages[page][i].Column);

                            tempExperiment.Pages[page][i] = updetedField;
                            continue;
                        }
                    }
                }
            }

            return tempExperiment;
        }

        static public ExperimentData CreateTemplate(TabControl template_control, string ExperimentName)
        {
            Dictionary<string, List<FieldData>> pages = new Dictionary<string, List<FieldData>>();

            HashSet<string> usedFieldsNames = new HashSet<string>();

            foreach (TabPage page in template_control.TabPages)
            {
                string name_page = page.Text;
                List<FieldData> fields = new List<FieldData>();
                for (int i = 0; i < Create_template_menu.columns; i++)
                {
                    for (int y = 0; y < Create_template_menu.rows; y++)
                    {
                        string item_id = i.ToString() + y.ToString();
                        var textbox = page.Controls.Find(item_id + Create_template_menu.text_box_item_suffix, true)
                                                        .FirstOrDefault();
                        if (textbox == null)
                            continue;
                        if (textbox.Text == "")
                            throw new EmptyTextBoxException();

                        if(usedFieldsNames.Contains(textbox.Text))
                            throw new SameFieldsNamesException();

                        fields.Add(new FieldData(textbox.Text, textbox.Tag.ToString(), "", y, i));
                    }
                }
                pages.Add(name_page, fields);
            }
            if (pages.Count == 0)
                throw new NullPagesException();

            ExperimentData template = new ExperimentData(ExperimentName, pages);
            return template;
        }

        static public void Create_template_json(TabControl template_control, string name)
        {
            ExperimentData template = CreateTemplate(template_control, "Новый эксперимент");
            string str_template = JsonConvert.SerializeObject(template);
            Write_template_to_file(str_template, name);
        }
        static private void Write_template_to_file(string template, string template_name)
        {
            Create_folder();
            using (FileStream fstream = new FileStream(get_full_path(template_name), FileMode.Create))
            {
                // преобразуем строку в байты
                byte[] buffer = Encoding.Default.GetBytes(template);
                // запись массива байтов в файл
                fstream.Write(buffer, 0, buffer.Length);
            }
        }

        static public Dictionary<string, List<Pair>> get_experiment(TabControl pages, ExperimentData template)
        {
            Dictionary<string, List<Pair>> experiment = new Dictionary<string, List<Pair>>();

            foreach (TabPage page in pages.TabPages)
            {
                string pageName = page.Text;

                List<Pair> textboxes = new List<Pair>();

                foreach (FieldData field in template.Pages[pageName]) 
                { 
                    var textbox = page.Controls.Find(field.Column.ToString() + field.Row.ToString() + Create_template_menu.text_box_item_suffix, true)
                                                    .FirstOrDefault();

                    string fieldName = textbox.Tag.ToString().Split(';')[0], value = textbox.Text;

                    Pair pair = new Pair(fieldName, value);
                    textboxes.Add(pair);
                    
                }

                experiment.Add(pageName, textboxes);
            }

            return experiment;
        }

        static public string[] GetTemplatesArray()
        {
            Create_folder();

            List<string> templates = new List<string>();
            foreach(string file in Directory.GetFiles(templates_folder))
            {
                if (Path.GetExtension(file) == EXTENSION)
                    templates.Add(Path.GetFileNameWithoutExtension(file));
            }

            return templates.ToArray();
        }

        static public string[] GetTemplatesPathesArrayFromOrigin()
        {
            Create_folder();
            return GetTemplatesPathesArray(templates_folder);
        }

        static public string[] GetTemplatesPathesArray(string templates_folder)
        {
            if (!Directory.Exists(templates_folder))
                return null;

            List<string> templates = new List<string>();
            foreach (string file in Directory.GetFiles(templates_folder))
            {
                if (Path.GetExtension(file) == EXTENSION)
                    templates.Add(file);
            }

            return templates.ToArray();
        }

        static private string Read_template_file(string template_name)
        {
            Create_folder();
            if (!File.Exists(get_full_path(template_name)))
                return null;

            string textFromFile = "";

            using (FileStream fstream = new FileStream(get_full_path(template_name), FileMode.Open))
            {
                // выделяем массив для считывания данных из файла
                byte[] buffer = new byte[fstream.Length];
                // считываем данные
                fstream.Read(buffer, 0, buffer.Length);
                // декодируем байты в строку
                textFromFile = Encoding.Default.GetString(buffer);
            }
            return textFromFile;
        }

        static public ExperimentData Upload_template(string template_name)
        {
            try
            {
                string json_ = Read_template_file(template_name);

                return JsonConvert.DeserializeObject<ExperimentData>(json_);
            }
            catch
            {
                return null;
            }
        }

        static public void Delete_template(string template_name)
        {
            Create_folder();

            if (!File.Exists(get_full_path(template_name)))
                return;

            File.Delete(get_full_path(template_name));
        }

    }
}