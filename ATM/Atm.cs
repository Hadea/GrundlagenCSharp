using System;
using System.Collections.Generic;
using System.Text;

namespace ATM
{
    class Atm
    {
        List<BankAccount> bankAccounts;

        public Atm()
        {
            bankAccounts = new List<BankAccount> {
                new BankAccount( "hans", 1234, 5000 ),
                new BankAccount( "katie", 4321, 6500 ) };
        }

        public ATMError GetBalance(string UserName, ushort Pin, out int Balance)
        {
            // testen ob der Container "bankAccounts" korrekt erstellt wurde
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
