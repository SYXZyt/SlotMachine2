using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanketyBank
{
    class Interface
    {
        public static void RemoveLastLine()
        {
            if (Console.CursorTop == 0) return;
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }
        public static void TxtColour(ConsoleColor colour)
        {
            Console.ForegroundColor = colour;
        }
        public static void ResetColour()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
