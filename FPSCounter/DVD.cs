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
                for (int i = 0; i < clear.Length; i++)
                {
                    Console.SetCursorPosition(position.X, position.Y+i);
                    Console.Write(clear[i]);
                }

                // testen ob eine richtungsänderung nötig ist
                var directionOld = direction;
                if (position.X > 100) direction.X = false;
                if (position.Y > 25) direction.Y = false;
                if (position.X < 1) direction.X = true;
                if (position.Y < 1) direction.Y = true;

                // wenn eine richtung geändert wurde auch eine neue Farbe wählen
                if (directionOld.X != direction.X || directionOld.Y != direction.Y)
                    color = (ConsoleColor)rndGen.Next(16);

                // neue Position errechnen anhand der richtung
                position.X = (direction.X ? position.X + 1 : position.X - 1);
                position.Y = (direction.Y ? position.Y + 1 : position.Y - 1);

                // zeit aktualisieren damit das interval neu vergehen muss
                lastPositionUpdate = DateTime.Now;

                // logo mit neuer farbe an neue position zeichnen
                Console.ForegroundColor = color;
                for (int i = 0; i < logo.Length; i++)
                {
                    Console.SetCursorPosition(position.X, position.Y + i);
                    Console.Write(logo[i]);
                }
            }

        }
    }
}
