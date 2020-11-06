using System;
using System.ComponentModel.DataAnnotations;

namespace Taschenrechner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");// macht automatisch einen Zeilenumbruch
            Console.Write("abcde"); // macht keinen Zeilenumbruch

            string UserInput;
            UserInput = Console.ReadLine();// liesst von der Konsole und speichert in string
            int ConvertedNumber = int.Parse(UserInput);

            if (int.TryParse(UserInput,out ConvertedNumber))
            {
                // code wenn es geklappt hat
            }
            else
            {
                // code wenn die nutzereingabe fehlerhaft war und nicht in eine
                // zahl konvertiert werden konnte
            }


            switch (VariableMitEnum)
            {
                case EnumTyp.Addition:
                case EnumTyp.Addition:
                case EnumTyp.Addition:
                case EnumTyp.Addition:
                default:
            }

        }
    }
}
