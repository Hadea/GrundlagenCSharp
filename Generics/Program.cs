using System;
using System.Collections.Generic;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            GenAddition<int> meinIntGeneric = new GenAddition<int>();
            meinIntGeneric.VariableA = 5;

            GenAddition<byte> meinByteGeneric = new GenAddition<byte>();
            meinByteGeneric.VariableA = 5;

            GenAddition<string> meinStringGeneric = new GenAddition<string>();
            meinStringGeneric.VariableA = "dasdsad";

            GenericMethod<int>(meinIntGeneric.VariableA);

            GenericMethod<List<string>>(new List<string>());

            List<int> intList = new List<int> {0,1,2,3,4,5 };

            FuelleArray<int>(intList);

            List<long> longList = new List<long> { 1, 2, 3, 4, 5, 6, 7 };

            FuelleArray<long>(longList);

            foreach (var item in longList)
            {
                Console.Write(item + " ");
            }

        }

        static T GenericMethod<T>(T parameter)
        {
            return parameter;
        }

        static int Summe<T>(List<T> parameter)
        {
            return 0;
        }



        private static void FuelleArray<T>(List<T> pArray) where T : struct
        {
            Random r = new Random();

            List<T> intreference = (List<T>)Convert.ChangeType(pArray, typeof(List<T>));
            for (int i = 0; i < intreference.Count; i++)
            {
                intreference[i] = (T)Convert.ChangeType(r.Next(100), typeof(T));
            }


        }

    }
}
