using System;

namespace BanketyBank
{
    class Initalise
    {

        public static void Main()
        {
            Console.Clear();
            Console.Title = "Bankety Bank"; //Set console title
            Console.OutputEncoding = System.Text.Encoding.Unicode; //Use unicode rather than ascii

            //Call Startup
            Menu.StartUp();
        }
    }
}
