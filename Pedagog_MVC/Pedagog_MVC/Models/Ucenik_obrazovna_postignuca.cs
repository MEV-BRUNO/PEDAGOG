
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models
{
    [Table("ucenik_obrazovna_postignuca")]
    public class Ucenik_obrazovna_postignuca
    {
        [Key]
        [Required]
        public long id_postignuce { get; set; }
        [Required]      
        public long id_pracenje { get; set; }
        [Required]
        public int godina { get; set; }
        [Required]
        public int razred { get; set; }
        [Required]
        public string napomena { get; set; }

    }
}