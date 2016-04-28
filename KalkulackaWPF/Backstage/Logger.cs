using KalkulackaWPF.Properties;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;

namespace KalkulackaWPF
{
    class Logger
    {
        public bool consoleLogged { get; set; }
        public bool fileLogged { get; set; }
        public Logger(int level, string attr, string value)
        {
            if (ProgHelp.consoleActive)
            {
                if (level == 0) //FATAL
                {
                    Console.Write("[{0}][", string.Format("{0}, {1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString()));
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("FATAL");
                    Console.ResetColor();
                    Console.WriteLine("][{0}] > {1}", attr, value);

                }
                else if (level == 1) // WARN
                {
                    Console.Write("[{0}][", string.Format("{0}, {1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString()));
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("WARN");
                    Console.ResetColor();
                    Console.WriteLine("][{0}] > {1}", attr, value);
                }
                else if (level == 2) // INFO
                {
                    Console.Write("[{0}][", string.Format("{0}, {1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString()));
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("INFO");
                    Console.ResetColor();
                    Console.WriteLine("][{0}] > {1}", attr, value);
                }
                else if (level == 3) // EVENT
                {
                    Console.ResetColor();
                    Console.Write("[{0}][", string.Format("{0}, {1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString()));
                    Console.WriteLine("EVENT][{0}] > {1}", attr, value);
                }
                consoleLogged = true;
                int line = Console.CursorTop;
                Console.SetCursorPosition(0, 0);
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Program logging Console");
                Console.ResetColor();
                Console.SetCursorPosition(0, line);
            }
            else
            {
                consoleLogged = false;
            }
            if (Properties.Settings.Default.logging)
            {
                string path = First.logPath;
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                TextWriter write = new StreamWriter(path, true);

                if (level == 0)
                {
                    write.WriteLine("[{0}, {1}][FATAL][{2}] > {3}", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), attr, value);
                }
                else if (level == 1)
                {
                    write.WriteLine("[{0}, {1}][WARN][{2}] > {3}", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), attr, value);
                }
                else if (level == 2)
                {
                    write.WriteLine("[{0}, {1}][INFO][{2}] > {3}", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), attr, value);
                }
                else if (level == 3)
                {
                    write.WriteLine("[{0}, {1}][EVENT][{2}] > {3}", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), attr, value);
                }
                fileLogged = true;
                write.Close();
            }
            else
            {
                fileLogged = false;
            }
        }
        public Logger(bool license)
        {
            if (license)
            {
                ConsoleHelper.Create();
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
                ConsoleHelper.Destroy();
            }
            else
            {
                if (Settings.Default.logging)
                {
                    ConsoleHelper.Create();
                    new Logger(2, "Logging", "Logging code initialized and working");
                    new Logger(2, "System", "System started, app window should open wihin 3 seconds");
                }
            }
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
