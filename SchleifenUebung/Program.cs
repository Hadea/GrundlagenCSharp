using System;
using System.Collections.Generic;

namespace SchleifenUebung
{
    class Program
    {
        static void Main()
        {
            //TextSchleifen();
            List<byte> NumbersDrawn;
            List<byte> SpecialsDrawn;

            Console.WriteLine("Hallo User, dies ist ein Lotto-Generator");
            Console.WriteLine("Wie möchten sie ihren Tippschein befüllen?");
            Console.WriteLine(" 1 -> automatisch");
            Console.WriteLine(" 2 -> vordefiniert");
            Console.WriteLine(" 3 -> von Hand");
            string userInput;
            do
            {
                Console.Write("Bitte wählen sie eine Option: ");
                userInput = Console.ReadLine();
            } while (userInput != "1" && userInput != "2" && userInput != "3");
            Random rndGen = new Random();

            switch (userInput)
            {
                case "2": // vordefiniert
                    NumbersDrawn = new List<byte> { 2, 7, 9, 15, 23, 42 };
                    SpecialsDrawn = new List<byte> { 6, 8 };
                    break;
                case "3": // benutzerdefiniert
                    NumbersDrawn = new List<byte>();
                    SpecialsDrawn = new List<byte>();
                    do
                    {
                        Console.Write("Bitte eindeutige Zahl von 1 bis 50 eingeben: ");
                        if (byte.TryParse(Console.ReadLine(), out byte newNumber) && newNumber > 0 && newNumber < 51 && !NumbersDrawn.Contains(newNumber))
                        {
                            NumbersDrawn.Add(newNumber);
                            Console.Write(" OK");
                        }
                        else
                        {
                            Console.WriteLine("Das war keine gültige Zahl, nochmal.");
                        }
                    } while (NumbersDrawn.Count < 5);

                    do
                    {
                        Console.Write("Bitte eindeutige Zahl von 1 bis 10 eingeben: ");
                        if (byte.TryParse(Console.ReadLine(), out byte newNumber) && newNumber > 0 && newNumber < 11 && !SpecialsDrawn.Contains(newNumber))
                        {
                            SpecialsDrawn.Add(newNumber);
                            Console.Write(" OK");
                        }
                        else
                        {
                            Console.WriteLine("Das war keine gültige Zahl, nochmal.");
                        }
                    } while (SpecialsDrawn.Count < 2);
                    break;
                default: // random
                    NumbersDrawn = new List<byte>();
                    SpecialsDrawn = new List<byte>();
                    EuroJackpot(NumbersDrawn, SpecialsDrawn, rndGen);
                    break;

            }

            List<byte> Numbers = new List<byte>();
            List<byte> Specials = new List<byte>();

            Console.WriteLine("EuroJackpot, so schnell es geht");
            PrintLotto(NumbersDrawn, SpecialsDrawn);

            int[] hitStatistic = new int[8];

            int counter = 0;
            DateTime startTime = DateTime.Now;
            while ( (DateTime.Now - startTime).TotalMilliseconds < 5000)
            {
                EuroJackpot(Numbers, Specials, rndGen);
                hitStatistic[CompareLotto(NumbersDrawn, SpecialsDrawn, Numbers, Specials)] += 1;
                counter++;
            }

            Console.WriteLine("Statistik für {0} versuche und {1} Sekunden:", counter.ToString("0,00"), (DateTime.Now - startTime).TotalSeconds);
            foreach (var item in hitStatistic)
            {
                Console.Write(" " + item);
            }
            Console.WriteLine();
            Console.WriteLine("Die Versuche haben {0} Euro gekostet", (counter * 2 + counter / 20).ToString("0,00"));
            Console.ReadLine();

        }


        static int CompareLotto(List<byte> Numbers, List<byte> Special,
                                List<byte> PrePickedNumbers, List<byte> PrePickedSpecial)
        {
            int hits = 0;// ergebnisvariable erstellen
            foreach (int source in Numbers) // schleife welche durch die gesamte Numbers-Liste geht
            {
                foreach (int target in PrePickedNumbers)//      schleife welche durch die gesamte PrePickedNumbers-Liste geht
                {
                    if (source == target)//wenn element der äusseren schleife und der inneren identisch sind
                    {
                        hits++;//              ergebnisvariable um 1 erhöhen
                        break;
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
                        break;
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
        static void PrintLotto(List<byte> Numbers, List<byte> Special) // methode welche 2 integer-listen mit lottozahlen füllen soll. List ist ein Objekt und wird immer im original weitergegeben
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

        static void EuroJackpot(List<byte> Numbers, List<byte> Special, Random RandomGenerator)
        {
            Numbers.Clear();
            Special.Clear();

            while (Numbers.Count < 5)
            {
                byte newNumber = (byte)RandomGenerator.Next(1, 51);
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
                byte newNumber = (byte)RandomGenerator.Next(1, 11);
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
