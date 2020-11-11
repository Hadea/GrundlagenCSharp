using System;
using System.Collections.Generic;
using System.Text;

namespace ATM
{
    /// <summary>
    /// Container class for holding account information.
    /// </summary>
    class BankAccount
    {
        // alle Variablen public damit wir sie von aussen befüllen und lesen können
        public string UserName;
        public ushort Pin;
        public int Balance;

        /// <summary>
        /// Constructor for a bankaccount
        /// </summary>
        /// <param name="Name">Name of Customer</param>
        /// <param name="Pin">Secret PIN of the Customer</param>
        /// <param name="Kontostand">Current balance</param>
        public BankAccount(string Name, ushort Pin, int Balance)
        {
            UserName = Name;
            // this ist hier nötig damit der Compiler unterscheiden kann 
            // das die Klassenvariable (Pin) und nicht der Parameter (Pin) gemeint ist
            // im zweifelsfall wird die Variable genommen die am dichtesten deklariert wurde.
            this.Pin = Pin;
            this.Balance = Balance;
        }
    }
}
