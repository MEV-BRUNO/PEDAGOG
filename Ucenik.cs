
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace ProjektIdio.Models
{
    public class Ucenik
    {
       [Required]
        public int ID_Ucenik { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [Required]
        public string Spol { get; set; }
        [Required]
        public DateTime Datum { get; set; }
        [Required]
        public string OIB { get; set; }
        [Required]
        public string Adresa { get; set; }
        [Required]
        public string Grad { get; set; }
        [Required]
        public string Biljeska { get; set; }
        }
    }

