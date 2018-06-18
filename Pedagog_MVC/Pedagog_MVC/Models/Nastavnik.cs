
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace ProjektIdio.Models
{
    [Table("nastavnik")]
    public class Nastavnik
    {
        [Required]
        [Key]
        public long id_nastavnik { get; set; }
        [Required]
        public int id_skola { get; set; }
        [Required]
        public string ime_prezime { get; set; }
        [Required]
        public int titula { get; set; }


    }
}