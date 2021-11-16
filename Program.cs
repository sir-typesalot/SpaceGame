using System;

namespace SpaceGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Display console = new Display();
            console.Write("Welcome to the Game", pauseText:true, tabText:true);
            string _startChoice = console.GetInput("Press [Yy] - Start\n[Nn] - Exit\n[Hh] - Help");
            console.Write(_startChoice);
        }
    }
}
