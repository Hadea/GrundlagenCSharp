using System;
using System.Collections.Generic;
using System.Linq;

namespace Sortieren
{
    class Program
    {
        static void Main()
        {
            int[] arrayDataA = new int[30000]; // erstellen des Ausgangsarrays
            arrayRandomFill(arrayDataA); // befüllen mit zufälligen werten
            byte[] buffer = new byte[10000000];
            Random rnd = new Random();
            rnd.NextBytes(buffer);
            //foreach (var item in buffer) Console.Write(" " + item);
            Console.WriteLine();
            //            int[] arrayDataB = (int[])arrayDataA.Clone();// erstellen einer kopie des arrays
            //Array.Copy(arrayDataA, arrayDataB, arrayDataA.Length); // alternative zum kopieren

            //            int[] warmUp = (int[])arrayDataA.Clone();
            //            selectionSortOptimized(warmUp);

            //            printArray(arrayDataA); // ausgabe des unsortierten arrays
            DateTime start = DateTime.Now;
            //selectionSortNaiv(arrayDataA);// sortieren
            //Console.WriteLine("Array sortiert nach {0} millisekunden", (DateTime.Now - start).TotalMilliseconds);
            //start = DateTime.Now;
            //selectionSortNaiv(arrayDataB);
            //Console.WriteLine("Array sortiert nach {0} millisekunden", (DateTime.Now - start).TotalMilliseconds);
            //printArray(arrayDataA); // ausgabe des nun sortierten arrays

            //MergeSortScratch(buffer);// sortieren
            //IndexedSort(buffer);
            //buffer = MergeSortWithoutRecursion(buffer);
            Array.Sort(buffer);
            Console.WriteLine("Array sortiert nach {0} millisekunden", (DateTime.Now - start).TotalMilliseconds);
            //foreach (var item in buffer) Console.Write(" " + item);
            Console.ReadLine();
        }

        static void printArray(int[] ArrayToPrint)
        {
            foreach (int item in ArrayToPrint)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        static void arrayRandomFill(int[] ArrayToFill)
        {
            Random rndGen = new Random(); // erstellen eines zufallsgenerators
            for (int counter = 0; counter < ArrayToFill.Length; counter++) // das übergebene array von anfang bis ende durchlaufen
            {
                ArrayToFill[counter] = rndGen.Next(100);// den aktuellen eintrag auf eine frisch generierte zufallszahl setzen
            }
        }

        static void selectionSortNaiv(int[] ArrayToSort)
        {
            //TODO: Äusserer zähler kann bereits ein element früher aufhören
            //TODO: Innerer zähler kann ein element später anfangen
            //TODO: Anstatt sofort zu tauschen nur die position der kleineren Zahl merken, nach dem durchlauf der inneren tauschen
            for (int outer = 0; outer < ArrayToSort.Length; outer++)// zählen von 0 solange kleiner als Arraylänge
            {
                for (int inner = outer; inner < ArrayToSort.Length; inner++)//zählen von äuserem zählerstand solange kleiner als Arraylänge
                {
                    if (ArrayToSort[outer] > ArrayToSort[inner])//wenn zahl an position des äusseren zählers grösser als die des inneren zählers
                    {
                        int backup = ArrayToSort[inner];// zahl an innerer position sichern
                        ArrayToSort[inner] = ArrayToSort[outer];// zahl an äusserer an position der inneren speichern
                        ArrayToSort[outer] = backup;// gesicherte an äusserer position speichern
                    }//ende wenn
                }// ende zählen
            }// ende zählen 
        }
        static void selectionSortOptimized(int[] ArrayToSort)
        {
            //TODO: Äusserer zähler kann bereits ein element früher aufhören
            //TODO: Innerer zähler kann ein element später anfangen
            //TODO: Anstatt sofort zu tauschen nur die position der kleineren Zahl merken, nach dem durchlauf der inneren tauschen

            int inner;
            int smallestID;
            for (int outer = 0; outer < ArrayToSort.Length - 1; outer++)// zählen von 0 solange kleiner als Arraylänge
            {
                smallestID = outer;
                for (inner = outer + 1; inner < ArrayToSort.Length; inner++)//zählen von äuserem zählerstand solange kleiner als Arraylänge
                {
                    if (ArrayToSort[smallestID] > ArrayToSort[inner])//wenn zahl an position des äusseren zählers grösser als die des inneren zählers
                    {
                        smallestID = inner;
                    }//ende wenn
                }// ende zählen
                if (outer != smallestID)
                {
                    int backup = ArrayToSort[smallestID];// zahl an innerer position sichern
                    ArrayToSort[smallestID] = ArrayToSort[outer];// zahl an äusserer an position der inneren speichern
                    ArrayToSort[outer] = backup;// gesicherte an äusserer position speichern
                }
            }// ende zählen 
        }

        static byte[] MergeSort(byte[] ArrayToSort)
        {
            // ########  DIVIDE  #########

            if (ArrayToSort.Length == 1) return ArrayToSort;

            byte[] linkeSeite = MergeSort(ArrayToSort.Take(ArrayToSort.Length / 2).ToArray());
            byte[] rechteSeite = MergeSort(ArrayToSort.Skip(ArrayToSort.Length / 2).ToArray());

            // ########  CONQUER  ########

            int linkerZeiger = 0;
            int rechterZeiger = 0;
            int ergebnisZeiger = 0;

            byte[] ergebnis = new byte[linkeSeite.Length + rechteSeite.Length];
            while (linkerZeiger < linkeSeite.Length && rechterZeiger < rechteSeite.Length)
            {
                if (rechteSeite[rechterZeiger] < linkeSeite[linkerZeiger])
                    ergebnis[ergebnisZeiger++] = rechteSeite[rechterZeiger++];
                else
                    ergebnis[ergebnisZeiger++] = linkeSeite[linkerZeiger++];
            }

            while (linkerZeiger < linkeSeite.Length)
                ergebnis[ergebnisZeiger++] = linkeSeite[linkerZeiger++];

            while (rechterZeiger < rechteSeite.Length)
                ergebnis[ergebnisZeiger++] = rechteSeite[rechterZeiger++];

            return ergebnis;
            // solange linkerZähler kleiner als linkelänge und rechterZähler kleiner als rechtelänge
            //      wenn element im rechten array an position des rechten zeigers kleiner ist als
            //           der wert im linken array an position des linken zeigers
            //          rechtes element in das ergebnisarray an position des ergebnisZeigers kopieren
            //      andernfalls
            //          linkes element in das ergebnisarray an position des ergebnisZeigers kopieren
            //      ende wenn
            //      ergebniszeiger um 1 erhöhen
            // ende solange

            // solange linkerZähler kleiner als linkeLänge
            //      linkes element in das ergebnisarray an position des ergebniszeigers kopieren
            //      ergebniszeiger um 1 erhöhen
            // ende solange

            // solange rechterZähler kleiner als rechteLänge
            //      rechtes element in das ergebnisarray an position des ergebniszeigers kopieren
            //      ergebniszeiger um 1 erhöhen
            // ende solange

            // ergebnisarray zurückgeben (falls mit return gearbeitet wurde)
        }

        static void MergeSortScratch(byte[] ArrayToSort)
        {
            //MergeSortScratchWorker(ArrayToSort, new byte[ArrayToSort.Length], 0, ArrayToSort.Length - 1);
            MergeSortScratchWorkerLinear(ArrayToSort, new byte[ArrayToSort.Length]);
        }

        static void MergeSortScratchWorker(byte[] ArrayToSort, byte[] ScratchArray, int FirstElementId, int LastElementId)
        {
            if (FirstElementId == LastElementId) return;

            int splitpoint = (LastElementId - FirstElementId) / 2 + FirstElementId;

            MergeSortScratchWorker(ArrayToSort, ScratchArray, FirstElementId, splitpoint);
            MergeSortScratchWorker(ArrayToSort, ScratchArray, splitpoint + 1, LastElementId);

            int linkerZeiger = FirstElementId;
            int rechterZeiger = splitpoint + 1;
            int ergebniszeiger = FirstElementId;

            while (linkerZeiger <= splitpoint && rechterZeiger <= LastElementId)
            {
                if (ArrayToSort[rechterZeiger] < ArrayToSort[linkerZeiger])
                    ScratchArray[ergebniszeiger++] = ArrayToSort[rechterZeiger++];
                else
                    ScratchArray[ergebniszeiger++] = ArrayToSort[linkerZeiger++];
            }

            while (linkerZeiger <= splitpoint)
                ScratchArray[ergebniszeiger++] = ArrayToSort[linkerZeiger++];

            while (rechterZeiger <= LastElementId)
                ScratchArray[ergebniszeiger++] = ArrayToSort[rechterZeiger++];

            for (int counter = FirstElementId; counter <= LastElementId; counter++)
                ArrayToSort[counter] = ScratchArray[counter];
        }

        static void MergeSortScratchWorkerLinear(byte[] ArrayToSort, byte[] ScratchArray)
        {
            int stride = 2;

            while (stride*2 < ArrayToSort.Length) //todo ende checken
            {
                for (int counter = 0; counter < ArrayToSort.Length; counter+= stride)//todo ende benötigt einen weiteren durchlauf
                {
                    if (counter + stride/ 2 > ArrayToSort.Length-1)
                    {
                        break;
                    }

                    int splitpoint = counter + stride / 2;
                    int linkerZeiger = counter;
                    int rechterZeiger = (splitpoint < ArrayToSort.Length ? splitpoint+1: ArrayToSort.Length-1);
                    int ergebniszeiger = counter;
                    int LastElementId = (counter + stride < ArrayToSort.Length ? counter + stride : ArrayToSort.Length - 1);

                    while (linkerZeiger <= splitpoint && rechterZeiger <= LastElementId)
                    {
                        if (ArrayToSort[rechterZeiger] < ArrayToSort[linkerZeiger])
                            ScratchArray[ergebniszeiger++] = ArrayToSort[rechterZeiger++];
                        else
                            ScratchArray[ergebniszeiger++] = ArrayToSort[linkerZeiger++];
                    }

                    while (linkerZeiger <= splitpoint)
                        ScratchArray[ergebniszeiger++] = ArrayToSort[linkerZeiger++];

                    while (rechterZeiger <= LastElementId)
                        ScratchArray[ergebniszeiger++] = ArrayToSort[rechterZeiger++];

                    for (int cnt = counter; cnt <= LastElementId; cnt++)
                        ArrayToSort[cnt] = ScratchArray[cnt];

                }
                stride *= 2;
            }
        }

        /// <summary>
        /// By Tobias
        /// </summary>
        /// <param name="ArrayToSort"></param>
        static void IndexedSort(byte[] ArrayToSort)
        {
            int[] sortedArrayIndex = new int[256];

            for (int i = 0; i < ArrayToSort.Length; i++)
            {
                sortedArrayIndex[ArrayToSort[i]]++; // no need
            }

            int writerID = 0;
            for (short ListCounter = 0; ListCounter < sortedArrayIndex.Length; ListCounter++)
            {
                for (int ElementCounter = 0; ElementCounter < sortedArrayIndex[ListCounter]; ElementCounter++)
                {
                    ArrayToSort[writerID++] = (byte)ListCounter;
                }
            }
        }



        /// <summary>
        /// by Frederic
        /// </summary>
        /// <param name="ArrayLength"></param>
        /// <param name="NewArrayLength"></param>
        /// <returns></returns>
        static bool GetNextPow(int ArrayLength, out int NewArrayLength)
        {
            NewArrayLength = 1;

            while (NewArrayLength < ArrayLength) NewArrayLength <<= 1;

            return NewArrayLength != ArrayLength ? true : false;
        }

        /// <summary>
        /// by Frederic
        /// </summary>
        /// <param name="ArrayToSort"></param>
        /// <returns></returns>
        static byte[] MergeSortWithoutRecursion(byte[] ArrayToSort)
        {
            int methodCount = 1;
            int Schrittlänge;
            int linkerCounter;
            int rechterCounter;
            int gesamtCounter;
            int OriginalLength = ArrayToSort.Length;                            //speichern der Original-Länge des übergebenen Arrays

            byte[] MergedArray;

            if (GetNextPow(OriginalLength, out int NewLength))
            {
                Array.Resize(ref ArrayToSort, NewLength);                       //die Länge des übergebenen Arrays auf neue Länge setzen
                //da das alte Array mit der neuen Länge hinten mit 0 aufgefüllt wird...
                for (int counter = OriginalLength; counter < ArrayToSort.Length; counter++)
                {
                    ArrayToSort[counter] = byte.MaxValue;                       //...alle hinzugefügten Nullen mit 255 ersetzen
                }
            }

            MergedArray = new byte[ArrayToSort.Length];
            ArrayToSort.CopyTo(MergedArray, 0);                                 //Kopie des Arrays in ein Zwischenlager

            while (methodCount < ArrayToSort.Length)
            {
                gesamtCounter = 0;
                Schrittlänge = 2 * methodCount;
                for (int ArrayPosition = 0; ArrayPosition < ArrayToSort.Length; ArrayPosition += Schrittlänge)
                {
                    linkerCounter = ArrayPosition;
                    rechterCounter = ArrayPosition + Schrittlänge / 2;

                    while (linkerCounter != (ArrayPosition + Schrittlänge / 2)
                        && rechterCounter != (ArrayPosition + Schrittlänge))
                    {
                        if (ArrayToSort[linkerCounter] < ArrayToSort[rechterCounter])
                        {
                            MergedArray[gesamtCounter++] = ArrayToSort[linkerCounter++];
                        }
                        else
                        {
                            MergedArray[gesamtCounter++] = ArrayToSort[rechterCounter++];
                        }
                    }

                    while (linkerCounter < ArrayPosition + Schrittlänge / 2)
                    {
                        MergedArray[gesamtCounter++] = ArrayToSort[linkerCounter++];
                    }

                    while (rechterCounter < ArrayPosition + Schrittlänge)
                    {
                        MergedArray[gesamtCounter++] = ArrayToSort[rechterCounter++];
                    }
                }

                methodCount <<= 1;
                MergedArray.CopyTo(ArrayToSort, 0);
            }

            Array.Resize(ref ArrayToSort, OriginalLength);
            return ArrayToSort;
        }
    }
}
