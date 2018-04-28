using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models
{
    public class Skola
    {
        public int id_skola { get; set; }
        public string naziv { get; set; }
        public string adresa { get; set; }
        public string grad { get; set; }
        public string oib { get; set; }
        public string mail { get; set; }
        public string tel { get; set; }
        public string opis { get; set; }
    }
}