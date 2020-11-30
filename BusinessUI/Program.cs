using System;
using BusinessLogic;

namespace BusinessUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Auto meinAuto = new Auto();

            // die anderen Variablen sind nicht sichtbar
            meinAuto.VarPublic = 5;

            meinAuto.MethodPublic();
            //meinAuto.MehodInternal();// geht nicht, da wir ausserhalb des DLL-Projektes sind
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
