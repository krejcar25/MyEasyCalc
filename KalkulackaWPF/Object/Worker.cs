using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KalkulackaWPF.Backstage;

namespace KalkulackaWPF.Objects
{
    class Worker
    {
        public static MainWindow main = new MainWindow();
        public static Calculator processor = new Calculator();
        public static BackgroundTasks tasks = new BackgroundTasks();
        public static Typer Typer = new Typer();
    }
}
