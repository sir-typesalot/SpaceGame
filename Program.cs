using System;

namespace SpaceGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Display console = new Display();
            Galaxy galaxy = new Galaxy(@"..\..\..\Resources\PlanetConfig.xml");

            console.Draw("Start_Game");

            console.Write("Welcome to the Game", pauseText:true, textIndent:5);

            string _startChoice = "1";

            //Loop for help and exit options.
            while (_startChoice != "y")
            {
                _startChoice = console.GetInput("Enter\n[Yy] - Start\n[Nn] - Exit\n[Hh] - Help");
                _startChoice = _startChoice.ToLower();


                //Exit game.
                if (_startChoice == "n")
                {
                    // Output and then console will exit
                    console.Write("Thank you for Playing", pauseText:true, textIndent:5);
                    Environment.Exit(0);
                }
                //Display help.
                else if (_startChoice == "h")
                {
                    // Simple Help Dialog
                    console.Write(
                    "\nTo play, press Y/y." +
                    "\nThe objective of the game is to find the crystal and trade it to Xabat before time runs out");
                }
            }

            //DISPLAY STORY TEXT HERE

            console.Write("story text");//placeholder

            //ALLOW PLAYER TO BUY ITEMS AT FIRST PLANET

            // Should we create a property in the Galaxy Class to handle this? - What do you guys think?
            int timesTraveled = 0;
            //Loop to limit how many planets player can travel to.
            while (timesTraveled <= 15)
            {
                
                //Pick a planet to travel to.
                console.Write("pick a planet to travel to");//placeholder

                //Display planets story
                console.Write("display selected planets story");//placeholder
                

                string currentAction = "1";

                while (currentAction != "p")
                {
                    currentAction = console.GetInput("Enter\n[Bb] - Buy\n[Ss] - Sell\n[Pp] - Travel to a new planet");
                }

                timesTraveled++;
            }

            console.Write("And thus he left...", pauseText: true, textIndent: 5);

            console.Draw("End_Game");
            // test

        }
    }
}
