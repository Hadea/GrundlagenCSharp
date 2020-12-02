using System;
using System.IO;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                using (Thrower thrower = new())
                {
                    thrower.MayThrow(); // könnte eine exception auslösen
                }
            }
            catch (FileNotFoundException ex) // code der nur für FileNotFound zuständig ist
            {
                Console.WriteLine("Da war eine Datei nicht vorhanden!");
                Console.WriteLine(ex.StackTrace);
            }
            catch (FileLoadException ex) // nur für FileLoad
            {
                Console.WriteLine("Datei konnte nicht geladen werden.");
                Console.WriteLine(ex.StackTrace);
            }
            catch (ZuVieleZahlenException ex)
            {
                Console.WriteLine("Zu viele Zahlen!");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            catch (Exception ex) // pokemon, gonna catch em all
            {
                Console.WriteLine("Unbekannter fehler, keine ahung was da schief gegangen ist");

                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally // code der immer aufgerufen werden muss, egal ob exception oder nicht
            {
                // sachen aufräumen, z.B. datenbanken dicht machen (wenn kein using verwendet wurde)
                // netzwerkverbindungen kappen
                Console.WriteLine("Finally, räume gerade auf");
            }

            Console.ReadLine();
        }
    }

    public class ZuVieleZahlenException : Exception
    {
        // meine eigene special Edition
        public string Message;
        public ZuVieleZahlenException()
        {
            Message = "Das waren zu viele Zahlen";
        }
    }

    public class Thrower : IDisposable
    {
        public void MayThrow()
        {
            throw new ZuVieleZahlenException();
            throw new FileNotFoundException();
        }

        public void Dispose()
        {
            Console.WriteLine("Dispose gerade das Objekt vom Typ Thrower");
        }
    }
}
