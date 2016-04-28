﻿using System;
using System.Text.RegularExpressions;
using Mono.CSharp;

namespace KalkulackaWPF
{
    public class Calculator
    {
        public string mathString { get; set; }
        public Calculator()
        {
            //math = First.main.indirectPad.Text;
        }
        public void Process()
        {
            mathString = First.main.indirectPad.Text;
            FuncParser();
            Console.WriteLine("Math: {0}", mathString);
            //MSScriptControl.ScriptControl sc = new MSScriptControl.ScriptControl();
            //sc.Language = "VBScript";
            string expression = mathString.Remove(mathString.Length - 1, 1);
            Console.WriteLine("Expression: {0}", expression);
            //object result = sc.Eval(expression);
            Mono.CSharp.Evaluator evaluator = new Evaluator(new CompilerContext(new CompilerSettings(), new ConsoleReportPrinter()));
            object result = evaluator.Evaluate(expression);
            First.main.directPad.Text = result.ToString();
            First.main.isResult = true;
        }
        private void FuncParser()
        {
            mathString = mathString
                .Replace("sin", "System.Math.Sin").Replace("cos", "System.Math.Cos").Replace("tan", "System.Math.Tan")
                .Replace("log", "System.Math.Log").Replace("log10", "System.Math.Log10").Replace("ln", "System.Math.Log")
                .Replace("Ans", First.main.lastResult.ToString());
            mathString = Regex.Replace(mathString, @"\be", "System.Math.E");
            mathString = Regex.Replace(mathString, @"\bE", "*10^");
            //mathString = Regex.Replace(mathString, "log(\s+(.*?)(?:,)\s+(.*?)(?:))", "(log($1)/log($2)");)
        }
        public string StepSolve()
        {
            return "";
        }
        public void CreateFormula(string name)
        {
            mathString = First.main.indirectPad.Text;
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
            First.main.MainWindow1.updateDisplay("write", toAdd);
        }
    }
}
