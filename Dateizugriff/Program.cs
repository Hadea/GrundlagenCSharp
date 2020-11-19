using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Dateizugriff
{
    [Serializable]
    class Auto
    {
        public int Tempo;
        public string Name;
        [NonSerialized] public bool geheim;
    }

    // für den XML Serializer muss kein Attribut [Serializable] mit angegeben werden
    public class Hund // die Klasse muss für den XML Serializer public sein
    {
        public string Name;
        public byte Alter;
        public List<Bein> Beine;
    }

    public class Bein
    {
        public byte AnzahlKnochen;
    }

    class Program
    {
        static void Main(string[] args)
        {
            //SaveAndLoadXML();
            LoadText();
        }

        static void LoadText()
        {
            // liesst die gesamte datei ein und gibt sie auf die konsole aus
            using (var reader = new StreamReader("Beispieltext.txt"))
            {
                string dateiinhalt = reader.ReadToEnd();
                Console.WriteLine(dateiinhalt);
            }

            Console.ReadLine();
            Console.Clear();

            using (var reader = new StreamReader("Beispieltext.txt"))
            {
                string zeile;
                while ( (zeile = reader.ReadLine()) != null )
                {
                    Console.WriteLine(zeile);
                    Console.ReadLine();
                }
            }


        }

        static void SaveAndLoadXML()
        {
            Hund meinHund = new Hund();
            meinHund.Alter = 5;
            meinHund.Name = "Wuffi";
            meinHund.Beine = new List<Bein>();
            meinHund.Beine.Add(new Bein());
            meinHund.Beine.Add(new Bein());
            meinHund.Beine.Add(new Bein());
            meinHund.Beine.Add(new Bein());

            XmlSerializer formXML = new XmlSerializer(typeof(Hund));

            using (Stream datei = new FileStream("GespeicherterHund.xml", FileMode.Create, FileAccess.Write))
            {
                formXML.Serialize(datei, meinHund);
            }

            Console.WriteLine("Hund gespeichert");

            Hund geladenerHund;

            using (Stream datei = new FileStream("GespeicherterHund.xml", FileMode.Open, FileAccess.Read))
            {
                geladenerHund = (Hund)formXML.Deserialize(datei);
            }

            if (meinHund.Alter == geladenerHund.Alter &&
                meinHund.Beine.Count == geladenerHund.Beine.Count &&
                meinHund.Beine[3].AnzahlKnochen == geladenerHund.Beine[3].AnzahlKnochen)
            {
                Console.WriteLine("Hund wurde erfolgreich geladen");
            }
        }

        static void SaveAndLoadBinary()
        {
            Auto myCar = new Auto();
            myCar.Name = "Ferrari Maranello";
            myCar.Tempo = 320;
            myCar.geheim = true;

            BinaryFormatter formBin = new BinaryFormatter();

            using (Stream myFileStream = new FileStream("GespeichertesAuto.bin", FileMode.Create, FileAccess.Write))
            {
                formBin.Serialize(myFileStream, myCar);
            }

            Console.WriteLine("Das Auto wurde gespeichert");

            Auto meinGeladenesAuto;
            using (Stream myFileStream = new FileStream("GespeichertesAuto.bin", FileMode.Open, FileAccess.Read))
            {
                meinGeladenesAuto = (Auto)formBin.Deserialize(myFileStream);
            }

            if (meinGeladenesAuto.Name == myCar.Name && meinGeladenesAuto.Tempo == myCar.Tempo)
            {
                Console.WriteLine("Das Auto wurde erfolgreich geladen {0}", meinGeladenesAuto.geheim);
            }
        }
    }
}
