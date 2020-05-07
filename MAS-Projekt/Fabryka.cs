using System;
using System.Collections.Generic;
using System.Text;

namespace MAS_Projekt
{
    class Fabryka
    {
        private string _nazwa;
        private string _adres;

        private readonly List<FabrykaSamochod> _fabrykaSamochodList = new List<FabrykaSamochod>();
        public Fabryka(string nazwa, string adres)
        {
            _nazwa = nazwa;
            _adres = adres;
        }
        public void addSamochod(FabrykaSamochod fabrykaSamochod)
        {
            if (_fabrykaSamochodList.Contains(fabrykaSamochod))
                return;
            if(fabrykaSamochod.GetFabryka() != this)
            {
                throw new Exception("Nie poprwane dane");
            }
            _fabrykaSamochodList.Add(fabrykaSamochod);
        }

        public override string ToString()
        {
            return _nazwa + " " + _adres + " produkuje dla ";
        }
    }
}
