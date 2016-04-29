using KalkulackaWPF.Backstage;
using KalkulackaWPF.Objects;
using KalkulackaWPF.Views;
using System.Windows;

namespace KalkulackaWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        // public static bool isResult = false;
        // public static int lastResult = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            View.Calc.directPad.Text = "";
        }
        public void SetPage(string id)
        {
            new Logger(2, "Display", string.Format("Setting page to {0}", id));
            Viewer.Content = Vars.viewsList[id];
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (this.Viewer.Content == View.Calc)
            {
                Worker.Typer.typer(sender, e);
            }
        }
    }
}
