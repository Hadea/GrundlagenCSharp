using System;
using System.Collections.Generic;

namespace GameOfLife
{
    class Program
    {
        public static Stack<Scene> Scenes = new();

        static void Main()
        {
            Scenes.Push(new Intro());

            do
            {
                Scenes.Peek().Update();
            } while (Scenes.Count > 0);
        }

    }
}
