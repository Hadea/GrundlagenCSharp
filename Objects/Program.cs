using System;

namespace Objects
{
    class Program
    {
        static void Main(string[] args)
        {
            Auto CarA = new Auto();
            CarA.ReifenAnzahl = 5;

            Ferrari FerrA = new Ferrari();
            FerrA.ReifenAnzahl = 4;

            CarA.GibMirMalVentile();
            CarA.SetzeMalDieVentile(5);

            // CarA.Zylinder = 3; // kann nicht befüllt werden, da der setter privat ist
            Console.WriteLine(CarA.Zylinder);
        }
    }
}
