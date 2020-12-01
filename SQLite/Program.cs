using System;
using System.Data.SQLite; // durch laden der DLL hinzugekommen
using System.IO;

namespace SQLite
{
    class Program
    {
        static void Main()
        {
            //0. DLL für die Datenbank laden (z.B. NuGet Package)
            //1. Connectionstring erstellen (https://www.connectionstrings.com/ oder mit Klasse erstellen)
            //2. Connection aufbauen
            //3. Query vorbereiten
            //4. Query absenden
            //5. Ergebnis zeilenweise lesen (falls ergebnis erwartet)
            //6. alles wieder dicht machen

            SQLiteConnectionStringBuilder builder = new(); //1 hilfsklasse
            builder.DataSource = "Steam.db";
            builder.Version = 3;
            Console.WriteLine("Der finale Connectionstring : " + builder.ToString());

            using (SQLiteConnection connection = new(builder.ToString()))// 2 erstellen der verbindung anhand des connectionstrings
            {
                connection.Open(); // 2 open
                SQLiteCommand command = connection.CreateCommand();// 3 vorbereitung des kommandos, es wird direkt schon für/von der verbindung gebaut
                command.CommandText = "select Title, Name from Games join Categories on (Games.CategoryID = Categories.ID);"; //3 SQL Kommando
                using (SQLiteDataReader response = command.ExecuteReader())//4 absenden und speichern der rückgabe vom Datenbankserver
                {
                    while (response.Read()) //5 solange es noch zeilen in der rückgabe vom Server gibt
                    {
                        Console.WriteLine("Name: {0} , Kategorie: {1}", response.GetString(0), response.GetString(1) ); // zeile bearbeiten
                    }
                }//6 der data reader wird durch das using dicht gemacht
            }//6  die SQL connection wird durch das using dicht gemacht
            Console.ReadLine();
        }
    }
}
