using System;
using System.Collections.Generic;
using System.IO;

namespace MAS_Projekt
{
    class Program
    {
        static void Main(string[] args)
        {
            //Asocjacja o licznościach "1 - *" 1 po stronie Pracownika * po stronie samochod (opiekuje się)
            Console.WriteLine("Asocjacja 1 - *");
            Samochod car0 = new Samochod("Audi", "A1", 2012, "PL");
            Samochod car1 = new Samochod("Audi", "A5", 2015, "PL");
            Samochod car2 = new Samochod("Honda", "S2000", 2004, "JP");
            Samochod car3 = new Samochod("Honda", "Civic", 2015, "PL");
            
            
            Pracownik pracownik0 = new Pracownik("Adam","Adamski","AdamAdamski","aa");
            Pracownik pracownik1 = new Pracownik("Bogdan","Bogdanski","BogdanBoganski","bb");
           
            try
            {
                pracownik0.addSamochod(car0);
                pracownik0.addSamochod(car1);
               
                pracownik1.addSamochod(car2);
                pracownik1.addSamochod(car3);

               // pracownik0.removeSamochod(car0);
                
            }
            catch(Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
            finally
            {
              Console.WriteLine(pracownik0);
              Console.WriteLine(pracownik1);
            }
            //Asocjacja z atrybutem, pomiedzy klasami Fabryka a Samochod, FabrykaSamochod ktory tworzy odpowiednie czesci dla danych samochodow
            Console.WriteLine();
            Fabryka fabryka1 = new Fabryka("Fabryka 1", "Aleje Jerozolimskie 129 - Warszawa");
            Fabryka fabryka2 = new Fabryka("Fabryka 2", "Tomcia Palucha 100 - Łodz");
            Fabryka fabryka3 = new Fabryka("Fabryka 3", "Dobra 13 - Chyrzyce");
            
            Console.WriteLine("Asocjacja z atrybutem");
            try
            {
                FabrykaSamochod fabrykaSamochod = new FabrykaSamochod(fabryka1, car0, "Kierownica", "Kierownica sportowa prosto dla Audioli");
                FabrykaSamochod fabrykaSamochod1 = new FabrykaSamochod(fabryka2, car1, "Fotele", "Fotele sportowe prosto dla Audioli");
                FabrykaSamochod fabrykaSamochod2 = new FabrykaSamochod(fabryka3, car2, "Body-kit", "Honda honda szybsza niz wyglada");
                //test czy dana para juz istnieje
                //FabrykaSamochod fabrykaSamochod3 = new FabrykaSamochod(fabryka1, car0, "Body-kit", "Honda honda szybsza niz wyglada");
                //testowanie polaczen danych fabryk z samochodami  
                FabrykaSamochod fabrykaSamochod4 = new FabrykaSamochod(fabryka1, car1, "Body-kit", "Audi szybsza niz wyglada");
                FabrykaSamochod fabrykaSamochod5 = new FabrykaSamochod(fabryka2, car0, "Fotele", "Audi szybsza niz wyglada");
                FabrykaSamochod fabrykaSamochod6 = new FabrykaSamochod(fabryka3, car0, "Body-kit", "Audi szybsza niz wyglada");

                Console.WriteLine(fabrykaSamochod);
                Console.WriteLine(fabrykaSamochod1);
                Console.WriteLine(fabrykaSamochod2);
                Console.WriteLine(fabrykaSamochod4);
                Console.WriteLine(fabrykaSamochod5);
                Console.WriteLine(fabrykaSamochod6);


            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
            Console.WriteLine();
            //Asocjaca kwaliwfikowna asocjacja midzy klasa Pracownik a Klient, jeden Pracownik obluguje wiele klientow, klienci maja przypisany odpowiedni login pracownika
            Console.WriteLine("Asocjacja Kwalikowana");
            Klient klient1 = new Klient("Marek", "Mostowiak","Markowskicompnay");
            Klient klient2 = new Klient("Robert", "Lewadnowski","Lewandowskicompany");
            Klient klient3 = new Klient("Michal", "Pazdan","Pazdancompany");

            Klient klient4 = new Klient("Adrzej", "Duda", "Dudacompany");
            Klient klient5 = new Klient("Barbara", "Nowicka", "NowickaCompany");
            Klient klient6 = new Klient("Aleksander", "Kwasniewski", "KwasniewskiCompany");

            try
            {
                klient1.addPracownikQualif(pracownik0);
                klient2.addPracownikQualif(pracownik0);
                klient3.addPracownikQualif(pracownik0);
                
                klient1.findPracownikQualif(pracownik0.GetLogin());
                klient2.findPracownikQualif(pracownik0.GetLogin());
                klient3.findPracownikQualif(pracownik0.GetLogin());
                
                Console.WriteLine(pracownik0.ShowKlient());
                
                Console.WriteLine();
                klient4.addPracownikQualif(pracownik1);
                klient5.addPracownikQualif(pracownik1);
                klient6.addPracownikQualif(pracownik1);
                Console.WriteLine(pracownik1.ShowKlient());
            
            }catch(Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
            //Kompozycja klasa Samochod posiada czujniki, realizwone przez klase wewnetrzną , zapewnia gdy zostanie usunieta Samochod rowniez zostanie usuniety czujnik
            car0.CreateCzujnik("nazwa", "opis");
            car0.CreateCzujnik("nazwaa", "opisss");
            car0.ShowCzujnikList();
        }
    }
}

