using System; // wenn wir viele dinge aus dem Namespace System brauchen und keine lust haben jedes mal System davor zu schreiben
// ohne dieses using müssten wir Befehle mit vollem namen ansprechen: System.Console.WriteLine();
using System.Drawing;

namespace FPSCounter // unser eigener namespace FPSCounter
                     // dieser wird uns direkt bei Projekterstellung mitgeliefert damit wir uns keine gedanken um Namen machen müssen
                     // ohne namespace müssten wir darauf achten das niemand sonst unsere KlassenNamen auch verwendet.
{
    class Program // serienmässig mitgelieferte Klasse "Program" welche unsere static Main enthalten muss
    {
        static void Main() // static bedeutet das diese methode auf Klassenebene ist, also keinem einzelnen
                           // Objekt direkt zugeordnet ist. Name muss so gewählt sein da windows sonst nicht weiss wo es beginnen
                           // muss
        {

            FPS fpsCounter = new FPS();//erstellt ein O
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Yellow;
            TextBox tbTest = new TextBox(new Point(2, 2), ConsoleColor.Red);
            DVD dvd = new DVD();
            ConsoleKey key = ConsoleKey.Attention;
            do
            {
                fpsCounter.Draw();
                tbTest.Draw();
                dvd.Draw();
                if (!Console.KeyAvailable) continue;
                // code only processed when a key is down
                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        break;
                    case ConsoleKey.DownArrow:
                        break;
                    case ConsoleKey.Enter:
                        break;
                    default:
                        tbTest.ProcessKey(key);
                        break;
                }

            } while (key != ConsoleKey.Escape);
            Console.ResetColor();
        }
    }
}
