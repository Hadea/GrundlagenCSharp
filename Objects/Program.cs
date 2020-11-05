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
            
        }
    }

    /// <summary>
    /// Basisklasse für alle Autos, da keine Vererbung angegeben ist erbt es direkt von "Object"
    /// </summary>
    class Auto
    {
        public int ReifenAnzahl; // Andere klassen können darauf zugreifen und erben
        protected int SitzAnzahl; // "Fammiliengeheimnis" Vererbt an Child-Objekte, aber nicht von anderen klassen sichtbar
        private int Ventile; // "geheim" nur von der gleichen klasse sichtbar, keine vererbung.

        void ZugriffstestB()
        {
            ReifenAnzahl = 2;
            SitzAnzahl = 2;
            Ventile = 5; 
        }
    }

    /// <summary>
    /// Ferrari erbt von Auto, dabei werden nur Elemente übernommen die nicht private sind
    /// </summary>
    class Ferrari : Auto
    {
        void ZugriffstestA()
        {
            ReifenAnzahl = 2;
            SitzAnzahl = 2;
            //Ventile = 5; // funktioniert nicht da Ventile nicht mitvererbt wurde
        }
    }
}
