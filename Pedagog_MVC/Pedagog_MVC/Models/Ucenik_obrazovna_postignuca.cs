using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models
{
    public class Ucenik_obrazovna_postignuca
    {

        public long id_pracenje { get; set; }

        public int godina { get; set; }

        public int razred { get; set; }

        public string napomena { get; set; }

    }
}