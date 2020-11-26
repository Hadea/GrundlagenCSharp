using System;

namespace GameOfLife
{
    internal class IngameMenu : Scene
    {
        GameLogic logic;
        public IngameMenu(GameLogic Logic)
        {
            logic = Logic;
            uiElements = new()
            {
                new Button(10, true, "Save Game", null),
                new TextBox(12, true, "Irgendwas"),
                new Button(14, true, "Back to Main Menu", () => { Program.SceneRemove(); Program.SceneRemove(); }),
                new Button(16, true, "Quit to Desktop", () => { Program.SceneRemove(); Program.SceneRemove(); Program.SceneRemove(); })
            };
            selectedElementID = 0;
        }

        public override void Activate()
        {
            Program.NeedsRedraw.AddRange(uiElements);
        }

        public override void Update()
        {
            if (Console.KeyAvailable)
            {
                var pressedKey = Console.ReadKey(true);
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
    }
}