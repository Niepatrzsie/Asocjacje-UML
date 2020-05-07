using System;
using System.Collections.Generic;
using System.Text;

namespace MAS_Projekt
{
    class FabrykaSamochod
    {
        private string _czesc;
        private string _opis;
        private readonly Fabryka _fabryka;
        private readonly Samochod _samochod;

        private static readonly List<FabrykaSamochod> _fabrykaSamochodList = new List<FabrykaSamochod>();
        public FabrykaSamochod(Fabryka fabryka,Samochod samochod, string czesc, string opis)
        {
            if(fabryka == null)
            {
                throw new Exception("Fabryka nie moze byc null");
            }
            if(samochod == null)
            {
                throw new Exception("Samochod nie moze byc null");
            }
            foreach (FabrykaSamochod fabrykaSamochod in _fabrykaSamochodList)
            {
                if(fabrykaSamochod.GetFabryka() == fabryka && fabrykaSamochod.GetSamochod() == samochod)
                {
                    throw new Exception("Takie połaczenie juz istanieje");
                }
            }
            _fabryka = fabryka;
            _samochod = samochod;
            _czesc = czesc;
            _opis = opis;

            fabryka.addSamochod(this);
            samochod.addFabryka(this);
            
            _fabrykaSamochodList.Add(this);
        }
        public Fabryka GetFabryka()
        {
            return _fabryka;
        }
        public Samochod GetSamochod()
        {
            return _samochod;
        }

        
        public override string ToString()
        {
            return  _fabryka + _samochod.getMarka() + " czesc " + _czesc;
        }
    }
}
