using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Taschenrechner
{
    class Calculator
    {
        public int NumberA; // ziffer 0
        public int NumberB;
        public Operations Operator;

        public int Calculate()
        {
            

            var _result = Operator switch
            {
                Operations.Addition => NumberA + NumberB,
                Operations.Substration => NumberA - NumberB,
                Operations.Multiplication => NumberA * NumberB,
                Operations.Division => NumberA / NumberB,
                Operations.Modulo => NumberA % NumberB,
                _ => throw new NotImplementedException(),
            };

            NumberA = 0;
            NumberB = 0;
            Operator = Operations.UnSet;
            return _result;
        }

    }
}
