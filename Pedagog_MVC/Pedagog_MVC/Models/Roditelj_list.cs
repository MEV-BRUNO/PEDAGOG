using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models
{
    public class Roditelj_list
    {
        [Required]
        public long id_list { get; set; }
        [Required]
        public int id_pedagog { get; set; }
        [Required]
        public int id_odjel { get; set; }
        [Required]
        public long id_ucenik { get; set; }
        [Required]
        public int godina { get; set; }
        [Required]
        public DateTime datum { get; set; }
        [Required]
        public string naslov { get; set; }
        [Required]
        public string analiza { get; set; }
        [Required]
        public string problemi { get; set; }
        [Required]
        public string odgovori { get; set; }
        [Required]
        public string zadaci { get; set; }
    }
}