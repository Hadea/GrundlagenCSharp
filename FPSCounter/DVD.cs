using System;
using System.Drawing;

namespace FPSCounter
{
    class DVD
    {
        string[] logo = new string[] { @"|\  | | |\ ",
                                       @"| > \ / | >",
                                       @"|/   V  |/ "};
        string[] clear = new string[] { "           ", "           ", "           " };


        Point position;
        (bool X, bool Y) direction;
        DateTime lastPositionUpdate;
        Random rndGen = new Random();
        ConsoleColor color;

        public void Draw()
        {

            if ((DateTime.Now - lastPositionUpdate).TotalMilliseconds > 100)
            {

                // altes logo mit leerzeichen überschreiben
                for (int row = 0; row < logo.Length; row++)
                {
                    for (int col = 0; col < logo[row].Length; col++)
                    {
                        Program.ScreenBuffer[(position.Y + row) * 80 + position.X + col].Char.UnicodeChar = ' ';
                        Program.ScreenBuffer[(position.Y + row) * 80 + position.X + col].Attributes =0;

                    }
                }

                // testen ob eine richtungsänderung nötig ist
                var directionOld = direction;
                if (position.X + logo[0].Length + 5 > 80 ) direction.X = false;
                if (position.Y + logo.Length + 5 > 25) direction.Y = false;
                if (position.X < 1) direction.X = true;
                if (position.Y < 1) direction.Y = true;

                // wenn eine richtung geändert wurde auch eine neue Farbe wählen
                //if (directionOld.X != direction.X || directionOld.Y != direction.Y)
                //    color = (ConsoleColor)rndGen.Next(16);

                // neue Position errechnen anhand der richtung
                position.X = (direction.X ? position.X + 1 : position.X - 1);
                position.Y = (direction.Y ? position.Y + 1 : position.Y - 1);

                // zeit aktualisieren damit das interval neu vergehen muss
                lastPositionUpdate = DateTime.Now;

                // logo mit neuer farbe an neue position zeichnen
                //Console.ForegroundColor = color;
                for (int row = 0; row < logo.Length; row++)
                {
                    for (int col = 0; col < logo[row].Length; col++)
                    {
                        Program.ScreenBuffer[(position.Y + row) * 80 + position.X + col].Char.UnicodeChar = logo[row][col];
                        Program.ScreenBuffer[(position.Y + row) * 80 + position.X + col].Attributes = (short)COLOR.GREEN_TEXT;

                    }
                }
            }

        }
    }
}
