using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models
{
    public class Roditelj_biljeske_mjesec
    {
        [Required]
        public long id_biljeske { get; set; }
        [Required]
        public string mjesec { get; set; }
        [Required]
        public string zakljucak { get; set; }
    }
}