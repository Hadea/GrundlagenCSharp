using System;
using System.Collections.Generic;
using System.Text;

namespace ATM
{
    class BankAccount
    {
        public string UserName;
        public ushort Pin;
        public int Balance;

        public BankAccount(string Name, ushort Pin, int Kontostand)
        {
            UserName = Name;
            this.Pin = Pin;
            Balance = Kontostand;
        }
    }
}
