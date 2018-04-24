using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models
{
    public class Nastavnik_analiza
    {

        public long id_analiza { get; set; }

        public int id_pedagog { get; set; }

        public long id_nastavnik { get; set; }

        public int godina { get; set; }

        public DateTime datum { get; set; }

        public string nastavni_sat { get; set; }

        public string predmet { get; set; }

        public string cilj { get; set; }

        public string nastavna_jedinica { get; set; }

        public string vrsta_sata { get; set; }


        public string planiranje { get; set; }

        public string izvedba { get; set; }

        public string tijek { get; set; }

        public string ugodaj { get; set; }

        public string disciplina { get; set; }

        public string ocjena_napredovanja { get; set; }

        public string osvrt { get; set; }

        public string prijedlozi { get; set; }

        public string uvid { get; set; }

        public string zakljucak { get; set; }


    }
}