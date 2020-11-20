using System;

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
        }

        public GameLogic()
        {
            fieldFalse = new bool[20, 30];
            fieldTrue = new bool[20, 30];
            activeField = false;

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



                    if (fieldFalse[Y, X])
                    {
                        // lebender bereich
                        // wenn weniger als 2 lebende angrenzen auf tot setzen
                        // wenn mehr als 3 lebende angrenzen auf tot setzen

                    }
                    else
                    {
                        // toter bereich
                        // wenn exakt 3 lebende angrenzen auf lebend setzen

                    }
                }
            }




        }
    }
}