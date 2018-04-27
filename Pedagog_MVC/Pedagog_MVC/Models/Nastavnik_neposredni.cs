using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models
{
    public class Nastavnik_neposredni
    {
        [Required]
        public long id_rad { get; set; }
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
        public string nas_jedinica { get; set; }
        [Required]
        public string nas_cijelina { get; set; }

        [Required]
        public int uvjeti_izvodenja { get; set; }
        [Required]
        public int uvjet_prostor { get; set; }
        [Required]
        public string uvjet_higijena { get; set; }
        [Required]
        public string uvjet_materijalna { get; set; }
        [Required]
        public int planiranje_redovno { get; set; }
        [Required]
        public string planiranje_priprava { get; set; }
        [Required]
        public int planiranje_sadrzaji { get; set; }
        [Required]
        public int planiranje_postignuca { get; set; }
        [Required]
        public int planiranje_pismena { get; set; }
        [Required]
        public string analiza_model { get; set; }
        [Required]
        public string analiza_soci { get; set; }
        [Required]
        public string analiza_metode { get; set; }
        [Required]
        public string analiza_strategija { get; set; }
        [Required]
        public string analiza_sredstva { get; set; }
        [Required]
        public int analiza_novi_pojam { get; set; }
        [Required]
        public int analiza_oblici { get; set; }
        [Required]
        public int analiza_ciljevi { get; set; }
        [Required]
        public string analiza_odnos { get; set; }
        [Required]
        public string analiza_pozornost { get; set; }
        [Required]
        public string analiza_nastup { get; set; }
        [Required]

        public string analiza_govor { get; set; }
        [Required]
        public string analiza_stil { get; set; }
        [Required]
        public string aktiv_samostalan { get; set; }
        [Required]
        public string aktiv_postignuca { get; set; }
        [Required]
        public string aktiv_dz { get; set; }
        [Required]
        public string aktiv_karakter { get; set; }
        [Required]
        public int aktiv_dz_provjerena { get; set; }
        [Required]
        public int aktiv_zapis { get; set; }
        [Required]
        public int aktiv_procjena { get; set; }
        [Required]
        public int aktiv_evaluacija { get; set; }

        [Required]
        public int aktiv_zapazanja { get; set; }
        [Required]
        public int dokument_vodi { get; set; }
        [Required]
        public int dokument_dnevnik { get; set; }
        [Required]
        public int dokument_priprema { get; set; }
        [Required]
        public int dokument_imenik { get; set; }
        [Required]
        public int dokument_ocjene { get; set; }
        [Required]
        public string poslovi { get; set; }
        [Required]
        public int procjena_vodenja { get; set; }

    }
}