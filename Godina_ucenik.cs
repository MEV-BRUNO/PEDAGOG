using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace ProjektIdio.Models
{
    public class Godina_ucenik
    {
        [Required]
            public int ID_ucenik { get; set; }
        [Required]
            public int ID_odjel { get; set; }
        [Required]
            public int ID_skola { get; set; }
        [Required]
            public int Godina{ get; set; }
        [Required]
            public int ID_razrednik { get; set; }
        [Required]
            public string Ponavlja { get; set; }
        [Required]
            public string Putnik { get; set; }
        [Required]
            public string Zaduzenja { get; set; }

        }
    }

