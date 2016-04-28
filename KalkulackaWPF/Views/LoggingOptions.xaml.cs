using KalkulackaWPF.Properties;
using System;
using System.Collections.Generic;
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

namespace KalkulackaWPF
{
    /// <summary>
    /// Interaction logic for LoggingOptions.xaml
    /// </summary>
    public partial class LoggingOptions : Page
    {
        public LoggingOptions()
        {
            InitializeComponent();
        }

        private bool loggingToggled { get; set; }
        private bool changed { get; set; }

        private void Recolor()
        {
            if (!Settings.Default.logging)
            {
                toggleLogging.Background = Brushes.Crimson;
                toggleLogging.Content = "Turn on\r\n(currently off)";
            }
            else if (Settings.Default.logging)
            {
                toggleLogging.Background = Brushes.Olive;
                toggleLogging.Content = "Turn off\r\n(currently on)";
            }

            loggingPath.Text = Settings.Default.loggingFile;

            if (!Settings.Default.consoleOpen)
            {
                toggleConsole.Background = Brushes.Crimson;
                toggleConsole.Content = "Turn on\r\n(currently off)";
            }
            else if (Settings.Default.logging)
            {
                toggleConsole.Background = Brushes.Olive;
                toggleConsole.Content = "Turn off\r\n(currently on)";
            }
        }

        private void toggleLogging_Click(object sender, RoutedEventArgs e)
        {
            if (Settings.Default.logging)
            {
                Settings.Default.logging = false;
                loggingToggled = true;
            }
            else
            {
                Settings.Default.logging = true;
                loggingToggled = true;
            }

            Recolor();
        }
        private void loggingBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Settings.Default.loggingFile = loggingPath.Text;
            loggingToggled = true;
        }

        private void visitLogs_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("explorer.exe", Settings.Default.loggingFile);
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
            if (Settings.Default.logging)
            {
                Settings.Default.logging = false;
                loggingToggled = true;
            }
            else
            {
                Settings.Default.logging = true;
                loggingToggled = true;
            }

            Recolor();
        }

        private void showEula_Click(object sender, RoutedEventArgs e)
        {

        }

        private void showAbout_Click(object sender, RoutedEventArgs e)
        {
            ProgHelp help = new ProgHelp();
            help.ShowDialog();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            First.main.SetPage(1);
        }
    }
}
