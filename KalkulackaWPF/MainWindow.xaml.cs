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
            First.Calc.directPad.Text = "";
        }
        public void SetPage(int id)
        {
            object[] list = new object[] { First.Calc, First.Options, First.LoggingOptions };
            Viewer.Content = list[id];
        }
    }
}
