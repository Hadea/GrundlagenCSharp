using System;

namespace FPSCounter
{
    class Program
    {
        class FPS
        {
            DateTime lastUpdate;
            uint framesSinceLastUpdate;

            public FPS()
            {
                lastUpdate = DateTime.Now;
                framesSinceLastUpdate = 0;
            }
            public void Draw()
            {
                framesSinceLastUpdate++;
                if ((DateTime.Now - lastUpdate).TotalMilliseconds >= 5000)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.Write("{0,8} fps", framesSinceLastUpdate/5);
                    framesSinceLastUpdate = 0;
                    lastUpdate = DateTime.Now;
                }
            }
        }

        static void Main(string[] args)
        {
            FPS fpsCounter = new FPS();
            Console.ForegroundColor = ConsoleColor.Yellow;
            do
            {
                fpsCounter.Draw();
            } while (!Console.KeyAvailable);
        }
    }
}
