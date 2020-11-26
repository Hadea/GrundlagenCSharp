using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Button : UIElement
    {
        readonly string buttonText;
        readonly ConsoleColor colorSelected;
        readonly ConsoleColor colorUnSelected;
        readonly ConsoleColor colorActive;
        readonly ConsoleColor colorInactive;
        ConsoleColor currentForeground;
        ConsoleColor currentBackground;
        readonly Action method; // Vorbereiteter Delegate ohne Parameter und ohne Rückgabe

        public override void Draw()
        {
            Console.SetCursorPosition((center ? Console.WindowWidth / 2 - buttonText.Length / 2 - 1 : 2), posY);
            Console.BackgroundColor = currentBackground;
            Console.ForegroundColor = currentForeground;
            Console.Write(" {0} ", buttonText);
        }

        public Button(byte Row, bool Centered, string ButtonText, Action MethodToExecute) : base(Row, Centered)
        {
            buttonText = ButtonText;
            colorSelected = ConsoleColor.Gray;
            colorUnSelected = ConsoleColor.Black;
            colorActive = ConsoleColor.Green;
            colorInactive = ConsoleColor.DarkGray;

            OnStateChanged = StateChanged;

            if (MethodToExecute == null)
            {
                State = ButtonStates.Inactive;
            }
            else
            {
                State = ButtonStates.Available;
                method = MethodToExecute;
            }
        }

        public override void ProcessKey(ConsoleKeyInfo KeyInfo)
        {
            if (KeyInfo.Key == ConsoleKey.Enter)
            {
                if (State is ButtonStates.Available or ButtonStates.Selected && method != null)
                {
                    method();
                }
            }
        }

        void StateChanged()
        {
            switch (State)
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
}
