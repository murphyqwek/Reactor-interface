using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2.Responses;
using Reactor_Interface;
using Reactor_Interface.Classes;
using Reactor_Interface.Classes.ExcelTests;
using Reactor_Interface.Classes.GoogleAPI;
using Reactor_Interface.Forms.Experiment;
using WindowsFormsApp1.Classes;

namespace WindowsFormsApp1
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Google_data.Upload_data();
            //InteropExcel.Test("D:\\XRD Parsed\\Test1.xls");
            //EPPlusTestExcel.CreateExcelExperiment("D:\\XRD Parsed\\Test1.xls");
            Drive.Upload(Google_data.Get_current_drive());
            //Application.Run(new Jounral_menu());
            Application.Run(new Main_menu());
        }
    }
}
