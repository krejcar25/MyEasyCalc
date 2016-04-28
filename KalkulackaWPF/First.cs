using System;
using System.Runtime.InteropServices;
using System.Security;
using KalkulackaWPF.Properties;

namespace KalkulackaWPF
{
    class First
    {
        public static MainWindow main = new MainWindow();
        public static Calculator processor = new Calculator();
        public static string logPath = Settings.Default.loggingFile.Replace("{date}", DateTime.Now.ToShortDateString()).Replace("{time}", DateTime.Now.ToLongTimeString().Replace(":", "."));
        public static CalcWindow Calc = new CalcWindow();
        public static Options Options = new Options();
        public static LoggingOptions LoggingOptions = new LoggingOptions();
        public static BackgroundTasks tasks = new BackgroundTasks();
        public First()
        {
            new Logger(true);
            Calc.isResult = false;
            Calc.lastResult = 0;
            new Logger(false);
            main.Viewer.Content = new CalcWindow();
            main.Show();
        }
    }
}
