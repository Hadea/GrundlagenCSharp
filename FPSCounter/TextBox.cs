using System;
using System.Drawing;
using System.Text;

namespace FPSCounter
{
    class TextBox
    {
        private StringBuilder content;
        private readonly Point position;
        private readonly ConsoleColor color;

        public string Content
        {
            get { return content.ToString(); }
        }

        public void Draw()
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.ForegroundColor = color;
            Console.Write(Content);
        }

        public TextBox(Point Position, ConsoleColor TextColor)
        {
            position = Position;
            color = TextColor;
            content = new StringBuilder("Hallo Welt");
        }

        public void ProcessKey(ConsoleKey KeyInformation)
        {
            if (KeyInformation == ConsoleKey.Delete)
            {
                content.Clear();
                Console.SetCursorPosition(position.X, position.Y);
                Console.Write("                                ");
            }
            if ((int)KeyInformation >63 && (int)KeyInformation < 91)
            {
                content.Append(KeyInformation);
            }
        }
    }
}
