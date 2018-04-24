using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models
{
    public class Strucno_usavrsavanje
    {

        public long id_usavrsavanje { get; set; }

        public int id_pedagog { get; set; }

        public int godina { get; set; }

        public DateTime datum { get; set; }

        public string naslov { get; set; }

        public string cilj { get; set; }

        public string namjena { get; set; }

        public string nacina_rada { get; set; }

        public string br_sudionika { get; set; }

        public string modul_1_opis { get; set; }

        public string modul_1_vrijeme { get; set; }

        public string modul_2_opis { get; set; }

        public string modul_2_vrijeme { get; set; }

        public string modul_3_opis { get; set; }

        public string modul_3_vrijeme { get; set; }

        public string biljeska { get; set; }

    }
}