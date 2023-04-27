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

namespace Reactor_Interface.Classes
{
    static class TemplateSystem
    {
        static private readonly string templates_folder = Environment.GetFolderPath(
                                                            Environment.SpecialFolder.ApplicationData) 
                                                          + "\\Journal templates\\";

        static private readonly string page_separator = string.Concat(Enumerable.Repeat("-" , Create_template_menu.max_txtbx_len + 10));
        static private readonly string extension = ".template";

        public enum Save_result {
            EmptyFiled,
            EmptyPages,
            CreationError,
            Saved
        }
        
        static private string get_full_path(string name)
        {
            return templates_folder + name + extension;
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

        static public Save_result Create_template_json(TabControl template_control, string name)
        {
            Dictionary<string, List<FieldData>> pages = new Dictionary<string, List<FieldData>>();

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
                            return Save_result.EmptyFiled;

                        fields.Add(new FieldData(textbox.Text, textbox.Tag.ToString(), "", y, i));
                    }
                }
                pages.Add(name_page, fields);
            }
            if (pages.Count == 0)
                return Save_result.EmptyPages;
            try
            {
                ExperimentData template = new ExperimentData("Новый эксперимент", pages);
                string str_template = JsonConvert.SerializeObject(template);
                Write_template_to_file(str_template, name);
            }
            catch
            {
                return Save_result.CreationError;
            }
            return Save_result.Saved;
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

        static public string[] get_template_array()
        {
            Create_folder();

            List<string> templates = new List<string>();
            foreach(string file in Directory.GetFiles(templates_folder))
            {
                if (Path.GetExtension(file) == extension)
                    templates.Add(Path.GetFileNameWithoutExtension(file));
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