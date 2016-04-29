using KalkulackaWPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalkulackaWPF.Objects
{
    class Vars
    {
        public static string LogPath = config.Default.loggingPath + config.Default.loggingFile.Replace("{date}", DateTime.Now.ToShortDateString()).Replace("{time}", DateTime.Now.ToLongTimeString().Replace(":", "."));
        //public static object[] viewsList = new object[] { View.Calc, View.Options, View.LoggingOptions, View.FileNameHelp, View.License, View.About };
        public static Dictionary<string, object> viewsList = new Dictionary<string, object>();
        public static bool consoleOpen = false;
        public static string[] numbersList = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        public static void InitViewsList()
        {
            viewsList["Calc"] = View.Calc;
            viewsList["Options"] = View.Options;
            viewsList["LoggingOptions"] = View.LoggingOptions;
            viewsList["FileNameHelp"] = View.FileNameHelp;
            viewsList["License"] = View.License;
            viewsList["About"] = View.About;
            viewsList["Controls"] = View.Controls;
        }
    }
}
