using System;

namespace GameOfLife
{
    internal class BoardButton : Button
    {
        private bool alive;
        private readonly byte posX;
        private readonly byte coordY;
        private readonly byte coordX;

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

        public BoardButton(byte ScreenY, byte ScreenX, byte CoordY, byte CoordX, GameOfLifeLogic.GameLogic Logic) : base(ScreenY, false, "  ", null)
        {
            coordX = CoordX;
            coordY = CoordY;
            posX = ScreenX;

            method = () =>  Alive = Logic.FlipValue(coordY, coordX);
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
            Console.Write(buttonText);
        }
    }
}