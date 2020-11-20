using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Dateizugriff
{
    [Serializable] // Das Attribut sagt dem BinaryFormatter das diese Klasse seriaisiert werden kann.
    class Auto
    {
        public int Tempo;
        public string Name;
        [NonSerialized] public bool geheim; // Diese Variable wird nicht serialisiert, nach dem neu einlesen wird hier der Standardwert "false" stehen
    }

    // für den XML Serializer muss kein Attribut [Serializable] mit angegeben werden
    public class Hund // die Klasse muss für den XML Serializer public sein
    {
        public string Name;
        public byte Alter;
        public List<Bein> Beine; // es ist möglich objekte zu verschachteln
    }

    public class Bein // Bein muss public sein da diese Klasse innerhalb von Hund verwendet wird
    {
        public byte AnzahlKnochen;
    }

    class Program
    {
        static void Main()
        {
            //SaveAndLoadBinary();
            //SaveAndLoadXML();
            LoadText("Beispieltext.txt");
            //TODO: Direktes schreiben in eine Datei
            //TODO: Laufweiten-Kompression

        }

        /// <summary>
        /// Reads a file an prints it to the screen, then rereads it line by line
        /// </summary>
        /// <param name="FileName">Name of file to print on screen</param>
        static void LoadText(string FileName)
        {
            // liesst die gesamte datei ein und gibt sie auf die konsole aus
            using (var reader = new StreamReader(FileName))// datei wird geöffnet und ist innerhalb der klammern von using verfügbar. das using kümmert sich um das korrekte freigeben der ressourcen am ende.
            {
                string dateiinhalt = reader.ReadToEnd();// liesst die gesamte datei in einen einzigen string und speichert diesen.
                Console.WriteLine(dateiinhalt); // der gespeicherte string wird komplett auf die konsole ausgegeben.
            }

            Console.ReadLine(); // programmablauf unterbrechen bis ENTER gedrückt wurde
            Console.Clear(); // konsolenfenster leeren

            using (var reader = new StreamReader("Beispieltext.txt")) // öffnet eine datei zum lesen, das using kümmert sich um das zerstören.
            {
                string zeile; // soll gelesene zeilen zwischenlagern
                while ( (zeile = reader.ReadLine()) != null )// Liesst eine Zeile (bis zum enter) aus der Datei und speichert sie in der variable. sollte dabei aber NULL (ende der datei) gelesen werden beendet es die schleife.
                {
                    Console.WriteLine(zeile); // gibt die gelesene zeile aus.
                    Console.ReadKey(true);// wartet auf irgendeinen einen tastendruck.
                }
            }


        }

        /// <summary>
        /// Saves and loads an object of type Hund using XML
        /// </summary>
        static void SaveAndLoadXML()
        {
            Hund meinHund = new Hund(); // ein objekt vom typ hund wird im HEAP erstellt und die adresse in meinHund abgelegt.  (referenz)
            // befüllen der werte.
            meinHund.Alter = 5;
            meinHund.Name = "Wuffi";
            meinHund.Beine = new List<Bein>(); // ein hund hat als unterobjekt eine liste aus beinen, diese referenz muss natürlich auch befüllt werden.
            meinHund.Beine.Add(new Bein());
            meinHund.Beine.Add(new Bein());
            meinHund.Beine.Add(new Bein());
            meinHund.Beine.Add(new Bein());

            XmlSerializer formXML = new XmlSerializer(typeof(Hund)); //Der Serialisierer wird auf Objekte vom typ Hund festgelegt und erstellt.

            using (Stream datei = new FileStream("GespeicherterHund.xml", FileMode.Create, FileAccess.Write)) // Datei wird neu erstellt oder falls sie besteht ersetzt, diese datei wird dann mit schreibzugriff geöffnet.
            {
                formXML.Serialize(datei, meinHund); // schreibt das objekt meinHund in über den FileStream in die datei
            }

            Console.WriteLine("Hund gespeichert");

            Hund geladenerHund; // leere referenz für ein objekt vom typ Hund

            using (Stream datei = new FileStream("GespeicherterHund.xml", FileMode.Open, FileAccess.Read)) // öffnen der datei, falls sie nicht existiert kommt eine fehlermeldung. Es werden nur leserechte angefordert sodass auch andere programm problemlos gleichzeitig lesend zugreifen können
            {
                geladenerHund = (Hund)formXML.Deserialize(datei); // liesst das Objekt aus der datei, es muss dann noch zu Hund uminterpretiert werden und die adresse des objektes wird in der Variable abgelegt (referenz)
            }

            // vergleicht ob das gelesene und das original identisch sind.
            if (meinHund.Alter == geladenerHund.Alter &&
                meinHund.Beine.Count == geladenerHund.Beine.Count &&
                meinHund.Beine[3].AnzahlKnochen == geladenerHund.Beine[3].AnzahlKnochen)
            {
                Console.WriteLine("Hund wurde erfolgreich geladen");
            }
        }

        /// <summary>
        /// Saves and loads an object of type Hund using BinaryFormatter
        /// </summary>
        static void SaveAndLoadBinary()
        {
            Auto myCar = new Auto(); // ein objekt vom typ Auto wird erstellt und die arbeitsspeicheradresse in der variable myCar abgelegt.
            // befüllen des objektes
            myCar.Name = "Ferrari Maranello";
            myCar.Tempo = 320;
            myCar.geheim = true;

            BinaryFormatter formBin = new BinaryFormatter(); //starten des Formatters

            using (Stream myFileStream = new FileStream("GespeichertesAuto.bin", FileMode.Create, FileAccess.Write))// erstellen einer datei, falls bereits eine existiert wird diese überschrieben. diese Datei wird mit schreibzugriff geöffnet.
            {
                formBin.Serialize(myFileStream, myCar); //formatiert myCar und sendet das ergebnis an den FileStream welcher es in die Datei legt
            }

            Console.WriteLine("Das Auto wurde gespeichert");

            Auto meinGeladenesAuto; // neue leere referenz für ein objekt vom typ Auto
            using (Stream myFileStream = new FileStream("GespeichertesAuto.bin", FileMode.Open, FileAccess.Read)) // Datei wird mit lesezugriff geöffnet
            {
                meinGeladenesAuto = (Auto)formBin.Deserialize(myFileStream);// einlesen der datei und umformatieren in ein Object, dieses wird uminterpretiert als Auto sodass es in der vorher erstellten referenz gespeichert werden kann.
            }

            // tests ob das gladene Auto mit dem Original übereinstimmt.
            if (meinGeladenesAuto.Name == myCar.Name && meinGeladenesAuto.Tempo == myCar.Tempo)
            {
                Console.WriteLine("Das Auto wurde erfolgreich geladen {0}", meinGeladenesAuto.geheim);
            }
        }
    }
}
