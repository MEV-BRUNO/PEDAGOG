using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace ProjektIdio.Models
{
    public class Obitelj
    {
        [Required]
        public int ID_obitelj { get; set; }
        [Required]
        public int ID_ucenik { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Vrsta { get; set; }
    }
}

