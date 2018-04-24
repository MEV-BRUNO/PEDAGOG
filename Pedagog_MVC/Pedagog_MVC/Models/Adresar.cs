using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models
{
    public class Adresar
    {

        public int id_kontakt { get; set; }

        public int id_pedagog { get; set; }

        public string naziv { get; set; }

        public string adresa { get; set; }

        public string grad { get; set; }

        public string tel { get; set; }

        public string mail { get; set; }

        public string opis { get; set; }

    }
}