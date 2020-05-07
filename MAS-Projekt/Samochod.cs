using System;
using System.Collections.Generic;
using System.Text;

namespace MAS_Projekt
{
    class Samochod
    {
        private string _marka { get; set; }
        private string _model { get; set; }
        private int _rokProdukcji { get; set; }
        private string _krajPochodzenia { get; set; }
        
        private  Pracownik _pracownik;

        private List<FabrykaSamochod> _fabrykaSamochodList = new List<FabrykaSamochod>();

        private List<Czujnik> _czujnikList = new List<Czujnik>();
        public Samochod(string marka, string model, int rokProdukcji, string krajPochodzenia)
        {
            _marka = marka;
            _model = model;
            _rokProdukcji = rokProdukcji;
            _krajPochodzenia = krajPochodzenia;
            
        }
        public string getMarka()
        {
            return _marka;
        }
        public void setPracownik(Pracownik pracownik)
        {
            _pracownik = pracownik;
        }
        public Pracownik GetPracownik()
        {
            return _pracownik;
        }
        public void removePracowik(Pracownik pracownik)
        {
            _pracownik = pracownik;
        }
        public void addFabryka(FabrykaSamochod fabrykaSamochod)
        {
            if (_fabrykaSamochodList.Contains(fabrykaSamochod))
                return;
            if(fabrykaSamochod.GetSamochod() != this)
            {
                throw new Exception("Niepoprawne dane");
            }
            _fabrykaSamochodList.Add(fabrykaSamochod);
        }
        public void CreateCzujnik(string nazwa, string opis)
        {
            Czujnik czujnik = new Czujnik(nazwa, opis);
            _czujnikList.Add(czujnik);
            
        }
        public void ShowCzujnikList()
        {
            Console.WriteLine(this.ToString() + string.Join("", _czujnikList));
        }
        public override string ToString()
        {
            return Environment.NewLine+ "Marka " + _marka + " Model " + _model + " Rok produkcji " + _rokProdukcji + " KrajPochodzenia " + _krajPochodzenia;
        }
        private class Czujnik
        {
            private string _nazwa;
            private string _opis;

            public Czujnik(string nazwa, string opis)
            {
                _nazwa = nazwa;
                _opis = opis;
            }
            public override string ToString()
            {
                return Environment.NewLine + "Czujnik " + _nazwa + " " + _opis;
            }
        }
    }
   
}
