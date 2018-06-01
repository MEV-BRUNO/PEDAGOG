using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models
{
    [Table("adresar")]
    public class Adresar
    {
        [Key]
        [Required]
        public int id_kontakt { get; set; }
        
        [Required]
        public int id_pedagog { get; set; }

        [Required(ErrorMessage ="{0} je obavezan podatak")]
        [Display(Name = "Naziv kontakta")]
        public string naziv { get; set; }

        [Required(ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Adresa")]
        public string adresa { get; set; }

        [Required(ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Grad")]
        public string grad { get; set; }

        [Required(ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Broj telefona")]
        public string tel { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Upisali ste nevaljanu e-mail adresu")]
        [Display(Name = "Email adresa")]
        public string mail { get; set; }

        
        [Required(ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Opis kontakta")]
        public string opis { get; set; }

    }
}