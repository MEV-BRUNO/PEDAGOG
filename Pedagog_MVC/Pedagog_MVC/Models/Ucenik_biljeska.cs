using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models
{
    public class Ucenik_biljeska
    {
        [Required]
        public long id_biljeska { get; set; }
        [Required]
        public int id_pedagog { get; set; }
        [Required]
        public long id_ucenik { get; set; }
        [Required]
        public int godina { get; set; }
        [Required]
        public string inicijalni_podaci { get; set; }
        [Required]
        public DateTime datum_pocetak { get; set; }
        [Required]
        public string biljeska_1 { get; set; }
        [Required]
        public string biljeska_2 { get; set; }
        [Required]
        public string biljeska_3 { get; set; }
        [Required]
        public string biljeska_4 { get; set; }
        [Required]
        public string biljeska_5 { get; set; }
        [Required]
        public string biljeska_6 { get; set; }
        [Required]
        public string biljeska_7 { get; set; }
        [Required]
        public string biljeska_8 { get; set; }
        [Required]
        public string biljeska_9 { get; set; }
        [Required]
        public string biljeska_10 { get; set; }
        [Required]
        public string biljeska_11 { get; set; }
        [Required]
        public string biljeska_12 { get; set; }
        [Required]
        public string zakljucak { get; set; }
        [Required]
        public string zapazanja { get; set; }

    }
}