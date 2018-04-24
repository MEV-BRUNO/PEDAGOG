using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models
{
    public class Razrednik_procjena
    {


        public long id_procjena { get; set; }

        public int id_pedagog { get; set; }

        public long id_nastavnik { get; set; }

        public int id_odjel { get; set; }

        public int godina { get; set; }

        public DateTime datum { get; set; }

        public int br_ucenika { get; set; }

        public int ucenici_pozitivni { get; set; }

        public string ucenici_nedovoljno { get; set; }

        public string ucenici_izostanci { get; set; }


        public string ucenici_mjere { get; set; }

        public string ucenici_roditelji { get; set; }


        public string predmet_malo_ocjena { get; set; }


    }
}