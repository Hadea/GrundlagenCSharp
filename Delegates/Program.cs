using System;

namespace Delegates
{
    // erstellt einen neuen Typ den wir in unserem Projekt nutzen können
    // wir Kündigen also an das es Variablen (referenz) geben kann welche auf Methoden zeigen
    // Die Methoden welche in dieser Variablen gespeichert werden sollen müssen exakt diesem
    // delegate entsprechen. Parameteranzahl, Typen der Parameter, Rückgabewert!
    public delegate int MathematischeOperation(int ZahlA, int ZahlB);

    class Button
    {
        // die klasse hat eine Variable (referenz) in welcher Methoden abgelegt werden können
        public MathematischeOperation Execute;
    }

    class ButtonDel
    {
        readonly private MathematischeOperation befehl; // private variante der Variable welche mit dem Konstruktor befüllt wird

        // Konstruktor-Methode welche als Parameter eine Referenz zu einer Methode verlangt.
        public ButtonDel(MathematischeOperation operation)
        {
            // die referenz zur übergebenen Methode wird in der privaten abgelegt
            befehl = operation;
        }

        // führt den hinterlegten befehl aus
        public int Execute(int ZahlA, int ZahlB)
        {
            if (befehl.GetInvocationList().Length > 0)
            {
                return befehl(ZahlA, ZahlB);
            }
            return -1;
        }
    }
    class Program
    {
        // eine Methode die exakt den Anforderungen des Delegate entspricht
        // Parameteranzahl, Typen der Parameter, Rückgabewert!
        static int Addition(int ZahlA, int ZahlB)
        {
            return ZahlA + ZahlB;
        }

        // eine Methode die exakt den Anforderungen des Delegate entspricht
        // Parameteranzahl, Typen der Parameter, Rückgabewert!
        static int Subtraktion(int ZahlA, int ZahlB)
        {
            return ZahlA - ZahlB;
        }

        static void Main()
        {
            // erstellt eine Variable in der Methoden abgelegt werden können
            MathematischeOperation meineOperationen;

            // die kompatible methode Subtraktion wird nun auch mit meineOperation angesprochen
            meineOperationen = Subtraktion;

            // aufruf der in der Variablen hinterlegten methode
            Console.WriteLine("Operation ergibt {0}", meineOperationen(5, 3));

            // austausch der Methode durch eine andere kompatible
            meineOperationen = Addition;

            // aufruf der in der Variablen hinterlegten methode
            Console.WriteLine("Operation ergibt {0}", meineOperationen(5, 3));

            // erstellung eines Objektes vom Typ Button
            Button meinButton = new Button();

            // Der Variable Execute wird die referenz zu Addition übergeben
            meinButton.Execute = Addition;

            // Die in Execute referenzierte Methode wird gestartet
            meinButton.Execute(4, 7);

            ButtonDel meinButton2 = new ButtonDel(Addition);
            meinButton2.Execute(7, 9);
        }
    }
}
