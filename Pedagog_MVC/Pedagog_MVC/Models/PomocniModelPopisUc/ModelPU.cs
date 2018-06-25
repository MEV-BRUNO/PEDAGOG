using Pedagog_MVC.fonts;
using ProjektIdio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models.PomocniModelPopisUc
{
    public class ModelPU
    {
        [Required]
        public Ucenik ucenik { get; set; }
        [Required]
        public Godina_ucenik godUcenik { get; set; }

        [Required]
        public Ucenik_lista_pracenja lista { get; set; }

        [Required]
        public Ucenik_biljeska biljeska { get; set; }



    }
}