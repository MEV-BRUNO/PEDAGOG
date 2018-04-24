using System;
namespace ProjektIdio.Models
{
    public class Ucenik
    {
        public Ucenik()
        { }
            public int ID_Ucenik { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Spol { get; set; }
        public DateTime Datum { get; set; }
        public string OIB { get; set; }
        public string Adresa { get; set; }
        public string Grad { get; set; }
            public string Biljeska { get; set; }
        }
    }

