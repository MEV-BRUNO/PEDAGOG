using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models
{
    public class Roditelj_list
    {
        public long id_list { get; set; }

        public int id_pedagog { get; set; }

        public int id_odjel { get; set; }

        public long id_ucenik { get; set; }

        public int godina { get; set; }

        public DateTime datum { get; set; }

        public string naslov { get; set; }

        public string analiza { get; set; }

        public string problemi { get; set; }

        public string odgovori { get; set; }

        public string zadaci { get; set; }
    }
}