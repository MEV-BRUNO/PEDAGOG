using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models
{
    public class Tijek_pracenja_ponav_uc
    {
        public int id_napredovanje { get; set; }
        public int id_tijek { get; set; }
        public DateTime datum { get; set; }
        public string sadrzaj { get; set; }
        public string dogovor { get; set; }
        //tijek pracenja ucenika ponavljaca
    }
}