using System;

namespace Kaffeeautomat
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hallo User, dies ist ein Kaffeeautomat");
            Console.WriteLine("Möchten sie einen Kaffee?");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "y":
                    Console.WriteLine("Ihr Kaffee wird ausgegeben");
                    break;
                default:
                    Console.WriteLine("Schade, dann kann ich ihnen nicht helfen");
                    break;
            }

            Console.WriteLine("Kaffeeautomat wird beendet");
        }
    }
}
