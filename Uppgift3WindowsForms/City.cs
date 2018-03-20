using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3WindowsForms
{
    class City
    {
        private string cityname;
        private int antalinvanarecity;
        private int medelinkomst;
        private int antalturisterar;
        private List<Accommodation> accommodations;
        private int accommodationscount;
        private double medelkostnad;

        //Konstruktor
        public City(string CityName
            , int AntalInvanareCity
            , int AntalTuristerAr
            , List<Accommodation> Accommodations)

        {
            cityname = CityName;
            antalinvanarecity = AntalInvanareCity;
            antalturisterar = AntalTuristerAr;
            medelinkomst = antalinvanarecity * antalturisterar;
            accommodations = Accommodations;
            accommodationscount=accommodations.Count;
            medelkostnad = accommodations.Average(x => x.Price);
           
        }

        //Getters och setters
        public string Name { get => cityname; set => cityname = value; }
        public int Antalinvanare { get => antalinvanarecity; set => antalinvanarecity = value; }
        public int Medelinkomst { get => medelinkomst; set => medelinkomst = value; }
        public int Antalturisterar { get => antalturisterar; set => antalturisterar = value; }
        public int Accommodationscount { get => accommodationscount; set => accommodationscount = value; }
        public double Medelkostnad { get => medelkostnad; set => medelkostnad = value; }
        internal List<Accommodation> Accommodations { get => accommodations; set => accommodations = value; }
    }
}
