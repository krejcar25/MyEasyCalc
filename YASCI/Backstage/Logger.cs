using YASCI.Objects;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;

namespace YASCI.Backstage
{
    public class Logger
    {
        public bool consoleLogged { get; set; }
        public bool fileLogged { get; set; }
        public bool licenseDisplayed { get; set; } = false;

        public void log(int level, string attr, string value, params object[] args)
        {
            string newVal = string.Format(value, args);
            log(level, attr, newVal);
        }

        public void log(int level, string attr, string value)
        {
            if (config.Default.console)
            {
                if (level == 0) //FATAL
                {
                    Console.Write("[{0}][", string.Format("{0}, {1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString()));
                    Console.ForegroundColor = ConsoleColor.Red;
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
                    Console.Write("[{0}, {1}][", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString());
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
            }
            else
            {
                consoleLogged = false;
            }
            if (config.Default.logging)
            {
                string path = Vars.LogPath;
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

        public void log(bool license)
        {
            if (license)
            {
                if (!Vars.consoleOpen)
                {
                    ConsoleHelper.Create();
                    Vars.consoleOpen = true;
                }
                Console.Clear();
                if (!config.Default.license)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("By using this product you agree to the License Agreement accompanied with this product, that is available through options menu. By continuing you agree that you have read and understand the License Agreement. If you disagree with the License Agreement please quit this software immediately and contact Author");
                    Console.WriteLine("Hit Enter key now to accept the license and start the program or anything else to quit: ");
                    if (Console.ReadKey().Key.ToString() == "Enter")
                    {
                        config.Default.license = true;
                        config.Default.Save();
                        Console.WriteLine("License Accepted!");
                        Worker.tasks.InitialiseLogDir();
                    }
                    else
                    {
                        Console.WriteLine("License Rejected, quitting");
                        System.Windows.Application.Current.Shutdown();
                    }
                }
                if (!config.Default.console) ConsoleHelper.Destroy();
            }
            else
            {
                if (config.Default.console)
                {
                    ConsoleHelper.Create();
                    Vars.consoleOpen = true;
                }
            }
        }
    }
}
