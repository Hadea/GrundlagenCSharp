using System;

namespace GameOfLife
{
    internal class BoardButton : Button
    {
        private bool alive;
        readonly byte posX;
        byte coordY;
        byte coordX;

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

        public BoardButton(byte ScreenY, byte ScreenX, byte CoordY, byte CoordX, GameLogic Logic) : base(ScreenY, false, "  ", null)
        {
            coordX = CoordX;
            coordY = CoordY;
            posX = ScreenX;

            method = () => { Logic.FlipValue(coordY, coordX);  Program.NeedsRedraw.Add(this); };//HACK: call not working?
        }

        public override void Draw()
        {
            Console.SetCursorPosition(posX, posY);
            if (State == ButtonStates.Selected)
            {
                Console.BackgroundColor = (alive ? ConsoleColor.Blue : ConsoleColor.Red);
            }
            else
            {
                Console.BackgroundColor = (alive ? ConsoleColor.DarkBlue : ConsoleColor.DarkRed);
            }
            Console.Write("  ");
        }

    }
}