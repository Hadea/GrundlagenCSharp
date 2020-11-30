using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Button : UIElement
    {
        protected readonly string buttonText;
        protected readonly ConsoleColor colorSelected;
        protected readonly ConsoleColor colorUnSelected;
        protected readonly ConsoleColor colorActive;
        protected readonly ConsoleColor colorInactive;
        protected ConsoleColor currentForeground;
        protected ConsoleColor currentBackground;
        protected Action method; // Vorbereiteter Delegate ohne Parameter und ohne Rückgabe

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

            OnStateChanged = stateChanged;

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

        void stateChanged()
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
