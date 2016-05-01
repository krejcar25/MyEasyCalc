using System;
using System.Text.RegularExpressions;
using YASCI.Views;
using YASCI.Objects;
using LoreSoft.MathExpressions;

namespace YASCI.Backstage
{
    public class Calculator
    {
        public string mathString { get; set; }
        public bool isResult { get; set; }
        public double lastResult { get; set; }
        public Calculator()
        {
            //math = First.main.indirectPad.Text;
        }
        public void Process()
        {
            mathString = View.Calc.indirectPad.Text;
            bool mathLoop = true;
            while (mathLoop)
            {
                Worker.Logger.log(2, "Math", string.Format("Current math value before replacement: {0}", mathString));
                FuncParser();
                Worker.Logger.log(2, "Math", string.Format("Current math value after replacement: {0}", mathString));
                //Evaluator evaluator = new Evaluator(new CompilerContext(new CompilerSettings(), new ConsoleReportPrinter()));
                MathEvaluator eval = new MathEvaluator();

                object result;
                string success = "yes";
                try
                {
                    result = eval.Evaluate(mathString);
                }
                catch (ParseException e)
                {
                    result = "Error";
                    if (e.Message == "Unbalanced parentheses." && mathString.ToCharArray()[mathString.ToCharArray().Length-1]!=')')
                    {
                        Worker.Logger.log(1, "Evaluate", string.Format("There was an error in the formula provided: {0}", e.Message));
                        Worker.Logger.log(2, "Evaluate", "Trying to add ) to string to fix error");
                        mathString += ")";
                        success = "no";
                    }
                    else
                    {
                        Worker.Logger.log(0, "Evaluate", string.Format("There was an error in the formula provided: {0} Adding", e.Message));
                        Worker.Logger.log(2, "Evaluate", "Automatic string editing didn't help, user made mistake");
                        success = "error";
                    }
                }
                catch (Exception e)
                {
                    success = "error";
                    result = "Error";
                    Worker.Logger.log(0, "Evaluate", string.Format("There was an error in the formula provided: {0}", e.Message));
                    success = "error";
                }

                if (success == "yes")
                {
                    View.Calc.directPad.Text = result.ToString();
                    lastResult = double.Parse(result.ToString());
                    mathLoop = false;
                }
                else if (success == "error")
                {
                    View.Calc.directPad.Text = "Error";
                    lastResult = 0;
                    mathLoop = false;
                }
                else
                {
                    lastResult = 0;
                }
            }
            isResult = true;
        }
        private void FuncParser()
        {
            // invert , and .
            Worker.Logger.log(2, "Math", "Current math value before comma and period inversion: {0}", mathString);
            mathString = Regex.Replace(mathString, @"\,", "_comma_");
            mathString = Regex.Replace(mathString, @"\.", ",");
            mathString = Regex.Replace(mathString, @"_comma_", ".");
            Worker.Logger.log(2, "Math", "Current math value after comma and period inversion: {0}", mathString);

            // replace functions
            mathString = Regex.Replace(mathString, @"log\((.+?). (.+?)[)]?", "(log($1)/log($2))");
            mathString = Regex.Replace(mathString, @"log\((.+?)[)]?", "log10($1)");
            mathString = Regex.Replace(mathString, @"ln\((.+?)[)]?", "log($1)");/*
            //mathString = Regex.Replace(mathString, @"([sin, cos, tan]?\(.+?)[)]?", "$1)");
            mathString = Regex.Replace(mathString, @"sin\((.+?)[)]?", "sin($1)");
            mathString = Regex.Replace(mathString, @"cos\((.+?)[)]?", "cos($1)");
            mathString = Regex.Replace(mathString, @"tan\((.+?)[)]?", "tan($1)");*/
            mathString = Regex.Replace(mathString, @"\bE", "*10^");
            mathString = Regex.Replace(mathString, @"Ans", "answer");
            mathString = Regex.Replace(mathString, @"crt\((.+?)[)]?", "$1^(1/3)");
            

            if (mathString.ToCharArray()[mathString.Length -1 ] == '=')
            {
                Worker.Logger.log(2, "Math", "Yup, there was an equal sign at the end, I shall remove it!");
                mathString.Remove(mathString.Length - 1);
            }
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
                    toAdd = "sqrt(";
                    break;
                case "root3":
                    toAdd = "crt(";
                    break;
                case "rootx":
                    toAdd = "xrt(";
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
                    toAdd = "e^";
                    break;
                default:
                    toAdd = "";
                    break;
            }
            View.Calc.updateDisplay("write", toAdd);
        }
    }
}
