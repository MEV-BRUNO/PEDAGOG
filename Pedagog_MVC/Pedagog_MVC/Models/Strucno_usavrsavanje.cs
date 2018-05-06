using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models
{
    public class Strucno_usavrsavanje
    {
        [Required]
        public long id_usavrsavanje { get; set; }
        [Required]
        public int id_pedagog { get; set; }
        [Required]
        public int godina { get; set; }
        [Required]
        public DateTime datum { get; set; }
        [Required]
        public string naslov { get; set; }
        [Required]
        public string cilj { get; set; }
        [Required]
        public string namjena { get; set; }
        [Required]
        public string nacina_rada { get; set; }
        [Required]
        public string br_sudionika { get; set; }
        [Required]
        public string modul_1_opis { get; set; }
        [Required]
        public string modul_1_vrijeme { get; set; }
        [Required]
        public string modul_2_opis { get; set; }
        [Required]
        public string modul_2_vrijeme { get; set; }
        [Required]
        public string modul_3_opis { get; set; }
        [Required]
        public string modul_3_vrijeme { get; set; }
        [Required]
        public string biljeska { get; set; }

    }
}