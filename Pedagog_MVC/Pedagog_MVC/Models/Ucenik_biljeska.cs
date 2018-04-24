using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models
{
    public class Ucenik_biljeska
    {

        public long id_biljeska { get; set; }

        public int id_pedagog { get; set; }

        public long id_ucenik { get; set; }

        public int godina { get; set; }

        public string inicijalni_podaci { get; set; }

        public DateTime datum_pocetak { get; set; }

        public string biljeska_1 { get; set; }

        public string biljeska_2 { get; set; }

        public string biljeska_3 { get; set; }

        public string biljeska_4 { get; set; }

        public string biljeska_5 { get; set; }

        public string biljeska_6 { get; set; }

        public string biljeska_7 { get; set; }

        public string biljeska_8 { get; set; }

        public string biljeska_9 { get; set; }

        public string biljeska_10 { get; set; }
        
        public string biljeska_11 { get; set; }

        public string biljeska_12 { get; set; }

        public string zakljucak { get; set; }

        public string zapazanja { get; set; }

    }
}