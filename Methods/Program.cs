using System;

namespace Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            int MeineZahl = 12;
            int MeineNeueZahl = MethodeB(MeineZahl);

            MethodeC(ref MeineZahl);

            int PreRueckgabe = PreIncrement(ref MeineZahl);
            int PostRueckgabe = PostIncrement(ref MeineZahl);
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
    }
}
