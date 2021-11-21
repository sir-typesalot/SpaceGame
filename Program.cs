using System;
using System.Collections.Generic;

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
                    console.Write("Press Q/q at any time to quit the game...");
                }
            }

            // Story Intro
            // Should probably migrate this to a file?
            console.Write("In a galaxy far away, on the planet of Argon, a meteorite-iron trader Aster\n" +
                "miscalculated his spacecraft’s entry to the planet’s belt and is now left with a wrecked"+
                " ship.\nA ship is not that hard to recover from, if only it hadn’t been owned by the" +
                "galaxy’s most feared\nship lender - Xabat. Aster knew they were in trouble. It was only" +
                " a matter of time before Xabat\nheard of the news, 1 galactic day exactly. Once he did," +
                " there was no escape. No place was safe\nfrom Xabat, for he had contacts and bounty" +
                "hunters throughout the galaxy, on every planet, on\nevery outpost. A rumor was " +
                "circulating that there was one thing that Xabat liked more than his\nships, supernova" +
                " crystals, crystals that are found in the debris of an exploded star. Aster\nheard of" +
                "these at one of the outposts on Argon’s moons. Apparently there was a dealer that could" +
                "\nprocure some, but only to the highest bidders. Whatever the cost, Aster knew they had" +
                " no\noption, for his life was dependent on these crystals and he would have to do " +
                "whatever it takes to\nget them, before it’s too late…", textIndent:5);

            // Should we create a property in the Galaxy Class to handle this? - What do you guys think?
            int timesTraveled = 0;
            Planet CurrentPlanet = galaxy.planetsInGalaxy["Argon"];
            int planetChoice = 1;
            //Loop to limit how many planets player can travel to.
            while (timesTraveled <= 15)
            {
                
                string currentAction = "1";
                

                if (timesTraveled == 0)
                {
                    string story = CurrentPlanet.Story;
                    
                    CurrentPlanet.CheckCrystalMan();
                    galaxy.CurrentPlanet = CurrentPlanet.Name;

                    console.Write(story, textIndent: 3);

                } 
                else
                {
                    //Pick a planet to travel to.
                    console.Write(" Pick a planet to travel to");
                    string planetRoster = "";
                    int planetNum = 1;
                    foreach (string planetName in galaxy.planetsInGalaxy.Keys)
                    {
                        string planet = $"\n {planetNum} - {planetName}";
                        planetRoster += planet;
                        planetNum++;
                    }

                    int userChoice =1;

                    //Doesn't allow player to travel to the current planet
                    do
                    {
                        console.Write("\n Traveling to your current planet is forbidden");

                            // Get planet selection from user and convert to Int

                            string travelPlanet = console.GetInput(planetRoster);

                            userChoice = Convert.ToInt32(travelPlanet);

                    }
                    while (userChoice == planetChoice);


                    planetChoice = userChoice;


                    // Display story for selected planet
                    // Need to reset the galaxy.CurrentPlanet to the chosen one
                    switch (planetChoice)
                    {
                        case 1:
                            CurrentPlanet = galaxy.planetsInGalaxy["Argon"];
                            console.Write(CurrentPlanet.Story, textIndent: 3);
                            break;
                        case 2:
                            CurrentPlanet = galaxy.planetsInGalaxy["Plutonius"];
                            console.Write(CurrentPlanet.Story, textIndent: 3);
                            break;
                        case 3:
                            CurrentPlanet = galaxy.planetsInGalaxy["Andromedian"];
                            console.Write(CurrentPlanet.Story, textIndent: 3);
                            break;
                        case 4:
                            CurrentPlanet = galaxy.planetsInGalaxy["Zargos"];
                            console.Write(CurrentPlanet.Story, textIndent: 3);
                            break;
                        case 5:
                            CurrentPlanet = galaxy.planetsInGalaxy["Novius"];
                            console.Write(CurrentPlanet.Story, textIndent: 3);
                            break;
                        default:
                            console.Write(planetChoice.ToString());
                            break;
                    }
                }

                while (currentAction != "p")
                {
                    currentAction = console.GetInput(
                        "Enter\n [Bb] - Buy\n [Ss] - Sell\n [Pp] - Travel to a new planet");
                }

                timesTraveled++;
            }

            // End Game sequence... Need if statement to check if user has won
            console.Write("And thus he left...", pauseText: true, textIndent: 5);

            console.Draw("End_Game");
            // test

        }
    }
}
