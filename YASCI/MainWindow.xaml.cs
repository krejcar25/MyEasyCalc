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
            //SetPage("Calc");
        }

        public void Clear()
        {
            View.Calc.directPad.Text = "";
        }
        public void SetPage(string id)
        {
            Worker.Logger.log(2, "Display", string.Format("Setting page to {0}", id));
            Viewer.Content = Vars.viewsList[id];
            Title = "YASCI MyEasyCalc - " + Vars.titleList[id].ToString();
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
