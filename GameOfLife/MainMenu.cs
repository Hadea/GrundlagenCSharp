using System;
using System.Collections.Generic;
using System.IO;

namespace GameOfLife
{
    internal class MainMenu : Scene
    {
        readonly List<Label> labels;

        public MainMenu()
        {
            byte row = 12;
            buttons = new List<Button>
            {
                new (row, true, "Random Game", () => Program.SceneAdd(new GameScene())),
                new (row+=2, true, "Predefined Game", () => Program.SceneAdd(new GameScene())),
                new (row+=2, true, "Load Game", () => Program.SceneAdd(new LoadScene())),
                new (row+=2, true, "Quit Game", () => Program.SceneRemove())
            };

            labels = new();
            using (StreamReader reader = new("LogoSmall.txt"))
            {
                List<string> logoLines = new();
                string newLine;
                while ((newLine = reader.ReadLine()) != null)
                {
                    logoLines.Add(newLine);
                }
                labels.Add(new Label(1, true, logoLines));
            }

            ActiveButtonID = 0;
        }
        public override void Update()
        {
            // prüfen ob es neue Eingaben vom Nutzer gibt
            if (Console.KeyAvailable)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        ActiveButtonID--;
                        break;
                    case ConsoleKey.DownArrow:
                        ActiveButtonID++;
                        break;
                    case ConsoleKey.Escape:
                        Program.SceneRemove();
                        break;
                    case ConsoleKey.Enter:
                        buttons[ActiveButtonID].Execute();
                        // Todo: switch for buttonID to react to user choice or delegate!
                        break;
                }
            }
        }

        public override void Activate()
        {
            Console.ResetColor();
            Console.Clear();
            Program.NeedsRedraw.AddRange(buttons);
            Program.NeedsRedraw.AddRange(labels);
        }
    }
}