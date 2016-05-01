using YASCI.Objects;
using YASCI.Views;
using System;

namespace YASCI.Backstage
{
    public class BackgroundTasks
    {
        public bool dec { get; set; }
        public string directPad { get; set; }
        public string indirectPad { get; set; }

        public void CheckBlocksInitiate(string directPadParam, string indirectPadParam)
        {
            directPad = directPadParam;
            indirectPad = directPadParam;
            Worker.Logger.log(2, "Code", string.Format("A CheckBlocksInitiate has appeared with current pad values {0} and {1}. Passing to CheckBlocks()",
                directPadParam, indirectPadParam));
            CheckBlocks();
        }
        private void CheckBlocks()
        {
            if (this.directPad.Contains("."))
            {
                dec = true;
            }
            else if (!directPad.Contains("."))
            {
                dec = false;
            }
            if (dec) {
                View.Calc.decButton.IsEnabled = false;
            }
            else if (!dec)
            {
                View.Calc.IsEnabled = true;
            }
        }
        public void InitialiseLogDir()
        {
            string homePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            config.Default.loggingPath = config.Default.loggingPath.Replace("{homeDir}", homePath);
            config.Default.Save();
            Vars.LogPath = config.Default.loggingPath + config.Default.loggingFile.Replace("{date}", DateTime.Now.ToShortDateString()).Replace("{time}", DateTime.Now.ToLongTimeString().Replace(":", "."));
        }
    }
}
