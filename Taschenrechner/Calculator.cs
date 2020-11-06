using System;
using System.Collections.Generic;
using System.Text;

namespace Taschenrechner
{
    class Calculator
    {
        public int NumberA;
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
            return _result;
        }

    }
}
