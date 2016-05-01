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

namespace YASCI.Views
{
    /// <summary>
    /// Interaction logic for Func2.xaml
    /// </summary>
    public partial class Func2 : Page
    {
        public Func2()
        {
            InitializeComponent();
        }
        
        private void bracketClose_Click(object sender, RoutedEventArgs e)
        {
            View.Calc.updateDisplay("write", ")");
            View.Calc.SetFuncPanel(1);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            View.Calc.SetFuncPanel(1);
        }
    }
}
