using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YASCI.Objects;
using YASCI.Views;

namespace YASCI.Backstage
{
    class PageManager
    {
        //public Dictionary<int, object> history { get; set; }
        public string[] history { get; private set; }
        public int historyLevel { get; set; }
        public PageManager()
        {
            history = new string[64];
            historyLevel = 0;
            history[0] = "Calc";
        }

        public void SetPage(string id)
        {
            if (id == "back")
            {
                Back();
            }
            else
            {
                Goto(id);
            }
        }

        private void Back()
        {
            Worker.Logger.log(2, "Display", "Going back in view history from {0} to {1}", history[historyLevel], history[historyLevel - 1]);
            object lastPage = Vars.viewsList[history[historyLevel - 1]];
            history[historyLevel] = null;
            historyLevel -= 1;
            Worker.main.Viewer.Content = lastPage;
            Rename();
        }

        private void Goto(string id)
        {
            Worker.Logger.log(2, "Display", string.Format("Setting page to {0}", id));
            history[historyLevel + 1] = id;
            historyLevel += 1;
            Worker.main.Viewer.Content = Vars.viewsList[id];
            Worker.main.Title = "YASCI MyEasyCalc - " + Vars.titleList[id].ToString();
        }

        private void Rename()
        {
            Worker.main.Title = "YASCI MyEasyCalc - " + Vars.titleList[history[historyLevel]];
        }
    }
}
