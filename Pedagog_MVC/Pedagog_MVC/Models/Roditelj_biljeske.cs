using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Pedagog_MVC.Models
{
    public class Roditelj_biljeske
    {
        [Required]
        public long id_biljeske { get; set; }
        [Required]
        public int id_pedagog { get; set; }
        [Required]
        public int id_odjel { get; set; }
        [Required]
        public long id_ucenik { get; set; }
        [Required]
        public int godina { get; set; }
        [Required]
        public DateTime datum { get; set; }
        [Required]
        public string naslov { get; set; }
        [Required]
        public string ime_roditelja { get; set; }
        [Required]
        public string zapazanja { get; set; }
    }
}