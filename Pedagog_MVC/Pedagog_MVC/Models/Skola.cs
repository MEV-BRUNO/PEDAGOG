using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pedagog_MVC.Models
{
    [Table("skola")]
    public class Skola
    {
        [Key]
        [Required]
        public int id_skola { get; set; }
        [Required(ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Naziv škole")]
        public string naziv { get; set; }
        [Required(ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Adresa")]
        public string adresa { get; set; }
        [Required(ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Grad")]
        public string grad { get; set; }
        [Required(ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "OIB")]
        public string oib { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Upisali ste nevaljanu e-mail adresu")]
        [Display(Name = "Email")]
        public string mail { get; set; }
        [Required(ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Telefon")]
        public string tel { get; set; }
        [Required(ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Bilješka")]
        public string opis { get; set; }
    }
}