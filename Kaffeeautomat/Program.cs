using System;
using System.Threading;

namespace Kaffeeautomat
{

    class Program
    {
        static void Main()
        {
            Console.CursorVisible = false;
            Console.WriteLine("Hallo User, dies ist ein Kaffeeautomat\nKaffeemaschine wird gestartet");
            CoffeeMashine coffeeMashine = new CoffeeMashine();
            ConsoleKey userInput;
            bool shutdownMashine = false;

            Button[] buttons = new Button[5];
            buttons[0].Text = "Kaffee";
            buttons[0].MachineValue = Recipe.Coffee;

            buttons[1].Text = "Capuchino";
            buttons[1].MachineValue = Recipe.Capuchino;

            buttons[2].Text = "Milchkaffee";
            buttons[2].MachineValue = Recipe.CoffeeMilk;

            buttons[3].Text = "Heiße Milch";
            buttons[3].MachineValue = Recipe.HotMilk;

            buttons[4].Text = "Heißes Wasser";
            buttons[4].MachineValue = Recipe.HotWater;

            byte activeButtonID = 0;


            do
            {
                Thread.Sleep(500);
                DrawButtons(activeButtonID, buttons);
                userInput = Console.ReadKey(true).Key;

                switch (userInput)
                {
                    case ConsoleKey.UpArrow:
                        if (activeButtonID > 0)
                            activeButtonID--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (activeButtonID < buttons.Length -1)
                            activeButtonID++;
                        break;

                    case ConsoleKey.Enter:
                        Console.WriteLine("Ihr " + buttons[activeButtonID].Text + " wird zubereitet");
                        if (coffeeMashine.Dispense(buttons[activeButtonID].MachineValue))
                            Console.WriteLine("Ihr " + buttons[activeButtonID].Text + " ist Fertig");
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Fehler beim zubereten, prüfen sie die Kontainer");
                            Console.ResetColor();
                            Thread.Sleep(2000);
                        }
                        break;
                    case ConsoleKey.K:
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
                    case ConsoleKey.A:
                        shutdownMashine = true;
                        break;
                    case ConsoleKey.W:
                        coffeeMashine.Maintenance();
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

        static void DrawButtons(byte IdActiveButton, Button[] buttons)
        {


            for (int counter = 0; counter < buttons.Length; counter++)
            {
                Console.SetCursorPosition(15, 5 + 2*counter);

                if (counter == IdActiveButton)
                {
                    // ausgewählter button
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.Write(" -> " + buttons[counter].Text);
                    Console.ResetColor();
                }
                else
                {
                    // nicht ausgewählt
                    Console.Write("    " + buttons[counter].Text);
                }
            }

            Console.WriteLine("\n A = Maschine abschalten");
            Console.WriteLine(" W = Wartung durchführen");
        }
    }
}
