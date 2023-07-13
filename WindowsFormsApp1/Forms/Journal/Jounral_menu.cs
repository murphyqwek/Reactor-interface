using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
using Newtonsoft.Json.Bson;
using Reactor_Interface.Classes;
using Reactor_Interface.Classes.Exceptions;
using Reactor_Interface.Classes.Experiment;
using Reactor_Interface.Classes.GoogleAPI;
using Reactor_Interface.Classes.Message;
using Reactor_Interface.Classes.Serie;
using Reactor_Interface.Classes.Templates;
using Reactor_Interface.Classes.Weigher;
using Reactor_Interface.Forms;
using Reactor_Interface.Forms.Experiment;
using Reactor_Interface.Forms.Journal;
using Reactor_Interface.Forms.Journal.SerieMenus;
using Reactor_Interface.Forms.Template;
using WindowsFormsApp1;
using WindowsFormsApp1.Classes;
using Buffer = Reactor_Interface.Classes.Buffer;

namespace Reactor_Interface
{
    public partial class Jounral_menu : Form
    {
        private Chart _chart;
        private ExperimentData _experiment;
        private SerieData _serie;
        private SerialPort weigherSerialPort = new SerialPort();
        private WeigherReader weigherReader;
        private Main_menu _mainMenu;

        private SerieExperimentMetaData _serieExperimentMetaData;

        private readonly string weigherTag = "$МАССА$";
        private readonly string diskPreffix = "D_";
        private readonly string computerPreffix = "C_";

        public FileData DiskSerie;
        public string numer = "";

        private string weigherPort = null;

        private string LoadFrom = null;

        private List<RichTextBox> weigherListBox = new List<RichTextBox>();

        private bool _isSaved = true;

        private Buffer buffer = new Buffer();

        private Dictionary<string, RichTextBox> Fields;

        private bool bufferUploading = false;

        private Dictionary<string, string[,]> prevdata = new Dictionary<string, string[,]>();
        private string prevCommentText;

        public bool IsSaved 
        {
            get
            {
                return _isSaved;
            }

            private set
            {
                _isSaved = value;

                experiment_btn.Text = "Эксперимент: ";
                if (_experiment != null)
                    experiment_btn.Text += _experiment.Name;

                experiment_btn.Text += _isSaved ? "" : "*";
            }
        }

        public Jounral_menu(SerieData serie, Chart chart = null, Main_menu _mainMenu = null)
        {
            setupJournal(chart, _mainMenu);

            QuitSerieBtn.Visible = true;
            AddTemplatesBtn.Visible = true;

            CreateTemplateBasedOnExperimentBtn.Visible = false;
            changeExperimentTemplatebtn.Visible = false;
            SaveExperimentBtn.Visible = false;
            CreateNewExperimentBtn.Visible = false;
            renameExperimentBtn.Visible = false;
            UploadExperimentBtn.Visible = false;

            _serie = serie;

            Text = "Журнал. Серия: " + serie.Name; 
            this.Focus();
        }

        public Jounral_menu(Chart chart = null, Main_menu _mainMenu = null)
        {
            setupJournal(chart, _mainMenu);
            uploadCurrentExperiment();
        }

        private void setupJournal(Chart chart, Main_menu _mainMenu)
        {
            InitializeComponent();

            weigherReader = new WeigherReader(weigherSerialPort);

            _chart = chart;

            this._mainMenu = _mainMenu;

            if (chart == null)
                UploadNewGraphBtn.Visible = false;

            googleDriveToolStripMenuItem.Text = "Google Drive: " + Drive.name;
            upload_ports();
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
            weigher_btn.Text += weigherPort;

            weigherPort = weigherPort ?? weigherSerialPort.PortName;
            
            weigherSerialPort.PortName = weigherPort;
        }

        private void weigher_btn_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            weigherPort = e.ClickedItem.Text;

            Interface_settings.save_weigher_port(weigherPort);
            weigher_btn.Text = "Порт весов: " + weigherPort;
            weigherSerialPort.PortName = weigherPort;
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
            string expPath = ExperimentSystem.GetCurrentExperimentPath();

            if (currentExperiment == null)
                return;

            uploadExperimentFromComputer(currentExperiment, expPath, false);
        }

        private void uploadExperimentFromComputer(ExperimentData experiment, string loadFromPath, bool SaveIntoRegister)
        {
            if (experiment == null)
                ErrorMessage.Show("Шаблон был повреждён. Невозможно загрузить.");
            else
            {
                LoadFrom = computerPreffix + Path.GetDirectoryName(loadFromPath);
                _experiment = experiment;
                parseExperimentData(_experiment);
                SetExperimentName(_experiment.Name);
                IsSaved = true;
                if (SaveIntoRegister)
                    ExperimentSystem.SetCurrentExperimentIntoRegister(loadFromPath);
            }
        }

        private void parseExperimentData(ExperimentData experiment)
        {
            buffer.Clear();

            Fields = new Dictionary<string, RichTextBox>();
            prevdata = new Dictionary<string, string[,]>();
            prevCommentText = "";

            data_control.TabPages.Clear();

            weigherListBox.Clear();

            foreach (string page_name in experiment.Pages.Keys)
            {
                TabPage page = new TabPage
                {
                    Text = page_name,
                    BackColor = Control_settings.BackColor
                };

                string[,] prevdataPage = new string[4, 3];

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
                        Multiline = false,  
                    };

                    prevdataPage[field.Row, field.Column] = textBox.Text;

                    textBox.TextChanged += onTextChanged;
                    //textBox.GotFocus += onGetFocus;
                    //DPI.ResizeRichTextBox(textBox

                    if (field.MetaData.Contains(weigherTag))
                    {
                        textBox.ContextMenuStrip = context_menu;
                        textBox.BackColor = Color.LightGray;
                        textBox.DoubleClick += DobuleClickMass;
                        weigherListBox.Add(textBox);
                        textBox.MouseHover += showToolTip;
                        //textBox.MouseHover
                    }

                    if (Fields.ContainsKey(field_label.Text))
                    {
                        IsSaved = false;
                        field_label.Text += "1";
                    }


                    Fields.Add(field_label.Text, textBox);
                    page.Controls.Add(field_label);
                    page.Controls.Add(textBox);
                }

                data_control.TabPages.Add(page);
                prevdata.Add(page_name, prevdataPage);
            }

            comments_txtbx.Text = experiment.Comments;
            prevCommentText = experiment.Comments;
        }

        private void TextBox_GotFocus(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void onGetFocus(object sender, EventArgs e)
        {

        }

        private void showToolTip(object sender, EventArgs e)
        {
            RichTextBox TB = (RichTextBox)sender;
            int VisibleTime = 1000;

            ToolTip tt = new ToolTip();
            tt.Show("Щёлкните два раза левой кнопкой мыши чтобы записать массу", TB, VisibleTime);
        }

        private void DobuleClickMass(object sender, EventArgs e)
        {
            RichTextBox textBox = (RichTextBox)sender;

            getMass(textBox);
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
                ErrorMessage.Show(connect_error_text);
                return;
            }

            if(DiskSerie == null)
            {
                ErrorMessage.Show("Не указана серия экспериментов");
                return;
            }

            Numer_menu numer_menu = new Numer_menu(this);
            numer_menu.ShowDialog();

            if (numer == "")
            {
                ErrorMessage.Show("Не указан номер эксперимента");
                return;
            }

            string exlname = string.Format("{0}_{1}.xlsx", DiskSerie, numer);

            string path = string.Format("{0}\\{1}", Google_service.GetFileTempFolderPath(), exlname);

            //ExperimentExl.CreateExcelExperiment(path, experiment);
            Drive.UploadFileOnDrive(path, DiskSerie, numer);
            SuccesMessage.Show("Файл успешно загружен!!!");
        }

        private void change_serie_menubtn_Click(object sender, EventArgs e)
        {
            if (!Internet_checker.CheckInternet())
            {
                ErrorMessage.Show("Отсутсвует подклчение к интернету");
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
            this.DiskSerie = serie;
            this.Text = "Эксперимент. Серия: " + serie.Name;
            change_serie_menubtn.Text = "Выбрать серию: " + serie.Name;
        }

        public void upload_template(ExperimentData template)
        {
            uploadExperimentFromComputer(template, null, false);
            IsSaved = false;
        }

        public void UploadChangedExperiment(ExperimentData experiment)
        {
            parseExperimentData(experiment);
            _experiment = experiment;
            IsSaved = false;
        }

        private void SaveOnComp_btn_Click(object sender, EventArgs e)
        {
            if (!IsSaved)
            {
                MessageBox.Show("Эксперимент не сохранён. Прежде сохранить отчёт, сохраните эксперимент", "Внимание",
                                MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            string path = "";
            using (SaveFileDialog sf = new SaveFileDialog())
            {
                sf.Title = "Сохранить файл как...";
                sf.FileName = _experiment.Name + " Отчёт";
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

                ExperimentExl.CreateExcelExperiment(path, _experiment);
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

        private void getMass(RichTextBox textBox)
        {
            string mass = weigherReader.GetMass();

            if (mass == null)
                ErrorMessage.Show("Проблема с подключением к весам. Проверьте соединение с портом");
            else
                textBox.Text = mass;
        }

        private void weigh_btn_Click(object sender, EventArgs e)
        {
            var textbox = getRichTextBoxFromContextMenuStrip((ToolStripItem)sender);

            getMass(textbox);
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

        private void CreateNewExperimentBtn_Click(object sender, EventArgs e)
        {
            Template_menu template = new Template_menu(this);
            template.Show();
        }

        private void GetUploadedExperimentFromComputer()
        {
            if (NeedToCancel())
                return;

            string path = ExperimentSystem.GetExperimentPath();

            var experiment = ExperimentSystem.UploadExperiment(path, false);
            uploadExperimentFromComputer(experiment, path, true);
        }

        private void UploadExperimentComputerBtn_Click(object sender, EventArgs e)
        {
            GetUploadedExperimentFromComputer();
        }

        private void experiment_btn_DropDownOpening(object sender, EventArgs e)
        {
            bool isExperimentNotNull = _experiment != null;
            bool isNotSerie = _serie == null;
            SaveExperimentBtn.Visible = isExperimentNotNull & isNotSerie;
            renameExperimentBtn.Visible = isExperimentNotNull & isNotSerie;
            changeExperimentTemplatebtn.Visible = isExperimentNotNull & isNotSerie;
            CreateTemplateBasedOnExperimentBtn.Visible = isExperimentNotNull & isNotSerie;
            DataExperimentBtn.Visible = isExperimentNotNull;
            CreateExperimentSerieBtn.Visible = !isNotSerie;
            ShowSerieExperimentsBtn.Visible = !isNotSerie;
        }

        public void SaveExperimentOnComputer()
        {
            string folderPath;
            string experimentName;

            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Выберите папку эксперимента";

                DialogResult result = fbd.ShowDialog();

                if (result != DialogResult.OK || string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    return;

                folderPath = fbd.SelectedPath;
            }

            using (InputFormMenu inputForm = new InputFormMenu("Создание нового эксперимента", "Введите название эксперимента"))
            {
                if(inputForm.ShowDialog() != DialogResult.OK)
                    return;

                experimentName = inputForm.OutputValue.Trim();
            }

            if (string.IsNullOrEmpty(experimentName))
            {
                ErrorMessage.Show("Пустое название");
                return;
            } 

            folderPath = Path.Combine(folderPath, experimentName);

            if (Directory.Exists(folderPath))
            {
                ErrorMessage.Show("Папка с таким названием уже существует");
                return;
            }

            Directory.CreateDirectory(folderPath);
            LoadFrom = computerPreffix + folderPath;
            SetExperimentName(experimentName);
            _experiment = FormNewExperiment(experimentName, _experiment.ApplianceData, _experiment.ConnectedFields);
            ExperimentSystem.SaveExperimentOnComputer(_experiment, folderPath);
            ExperimentSystem.SetCurrentExperimentIntoRegister(Path.Combine(folderPath, experimentName + ExperimentSystem.EXTENSION));
            IsSaved = true;
        }

        private void SaveAutomaticly()
        {
            if (IsSaved)
                return;

            if(_serie != null && _experiment != null)
            {
                SaveSerieExperiment();
                return;
            }

            if (string.IsNullOrEmpty(LoadFrom))
            {
                SaveExperimentOnComputer();
                return;
            }

            string path = LoadFrom.Substring(2);
            if (LoadFrom.StartsWith(computerPreffix))
            {
                if (!ExperimentSystem.IsExperimentExists(path, _experiment.Name,
                                                    ExperimentSystem.ExperimentStorePlace.OnComputer))
                {
                    SaveExperimentOnComputer();
                }
                else
                {
                    _experiment = FormNewExperiment(_experiment.Name, _experiment.ApplianceData, _experiment.ConnectedFields);
                    ExperimentSystem.SaveExperimentOnComputer(_experiment, path);
                    ExperimentSystem.SetCurrentExperimentIntoRegister(Path.Combine(path, _experiment.GetFileName()));
                    IsSaved = true;
                }
            }

            if (LoadFrom.StartsWith(diskPreffix))
            {
                if (!Internet_checker.CheckInternet())
                {
                    ErrorMessage.Show("Отсутсвует подключение к интернету");
                    return;
                }

                if (!ExperimentSystem.IsExperimentExists(path, _experiment.Name,
                                                    ExperimentSystem.ExperimentStorePlace.OnComputer))
                {
                    ErrorMessage.Show("Ошибка при сохранении файла. Проверьте, подключены ли вы к диску");
                    return;
                }

                _experiment = FormNewExperiment(_experiment.Name, _experiment.ApplianceData, _experiment.ConnectedFields);
                ExperimentSystem.SaveExperimentOnDisk(_experiment, path);
            }
        }

        private void SaveExperimentBtn_Click(object sender, EventArgs e)
        {
            experiment_btn.HideDropDown();
            SaveAutomaticly();
        }

        private void SetExperimentName(string experimentName)
        {
            experiment_btn.Text = "Эксперимент: " + experimentName;
        }

        private ExperimentData FormNewExperiment(string experimentName, Dictionary<string, ApplianceData> appData, List<ConnectedFields> connectedFields)
        {
            return ExperimentSystem.FormNewExperiment(data_control, experimentName, comments_txtbx.Text, appData, connectedFields);
        }

        private void onTextChanged(object sender, EventArgs e)
        {
            IsSaved = false;
            if (!bufferUploading) {
                RichTextBox textBox = (RichTextBox)sender;
                string oldText;
                if (textBox.Name == comments_txtbx.Name)
                {
                    oldText = prevCommentText;
                    prevCommentText = comments_txtbx.Text;
                }
                else
                {
                    var splittedName = textBox.Name.Split('_');//BACK
                    int row = Convert.ToInt32(splittedName[0]), column = Convert.ToInt32(splittedName[1]);
                    oldText = prevdata[data_control.SelectedTab.Text][row, column];
                    prevdata[data_control.SelectedTab.Text][row, column] = textBox.Text;
                }
                buffer.Add(textBox, oldText, data_control.SelectedTab.Text);
            }
        }

        public bool NeedToCancel()
        {
            if (IsSaved)
                return false;

            var result = MessageBox.Show("Эксперимент не сохранён. Вы хотите его сохранить?", "Внимание",
                                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
            {
                SaveAutomaticly();
                return false;
            }
            if (result == DialogResult.No)
                return false;
            else
                return true;
        }

        private void SaveExperiment()
        {
            if (_serie != null)
            {
                _experiment = FormNewExperiment(_experiment.Name, _experiment.ApplianceData, _experiment.ConnectedFields);
                SerieSystem.AddExperiment(_serie, _experiment, _serieExperimentMetaData);
                return;
            }

            var store = LoadFrom.Substring(0, 2) == computerPreffix ? ExperimentSystem.ExperimentStorePlace.OnComputer : ExperimentSystem.ExperimentStorePlace.OnDisk;
            string path = LoadFrom.Substring(2);
            if (IsSaved && !ExperimentSystem.IsExperimentExists(path, _experiment.Name, store))
            {
                SaveExperimentOnComputer();
            }
        }

        private void Jounral_menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_experiment == null)
            {
                e.Cancel = false;
                return;
            }
            e.Cancel = NeedToCancel();
        }

        private void DataExperimentBtn_DropDownOpening(object sender, EventArgs e)
        {
            if (_experiment.ApplianceData == null)
            {
                SeeGraphBtn.Visible = false;
                ClearGraphBtn.Visible = false;
            }
            else
            {
                SeeGraphBtn.Visible = true;
                ClearGraphBtn.Visible = true;
            }

        }

        private void ClearGraphBtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы точно хотите очистить данные с оборудования? Данные будут утеряны", "Внимание",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                _experiment.ClearApplianceData();
                IsSaved = false;
            }
        }

        private void UploadNewGraphBtn_Click(object sender, EventArgs e)
        {
            if(_experiment.ApplianceData == null)
            {
                ExperimentSystem.UploadApplianceDataToExperiment(ref _experiment, _chart.Series);
                SuccesMessage.Show("Данные загружены");
                IsSaved = false;
                return;
            }

            var result = MessageBox.Show("Вы точно хотите загрузить новые данные с оборудования? Данные будут утеряны", "Внимание",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                ExperimentSystem.UploadApplianceDataToExperiment(ref _experiment, _chart.Series);
                SuccesMessage.Show("Данные загружены");
                IsSaved = false;
            }
        }

        private void SeeGraphBtn_Click(object sender, EventArgs e)
        {
            ExperimentGraphicDemonstationMenu graphicMenu = new ExperimentGraphicDemonstationMenu(_experiment);
            graphicMenu.ShowDialog();
        }

        private void SaveOnComputerBtn_Click(object sender, EventArgs e)
        {
            experiment_btn.HideDropDown();
            SaveExperimentOnComputer();
        }

        private void renameExperimentBtn_Click(object sender, EventArgs e)
        {
            string newExperimentName;

            using(InputFormMenu inputForm = new InputFormMenu("Переименовать", "Введите новое название"))
            {
                if (inputForm.ShowDialog() != DialogResult.OK)
                    return;

                newExperimentName = inputForm.OutputValue;
            }

            newExperimentName = newExperimentName.Trim();

            if(string.IsNullOrEmpty(newExperimentName))
            {
                ErrorMessage.Show("Пустое название");
                return;
            }

            string placePreffix = LoadFrom.Substring(0, 2);
            ExperimentSystem.ExperimentStorePlace place = (placePreffix == computerPreffix) ? ExperimentSystem.ExperimentStorePlace.OnComputer : ExperimentSystem.ExperimentStorePlace.OnDisk;

            LoadFrom = ExperimentSystem.RenameExperiment(_experiment, newExperimentName, LoadFrom.Substring(2), place);
            string path = LoadFrom;
            LoadFrom = LoadFrom != null ? placePreffix + LoadFrom : null;

            if (newExperimentName != _experiment.Name)
            {
                _experiment.Rename(newExperimentName);
                if (path != null)
                {
                    experiment_btn.Text = "Эксперимент: " + _experiment.Name;
                    ExperimentSystem.SaveExperimentOnComputer(_experiment, path);
                }
                else
                {
                    IsSaved = false;
                    SaveExperimentOnComputer();
                }

            }
        }

        private void weigher_btn_DropDownOpening(object sender, EventArgs e)
        {
            upload_ports();
        }

        private void UploadDataFromOtherApplianceBtn_Click(object sender, EventArgs e)
        {
            if (LoadFrom.Length <= 2)
            {
                ErrorMessage.Show("Эксперимент не был сохранён на компьютер. Прежде чем загрузить данные, сохраните эксперимент");
                return;
            }

            if (!Directory.Exists(LoadFrom.Substring(2)))
            {
                Directory.CreateDirectory(LoadFrom.Substring(2));
                string filePath = Path.Combine(LoadFrom.Substring(2), _experiment.GetFileName());
                _experiment = FormNewExperiment(_experiment.Name, _experiment.ApplianceData, _experiment.ConnectedFields);
                ExperimentSystem.SaveExperiment(_experiment, filePath);
                IsSaved = true;
            }

            UploadingApplicienceDataMenu dataMenu = new UploadingApplicienceDataMenu(_chart, _experiment, LoadFrom.Substring(2));
            var result = dataMenu.ShowDialog();

            if (result == DialogResult.Yes)
                IsSaved = false;
        }

        private void changeExperimentTemplatebtn_Click(object sender, EventArgs e)
        {
            _experiment = FormNewExperiment(_experiment.Name, _experiment.ApplianceData, _experiment.ConnectedFields);
            Create_template_menu template_Menu = new Create_template_menu(_experiment, this);
            template_Menu.ShowDialog();
        }

        public void CreateNewSerie(ExperimentData template, string templatePath)
        {
            SerieData serie = SerieSystem.CreateNewSerie(template, templatePath);

            if(serie  == null) return;

            this.Close();
            OpenNewJounral(serie);
            //jounralSerie.Focus();
            //jounralSerie.
        }


        private void CreateNewSerieBtn_Click(object sender, EventArgs e)
        {
            if (!ConfirmMessageBox.Show("Вы уверены, что хотите создать новую серию?"))
                return;

            if (NeedToCancel())
            {
                return;
            }
            GetTemplateMenu getTemplateMenu = new GetTemplateMenu(CreateNewSerie);
            getTemplateMenu.ShowDialog();
        }

        private void QuitSerieBtn_Click(object sender, EventArgs e)
        {
            if (!ConfirmMessageBox.Show("Вы уверены, что хотите выйти из режима серии экспериментов?"))
                return;

            if(!IsSaved && _experiment != null)
            {
                MessageBox.Show("Перед выходом сохраните текущий эксперимент", "Внимание",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            OpenNewJounral();
        }

        private void ChooseSerieBtn_Click(object sender, EventArgs e)
        {
            if (NeedToCancel())
            {
                return;
            }


            SerieData newSerie = SerieSystem.GetSerie();

            if (newSerie == null)
                return;

            this.Close();
            OpenNewJounral(newSerie);
        }

        private void OpenNewJounral(SerieData Serie = null)
        {
            Jounral_menu newJournal = new Jounral_menu(_chart, _mainMenu);

            if (Serie != null)
                newJournal = new Jounral_menu(Serie, _chart, _mainMenu);

            this.Hide();
            if (_mainMenu != null)
            {
                _mainMenu.ShowNewJounral(newJournal);
            }
            else
                newJournal.Show();
        }

        private void CreateExperimentSerieBtn_Click(object sender, EventArgs e)
        {
            CreateNewSerieExperiment createNewSerieMenu = new CreateNewSerieExperiment(_serie, UploadSerieExperiment);
            createNewSerieMenu.ShowDialog();
        }

        private void AddTemplatesBtn_Click(object sender, EventArgs e)
        {
            GetTemplateMenu getTemplateMenu = new GetTemplateMenu(AddNewTemplateToSerie);
            getTemplateMenu.ShowDialog();
        }

        private void AddNewTemplateToSerie(ExperimentData template, string templatePath)
        {
            SerieSystem.AddNewTemplateToSerie(_serie, template, templatePath);
        }

        private void ShowSerieExperimentsBtn_Click(object sender, EventArgs e)
        {
            SerieExperimentsMenu serieExperimentsMenu = new SerieExperimentsMenu(_serie, UploadSerieExperiment, _experiment?.Name);
            serieExperimentsMenu.ShowDialog();
        }

        public void UploadSerieExperiment(SerieExperimentMetaData serieExperiment, ExperimentData experiment, bool isSaved, string loadFrom)
        {
            if(_experiment != null && !IsSaved)
            {
                ErrorMessage.Show("Текущий эксперимент не сохранён");
                return;
            }

            if (experiment == null)
            {
                SetNullExperiment();
                return;
            }

            LoadFrom = computerPreffix + loadFrom;
            _experiment = experiment;
            parseExperimentData(experiment);
            SetExperimentName(experiment.Name);

            _serieExperimentMetaData = serieExperiment;
            IsSaved = isSaved;
            SaveSerieExperimentBtn.Visible = true;
        }

        private void SetNullExperiment()
        {
            SaveSerieExperimentBtn.Visible = false;
            _experiment = null;
            IsSaved = true;
            data_control.TabPages.Clear();
            comments_txtbx.Clear();
        }

        private void SaveSerieExperiment()
        {
            try
            {
                _experiment = FormNewExperiment(_experiment.Name, _experiment.ApplianceData, _experiment.ConnectedFields);
                SerieSystem.AddExperiment(_serie, _experiment, _serieExperimentMetaData);
                IsSaved = true;
            }
            catch (NullTemplateException ex)
            {
                ErrorMessage.Show(ex.Message);
                //SetNullExperiment();
            }
            catch (ExperimentIsNotCapableWithTemplateExcpetion ex)
            {
                ErrorMessage.Show(ex.Message);
                //SetNullExperiment();
            }
            catch (Exception ex)
            {
                ErrorMessage.Show(ex.Message);
            }
        }

        private void SaveSerieExperimentBtn_Click(object sender, EventArgs e)
        {
            if (!ConfirmMessageBox.Show("Вы действительно хотите сохранить эксперимент?"))
                return;

            SaveSerieExperiment();
        }

        private void CreateTemplateBasedOnExperimentBtn_Click(object sender, EventArgs e)
        {
            string input;
            using (InputFormMenu inputForm = new InputFormMenu("Новый шаблон", "Введите название шаблона", _experiment.Name))
            {
                var result = inputForm.ShowDialog();

                if (result != DialogResult.OK)
                    return;

                input = inputForm.OutputValue;

                input = input.Trim();
            }

            if (string.IsNullOrEmpty(input)) 
            {
                ErrorMessage.Show("Пустое название");
                return;
            }

            if (TemplateSystem.IsTemplateCreated(input))
            {
                ErrorMessage.Show("Шаблон с таким названием уже существует. Выберите другое название");
                return;
            }

            TemplateSystem.CreateTemplateBasedOnExperiment(_experiment, input);

            SuccesMessage.Show("Шаблон создан");
        }

        private void Jounral_menu_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control && e.KeyCode == Keys.S)
            {
                SaveAutomaticly();
            }
            else if (e.Control && e.KeyCode == Keys.Z)
            {
                var changedTextBox = buffer.Pop();
                if (changedTextBox.Item1 == null)
                    return;

                bufferUploading = true;
                if(changedTextBox.Item1.Name == comments_txtbx.Name)
                {
                    prevCommentText = comments_txtbx.Text;
                }
                else
                {
                    var splittedName = changedTextBox.Item1.Name.Split('_');
                    int row = Convert.ToInt32(splittedName[0]), column = Convert.ToInt32(splittedName[1]);
                    prevdata[changedTextBox.Item3][row, column] = changedTextBox.Item1.Text;
                }

                changedTextBox.Item1.Text = changedTextBox.Item2;
                bufferUploading = false;
            }
        }

        private void FeedBack(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch (Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    ErrorMessage.Show(noBrowser.Message);
            }
            catch
            {
                ErrorMessage.Show("Ошибка при открытии барузера");
            }
        }

        private void sendErrorBtn_Click(object sender, EventArgs e)
        {
            FeedBack("https://forms.gle/zwM4ofZKikWPyGch8");
        }

        private void reviewBtn_Click(object sender, EventArgs e)
        {
            FeedBack("https://forms.gle/ufUjPETeZdXFXVtq6");
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            if (!ConfirmMessageBox.Show("Вы уверены, что хотите очистить поля эксперимента?"))
                return;

            foreach (var field in Fields.Values)
                field.Text = "";

            comments_txtbx.Text = "";
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