using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models
{
    public class Pedagog
    {
        public int id_pedagog { get; set; }
        public string ime_prezime { get; set; }
        public string mail { get; set; }
        public string lozinka { get; set; }
        public string titula { get; set; }
        public DateTime licenca { get; set; }
        public string aktiv_link { get; set; }
        public int aktivan { get; set; }
        public int id_skola { get; set; }
    }
}