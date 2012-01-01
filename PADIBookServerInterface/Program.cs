using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace Server
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            switch(args.Length){
                case 2:
                    Application.Run(new ServerForm(args[0],args[1]));
                    break;
                case 4:
                    try
                    {
                        Application.Run(new ServerForm(args[0], args[1], args[2], Int32.Parse(args[3])));
                    }catch(FormatException){
                        Console.WriteLine("Invalid chord port number.");
                        return;
                    }
                    break;
                default:
                       Application.Run(new ServerForm());
                       break;
            }
            Process.GetCurrentProcess().Kill();
        }
    }
}
