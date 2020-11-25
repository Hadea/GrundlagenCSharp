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
        readonly public MathematischeOperation befehl; // private variante der Variable welche mit dem Konstruktor befüllt wird

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

    class ActionButton
    {
        public Action befehl; // entspricht dem Typ:  public delegate void Action ();
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

            // Hier wird dem Konstruktor die referenz zur methode Addition mitgegeben
            ButtonDel meinButton2 = new ButtonDel(Addition);

            // die im button hinterlegte Methode wird gestartet.
            meinButton2.Execute(7, 9);

            // erstellt ein Objekt vom Typ Action
            ActionButton meinActionButton = new ActionButton();
            
            // trägt die referenz zur Methode in der Variable ein
            meinActionButton.befehl = meineVoidMethode;
            // fügt eine weitere Methode hinzu, diesmal in Lambda-Schreibweise
            // Diese hier hat keinen Rückgabewert, keinen Namen und keine Parameter
            // Da sie auch nur einen befehl enthält können sogar geschweifte klammern und semikolon entfernt werden.
            meinActionButton.befehl += () => Console.WriteLine("Lambda Methode wurde gestartet");

            // wenn ein Lambda mehr als einen befehl enthält werden die geschweiften Klammern benötigt und die
            // befehle werden wie üblich mit semikolon beendet
            meinActionButton.befehl += () => { Console.Write("Lambda Methode "); Console.WriteLine("mit mehreren Befehlen"); };
            // führt alle Methoden aus welche in befehl gespeichert sind
            // die Variable befehl vom typ Action (delegate ohne parameter und rückgabe) verhält sich wie eine
            // Liste aus Methodenreferenzen welche beim ausführen mit einer foreach durchgegangen wird.
            meinActionButton.befehl();


            // erstellt einen neuen Button welcher eine Methode als parameter für den Konstruktor haben will
            // auch hier können Lambdas verwendet werden.
            // Dieses Lambda kann zwei parameter empfangen und intern benutzen, wie normale methoden auch.
            // der Datentyp der Parameter kann dabei weggelassen werden
            // Ausgeschrieben als normale methode:   int MeinLambda(int A, int B) { return A/B;}
            ButtonDel meinDritterButton = new ButtonDel( (A,B) => { return A / B; } );

            int h = 5;
            int o = 7;
            // starten der Methoden welche in befehl eingetragen sind, hier bisher nur eine.
            // die parameter werden der reihe nach an jede der Methoden (oder Lambdas) weitergereicht
            // und nacheinander ausgeführt. Vorsicht mit Referenzen und rückgaben.
            Console.WriteLine(meinDritterButton.befehl(h,o));

            Console.ReadLine();
        }

        static void meineVoidMethode()
        {
            Console.WriteLine("Void Methode wurde gestartet");
        }
    }
}
