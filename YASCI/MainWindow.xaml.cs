using YASCI.Backstage;
using YASCI.Objects;
using YASCI.Views;
using System.Windows;

namespace YASCI
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
            //SetPage("Calc");
        }

        public void Clear()
        {
            View.Calc.directPad.Text = "";
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
