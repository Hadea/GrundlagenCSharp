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
            int _result;
            switch (Operator)
            {
                case Operations.Addition:
                    _result= NumberA + NumberB;
                    break;
                case Operations.Substration:
                    _result = NumberA - NumberB;
                    break;
                case Operations.Multiplication:
                    _result = NumberA * NumberB;
                    break;
                case Operations.Division:
                    _result = NumberA / NumberB;
                    break;
                case Operations.Modulo:
                    _result = NumberA % NumberB;
                    break;
                default:
                    throw new NotImplementedException();
            }
            return _result;
        }

    }
}
