using System;

namespace GameOfLife
{
    abstract class UIElement : IDrawable
    {
        protected byte posY;
        protected bool center;
        protected Action OnStateChanged;


        private ButtonStates states;

        public ButtonStates State
        {
            get { return states; }
            set
            {
                states = value;
                OnStateChanged();
            }
        }

        public UIElement(byte Row, bool Centered)
        {
            posY = Row;
            center = Centered;
        }

        public virtual void ProcessKey(ConsoleKeyInfo KeyInfo)
        { }

        public abstract void Draw();
    }
}
