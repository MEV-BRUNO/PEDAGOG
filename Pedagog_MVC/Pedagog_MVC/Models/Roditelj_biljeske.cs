using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models
{
    public class Roditelj_biljeske
    {
        public long id_biljeske { get; set; }
        public int id_pedagog { get; set; }
        public int id_odjel { get; set; }
        public long id_ucenik { get; set; }
        public int godina { get; set; }
        public DateTime datum { get; set; }
        public string naslov { get; set; }
        public string ime_roditelja { get; set; }
        public string zapazanja { get; set; }
    }
}