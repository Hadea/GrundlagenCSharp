using System;

namespace Taschenrechner
{
    /// <summary>
    /// A simple integer calculator
    /// </summary>
    class Calculator
    {
        public int NumberA; // Erster Operant, wird von der Main befüllt 
        public int NumberB; // Zweiter Operant, wird von der Main befüllt 
        public Operations Operator; // Operator, wird von der Main befüllt und enthält die mathematische Operation

        /// <summary>
        /// Uses the three public fields to calculate a result. Works with integer, only.
        /// </summary>
        /// <returns>Result of the operation</returns>
        /// <exception cref="NotImplementedException">Throws if no valid operator has been provided</exception>
        public int Calculate()
        {
            // kurzschreibweise des switch welcher mit C# 8 eingeführt wurde
            // Sie ist dafür gedacht einer Variable einen wert zuzuweisen über den das switch entscheidet.
            var _result = Operator switch // linke seite ist die Variable welche das switch befüllen soll, rechts vom "=" die Variable welche vom switch überprüft werden soll.
            {
                Operations.Addition => NumberA + NumberB, // links steht der case, rechts vom "=>" steht der wert welcher in _result abgelegt werden soll. Hier ein berechneter Wert.
                Operations.Substration => NumberA - NumberB,
                Operations.Multiplication => NumberA * NumberB,
                Operations.Division => NumberA / NumberB,
                Operations.Modulo => NumberA % NumberB,
                _ => throw new NotImplementedException(), // Der unterstrich "_" ist der default case, welcher hier zu einer exception führt
            };

            // die Variablen werden nach der Berechnung wieder auf die Ausgangswerte zurückgesetzt
            NumberA = 0;
            NumberB = 0;
            Operator = Operations.UnSet;
            return _result; // Ende der Methode und Rückgabe des Ergebnisses an die Stelle des Aufrufs (Main)
        }

    }
}
