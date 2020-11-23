using System;
using System.IO;
using System.Xml.Serialization;

namespace GameOfLife
{
    internal class GameLogic
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

        void SetValue(int X, int Y, bool value)
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

        public GameLogic()
        {
            fieldFalse = new bool[20, 30];
            fieldTrue = new bool[20, 30];
            activeField = false;


            Reset();
        }

        private void Reset()
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
                        if (GetLivingCount(X, Y) is < 2 or > 3) //C# 9 vergleich mit zwei bedingungen
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
                        if (GetLivingCount(X, Y) == 3)
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

        private int GetLivingCount(int x, int y)
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
            if (! File.Exists(FileName))
            {
                return false;
            }

            XmlSerializer serializer = new(typeof(StoredGame));
            StoredGame sg;

            using (Stream file = new FileStream(FileName, FileMode.Open, FileAccess.Read))
            {
                sg = (StoredGame)serializer.Deserialize(file);
            }
            fieldFalse = sg.Field;

            return true;
        }

        public bool SaveGame(string FileName)
        {
            StoredGame sg = new();
            sg.Field = Field;
            sg.Description = "New Savegame" + DateTime.Now.ToString();

            XmlSerializer serializer = new(typeof(StoredGame));

            using (Stream file = new FileStream(FileName, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(file, sg);
            }
            return true; //TODO: immer true, exception abfangen und ggfs auf false returnen
        }

    }
}