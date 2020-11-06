using System;
using System.Collections.Generic;
using System.Text;

namespace Objects
{
    public partial class Auto
    {
        public int ReifenAnzahl; // Andere klassen können darauf zugreifen und erben
        protected int SitzAnzahl; // "Fammiliengeheimnis" Vererbt an Child-Objekte, aber nicht von anderen klassen sichtbar
        private int Ventile; // "geheim" nur von der gleichen klasse sichtbar, keine vererbung.

        private int SchreibCounter = 0;
        void ZugriffstestB()
        {
            ReifenAnzahl = 2;
            SitzAnzahl = 2;
            Ventile = 5;
            _zylinder = 7;

        }

        private int _hitpoints;

        public int Hitpoints
        {
            get { return _hitpoints; }
            set
            {
                _hitpoints = value;
                if (_hitpoints < 20)
                {
                    Zylinder--;
                }
            }
        }


        private int _zylinder;

        public int Zylinder
        {
            get { return _zylinder; }
            private set
            { // alle im netzwerk aktualisieren
                _zylinder = value;
            }
        }



        public int GibMirMalVentile()
        {
            return Ventile;
        }

        public void SetzeMalDieVentile(int NeueVentilanzahl)
        {
            SchreibCounter++;
            Ventile = NeueVentilanzahl;
        }
    }

}
