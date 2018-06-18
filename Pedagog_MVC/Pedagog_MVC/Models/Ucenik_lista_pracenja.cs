using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.fonts
{   
        [Table("ucenik_lista_pracenja")]
        public class Ucenik_lista_pracenja
        {
            [Required]
            [Key]
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
            public int id_odjel { get; set; }
            [Required]
            public string razlog { get; set; }
            [Required]
            public string inic_ucenik { get; set; }
            [Required]
            public string inic_roditelj { get; set; }
            [Required]
            public string inic_razrednik { get; set; }
            [Required]
            public string soc_eko { get; set; }
            [Required]
            public string ucenje { get; set; }
            [Required]
            public string vjestine { get; set; }
            [Required]
            public string suradnja { get; set; }
            [Required]
            public string zakljucak { get; set; }

        }
}