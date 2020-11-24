using System;

namespace GameOfLife
{
    class BoardLabel : IDrawable
    {
        readonly int Y;
        readonly int X;
        public BoardLabel(int Row, int Col)
        {
            Y = Row;
            X = Col;
        }

        private bool alive;

        public bool Alive
        {
            get { return alive; }
            set
            {
                if (alive != value)
                {
                    alive = value;
                    Program.NeedsRedraw.Add(this);
                }
            }
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.BackgroundColor = (alive ? ConsoleColor.DarkBlue : ConsoleColor.DarkRed);
            Console.Write("  ");
        }
    }
}