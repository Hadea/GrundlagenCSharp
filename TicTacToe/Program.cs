using System;
using System.Drawing;

namespace TicTacToe
{
    class Program
    {
        static void Draw(FieldState[,] Board)
        {
            Console.Clear();
            for (int row = 0; row < 3; row++)// reihe zählen von 0 solange kleiner als 3
            {
                for (int column = 0; column < 3; column++)//    spalte zählen von 0 solange kleiner als 3
                {
                    switch (Board[row, column])
                    {
                        case FieldState.Empty://      wenn im spielfeld an koordinate reihe,spalte leer steht
                            Console.Write("_");//          ausgabe leerzeichen
                            break;
                        case FieldState.X://      wenn im spielfeld an koordinate reihe,spalte X steht
                            Console.Write("X");//          ausgabe eines X
                            break;
                        case FieldState.O://      wenn im spielfeld an koordinate reihe,spalte O steht
                            Console.Write("O");//          ausgabe eines O
                            break;
                        case FieldState.Hint://      wenn im spielfeld an koordinate reihe,spalte hint steht
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.Write(" ");//          ausgabe eines leerzeichens mit anderer hintergrundfarbe
                            Console.ResetColor();
                            break;
                        default: // wenn etwas völlig unerwartetes in einem Spielfeld steht
                            throw new NotImplementedException();//abbruch der Methode
                    }//ende switch
                }//    ende zählen spalte
                Console.WriteLine();
            }// ende zählen reihe
        }
        static void Main()
        {
            string[] userNames = new string[2];

            Console.WriteLine("Hallo User, ich bin ein Spiel"); // ausgabe begrüssung
            Console.WriteLine("Spieler X bitte name eingeben");// ausgabe Spieler X bitte name eingeben
            userNames[0] = Console.ReadLine(); // eingabe von tastatur lesen und abspeichern
            Console.WriteLine("Spieler Y bitte name eingeben"); // ausgabe Spieler Y bitte name eingeben
            userNames[1] = Console.ReadLine();// eingabe von tastatur lesen und abspeichern

            
            Spielfeld spiel = new Spielfeld();
            do // wiederholen
            {
                spiel.Reset(); //   spiel auf anfangszustand setzen
                TurnResult result = TurnResult.Invalid;
                do
                {  //   wiederholen
                    Draw(spiel.GetBoard());//      spielfeld anzeigen
                    do
                    {//      wiederholen
                        Console.Write("Bitte feld auswählen {0} xy : ", (spiel.GetCurrentPlayer() ? userNames[0] : userNames[1]));//          ausgabe Bitte feld auswählen
                        byte X;
                        byte Y;
                        string userInput = Console.ReadLine();//          eingabe des feldes lesen und abspeichern
                        if (!byte.TryParse(userInput[0].ToString(), out X) || X > 2)
                        {
                            Console.WriteLine("keine gültige koordinate X");
                            continue;
                        }

                        if (!byte.TryParse(userInput[1].ToString(), out Y) || Y > 2)
                        {
                            Console.WriteLine("keine gültige koordinate Y");
                            continue;
                        }
                        result = spiel.Turn(new Point(X, Y)); //          zug durchführen und ergebnis abspeichern
                    } while (result == TurnResult.Invalid);//      solange Spielerzug ungültig
                } while (result == TurnResult.Valid); //   solange Spielerzug gültig
                Draw(spiel.GetBoard());
                if (result == TurnResult.Tie) //   wenn spielerzug unentschieden
                    Console.WriteLine("Unentschieden!");
                else
                    Console.WriteLine("Sieg für {0}", (spiel.GetCurrentPlayer() ? userNames[0] : userNames[1]));            //      ausgabe aktueller spieler hat gewonnen
                Console.WriteLine("Möchten sie noch ein Spiel spielen? [y/n]");//   ausgabe möchten sie noch ein spiel?
            } while (Console.ReadKey(true).Key == ConsoleKey.Y); // solange y von der tastatur gelesen wurde

            Console.WriteLine("Auf wiedersehen");
        }
    }
}