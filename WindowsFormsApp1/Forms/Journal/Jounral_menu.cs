using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.VisualBasic;
using Newtonsoft.Json.Bson;
using Reactor_Interface.Classes;
using Reactor_Interface.Classes.GoogleAPI;
using Reactor_Interface.Classes.Templates;
using Reactor_Interface.Classes.Weigher;
using Reactor_Interface.Forms;
using Reactor_Interface.Forms.Experiment;
using WindowsFormsApp1;
using WindowsFormsApp1.Classes;

namespace Reactor_Interface
{
    public partial class Jounral_menu : Form
    {
        private Chart _chart;
        private Template template;
        private SerialPort weigherSerialPort = new SerialPort();
        private WeigherReader weigherReader;

        private readonly string weigherTag = "$МАССА$";

        public string serie = "";
        public string numer = "";

        private string weigherPort = null;

        private List<RichTextBox> weigherListBox = new List<RichTextBox>();

        public Jounral_menu(Chart chart = null)
        {
            InitializeComponent();
            weigherReader = new WeigherReader(weigherSerialPort);

            weigherReader.OnMassGet += UpdateWeigherFields;
            _chart = chart; 
            googleDriveToolStripMenuItem.Text = "Google Drive: " + Drive.name;
            upload_ports();
            upload_using_template();
            upload_drives();
        }

        private void upload_ports()
        {
            var ports = Port.get_ports();
            weigherPort = Interface_settings.get_weigher_port();

            foreach (var port in ports)
            {
                weigher_btn.DropDownItems.Add(port);
            }

            weigher_btn.Text = "Порт весов: " + weigherPort;
            weigherSerialPort.PortName = weigherTag;
        }

        private void weigher_btn_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            weigherPort = e.ClickedItem.Text;

            Interface_settings.save_weigher_port(weigherPort);
            weigher_btn.Text = "Порт весов: " + weigherSerialPort;
        }

        protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
        {
            base.ScaleControl(factor, specified);
            DPI.SetFactor(factor);
            //this.Size = new Size((int)((clear_btn.Location.X + clear_btn.Size.Width * 1.15) * factor.Width), 
                                 //(int)((clear_btn.Location.Y + clear_btn.Size.Height * 1.5) * factor.Height));
            this.MinimumSize = new Size(this.Width, this.Height);
            this.MaximumSize = this.MinimumSize;
        }

        private void upload_using_template()
        {
            string using_template_name = Template_system.get_using_template();
            if (!Template_system.IsTemplateCreated(using_template_name))
                return;

            template_btn.Text = "Шаблон: " + using_template_name;

            template = Template_system.Upload_template(using_template_name);
            parse_template(template);
        }

        private void parse_template(Template template)
        {
            data_control.TabPages.Clear();
            foreach (string page_name in template.Pages.Keys)
            {
                TabPage page = new TabPage {
                    Text = page_name,
                    BackColor = Control_settings.BackColor
                };

                for (int column = 0; column < template.Pages[page_name].Count; column++)
                {
                    for(int row = 0; row < template.Pages[page_name][column].Count; row++)
                    {
                        Label field_label = new Label
                        {
                            Text = template.Pages[page_name][column][row].First.ToString(),
                            AutoSize = true,
                            Location = new Point(Control_settings.label_x + column * Control_settings.space_x,
                                                 Control_settings.label_y + row * Control_settings.space_y),
                        };

                        RichTextBox textBox = new RichTextBox
                        {
                            Size = new Size(Control_settings.textbox_width, Control_settings.text_box_height),
                            Location = new Point(Control_settings.textbox_x + column * Control_settings.space_x,
                                                 Control_settings.textbox_y + row * Control_settings.space_y),
                            Name = column.ToString() + row.ToString() + Control_settings.textbox_suffix,
                            Tag = template.Pages[page_name][column][row].First,
                            Multiline = false
                        };

                        //DPI.ResizeRichTextBox(textBox

                        if (template.Pages[page_name][column][row].Second.ToString().Contains(weigherTag))
                        {
                            textBox.ContextMenuStrip = context_menu;
                            textBox.BackColor = Color.LightGray;
                            weigherListBox.Add(textBox);
                        }

                        page.Controls.Add(field_label);
                        page.Controls.Add(textBox);
                    }
                }

                data_control.TabPages.Add(page);
            }
        }

        private void upload_drives()
        {
            foreach(string drive in Google_data.Get_drives())
            {
                googleDriveToolStripMenuItem.DropDownItems.Add(drive);
            }
        }

        private void googleDriveToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string drive_name = e.ClickedItem.Text;
            Drive.Upload(drive_name);
            googleDriveToolStripMenuItem.Text = "Google Drive: " + Drive.name;
        }
        
        private void save_to_drive_btn_Click(object sender, EventArgs e)
        {
            var connect_result = Drive.Connect();

            string connect_error_text = Error_message.ConnectionError(connect_result);
            if(connect_error_text != "")
            {
                MessageBox.Show(connect_error_text, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            if(serie == "")
            {
                MessageBox.Show("Не указана серия экспериментов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            Numer_menu numer_menu = new Numer_menu(this);
            numer_menu.ShowDialog();

            if (numer == "")
            {
                MessageBox.Show("Не указан номер эксперимента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            Drive.UploadFileOnDrive("C:\\Users\\qweka\\Desktop\\Данные\\Крутые Графики.xlsx", serie, numer);
        }

        private void change_serie_menubtn_Click(object sender, EventArgs e)
        {
            Serie_exp_menu serie = new Serie_exp_menu(this);
            serie.ShowDialog();
        }

        public string get_serie()
        {
            return serie;
        }

        public void set_numer(string numer)
        {
            this.numer = numer;
        }
        public void set_serie(string serie)
        {
            this.serie = serie;
            this.Text = "Эксперимент. Серия: " + serie;
        }

        private void template_btn_Click(object sender, EventArgs e)
        {
            Template_menu template = new Template_menu(this);
            template.Show();
        }

        public void upload_template(Reactor_Interface.Classes.Templates.Template template)
        {
            upload_using_template();
        }

        private void SaveOnComp_btn_Click(object sender, EventArgs e)
        {
            string path = "";
            using (SaveFileDialog sf = new SaveFileDialog())
            {
                sf.Title = "Сохранить файл как...";
                sf.FileName = "График";
                sf.Filter = "*.xlsx|*.xlsx;";
                sf.DefaultExt = ".xlsx";

                if (sf.ShowDialog() == DialogResult.OK)
                {
                    path = sf.FileName;
                }
                else
                {
                    return;
                }

                var experiment = Template_system.get_experiment(data_control, template);

                ExperimentExl.CreateExcelExperiment(path, experiment, _chart, comments_txtbx.Text);

                MessageBox.Show("Excel файл сохранен", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void save_menubtn_Click(object sender, EventArgs e)
        {

        }

        public void UpdateWeigherFields(string data)
        {
            foreach(var textbox in weigherListBox)
            {
                textbox.Text = data;
            }
        }

        private RichTextBox getRichTextBoxFromContextMenuStrip(ToolStripItem toolStripItem)
        {
            if (toolStripItem == null)
                return null;

            ContextMenuStrip owner = toolStripItem.Owner as ContextMenuStrip;

            if (owner == null)
                return null;

            RichTextBox textbox = (RichTextBox)owner.SourceControl;

            return textbox;
        }

        private void context_menu_Opening(object sender, CancelEventArgs e)
        {
            RichTextBox textbox = (RichTextBox)context_menu.SourceControl;

            if (textbox == null)
                return;

            bool isWeigherfield = textbox.Tag.ToString().Contains(weigherTag);

            e.Cancel = !isWeigherfield;
        }

        private void weigh_btn_Click(object sender, EventArgs e)
        {
            var textbox = getRichTextBoxFromContextMenuStrip((ToolStripItem)sender);

            textbox.Text = "190";//weigherReader.GetMass();
        }

        private void get_mass_btn_Click(object sender, EventArgs e)
        {
            weigherReader.Test();
            return;

            try
            {
                weigherSerialPort.Open();

                weigherReader.UpdateMass();

                weigherSerialPort.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }
    }

    struct Control_settings
    {
        public static Color BackColor = Color.WhiteSmoke;
        public static int label_x = 6, label_y = 27;
        public static int textbox_x = 11, textbox_y = 55;

        public static int textbox_width = (int)(DPI.factor.Width * 105), text_box_height = (int)(DPI.factor.Height * 30);

        public static int space_x = (int)(DPI.factor.Width * 270), space_y = (int)(DPI.factor.Height * 100);

        public static string label_suffix = "_lbl";
        public static string textbox_suffix = "_txtbx";
    }
}