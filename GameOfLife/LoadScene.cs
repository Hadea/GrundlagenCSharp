using System;
using System.Collections.Generic;
using System.IO;

namespace GameOfLife
{
    class LoadScene : Scene
    {
        GameScene preview; //TODO load file for preview, just constructor, no update or activate
        public LoadScene()
        {
            string[] fileNames = Directory.GetFiles(@".\", "*.xml");
            byte row = 4;
            buttons = new List<Button>();

            foreach (var item in fileNames)
            {
                buttons.Add(new Button(row += 2, false, item.Substring(2,item.Length-2-4), () => { Program.SceneRemove(); Program.SceneAdd(new GameScene(item)); }));
            }

            buttons.Add(new Button(row += 2, false, "Back", () => Program.SceneRemove()));
        }

        public override void Activate()
        {
            Console.ResetColor();
            Console.Clear();
            Program.NeedsRedraw.AddRange(buttons);
        }

        public override void Update()
        {
            if (Console.KeyAvailable)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Escape:
                        Program.SceneRemove();
                        break;
                    case ConsoleKey.Enter:
                        buttons[ActiveButtonID].Execute();
                        break;
                    case ConsoleKey.UpArrow:
                        ActiveButtonID--;
                        break;
                    case ConsoleKey.DownArrow:
                        ActiveButtonID++;
                        break;
                    
                }
            }
        }
    }
}