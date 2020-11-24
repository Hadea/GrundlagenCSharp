using System;
using System.Collections.Generic;
using System.IO;

namespace GameOfLife
{
    class Intro : Scene
    {
        readonly List<string> logoLines;
        bool needsRedraw;
        public Intro()
        {
            logoLines = new();
            using (StreamReader reader = new("LogoBig.txt"))
            {
                string newLine;
                while ( (newLine = reader.ReadLine()) != null)
                {
                    logoLines.Add(newLine);
                }
            }
        }

        public override void Activate()
        {
            Console.Clear();
            needsRedraw = true;
        }

        public override void Update()
        {
            if (needsRedraw)
            {
                int row = 0;
                for (; row < logoLines.Count; row++)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - logoLines[row].Length / 2, 2 + row);
                    Console.Write(logoLines[row]);
                }

                string anyKey = "< press any key >";
                row += 2;
                Console.SetCursorPosition(Console.WindowWidth / 2 - anyKey.Length / 2, 2 + row);
                Console.Write(anyKey);

                needsRedraw = false;
            }

            if (Console.KeyAvailable) // prüft nur ob eine taste gerade unten ist, diese wird nicht aus liste der gedrückten tasten entfernt.
            {
                Console.ReadKey(true); // ohne readkey bleibt die gedrückte taste erhalten und das Hauptmneü reagiert bereits darauf.
                Program.SceneRemove();
                Program.SceneAdd(new MainMenu());
            }
        }
    }
}