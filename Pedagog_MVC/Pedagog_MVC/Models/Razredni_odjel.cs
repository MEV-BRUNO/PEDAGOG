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
        [Required]
        public int os_ss { get; set; }
        [Required]
        public string program { get; set; }
        [Required]
        public string usmjerenje { get; set; }
        [Required]
        public int broj_z { get; set; }
        [Required]
        public int broj_m { get; set; }
    }
}