using System;
using System.Data.SQLite; // durch laden der DLL hinzugekommen

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

            SQLiteConnectionStringBuilder builder = new();
            builder.DataSource = "Steam.db";
            builder.Version = 3;
            Console.WriteLine("Der finale Connectionstring : " + builder.ToString());

            using (SQLiteConnection connection = new(builder.ToString()))
            {
                connection.Open();
                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = "select Title, Name from Games join Categories on (Games.CategoryID = Categories.ID);";
                using (SQLiteDataReader response = command.ExecuteReader())
                {
                    while (response.Read())
                    {
                        Console.WriteLine("Name: {0} , Kategorie: {1}", response.GetString(0), response.GetString(1) );
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
