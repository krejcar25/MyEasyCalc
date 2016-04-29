using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalkulackaWPF.Views
{
    class View
    {
        public static CalcWindow Calc = new CalcWindow();
        public static Options Options = new Options();
        public static LoggingOptions LoggingOptions = new LoggingOptions();
        public static FileNameHelp FileNameHelp = new FileNameHelp();
        public static License License = new License();
        public static About About = new About();
        public static Controls Controls = new Controls();
    }
}
