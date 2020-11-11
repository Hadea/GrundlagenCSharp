using System;

namespace Methods
{
    class Program
    {
        /// <summary>
        /// Demo project for methods
        /// </summary>
        static void Main()
        {
            int MeineZahl = 12;
            int MeineNeueZahl = MethodeB(MeineZahl);

            // mit ref wird die Arbeitsspeicheradresse (reference) an die methode "MethodeC"
            // weitergegeben sodass die methode die original-variable aus zeile 12 ändert.
            MethodeC(ref MeineZahl);
            // nach diesem aufruf ist MeineZahl auf dem wert 14

            int PreRueckgabe = PreIncrement(ref MeineZahl);
            int PostRueckgabe = PostIncrement(ref MeineZahl);

            // ein Array aus ganzzahlen wird im RAM erstellt und die Arbeisspeicheradresse (reference)
            // wird in der Varialbe ArrayOfInt abgelegt
            int[] ArrayOfInt = new int[20];

            // beim übergeben von Objekten von denen wir nur die Adresse haben benötigen wir kein ref
            // das trifft auf array als auch Klassen zu.
            ArrayConsolePrint(ArrayOfInt);

            ArrayInitializeAscending(ArrayOfInt);

            ArrayConsolePrint(ArrayOfInt);

            int durchschnitt = ArrayAverage(ArrayOfInt);
            Console.WriteLine("Der durchschnitt ist: " + durchschnitt);

            short[] ArrayOfShort = new short[50000];
            ArrayAverage(ArrayOfShort, false);


            CopyParameter(MeineZahl);

            
            int ganzneueVarialbe = VerdoppelnOut(ref MeineZahl);

        }

        // Hier sind 3 verschiedene Varianten der Methode "ArrayAverage"
        // Der Compiler kann sie unterscheiden da sich die Parameter unterscheiden
        // Dieses "Overloading" benutzt man um es dem Anwender der Methoden einfach zu machen
        // die richtige Methode auszuwählen.
        private static short ArrayAverage(short[] pArrayToCalculate)
        {
            short summe = 0;
            foreach (var item in pArrayToCalculate)
            {
                summe += item;
            }
            return (short)(summe / pArrayToCalculate.Length);

        }
        private static short ArrayAverage(short[] pArrayToCalculate, bool test)
        {
            short summe = 0;
            foreach (var item in pArrayToCalculate)
            {
                summe += item;
            }
            return (short)(summe / pArrayToCalculate.Length);

        }
        private static int ArrayAverage(int[] pArrayToCalculate)
        {
            #region Variante1
            int summe = 0;
            foreach (var item in pArrayToCalculate)
            {
                summe += item;
            }
            return summe / pArrayToCalculate.Length;

            #endregion

            #region Variante2
            /*
            int summe = 0;
            int counter = 0;
            while (counter < pArrayToCalculate.Length)
            {
                summe += pArrayToCalculate[counter++];
            }

            return summe / counter;
            */
            #endregion
        }

        /// <summary>
        /// Befüllt das Array mit Zahlen aufsteigend bei 0 beginnent.
        /// </summary>
        /// <param name="pArrayToFill">Array welches befüllt werden soll</param>
        static void ArrayInitializeAscending(int[] pArrayToFill)
        {
            for (int counter = 0; counter < pArrayToFill.Length; counter++)
            {
                pArrayToFill[counter] = counter;
            }
        }


        /// <summary>
        /// Gibt den Inhalt des Arrays auf die Konsole aus. Die Werte werden mit Leerzeichen
        /// voneinander getrennt. Es wird kein Enterzeichen am ende der Ausgabe angefügt.
        /// </summary>
        /// <param name="pArrayToPrint">Array welches ausgegeben werden soll</param>
        static void ArrayConsolePrint(int[] pArrayToPrint)
        {
            foreach (var item in pArrayToPrint)
            {
                Console.Write(item + " ");
            }
        }



        /// <summary>
        /// Gibt einen Text auf die Konsole aus um anzuzeigen das die Methode gestartet wurde.
        /// </summary>
        static void MethodeA() // Methode die keine Daten übergeben bekommt "()" und auch keine daten zurückgibt "void"
        {
            Console.WriteLine("Methode A wurde gestartet");
        }

        /// <summary>
        /// MethodeB erhält eine Zahl und erhöht sie um 2 und gibt das ergebnis der addition zurück
        /// </summary>
        /// <param name="pZahl">Zahl die erhöht werden soll</param>
        /// <returns>Ergebnis des Erhöhens um 2.</returns>
        static int MethodeB(int pZahl) //
        {
            pZahl += 2; // pZahl = pZahl + 2;
            return pZahl;
        }

        /// <summary>
        /// Erhöht den Wert einer Variable um zwei
        /// </summary>
        /// <param name="pZahl">Die Variable welche erhöht werden soll</param>
        static void MethodeC(ref int pZahl)
        {
            pZahl += 2;
            Console.WriteLine(pZahl);
        }


        /// Erstellen von Methoden welche ++ nachstellen
        /// 1. Name: PostIncrement
        ///     Originalvariable sichern
        ///     Original erhöhen
        ///     Sicherung zurückgeben
        static int PostIncrement(ref int pZahl)
        {
            int backup;
            backup = pZahl;
            // alternativ  int backup = pZahl;

            pZahl = pZahl + 1; // alternativ  pZahl += 1;

            return backup;
        }


        /// 2. Name: PreIncrement
        ///     Original erhöhen
        ///     Original zurückgeben
        static int PreIncrement(ref int pZahl)
        {
            pZahl = pZahl + 1;
            return pZahl;
        }

        static void ReadonlyParameterDemo(in int pZahl) // methode erhält die arbeitsspeicheradress eines integers welcher innerhalb der methode nicht verändert werden darf
        {
            Console.WriteLine(pZahl);
            // pZahl = 4; // nicht erlaubt da die referenz schreibgeschützt (in) übergeben wurde
        }

        static void WriteonlyParameterDemo(out int pZahl) // methode erhält die arbeitsspeicheradresse eines integer welcher aber nur zum schreiben da ist. Praktisch falls mehr als eine ausgabe nötig ist.
        {
            //Console.WriteLine(pZahl); // nicht erlaubt da nicht sicher ist das pZahl überhaupt initialisiert wurde
            pZahl = 9; // mindestens einmal muss pZahl beschrieben werden!
        }

        /// <summary>
        /// Value demo
        /// </summary>
        /// <param name="pZahl">copy of content</param>
        static void CopyParameter(int pZahl) // Methode erhält eine KOPIE des Inhaltes eines integer und legt diesen in pZahl ab
        {
            Console.WriteLine(pZahl);
        }

        static int Verdoppeln(int pZahl)
        {
            return pZahl * 2;
        }

        static int VerdoppelnOut(ref int pZahl)
        {
            pZahl *= 2;
            return pZahl;
        }
    }
}
