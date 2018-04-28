using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models
{
    public class Razredni_odjel
    {
        public int id_odjel { get; set; }
        public int godina { get; set; }
        public string naziv { get; set; }
        public int razred { get; set; }
        public int id_razrednik { get; set; }
        public int os_ss { get; set; }
        public string program { get; set; }
        public string usmjerenje { get; set; }
        public int broj_z { get; set; }
        public int broj_m { get; set; }
    }
}