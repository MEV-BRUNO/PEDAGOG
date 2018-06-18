using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models
{
    [Table("razredni_odjel")]
    public class Razredni_odjel
    {
        [Key]
        [Required]
        public int id_odjel { get; set; }
        [Required(ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Školska Godina")]
        public int godina { get; set; }
        [Required(ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Naziv")]
        public string naziv { get; set; }
        [Required(ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Razred")]
        public int razred { get; set; }
        [Required(ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Razrednik")]
        public int id_razrednik { get; set; }
        [Required(ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "OŠ/SŠ(0/1)")]
        public int os_ss { get; set; }
        [Required(ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Program")]
        public string program { get; set; }
        [Required(ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Usmjerenje")]
        public string usmjerenje { get; set; }
        [Required(ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Broj učenica")]
        public int broj_z { get; set; }
        [Required(ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Broj učenika")]
        public int broj_m { get; set; }
    }
}