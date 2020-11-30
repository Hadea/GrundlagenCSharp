using System;
using System.Collections.Generic;

namespace GameOfLife
{
    abstract class Scene
    {
        protected List<UIElement> uiElements = new List<UIElement>();
        protected short activeButton;

        public short selectedElementID
        {
            get { return activeButton; }
            set
            {
                if (activeButton != value)
                {
                    uiElements[activeButton].State = ButtonStates.Available;
                    Program.NeedsRedraw.Add(uiElements[activeButton]);
                }

                activeButton = value;
                // TODO: replace with search for next active button
                if (activeButton < 0)
                {
                    activeButton = (sbyte)(uiElements.Count - 1);
                }
                else if (activeButton > uiElements.Count - 1)
                {
                    activeButton = 0;
                }

                uiElements[activeButton].State = ButtonStates.Selected;
                Program.NeedsRedraw.Add(uiElements[activeButton]);
            }
        }

        public abstract void Update();

        public abstract void Activate();
    }
}