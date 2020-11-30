using System;

namespace GameOfLife
{
    internal class EditorScene : Scene
    {
        readonly GameLogic logic;

        public EditorScene(string FileName)
        {
            logic = new();

            if (logic.LoadGame(FileName))
            {

                int offset = Console.WindowWidth / 2 - logic.Field.GetLength(1);

                for (byte row = 0; row < logic.Field.GetLength(0); row++)
                {
                    for (byte col = 0; col < logic.Field.GetLength(1); col++)
                    {
                        uiElements.Add(new BoardButton(row, (byte)(offset + col * 2), row, col, logic));
                    }
                }
            }
            else
            {
                Console.WriteLine("Spiel konnte nicht geladen werden");
            }
        }

        public override void Activate()
        {
            Console.ResetColor();
            Console.Clear();
            for (int row = 0; row < logic.Field.GetLength(0); row++)
            {
                for (int col = 0; col < logic.Field.GetLength(1); col++)
                {
                    BoardButton buffer = (BoardButton)uiElements[row * logic.Field.GetLength(1) + col];
                    if (buffer.Alive == logic.Field[row, col])
                    {
                        Program.NeedsRedraw.Add(buffer); //TODO: remove setter change comparison to always redraw
                    }
                    else
                    {
                        buffer.Alive = logic.Field[row, col];
                    }
                }
            }
        }

        public override void Update()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Escape:
                        Program.SceneAdd(new IngameMenu(logic));
                        break;
                    case ConsoleKey.UpArrow:
                        selectedElementID -= (short)logic.Field.GetLength(1);
                        break;
                    case ConsoleKey.DownArrow:
                        selectedElementID += (short)logic.Field.GetLength(1);
                        break;
                    case ConsoleKey.LeftArrow:
                        selectedElementID--;
                        break;
                    case ConsoleKey.RightArrow:
                        selectedElementID++;
                        break;
                    default:
                        uiElements[selectedElementID].ProcessKey(keyInfo);
                        break;
                }
            }

        }
    }
}