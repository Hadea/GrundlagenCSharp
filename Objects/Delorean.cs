using System;
using System.Collections.Generic;
using System.Text;

namespace Objects
{
    class Delorean
    {
        public virtual void ID()
        {
            Console.WriteLine("Delorean");
        }
        
    }

    class TimeMashine : Delorean
    {
        /// <summary>
        /// "sealed" verhindert das diese Methode mit "override" überschrieben wird
        /// </summary>
        public sealed override void ID()
        {
            Console.WriteLine("TimeMashine");
        }
    }

    class TimeMashineSpezial : TimeMashine
    {
        // public override void ID() { } // nicht erlaubt, da ID in der Basisklasse "sealed" ist
    }
}
