using Reactor_Interface.Classes;
using Reactor_Interface.Classes.Message;
using Reactor_Interface.Classes.Presets;
using Reactor_Interface.Forms.Journal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Classes;

namespace WindowsFormsApp1
{
    public partial class PresetRedactorMenu : Form
    {
        private KoefPreset preset;

        private List<string[]> TigelTempKoeff = new List<string[]>();
        private List<string[]> VoilokTempKoeff = new List<string[]>();

        private bool _isSaved = true;
        private bool isProgramInput;

        private bool IsSaved
        {
            get { return _isSaved; }
            set 
            {
                if (preset != null)
                    Text = "Редактирование пресета: " + preset.Name;

                if (!value && preset != null)
                {
                     Text += "*";
                }

                _isSaved = value; 
            }
        }

        public PresetRedactorMenu()
        {
            InitializeComponent();
            ClearTempLists();
            LoadPresets();
        }

        private void ClearTempList(ref List<string[]> tempList)
        {
            tempList = new List<string[]>();

            for(int i = 0; i < PresetSystem.TOKMODECOUNT; i++)
            {
                string[] mode = new string[4];
                for(int j = 0; j < 4; j++)
                {
                    mode[j] = "";
                }
                tempList.Add(mode);
            }
        }

        private void LoadPresets()
        {
            PresetTreeList.Nodes.Clear();
            foreach (var preset in PresetSystem.GetKoefPresets())
            {
                var Node = PresetTreeList.Nodes.Add(preset.Name);

                //Node.ToolTipText = preset.getPresetToolTipText();
                Node.ContextMenuStrip = PresetContextMenuStrip;
            }
        }

        private void ClearTempLists()
        {
            ClearTempList(ref TigelTempKoeff);
            ClearTempList(ref VoilokTempKoeff);
        }

        private void UpdateListBtn_Click(object sender, EventArgs e)
        {
            LoadPresets();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void OpenPresetsFolderBtn_Click(object sender, EventArgs e)
        {
            PresetSystem.OpenPresetsFolder();
        }

        private void ImportPresetBtn_Click(object sender, EventArgs e)
        {
            if (PresetSystem.ImportPreset())
                LoadPresets();
        }

        private void CreateNewPersetBtn_Click(object sender, EventArgs e)
        {
            if (!IsSaved)
            {
                bool confirmed = ConfirmMessageBox.Show("Текущий пресет не сохранён. Вы точно хотите создать новый шаблон?\nВНИМАНИЕ: при создании нового шаблона изменения не будут сохранены");
                if (!confirmed)
                    return;
            }

            isProgramInput = true;
            ClearKoeffPresetMenu();
            NameTextBox.Text = "";
            Text = "Создание нового пресета";
            SaveBtn.Visible = true;
            SaveBtn.Text = "Сохранить новый шаблон";
            preset = null;
            TigelKoefRadioButton.Checked = true;
            IsSaved = false;
            isProgramInput = false;
            DeletePresetBtn.Visible = false;
        }

        private void ClearKoeffPresetMenu()
        {
            SetKoeffMenuVisible(true);
            ClearAllTabs();
            ClearTempLists();
        }

        private void ClearAllTabs()
        {
            for (int i = 0; i < KoeffTabControl.TabPages.Count; i++)
                ClearTab(i);
        }

        private void ClearTab(int tabIndex)
        {
            var Page = KoeffTabControl.TabPages[tabIndex];

            foreach(TextBox koeffField in Page.Controls.OfType<TextBox>())
                koeffField.Clear();
        }

        private void SetKoeffMenuVisible(bool visible)
        {
            KoeffTabControl.Visible = visible;
            TigelKoefRadioButton.Visible = visible;
            VoilokRadioButton.Visible = visible;
            NameTextBox.Visible = visible;
            NameLabel.Visible = visible;
            ClearFieldsBtn.Visible = visible;
        }

        private void ClearFieldsBtn_Click(object sender, EventArgs e)
        {
            if (!ConfirmMessageBox.Show("Вы точно хотите очистить вкалдку? Обратное дейтсвие невозможно"))
                return;

            int index = KoeffTabControl.SelectedIndex;
            ClearTab(index);
        }

        private void PresetTreeList_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (!IsSaved)
            {
                bool confirmed = ConfirmMessageBox.Show("Текущий пресет не сохранён. Вы точно хотите создать новый шаблон?\nВНИМАНИЕ: при создании нового шаблона изменения не будут сохранены");
                if (!confirmed)
                    return;
            }

            string PresetName = PresetTreeList.SelectedNode.Text;

            preset = PresetSystem.GetPresetByName(PresetName);

            if(preset == null)
            {
                ErrorMessage.Show("Пресет был повреждён либо удалён");
                LoadPresets();
                return;
            }
            isProgramInput = true;
            ClearKoeffPresetMenu();
            NameTextBox.Text = preset.Name;
            Text = "Редактирование пресета: " + preset.Name;
            SaveBtn.Visible = true;
            SaveBtn.Text = "Сохранить изменения";
            TigelKoefRadioButton.Checked = true;
            TigelTempKoeff = ConvertToListString(preset.TigelKoeffs);
            VoilokTempKoeff = ConvertToListString(preset.VoilokKoeffs);

            UploadTempValues(TigelTempKoeff);
            isProgramInput = false;

            SuccesMessage.Show("Пресет успешно загружен");
        }

        private List<string[]> ConvertToListString(List<double[]> tigelKoeffs)
        {
            List<string[]> convertedList = new List<string[]>();

            for(int i = 0; i < tigelKoeffs.Count; i++)
            {
                string[] strings = new string[4]; 
                for(int j = 0; j < tigelKoeffs[i].Count(); j++)
                {
                    strings[j] = tigelKoeffs[i][j].ToString();
                }

                convertedList.Add(strings);
            }

            return convertedList;
        }

        private void TigelKoefRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            isProgramInput = true;
            if (!TigelKoefRadioButton.Checked) {
                SaveTempValues(ref TigelTempKoeff);
                UploadTempValues(VoilokTempKoeff);
                isProgramInput = false;
                return;
            }

            SaveTempValues(ref VoilokTempKoeff);
            UploadTempValues(TigelTempKoeff);
            isProgramInput = false;
        }

        private void UploadTempValues(List<string[]> tempListKoeff)
        {
            int pageIndex = 0;
            foreach (TabPage Page in KoeffTabControl.TabPages)
            {
                for (int i = 1; i <= 4; i++)
                {
                    string textboxName = "TextBox" + Page.Text + i.ToString();
                    TextBox koeffField = (TextBox)Page.Controls.Find(textboxName, false)[0];
                    koeffField.Text = tempListKoeff[pageIndex][i - 1];
                }
                pageIndex++;
            }
        }

        private void SaveTempValues(ref List<string[]> tempListKoeff)
        {
            int pageIndex = 0;
            foreach(TabPage Page in KoeffTabControl.TabPages)
            {
                for (int i = 1; i <= 4; i++) 
                {
                    string textboxName = "TextBox" + Page.Text + i.ToString();
                    TextBox koeffField = (TextBox)Page.Controls.Find(textboxName, false)[0];
                    tempListKoeff[pageIndex][i - 1] = koeffField.Text;
                }
                pageIndex++;
            }
        }

        private void FieldTextChangedEvent(object sender, EventArgs e)
        {
            if(!isProgramInput)
                IsSaved = false;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            SavePreset();
        }

        private bool SavePreset()
        {
            if (IsSaved)
                return true;

            if (TigelKoefRadioButton.Checked)
                SaveTempValues(ref TigelTempKoeff);
            else
                SaveTempValues(ref VoilokTempKoeff);

            List<double[]> newTigelKoeffs = ConvertToDouble(TigelTempKoeff);
            List<double[]> newVoilokKoeffs = ConvertToDouble(VoilokTempKoeff);

            if (newTigelKoeffs == null || newVoilokKoeffs == null)
            {
                ErrorMessage.Show("Одно или несколько полей было не заполнено");
                return false;
            }
            string newName = NameTextBox.Text;

            if (string.IsNullOrWhiteSpace(newName))
            {
                ErrorMessage.Show("Введите название пресета");
                return false;
            }

            KoefPreset newPreset = new KoefPreset(newTigelKoeffs, newVoilokKoeffs, newName);

            if (PresetSystem.isPresetAlreadyExisting(newPreset.Name) && preset == null ||
                PresetSystem.isPresetAlreadyExisting(newPreset.Name) && preset?.Name != newPreset.Name)
            {
                ErrorMessage.Show("Пресет с таким названием уже существует. Выберите другое название");
                LoadPresets();
                return false;
            }

            if (preset != null)
                return SaveExistingPreset(newPreset);
            else
                SaveNewPreset(newPreset);

            return true;
        }

        private void SaveNewPreset(KoefPreset newPreset)
        {
            PresetSystem.SavePreset(newPreset);
            SaveBtn.Text = "Сохранить изменения";
            preset = newPreset;
            IsSaved = true;
            SuccesMessage.Show("Новый шаблон успешно создан");
            LoadPresets();
        }

        private bool SaveExistingPreset(KoefPreset modifyingPreset)
        {
            if(preset.Name != modifyingPreset.Name) 
            {
                if (MessageBox.Show("Сохранить как новый шаблон?", "Внимание", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    if (PresetSystem.isPresetAlreadyExisting(modifyingPreset.Name))
                    {
                        ErrorMessage.Show("Пресет с таким названием уже существует. Выберите другое название");
                        return false;
                    }
                    if (Interface_settings.getPresetName() == preset.Name)
                        Interface_settings.savePresetName(modifyingPreset.Name);

                    PresetSystem.SavePreset(modifyingPreset);
                }
                else
                    PresetSystem.SavePreset(modifyingPreset, preset.Name);
            }
            else
                PresetSystem.SavePreset(modifyingPreset, preset.Name);

            //PresetSystem.SavePreset(modifyingPreset, preset.Name);
            preset = modifyingPreset;
            IsSaved = true;
            SuccesMessage.Show("Изменения успешно сохранены");
            LoadPresets();
            return true;
        }

        private List<double[]> ConvertToDouble(List<string[]> tempListString)
        {
            List<double[]> output = new List<double[]>();
            for(int i = 0; i < PresetSystem.TOKMODECOUNT; i++)
            {
                double[] row = new double[4];
                for(int j = 0; j < 4; j++)
                {
                    string value = tempListString[i][j].Replace('.', ',');
                    if (!Double.TryParse(value, out row[j]) || string.IsNullOrWhiteSpace(value))
                        return null;
                }
                output.Add(row);
            }

            return output;
        }

        private void PresetTreeList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            DeletePresetBtn.Visible = true;
        }

        private void DeletePresetBtn_Click(object sender, EventArgs e)
        {
            string ChosenPreset = PresetTreeList.SelectedNode.Text;
            if (!ConfirmMessageBox.Show("Вы точно хотите удалить пресет " + ChosenPreset + "?"))
                return;

            PresetSystem.DeletePreset(ChosenPreset);

            if (Interface_settings.getPresetName() == ChosenPreset)
                Interface_settings.savePresetName("");

            LoadPresets();
            if (preset?.Name != ChosenPreset)
            {
                SuccesMessage.Show("Пресет был успешно удалён");
                return;
            }

            SuccesMessage.Show("Пресет был успешно удалён");
            SetVisibleCore(false);
            Text = "Редактирование пресета коэффициентов";
            preset = null;
            ClearTempLists();
        }

        private void RenamePresetBtn_Click(object sender, EventArgs e)
        {
            string ChosenPreset = PresetTreeList.SelectedNode.Text;
            string newPresetName = "";
            using (InputFormMenu inputForm = new InputFormMenu("Редактирование пресета", "Выберите новое название пресета", ChosenPreset))
            {
                if (inputForm.ShowDialog() != DialogResult.OK)
                {
                    LoadPresets();
                    return;
                }

                newPresetName = inputForm.OutputValue;
            }

            
            if (string.IsNullOrWhiteSpace(newPresetName))
            {
                ErrorMessage.Show("Введено пустое название");
                LoadPresets();
                return;
            }

            if(newPresetName == ChosenPreset)
            {
                LoadPresets();
                return;
            }

            if (PresetSystem.isPresetAlreadyExisting(newPresetName))
            {
                ErrorMessage.Show("Пресет с таким названием уже существует. Выберите другое название");
                LoadPresets();
                return;
            }

            PresetSystem.RenamePreset(ChosenPreset, newPresetName);

            if (Interface_settings.getPresetName() == ChosenPreset)
                Interface_settings.savePresetName(newPresetName);

            LoadPresets();
            SuccesMessage.Show("Пресет успешено переименован");
        }

        private void PresetRedactorMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsSaved)
            {
                e.Cancel = false;
                return;
            }

            if(!ConfirmMessageBox.Show("Текущий пресет не сохранён. Вы хотите его сохранить?"))
            {
                e.Cancel = false;
                return;
            }

            e.Cancel = !SavePreset();
        }
    }
}