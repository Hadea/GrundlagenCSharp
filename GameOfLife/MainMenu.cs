using System;
using System.Collections.Generic;
using System.IO;

namespace GameOfLife
{
    internal class MainMenu : Scene
    {
        readonly List<string> logoLines;
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
            Console.ResetColor();
            Console.Clear();
            logoLines = new();
            buttons = new List<Button>
            {
                new (10, true, "Random Game"),
                new (12, true, "Predefined Game"),
                new (16, true, "Quit Game")
            };
            inactiveButtons = new List<Button>
            {
                new (14, true, "Load Game"),
            };



            inactiveButtons[0].State = ButtonStates.Inactive;

            needsRedraw = new(buttons);
            needsRedraw.AddRange(inactiveButtons);
            using (StreamReader reader = new("LogoSmall.txt"))
            {
                string newLine;
                while ((newLine = reader.ReadLine()) != null)
                {
                    logoLines.Add(newLine);
                }
            }

            ActiveButtonID = 0;
        }
        public override void Update()
        {
            foreach (var item in needsRedraw)
            {
                item.Draw();
            }
            needsRedraw.Clear();

            int row = 0;
            Console.ResetColor();
            for (; row < logoLines.Count; row++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - logoLines[row].Length / 2, 2 + row);
                Console.Write(logoLines[row]);
            }

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
                        Program.Scenes.Pop();
                        break;
                    case ConsoleKey.Enter:
                        Program.Scenes.Push(new Game());
                        // Todo: switch for buttonID to react to user choice or delegate!
                        break;
                }
            }
        }
    }
}