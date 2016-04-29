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

            Viewer.Content = Vars.viewsList[id];
        }
    }
}
