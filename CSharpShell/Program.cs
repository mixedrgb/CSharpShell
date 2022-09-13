using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using Microsoft.VisualBasic;

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

        private static void changeDir(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 1; i < args.Length; i++)
            {
                sb.Append(args[i]);
            }

            try
            {
                Directory.SetCurrentDirectory(sb.ToString());
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("how dare u");
            }
        }
        private static void Loop()
        {
            while (true)
            {
                Console.Write("> ");
                string args = Console.ReadLine();
                string[] useArgs = args.Split(' ');
                switch (useArgs[0])
                {
                    case "cd":
                        changeDir(useArgs);
                        break;
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