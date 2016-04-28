using System;
using System.Runtime.InteropServices;
using System.Security;
using KalkulackaWPF.Properties;

namespace KalkulackaWPF
{
    class First
    {
        public static MainWindow main = new MainWindow();
        public static string logPath = Settings.Default.loggingFile.Replace("{date}", DateTime.Now.ToShortDateString()).Replace("{time}", DateTime.Now.ToLongTimeString().Replace(":", "."));
        public First()
        {
            ConsoleHelper.Create();
            ProgHelp.consoleActive = true;
            Console.Clear();
            if (!Settings.Default.license)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("By using this product you agree to the License Agreement accompanied with this product, that is available through options menu. By continuing you agree that you have read and understand the License Agreement. If you disagree with the License Agreement please quit this software immediately and contact Author");
                Console.WriteLine("Hit Enter key now to accept the license and start the program or anything else to quit: ");
                if (Console.ReadKey().Key.ToString() == "Enter")
                {
                    Settings.Default.license = true;
                    Settings.Default.Save();
                    Console.WriteLine("License Accepted!");
                }
                else
                {
                    Console.WriteLine("License Rejected, quitting");
                    System.Windows.Application.Current.Shutdown();
                }
            }
            
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Program logging Console");
            Console.ResetColor();
            new Logger(2, "General", "Program started, app window should open within 3 seconds.");
            main.isResult = false;
            main.lastResult = 0;
            main.Show();
        }
    }
    public class ConsoleHelper
    {
        public static int Create()
        {
            if (AllocConsole())
                return 0;
            else
                return Marshal.GetLastWin32Error();
        }

        public static int Destroy()
        {
            if (FreeConsole())
                return 0;
            else
                return Marshal.GetLastWin32Error();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage"), SuppressUnmanagedCodeSecurity]
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage"), SuppressUnmanagedCodeSecurity]
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool FreeConsole();
    }
}
