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
            public long id_ucenik { get; set; }
        [Required]
            public int id_odjel { get; set; }
        [Required]
            public int id_skola { get; set; }
        [Required]
            public int godina{ get; set; }
        [Required]
            public int id_razrednik { get; set; }
        [Required]
            public int ponavlja { get; set; }
        [Required]
            public int putnik { get; set; }
        [Required]
            public string zaduzenja { get; set; }

        }
    }

