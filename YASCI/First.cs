using System;
using System.Runtime.InteropServices;
using System.Security;
using YASCI.Views;
using YASCI.Objects;
using System.Configuration;
using YASCI.Backstage;

namespace YASCI
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
