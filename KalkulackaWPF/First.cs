using System;
using System.Runtime.InteropServices;
using System.Security;
using KalkulackaWPF.Views;
using KalkulackaWPF.Objects;
using System.Configuration;
using KalkulackaWPF.Backstage;

namespace KalkulackaWPF
{
    class First
    {
        public First()
        {
            Worker.Logger.log(true);
            View.Calc.isResult = false;
            View.Calc.lastResult = 0;
            if (!Vars.consoleOpen)
            {
                Worker.Logger.log(false);
            }
            Worker.Logger.log(2, "Logging", "Logging code initialized and working");
            Worker.Logger.log(2, "System", "System started, app window should open wihin 3 seconds");
            Vars.InitViewsList();
            Worker.main.Viewer.Content = View.Calc;
            Worker.main.Show();
        }
    }
}
