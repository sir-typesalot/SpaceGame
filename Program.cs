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

            bool CrystalManFound = false;
            bool hasEnoughMoney = false;
            string spawnManDialog = "";

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
            console.Write("\n\tIn a galaxy far away, on the planet of Argon, a meteorite-iron trader "+ playerName + "\n\t" +
                "miscalculated their spacecraft’s entry to the planet’s belt and is now left with a wrecked"+
                " ship.\n\tA ship is not that hard to recover from, if only it hadn’t been owned by the " +
                "galaxy’s most feared\n\tship lender - Xabat. " + playerName + " knew they were in trouble. It was only" +
                " a matter of time before Xabat\n\theard of the news, 1 galactic day exactly. Once he did," +
                " there was no escape. No place was safe\n\tfrom Xabat, for he had contacts and bounty" +
                "hunters throughout the galaxy, on every planet, on\n\tevery outpost. A rumor was " +
                "circulating that there was one thing that Xabat liked more than his\n\tships, supernova" +
                " crystals, crystals that are found in the debris of an exploded star. "+ playerName + "\n\theard of " +
                "these at one of the outposts on Argon’s moons. Apparently there was a dealer that could" +
                "\n\tprocure some, but only to the highest bidders. Whatever the cost, "+ playerName + " knew they had" +
                " no\n\toption, for their life was dependent on these crystals and they would have to do " +
                "whatever it takes to\n\tget them, before it’s too late...\n");

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

                    console.Write("\tCurrent planet : " + CurrentPlanet.Name);

                    console.Write(story, textIndent: 3);
                } 
                else
                {
                    //Pick a planet to travel to.
                    console.Write("\tPick a planet to travel to");
                    string planetRoster = "";
                    int planetNum = 1;
                    foreach (string planetName in galaxy.planetsInGalaxy.Keys)
                    {
                        string planet = $"\n\t {planetNum} - {planetName}";
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
                            console.Write("\n\tCurrent planet : " + CurrentPlanet.Name);
                            console.Write(CurrentPlanet.Story, textIndent: 3);
                            break;
                        case 2:
                            CurrentPlanet = galaxy.planetsInGalaxy["Plutonius"];
                            console.Write("\n\tCurrent planet : " + CurrentPlanet.Name);
                            console.Write(CurrentPlanet.Story, textIndent: 3);
                            break;
                        case 3:
                            CurrentPlanet = galaxy.planetsInGalaxy["Andromedian"];
                            console.Write("\n\tCurrent planet : " + CurrentPlanet.Name);
                            console.Write(CurrentPlanet.Story, textIndent: 3);
                            break;
                        case 4:
                            CurrentPlanet = galaxy.planetsInGalaxy["Zargos"];
                            console.Write("\n\tCurrent planet : " + CurrentPlanet.Name);
                            console.Write(CurrentPlanet.Story, textIndent: 3);
                            break;
                        case 5:
                            CurrentPlanet = galaxy.planetsInGalaxy["Novius"];
                            console.Write("\n\tCurrent planet : " + CurrentPlanet.Name);
                            console.Write(CurrentPlanet.Story, textIndent: 3);
                            timesTraveled = 10;
                            break;
                        default:
                            console.Write(planetChoice.ToString());
                            break;
                    }
                    if (timesTraveled == 10)
                    {
                        break;
                    } else
                    {
                        CurrentPlanet.CheckCrystalMan();
                        CrystalManFound = CurrentPlanet.HasCrystalMan;
                        spawnManDialog = CrystalManFound ? "\tYou hear a faint whisper, something about a crystal" : "The market is busy";
                        hasEnoughMoney = newPlayer.money > 4000 ? true : false;
                        
                    }  
                }
          
                while (currentAction != "p")
                {
                    if (!CrystalManFound && !hasEnoughMoney)
                    {
                        currentAction = console.GetInput("Enter\n [Bb] - Buy\n [Ss] - Sell\n [Pp] - Travel to a new planet");
                        if (currentAction.ToLower() == "b")
                        {
                            int bTotal;
                            int amount;
                            string currentAmount;
                            int price;
                            string currentPrice;
                            string currentItem;
                            do
                            {
                                bTotal = 0;
                                amount = 0;
                                currentAmount = "";
                                price = 0;
                                currentPrice = "";
                                currentItem = "";
                                // Call util method to read file. set getItems to true to read from items.xml
                                List<Dictionary<string, string>> itemsList = tools.ReadPlanetXMLFile("Planet", getItems: true);

                                console.Write("\n Enter the name of the item you would like to buy. or x to exit\n You can't spend more money than you have. \n You have " + newPlayer.money + " units.\n");
                                // ItemsList[0] -> Argon
                                foreach (var item in itemsList[userChoice - 1])
                                {
                                    console.Write(item.Key + "\t\t" + item.Value);
                                }

                                currentItem = console.GetInput("Item: ");

                                if (itemsList[userChoice - 1].TryGetValue(currentItem, out currentPrice))
                                {
                                    Console.Write("\nYou have selected " + currentItem + ", it costs " + currentPrice + " units per item.\nYou have " + newPlayer.money + " units.\n");
                                    currentAmount = console.GetInput("How much would you like to buy?");

                                    Int32.TryParse(currentPrice, out price);
                                    Int32.TryParse(currentAmount, out amount);
                                    bTotal = price * amount;
                                    newPlayer.money -= bTotal;
                                    newPlayer.Inventory.Add(currentItem);
                                    newPlayer.Amount.Add(amount);
                                    console.Write("\nYou purchased " + amount + " " + currentItem + " at " + price + " for a total of " + bTotal + " units. \nYou now have " + newPlayer.money + " units.\n");
                                } else if(currentItem == "x") {
                                    break;
                                }
                                else Console.Write("\tThe item you typed is not found.\n");
                            }
                            while (newPlayer.money < bTotal);
                        }
                        else if (currentAction.ToLower() == "s")
                        {
                            string sellStr = "";
                            string sellPrice = "";
                            int price = 0;
                            int sTotal = 0;
                            if (newPlayer.Inventory != null && newPlayer.Inventory.Count > 0)
                            {
                                console.Write("\tWhich item(s) do you want to sell?", textIndent: 5);
                                for (int i = 0; i < newPlayer.Inventory.Count; i++)
                                {
                                    console.Write($"{i} - {newPlayer.Inventory[i]}");
                                }

                                sellStr = console.GetInput("Item Number: ");

                                Int32.TryParse(sellStr, out int sellIndex);

                                console.Write("You have " + newPlayer.Amount[sellIndex] + " " + newPlayer.Inventory[sellIndex]);

                                string amountSell = console.GetInput("How much would you like to sell?");
                                Int32.TryParse(amountSell, out int sellInt);

                                // Call util method to read file. set getItems to true to read from items.xml
                                List<Dictionary<string, string>> itemsList = tools.ReadPlanetXMLFile("Planet", getItems: true);

                                // Getting price of item
                                itemsList[userChoice - 1].TryGetValue(newPlayer.Inventory[sellIndex], out sellPrice);
                                Int32.TryParse(sellPrice, out price);
                                sTotal = price * sellInt;
                                if (sellInt == newPlayer.Amount[sellIndex])
                                {
                                    newPlayer.Inventory.RemoveAt(sellIndex);
                                    newPlayer.Amount.RemoveAt(sellIndex);

                                    newPlayer.money += sTotal;

                                    console.Write("You now have " + newPlayer.money + " units.\n");
                                }
                                else if (sellInt < newPlayer.Amount[sellIndex])
                                {
                                    newPlayer.Amount[sellIndex] -= sellInt;
                                    newPlayer.money += sTotal;

                                    console.Write("You now have " + newPlayer.money + " units.\n");
                                }
                                else console.Write("Please select a valid amount to sell");
                            }
                            else console.Write("You don't have anything to sell! Try getting some items..");
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
                    } else
                    {
                        console.Write(spawnManDialog);
                        console.Write("\tYou are led down a dimly lit alley way and are met with a dwarf-sized merchant");
                        console.Write("\t'I presume you are looking for the crystal' he says");
                        console.Write("\tHe looks at your purse and nods - 'That will do' he says");
                        string userchoice = console.GetInput("Press [B/b] to buy the crystal");
                        if (userchoice.ToLower() == "b")
                        {
                            int bTotal = 4000 * 1;
                            newPlayer.money -= bTotal;
                            newPlayer.Inventory.Add("Crystal");
                            newPlayer.Amount.Add(1);
                            console.Write("\nYou purchased " + 1 + " Crystal at " + 4000 + " for a total of " + bTotal + " units. \nYou now have " + newPlayer.money + " units.\n");
                            newPlayer.hasCrystal = true;
                        }
                        timesTraveled = 10;
                        break;

                    }
                    
                }
                timesTraveled++;
            }

            //End game scenarios based off money and random num  && notEnoughMoney
            if (timesTraveled >= 9 && newPlayer.hasCrystal == false)
            {
                console.Write("ALERT! ALERT! Xabat's spies have found you! There is nowhere for you to hide....", textIndent:10);
                console.Write("You lost. You didn't give the crystals to Xabat in time!", pauseText:true, textIndent:10);
            }
            else if (newPlayer.hasCrystal)
            {
                console.Write("\tYou are arrested and brought before Xabat...", pauseText:true);
                console.Write("\n\tJust as the final judgement is about to be given, you raise your hand.");
                console.Write("\n\tXabat sees the crystal and the crowd gasps. He orders to release you");
                console.Write("\n\tYou just escaped death, thanks to that crystal");
                console.Write("You have won!", pauseText:true, textIndent:5);
            }
            // End Game sequence... Need if statement to check if user has won
            console.Write("And thus it ends...", pauseText: true, textIndent: 5);

            console.Draw("End_Game");
            console.GetInput("Press any key to exit");
            Environment.Exit(0);
        }
    }
}
