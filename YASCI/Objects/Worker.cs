using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YASCI.Backstage;
using LoreSoft.MathExpressions;

namespace YASCI.Objects
{
    class Worker
    {
        public static MainWindow main = new MainWindow();
        public static Calculator processor = new Calculator();
        public static BackgroundTasks tasks = new BackgroundTasks();
        public static Typer Typer = new Typer();
        public static Logger Logger = new Logger();
        public static MathEvaluator MathEvaluator = new MathEvaluator();
        public static PageManager PageManager = new PageManager();
    }
}
