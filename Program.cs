using System;

namespace SpaceGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Display console = new Display();
            console.Draw("Start_Game");
            console.Write("Welcome to the Game", pauseText:true, textIndent:5);
            string _startChoice = console.GetInput("Press [Yy] - Start\n[Nn] - Exit\n[Hh] - Help");
            console.Write("And thus he left...", pauseText: true, textIndent: 5);
            console.Draw("End_Game");

        }
    }
}
