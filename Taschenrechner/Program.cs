using System;
using System.ComponentModel.DataAnnotations;

namespace Taschenrechner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello User, this is a calculator!");// macht automatisch einen Zeilenumbruch
            Console.Write("Please enter your first number : "); // macht keinen Zeilenumbruch
            string UserInput;
            UserInput = Console.ReadLine();// liesst von der Konsole und speichert in string
            int ConvertedNumber;
            if (!int.TryParse(UserInput, out ConvertedNumber))
            {
                Console.WriteLine("Input error. Please insert integer numbers only!");
                return;
            }

            Calculator calc = new Calculator();
            calc.NumberA = ConvertedNumber;

            Console.Write("Please enter an operation ( + - * / % ) : ");
            UserInput = Console.ReadLine();

            switch (UserInput)
            {
                case "+":
                    calc.Operator = Operations.Addition;
                    break;
                case "-":
                    calc.Operator = Operations.Substration;
                    break;
                case "*":
                    calc.Operator = Operations.Multiplication;
                    break;
                case "/":
                    calc.Operator = Operations.Division;
                    break;
                case "%":
                    calc.Operator = Operations.Modulo;
                    break;
                default:
                    Console.WriteLine("Unkown operator!");
                    return;
            }

            Console.Write("Please insert second number : ");
            UserInput = Console.ReadLine();

            if (!int.TryParse(UserInput, out ConvertedNumber))
            {
                Console.WriteLine("Input error. Please insert integer numbers only!");
                return;
            }

            calc.NumberB = ConvertedNumber;
            Console.WriteLine("Result is: " +  calc.Calculate());
        }
    }
}
