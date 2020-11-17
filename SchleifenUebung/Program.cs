using System;
using System.Collections.Generic;

namespace SchleifenUebung
{
    class Program
    {
        static void Main()
        {
            //TextSchleifen();

            //TODO: 1x Lottoergebnis ziehen
            //TODO: Schleife umbauen das sie 10 sekunden lang läuft
            //TODO: Methode bauen welche einen Lottoschein mit dem Lottoergebnis vergleicht
            //      rückgabe soll die anzahl der korrekten zahlen sein
            //TODO: Ergebnisarray der länge 8 erstellen. Rückgabe der Vergleichsmethode
            //      als sprung im Ergebnisarray nutzen und inhalt um 1 raufzählen
            //TODO: zählvariable in die schleife einbauen
            //TODO: Ausgabe des arrays und der zählvariable

            for (int i = 0; i < 20; i++)
            {
                List<int> Liste1 = new List<int>();
                List<int> Liste2 = new List<int>();

                EuroJackpot(Liste1, Liste2);
                PrintLotto(Liste1, Liste2);

            }
        }

        static void PrintLotto(List<int> Numbers, List<int> Special)
        {
            Console.Write("EuroJackpot Zahlen:");
            foreach (var item in Numbers)
            {
                Console.Write("{0,3}", item);
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
