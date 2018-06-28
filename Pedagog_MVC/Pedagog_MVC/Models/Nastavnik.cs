
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace ProjektIdio.Models
{
    [Table("nastavnik")]
    public class Nastavnik
    {
        [Required]
        [Key]
        public long id_nastavnik { get; set; }
        [Required]
        public int id_skola { get; set; }
        [Required(ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Prezime i Ime")]
        public string ime_prezime { get; set; }
        [Required(ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Titula")]
        public string titula { get; set; }



    }
}