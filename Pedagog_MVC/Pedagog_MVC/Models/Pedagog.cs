using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pedagog_MVC.Models
{
    [Table("pedagog")]
    public class Pedagog
    {
        [Required]
        [Key]
        public int id_pedagog { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Ime i Prezime")]
        public string ime_prezime { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Upisali ste nevaljanu e-mail adresu")]
        [Display(Name = "Email adresa")]
        public string mail { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Lozinka")]
        [DataType(DataType.Password)]
        public string lozinka { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Titula")]
        public string titula { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Datum licence")]
        [DataType(DataType.Date)]
        //ako ne napišemo fiksno ovaj format Google Chrome nece dobro prikazati datumsko polje
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime licenca { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Aktiv link")]
        public string aktiv_link { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Aktivan")]
        public int aktivan { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "ID škola")]
        public int id_skola { get; set; }
    }
}