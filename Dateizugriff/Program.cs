using System;
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

    public class Hund
    {
        public string Name;
        public byte Alter;
    }

    class Program
    {
        static void Main(string[] args)
        {
            SaveAndLoadXML();
        }

        static void SaveAndLoadXML()
        {
            Hund meinHund = new Hund();
            meinHund.Alter = 5;
            meinHund.Name = "Wuffi";

            XmlSerializer formXML = new  XmlSerializer(typeof(Hund));

            using (Stream datei = new FileStream("GespeicherterHund.xml", FileMode.Create, FileAccess.Write))
            {
                formXML.Serialize(datei, meinHund);
            }

            Console.WriteLine("Hund gespeichert");

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
