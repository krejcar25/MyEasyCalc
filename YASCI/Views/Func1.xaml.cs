using YASCI.Objects;
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
    /// Interaction logic for Func1.xaml
    /// </summary>
    public partial class Func1 : Page
    {
        public Func1()
        {
            InitializeComponent();
        }

        private void bracketOpen_Click(object sender, RoutedEventArgs e)
        {
            View.Calc.updateDisplay("write", "(");
        }
        private void power2_Click(object sender, RoutedEventArgs e)
        {
            Worker.processor.CreateFormula("pow2");
        }
        private void power3_Click(object sender, RoutedEventArgs e)
        {
            Worker.processor.CreateFormula("pow3");
        }
        private void powerN_Click(object sender, RoutedEventArgs e)
        {
            Worker.processor.CreateFormula("powx");
        }
        private void root2_Click(object sender, RoutedEventArgs e)
        {
            Worker.processor.CreateFormula("root2");
        }
        private void root3_Click(object sender, RoutedEventArgs e)
        {
            Worker.processor.CreateFormula("root3");
        }
        private void rootN_Click(object sender, RoutedEventArgs e)
        {
            Worker.processor.CreateFormula("rootx");
        }
        private void sin_Click(object sender, RoutedEventArgs e)
        {
            Worker.processor.CreateFormula("sin");
        }
        private void cos_Click(object sender, RoutedEventArgs e)
        {
            Worker.processor.CreateFormula("cos");
        }
        private void tan_Click(object sender, RoutedEventArgs e)
        {
            Worker.processor.CreateFormula("tan");
        }
        private void log_Click(object sender, RoutedEventArgs e)
        {
            Worker.processor.CreateFormula("log10");
        }
        private void logn_Click(object sender, RoutedEventArgs e)
        {
            Worker.processor.CreateFormula("log");
        }
        private void ln_Click(object sender, RoutedEventArgs e)
        {
            Worker.processor.CreateFormula("ln");
        }
        private void powerE_Click(object sender, RoutedEventArgs e)
        {
            Worker.processor.CreateFormula("eP");
        }

        private void shift_Click(object sender, RoutedEventArgs e)
        {
            View.Calc.SetFuncPanel(2);
        }
    }
}
