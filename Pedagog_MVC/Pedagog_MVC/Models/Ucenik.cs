using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace ProjektIdio.Models
{
    [Table("ucenik")]
    public class Ucenik
    {
       [Key]
       [Required]
        public long id_ucenik { get; set; }
        [Required]
        public string ime_prezime { get; set; }     
        [Required]
        public int spol { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [Display(Name = "Datum licence")]
        [DataType(DataType.Date)]
        //ako ne napišemo fiksno ovaj format Google Chrome nece dobro prikazati datumsko polje
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime datum { get; set; }
        [Required]
        public string oib { get; set; }
        [Required]
        public string adresa { get; set; }
        [Required]
        public string grad { get; set; }
        [Required]
        public string biljeska { get; set; }
        }
    }

