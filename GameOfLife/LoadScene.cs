using System;
using System.Collections.Generic;
using System.IO;

namespace GameOfLife
{
    class LoadScene : Scene
    {
        //GameScene preview; //TODO load file for preview, just constructor, no update or activate
        private readonly bool editMode;

        public LoadScene(bool LoadForEdit)
        {
            editMode = LoadForEdit;
            List<string> fileNames = new();
            fileNames.AddRange(Directory.GetFiles(@".\", "*.xml"));
            fileNames.AddRange(Directory.GetFiles(@".\", "*.gol"));

            byte row = 4;
            uiElements = new List<UIElement>();

            foreach (var item in fileNames)
            {
                uiElements.Add(new Button(row += 2, false, item.Substring(2, item.Length - 2), () => startLevel(item)));
            }

            uiElements.Add(new Button(row += 2, false, "Back", () => Program.SceneRemove()));
        }

        public override void Activate()
        {
            Console.ResetColor();
            Console.Clear();
            Program.NeedsRedraw.AddRange(uiElements);
        }

        public override void Update()
        {
            if (Console.KeyAvailable)
            {
                var pressedKey = Console.ReadKey(true);
                switch (pressedKey.Key)
                {
                    case ConsoleKey.Escape:
                        Program.SceneRemove();
                        break;
                    case ConsoleKey.UpArrow:
                        selectedElementID--;
                        break;
                    case ConsoleKey.DownArrow:
                        selectedElementID++;
                        break;
                    default:
                        uiElements[selectedElementID].ProcessKey(pressedKey);
                        break;
                }
            }

        }
        private void startLevel(string FileName)
        {
            Program.SceneRemove();
            if (editMode)
            {
                Program.SceneAdd(new EditorScene(FileName));
            }
            else
            {
                Program.SceneAdd(new GameScene(FileName));
            }
        }
    }
}