
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace ProjektIdio.Models
{
    [Table("obitelj")]
    public class Obitelj
    {
        [Required]
        [Key]
        public int id_obitelj { get; set; }
        [Required]
        public long id_ucenik { get; set; }
        [Required]
        [Display(Name = "ime i prezime")]
        public string ime_prezime { get; set; }
        [Required]
        public int vrsta { get; set; }
        [Required]
        public string zanimanje { get; set; }
        [Required]
        [Display(Name = "broj telefona")]
        public string tel { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Upisali ste nevaljanu e-mail adresu")]
        [Display(Name = "e-mail adresa")]
        public string mail { get; set; }
        [Required]
        public string adresa { get; set; }
        [Required]
        public string grad { get; set; }
        [Required]
        public string obrazovanje { get; set; }
        [Required]
        [Display(Name = "biljeska")]
        public string biljeska { get; set; }
    }
}

