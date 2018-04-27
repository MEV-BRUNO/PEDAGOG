using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models
{
    public class Ucenik_neposredni_rad
    {
        [Required]
        public long id_pracenje { get; set; }
        [Required]
        public DateTime datum { get; set; }

        [Required]
        public string biljeska { get; set; }

    }
}