using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models
{
    public class Ucenik_tijek_napredovanja
    {

        [Required]
        public long id_napredovanje { get; set; }
        [Required]
        public DateTime datum { get; set; }
        [Required]
        public string sadrzaj { get; set; }
        [Required]
        public string dogovor { get; set; }

    }
}