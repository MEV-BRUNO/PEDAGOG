

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace ProjektIdio.Models
{
    [Table("ucenik_godina")]
    public class Godina_ucenik
    {
        [Key]
        [Required]
        public long id_ucenik { get; set; }
        [Required]
        public int id_odjel { get; set; }
        [Required]
        public int id_skola { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Godina")]
        public int godina { get; set; }
        [Required]
        public int id_razrednik { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Ponavlja razred")]
        public int ponavlja { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Putnik")]
        public int putnik { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Zaduženja")]
        public string zaduzenja { get; set; }

    }
}