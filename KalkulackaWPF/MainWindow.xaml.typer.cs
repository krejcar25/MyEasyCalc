using System.Windows.Input;

namespace KalkulackaWPF
{
    public partial class MainWindow
    {
        public void typer(object sender, KeyEventArgs e)
        {
            new Logger(3, "Keypress", string.Format("A key was pressed: {0}", e.Key));
            switch (e.Key)
            {
                case Key.None:
                    break;
                case Key.Cancel:
                    break;
                case Key.Back:
                    First.Calc.updateDisplay("del");
                    break;
                case Key.Tab:
                    break;
                case Key.LineFeed:
                    break;
                case Key.Clear:
                    break;
                case Key.Enter:
                    First.Calc.updateDisplay("moveUp", "equal");
                    First.processor.Process();
                    break;
                case Key.Pause:
                    break;
                case Key.CapsLock:
                    break;
                case Key.Escape:
                    First.Calc.updateDisplay("clear");
                    break;
                case Key.Space:
                    break;
                case Key.PageUp:
                    break;
                case Key.PageDown:
                    break;
                case Key.End:
                    break;
                case Key.Home:
                    break;
                case Key.Left:
                    break;
                case Key.Up:
                    break;
                case Key.Right:
                    break;
                case Key.Down:
                    break;
                case Key.Select:
                    break;
                case Key.Print:
                    break;
                case Key.Execute:
                    break;
                case Key.PrintScreen:
                    break;
                case Key.Insert:
                    break;
                case Key.Delete:
                    break;
                case Key.Help:
                    break;
                case Key.D0:
                    First.Calc.updateDisplay("write", "0");
                    break;
                case Key.D1:
                    First.Calc.updateDisplay("write", "1");
                    break;
                case Key.D2:
                    First.Calc.updateDisplay("write", "2");
                    break;
                case Key.D3:
                    First.Calc.updateDisplay("write", "3");
                    break;
                case Key.D4:
                    First.Calc.updateDisplay("write", "4");
                    break;
                case Key.D5:
                    First.Calc.updateDisplay("write", "5");
                    break;
                case Key.D6:
                    First.Calc.updateDisplay("write", "6");
                    break;
                case Key.D7:
                    First.Calc.updateDisplay("write", "7");
                    break;
                case Key.D8:
                    First.Calc.updateDisplay("write", "8");
                    break;
                case Key.D9:
                    First.Calc.updateDisplay("write", "9");
                    break;
                case Key.A:
                    break;
                case Key.B:
                    break;
                case Key.C:
                    break;
                case Key.D:
                    break;
                case Key.E:
                    break;
                case Key.F:
                    break;
                case Key.G:
                    break;
                case Key.H:
                    break;
                case Key.I:
                    break;
                case Key.J:
                    break;
                case Key.K:
                    break;
                case Key.L:
                    break;
                case Key.M:
                    break;
                case Key.N:
                    break;
                case Key.O:
                    break;
                case Key.P:
                    break;
                case Key.Q:
                    break;
                case Key.R:
                    break;
                case Key.S:
                    break;
                case Key.T:
                    break;
                case Key.U:
                    break;
                case Key.V:
                    break;
                case Key.W:
                    break;
                case Key.X:
                    break;
                case Key.Y:
                    break;
                case Key.Z:
                    break;
                case Key.LWin:
                    break;
                case Key.RWin:
                    break;
                case Key.Apps:
                    break;
                case Key.Sleep:
                    break;
                case Key.NumPad0:
                    First.Calc.updateDisplay("write", "0");
                    break;
                case Key.NumPad1:
                    First.Calc.updateDisplay("write", "1");
                    break;
                case Key.NumPad2:
                    First.Calc.updateDisplay("write", "2");
                    break;
                case Key.NumPad3:
                    First.Calc.updateDisplay("write", "3");
                    break;
                case Key.NumPad4:
                    First.Calc.updateDisplay("write", "4");
                    break;
                case Key.NumPad5:
                    First.Calc.updateDisplay("write", "5");
                    break;
                case Key.NumPad6:
                    First.Calc.updateDisplay("write", "6");
                    break;
                case Key.NumPad7:
                    First.Calc.updateDisplay("write", "7");
                    break;
                case Key.NumPad8:
                    First.Calc.updateDisplay("write", "8");
                    break;
                case Key.NumPad9:
                    First.Calc.updateDisplay("write", "9");
                    break;
                case Key.Multiply:
                    First.Calc.updateDisplay("moveUp", "times");
                    break;
                case Key.Add:
                    First.Calc.updateDisplay("moveUp", "plus");
                    break;
                case Key.Separator:
                    break;
                case Key.Subtract:
                    First.Calc.updateDisplay("moveUp", "minus");
                    break;
                case Key.Decimal:
                    First.Calc.updateDisplay("write", ".");
                    break;
                case Key.OemPeriod:
                    First.Calc.updateDisplay("write", ".");
                    break;
                case Key.OemComma:
                    First.Calc.updateDisplay("write", ",");
                    break;
                case Key.Divide:
                    First.Calc.updateDisplay("moveUp", "divide");
                    break;
                case Key.F1:
                    break;
                case Key.F2:
                    break;
                case Key.F3:
                    break;
                case Key.F4:
                    break;
                case Key.F5:
                    break;
                case Key.F6:
                    break;
                case Key.F7:
                    break;
                case Key.F8:
                    break;
                case Key.F9:
                    break;
                case Key.F10:
                    break;
                case Key.F11:
                    break;
                case Key.F12:
                    break;
                case Key.F13:
                    break;
                case Key.F14:
                    break;
                case Key.F15:
                    break;
                case Key.F16:
                    break;
                case Key.F17:
                    break;
                case Key.F18:
                    break;
                case Key.F19:
                    break;
                case Key.F20:
                    break;
                case Key.F21:
                    break;
                case Key.F22:
                    break;
                case Key.F23:
                    break;
                case Key.F24:
                    break;
                case Key.NumLock:
                    break;
                case Key.Scroll:
                    break;
                case Key.LeftShift:
                    break;
                case Key.RightShift:
                    break;
                case Key.LeftCtrl:
                    break;
                case Key.RightCtrl:
                    break;
                case Key.LeftAlt:
                    break;
                case Key.RightAlt:
                    break;
                case Key.BrowserBack:
                    break;
                case Key.BrowserForward:
                    break;
                case Key.BrowserRefresh:
                    break;
                case Key.BrowserStop:
                    break;
                case Key.BrowserSearch:
                    break;
                case Key.BrowserFavorites:
                    break;
                case Key.BrowserHome:
                    break;
                case Key.VolumeMute:
                    break;
                case Key.VolumeDown:
                    break;
                case Key.VolumeUp:
                    break;
            }
        }
    }
}
