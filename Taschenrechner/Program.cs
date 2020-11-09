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
            string UserInput; // zwischenlager für die Nutzereingabe. Die Eingaben sind immer buchstaben und müssen konvertiert werden
            int ConvertedNumber; // zwischenlager für die konvertierte Nutzereingabe
            Calculator calc = new Calculator(); // rechte seite erstellt ein Objekt vom Typ "Calculator"
            bool faultyInput; // wird für das überprüfen des Operators verwendet um im fehlerfall zu wiederholen

            do // Sprungpunkt für die Programmwiederholung
            {
                do //sprungpunkt für die wiederholung der ersten eingabe
                {
                    Console.Write("Please enter your first number : "); // ausgabe des textes damit der nutzer weiss was er eingeben soll
                    UserInput = Console.ReadLine(); // einlesen der Konsoleneingabe und ablegen in Userinput. Eingaben kommen im "string" format
                } while (!int.TryParse(UserInput, out ConvertedNumber)); // TryParse gibt true zurück wenn der übergebene string umgewandelt werden kann. Durch das ! wird die rückgabe invertiert sodass im fehlerfall wiederholt wird.

                calc.NumberA = ConvertedNumber; // die konvertierte Nummer wird im Calculator abgelegt.

                faultyInput = true; // standardwert für faultyInput setzen, damit es auch im zweiten durchlauf des programms den richtigen wert hat.
                do // sprungpunkt für die Operator-Frage
                {
                    Console.Write("Please enter an operation ( + - * / % ) : "); // ausgeben der Frage
                    UserInput = Console.ReadLine(); // einlesen der Nutzereingabe und ablegen in UserInput
                    switch (UserInput) // inhalt von UserInput auslesen und anhand der case vergleichen
                    {
                        case "+": // falls in UserInput exakt ein + zeichen steht, sonst nichts.
                            calc.Operator = Operations.Addition; // setzen des operators für den taschenrechner
                            faultyInput = false; // variable wird auf false gesetzt da wir einen korrekten operator haben und nicht wiederholt werden soll
                            break;
                        case "-": // falls in UserInput exakt ein - zeichen steht, sonst nichts.
                            calc.Operator = Operations.Substration;
                            faultyInput = false;
                            break;
                        case "*": //falls in UserInput exakt ein * zeichen steht, sonst nichts.
                            calc.Operator = Operations.Multiplication;
                            faultyInput = false;
                            break;
                        case "/"://falls in UserInput exakt ein / zeichen steht, sonst nichts.
                            calc.Operator = Operations.Division;
                            faultyInput = false;
                            break;
                        case "%"://falls in UserInput exakt ein % zeichen steht, sonst nichts.
                            calc.Operator = Operations.Modulo;
                            faultyInput = false;
                            break;
                        default: // in jedem anderen fall, also wenn kein case getroffen wurde
                            Console.ForegroundColor = ConsoleColor.Red; // ab hier wird die schriftfarbe für alle weiteren ausgaben auf rot gesetzt
                            Console.WriteLine("Unkown operator, try again: ");
                            Console.ResetColor(); // ab hier sind die standardfarben wieder aktiv
                            break;
                    }
                } while (faultyInput); // solange wir fehlerhafte eingaben haben soll wiederholt werden

                do // Sprungpunkt für fehler bei der eingabe der zweiten Zahl
                {
                    Console.Write("Please insert second number : ");
                    UserInput = Console.ReadLine();
                }
                while (!int.TryParse(UserInput, out ConvertedNumber)); // solange die nutzereingabe nicht in eine Zahl konvertiert werden kann wird wiederholt

                calc.NumberB = ConvertedNumber;

                //Todo: divZero check should be in calculator!
                if ((calc.Operator == Operations.Modulo || calc.Operator == Operations.Division) && calc.NumberB == 0) // Wenn die zweite Zahl eine 0 ist und der operaor Division oder Modulo, dann gibt es eine fehlermeldung.
                {
                    Console.WriteLine("Division by zero is undefined!");
                    return; // vorzeitiges ende der Methode Main
                }

                Console.Write("Result is: " + calc.Calculate() + "\nAgain?[y/n] : "); // zwei zeilen werden auf einmal ausgegeben, "\n" entspricht einem Enter
            } while (Console.ReadLine().ToLower() == "y"); // liesst von der konsole, konvertiert das gelesene in kleinbuchstaben und vergleicht das ergebnis mit dem text "y".

            Console.WriteLine("Ending program. Bye :)");

            // das Objekt Calculator muss in C# nicht von hand zerstört werden.
            // Sobald die Referenz calc zusammen mit Main zerstört wird und es keine weitere referenz auf das Objekt gibt
            // wird der Garbage-Collector den destructor aufrufen und den Arbeitsspeicher des Objektes freigeben.
        }
    }
}
