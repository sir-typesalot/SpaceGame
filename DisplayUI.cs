using System;
using System.Threading;
using System.Collections.Generic;

namespace SpaceGame
{
    // Class to act ad interface between the game and the Console.
    class Display
    {
        // May not need this
        private List<string> imageList = new List<string> { };
        /** 
         * Method to get intput from user
         * Args:
         *  inputText {string} text to prompt user for input
         * Returns:
         *  userInput {string} user input
         */
        public string GetInput(string inputText)
        {
            Console.WriteLine("\n" + inputText);
            string userInput = Console.ReadLine();
            return userInput;
        }
        public void Draw(string item)
        {
            
        }
        /** 
         * Method to write output to the console
         * Args:    
         *  text {string} text to write to console
         *  pauseText {bool} determines whether to pause between characters in output
         *  tabText {bool} determines whether to tab the start of the output
         * Returns:
         *  None
         */
        public void Write(string text, bool pauseText=false, bool tabText=false)
        {
            // Buffer text
            string bufferText = tabText ? "\t" : "";
            // Append buffer text before the output
            Console.Write(bufferText);
            if (pauseText) {
                foreach (char letter in text)
                {
                    Console.Write(letter);
                    Thread.Sleep(250);
                }
            } else
            {
                Console.WriteLine(text);
            }
        }
    }
    // Not sure if this class will be needed
    class Images
    {
        public void drawPlanet()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
        }
    }
}