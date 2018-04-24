using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.fonts
{
    public class Ucenik_lista_pracenja
    {

        public long id_pracenje { get; set; }

        public int id_pedagog { get; set; }

        public long id_ucenik { get; set; }

        public int godina { get; set; }

        public DateTime datum { get; set; }

        public int id_odjel { get; set; }

        public string razlog { get; set; }

        public string inic_ucenik { get; set; }

        public string inic_roditelj { get; set; }

        public string inic_razrednik { get; set; }

        public string soc_eko { get; set; }

        public string ucenje { get; set; }

        public string vjestine { get; set; }

        public string suradnja { get; set; }

        public string zakljucak { get; set; }

    }
}