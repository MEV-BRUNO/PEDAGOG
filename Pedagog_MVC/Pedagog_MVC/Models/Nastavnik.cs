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
        public long id_ucenik { get; set; }
        [Required]
        public int id_skola { get; set; }
        [Required]
        public string ime_prezime { get; set; }
        [Required]
        public int titula { get; set; }


        }
    }

