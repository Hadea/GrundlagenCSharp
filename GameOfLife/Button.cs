using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Button : IDrawable
    {
        readonly string buttonText;
        readonly byte posY;
        readonly ConsoleColor colorSelected;
        readonly ConsoleColor colorUnSelected;
        readonly ConsoleColor colorActive;
        readonly ConsoleColor colorInactive;
        ConsoleColor currentForeground;
        ConsoleColor currentBackground;
        readonly bool center;

        private ButtonStates states;

        public ButtonStates State
        {
            get { return states; }
            set
            {
                states = value;
                switch (states)
                {
                    case ButtonStates.Selected:
                        currentBackground = colorSelected;
                        currentForeground = colorActive;
                        break;
                    case ButtonStates.Available:
                        currentBackground = colorUnSelected;
                        currentForeground = colorActive;
                        break;
                    case ButtonStates.Inactive:
                        currentBackground = colorUnSelected;
                        currentForeground = colorInactive;
                        break;
                }
            }
        }

        public void Draw()
        {
            Console.SetCursorPosition((center? Console.WindowWidth / 2 - buttonText.Length / 2 - 1: 2), posY);
            Console.BackgroundColor = currentBackground;
            Console.ForegroundColor = currentForeground;
            Console.Write(" {0} ",buttonText);
        }

        public Button(byte Row, bool Centered, string ButtonText)
        {
            posY = Row;
            buttonText = ButtonText;
            colorSelected = ConsoleColor.Gray;
            colorUnSelected = ConsoleColor.Black;
            colorActive = ConsoleColor.Green;
            colorInactive = ConsoleColor.DarkGray;
            center = Centered;
            State = ButtonStates.Available;
        }
    }
}
