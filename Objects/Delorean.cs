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

        public void HiddenID()
        {
            Console.WriteLine("Delorean Hidden");
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

        public new void HiddenID() // mit dem new bestätigen wir das wir gewollt den gleichen methodennamen wie im delorean verwenden wollen
        {
            Console.WriteLine("TimeMashine Hidden");
        }
    }

    class TimeMashineSpezial : TimeMashine
    {
        // public override void ID() { } // nicht erlaubt, da ID in der Basisklasse "sealed" ist
    }
}
