using System;
using System.Collections.Generic;
using System.Text;

namespace MAS_Projekt
{
    class Klient
    {
        private string _imie;
        private string _nazwisko;
        private string _nazwaFirmy;

        private Dictionary<string, Pracownik> _pracownikQualif = new Dictionary<string, Pracownik>();

        public Klient(string imie, string nazwisko, string nazwaFirmy) 
        {
            _imie = imie;
            _nazwisko = nazwisko;
            _nazwaFirmy = nazwaFirmy;
            
        }
        public void addPracownikQualif(Pracownik pracownik)
        {
            if(!_pracownikQualif.ContainsKey(pracownik.GetLogin()))
            {
                _pracownikQualif.Add(pracownik.GetLogin(), pracownik);
                pracownik.addKlient(this);
            }
        }
        public Pracownik findPracownikQualif(string login)
        {
            if (!_pracownikQualif.ContainsKey(login))
            {
                throw new Exception("Unable to find a login " + login);
            }
            return _pracownikQualif.GetValueOrDefault(login);
        }
        public Dictionary<string,Pracownik> GetDictionary()
        {
            return _pracownikQualif;
        }

        public override string ToString()
        {
            return Environment.NewLine +  _imie + " " +_nazwisko + " " + _nazwaFirmy;
        }
    }
}
