using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models
{
    public class Ucenik_napredovanje
    {
        public long id_napredovanje { get; set; }

        public int id_pedagog { get; set; }

        public long id_ucenik { get; set; }


        public int godina { get; set; }

        public DateTime datum { get; set; }

        public string vrijeme { get; set; }

        public string naziv { get; set; }

        public string razlog { get; set; }

        public int odgojni_otac { get; set; }

        public int odgojni_majka { get; set; }

        public int odnos_ucenje_otac { get; set; }


        public int odnos_ucenje_majka { get; set; }

        public int suradnja_otac { get; set; }

        public int suradnja_majka { get; set; }

        public string prijatelji { get; set; }

        public string slobodno_vrijeme { get; set; }

        public string los_utjecaj { get; set; }

        public string zdravlje { get; set; }

        public string promjene { get; set; }


        public string ped_mjere { get; set; }

        public string procjena { get; set; }

        


    }
}