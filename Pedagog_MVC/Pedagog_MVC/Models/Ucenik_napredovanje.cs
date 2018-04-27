using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models
{
    public class Ucenik_napredovanje
    {
        [Required]
        public long id_napredovanje { get; set; }
        [Required]
        public int id_pedagog { get; set; }
        [Required]
        public long id_ucenik { get; set; }
        [Required]

        public int godina { get; set; }
        [Required]
        public DateTime datum { get; set; }
        [Required]
        public string vrijeme { get; set; }
        [Required]
        public string naziv { get; set; }
        [Required]
        public string razlog { get; set; }
        [Required]
        public int odgojni_otac { get; set; }
        [Required]
        public int odgojni_majka { get; set; }
        [Required]
        public int odnos_ucenje_otac { get; set; }

        [Required]
        public int odnos_ucenje_majka { get; set; }
        [Required]
        public int suradnja_otac { get; set; }
        [Required]
        public int suradnja_majka { get; set; }
        [Required]
        public string prijatelji { get; set; }
        [Required]
        public string slobodno_vrijeme { get; set; }
        [Required]
        public string los_utjecaj { get; set; }
        [Required]
        public string zdravlje { get; set; }
        [Required]
        public string promjene { get; set; }
        [Required]

        public string ped_mjere { get; set; }
        [Required]
        public string procjena { get; set; }

        


    }
}