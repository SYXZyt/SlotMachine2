using System;

namespace BanketyBank
{
    class Wheel
    {

        public static Random rand = new Random();

        public static int Spin() //Spin the wheel
        {

            int wheelVal = rand.Next(1, 64);/*Pick random number between 1 and 64
                                              *The max is exclusive meaning that
                                              *64 will never be picked as a number.
                                              *The min is inclusive, meaing that 
                                              *1 will be picked*/


            if (wheelVal > 0 && wheelVal < 11) //This code should be self-explanitory, aka, i cba commenting
                //all of this code. Im sure you can understand it
                //Basiaclly, it returns what index of the wheel arrays we generated
            {
                return 0;
            }
            else if (wheelVal > 10 && wheelVal <= 19)
            {
                return 1;
            }
            else if (wheelVal > 19 && wheelVal <= 27)
            {
                return 2;
            }
            else if (wheelVal > 27 && wheelVal <= 34)
            {
                return 3;
            }
            else if (wheelVal > 34 && wheelVal <= 40)
            {
                return 4;
            }
            else if (wheelVal > 40 && wheelVal <= 46)
            {
                return 5;
            }
            else if (wheelVal > 46 && wheelVal <= 51)
            {
                return 6;
            }
            else if (wheelVal > 51 && wheelVal <= 56)
            {
                return 7;
            }
            else if (wheelVal > 56 && wheelVal <= 60)
            {
                return 8;
            }
            else if (wheelVal > 60 && wheelVal <= 64)
            {
                return 9;
            }
            else //If we generate a number that isnt a part of the odds
            {
                Console.WriteLine("OUT-OF-RANGE"); //If this prints, something went wrong
                return 0; //Return cherry
            }
        }

        public static void MoneyCheck() //Check how much money to give the player
        {
            if (Face.wheelOneVal == 0 && Face.wheelTwoVal == 0 && Face.wheelThrVal == 0)//If all wheels are cherry
            {
                Face.money += 0.20m; //Give 20p
                Face.jackpotWorth += 0.20m;
            }
            else if (Face.wheelOneVal == 1 && Face.wheelTwoVal == 1 && Face.wheelThrVal == 1)//If all wheels are lemon
            {
                Face.money += 0.60m; //Give 60p
                Face.jackpotWorth += 0.60m;
                Minigames.HigherOrLower(); //Call the higher or lower minigame
            }
            else if (Face.wheelOneVal == 2 && Face.wheelTwoVal == 2 && Face.wheelThrVal == 2)//If all wheels are rberry
            {
                Face.money += 0.80m; //Give 80p
                Face.jackpotWorth += 0.80m;
                Minigames.HigherOrLower(); //Call the higher or lower minigame
            }
            else if (Face.wheelOneVal == 3 && Face.wheelTwoVal == 3 && Face.wheelThrVal == 3)//If all wheels are sberry
            {
                Face.money += 1.00m; //Give £1
                Face.jackpotWorth += 1.00m;
            }
            else if (Face.wheelOneVal == 4 && Face.wheelTwoVal == 4 && Face.wheelThrVal == 4)//If all wheels are wmelon
            {
                Face.money += 1.20m; //Give £1.20
                Face.jackpotWorth += 1.20m;
            }
            else if (Face.wheelOneVal == 5 && Face.wheelTwoVal == 5 && Face.wheelThrVal == 5)//If all wheels are Bar
            {
                Face.money += 1.80m; //Give £1.80
                Face.jackpotWorth += 1.80m;
                Minigames.HigherOrLower(); //Call the higher or lower minigame
            }
            else if (Face.wheelOneVal == 6 && Face.wheelTwoVal == 6 && Face.wheelThrVal == 6)//If all wheels are DBar
            {
                Face.money += 2.00m; //Give £2
                Face.jackpotWorth += 2.00m;
            }
            else if (Face.wheelOneVal == 7 && Face.wheelTwoVal == 7 && Face.wheelThrVal == 7)//If all wheels are TBar
            {
                Face.money += 4.00m; //Give £4
                Face.jackpotWorth += 4.00m;
            }
            else if (Face.wheelOneVal == 8 && Face.wheelTwoVal == 8 && Face.wheelThrVal == 8)//If all wheels are Book
            {
                //Call "feature" code
            }
            else if (Face.wheelOneVal == 9 && Face.wheelTwoVal == 9 && Face.wheelThrVal == 9)//If all wheels are JPot
            {
                Face.money += Face.jackpotWorth; //Give £5
                Face.jackpotWorth = 5.00m;
                Jackpot.Jingle();
            }
            else { } //If non of the conditions are met, then pass
        }

        public static void NudgeCheck()
        {
            //The game seems to rewards nudges too often, so when any wheel equals 6, there is a one in two chance to be rewarded
            int chance = 0;


            if (Face.wheelOneVal == 6 || Face.wheelTwoVal == 6 || Face.wheelThrVal == 6)
            {
                chance = rand.Next(1,3);

                if (chance == 2)
                {
                    Face.nudges += 2;
                }
            }
        }

        public static int Nudge(int wheel) //Nudge the wheels
        {
            if (wheel == 1)
            {
                Face.nudges--; //Decrement nudges
                Face.wheelOneVal++; //Increment wheel
                
                //Check if we are out of the array
                if (Face.wheelOneVal > 9)
                {
                    Face.wheelOneVal = 0; //Reset to cherry
                }

                return Face.wheelOneVal;

            }
            else if (wheel == 2)
            {
                Face.nudges--; //Decrement nudges
                Face.wheelTwoVal++; //Increment wheel

                //Check if we are out of the array
                if (Face.wheelTwoVal > 9)
                {
                    Face.wheelTwoVal = 0; //Reset to cherry
                }

                return Face.wheelTwoVal;

            }

            else
            {
                Face.nudges--; //Decrement nudges
                Face.wheelThrVal++; //Increment wheel

                //Check if we are out of the array
                if (Face.wheelThrVal > 9)
                {
                    Face.wheelThrVal = 0; //Reset to cherry
                }

                return Face.wheelThrVal;

            }
        }
    }
}
