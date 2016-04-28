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
        public bool isResult { get; set; }
        public int lastResult { get; set; }
        public static BackgroundTasks tasks = new BackgroundTasks();
        public static Calculator processor = new Calculator();
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            directPad.Text = "";
        }
    }
}
