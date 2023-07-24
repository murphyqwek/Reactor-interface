using Reactor_Interface.Classes.Experiment;
using Reactor_Interface.Classes.Message;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace Reactor_Interface.Classes.Presets
{
    public class PresetSystem
    {
        private static readonly string PRESETSPATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Reactor TPU Koef Presets";
        private static readonly string PRESETEXTENSION = ".preset";
        public static readonly int TOKMODECOUNT = 6;

        private static void CreateFolder()
        {
            if(!Directory.Exists(PRESETSPATH))
                Directory.CreateDirectory(PRESETSPATH);
        }

        public static void OpenPresetsFolder()
        {
            CreateFolder();

            Process.Start("explorer", PRESETSPATH);
        }

        public static void ChangeKoeffsArrays(KoefPreset preset, List<double[]> koeffs, KoefPreset.Type type)
        {
            preset.ChangeKoeffsList(koeffs, type);
        }

        public static KoefPreset GetPresetByName(string name)
        {
            string path = Path.Combine(PRESETSPATH, name + PRESETEXTENSION);

            return GetPresetFromFile(path);
        }

        public static KoefPreset GetPresetFromFile(string presetPath)
        {
            int i = 0;
            List<double[]> TigelParams = new List<double[]>();
            List<double[]> VoilokParams = new List<double[]>();
            double[] koeff = new double[4];
            string name = Path.GetFileNameWithoutExtension(presetPath);
            foreach(string line in File.ReadLines(presetPath))
            {
                if (i == TOKMODECOUNT * 8)
                    break;

                if (!Double.TryParse(line, out koeff[i % 4]))
                    return null;

                i++;

                if (i % 4 == 0)
                {
                    if(i <= TOKMODECOUNT * 4)
                        TigelParams.Add(koeff);
                    else
                        VoilokParams.Add(koeff);
                    koeff = new double[4];
                }
            }
            if (TigelParams.Count != TOKMODECOUNT || VoilokParams.Count != TOKMODECOUNT)
                return null;

            return new KoefPreset(TigelParams, VoilokParams, name);
        }

        public static List<KoefPreset> GetKoefPresets()
        {
            if (!Directory.Exists(PRESETSPATH))
            {
                Directory.CreateDirectory(PRESETSPATH);
                return new List<KoefPreset>();
            }

            List<KoefPreset> presets = new List<KoefPreset>();
            foreach(string presetPath in Directory.GetFiles(PRESETSPATH, "*" + PRESETEXTENSION))
            {
                var preset = GetPresetFromFile(presetPath);
                if(preset != null)
                    presets.Add(preset);
            }

            return presets;
        }

        public static void SavePreset(KoefPreset preset)
        {
            CreateFolder();

            string path = getPresetFilePath(preset.Name);

            if (File.Exists(path))
            {
                ErrorMessage.Show("Пресет с таким именем уже существует. Выберите другое имя");
                return;
            }

            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach(var workMode in preset.TigelKoeffs)
                {
                    foreach(var koef in workMode)
                    {
                        writer.WriteLine(koef);
                    }
                }

                foreach (var workMode in preset.VoilokKoeffs)
                {
                    foreach (var koef in workMode)
                    {
                        writer.WriteLine(koef);
                    }
                }
            }
        }

        public static void DeletePreset(string presetName)
        {
            CreateFolder();
            string path = getPresetFilePath(presetName);
            if (File.Exists(path))
                File.Delete(path);
        }

        public static bool isPresetAlreadyExisting(string presetName) => File.Exists(getPresetFilePath(presetName));

        public static void SavePreset(KoefPreset preset, string oldName)
        {
            CreateFolder();

            DeletePreset(oldName);

            SavePreset(preset);
        }

        private static string getPresetFilePath(string name)
        {
            return Path.Combine(PRESETSPATH, name + PRESETEXTENSION);
        }

        public static bool RenamePreset(string oldName, string newName)
        {
            CreateFolder();

            string oldFilePath = getPresetFilePath(oldName);
            string newFilePath = getPresetFilePath(newName);

            if (!File.Exists(oldFilePath))
                return false;
            
            File.Move(oldFilePath, newFilePath);

            return true;
        }

        public static bool ImportPreset()
        {
           using(OpenFileDialog dialog = new OpenFileDialog())
           {
                dialog.Filter = string.Format("Файлы пресетов коэффициентов (*{0})|*{0}", PRESETEXTENSION);
                dialog.Title = "Выберите пресет коэффициентов";
                dialog.Multiselect = false;

                var result = dialog.ShowDialog();

                if (result != DialogResult.OK)
                    return false;

                string file = dialog.FileName;
                string fileName = Path.GetFileNameWithoutExtension(file);

                string PresetFilePath = getPresetFilePath(fileName);

                KoefPreset preset = GetPresetFromFile(file);

                if(preset == null)
                {
                    ErrorMessage.Show("Выбранный пресет повреждён. Невозможно импортировать");
                    return false;
                }

                if (File.Exists(PresetFilePath))
                {
                    bool confirmed = ConfirmMessageBox.Show("Пресет с таким названием уже существует. Хотите его заменить?");
                    if (!confirmed)
                        return false;

                    File.Delete(PresetFilePath);
                }

                File.Copy(file, PresetFilePath);

                SuccesMessage.Show("Пресет успешно загружен");

                return true;
           } 
        }

        public static double[] GetKoeffsFromPresets(KoefPreset preset, int workMode, KoefPreset.Type type)
        {
            if (type == KoefPreset.Type.Tigel)
                return preset.TigelKoeffs[workMode];
            else
                return preset.VoilokKoeffs[workMode];
        }
    }
}