using System;
using System.Threading;

namespace Kaffeeautomat
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hallo User, dies ist ein Kaffeeautomat\nKaffeemaschine wird gestartet");
            CoffeeMashine coffeeMashine = new CoffeeMashine();

            bool shutdownMashine = false;
            do
            {
                Thread.Sleep(2000);
                Console.Clear();
                Console.WriteLine(" K -> Kaffee ausgeben\n C -> Capuchino\n H -> Heisses Wasser\n M -> Heisse Milch\n ? -> Milchkaffee\n W -> Wartung\n  A -> Kaffeemaschine abschalten");
                string userInput = Console.ReadLine().ToUpper();

                switch (userInput)
                {
                    case "k":
                    case "K":
                        Console.WriteLine("Ihr Kaffee wird zubereitet");
                        if (coffeeMashine.Dispense(Recipe.Coffee))
                        {
                            Console.WriteLine("Ihr Kaffee ist fertig");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ihr Kaffee konnte nicht zubereitet werden, checken sie die Kontainer");
                            Console.ResetColor();
                        }
                        break;
                    case "A":
                        shutdownMashine = true;
                        break;
                    case "W":
                        coffeeMashine.CCoffee = 100;
                        coffeeMashine.CWater = 100;
                        coffeeMashine.CWasteCoffee = 0;
                        coffeeMashine.CWasteWater = 0;
                        Console.WriteLine("Wartung durchgeführt, container sind wieder ok.");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Die Eingabe verstehe ich nicht.");
                        Console.ResetColor();
                        break;
                }

            } while (!shutdownMashine);
            Console.WriteLine("Kaffeeautomat wird beendet");
        }
    }
}
