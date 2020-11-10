using System;

namespace ATM
{
    class Program
    {
        static void Main()
        {
            Atm BankAutomat = new Atm();

            Console.Write("Hallo User, ich bin ein Geldautomat!\n\nBitte geben sie ihren Namen ein");
            string userName = Console.ReadLine().ToLower();
            Console.Write("Bitte geben sie ihren PIN ein: ");
            string userPinS = Console.ReadLine();
            ushort userPin;
            if (! ushort.TryParse(userPinS, out userPin) || userPinS.Length != 4)
            {
                Console.WriteLine("Die Eingabe entspricht nicht dem PIN format, bye!");
                return;
            }

            switch (BankAutomat.GetBalance(userName, userPin, out int userBalance))
            {
                case ATMError.NoError:
                    Console.WriteLine("Ihr Kontostand beträgt " + userBalance);
                    break;
                case ATMError.PinError:
                case ATMError.UserError:
                    Console.WriteLine("Kommst hier nicht rein, du hacker!!");
                    return;
                default:
                    Console.WriteLine("Der Gerät klappt irgendwie nischt...tschuligom");
                    return;
            }

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

                switch (BankAutomat.Withdraw(userName, userPin, convertedNumber))
                {
                    case ATMError.NoError:
                        Console.WriteLine("Das Geld wurde abgebucht");
                        BankAutomat.GetBalance(userName, userPin, out int newBalance);
                        Console.WriteLine("Neuer Kontostand : " + newBalance);
                        break;
                    case ATMError.PinError:
                    case ATMError.UserError:
                        Console.WriteLine("Kommst hier nicht rein, du hacker!!");
                        return;
                    case ATMError.BalanceError:
                        Console.WriteLine("Sie haben nicht genug Geld");
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine("Bye");
        }
    }
}
