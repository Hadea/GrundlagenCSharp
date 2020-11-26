using System;
using System.Drawing;
using System.Text;

namespace GameOfLife
{
    class TextBox : UIElement
    {
        private char[] content;
        private readonly ConsoleColor color;
        private byte cursorPosition;

        public string Text
        {
            get { return content.ToString(); }
        }


        public TextBox(byte Row, bool Centered, string Text = "") : base(Row, Centered)
        {
            content = new char[15];
            byte count = 0;
            for (; count < Text.Length && count < content.Length; count++)
            {
                content[count] = Text[count];
            }
            cursorPosition = count;
            for (; count < content.Length; count++)
            {
                content[count] = ' ';
            }

            color = ConsoleColor.White;

            OnStateChanged = () => { };
        }

        public override void Draw()
        {
            Console.SetCursorPosition((center ? Console.WindowWidth / 2 - content.Length / 2 - 1 : 2), posY);
            Console.ForegroundColor = color;
            for (int counter = 0; counter < content.Length; counter++)
            {
                Console.BackgroundColor = (counter != cursorPosition? ConsoleColor.Black: ConsoleColor.DarkBlue);
                Console.Write(content[counter]);
            }
        }

        public override void ProcessKey(ConsoleKeyInfo KeyInformation)
        {
            switch (KeyInformation.Key)
            {
                case ConsoleKey.Delete:
                    Array.Fill(content, ' ');
                    Program.NeedsRedraw.Add(this);
                    break;
                case ConsoleKey.Backspace:
                    content[cursorPosition--] = ' ';
                    Program.NeedsRedraw.Add(this);
                    break;
                case ConsoleKey.LeftArrow:
                    if (cursorPosition > 0)
                    {
                        cursorPosition--;
                    }
                    Program.NeedsRedraw.Add(this);
                    break;
                case ConsoleKey.RightArrow:
                    if (cursorPosition < content.Length - 1)
                    {
                        cursorPosition++;
                    }
                    Program.NeedsRedraw.Add(this);
                    break;
                default:
                    if (KeyInformation.KeyChar is >= 'A' and <= 'Z' ||
                        KeyInformation.KeyChar is >= 'a' and <= 'z' ||
                        KeyInformation.KeyChar is >= '0' and <= '9')
                    {
                        content[cursorPosition++] = KeyInformation.KeyChar;
                        Program.NeedsRedraw.Add(this);
                    }
                    break;
            }
        }
    }
}
