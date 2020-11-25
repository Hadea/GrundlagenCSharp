using System;
using System.Collections.Generic;

namespace GameOfLife
{
    abstract class Scene
    {
        protected List<Button> buttons;
        protected sbyte activeButton;

        public sbyte ActiveButtonID
        {
            get { return activeButton; }
            set
            {
                if (activeButton != value)
                {
                    buttons[activeButton].State = ButtonStates.Available;
                    Program.NeedsRedraw.Add(buttons[activeButton]);
                }

                activeButton = value;
                // TODO: replace with search for next active button
                if (activeButton < 0)
                {
                    activeButton = (sbyte)(buttons.Count - 1);
                }
                else if (activeButton == buttons.Count)
                {
                    activeButton = 0;
                }

                buttons[activeButton].State = ButtonStates.Selected;
                Program.NeedsRedraw.Add(buttons[activeButton]);
            }
        }

        public abstract void Update();

        public abstract void Activate();
    }
}