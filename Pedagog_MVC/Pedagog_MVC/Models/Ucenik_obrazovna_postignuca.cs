using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models
{
    public class Ucenik_obrazovna_postignuca
    {
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