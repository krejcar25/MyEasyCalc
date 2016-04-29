using System;
using System.Runtime.InteropServices;
using System.Security;
using KalkulackaWPF.Views;
using KalkulackaWPF.Objects;
using System.Configuration;

namespace KalkulackaWPF
{
    class First
    {
        public First()
        {
            Logger init = new Logger(true);
            View.Calc.isResult = false;
            View.Calc.lastResult = 0;
            if (!init.consoleLogged)
            {
                new Logger(false);
            }
            new Logger(2, "Logging", "Logging code initialized and working");
            new Logger(2, "System", "System started, app window should open wihin 3 seconds");
            Vars.InitViewsList();
            Worker.main.Viewer.Content = View.Calc;
            Worker.main.Show();
        }
    }
}
