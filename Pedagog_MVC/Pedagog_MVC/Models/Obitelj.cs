using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace ProjektIdio.Models
{
    public class Obitelj
    {
        [Required]
        public int id_obitelj { get; set; }
        [Required]
        public long id_ucenik { get; set; }
        [Required]
        public string ime_prezime { get; set; }
        [Required]
        public int vrsta { get; set; }
        [Required]
        public string zanimanje { get; set; }
        [Required]
        public string tel { get; set; }
        [Required]
        public string mail { get; set; }
        [Required]
        public string adresa { get; set; }
        [Required]
        public string grad { get; set; }
        [Required]
        public string obrazovanje { get; set; }
        [Required]
        public string biljeska { get; set; }
    }
}

