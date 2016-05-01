using YASCI.Objects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace YASCI.Views
{
    /// <summary>
    /// Interaction logic for LoggingOptions.xaml
    /// </summary>
    public partial class LoggingOptions : Page
    {
        public LoggingOptions()
        {
            InitializeComponent();
            Recolor();
        }

        private bool loggingToggled { get; set; }
        private bool changed { get; set; }

        public void Recolor()
        {
            if (!config.Default.logging)
            {
                toggleLogging.Background = Brushes.Crimson;
                toggleLogging.Content = "Turn on\r\n(currently off)";
            }
            else if (config.Default.logging)
            {
                toggleLogging.Background = Brushes.Olive;
                toggleLogging.Content = "Turn off\r\n(currently on)";
            }

            loggingPath.Text = config.Default.loggingPath;
            loggingFile.Text = config.Default.loggingFile;

            if (!config.Default.console)
            {
                toggleConsole.Background = Brushes.Crimson;
                toggleConsole.Content = "Turn on\r\n(currently off)";
            }
            else if (config.Default.console)
            {
                toggleConsole.Background = Brushes.Olive;
                toggleConsole.Content = "Turn off\r\n(currently on)";
            }
        }

        private void toggleLogging_Click(object sender, RoutedEventArgs e)
        {
            if (config.Default.logging)
            {
                config.Default.logging = false;
                config.Default.Save();
            }
            else
            {
                config.Default.logging = true;
                config.Default.Save();
            }

            Recolor();
        }

        private void visitLogs_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("explorer.exe", config.Default.loggingPath);
        }

        private void pathSelect_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog browser = new System.Windows.Forms.FolderBrowserDialog();
            browser.Description = "Please select folder for the log files to be save to...";
            browser.SelectedPath = loggingPath.Text;
            browser.ShowDialog();
            loggingPath.Text = browser.SelectedPath;
        }

        private void toggleConsole_Click(object sender, RoutedEventArgs e)
        {
            if (config.Default.console)
            {
                config.Default.console = false;
                config.Default.Save();
            }
            else
            {
                config.Default.console = true;
                config.Default.Save();
            }

            Recolor();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Worker.main.SetPage("Options");
            config.Default.loggingPath = this.loggingPath.Text;
            config.Default.loggingFile = this.loggingFile.Text;
            config.Default.Save();
        }

        private void fileNameInfo_Click(object sender, RoutedEventArgs e)
        {
            Worker.main.SetPage("FileNameInfo");
        }
    }
}
