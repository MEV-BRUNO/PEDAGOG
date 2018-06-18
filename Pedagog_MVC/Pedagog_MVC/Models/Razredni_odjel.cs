using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pedagog_MVC.Models
{
    [Table("razredni_odjel")]
    public class Razredni_odjel
    {
        [Key]
        [Required]
        public int id_odjel { get; set; }
        [Required]
        public int godina { get; set; }
        [Required]
        public string naziv { get; set; }
        [Required]
        public int razred { get; set; }
        [Required]
        public int id_razrednik { get; set; }       
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "OŠ / SŠ")]
        public int os_ss { get; set; }
        [Required]
        public string program { get; set; }
        [Required]
        public string usmjerenje { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "broj ženskih osoba")]
        public int broj_z { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "broj muških osoba")]
        public int broj_m { get; set; }
    }
}