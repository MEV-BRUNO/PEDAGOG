using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace ProjektIdio.Models
{
    public class Nastavnik
    {
        [Required]
        public int ID_UCENIK { get; set; }
        [Required]
        public int ID_SKOLA { get; set; }
        [Required]
        public string Ime_Prezime { get; set; }
        [Required]
            public string Titula { get; set; }


        }
    }

