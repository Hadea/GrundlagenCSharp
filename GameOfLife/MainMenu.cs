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
            uiElements = new List<UIElement>
            {
                new Button(row, true, "Random Game", () => Program.SceneAdd(new GameScene())),
                new Button(row+=2, true, "Predefined Game", () => Program.SceneAdd(new GameScene())),
                new Button(row+=2, true, "Load Game", () => Program.SceneAdd(new LoadScene(false))),
                new Button(row+=2, true, "Edit Game", () => Program.SceneAdd(new LoadScene(true))),
                new Button(row+=2, true, "Quit Game", () => Program.SceneRemove())
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

            selectedElementID = 0;
        }
        public override void Update()
        {
            // prüfen ob es neue Eingaben vom Nutzer gibt
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedElementID--;
                        break;
                    case ConsoleKey.DownArrow:
                        selectedElementID++;
                        break;
                    case ConsoleKey.Escape:
                        Program.SceneRemove();
                        break;
                    default:
                        uiElements[selectedElementID].ProcessKey(pressedKey);
                        break;
                }
            }
        }

        public override void Activate()
        {
            Console.ResetColor();
            Console.Clear();
            Program.NeedsRedraw.AddRange(uiElements);
            Program.NeedsRedraw.AddRange(labels);
        }
    }
}