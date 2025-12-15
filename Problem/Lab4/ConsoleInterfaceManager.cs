using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Problem.StudentDataBase.TechnicalStuff
{
    public static class ConsoleInterfaceManager
    {
        public static void DrawColoredText(object article, ConsoleColor color)
        {
            if (article != null && !string.IsNullOrWhiteSpace(Convert.ToString(article)))
            {
                var previousColor = Console.ForegroundColor;
                Console.ForegroundColor = color;
                Console.WriteLine(Convert.ToString(article));
                Console.ForegroundColor = previousColor;
            }
            else
            {
                var previousColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Data were corrupted");
                Console.ForegroundColor = previousColor;
            }
        }

        public static void CentralizeText(string text)
        {
            const int HALF_SCREEN_WIDTH = 2;
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / HALF_SCREEN_WIDTH, Console.CursorTop);
            Console.WriteLine(text);
        }
        public static double ReadDouble(string prompt)
        {
            while (true)
            {
                if (string.IsNullOrWhiteSpace(prompt))
                {
                    ConsoleInterfaceManager.DrawColoredText($"No prompt was provided", ConsoleColor.Red);
                    throw new ArgumentException("No prompt Exception");
                }
                else
                {
                    ConsoleInterfaceManager.DrawColoredText(prompt, ConsoleColor.Green);
                }
                var input = Console.ReadLine();

                if (double.TryParse(input, out double value))
                {
                    return value;
                }

                Console.WriteLine("Invalid number, use proper decimal separator.");
            }
        }

        public static int ReadInt(string prompt, int minInclusive = 0)
        {
            while (true)
            {
                if (string.IsNullOrWhiteSpace(prompt))
                {
                    ConsoleInterfaceManager.DrawColoredText($"No prompt was provided", ConsoleColor.Red);
                    throw new ArgumentException("No prompt Exception");
                }
                else
                {
                    ConsoleInterfaceManager.DrawColoredText(prompt, ConsoleColor.Green);
                }
                var input = Console.ReadLine();

                if (int.TryParse(input, out int value) && value >= minInclusive)
                {
                    return value;
                }

                Console.WriteLine($"Invalid integer, must be >= {minInclusive}.");
            }
        }

        public static string AskFileName()
        {
            while (true)
            {
                Console.Write("Enter file name to save plot (e.g. plot.png): ");
                string fileName = Console.ReadLine() ?? "";

                if (!string.IsNullOrWhiteSpace(fileName))
                {
                    return fileName;
                }
                ConsoleInterfaceManager.DrawColoredText($"File name cannot be empty.", ConsoleColor.Red);
            }
        }
     }
}
