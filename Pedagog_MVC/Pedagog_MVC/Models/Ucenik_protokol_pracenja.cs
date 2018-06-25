using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models
{
    [Table("ucenik_protokol_pracenja")]
    public class Ucenik_protokol_pracenja
    {

        [Key]
        [Required]
        public long id_protokol { get; set; }
        [Required]
        public long id_pracenje { get; set; }
        [Required]
        public int id_pedagog { get; set; }
        [Required]
        public long id_ucenik { get; set; }
        [Required]
        public int godina { get; set; }
        [Required]
        public DateTime datum { get; set; }
        [Required]
        public string vrijeme { get; set; }
        [Required]
        public int id_odjel { get; set; }
        [Required]
        public string soc_eko { get; set; }
        [Required]
        public string cilj { get; set; }
        [Required]
        public string sposobnost { get; set; }

        [Required]
        public string prilagodljivost { get; set; }
        [Required]
        public string odnos { get; set; }
        [Required]
        public string doprinos { get; set; }
        [Required]
        public string opis { get; set; }
        [Required]
        public string zakljucak { get; set; }

    }
}