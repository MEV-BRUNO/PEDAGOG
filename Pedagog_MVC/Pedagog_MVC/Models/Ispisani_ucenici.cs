using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models
{
    public class Ispisani_ucenici
    {
        public long id_analiza { get; set; }

        public long id_ucenik { get; set; }

        public DateTime datum { get; set; }

        public string razlog { get; set; }

        public string skola { get; set; }

    }
}