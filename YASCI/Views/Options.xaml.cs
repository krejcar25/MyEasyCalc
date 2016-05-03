using YASCI.Objects;
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

namespace YASCI.Views
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
            Worker.PageManager.SetPage("back");
        }
        
        private void showEula_Click(object sender, RoutedEventArgs e)
        {
            Worker.PageManager.SetPage("License");
            View.License.viewer.Navigate(new Uri(string.Format("file:///{0}/views/shows/license.html", Directory.GetCurrentDirectory())));
        }

        private void showAbout_Click(object sender, RoutedEventArgs e)
        {
            Worker.PageManager.SetPage("About");
            View.License.viewer.Navigate(new Uri(string.Format("file:///{0}/views/shows/About.html", Directory.GetCurrentDirectory())));
        }

        private void logginOptionsOpen_Click(object sender, RoutedEventArgs e)
        {
            Worker.PageManager.SetPage("LoggingOptions");
            View.LoggingOptions.Recolor();
        }

        private void pathSelect_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog browser = new System.Windows.Forms.FolderBrowserDialog();
            browser.Description = "Please select folder for the log files to be save to...";
            browser.SelectedPath = loggingPath.Text;
            browser.ShowDialog();
            loggingPath.Text = browser.SelectedPath;
        }
    }
}
