using Microsoft.Office.Interop.Excel;
using Reactor_Interface.Classes.GoogleAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using WindowsFormsApp1.Classes;

namespace Reactor_Interface.Classes
{
    public class RecentFiles
    {
        public const int MAXRECNETFILESCOUNT = 4;

        public static void DeleteRecentFile(string path, bool isExperiment)
        {
            string[] recentFiles = getRecentFiles(isExperiment);

            string[] existingRecentFiles = { "", "", "", "" };
            int j = 0;

            for(int i = 0; i < MAXRECNETFILESCOUNT; i++)
            {
                if (recentFiles[i] == path)
                    continue;

                existingRecentFiles[j] = recentFiles[i];
                j++;
            }

            SaveRecentFiles(existingRecentFiles, isExperiment);
        }

        public static string[] getRecentFiles(bool isExperiment)
        {
            if (isExperiment)
                return Interface_settings.getRecentExperiments();
            else
                return Interface_settings.getRecentSeries();
        }

        public static int GetIndexOfRecentFile(string[] RecentFiles, string RecentFile)
        {
            for (int i = 0; i < MAXRECNETFILESCOUNT; i++)
            {
                if (RecentFiles[i] == RecentFile)
                {
                    return i;
                }
            }

            return MAXRECNETFILESCOUNT;
        }

        public static void SaveRecentFiles(string[] recentFiles, bool isExperiment)
        {
            if (isExperiment)
                Interface_settings.saveRecentExperiments(recentFiles);
            else
                Interface_settings.saveRecentSeries(recentFiles);
        }

        public static void UpdateRecentFiles(ref ToolStripMenuItem openRecentBtn, ref ToolStripSeparator separator, string FilePath, bool isExperiment)
        {
            string[] recentFiles = getRecentFiles(isExperiment);

            int index = GetIndexOfRecentFile(recentFiles, FilePath);
            if (index != 0)
            {
                ShiftRecentFile(index, ref recentFiles);
                recentFiles[0] = FilePath;
            }

            SaveRecentFiles(recentFiles, isExperiment);

            SetRecentFiles(ref openRecentBtn, ref separator);
        }

        private static void ShiftRecentFile(int index, ref string[] RecentFilesArray)
        {
            if (index == MAXRECNETFILESCOUNT)
            {
                RecentFilesArray[MAXRECNETFILESCOUNT - 1] = "";
                index = MAXRECNETFILESCOUNT - 1;
            }
            for(; index > 0; index--)
                RecentFilesArray[index] = RecentFilesArray[index - 1];
        }

        public static void SetRecentFiles(ref ToolStripMenuItem openRecentBtn, ref ToolStripSeparator separator)
        {
            openRecentBtn.DropDownItems.Clear();
            openRecentBtn.Visible = false;

            var recentExperiments = Interface_settings.getRecentExperiments();
            var recentSeries = Interface_settings.getRecentSeries();

            bool isExperimentNull = isArrayNull(recentExperiments);
            bool isSeriesNull = isArrayNull(recentSeries);

            if(isExperimentNull && isSeriesNull)
                return;

            if(!isExperimentNull)
            {
                openRecentBtn.DropDownItems.Add("Эксперименты:");
                setRecentFiles(ref openRecentBtn, ref recentExperiments);
                if (recentSeries.Length != 0)
                    separator.Visible = true;
                Interface_settings.saveRecentExperiments(recentExperiments);
            }

            if(!isSeriesNull)
            {
                openRecentBtn.DropDownItems.Add("Серии");
                setRecentFiles(ref openRecentBtn, ref recentSeries);
                Interface_settings.saveRecentSeries(recentSeries);
            }

            openRecentBtn.Visible = true;
        }

        private static bool isArrayNull(string[] recentSeries)
        {
            foreach(string s in recentSeries)
            {
                if (s != null && s != "")
                {
                    return false;
                }
            }

            return true;
        }

        public static void setRecentFiles(ref ToolStripMenuItem openRecentBtn, ref string[] RecentFiles)
        {
            int nomer = 1;
            string[] existingRecentFiles = { "", "", "", "" };

            for (int i = 0; i < RecentFiles.Length; i++)
            {
                if (!File.Exists(RecentFiles[i]))
                    continue;

                var item = openRecentBtn.DropDownItems.Add(nomer.ToString() + ". \"" + RecentFiles[i] + "\"");
                item.Tag = RecentFiles[i];
                existingRecentFiles[nomer - 1] = RecentFiles[i];
                nomer++;
            }

            RecentFiles = existingRecentFiles;
        }

        public static void SaveRecent(ToolStripMenuItem openRecentBtn)
        {
            string[] RecentFiles = { 
                "",
                "",
                "",
                "",
            };
            int i = 0;
            foreach(ToolStripDropDownItem item in openRecentBtn.DropDownItems)
            {
                RecentFiles[i] = item.Tag.ToString();
            }

            Interface_settings.saveRecentExperiments(RecentFiles);
        }

    }
}