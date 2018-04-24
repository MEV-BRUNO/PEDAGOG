using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models
{
    public class Procjena_suradnje_ponav_uc
    {
        public int id_napredovanje { get; set; }
        public int id_procjena { get; set; }
        public string nastavnik { get; set; }
        public DateTime datum_razgovora { get; set; }
        public string biljeska { get; set; }
    }
}