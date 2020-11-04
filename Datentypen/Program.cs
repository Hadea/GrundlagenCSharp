using System;
using System.Collections.Generic;

namespace Datentypen
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("asdas");

            long Ganzzahl64Bit; // -9 Trillionen bis +9 Trillionen
            ulong Ganzzahl64BitPositiv; // 0 bis +18 Trillionen

            int Ganzzahl32Bit; // -2,14 Milliarden bis + 2,14 Milliarden
            uint Ganzzahl32BitPositiv; // 0 bis +4,29 Milliarden

            short Ganzzahl16Bit; // -32 tausden bis +32 tausend
            ushort Ganzzahl16BitPositiv; // 0 bis 65 tausend

            sbyte Ganzzahl8Bit; // -128 bis +127
            byte Ganzzahl8BitPositiv; // 0 bis 255

            /////////////////////////////////////////////

            float Gleitkommazahl32Bit; // ca 6 stellen genau
            double Gleitkommazahl64Bit; // ca 15 stellen genau
            decimal Gleitkommazahl128Bit; // ca 30 stellen

            /////////////////////////////////////////////

            bool JaOderNein; // exakt zwei werte. true (1) und false (0)

            //////////////////////////////////////////////

            byte AktiveOptionen = (byte)(MyEnum.A | MyEnum.D);

            //////////////////////////////////////////////

            string Text = "Mein Text"; // Text mit einem NULL als verstecktes ende-zeichen
            char Buchstabe = 'B'; // 16Bit
            string BuchstabeAlsString = ""; // Ein Text mit der länge 0

            //////////////////////////////////////////////
            
            byte[] ByteArray = new byte[20]; // erstellt ein Array von 20 byte, feste länge, immer hintereinander
            // 1. new wird aufgerufen mit dem Parameter byte[20], damit weiss new wieviel arbeitsspeicher
            //    benötigt wird und fordert diesen von dem Betriebssystem
            // 2. new startet den Konstruktor von dem frisch erstellten Objekt
            // 3. new endet mit einem return wert, welcher die arbeitsspeicheradresse des objektes enthält
            // 4. der Rückgabewert von new wird in der Variable ByteArray gespeichert

            List<byte> ListOfByte = new List<byte>(); // erstellt ein List-Objekt welches als kontainer für bytes
            // ausgelegt wurde. dynamische länge, immer hintereinander.
            // Fordert versteckt mehr arbeitsspeicher an als nötig damit elemente angefügt werden können.
            // Sollte der angeforderte RAM nicht reichen wird neuer Arbeitsspeicher in doppelter grösse angefordert,
            // die alten werte in den neuen bereich kopiert und der alte RAM freigegeben
            List<byte> ListOfThousendByte = new List<byte>(1024); //legt die anfangsgrösse des RAM fest
            // ListOfThousendByte.Count enthält die anzahl der elemente
            // ListOfThousendByte.Capacity enthält die grösse der Liste

            Console.WriteLine("Hello World!");
        } // ende Main

        enum MyEnum
        {
            A = 1,
            B = A*2,
            C = B*2,
            D = C*2
        }
    }
}
