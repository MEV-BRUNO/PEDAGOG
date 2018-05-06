using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pedagog_MVC.Models;
using System.ComponentModel.DataAnnotations;

namespace Pedagog_MVC.Models
{
    public class Tijek_Napredovanje_ponav_uc
    {
        [Required]
        public int id_napredovanje { get; set; }
        [Required]
        public int id_tijek { get; set; }
        [Required]
        public DateTime datum { get; set; }
        [Required]
        public string sadrzaj { get; set; }
        [Required]
        public string dogovor { get; set; } //tijek napredovanja ponavljaca

    }
}