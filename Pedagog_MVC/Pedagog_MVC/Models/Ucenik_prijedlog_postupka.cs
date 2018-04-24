using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models
{
    public class Ucenik_prijedlog_postupka
    {

        public long id_pracenje { get; set; }

        public DateTime datum { get; set; }

        public string vrsta { get; set; }

        public string vrijeme { get; set; }


    }
}