using System.Collections.Generic;

namespace ATM
{
    /// <summary>
    /// Represents an ATM device with some sample data
    /// </summary>
    class Atm
    {
        List<BankAccount> bankAccounts;

        /// <summary>
        /// Creates an ATM with two sample accounts
        /// </summary>
        public Atm()
        {
            // erstellt eine liste für BankAccount und fügt direkt zwei einträge hinzu.
            // besonderheit dabei ist das keine runden klammern, sondern geschweifte
            // hinter der listenerstellung verwendet werden
            bankAccounts = new List<BankAccount> {
                new BankAccount( "hans", 1234, 5000 ),
                new BankAccount( "katie", 4321, 6500 ) };
        }

        /// <summary>
        /// Reads the current balance of an account if login is successful
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Pin"></param>
        /// <param name="Balance"></param>
        /// <returns></returns>
        public ATMError GetBalance(string UserName, ushort Pin, out int Balance)
        {
            // testen ob der Container "bankAccounts" korrekt erstellt wurde
            // zuerst wird getestet ob bankAccounts den inhalt null enthält
            // sollte dies zutreffen wird sofort der inhalt des if ausgeführt
            // und der zweite test ignoriert
            // sollte der erste test fehlschlagen wird auch der zweite test gemacht
            // dadurch wissen wir bereits im zweiten test das das objekt existieren
            // muss und wir problemlos auf eigenschaften des objektes zugreifen können.
            if (bankAccounts == null || bankAccounts.Count == 0)
            {
                Balance = 0;
                return ATMError.ATMError;
            }

            // durch die liste aller BankAccounts durchlaufen
            for (int counter = 0; counter < bankAccounts.Count; counter++)
            {
                // vergleichen ob nutzername und pin mit den hinterlegten übereinstimmt
                if (UserName == bankAccounts[counter].UserName)
                {
                    if (Pin == bankAccounts[counter].Pin)
                    {
                        // rückgabe und out füllen
                        Balance = bankAccounts[counter].Balance;
                        return ATMError.NoError;
                    }
                    else
                    {
                        // wenn keiner der Listeneinträge übereinstimmt fehler zurückgeben
                        Balance = 0;
                        return ATMError.PinError;
                    }
                }
            }
            // wenn keiner der Listeneinträge übereinstimmt fehler zurückgeben
            Balance = 0;
            return ATMError.UserError;
        }

        public ATMError Withdraw(string UserName, ushort Pin, int Amount)
        {
            // testen ob der Container "bankAccounts" korrekt erstellt wurde
            if (bankAccounts == null || bankAccounts.Count == 0)
            {
                return ATMError.ATMError;
            }

            // durch die liste aller BankAccounts durchlaufen
            for (int counter = 0; counter < bankAccounts.Count; counter++)
            {
                // vergleichen ob nutzername und pin mit den hinterlegten übereinstimmt
                if (UserName == bankAccounts[counter].UserName)
                {
                    if (Pin == bankAccounts[counter].Pin)
                    {
                        // rückgabe und out füllen
                        if (bankAccounts[counter].Balance >= Amount)
                        {
                            bankAccounts[counter].Balance -= Amount;
                            return ATMError.NoError;
                        }
                        else
                            // wenn nur ein befehl in geschweifte klammern kommen würde
                            // kann man sie weglassen. Je nach firmeninterner Konvention
                            // vielleicht nicht erlaubt. (if, while, for, do, else)
                            return ATMError.BalanceError;
                    }
                    else
                    {
                        // wenn keiner der Listeneinträge übereinstimmt fehler zurückgeben
                        return ATMError.PinError;
                    }
                }
            }
            // wenn keiner der Listeneinträge übereinstimmt fehler zurückgeben
            return ATMError.UserError;
        }
    }
}
