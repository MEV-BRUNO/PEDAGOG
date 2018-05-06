using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Pedagog_MVC.Models
{
    public class Procjena_suradnje_ponav_uc
    {
        [Required]
        public int id_napredovanje { get; set; }
        [Required]
        public int id_procjena { get; set; }
        [Required]
        public string nastavnik { get; set; }
        [Required]
        public DateTime datum_razgovora { get; set; }
        [Required]
        public string biljeska { get; set; } //suradnja ponavljaca
    }
}