using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models
{
    public class Roditelj_procjena
    {

        public long id_procjena { get; set; }

        public int id_pedagog { get; set; }

        public int id_odjel { get; set; }

        public long id_ucenik { get; set; }

        public int godina { get; set; }

        public DateTime datum { get; set; }

        public string naslov { get; set; }

        public string opis { get; set; }

        public string interes { get; set; }

        public string najaktivniji { get; set; }

        public string poteskoce { get; set; }

        public string boravak_skola { get; set; }

        public string odnos_obitelj { get; set; }

        public string aktivnosti { get; set; }

        public string hobi { get; set; }

        public string ocekivanja { get; set; }

        public string dodatni_podaci { get; set; }

    }
}