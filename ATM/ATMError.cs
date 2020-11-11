namespace ATM
{
    /// <summary>
    /// Represents possible answers of the ATM
    /// </summary>
    enum ATMError : byte
    {
        NoError,
        PinError,
        UserError,
        ATMError,
        BalanceError
    }
}
