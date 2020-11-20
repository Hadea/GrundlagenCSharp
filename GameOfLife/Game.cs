using System;
namespace GameOfLife
{
    internal class Game : Scene
    {
        readonly GameLogic logic;
        public Game()
        {
            Console.ResetColor();
            Console.Clear();
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
                    Console.Write("{0}", (arrayToDraw[Y, X] ? "O": "_") ) ;
                }
                Console.WriteLine();
            }

            if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                Program.Scenes.Pop();
            }
        }
    }
}