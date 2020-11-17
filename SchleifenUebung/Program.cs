using System;
using System.Collections.Generic;

namespace SchleifenUebung
{
    class Program
    {
        static void Main()
        {
            //TextSchleifen();

            //TODO: 1x Lottoergebnis ziehen (gegen das vergleichen wir unsere scheine)
            //TODO: Ergebnisarray der länge 8 erstellen.
            List<int> NumbersDrawn = new List<int> { 5, 7, 20, 22, 42 };
            List<int> SpecialsDrawn = new List<int> { 6, 7 };
            List<int> Numbers = new List<int>() ;
            List<int> Specials = new List<int>();

            Console.WriteLine("EuroJackpot, so schnell es geht");
            PrintLotto(NumbersDrawn, SpecialsDrawn);

            int[] hitStatistic = new int[8];

            int counter = 0;
            DateTime startTime = DateTime.Now;
            while ( (DateTime.Now - startTime).TotalMilliseconds < 10000 ) //TODO: Schleife umbauen das sie 10 sekunden lang läuft (DateTime.Now)
            {
                EuroJackpot(Numbers, Specials);
                hitStatistic[CompareLotto(NumbersDrawn, SpecialsDrawn, Numbers, Specials)] += 1;
                counter++;
            }

            Console.WriteLine("Statistik für {0} versuche:", counter);
            foreach (var item in hitStatistic)
            {
                Console.Write(" "+ item);
            }
            Console.WriteLine();
            //TODO: Ausgabe des arrays und der zählvariable
        }


        //TODO: Methode bauen welche einen Lottoschein mit dem Lottoergebnis vergleicht
        //      rückgabe soll die anzahl der korrekten zahlen sein (List.contains)
        static int CompareLotto(List<int> Numbers, List<int> Special,
                                List<int> PrePickedNumbers, List<int> PrePickedSpecial)
        {
            int hits = 0;// ergebnisvariable erstellen
            foreach (int source in Numbers) // schleife welche durch die gesamte Numbers-Liste geht
            {
                foreach (int target in PrePickedNumbers)//      schleife welche durch die gesamte PrePickedNumbers-Liste geht
                {
                    if (source == target)//wenn element der äusseren schleife und der inneren identisch sind
                    {
                        hits++;//              ergebnisvariable um 1 erhöhen
                    }//          ende wenn
                }//      ende schleife
            }// ende schleife
            
            foreach (int source in Special)// schleife welche durch die gesamte Special-Liste geht
            {
                foreach (int target in PrePickedSpecial)//      schleife welche durch die gesamte PrePickedSpecial-Liste geht
                {
                    if (source == target)//          wenn element der äusseren schleife und der inneren identisch sind
                    {
                        hits++;//              ergebnisvariable um 1 erhöhen
                    }//          ende wenn
                }//      ende schleife
            }// ende schleife

            return hits;// rückgabe ergebnisvariable
        }

        /// <summary>
        /// Prints the contents of two integer-lists to the console to represent a lotto drawing.
        /// </summary>
        /// <param name="Numbers">List of 5 numbers between 1 and 50</param>
        /// <param name="Special">List of 2 numbers between 1 and 10</param>
        static void PrintLotto(List<int> Numbers, List<int> Special) // methode welche 2 integer-listen mit lottozahlen füllen soll. List ist ein Objekt und wird immer im original weitergegeben
        {
            Console.Write("EuroJackpot Zahlen:"); // ausgabe der Überschrift
            foreach (var item in Numbers) // den gesamten container Numbers durchgehen
            {
                Console.Write("{0,3}", item); // das aktuell zu bearbeitende element ausgeben. {0,3} bedeutet das item (parameter 0) in mindestens 3 zeichen ausgegeben werden soll.
            }
            Console.Write(" Zusatz:");
            foreach (var item in Special)
            {
                Console.Write("{0,3}", item);
            }
            Console.WriteLine();
        }

        static void EuroJackpot(List<int> Numbers, List<int> Special)
        {
            Random rndGen = new Random();

            Numbers.Clear();
            Special.Clear();

            while (Numbers.Count < 5)
            {
                int newNumber = rndGen.Next(1, 51);
                bool insertAllowed = true;

                foreach (var item in Numbers)
                {
                    if (item == newNumber)
                    {
                        insertAllowed = false;
                        break;
                    }
                }

                if (insertAllowed)
                {
                    Numbers.Add(newNumber);
                }

            }

            while (Special.Count < 2)
            {
                int newNumber = rndGen.Next(1, 11);
                bool insertAllowed = true;

                foreach (var item in Special)
                {
                    if (item == newNumber)
                    {
                        insertAllowed = false;
                        break;
                    }
                }

                if (insertAllowed)
                {
                    Special.Add(newNumber);
                }

            }

        }

        static void TextSchleifen()
        {
            string text = "Hello World!";
            Console.WriteLine(text);

            for (int counter = 0; counter < text.Length; counter++)// zählschleife von 0 solange textende nicht erreicht
            {
                Console.Write(text[counter]);// ausgabe des buchstabens an der stelle des zählers.
            }
            Console.WriteLine();

            for (int counter = text.Length - 1; counter >= 0; counter--)// text buchstabe für buchstabe ausgeben, diesmal aber rückwärts
            {
                Console.Write(text[counter]);
            }
            Console.WriteLine();
            for (int counter = 0; counter < text.Length; counter += 2)// text ausgeben, aber nur jeden zweiten buchstaben
            {
                Console.Write(text[counter]);
            }
            Console.WriteLine();
            Console.Write(text[0]);
            for (int counter = 1; counter < text.Length; counter *= 2)// text ausgeben, aber zähler immer verdoppeln
            {
                Console.Write(text[counter]);
            }
            Console.WriteLine();
            Random rndGen = new Random();
            for (int counter = 0; counter < text.Length; counter += rndGen.Next(3))
            {
                Console.Write(text[counter]);
            }
            Console.WriteLine();

            for (int counter = 0; counter < text.Length; counter++)
            {
                Console.Write(text[rndGen.Next(text.Length)]);
            }
            // ausgabe von zufälligen zeichen aus dem text, genausooft wie der text zeichen hat


            Console.ReadLine();
        }
    }
}
