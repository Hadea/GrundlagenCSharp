using System;
namespace GameOfLife
{
    internal class GameScene : Scene
    {
        readonly GameLogic logic;
        DateTime lastLogicUpdate;
        readonly BoardLabel[,] boardLabels;

        public GameScene()
        {
            lastLogicUpdate = DateTime.Now;
            logic = new();
            boardLabels = new BoardLabel[logic.Field.GetLength(0), logic.Field.GetLength(1)];

            int offset = Console.WindowWidth / 2 - boardLabels.GetLength(1);
            for (int row = 0; row < boardLabels.GetLength(0); row++)
            {
                for (int col = 0; col < boardLabels.GetLength(1); col++)
                {
                    boardLabels[row, col] = new(row, offset + col * 2);
                }
            }
        }

        public GameScene(string FileName)
        {
            lastLogicUpdate = DateTime.Now;
            logic = new();
            logic.LoadGame(FileName);

            boardLabels = new BoardLabel[logic.Field.GetLength(0), logic.Field.GetLength(1)];

            int offset = Console.WindowWidth / 2 - boardLabels.GetLength(1);
            for (int row = 0; row < boardLabels.GetLength(0); row++)
            {
                for (int col = 0; col < boardLabels.GetLength(1); col++)
                {
                    boardLabels[row, col] = new(row, offset + col * 2);
                }
            }
        }

        public override void Activate()
        {
            Console.ResetColor();
            Console.Clear();
            foreach (var item in boardLabels)
            {
                Program.NeedsRedraw.Add(item);
            }
        }

        public override void Update()
        {
            Console.SetCursorPosition(0, 0);
            bool[,] arrayToDraw = logic.Field;

            for (int Y = 0; Y < arrayToDraw.GetLength(0); Y++)
            {
                for (int X = 0; X < arrayToDraw.GetLength(1); X++)
                {
                    boardLabels[Y, X].Alive = arrayToDraw[Y, X];
                }
            }

            if (Console.KeyAvailable)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Escape:
                        Program.SceneRemove();
                        return;
                    case ConsoleKey.S: // spiel speichern
                        logic.SaveGame("GameA.xml");
                        break;
                }

            }

            if ((DateTime.Now - lastLogicUpdate).TotalMilliseconds > 500)
            {
                lastLogicUpdate = DateTime.Now;
                logic.Update();
            }
        }
    }
}