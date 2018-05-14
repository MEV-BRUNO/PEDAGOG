using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models
{
    public class Nastavnik_protokol
    {
        [Required]
        public long id_protokol { get; set; }
        [Required]
        public int id_pedagog { get; set; }
        [Required]
        public long id_nastavnik { get; set; }
        [Required]
        public int godina { get; set; }
        [Required]
        public DateTime datum { get; set; }
        [Required]
        public string vrijeme { get; set; }
        [Required]
        public string nastavni_sat { get; set; }
        [Required]
        public string mjesto { get; set; }
        [Required]
        public string nas_cjelina { get; set; }
        [Required]
        public string nas_jedinica { get; set; }

        [Required]
        public int prijava { get; set; }
        [Required]
        public int cilj { get; set; }
        [Required]
        public int struktura { get; set; }
        [Required]
        public int plan { get; set; }
        [Required]
        public int ploca { get; set; }
        [Required]
        public int tip_sata { get; set; }
        [Required]
        public int metoda_verbalna { get; set; }
        [Required]
        public int metoda_vizualna { get; set; }
        [Required]
        public int metoda_demo { get; set; }
        [Required]
        public int metoda_prakse { get; set; }
        [Required]
        public int metoda_kombi { get; set; }
        [Required]
        public int soc_oblik_rada { get; set; }
        [Required]
        public string nastavna_sredstva { get; set; }
        [Required]
        public int funkci_priprema { get; set; }
        [Required]
        public int motiv_uvod { get; set; }
        [Required]
        public int motiv_komunikacija { get; set; }
        [Required]
        public int motiv_humor { get; set; }
        [Required]
        public int motiv_paznja { get; set; }
        [Required]
        public string prezent_sto_nastavnik { get; set; }
        [Required]
        public string prezent_sto_ucenik { get; set; }
        [Required]

        public string prezent_kompo_nastavnik { get; set; }
        [Required]
        public string prezent_kompo_ucenik { get; set; }
        [Required]
        public string prezent_tijek_nastavnik { get; set; }
        [Required]
        public string prezent_tijek_ucenik { get; set; }
        [Required]
        public int procjena_razgovora { get; set; }
        [Required]
        public int procjena_ohr_ponasanje { get; set; }
        [Required]
        public int procjena_ohr_aktivnost { get; set; }
        [Required]
        public int procjena_pitanja { get; set; }
        [Required]
        public int procjena_autoritet { get; set; }
        [Required]
        public int procjena_empatija { get; set; }

        [Required]
        public int procjena_pomaze { get; set; }
        [Required]
        public int procjena_neverbalna { get; set; }
        [Required]
        public int procjena_inicijativa { get; set; }
        [Required]
        public int dz { get; set; }
        [Required]
        public int daje_ocjenu { get; set; }
        [Required]
        public string komentar { get; set; }
        [Required]
        public string prijedlozi { get; set; }

        


    }
}