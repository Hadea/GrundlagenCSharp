using System;

namespace ATM
{
    class Program
    {
        static void Main()
        {
            int kontostand = 5000; // erstellung einer ganzzahl welche ein Kontostand darstellen soll 

            Console.WriteLine("Hallo User, ich bin ein Geldautomat");
            Console.WriteLine("Ihr Kontostand beträgt " + kontostand);
            Console.WriteLine("Möchten Sie Geld abheben? [y/n]");

            ConsoleKey nutzerTaste = Console.ReadKey(true).Key;// liesst die gedrückte taste auf der tastatur aus
            if (nutzerTaste == ConsoleKey.Y) // ist die gedrückte taste die Y taste gewesen?
            {
                Console.WriteLine("Wieviel möchten sie abheben?");
                int convertedNumber; // lagerplatz für die Zahl vom nutzer, falls die konvertierung geklappt hat
                if (!int.TryParse(Console.ReadLine(), out convertedNumber)) // versuchen die nutzereingabe in eine Zahl zu verwandeln. Wenn es nicht klappt wird das if ausgeführt (wegen dem ! )
                {
                    // wenn tryparse sagt das die konvertierung fehlschlägt
                    Console.WriteLine("Das war keine gültige Zahl. Ende!");
                    return; // beendet die Main
                }

                if (kontostand < convertedNumber) // testen ob der kontostand kleiner als der gewünschte betrag ist
                {
                    Console.WriteLine("So viel geld haben Sie nicht. Ende!");
                    return; // beendet die Main
                }

                kontostand -= convertedNumber; //zieht den gewünschten betrag vom konto ab
                Console.WriteLine("Geld wurde abgebucht, neuer Kontostand: " + kontostand); // zeigt den neuen kontostand
            }
            Console.WriteLine("Bye");
        }
    }
}
