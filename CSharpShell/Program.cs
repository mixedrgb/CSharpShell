using System.ComponentModel;
using System.Diagnostics;

namespace CSharpShell
{
    public class CSharpShell
    {
        private static void Help()
        {
            Console.WriteLine("This is a help message");
        }

        private static void DoStuff(string args)
        {
            var arr = args.Split('\u0020');
            if (arr[0] == "")
            {
                Console.WriteLine("wat");
                return;
            }

            var p = new Process();
            if (arr.Length > 1)
            {
                p.StartInfo = new ProcessStartInfo(arr[0], arr[1]);
            }
            else
            {
                p.StartInfo = new ProcessStartInfo(arr[0]);
            }
            try
            {
                p.Start();
                p.WaitForExit();
            }
            catch (Win32Exception)
            {
                Console.WriteLine("Oops 1");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Oops 2");
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
                    case "exit":
                        Console.WriteLine("Hey thanks, bro");
                        Environment.Exit(0);
                        break;
                    case "help":
                        Help();
                        break;
                    default:
                        DoStuff(args);
                        break;
                }
            }
        }

        internal static void Main()
        {
            const string helloMsg = "Slap the Earth!";
            Console.WriteLine(helloMsg);
            Loop();
        }
    }
}