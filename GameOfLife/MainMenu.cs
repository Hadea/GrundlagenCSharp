using System;
using System.Collections.Generic;
using System.IO;

namespace GameOfLife
{
    internal class MainMenu : Scene
    {
        readonly List<Label> labels;
        readonly List<Button> buttons;
        readonly List<Button> inactiveButtons;
        readonly List<IDrawable> needsRedraw;
        private sbyte activeButton;

        public sbyte ActiveButtonID
        {
            get { return activeButton; }
            set
            {
                if (activeButton == value)
                {
                    return;
                }

                buttons[activeButton].State = ButtonStates.Available;
                needsRedraw.Add(buttons[activeButton]);
                activeButton = value;
                if (activeButton < 0)
                {
                    activeButton = (sbyte)(buttons.Count - 1);
                }
                else if (activeButton == buttons.Count)
                {
                    activeButton = 0;
                }

                buttons[activeButton].State = ButtonStates.Selected;
                needsRedraw.Add(buttons[activeButton]);
            }
        }


        public MainMenu()
        {
            
            buttons = new List<Button>
            {
                new (12, true, "Random Game"),
                new (14, true, "Predefined Game"),
                new (18, true, "Quit Game")
            };
            inactiveButtons = new List<Button>
            {
                new (16, true, "Load Game"),
            };

            inactiveButtons[0].State = ButtonStates.Inactive;

            needsRedraw = new();
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
            //prüfen ob etwas neu gezeichnet werden muss
            if (needsRedraw.Count > 0)
            {
                foreach (var item in needsRedraw)
                {
                    item.Draw();
                }
                needsRedraw.Clear(); 
            }

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
                        Program.RemoveScene();
                        break;
                    case ConsoleKey.Enter:
                        Program.AddScene(new Game());
                        // Todo: switch for buttonID to react to user choice or delegate!
                        break;
                }
            }
        }

        public override void Activate()
        {
            Console.ResetColor();
            Console.Clear();
            needsRedraw.AddRange(inactiveButtons);
            needsRedraw.AddRange(buttons);
            needsRedraw.AddRange(labels);
        }
    }
}