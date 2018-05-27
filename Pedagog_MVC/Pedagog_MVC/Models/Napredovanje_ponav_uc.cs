using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Pedagog_MVC.Models
{
    public class Napredovanje_ponav_uc
    {
        [Required]
        public long id_napredovanje { get; set; }
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
        public string naziv { get; set; }
        [Required]
        public string uzroci { get; set; }
        [Required]
        public int mogucnost_1 { get; set; }
        [Required]
        public int mogucnost_2 { get; set; }
        [Required]
        public int mogucnost_3 { get; set; }
        [Required]
        public int mogucnost_4 { get; set; }
        [Required]
        public int mogucnost_5 { get; set; }
        [Required]
        public int mogucnost_6 { get; set; }
        [Required]
        public int mogucnost_7 { get; set; }
        [Required]
        public int mogucnost_8 { get; set; }
        [Required]
        public string mjera_1_predmet { get; set; }
        [Required]
        public string mjera_2_predmet { get; set; }
        [Required]
        public string mjera_3_predmet { get; set; }
        [Required]
        public string mjera_1_ucinak { get; set; }
        [Required]
        public string mjera_2_ucinak { get; set; }
        [Required]
        public string mjera_3_ucinak { get; set; }
        [Required]
        public int upitnik { get; set; } // da/ne??
        [Required]
        public int suradnja { get; set; } //od 1-3
        [Required]
        public string komentar { get; set; }
        [Required]
        public string plan_razgovor_A_dan { get; set; }
        [Required]
        public string plan_razgovor_A_sat { get; set; }
        [Required]
        public string plan_razgovor_B_dan { get; set; }
        [Required]
        public string plan_razgovor_B_sat { get; set; }
        //napredovanje ucenika ponavljaca
    }
}