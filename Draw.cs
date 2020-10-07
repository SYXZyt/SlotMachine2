using System;
using System.ComponentModel.Design;

namespace BanketyBank
{
    class Draw
        //This class contains all the methods used to draw to the screen
    {
        public static void Empty() //This is called at the very start of each game
        {
            //Default cursor position
            int x = Console.CursorLeft;
            int y = Console.CursorTop;

            Console.CursorTop = Console.WindowTop + Console.WindowHeight - 1; //Move cursor to last time
            //Draw UI
            Console.WriteLine("Money: £{0} - Credits Left: {1} - Nudges: {2} - Jackpot: £{3}", Face.money, Face.credits
                ,Face.nudges, Face.jackpotWorth);

            Console.SetCursorPosition(x, y); //Move cursor back to top left

            Console.WriteLine(">[Cherry]-[Cherry]-[Cherry]<");
            Console.WriteLine("Press [ENTER] to spin");
        }
        public static void ReDraw() //Draws after each spin
        {
            Interface.RemoveLastLine();
            //Cursor pos
            int x = Console.CursorLeft;
            int y = Console.CursorTop;
            //Move cursor to teh last line
            Console.CursorTop = Console.WindowTop + Console.WindowHeight;

            //Draw UI
            Interface.RemoveLastLine();
            Console.WriteLine("Money: £{0} - Credits Left: {1} - Nudges: {2} - Jackpot: £{3}", Face.money, Face.credits
                , Face.nudges, Face.jackpotWorth);
            //Reset cursor
            Console.SetCursorPosition(x, y);

            Interface.RemoveLastLine();
            Console.WriteLine(">[{0}]-[{1}]-[{2}]<", Face.wheelOne[Face.wheelOneVal], Face.wheelTwo[Face.wheelTwoVal]
            , Face.wheelThr[Face.wheelThrVal]); //Draw wheel values
        }

        public static void EndDraw() //Draws when player is out of credits
        {
            Console.Clear(); //Clear console

            bool shouldDraw = false; //Should the game write about nudges?

            decimal leftover = 0.00m; //Set leftover amount

            int before = Face.nudges; //Nudges at the end of the game

            Interface.TxtColour(ConsoleColor.Red); //Change text colour to red
            Console.WriteLine("Game Over!");
            Interface.ResetColour();
            
            //Set shouldDraw
            if (Face.nudges > 0)
            {
                shouldDraw = true;
            }

            //Calculate how much has been made from nudges
            if (shouldDraw == true)
            {
                while (Face.nudges != 0) //Add 20p for every nudge
                {
                    leftover += 0.20m;
                    Face.nudges--;
                    if (Face.nudges == 0)
                    {
                        break;
                    }
                }
            }

            Face.nudges = before; //Reset nudges to the value before calculations

            //Draw info about nudges
            if (shouldDraw == true)
            {
                if (Face.nudges > 1)
                {
                    Console.WriteLine("You had {0} nudges which equates to £{1}", Face.nudges, leftover);
                }
                else if (Face.nudges == 1)
                {
                    Console.WriteLine("You had {0} nudge which equates to £{1}", Face.nudges, leftover);
                }
                else { }
            }

            Face.money += leftover; //Add leftover amount to the final money value

            Console.WriteLine("You ran out of credits. You earnt £{0}", Face.money);
            Console.WriteLine("Enter I to insert more credits");

            while (true)
            {
                string inp = Console.ReadLine();
                //Wait for player to press i
                inp.ToLower();

                if (inp == "i")
                {
                    Console.Clear();
                    Face.FirstTime();//Restart
                }
                else
                {
                    Interface.RemoveLastLine(); //Remove Lastline
                }
            }


        }
    }
}
