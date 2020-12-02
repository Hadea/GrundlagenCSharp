using System; // wenn wir viele dinge aus dem Namespace System brauchen und keine lust haben jedes mal System davor zu schreiben
// ohne dieses using müssten wir Befehle mit vollem namen ansprechen: System.Console.WriteLine();
using System.Drawing;
using Microsoft.Win32.SafeHandles; // für SafeFileHandle
using System.Runtime.InteropServices; // enthält das Attribut DLLImport und lässt uns DLLs zur laufzeit laden
using System.IO;

namespace FPSCounter // unser eigener namespace FPSCounter
                     // dieser wird uns direkt bei Projekterstellung mitgeliefert damit wir uns keine gedanken um Namen machen müssen
                     // ohne namespace müssten wir darauf achten das niemand sonst unsere KlassenNamen auch verwendet.
{
    class Program // serienmässig mitgelieferte Klasse "Program" welche unsere static Main enthalten muss
    {
        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern SafeFileHandle CreateFile(
            string fileName,
            [MarshalAs(UnmanagedType.U4)] uint fileAccess,
            [MarshalAs(UnmanagedType.U4)] uint fileShare,
            IntPtr securityAttributes,
            [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
            [MarshalAs(UnmanagedType.U4)] int flags,
            IntPtr template);


        [DllImport("Kernel32.dll", SetLastError = true)]
        static extern bool WriteConsoleOutput(
          SafeFileHandle hConsoleOutput,
          CharInfo[] lpBuffer,
          Coord dwBufferSize,
          Coord dwBufferCoord,
          ref SmallRect lpWriteRegion);

        public static CharInfo[] ScreenBuffer = new CharInfo[80 * 25];


        static void Main() // static bedeutet das diese methode auf Klassenebene ist, also keinem einzelnen
                           // Objekt direkt zugeordnet ist. Name muss so gewählt sein da windows sonst nicht weiss wo es beginnen
                           // muss
        {

            SafeFileHandle handle = CreateFile("CONOUT$", 0x40000000, 2, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);

            if (handle.IsInvalid)
            {
                Console.WriteLine("Konnte kein Handle für die Konsole bekommen :(");
                return;
            }

            SmallRect screenRectangle = new SmallRect(0, 80, 0, 25);
            Coord topLeft = new Coord { X = 0, Y = 0 };
            Coord bottomRight = new Coord { X = 80, Y = 25 };


            FPS fpsCounter = new FPS();
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Yellow;
            TextBox tbTest = new TextBox(new Point(2, 2), ConsoleColor.Red);
            DVD dvd = new DVD();
            ConsoleKey key = ConsoleKey.Attention;
            do
            {
                fpsCounter.Draw();
                //tbTest.Draw();
                dvd.Draw();

                WriteConsoleOutput(handle, ScreenBuffer, bottomRight, topLeft, ref screenRectangle);

                if (!Console.KeyAvailable) continue;
                // code only processed when a key is down
                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        break;
                    case ConsoleKey.DownArrow:
                        break;
                    case ConsoleKey.Enter:
                        break;
                    default:
                        tbTest.ProcessKey(key);
                        break;
                }

            } while (key != ConsoleKey.Escape);
            Console.ResetColor();
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Coord
    {
        public short X;
        public short Y;
    };

    [StructLayout(LayoutKind.Explicit)]
    public struct CharUnion
    {  //   0 1
        [FieldOffset(0)] public char UnicodeChar;
        [FieldOffset(0)] public byte AsciiChar;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct CharInfo
    {
        [FieldOffset(0)] public CharUnion Char;
        [FieldOffset(2)] public short Attributes;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SmallRect
    {
        public short Left;
        public short Top;
        public short Right;
        public short Bottom;

        public SmallRect(short pLeft, short pRight, short pTop, short pBottom)
        {
            Left = pLeft;
            Top = pTop;
            Right = pRight;
            Bottom = pBottom;
        }
    }

}
