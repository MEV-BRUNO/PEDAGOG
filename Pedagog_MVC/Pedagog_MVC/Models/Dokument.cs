using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models
{
    public class Dokument
    {
        [Required]
        public long id_dokument { get; set;}
        [Required]
        public int id_pedagog { get; set; }
        [Required]
        public int vrsta { get; set; }
        [Required]
        public string naziv { get; set; }
        [Required]
        public string putanja { get; set; }
    }
}