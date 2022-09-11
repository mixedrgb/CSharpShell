using System.ComponentModel.Design;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace CSharpShell
{
    public class CSharpShell
    {
        private static int exitCount = 0;
        private static void Help()
        {
            Console.WriteLine("This is a help message");
        }

        private static void DoStuff(string args)
        {
            var arr = args.Split('\u002C');
            foreach (var item in arr)
            {
                // do stuff
                Process p = new Process();
                p.StartInfo = new ProcessStartInfo(item);
                p.Start();
            }
        }

        private static void Loop()
        {
            while (true)
            {
                Console.Write("> ");
                var args = Console.ReadLine();
                switch (args)
                {
                    case "help":
                        Help();
                        break;
                    case "exit":
                        Environment.Exit(0);
                        break;
                    default:
                        DoStuff(args);
                        break;
                }
            }
        }

        internal static void Main()
        {
            const string HelloMsg = "Slap the Earth!";
            Console.WriteLine(HelloMsg);
            Loop();
        }
    }
}