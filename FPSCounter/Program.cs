using System;

namespace FPSCounter
{
    class Program
    {

        static void Main()
        {
            FPS fpsCounter = new FPS();
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Yellow;
            do
            {
                fpsCounter.Draw();
            } while (!Console.KeyAvailable);
        }
    }
}
