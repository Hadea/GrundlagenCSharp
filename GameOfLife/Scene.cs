using System;

namespace GameOfLife
{
    abstract class Scene
    {
        public abstract void Update();

        public abstract void Activate();
    }
}