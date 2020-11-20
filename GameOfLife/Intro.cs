using System;

namespace GameOfLife
{
    internal class Intro : Scene
    {
        public Intro()
        {
            Console.Clear();
            Console.WriteLine("Hallo, ich bin Game of Life");
        }

        public override void Update()
        {
            if (Console.KeyAvailable)
            {
                Program.Scenes.Pop();
                Program.Scenes.Push(new MainMenu());
            }
        }
    }
}