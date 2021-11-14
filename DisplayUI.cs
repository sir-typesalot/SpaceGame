using System;
using System.Collections.Generic;

namespace SpaceGame
{
    class Display
    {
        private List<string> imageList = new List<string> { };
        public string GetInput()
        {
            return "";
        }
        public void Draw()
        {

        }
        public void Write(string text)
        {
            Console.Write(text);
        }
    }
}