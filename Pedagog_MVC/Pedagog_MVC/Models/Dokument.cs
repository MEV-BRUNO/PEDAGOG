using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models
{
    public class Dokument
    {
        public long id_dokument { get; set;}

        public int id_pedagog { get; set; }

        public int vrsta { get; set; }

        public string naziv { get; set; }

        public string putanja { get; set; }
    }
}