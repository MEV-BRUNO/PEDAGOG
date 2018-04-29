using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models
{
    public class Roditelj_procjena
    {
        [Required]
        public long id_procjena { get; set; }
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
        public string opis { get; set; }
        [Required]
        public string interes { get; set; }
        [Required]
        public string najaktivniji { get; set; }
        [Required]
        public string poteskoce { get; set; }
        [Required]
        public string boravak_skola { get; set; }
        [Required]
        public string odnos_obitelj { get; set; }
        [Required]
        public string aktivnosti { get; set; }
        [Required]
        public string hobi { get; set; }
        [Required]
        public string ocekivanja { get; set; }
        [Required]
        public string dodatni_podaci { get; set; }

    }
}