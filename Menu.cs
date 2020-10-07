using System;
using System.Threading;

namespace BanketyBank
{
    class Menu
    {
        private static bool skip = false;

        private static int fore = 0;

        public static void StartUp()
        {
            Console.WriteLine("Starting Up");

            System.Threading.Thread.Sleep(500);

            if (skip) //Check if the startup is to be skipped
            {
                Console.Clear();
                Face.FirstTime();
            }

            int count = 0;


            //Colourful startup sequence - If you want to skip, set skip to true
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Starting Up");
                fore++;
                count++;

                if (count == 5)
                {
                    Console.Clear();
                    Interface.ResetColour();
                    Face.FirstTime();
                }

                if (fore > 3)
                {
                    fore = 0;
                }

                switch (fore)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        break;

                }

                Thread.Sleep(100);
            }
        }
    }
}
