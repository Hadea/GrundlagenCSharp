using System;

namespace Objects
{
    // Ein interface sagt das eine Klasse gemeinsame fähigkeiten hat mit einer anderen. Das Interface stellt dabei sicher
    // das alle Klassen sich genauestens an diese Methodensignaturen halten müssen.
    // Die anwender der Klassen können sich dann darauf verlassen das Methoden existieren und aufgerufen werden können,
    // selbst wenn nicht genau klar ist welche Klasse es ist.
    interface IDrawable
    {
        public void Draw();// Jede Klasse die IDrawable implementieren will muss exakt diese Methode haben, ohne abweichung.
    }


    // Die Klasse Grid erbt (abgesehen von Object) von keiner anderen Klasse, implementiert aber zwei Interfaces
    // Diese Interfaces legen fest welche Methoden erstellt werden müssen damit sich der Benutzer der Klasse
    // darauf verlassen kann das sie auch existieren wenn er nicht genau weiss welche Klasse es ist.
    class Grid : IDrawable, IDisposable
    {
        public void Dispose()// exakte Übereinstimmung wie in IDisposable definiert.
        {
            // inhalt muss erstellt werden
            throw new NotImplementedException();
        }

        public void Draw() // exakte Übereinstimmung wie in IDrawable definiert
        { 
            throw new NotImplementedException();
        }
    }

    // Vererbung: "is a" beziehung, Delorean is a Car
    // Interface: "can do" beziehung, Grid can do Draw

}
