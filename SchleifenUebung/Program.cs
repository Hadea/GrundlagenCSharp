using System;
using System.Collections.Generic;

namespace SchleifenUebung
{
    class Program
    {
        static void Main()
        {
            //TextSchleifen();
            for (int i = 0; i < 20; i++)
            {

            EuroJackpot();
            }



        }

        static void EuroJackpot()
        {
            Random rndGen = new Random();

            List<int> numbers = new List<int>();
            while (numbers.Count < 5)
            {
                int newNumber = rndGen.Next(1, 51);
                bool insertAllowed = true;

                foreach (var item in numbers)
                {
                    if (item == newNumber)
                    {
                        insertAllowed = false;
                        break;
                    }
                }

                if (insertAllowed)
                {
                    numbers.Add(newNumber);
                }

            }

            List<int> zusatz = new List<int>();
            while (zusatz.Count < 2)
            {
                int newNumber = rndGen.Next(1, 11);
                bool insertAllowed = true;

                foreach (var item in zusatz)
                {
                    if (item == newNumber)
                    {
                        insertAllowed = false;
                        break;
                    }
                }

                if (insertAllowed)
                {
                    zusatz.Add(newNumber);
                }

            }

            Console.Write("EuroJackpot Zahlen:");
            foreach (var item in numbers)
            {
                Console.Write("{0,3}",item);
            }
            Console.Write(" Zusatz:");
            foreach (var item in zusatz)
            {
                Console.Write("{0,3}",item);
            }
            Console.WriteLine();

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
