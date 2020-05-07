using System;
using System.Collections.Generic;
using System.Text;

namespace MAS_Projekt
{
    class Pracownik
    {
        private string _imie;
        private string _nazwisko;
        private string _login;
        private string _haslo; 

        private  readonly List<Samochod> _samochodList = new List<Samochod>();

        private readonly List<Klient> _klientList = new List<Klient>();

        private static List<string> _loginList = new List<string>();
        public Pracownik(string imie, string nazwisko, string login, string haslo)
        {
            if (_loginList.Contains(login))
            {
                throw new Exception("Podany login juz istnieje");
            }
            else
            {
                _imie = imie;
                _nazwisko = nazwisko;
                _login = login;
                _haslo = haslo;
                _loginList.Add(login);
            }
        }
        public void addSamochod(Samochod samochod)
        {
            if (_samochodList.Contains(samochod))
                return;
            if(!(samochod.GetPracownik() == null || samochod.GetPracownik() == this))
            {
                throw new Exception("Inny pracownik jest juz przypisany do samochodu");
            }
            else
            {
                _samochodList.Add(samochod);
               samochod.setPracownik(this);
            }
            
                           
        }
        public void removeSamochod(Samochod samochod)
        {
            if (_samochodList.Contains(samochod))
            {
                _samochodList.Remove(samochod);
                samochod.removePracowik(this);
            }
            else
            {
                Console.WriteLine("Brak samochodu na lisce, nie ma czego usunac");
            }
        }
        public string GetLogin()
        {
            return _login;
        }
        public void addKlient(Klient klient)
        {
            if (_klientList.Contains(klient))
                return;
            if (!(klient.GetDictionary().ContainsKey(_login)))
            {
                throw new Exception("Klient juz zostal przypisany.");
            }
            _klientList.Add(klient);
            klient.addPracownikQualif(this);
        }
        
        public string ShowKlient()
        {
            return "Pracownik " +_imie + " " +_nazwisko + " opiekuje się "+string.Join("",_klientList);
        }
        public override string ToString()
        {
            return "Pracownik " +_imie + " " + _nazwisko +" " + "opiekuje sie " + string.Join("",_samochodList);
        }
       
    }
}
