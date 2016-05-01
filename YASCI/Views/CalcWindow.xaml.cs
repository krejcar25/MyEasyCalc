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
using YASCI.Backstage;

namespace YASCI.Views
{
    /// <summary>
    /// Interaction logic for CalcWindow.xaml
    /// </summary>
    public partial class CalcWindow : Page
    {
        public CalcWindow()
        {
            InitializeComponent();
            SetFuncPanel(1);
        }

        public bool isResult { get; set; }
        public int lastResult { get; set; }
        private BackgroundTasks tasks = new BackgroundTasks();
        public void updateDisplay(string task)
        {
            Worker.Logger.log(3, "Code", string.Format("An updateDisplay call has appeared with task {0}", task));
            if (task == "clear")
            {
                directPad.Text = "";
                indirectPad.Text = "";
                Worker.Logger.log(2, "Display", "Text pads were cleared");
                Worker.processor.isResult = false;
                Worker.processor.lastResult = 0;
                Worker.Logger.log(2, "Vars", "Ans values were resetted");
            }
            else if (task == "del")
            {
                if (0 < directPad.Text.Length)
                {
                    directPad.Text = directPad.Text.Remove(directPad.Text.Length - 1, 1);
                    Worker.Logger.log(2, "Display", "Erasing last caracter from directPad");
                }
                else
                {
                    Worker.Logger.log(2, "Display", "Attempted to erase from directPad but source string is empty, aboarting");
                }
            }
            tasks.CheckBlocksInitiate(directPad.Text, indirectPad.Text);
        }
        public void updateDisplay(string task, string val)
        {
            if (task == "write")
            {
                if (val == ".")
                {
                    if (!tasks.dec && directPad.Text != "" && !Worker.processor.isResult)
                    {
                        directPad.Text += ".";
                    }
                }
                else
                {
                    if (Worker.processor.isResult)
                    {
                        directPad.Text = val;
                        indirectPad.Text = "";
                        Worker.processor.isResult = false;
                    }
                    else
                    {
                        directPad.Text += val;
                    }
                }
            }
            else if (task == "moveUp")
            {
                string oper;
                
                switch (val)
                {
                    default:
                        oper = "";
                        break;
                    case "plus":
                        oper = "+";
                        break;
                    case "minus":
                        oper = "-";
                        break;
                    case "times":
                        oper = "*";
                        break;
                    case "divide":
                        oper = "/";
                        break;
                    case "equal":
                        oper = "=";
                        break;
                }

                if (Worker.processor.isResult) {
                    indirectPad.Text = "";
                    Worker.processor.isResult = false;
                }

                indirectPad.Text += directPad.Text + oper;
                directPad.Text = Worker.processor.StepSolve();
            }
            tasks.CheckBlocksInitiate(directPad.Text, indirectPad.Text);
        }

        public void SetFuncPanel(int id)
        {
            switch (id)
            {
                default:
                    break;
                case 1:
                    this.funcPart.Content = View.Func.Func1;
                    break;
                case 2:
                    this.funcPart.Content = View.Func.Func2;
                    break;
            }
        }

        // numbers
        private void number1_Click(object sender, RoutedEventArgs e)
        {
            updateDisplay("write", "1");
        }
        private void number2_Click(object sender, RoutedEventArgs e)
        {
            updateDisplay("write", "2");
        }
        private void number3_Click(object sender, RoutedEventArgs e)
        {
            updateDisplay("write", "3");
        }
        private void number4_Click(object sender, RoutedEventArgs e)
        {
            updateDisplay("write", "4");
        }
        private void number5_Click(object sender, RoutedEventArgs e)
        {
            updateDisplay("write", "5");
        }
        private void number6_Click(object sender, RoutedEventArgs e)
        {
            updateDisplay("write", "6");
        }
        private void number7_Click(object sender, RoutedEventArgs e)
        {
            updateDisplay("write", "7");
        }
        private void number8_Click(object sender, RoutedEventArgs e)
        {
            updateDisplay("write", "8");
        }
        private void number9_Click(object sender, RoutedEventArgs e)
        {
            updateDisplay("write", "9");
        }
        private void number0_Click(object sender, RoutedEventArgs e)
        {
            updateDisplay("write", "0");
        }
        // clear
        private void del_Click(object sender, RoutedEventArgs e)
        {
            updateDisplay("del");
        }
        private void ac_Click(object sender, RoutedEventArgs e)
        {
            updateDisplay("clear");
        }
        // operators
        private void plus_Click(object sender, RoutedEventArgs e)
        {
            updateDisplay("moveUp", "plus");
        }
        private void minus_Click(object sender, RoutedEventArgs e)
        {
            updateDisplay("moveUp", "minus");
        }
        private void times_Click(object sender, RoutedEventArgs e)
        {
            updateDisplay("moveUp", "times");
        }
        private void divide_Click(object sender, RoutedEventArgs e)
        {
            updateDisplay("moveUp", "divide");
        }
        // parts
        private void exponential_Click(object sender, RoutedEventArgs e)
        {
            updateDisplay("write", "Ex");
        }
        private void ans_Click(object sender, RoutedEventArgs e)
        {
            updateDisplay("write", "Ans");
        }
        private void decButton_Click(object sender, RoutedEventArgs e)
        {
            updateDisplay("write", ".");
        }
        private void optionsOpen_Click(object sender, RoutedEventArgs e)
        {
            Worker.main.SetPage("Options");
        }
        private void equal_Click(object sender, RoutedEventArgs e)
        {
            updateDisplay("moveUp", "equal");
            Worker.processor.Process();
        }
    }
}
