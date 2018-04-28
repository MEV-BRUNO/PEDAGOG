using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models
{
    public class Razrednik_analiza
    {
        public long id_analiza { get; set; }
        public int id_pedagog { get; set; }
        public long id_nastavnik { get; set; }
        public int id_odjel { get; set; }
        public int godina { get; set; }
        public DateTime datum { get; set; }
        public int br_ucenika_m { get; set; }
        public int br_ucenika_z { get; set; }
        public int br_ucenika_prehrana { get; set; }
        public int br_ucenika_putnici { get; set; }
        public int br_ucenika_predstavnik { get; set; }
        public int br_ucenika_vrsnjacka { get; set; }
        public string ucenici_oblik_skolovanja { get; set; }
        public string ucenici_pokrenut { get; set; }
        public string ucenici_nadzor { get; set; }
        public string ucenici_ukljuceni { get; set; }
        public string ucenici_novi { get; set; }
        public string ucenici_mijenjaju { get; set; }
        public string ucenici_soci { get; set; }
        public string ucenici_bolest { get; set; }
        public string ucenici_jedan_roditelj { get; set; }
        public string ucenici_teski_uvjeti { get; set; }
        public string ucenici_branitelj { get; set; }
        public string ucenici_daroviti { get; set; }
        public string ucenici_izvanskolske { get; set; }
        public string ucenici_treba_pokrenut { get; set; }
    }
}