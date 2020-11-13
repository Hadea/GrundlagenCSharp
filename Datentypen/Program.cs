using System;
using System.Collections.Generic;

namespace Datentypen
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Datentypen und Kontainter



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
            // MyEnum.A entspricht 1,  binär 0000_0001
            // MyEnum.B entspricht 2,  binär 0000_0010
            // beide Zahlen werden ODER verknüpft, also gesetzte bits aus beiden übernommen.
            // ergebnis ist 3, binär 0000_0011
            // dieses ergebnis wird als datentyp byte interpretiert und in der
            // variable AktiveOptionen abgelegt

            //////////////////////////////////////////////

            string Text = "Mein Text"; // Text mit einem NULL als verstecktes ende-zeichen
            char Buchstabe = 'B'; // 16Bit, ein einzelner Buchstabe
            string LeererString = ""; // Ein Text mit der länge 0

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

            LinkedList<byte> LinkedListOfByte = new LinkedList<byte>(); //erstellt eine LinkedList
            // dynamische länge, nicht hintereinander im RAM
            // Einfügen und löschen überall erlaubt
            // einzelne elemente aus der mitte der linked list lesen erfordert das vom anfang
            // element für element nach vorn gesprungen wird und ist daher langsam

            #endregion

            int A = 4;
            int B = 9;
            int AdditionsErgebnis = A + B; // 13
            int SubtraktionsErgebnis = A - B; // -5
            int DivisionsErgebnis = A / B; // 0
            int MultiplikationsErgebnis = A * B; // 36
            int ModuloErgebnis = A % B; // 4

            int IncrementErgebnisA = A++; // 4, A wird nach der Benutzung raufgezählt
            int IncrementErgebnisB = ++B; // 10, B wird vor der Benutzung raufgezählt


            /// Übung
            /// 
            int Alpha = 4;
            int Bravo = 6;

            // Alpha = 5
            // Bravo = 7
            //   11            4    +   7
            int ErgebnisA = Alpha++ + ++Bravo;

            int Charly = 4;
            int Delta = 6;

            // Charly= 6
            // Delta = 9
            //                  5    +    5     +  7      +   8          8
            int ErgebnisB = ++Charly + Charly++ + ++Delta + ++Delta + Delta++;

            int[] IntegerArray = new int[5]; // erstellt ein array mit 5 feldern vom typ int
            IntegerArray = new int[5] { 1, 2, 3, 4, 5 }; // initialisiert das array direkt mit werten

            Random rndGen = new Random(); // startet eine inztanz des Zufallsgenerators
            rndGen.NextBytes(ByteArray); // befüllt das ByteArray mit zufälligen zahlen.

            int[,] MehrdimensionalesIntArray = new int[4, 3];
            // Array der grösse 10 * 5. Jedes element ist vom typ int.
            // Den aufbau kann man sich wie eine Excel-Tabelle vorstellen. Zeilen und Spalten
            // über die Koordinaten können wir jedes element einzeln lesen und schreiben.
            // Diese werden fast immer in verbindung mit for-schleifen verwendet.
            // ein foreach wandert das gesamte array mit allen dimensionen durch.
            // Die reihenfolge: [0,0] , [0,1] , [0,2], [1,0], [1,1]  u.s.w.
            MehrdimensionalesIntArray[1, 1] = 9298421;
            // Das element von oben links (excel) gesehen ein nach links und einen nach unten
            // wird hier mit einem integer gefüllt.

            byte[][] JaggedArray = new byte[10][];
            // Jagged arrays sind eindimensionale arrays wo jedes element ein in diesem
            // array ein weiteres array ist. "Array of Byte Array"
            JaggedArray[0] = new byte[3]; // erstellt ein neues array mit 3 elementen und speichert den Ablageort im Array an Stelle 0
            JaggedArray[1] = new byte[2];
            JaggedArray[3] = new byte[10];
            // die Byte-Array welche in dem Obersten Array gelagert werden können dabei
            // eine unterschiedliche länge haben, da sich das oberste nur referenzen zu
            // Objekten vom Typ Byte-Array merkt.

            // verschachteln ist nicht nur bei arrays erlaubt
            List<List<byte>> JaggedList = new List<List<byte>>();
            // dies erstellt eine Liste in welcher Byte-Listen abelegt werden.
            List<byte[]> ListOfByteArrays = new List<byte[]>();
            List<LinkedList<List<string[]>>>[] VielZuVerschachtelt = new List<LinkedList<List<string[]>>>[20];
            // der verschachtelung sind keine grenzen gesetzt

        } // ende Main

        enum MyEnum // erstellt einen neuen Datentyp namens MyEnum welcher 4 gültige werte enthält
        {  // enum basiert standardmässig auf dem int und kann deshalb bis zu 4,29 Milliarden werte enthalten
            // wenn man die normale numerierung (ab 0 aufsteigend) nicht mag kann man auch Werte direkt eintragen
            A = 1, // A soll intern dem wert 1 entsprechen
            B = A*2, // B soll dem doppelten von A entsprechen, also 2
            C = B*2, // C soll dem doppelten von B entsprechen, also 4
            D = C*2
        }
    }
}
