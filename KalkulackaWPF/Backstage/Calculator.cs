using System;
using System.Text.RegularExpressions;
using Mono.CSharp;
using KalkulackaWPF.Views;

namespace KalkulackaWPF
{
    public class Calculator
    {
        public string mathString { get; set; }
        public bool isResult { get; set; }
        public int lastResult { get; set; }
        public Calculator()
        {
            //math = First.main.indirectPad.Text;
        }
        public void Process()
        {
            mathString = View.Calc.indirectPad.Text;
            new Logger(2, "Math", string.Format("Current math value before replacement: {0}", mathString));
            FuncParser();
            new Logger(2, "Math", string.Format("Current math value after replacement: {0}", mathString));
            Evaluator evaluator = new Evaluator(new CompilerContext(new CompilerSettings(), new ConsoleReportPrinter()));
            object result = evaluator.Evaluate(mathString);
            View.Calc.directPad.Text = result.ToString();
            isResult = true;
        }
        private void FuncParser()
        {
            mathString = mathString
                .Replace("sin", "System.Math.Sin").Replace("cos", "System.Math.Cos").Replace("tan", "System.Math.Tan")
                .Replace("log", "System.Math.Log").Replace("log10", "System.Math.Log10").Replace("ln", "System.Math.Log")
                .Replace("Ans", lastResult.ToString());
            mathString = Regex.Replace(mathString, @"\be", "System.Math.E");
            mathString = Regex.Replace(mathString, @"\bE", "*10^");
            mathString = mathString.Replace("=", "");
        }
        public string StepSolve()
        {
            return "";
        }
        public void CreateFormula(string name)
        {
            mathString = View.Calc.indirectPad.Text;
            string toAdd;
            switch (name)
            {
                case "pow2":
                    toAdd = "^2";
                    break;
                case "pow3":
                    toAdd = "^3";
                    break;
                case "powx":
                    toAdd = "^";
                    break;
                case "root2":
                    toAdd = "^(1/2)";
                    break;
                case "root3":
                    toAdd = "^(1/3)";
                    break;
                case "rootx":
                    toAdd = "^(1/";
                    break;
                case "sin":
                    toAdd = "sin(";
                    break;
                case "cos":
                    toAdd = "cos(";
                    break;
                case "tan":
                    toAdd = "tan(";
                    break;
                case "log":
                    toAdd = "log(";
                    break;
                case "log10":
                    toAdd = "log10(";
                    break;
                case "ln":
                    toAdd = "ln(";
                    break;
                case "eP":
                    toAdd = "e";
                    break;
                default:
                    toAdd = "";
                    break;
            }
            View.Calc.updateDisplay("write", toAdd);
        }
    }
}
