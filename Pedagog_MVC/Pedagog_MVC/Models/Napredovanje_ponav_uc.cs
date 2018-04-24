using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models
{
    public class Napredovanje_ponav_uc
    {
        public int id_napredovanje { get; set; }
        public int id_pedagog { get; set; }
        public int id_ucenik { get; set; }
        public int godina { get; set; }
        public DateTime datum { get; set; }
        public string vrijeme { get; set; }
        public string naziv { get; set; }

        public string uzroci { get; set; }
        public int mogucnost_1 { get; set; }
        public int mogucnost_2 { get; set; }
        public int mogucnost_3 { get; set; }
        public int mogucnost_4 { get; set; }
        public int mogucnost_5 { get; set; }
        public int mogucnost_6 { get; set; }
        public int mogucnost_7 { get; set; }
        public int mogucnost_8 { get; set; }
        public string mjera_1_predmet { get; set; }
        public string mjera_2_predmet { get; set; }
        public string mjera_3_predmet { get; set; }
        public string mjera_1_ucinak { get; set; }
        public string mjera_2_ucinak { get; set; }
        public string mjera_3_ucinak { get; set; }
        public int upitnik { get; set; } // da/ne??

        public int suradnja { get; set; } //od 1-3
        public string komentar { get; set; }
        public string plan_razgovor_A_dan { get; set; }
        public string plan_razgovor_A_sat { get; set; }
        public string plan_razgovor_B_dan { get; set; }
        public string plan_razgovor_B_sat { get; set; }
        //napredovanje ponavljaca
    }
}