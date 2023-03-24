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

namespace Reactor_Interface.Classes
{
    static class Template_system
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

        static public bool IsTemplateCreated(string name)
        {
            Directory.CreateDirectory(templates_folder);

            return File.Exists(get_full_path(name));
        }

        static public Save_result Create_template_json(TabControl template_control, string name)
        {
            Dictionary<string, List<List<string>>> pages = new Dictionary<string, List<List<string>>>();

            foreach (TabPage page in template_control.TabPages)
            {
                string name_page = page.Text;
                List<List<string>> fields = new List<List<string>>();
                for (int i = 0; i < Create_template_menu.columns; i++)
                {
                    List<string> column = new List<string>();
                    for (int y = 0; y < Create_template_menu.rows; y++)
                    {
                        string item_id = i.ToString() + y.ToString();
                        var textbox = page.Controls.Find(item_id + Create_template_menu.text_box_item_suffix, true)
                                                        .FirstOrDefault();
                        if (textbox == null)
                            continue;
                        if (textbox.Text == "")
                            return Save_result.EmptyFiled;
                        column.Add(textbox.Text);
                    }
                    if (column.Count > 0)
                        fields.Add(column);
                }
                if(fields.Count > 0)
                    pages.Add(name_page, fields);
            }
            if (pages.Count == 0)
                return Save_result.EmptyPages;
            try
            {
                Template template = new Template(name, pages);
                string str_template = JsonConvert.SerializeObject(template);
                Write_template_to_file(str_template, name);
            }
            catch
            {
                return Save_result.CreationError;
            }
            return Save_result.Saved;
        }
        static public Save_result Create_template(TabControl template_control, string name)
        {
            string template = "";

            foreach (TabPage page in template_control.TabPages)
            {
                template += page.Text;
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
                        template += "\r\t"+ textbox.Text;
                    }
                    template += (i < Create_template_menu.columns) ? "\r\t" : "";
                }
                template += "\r" + page_separator + '\r';
            }
            try
            {
                Write_template_to_file(template, name);
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

        static public Template Upload_template(string template_name)
        {
            try
            {
                string json_ = Read_template_file(template_name);

                return JsonConvert.DeserializeObject<Template>(json_);
            }
            catch
            {
                return null;
            }
        }

        static public void Save_using_template_registry(string template_name)
        {
            Interface_settings.save_using_template(template_name);
        }

        static public string get_using_template()
        {
            return Interface_settings.get_using_template();
        }

        static public void Delete_template(string template_name)
        {
            Create_folder();

            if (!File.Exists(get_full_path(template_name)))
                return;

            File.Delete(get_full_path(template_name));

            if (Interface_settings.get_using_template() == template_name)
                Interface_settings.save_using_template("");
        }

    }
}