using KalkulackaWPF.Objects;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace KalkulackaWPF.Views
{
    /// <summary>
    /// Interaction logic for Options.xaml
    /// </summary>
    public partial class Options : Page
    {
        public Options()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Worker.main.SetPage("Calc");
        }
        
        private void showEula_Click(object sender, RoutedEventArgs e)
        {
            Worker.main.SetPage("License");
            View.License.viewer.Navigate(new Uri(string.Format("file:///{0}/views/shows/license.html", Directory.GetCurrentDirectory())));
        }

        private void showAbout_Click(object sender, RoutedEventArgs e)
        {
            Worker.main.SetPage("About");
        }

        private void logginOptionsOpen_Click(object sender, RoutedEventArgs e)
        {
            Worker.main.SetPage("LoggingOptions");
        }
    }
}
