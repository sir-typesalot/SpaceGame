using System;
using System.Collections.Generic;

namespace SpaceGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Display console = new Display();
            Galaxy galaxy = new Galaxy();
            Utils tools = new Utils();

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
                    console.Write("Press X/x at any time to quit the game...");
                }
            }

            string playerName = console.GetInput("Enter a name for your player: ");
            Player newPlayer = new Player(playerName);

            // Story Intro
            // Should probably migrate this to a file?
            console.Write("\nIn a galaxy far away, on the planet of Argon, a meteorite-iron trader "+ playerName + "\n" +
                "miscalculated their spacecraft’s entry to the planet’s belt and is now left with a wrecked"+
                " ship.\nA ship is not that hard to recover from, if only it hadn’t been owned by the " +
                "galaxy’s most feared\nship lender - Xabat. " + playerName + " knew they were in trouble. It was only" +
                " a matter of time before Xabat\nheard of the news, 1 galactic day exactly. Once he did," +
                " there was no escape. No place was safe\nfrom Xabat, for he had contacts and bounty" +
                "hunters throughout the galaxy, on every planet, on\nevery outpost. A rumor was " +
                "circulating that there was one thing that Xabat liked more than his\nships, supernova" +
                " crystals, crystals that are found in the debris of an exploded star. "+ playerName + "\nheard of " +
                "these at one of the outposts on Argon’s moons. Apparently there was a dealer that could" +
                "\nprocure some, but only to the highest bidders. Whatever the cost, "+ playerName + " knew they had" +
                " no\noption, for their life was dependent on these crystals and they would have to do " +
                "whatever it takes to\nget them, before it’s too late...\n");

            // Should we create a property in the Galaxy Class to handle this? - What do you guys think?
            int timesTraveled = 0;
            Planet CurrentPlanet = galaxy.planetsInGalaxy["Argon"];
            int planetChoice = 1;
            //Loop to limit how many planets player can travel to.
            while (timesTraveled <= 9)
            {
                
                string currentAction = "1";
                int userChoice = 1;

                if (timesTraveled == 0)
                {
                    string story = CurrentPlanet.Story;
                    
                    CurrentPlanet.CheckCrystalMan();
                    galaxy.CurrentPlanet = CurrentPlanet.Name;

                    console.Write("Current planet : " + CurrentPlanet.Name);

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
                            console.Write("\nCurrent planet : " + CurrentPlanet.Name);
                            console.Write(CurrentPlanet.Story, textIndent: 3);
                            break;
                        case 2:
                            CurrentPlanet = galaxy.planetsInGalaxy["Plutonius"];
                            console.Write("\nCurrent planet : " + CurrentPlanet.Name);
                            console.Write(CurrentPlanet.Story, textIndent: 3);
                            break;
                        case 3:
                            CurrentPlanet = galaxy.planetsInGalaxy["Andromedian"];
                            console.Write("\nCurrent planet : " + CurrentPlanet.Name);
                            console.Write(CurrentPlanet.Story, textIndent: 3);
                            break;
                        case 4:
                            CurrentPlanet = galaxy.planetsInGalaxy["Zargos"];
                            console.Write("\nCurrent planet : " + CurrentPlanet.Name);
                            console.Write(CurrentPlanet.Story, textIndent: 3);
                            break;
                        case 5:
                            CurrentPlanet = galaxy.planetsInGalaxy["Novius"];
                            console.Write("\nCurrent planet : " + CurrentPlanet.Name);
                            console.Write(CurrentPlanet.Story, textIndent: 3);
                            break;
                        default:
                            console.Write(planetChoice.ToString());
                            break;
                    }
                }
                
                while (currentAction != "p")
                {
                    currentAction = console.GetInput("Enter\n [Bb] - Buy\n [Ss] - Sell\n [Pp] - Travel to a new planet");
                    if (currentAction.ToLower() == "b")
                    {
                        int total;
                        int amount;
                        string currentAmount;
                        int price;
                        string currentPrice;
                        string currentItem;
                        do
                        {
                            total = 0;
                            amount = 0;
                            currentAmount = "";
                            price = 0;
                            currentPrice = "";
                            currentItem = "";
                            // Call util method to read file. set getItems to true to read from items.xml
                            List<Dictionary<string, string>> itemsList = tools.ReadPlanetXMLFile("Planet", getItems: true);
                            // Need logic to interact with planet and trader on planet
                            console.Write("\nEnter the name of the item you would like to buy. \nYou can't spend more money than you have. \nYou have " + newPlayer.money + " units.\n");
                            // ItemsList[0] -> Argon
                            foreach (var item in itemsList[userChoice - 1])
                            {
                                console.Write(item.Key + "\t\t" + item.Value);
                            }

                            //currentItem = console.Write(item);
                            currentItem = "Durasteel"; // Temporary fix to the error in the above line

                            if (itemsList[userChoice - 1].TryGetValue(currentItem, out currentPrice))
                            {
                                Console.Write("\nYou have selected " + currentItem + ", it costs " + currentPrice + " units per item.\nYou have " + newPlayer.money + " units.\n");
                                currentAmount = console.GetInput("How much would you like to buy?");

                                Int32.TryParse(currentPrice, out price);
                                Int32.TryParse(currentAmount, out amount);
                                total = price * amount;
                            }
                            else
                            {
                                Console.Write("The item you typed is not found.\n");
                            }

                        }
                        while (newPlayer.money < total);

                        newPlayer.money = newPlayer.money - total;
                        newPlayer.Inventory.Add(currentItem);
                        newPlayer.Amount.Add(amount);
                        console.Write("\nYou purchased " + amount + " " + currentItem + " at " + price + " for a total of " + total + " units. \nYou now have " + newPlayer.money + " units.\n");
                    }
                    else if (currentAction.ToLower() == "s")
                    {
                        if (newPlayer.Inventory != null && newPlayer.Inventory.Count > 0)
                        {
                            console.Write("Which item(s) do you want to sell?", textIndent:5);
                            for (int i=1; i < newPlayer.Inventory.Count; i++)
                            {
                                console.Write($"{i} - {newPlayer.Inventory[i]}");
                            }





                        } 
                        else
                        {
                            console.Write("You don't have aything to sell! Try getting some items..");
                        }

                    } 
                    else if (currentAction.ToLower() == "x")
                    {
                        // We can implement logic that will confirm if the user wants to quit
                        // This should do for now though
                        console.Write("Thank you for playing!", textIndent: 5);
                        Environment.Exit(0);
                    } 
                    else
                    {
                        console.Write("Input not understood, please try again or press [X/x] to Quit", textIndent: 5);
                    }
                }
                timesTraveled++;
            }
            
            //End game scenarios based off money and random num
            if (true)
            {

            }
            else if (true)
            {

            }
            else if (true)
            {

            }
            else
            {

            }



            // End Game sequence... Need if statement to check if user has won
            console.Write("And thus he left...", pauseText: true, textIndent: 5);

            console.Draw("End_Game");
            // test

        }
    }
}
