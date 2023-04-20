using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
using Reactor_Interface.Classes.Experiment;
using Reactor_Interface.Classes.GoogleAPI;
using Reactor_Interface.Classes.Templates;
using Reactor_Interface.Classes.Weigher;
using Reactor_Interface.Forms;
using Reactor_Interface.Forms.Experiment;
using Reactor_Interface.Forms.Journal;
using WindowsFormsApp1;
using WindowsFormsApp1.Classes;

namespace Reactor_Interface
{
    public partial class Jounral_menu : Form
    {
        private Chart _chart;
        private ExperimentData _experiment;
        private SerialPort weigherSerialPort = new SerialPort();
        private WeigherReader weigherReader;

        private readonly string weigherTag = "$МАССА$";

        public FileData serie;
        public string numer = "";

        private string weigherPort = null;

        private List<RichTextBox> weigherListBox = new List<RichTextBox>();

        public Jounral_menu(Chart chart = null)
        {
            InitializeComponent();
            weigherReader = new WeigherReader(weigherSerialPort);

            //weigherReader.OnMassGet += UpdateWeigherFields;
            _chart = chart; 
            googleDriveToolStripMenuItem.Text = "Google Drive: " + Drive.name;
            upload_ports();
            uploadCurrentExperiment();
            upload_drives();
        }

        private void upload_ports()
        {
            weigher_btn.DropDownItems.Clear();

            var ports = Port.get_ports();
            weigherPort = Interface_settings.get_weigher_port();

            foreach (var port in ports)
            {
                weigher_btn.DropDownItems.Add(port);
            }

            weigher_btn.Text = "Порт весов: ";
            weigher_btn.Text += string.IsNullOrEmpty(weigherPort) ? "Нет доступных портов" : weigherPort;

            weigherPort = weigherPort == null ? weigherSerialPort.PortName : weigherPort;
            
            weigherSerialPort.PortName = weigherPort;
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

        private void uploadCurrentExperiment()
        {
            var currentExperiment = ExperimentSystem.UploadCurrentExperiment();

            if (currentExperiment == null)
                return;

            uploadExperiment(currentExperiment);
        }

        private void uploadExperiment(ExperimentData experiment)
        {
            if (experiment == null)
                MessageBox.Show("Шаблон был повреждён. Невозможно загрузить.", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            else
            {
                _experiment = experiment;
                parseExperimentData(_experiment);
                SetExperimentName(_experiment.Name);
            }
        }

        private void parseExperimentData(ExperimentData experiment)
        {
            data_control.TabPages.Clear();

            weigherListBox.Clear();

            foreach (string page_name in experiment.Pages.Keys)
            {
                TabPage page = new TabPage
                {
                    Text = page_name,
                    BackColor = Control_settings.BackColor
                };

                foreach (FieldData field in experiment.Pages[page_name])
                {
                    Label field_label = new Label
                    {
                        Text = field.FieldName.ToString(),
                        AutoSize = true,
                        Location = new Point(Control_settings.label_x + field.Column * Control_settings.space_x,
                                             Control_settings.label_y + field.Row * Control_settings.space_y),
                    };

                    RichTextBox textBox = new RichTextBox
                    {
                        Size = new Size(Control_settings.textbox_width, Control_settings.text_box_height),
                        Location = new Point(Control_settings.textbox_x + field.Column * Control_settings.space_x,
                                             Control_settings.textbox_y + field.Row * Control_settings.space_y),
                        Name = field.Row.ToString() + "_" + field.Column.ToString() + Control_settings.textbox_suffix,
                        Tag = field.FieldName,
                        Text = field.FieldValue,
                        Multiline = false
                    };

                    //DPI.ResizeRichTextBox(textBox

                    if (field.MetaData.Contains(weigherTag))
                    {
                        textBox.ContextMenuStrip = context_menu;
                        textBox.BackColor = Color.LightGray;
                        weigherListBox.Add(textBox);
                    }

                    page.Controls.Add(field_label);
                    page.Controls.Add(textBox);
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

            if(serie == null)
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

            string exlname = string.Format("{0}_{1}.xlsx", serie, numer);

            string path = string.Format("{0}\\{1}", Google_service.GetFileTempFolderPath(), exlname);
            var experiment = TemplateSystem.get_experiment(data_control, _experiment);

            ExperimentExl.CreateExcelExperiment(path, experiment, _chart, comments_txtbx.Text);
            Drive.UploadFileOnDrive(path, serie, numer);
            MessageBox.Show("Файл успешно загружен!!!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void change_serie_menubtn_Click(object sender, EventArgs e)
        {
            if (!Internet_checker.CheckInternet())
            {
                MessageBox.Show("Отсутсвует подклчение к интернету", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            SerieChosenMenu serie = new SerieChosenMenu(this);
            serie.ShowDialog();
        }

        public void set_numer(string numer)
        {
            this.numer = numer;
        }

        public void set_serie(FileData serie)
        {
            this.serie = serie;
            this.Text = "Эксперимент. Серия: " + serie.Name;
            change_serie_menubtn.Text = "Выбрать серию: " + serie.Name;
        }

        public void upload_template(ExperimentData template)
        {
            uploadExperiment(template);
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

                var experiment = TemplateSystem.get_experiment(data_control, _experiment);

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

            string mass = weigherReader.GetMass();

            if(mass == null)
                MessageBox.Show("Проблема с подключением. Проверьте соединение с портом", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                textbox.Text = mass + " г";
        }

        private void get_mass_btn_Click(object sender, EventArgs e)
        {
            if (weigherListBox.Count == 0)
                return;

            Dictionary<string, List<RichTextBox>> massboxes = new Dictionary<string, List<RichTextBox>>();

            foreach(var massbox in weigherListBox)
            {
                string page = massbox.Parent.Text;
                
                if(massboxes.Keys.Contains(page))
                    massboxes[page].Add(massbox);
                else
                    massboxes.Add(page, new List<RichTextBox> { massbox });
            }

            Fill_mass_field_menu massFieldMenu = new Fill_mass_field_menu(massboxes, weigherReader);
            massFieldMenu.ShowDialog();
        }

        private void googleDriveToolStripMenuItem_DropDownItemClicked(object sender, EventArgs e)
        {

        }

        private void weigher_btn_Click(object sender, EventArgs e)
        {
            upload_ports();
        }

        private void CreateNewExperimentBtn_Click(object sender, EventArgs e)
        {
            Template_menu template = new Template_menu(this);
            template.Show();
        }

        private void UploadExperimentComputerBtn_Click(object sender, EventArgs e)
        {
            using (FileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Title = "Выберите эксперимент";
                fileDialog.Filter = string.Format("Experiment (*{0})|*{0}", ExperimentSystem.experimentExtension);

                if (fileDialog.ShowDialog() != DialogResult.OK)
                    return;

                string path = fileDialog.FileName;

                var experiment = ExperimentSystem.UploadExperiment(path);

                if (experiment == null)
                {
                    MessageBox.Show("Шаблон был удалён или повреждён", "Ошибка",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }

                _experiment = experiment;

                parseExperimentData(_experiment);
            }
        }

        private void experiment_btn_DropDownOpening(object sender, EventArgs e)
        {
            SaveExperimentBtn.Visible = _experiment != null;
        }

        private void SaveExperimentBtn_Click(object sender, EventArgs e)
        {
            using(SaveFileDialog fileDialog = new SaveFileDialog())
            {
                fileDialog.Title = "Выберите эксперимент";
                fileDialog.Filter = string.Format("Experiment (*{0})|*{0}", ExperimentSystem.experimentExtension);

                if (fileDialog.ShowDialog() != DialogResult.OK)
                    return;

                string path = fileDialog.FileName;
                string experimentName = Path.GetFileName(path);

                SetExperimentName(experimentName);
                _experiment = FormNewExperiment(experimentName);
                ExperimentSystem.SaveExperiment(_experiment, path);
            }
        }

        private void SetExperimentName(string experimentName)
        {
            experiment_btn.Text = "Эксперимент: " + experimentName;
        }

        private ExperimentData FormNewExperiment(string experimentName)
        {
            return ExperimentSystem.FormNewExperiment(data_control, experimentName, comments_txtbx.Text);
        }
    }

    struct Control_settings
    {
        public static Color BackColor = Color.WhiteSmoke;
        public static int label_x = 6, label_y = 17;
        public static int textbox_x = 11, textbox_y = 45;

        public static int textbox_width = (int)(DPI.factor.Width * 105), text_box_height = (int)(DPI.factor.Height * 30);

        public static int space_x = (int)(DPI.factor.Width * 270), space_y = (int)(DPI.factor.Height * 90);

        public static string label_suffix = "_lbl";
        public static string textbox_suffix = "_txtbx";
    }
}