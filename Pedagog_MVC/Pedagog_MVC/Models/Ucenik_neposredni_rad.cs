using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models
{
    [Table("ucenik_neposredni_rad")]
    public class Ucenik_neposredni_rad
    {
        [Key]
        [Required]
        public long id_rad { get; set; }

        [Required]        
        public long id_pracenje { get; set; }
        [Required]
        public DateTime datum { get; set; }

        [Required]
        public string biljeska { get; set; }

    }
}