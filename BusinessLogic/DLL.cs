using System;

namespace BusinessLogic
{
    public class Auto
    {
        private int VarPrivate;
        protected int VarProtected;
        public int VarPublic;

        private void MethodPrivate() =>
            Console.WriteLine("Bin Privat");

        protected void MethodProtected() =>
            Console.WriteLine("Bin Protected");

        public bool MethodPublic()
        {
            Console.WriteLine("Bin Public");
            return true;
        }

        // internal besagt das nur diese DLL auf die methode zugreifen darf
        // innerhalb der DLL wird es wie public gehandhabt
        internal void MehodInternal() =>
            Console.WriteLine("Bin Internal");

    }

    public class Garage
    {
        Auto meinAuto;

        private void DoSomething()
        {
            meinAuto.VarPublic = 5;
            meinAuto.MehodInternal();// nur diese DLL
            meinAuto.MethodPublic();// alle dürfen
        }
    }
}
