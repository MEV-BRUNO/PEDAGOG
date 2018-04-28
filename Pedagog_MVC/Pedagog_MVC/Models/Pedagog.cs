using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models
{
    public class Pedagog
    {
        [Required]
        public int id_pedagog { get; set; }
        [Required]
        public string ime_prezime { get; set; }
        [Required]
        public string mail { get; set; }
        [Required]
        public string lozinka { get; set; }
        [Required]
        public string titula { get; set; }
        [Required]
        public DateTime licenca { get; set; }
        [Required]
        public string aktiv_link { get; set; }
        [Required]
        public int aktivan { get; set; }
        [Required]
        public int id_skola { get; set; }
    }
}