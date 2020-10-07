using System;

namespace BanketyBank
{
    class Jackpot
    {
        public static void Jingle()
        {
            /*Play a little arpeggio
             The specific notes are not accurate since Console.Beep does not support floats
             Therefore, the frequences are rounded*/

            //This arpeggio is a modified version of an arp from a song
            //I made. The song is the main theme of a game im making

            int delay = 200;

            Console.Beep(440, delay);//A4 440
            Console.Beep(494, delay);//B4 493.88
            Console.Beep(523, delay);//C5 523.25
            Console.Beep(494, delay);//B4 493.88

            Console.Beep(349, delay);//F4 349.23
            Console.Beep(392, delay);//G4 392
            Console.Beep(440, delay);//A4 440
            Console.Beep(392, delay);//G4 392
            Prompt(); //Call prompt
        }

        public static void Prompt()
        {
            Console.Clear();
            Interface.TxtColour(ConsoleColor.DarkYellow);
            Console.WriteLine("CONGRATS!!!");
            Console.WriteLine("\n\n\nYou got a jackpot!\nEnter i to continue");

            while (true)
            {
                string input = Console.ReadLine();

                input.ToLower();

                if (input == "i")
                {
                    Console.Clear();
                    Interface.ResetColour();
                    Draw.ReDraw(); //Redraw the ui 
                    Face.Game(); //Call the main game method
                }
            }
        }
    }
}
