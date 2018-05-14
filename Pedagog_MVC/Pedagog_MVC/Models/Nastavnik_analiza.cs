using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models
{
    public class Nastavnik_analiza
    {
        [Required]
        public long id_analiza { get; set; }
        [Required]
        public int id_pedagog { get; set; }
        [Required]
        public long id_nastavnik { get; set; }
        [Required]
        public int godina { get; set; }
        [Required]
        public DateTime datum { get; set; }
        [Required]
        public string nastavni_sat { get; set; }
        [Required]
        public string predmet { get; set; }
        [Required]
        public string cilj { get; set; }
        [Required]
        public string nastavna_jedinica { get; set; }
        [Required]
        public string vrsta_sata { get; set; }
        [Required]

        public string planiranje { get; set; }
        [Required]
        public string izvedba { get; set; }
        [Required]
        public string tijek { get; set; }
        [Required]
        public string ugodaj { get; set; }
        [Required]
        public string disciplina { get; set; }
        [Required]
        public string ocjena_napredovanja { get; set; }
        [Required]
        public string osvrt { get; set; }
        [Required]
        public string prijedlozi { get; set; }
        [Required]
        public string uvid { get; set; }
        [Required]
        public string zakljucak { get; set; }


    }
}