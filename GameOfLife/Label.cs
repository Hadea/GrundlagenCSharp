using System;
using System.Collections.Generic;

namespace GameOfLife
{
    class Label : IDrawable
    {
        readonly List<string> TextLines;
        byte posY;
        bool center;
        public Label(byte Row, bool Centered, List<string> Text)
        {
            posY = Row;
            center = Centered;
            TextLines = Text;
        }

        public void Draw()
        {
            Console.ResetColor();
            for (int row = 0; row < TextLines.Count; row++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - TextLines[row].Length / 2, 2 + row);
                Console.Write(TextLines[row]);
            }
        }
    }
}
