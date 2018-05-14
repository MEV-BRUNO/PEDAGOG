using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models
{
    public class Razrednik_procjena
    {

        [Required]
        public long id_procjena { get; set; }
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
        public int br_ucenika { get; set; }
        [Required]
        public int ucenici_pozitivni { get; set; }
        [Required]
        public string ucenici_nedovoljno { get; set; }
        [Required]
        public string ucenici_izostanci { get; set; }

        [Required]
        public string ucenici_mjere { get; set; }
        [Required]
        public string ucenici_roditelji { get; set; }

        [Required]
        public string predmet_malo_ocjena { get; set; }


    }
}