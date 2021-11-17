using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace SpaceGame
{
    // Class to act ad interface between the game and the Console.
    class Display
    {
        private Images artist = new Images();
        public Display()
        {
            
        }
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
        /** 
         * Method to Draw art in the console
         * Args:
         *  item {string} art piece to draw
         * Returns: 
         *  None
         */
        public void Draw(string item)
        {
            this.artist.Driver(1);
        }
        /** 
         * Method to write output to the console
         * Args:    
         *  text {string} text to write to console
         *  pauseText {bool} determines whether to pause between characters in output
         *  textindent {int} amount of indentation for the text
         * Returns:
         *  None
         */
        public void Write(string text, bool pauseText=false, int textIndent=0)
        {
            // Buffer text to create text indent
            string bufferText = "";
            // Get size of text indent and add to buffer text
            if (textIndent > 0) 
            { foreach (int i in Enumerable.Range(0, textIndent)) { bufferText += " "; }}
            // Append buffer text before the output
            Console.Write(bufferText);
            // Check whether to output text with pauses.
            if (pauseText) {
                // Write out the text pausing between each character
                foreach (char letter in text)
                {
                    Console.Write(letter);
                    Thread.Sleep(250);
                }
            } else
            {
                // Write text in plain old line if no indent
                Console.WriteLine(text);
            }
        }
    }
    
    class Images
    {
        /**
         * Method to get user choice and draw art 
         * Args:
         *  choice {int} number that user selects *Note: will change this to an enum?
         * Returns:
         *  None
         */
        public void Driver(int choice)
        {
            switch(choice) {
                case 1:
                    this.gameLogo();
                    break;
                case 2:
                    this.endGameLogo();
                    break;
            }
        }
        private void gameLogo()
        {
            Console.WriteLine(@"   *     `   /\      *  ` .   ``.");
            Console.WriteLine(@"   `  . /---/||\---\    *  ,     `o");
            Console.WriteLine(@"*  .    \__/----\__/   *    .");
            Console.WriteLine(@"     *      \/\/     `  ,  O  *");
            Console.WriteLine(@"  O     .   #  #  `  .   '   . ");
            Console.WriteLine(@"  `    *    #  #    .   ,   `  ");
            Console.WriteLine(@"   `        #  #      ,   `  ");
        }
        private void endGameLogo()
        {
            Console.WriteLine(@"   *     `        x `    .   ``.");
            Console.WriteLine(@"   `  . \|/   ` _/|\_    `o");
            Console.WriteLine(@"*  .   --O--   (_| |_)   ");
            Console.WriteLine(@"     *  /|\      V-V     ,  O  *");
            Console.WriteLine(@"  O     .   `    # #     . ");
            Console.WriteLine(@"  `    *    .   #, #`     ");
            Console.WriteLine(@"   `     *     #   #   `  ");
        }
    }
}