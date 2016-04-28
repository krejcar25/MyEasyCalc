using System;
using System.IO;

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
    }
}
