using System;

namespace BanketyBank
{
    class Minigames
    {
        public static Random rand = new Random();

        public static void HigherOrLower()
        {
            //The higher or lower minigame
            
            Console.Beep(350, 350); //Play two notes 100hz apart
            Console.Beep(450, 350);

            //Clear the console
            Console.Clear();

            //Define var
            int curr = 0;
            int prev = 0;
            decimal money = 0.00m;
            string input;
            string correct;
            int min = 1;
            int max = 13;


            Console.WriteLine("HIGHER OR LOWER");

            prev = rand.Next(min, max);

            money = 0.60m;

            while (true)
            {
                curr = rand.Next(min,max); //Generate number

                while(curr == prev)
                {
                    curr = rand.Next(min, max); //Generate new number if they are the same
                }

                if (curr > prev) //set correct to the correct answer
                {
                    correct = "h";
                }
                else
                {
                    correct = "l";
                }

                Console.WriteLine("The number generated is {0}, Higher or Lower? - Answer with H or L", prev);
                Console.WriteLine("Get this right to win £{0}", money);
                //Console.WriteLine(curr); ---This prints the correct answer

                //Check if values are the highest or lowest possible
                if (prev == 1)
                {
                    Console.WriteLine("Must be higher");
                }
                else if (prev == 12)
                {
                    Console.WriteLine("Must be lower");
                }
                else { }

                //Get users input
                input = Console.ReadLine();

                input.ToLower();

                //Check users input
                if (input == correct)
                {
                    Console.Clear();
                    money += 0.60m;
                    prev = curr;
                }
                else if (input != "h" && input != "l") 
                {
                    Console.Clear();
                }
                else
                {
                    Face.money += (money-0.60m); //Give the player money

                    Console.Clear();
                    Interface.ResetColour();
                    Draw.ReDraw(); //Redraw the ui 
                    Face.Game(); //Call the main game method
                }

            }
        }
    }
}
