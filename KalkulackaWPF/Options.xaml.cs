using System;
using System.Collections.Generic;
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
using KalkulackaWPF.Properties;

namespace KalkulackaWPF
{
    /// <summary>
    /// Interaction logic for Options.xaml
    /// </summary>
    public partial class Options : UserControl
    {
        public Options()
        {
            InitializeComponent();
            Recolor();
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

        private void showEula_Click(object sender, RoutedEventArgs e)
        {

        }

        private void showAbout_Click(object sender, RoutedEventArgs e)
        {
            var info = new ProgHelp();
            info.Show();
        }
    }
}
