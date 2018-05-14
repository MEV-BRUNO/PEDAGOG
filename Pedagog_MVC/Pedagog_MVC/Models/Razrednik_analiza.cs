using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Pedagog_MVC.Models
{
    public class Razrednik_analiza
    {
        [Required]
        public long id_analiza { get; set; }
        [Required]
        public int id_pedagog { get; set; }
        [Required]
        public long id_nastavnik { get; set; }
        [Required]
        public int id_odjel { get; set; }
        [Required]
        public int godina { get; set; }
        [Required]
        public DateTime datum { get; set; }
        [Required]
        public int br_ucenika_m { get; set; }
        [Required]
        public int br_ucenika_z { get; set; }
        [Required]
        public int br_ucenika_prehrana { get; set; }
        [Required]
        public int br_ucenika_putnici { get; set; }
        [Required]
        public int br_ucenika_predstavnik { get; set; }
        [Required]
        public int br_ucenika_vrsnjacka { get; set; }
        [Required]
        public string ucenici_oblik_skolovanja { get; set; }
        [Required]
        public string ucenici_pokrenut { get; set; }
        [Required]
        public string ucenici_nadzor { get; set; }
        [Required]
        public string ucenici_ukljuceni { get; set; }
        [Required]
        public string ucenici_novi { get; set; }
        [Required]
        public string ucenici_mijenjaju { get; set; }
        [Required]
        public string ucenici_soci { get; set; }
        [Required]
        public string ucenici_bolest { get; set; }
        [Required]
        public string ucenici_jedan_roditelj { get; set; }
        [Required]
        public string ucenici_teski_uvjeti { get; set; }
        [Required]
        public string ucenici_branitelj { get; set; }
        [Required]
        public string ucenici_daroviti { get; set; }
        [Required]
        public string ucenici_izvanskolske { get; set; }
        [Required]
        public string ucenici_treba_pokrenut { get; set; }
    }
}