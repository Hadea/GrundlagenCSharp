using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Console.SetCursorPosition(0, 0);
                Console.Write("{0,8} fps", framesSinceLastUpdate );
                framesSinceLastUpdate = 0;
                lastUpdate = DateTime.Now;
            }
        }
    }
}
