using System;
using System.Windows.Forms;

namespace BanketyBank
{
    class Face
    {
        public static decimal money; //Stores players money
        public static int credits; //Stores game credits
        public static int nudges; //Stores game nudges
        public static bool openMode; //Stores if the game is running cheat mode

        //Arrays to contain all possible wheel values
        public static string[] wheelOne = {"Cherry", "Lemon", "Raspberry", "Strawberry"
                , "Watermelon", "Bar", "Double Bar", "Triple Bar", "Book", "Jackpot"};
        public static  string[] wheelTwo = {"Cherry", "Lemon", "Raspberry", "Strawberry"
                , "Watermelon", "Bar", "Double Bar", "Triple Bar", "Book", "Jackpot"};
        public static string[] wheelThr = {"Cherry", "Lemon", "Raspberry", "Strawberry"
                , "Watermelon", "Bar", "Double Bar", "Triple Bar", "Book", "Jackpot"};

        public static ConsoleColor openModeColour; //What colour is used when open mode is enabled

        public static decimal jackpotWorth = 5.00m; //How much is awarded per jackpot

        public static string input; //Users input

        public static bool canDrain; //Can the players nudges be drained?

        public static int count; //Count each spin until nudges can be drained

//|***************Wheel values***************|
//|==========================================|
        public static int wheelOneVal = 0;
        public static int wheelOneValPrev;
        public static int wheelTwoVal = 0;
        public static int wheelTwoValPrev;
        public static int wheelThrVal = 0;
        public static int wheelThrValPrev;
//|==========================================|


        public static void Freeze()
        {
            Console.ReadKey();
        }

        public static void FirstTime() //This is ran the first time the game is player, used to initalise var
        {

//|***********Initalise Variables*************|
//|===========================================|
            money = 0.00m;
            credits = 50;
            nudges = 0;
            openMode = false;
            canDrain = false;
            count = 0;
            //|===========================================|

            Draw.Empty(); //Draw empty screen / Screen to be drawn before the game has begun
            Game();
        }

        public static void Game()
        {

            openModeColour = ConsoleColor.Cyan; //Set default colour when openmode is on

            while (true)
            {

                //Check if the player still has credits
                if (credits <= 0)
                {
                    Draw.EndDraw();
                }

                input = Console.ReadLine();
                Interface.RemoveLastLine();

                input.ToLower(); //Change user's input to lowercase to avoid case issues

                //Check what the users input is
                switch (input)
                {
                    case "n1":
                        //Make sure we are allowed to nudge
                        if (nudges == 0)
                        {
                            MessageBox.Show("Cannot nudge - No nudges available to use");
                            break;
                        }

                        wheelOneVal = Wheel.Nudge(1); //Nudge the wheel

                        Wheel.MoneyCheck(); //Check if we have earnt money

                        Draw.ReDraw(); //Re-draw the screen

                        break;

                    case "n2":
                        //Make sure we are allowed to nudge
                        if (nudges == 0)
                        {
                            MessageBox.Show("Cannot nudge - No nudges available to use");
                            break;
                        }

                        wheelTwoVal = Wheel.Nudge(2); //Nudge the wheel

                        Wheel.MoneyCheck(); //Check if we have earnt money

                        Draw.ReDraw(); //Re-draw the screen

                        break;

                    case "n3":
                        //Make sure we are allowed to nudge
                        if (nudges == 0)
                        {
                            MessageBox.Show("Cannot nudge - No nudges available to use");
                            break;
                        }

                        wheelThrVal = Wheel.Nudge(3); //Nudge the wheel

                        Wheel.MoneyCheck(); //Check if we have earnt money

                        Draw.ReDraw(); //Re-draw the screen

                        break;


                    case "sys.call.jpot": //Used for testing, calls jackpot.prompt()
                        if (openMode)
                        {
                            wheelOneVal = 9;
                            wheelTwoVal = 9;
                            wheelThrVal = 9;

                            Wheel.MoneyCheck();

                        }
                        break;

                    case "h1":

                        if (nudges == 0) //Make sure player has enough nudges
                        {
                            MessageBox.Show("Cannot hide - No nudges available to use");
                            break;
                        }

                        nudges--; //Use nudges

                        if (nudges > 10) //Stop nudges going over max
                        {
                            nudges = 10;
                        }
                        if (nudges < 0) //Stop nudges going into negative
                        {
                            nudges = 0;
                        }

                        //Spin wheels

                        wheelTwoValPrev = wheelTwoVal;
                        wheelThrValPrev = wheelThrVal;

                        //Spin wheel two
                        while (wheelTwoValPrev == wheelTwoVal)
                        {
                            wheelTwoVal = Wheel.Spin();
                        };
                        //Spin wheel three
                        while (wheelThrValPrev == wheelThrVal)
                        {
                            wheelThrVal = Wheel.Spin();
                        }

                        //Check if the player is using cheats
                        if (!openMode) //When checking bools using if (bool), looks for true, if (!bool), looks for false
                        {
                            credits--;
                        }


                        Wheel.NudgeCheck(); //Check if the player needs nudges rewarding
                        Wheel.MoneyCheck(); //Check if the player needs rewarding


                        Draw.ReDraw(); //Re-draw the screen
                        break;

                    case "h2":

                        if (nudges == 0) //Make sure player has enough nudges
                        {
                            MessageBox.Show("Cannot hide - No nudges available to use");
                            break;
                        }

                        nudges--; //Use nudges

                        if (nudges > 10) //Stop nudges going over max
                        {
                            nudges = 10;
                        }
                        if (nudges < 0) //Stop nudges going into negative
                        {
                            nudges = 0;
                        }

                        //Spin wheels

                        wheelOneValPrev = wheelOneVal;
                        wheelThrValPrev = wheelThrVal;

                        //Spin wheel one
                        while (wheelOneValPrev == wheelOneVal)
                        {
                            wheelOneVal = Wheel.Spin();
                        };
                        //Spin wheel three
                        while (wheelThrValPrev == wheelThrVal)
                        {
                            wheelThrVal = Wheel.Spin();
                        }

                        //Check if the player is using cheats
                        if (!openMode) //When checking bools using if (bool), looks for true, if (!bool), looks for false
                        {
                            credits--;
                        }


                        Wheel.NudgeCheck(); //Check if the player needs nudges rewarding
                        Wheel.MoneyCheck(); //Check if the player needs rewarding


                        Draw.ReDraw(); //Re-draw the screen
                        break;

                    case "h3":

                        if (nudges == 0) //Make sure player has enough nudges
                        {
                            MessageBox.Show("Cannot hide - No nudges available to use");
                            break;
                        }

                        nudges--; //Use nudges

                        if (nudges > 10) //Stop nudges going over max
                        {
                            nudges = 10;
                        }
                        if (nudges < 0) //Stop nudges going into negative
                        {
                            nudges = 0;
                        }

                        //Spin wheels

                        wheelOneValPrev = wheelOneVal;
                        wheelTwoValPrev = wheelTwoVal;

                        //Spin wheel one
                        while (wheelOneValPrev == wheelOneVal)
                        {
                            wheelOneVal = Wheel.Spin();
                        };
                        //Spin wheel two
                        while (wheelTwoValPrev == wheelTwoVal)
                        {
                            wheelTwoVal = Wheel.Spin();
                        }

                        //Check if the player is using cheats
                        if (!openMode) //When checking bools using if (bool), looks for true, if (!bool), looks for false
                        {
                            credits--;
                        }


                        Wheel.NudgeCheck(); //Check if the player needs nudges rewarding
                        Wheel.MoneyCheck(); //Check if the player needs rewarding


                        Draw.ReDraw(); //Re-draw the screen
                        break;


                    case "":
                        //Spin wheels
                        
                        wheelOneValPrev = wheelOneVal;
                        wheelTwoValPrev = wheelTwoVal;
                        wheelThrValPrev = wheelThrVal;
                        
                        //Spin wheel one
                        while (wheelOneValPrev == wheelOneVal)
                        {
                            wheelOneVal = Wheel.Spin();
                        }
                        //Spin wheel two
                        while (wheelTwoValPrev == wheelTwoVal)
                        {
                            wheelTwoVal = Wheel.Spin();
                        };
                        //Spin wheel three
                        while (wheelThrValPrev == wheelThrVal)
                        {
                            wheelThrVal = Wheel.Spin();
                        }

                        //Check if the player is using cheats
                        if (!openMode)
                        {
                            credits--;
                        }


                        Wheel.NudgeCheck(); //Check if the player needs nudges rewarding
                        Wheel.MoneyCheck(); //Check if the player needs rewarding


                        //Nudge draining
                        if (count < 2)
                        {
                            if (canDrain == true)
                            {
                                count++; //Increment count
                            }
                        }
                        //Actually drain the nudges
                        if (count >= 2)
                        {
                            nudges--;
                            count = 0;
                        }
                        //Stop nudges from going into negative
                        if (nudges < 0)
                        {
                            nudges = 0;
                            canDrain = false;
                            count = 0;
                        }
                        //Enable nudges
                        if (nudges > 0)
                        {
                            canDrain = true;
                        }
                        //Limit nudges
                        if (nudges > 10)
                        {
                            nudges = 10;
                        }


                        Draw.ReDraw(); //Re-draw the screen
                        break;

                    case "sys.openmode":
                        openMode = !openMode; //Toggle openmode bool

                        if (openMode) //If openmode is now on
                        {
                            Interface.TxtColour(openModeColour); //Change text colour to cyan
                            MessageBox.Show("Open mode has been enabled. \n While in this mode, you will not lose credits.\n" +
                                "Re-enter 'sys.openmode' to disable open mode, or type 'end' to end the game."); //Inform user openmode is on
                            Console.Title = "Bankety Bank - Open Mode"; //Change title

                        }
                        else //If openmode is now off
                        {
                            Interface.ResetColour();
                            MessageBox.Show("Open mode has been disabled."); //Inform user openmode is off
                            Console.Title = "Bankety Bank";
                        }

                        Console.Clear(); //Clear and redraw the console to force change the text colour
                        Draw.ReDraw();

                        break;

                    case "end":
                        Draw.EndDraw();
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
