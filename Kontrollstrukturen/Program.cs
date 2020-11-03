using System;
using System.Collections.Generic;

namespace Kontrollstrukturen
{
    enum Programmzustaende
    {
        Stopping,
        Paused,
        Running,
        Starting,
        Stopped
    }


    class Program
    {

        static void Main(string[] args)
        {

            #region Bedingungen


            if (1 > 2) // testet einen ausdruck ob er TRUE oder FALSE ist
            {
                // wenn 1 grösser ist als 2
            }

            if (1 < 2)
            {
                // wenn 1 kleiner als 2
            }
            else
            {
                // in jedem anderen fall
            }

            if (1 < 2 && 3 > 2) // und verknüpfung
            {
                // wenn beide bedingungen erfüllt sind
            }

            if (1 < 2 || 3 > 2) // oder verknüpfung
            {

            }

            if (1 < 2)
            {
                if (3 > 2)
                {
                    // wenn beide bedingungen erfüllt sind
                }
                else
                {
                    // erste erfüllt, zweite aber nicht
                }
            }
            else
            {
                // erste bereits gescheitert
            }

            if (3 > 2 ||
                (1 < 3 && 2 == 2))
            {

            }

            int VariableA;

            //          ( bedingung     ? true : false)
            VariableA = (3 < 2 || 5 > 3 ? 5 : 3);


            switch (VariableA)
            {
                case 1:
                    // code wenn die Variable dem Fall 1 entspricht
                    break;
                case 2:
                    // code wenn die Variable dem Fall 2 entspricht
                    break;
                default:
                    // wenn kein case getroffen wurde
                    break;
            }

            Programmzustaende MeineGameEngine = Programmzustaende.Stopped;

            switch (MeineGameEngine)
            {
                case Programmzustaende.Paused:
                case Programmzustaende.Starting:
                case Programmzustaende.Running:
                    // code
                    break;
 
                default:
                    Console.WriteLine("#79587: Fehler bei der Engineüberprüfung");
                    break;
            }

            switch (VariableA)
            {
                case 1:
                    MeineGameEngine = Programmzustaende.Paused;
                    break;
                case 2:
                    MeineGameEngine = Programmzustaende.Starting;
                    break;
                default:
                    MeineGameEngine = Programmzustaende.Stopped;
                    break;
            }

            MeineGameEngine = VariableA switch // kurzform erst ab C# in version 8
            {
                1 => Programmzustaende.Paused,
                2 => Programmzustaende.Starting,
                _ => Programmzustaende.Stopped
            };


            #endregion

            #region Schleifen

            int Anfang = 0;

            while (Anfang < 10)
            {
                Anfang++;
            }

            do
            {
                Anfang--;
            } while (Anfang > 0); //wanna see me do it again?

            for (int counter = 0; counter < 10; counter++)
            {
            }


            for (; ; Anfang++)// die bereiche des for sind alle optional for(;;) ist gültig
            {
                if (Anfang > 20)
                {
                    break;
                }
            }

            List<int> ListOfNumbers = new List<int>();

            foreach (int item in ListOfNumbers)
            {
                Console.WriteLine(item);
            }

            ListOfNumbers = null;




            do
            {
                Anfang--;
            } while (Anfang > 0);

            // goto nur sehr selten verwenden, wenn es wirklich nicht anders geht!

            zielpunkt: // zielmarkierung für den goto-sprung

            Anfang--;

            if (Anfang > 0)
            {
                goto zielpunkt; // auslösen des sprungs
            }


            #endregion
        }

    }
}
