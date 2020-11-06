using System;
using System.Collections.Generic;
using System.Text;

namespace Objects
{
    /// <summary>
    /// Basisklasse für alle Autos, da keine Vererbung angegeben ist erbt es direkt von "Object"
    /// </summary>
    public sealed class Ferrari : Auto // sealed verhindert vererbung von dieser Klasse
    {
        void ZugriffstestA()
        {
            ReifenAnzahl = 4;
            SitzAnzahl = 2;
            //Ventile = 5; // funktioniert nicht da Ventile nicht mitvererbt wurde
        }

        public override void Identifikation() // override sagt das ich die Methode aus der Basisklasse ersetzen möchte
        {
            Console.WriteLine("Ich bin ein Ferrari");
        }

        public override void LichtAn()
        {
            throw new NotImplementedException(); //TODO: please implement
        }
    }

    // public class Maranello : Ferrari { } // nicht erlaubt da Ferrari sealed ist
}
