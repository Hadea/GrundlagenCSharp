using System;

namespace GameOfLife
{
    internal class MainMenu : Scene
    {
        public MainMenu()
        {
            Console.ResetColor();
            Console.Clear();
            Console.WriteLine("Willkommen im Hauptmenue");
        }
        public override void Update()
        {
            if (Console.KeyAvailable)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Escape:
                        Program.Scenes.Pop();
                        break;
                    case ConsoleKey.Enter:
                        Program.Scenes.Push(new Game());
                        break;
                    default:
                        break;
                }
            }
        }
    }
}