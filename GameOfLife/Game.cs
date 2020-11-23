using System;
namespace GameOfLife
{
    internal class Game : Scene
    {
        readonly GameLogic logic;
        DateTime lastLogicUpdate;

        public Game()
        {
            Console.ResetColor();
            Console.Clear();
            lastLogicUpdate = DateTime.Now;
            logic = new();
        }
        public override void Update()
        {
            Console.SetCursorPosition(0, 0);
            bool[,] arrayToDraw = logic.Field;

            for (int Y = 0; Y < arrayToDraw.GetLength(0); Y++)
            {
                for (int X = 0; X < arrayToDraw.GetLength(1); X++)
                {
                    Console.Write("{0}", (arrayToDraw[Y,X] ? "O" : "_"));
                }
                Console.WriteLine();
            }

            if (Console.KeyAvailable)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Escape:
                        Program.Scenes.Pop();
                        return;
                    case ConsoleKey.S: // spiel speichern
                        logic.SaveGame("GameA.xml");
                        break;
                }

            }

            if ((DateTime.Now - lastLogicUpdate).TotalMilliseconds > 500)
            {
                lastLogicUpdate = DateTime.Now;
                logic.Update();
            }
        }
    }
}