using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem.StudentDataBase.TechnicalStuff
{
    public static class ConsoleInterfaceManager
    {
        public static void DrawColoredText<T>(T article, ConsoleColor color)
        {
            if (article != null || !string.IsNullOrWhiteSpace(Convert.ToString(article)))
            {
                Console.WriteLine(Convert.ToString(article), Console.ForegroundColor = color);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.WriteLine("Data were corrupted", ConsoleColor.Green);
            }
        }
        public static void CentralizeText(string text)
        {
            const int HALF_SCREEN_WIDTH = 2;
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / HALF_SCREEN_WIDTH, Console.CursorTop);
            Console.WriteLine(text);
        }
    }
}
