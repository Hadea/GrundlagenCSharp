using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Channels;

namespace Taschenrechner
{
    class Program
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Standard naming convention breaks C#")]
        static void Main()
        {
            Console.WriteLine("Hello User, this is a calculator!");// macht automatisch einen Zeilenumbruch
            string UserInput;
            int ConvertedNumber;

            do
            {
                do
                {
                    Console.Write("Please enter your first number : ");
                    UserInput = Console.ReadLine();
                } while (!int.TryParse(UserInput, out ConvertedNumber));

                Calculator calc = new Calculator();
                calc.NumberA = ConvertedNumber;
                bool faultyInput = true;

                do
                {
                    Console.Write("Please enter an operation ( + - * / % ) : ");
                    UserInput = Console.ReadLine();
                    switch (UserInput)
                    {
                        case "+":
                            calc.Operator = Operations.Addition;
                            faultyInput = false;
                            break;
                        case "-":
                            calc.Operator = Operations.Substration;
                            faultyInput = false;
                            break;
                        case "*":
                            calc.Operator = Operations.Multiplication;
                            faultyInput = false;
                            break;
                        case "/":
                            calc.Operator = Operations.Division;
                            faultyInput = false;
                            break;
                        case "%":
                            calc.Operator = Operations.Modulo;
                            faultyInput = false;
                            break;
                        default:
                            Console.WriteLine("Unkown operator, try again: ");
                            break;
                    }
                } while (faultyInput);

                do
                {
                    Console.Write("Please insert second number : ");
                    UserInput = Console.ReadLine();
                }
                while (!int.TryParse(UserInput, out ConvertedNumber));

                calc.NumberB = ConvertedNumber;

                //Todo: divZero check should be in calculator!
                if ((calc.Operator == Operations.Modulo || calc.Operator == Operations.Division) && calc.NumberB == 0)
                {
                    Console.WriteLine("Division by zero is undefined!");
                    return;
                }

                Console.WriteLine("Result is: " + calc.Calculate());
                Console.Write("Again?[y/n] : ");
            } while (Console.ReadLine().ToLower() == "y" ); // nur wenn ein kleines y eingegeben wird soll wiederholt werden

            Console.WriteLine("Ending program. Bye :)");

        }
    }
}
