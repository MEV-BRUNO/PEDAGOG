using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models
{
    public class Nastavnik_protokol
    {

        public long id_protokol { get; set; }

        public int id_pedagog { get; set; }

        public long id_nastavnik { get; set; }

        public int godina { get; set; }

        public DateTime datum { get; set; }

        public string vrijeme { get; set; }

        public string nastavni_sat { get; set; }

        public string mjesto { get; set; }

        public string nas_cjelina { get; set; }

        public string nas_jedinica { get; set; }


        public int prijava { get; set; }

        public int cilj { get; set; }

        public int struktura { get; set; }

        public int plan { get; set; }

        public int ploca { get; set; }

        public int tip_sata { get; set; }

        public int metoda_verbalna { get; set; }

        public int metoda_vizualna { get; set; }

        public int metoda_demo { get; set; }

        public int metoda_prakse { get; set; }

        public int metoda_kombi { get; set; }

        public int soc_oblik_rada { get; set; }

        public string nastavna_sredstva { get; set; }

        public int funkci_priprema { get; set; }

        public int motiv_uvod { get; set; }

        public int motiv_komunikacija { get; set; }

        public int motiv_humor { get; set; }

        public int motiv_paznja { get; set; }

        public string prezent_sto_nastavnik { get; set; }

        public string prezent_sto_ucenik { get; set; }


        public string prezent_kompo_nastavnik { get; set; }

        public string prezent_kompo_ucenik { get; set; }

        public string prezent_tijek_nastavnik { get; set; }

        public string prezent_tijek_ucenik { get; set; }

        public int procjena_razgovora { get; set; }

        public int procjena_ohr_ponasanje { get; set; }

        public int procjena_ohr_aktivnost { get; set; }

        public int procjena_pitanja { get; set; }

        public int procjena_autoritet { get; set; }

        public int procjena_empatija { get; set; }


        public int procjena_pomaze { get; set; }

        public int procjena_neverbalna { get; set; }

        public int procjena_inicijativa { get; set; }

        public int dz { get; set; }

        public int daje_ocjenu { get; set; }

        public string komentar { get; set; }

        public string prijedlozi { get; set; }

        


    }
}