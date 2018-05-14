using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models
{
    public class Adresar
    {

        [Required]
        public int id_kontakt { get; set; }

        [Required]
        public int id_pedagog { get; set; }

        [Required]
        public string naziv { get; set; }

        [Required]
        public string adresa { get; set; }

        [Required]
        public string grad { get; set; }

        [Required]
        public string tel { get; set; }

        [Required]
        public string mail { get; set; }

        [Required]
        public string opis { get; set; }

    }
}