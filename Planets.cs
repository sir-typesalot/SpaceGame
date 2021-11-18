using System;
using System.Collections.Generic;

namespace SpaceGame
{
    class Planet
    {
        /** 
         * Constructor for Planet class
         * Params:
         *  name {string} name of planet
         *  story {string} story of planet - short dialog
         * Returns: 
         *  None
         */
        public Planet(string name="Template", string story="Template")
        {
            this.Name = name;
            this.Story = story;
        }
        // Method to randomly check if Crystal Man can appear
        public void CheckCrystalMan()
        {
            int rng = _random.Next(0, 1);
            this.HasCrystalMan = rng == 1 ? true: false ;
        }
        // Story Property to get and set story
        public string Story { get; set; }
        // Property to check whether planet has Crystal man
        public bool HasCrystalMan { get; set; }
        // Name Property for the planet
        public string Name { get; set; }
        // List of the products and prices for the planet
        // Need to figure out how to implement it for each planet - enums, maybe?
        public List<string> productList = new List<string>();
        // Climate property for planet object
        // Not sure if this is needed, might remove later,
        // Just thought it may be useful for the product list
        public string Climate { get; set; }
        // Heavily considering removing this
        private int timeOnPlanet;
        // Random Number Generator instance
        private readonly Random _random = new Random();
    }

    // Class that makes up the galaxy for the current Game
    class Galaxy
    {
        /**
         * Constructor for the Galaxy class
         * Params:
         *  names {string[]} list of names
         *  story {string[]} list of planet stories
         *  numOfPlanets {int} number of planets for the Galaxy
         */
        public Galaxy(string[] names, string[] story, int numOfPlanets = 1)
        {
            // Check that both lists and num of planets match
            if (names.Length != story.Length && names.Length != numOfPlanets) 
                throw new Exception("Array Mismatch");
            // Createnew planets with names and stories. Add to the list of Planets
            for (int i=0; i < numOfPlanets; i++)
            {
                this.planetsInGalaxy.Add(new Planet(names[i], story[i]));
            }
        }
        // List of planets in the Galaxy
        public List<Planet> planetsInGalaxy = new List<Planet>();
        // Property to show which planet the player is on currently
        public string CurrentPlanet { get; set; }
    }
}
