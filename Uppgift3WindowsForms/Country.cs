using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3WindowsForms
{
    class Country
    {
        private string countrynamn;
        private int antalinvanarecountry;
        private int bnppercapita;
        private List<City> cities;

        //Kontruktor
        public Country(string CountryName, int AntalInvanareCountry, int BnpPerCapita, List<City> Cities)
        {
            countrynamn = CountryName;
            antalinvanarecountry = AntalInvanareCountry;
            bnppercapita = BnpPerCapita;
            cities = Cities;
        }

        //Getters och Setters
        public string CountryName { get => countrynamn; set => countrynamn = value; }
        public int AntalInvanareCountry { get => antalinvanarecountry; set => antalinvanarecountry = value; }
        public int BnpPerCapita { get => bnppercapita; set => bnppercapita = value; }
        internal List<City> Cities { get => cities; set => cities = value; }
    }
}
