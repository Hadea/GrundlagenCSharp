using System;

namespace FPSCounter
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
            if ((DateTime.Now - lastUpdate).TotalMilliseconds >= 1000)
            {
                char[] output = $"{framesSinceLastUpdate} fps".ToCharArray();
                for (int counter = 0; counter < output.Length; counter++)
                {
                    Program.ScreenBuffer[counter].Char.UnicodeChar = output[counter];
                    Program.ScreenBuffer[counter].Attributes = (byte)COLOR.YELLOW_TEXT;
                }
                framesSinceLastUpdate = 0;
                lastUpdate = DateTime.Now;
            }
        }
    }
}
