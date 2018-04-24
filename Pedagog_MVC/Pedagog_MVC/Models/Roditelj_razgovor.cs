using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models
{
    public class Roditelj_razgovor
    {

        public long id_razgovor { get; set; }

        public int id_pedagog { get; set; }

        public int id_odjel { get; set; }

        public long id_ucenik { get; set; }

        public int godina { get; set; }

        public DateTime datum { get; set; }

        public string naslov { get; set; }

        public string ime_roditelja { get; set; }

        public string trazi { get; set; }

        public string razlog { get; set; }

        public string dolazak { get; set; }

        public string biljeske { get; set; }

        public string prijedlog_roditelj { get; set; }

        public string prijedlog_skola { get; set; }

        public string dogovor { get; set; }

        public string izvijestiti { get; set; }

        public string sljedeci_susret { get; set; }

    }
}