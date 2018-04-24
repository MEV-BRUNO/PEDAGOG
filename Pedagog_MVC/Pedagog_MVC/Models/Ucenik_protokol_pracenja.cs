using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models
{
    public class Ucenik_protokol_pracenja
    {


        public long id_pracenje { get; set; }

        public int id_pedagog { get; set; }

        public long id_ucenik { get; set; }

        public int godina { get; set; }

        public DateTime datum { get; set; }

        public string vrijeme { get; set; }

        public int id_odjel { get; set; }

        public string soc_eko { get; set; }

        public string cilj { get; set; }

        public string sposobnost { get; set; }


        public string prilagodljivost { get; set; }

        public string odnos { get; set; }

        public string doprinos { get; set; }

        public string opis { get; set; }

        public string zakljucak { get; set; }

    }
}