using System;
using System.Collections.Generic;
using System.Text;

namespace ATM
{
    enum ATMError : byte
    {
        NoError,
        PinError,
        UserError,
        ATMError,
        BalanceError
    }
}
