using System;

namespace Sortieren
{
    class Program
    {
        static void Main()
        {
            int[] arrayDataA = new int[30000]; // erstellen des Ausgangsarrays
            arrayRandomFill(arrayDataA); // befüllen mit zufälligen werten

//            int[] arrayDataB = (int[])arrayDataA.Clone();// erstellen einer kopie des arrays
            //Array.Copy(arrayDataA, arrayDataB, arrayDataA.Length); // alternative zum kopieren

//            int[] warmUp = (int[])arrayDataA.Clone();
//            selectionSortOptimized(warmUp);

//            printArray(arrayDataA); // ausgabe des unsortierten arrays
            DateTime start = DateTime.Now;
            selectionSortNaiv(arrayDataA);// sortieren
            Console.WriteLine("Array sortiert nach {0} millisekunden", (DateTime.Now - start).TotalMilliseconds);
            //start = DateTime.Now;
            //selectionSortNaiv(arrayDataB);
            //Console.WriteLine("Array sortiert nach {0} millisekunden", (DateTime.Now - start).TotalMilliseconds);
            //printArray(arrayDataA); // ausgabe des nun sortierten arrays
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
    }
}
