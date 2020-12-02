using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Xml.Serialization;

namespace GameOfLifeLogic
{
    public class GameLogic
    {
        bool[,] fieldFalse;
        bool[,] fieldTrue;
        bool activeField;

        public bool[,] Field
        {
            get { return (activeField ? fieldTrue : fieldFalse); }
            // ein umschaltender setter funktioniert hier nicht, da get und set nur auf änderungen
            // an der referenz reagieren, nicht aber auf lese/schreibzugriffe der inhalte
        }

        public void SetValue(int X, int Y, bool value)
        {
            if (activeField)
            {
                fieldFalse[Y, X] = value;
            }
            else
            {
                fieldTrue[Y, X] = value;
            }

            //(activeField ? fieldFalse : fieldTrue)[Y, X] = value;
        }

        public bool FlipValue(int row, int col)
        {
            fieldFalse[row, col] = !fieldFalse[row, col];
            return fieldFalse[row, col];
        }

        public GameLogic()
        {
            fieldFalse = new bool[20, 30];
            fieldTrue = new bool[20, 30];
            activeField = false;
            reset();
        }

        private void reset()
        {
            Random rndGen = new();
            for (int Y = 0; Y < fieldFalse.GetLength(0); Y++)
            {
                for (int X = 0; X < fieldFalse.GetLength(1); X++)
                {
                    fieldFalse[Y, X] = rndGen.NextDouble() > 0.8d;
                }
            }
        }

        public void Update()
        {

            for (int Y = 0; Y < fieldFalse.GetLength(0); Y++)
            {
                for (int X = 0; X < fieldFalse.GetLength(1); X++)
                {
                    if (Field[Y, X])
                    {
                        // lebender bereich
                        if (getLivingCount(X, Y) is < 2 or > 3) //C# 9 vergleich mit zwei bedingungen
                        {
                            // wenn weniger als 2 lebende angrenzen auf tot setzen
                            // wenn mehr als 3 lebende angrenzen auf tot setzen
                            SetValue(X, Y, false);
                        }
                        else
                            SetValue(X, Y, true);

                    }
                    else
                    {
                        // toter bereich
                        if (getLivingCount(X, Y) == 3)
                        {
                            // wenn exakt 3 lebende angrenzen auf lebend setzen
                            SetValue(X, Y, true);
                        }
                        else
                            SetValue(X, Y, false);
                    }
                }
            }
            activeField = !activeField;
        }

        private int getLivingCount(int x, int y)
        {
            int living = 0;
            for (int row = y - 1; row < y + 2; row++)
            {
                for (int col = x - 1; col < x + 2; col++)
                {
                    if (row > -1 && col > -1 && // ignorieren von zu kleinen zählern
                        row < Field.GetLength(0) && col < Field.GetLength(1) && // ignorieren von zu grossen zählern
                        !(row == y && col == x) && Field[row, col])
                    {
                        living++;
                    }
                }
            }
            return living;
        }

        public bool LoadGame(string FileName)
        {
            if (!File.Exists(FileName))
            {
                return loadGameDatabase(FileName);
            }

            string magic; // read first 4 chars
            using (StreamReader reader = new StreamReader(FileName))
            {
                char[] buffer = new char[4];
                reader.Read(buffer, 0, 4);
                magic = new string(buffer);
            }

            switch (magic)
            {
                case "GOLA":
                    loadGameAscii(FileName);
                    break;
                case "<?xm":
                    loadGameXML(FileName);
                    break;
                case "GOLB":
                    loadGameBinary(FileName);
                    break;
                case "GOLC":
                    throw new NotImplementedException();
                default:
                    return false;
            }

            return true;
        }

        private bool loadGameDatabase(string FileName)
        {
            SQLiteConnectionStringBuilder builder = new();
            builder.Version = 3;
            builder.DataSource = "SaveGames.db";

            int y;
            int x;
            SQLiteBlob blob;
            byte[] byteArray;
            using (SQLiteConnection connection = new(builder.ToString()))
            {
                connection.Open();
                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = "select Height, Width, Field from SaveGames where Name = @name;";
                command.Parameters.AddWithValue("@name", FileName);

                using (SQLiteDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.KeyInfo))
                {
                    if (reader.Read())
                    {
                        // nur die erste zeile der rückgabe.
                        y = reader.GetInt32(0); // spalte 0 = height
                        x = reader.GetInt32(1); // spalte 1 = width
                        using (blob = reader.GetBlob(2, true)) // spalte 2 = field
                        {
                            byteArray = new byte[blob.GetCount()];
                            blob.Read(byteArray, blob.GetCount(), 0);
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            BitArray bits = new(byteArray);

            fieldFalse = new bool[y, x];
            fieldTrue = new bool[y, x];
            activeField = false;

            for (int row = 0; row < y; row++)
            {
                for (int col = 0; col < x; col++)
                {
                    fieldFalse[row, col] = bits[row * x + col];
                }
            }
            return true;
        }

        private void loadGameBinary(string FileName)
        {
            using (BinaryReader reader = new(File.OpenRead(FileName)))
            {
                reader.ReadChars(4); // überspringen der bereits geprüften magic number
                byte y = reader.ReadByte();
                byte x = reader.ReadByte();

                fieldFalse = new bool[y, x];
                fieldTrue = new bool[y, x];
                activeField = false;

                byte[] bytes = reader.ReadBytes((y * x - 1) / 8 + 1);
                BitArray bits = new BitArray(bytes);

                for (int row = 0; row < y; row++)
                {
                    for (int col = 0; col < x; col++)
                    {
                        fieldFalse[row, col] = bits[row * x + col];
                    }
                }
            }
        }

        void loadGameXML(string FileName)
        {
            XmlSerializer serializer = new(typeof(StoredGame));
            StoredGame sg;

            using (Stream file = new FileStream(FileName, FileMode.Open, FileAccess.Read))
            {
                sg = (StoredGame)serializer.Deserialize(file);
            }
            bool[,] convertedField = new bool[sg.Field.Count, sg.Field[0].Count];

            for (int row = 0; row < convertedField.GetLength(0); row++)
            {
                for (int col = 0; col < convertedField.GetLength(1); col++)
                {
                    convertedField[row, col] = sg.Field[row][col];
                }
            }

            fieldFalse = convertedField;
        }
        public bool SaveGame(string FileName, StoredGameVersion Version)
        {
            switch (Version)
            {
                case StoredGameVersion.Ascii:
                    return saveGameAscii(FileName);
                case StoredGameVersion.AsciiXML:
                    return saveGameXML(FileName);
                case StoredGameVersion.Binary:
                    return saveGameBinary(FileName);
                case StoredGameVersion.Database:
                    return saveGameDatabase(FileName);
                default:
                    return false;
            }
        }

        private bool saveGameDatabase(string FileName)
        {
            SQLiteConnectionStringBuilder builder = new();
            builder.Version = 3;
            builder.DataSource = "SaveGames.db";
            if (!File.Exists(builder.DataSource)) // wenn die Datenbank noch nicht existiert soll sie erstellt werden
            {
                // bei sqlite ist das erstellen der datenbank, falls sie noch nicht exisitert ok
                // NIEMALS bei Datenbankservern! Nie! Nada! NULL! VOID! Gar nich! 404! Nööööö!
                using (SQLiteConnection connection = new(builder.ToString()))
                {
                    connection.Open(); // Open erstellt automatisch die datenbank wenn sie nicht da ist, es fehlen nur die tabellen.
                    SQLiteCommand command = connection.CreateCommand();
                    command.CommandText = "create table SaveGames (ID integer not null primary key, Name varchar(15) not null unique , Height integer not null, Width integer not null, Field blob not null)";
                    command.ExecuteNonQuery();
                }
            }

            BitArray bits = new BitArray(Field.GetLength(0) * Field.GetLength(1));
            for (int row = 0; row < Field.GetLength(0); row++)
            {
                for (int col = 0; col < Field.GetLength(1); col++)
                {
                    bits[row * Field.GetLength(1) + col] = Field[row, col];
                }
            }
            byte[] bytes = new byte[(bits.Length - 1) / 8 + 1];
            bits.CopyTo(bytes, 0);

            using (SQLiteConnection connection = new(builder.ToString()))
            {
                connection.Open();
                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = "replace into SaveGames (Name, Height, Width, Field) values (@name, @height, @width, @field);";
                command.Parameters.AddWithValue("@name", FileName);
                command.Parameters.AddWithValue("@height", Field.GetLength(0));
                command.Parameters.AddWithValue("@width", Field.GetLength(1));
                command.Parameters.AddWithValue("@field", bytes);

                int linesAffected = command.ExecuteNonQuery();
                if (linesAffected == 0)
                {
                    return false;
                }
            }
            return true;
        }

        private bool saveGameBinary(string FileName)
        {
            try
            {
                using (BinaryWriter writer = new(File.Open(FileName + ".gol", FileMode.Create)))
                {
                    writer.Write("GOLB".ToCharArray());
                    writer.Write((byte)Field.GetLength(0));
                    writer.Write((byte)Field.GetLength(1));
                    BitArray bits = new BitArray(Field.GetLength(0) * Field.GetLength(1));
                    for (int row = 0; row < Field.GetLength(0); row++)
                    {
                        for (int col = 0; col < Field.GetLength(1); col++)
                        {
                            bits[row * Field.GetLength(1) + col] = Field[row, col];
                        }
                    }
                    byte[] bytes = new byte[(bits.Length - 1) / 8 + 1];
                    bits.CopyTo(bytes, 0);
                    writer.Write(bytes);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        bool saveGameAscii(string FileName)
        {
            try
            {
                using (StreamWriter writer = new(FileName + ".gol"))
                {
                    writer.WriteLine("GOLA");// Game Of Life ASCII
                    writer.WriteLine(Field.GetLength(0));// Y
                    writer.WriteLine(Field.GetLength(1));// X
                    for (int row = 0; row < Field.GetLength(0); row++)
                    {
                        for (int col = 0; col < Field.GetLength(1); col++)
                        {
                            writer.Write((Field[row, col] ? "1" : "0"));
                        }
                        writer.WriteLine();
                    }
                    writer.Write("Spielname und datum... demnächst vom nutzer befüllt");
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Loads a stored game from disk and initializes the game
        /// </summary>
        /// <param name="FileName">Full path, name and extension of file</param>
        /// <returns>True if game loads successfully, otherwise false.</returns>
        bool loadGameAscii(string FileName)
        {
            using (StreamReader reader = new(FileName))
            {
                if (reader.ReadLine() != "GOLA") return false; // early exit,  testen ob wir das richtige format haben.

                if (!byte.TryParse(reader.ReadLine(), out byte Y)) return false;
                if (!byte.TryParse(reader.ReadLine(), out byte X)) return false;
                fieldFalse = new bool[Y, X];
                fieldTrue = new bool[Y, X];
                activeField = false;
                for (int row = 0; row < Y; row++)
                {
                    string line = reader.ReadLine();
                    for (int col = 0; col < X; col++)
                    {
                        fieldFalse[row, col] = line[col] == '1';
                    }
                }
            }
            return true;
        }

        bool saveGameXML(string FileName)
        {
            StoredGame sg = new();
            List<List<bool>> convertedField = new();

            for (int row = 0; row < Field.GetLength(0); row++)
            {
                convertedField.Add(new List<bool>(Field.GetLength(1)));
                for (int col = 0; col < Field.GetLength(1); col++)
                {
                    convertedField[row].Add(Field[row, col]);
                }
            }

            sg.Field = convertedField;
            sg.Description = "New Savegame" + DateTime.Now.ToString();

            XmlSerializer serializer = new XmlSerializer(typeof(StoredGame));
            try
            {
                using (Stream file = new FileStream(FileName, FileMode.Create, FileAccess.Write))
                {
                    serializer.Serialize(file, sg);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static List<(string Name, bool FromDatabase)> GetAvailableGames()
        {
            List<string> fileNames = new();
            fileNames.AddRange(Directory.GetFiles(@".\", "*.xml"));
            fileNames.AddRange(Directory.GetFiles(@".\", "*.gol"));

            SQLiteConnectionStringBuilder builder = new();
            builder.Version = 3;
            builder.DataSource = "SaveGames.db";

            List<(string Name, bool FromDatabase)> result = new();

            foreach (var item in fileNames)
            {
                result.Add((item, false));
            }

            if (File.Exists(builder.DataSource))
            {
                using (SQLiteConnection connection = new(builder.ToString()))
                {
                    connection.Open();
                    SQLiteCommand command = connection.CreateCommand();
                    command.CommandText = "select Name from SaveGames order by Name asc;";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add((reader.GetString(0), true));
                        }
                    }
                }
            }

            return result;
        }
    }
}