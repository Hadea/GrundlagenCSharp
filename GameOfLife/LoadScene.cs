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

            var fileNames = GameOfLifeLogic.GameLogic.GetAvailableGames();

            byte row = 4;
            uiElements = new List<UIElement>();

            foreach (var item in fileNames)
            {
                if (item.FromDatabase)
                {
                    uiElements.Add(new Button(row += 2, false, "DB " + item.Name, () => startLevel(item.Name)));
                }
                else
                {
                    uiElements.Add(new Button(row += 2, false, "FL " + item.Name.Substring(2, item.Name.Length - 2 - 4), () => startLevel(item.Name)));
                }
            }

            uiElements.Add(new Button(row += 2, false, "Back", () => Program.SceneRemove()));
            selectedElementID = 0;
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