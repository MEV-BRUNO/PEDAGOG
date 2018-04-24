using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models
{
    public class Nastavnik_neposredni
    {

        public long id_rad { get; set; }

        public int id_pedagog { get; set; }

        public long id_nastavnik { get; set; }

        public int godina { get; set; }

        public DateTime datum { get; set; }

        public string vrijeme { get; set; }

        public string nastavni_sat { get; set; }

        public string mjesto { get; set; }

        public string nas_jedinica { get; set; }

        public string nas_cijelina { get; set; }


        public int uvjeti_izvodenja { get; set; }

        public int uvjet_prostor { get; set; }

        public string uvjet_higijena { get; set; }

        public string uvjet_materijalna { get; set; }

        public int planiranje_redovno { get; set; }

        public string planiranje_priprava { get; set; }

        public int planiranje_sadrzaji { get; set; }

        public int planiranje_postignuca { get; set; }

        public int planiranje_pismena { get; set; }

        public string analiza_model { get; set; }

        public string analiza_soci { get; set; }

        public string analiza_metode { get; set; }

        public string analiza_strategija { get; set; }

        public string analiza_sredstva { get; set; }

        public int analiza_novi_pojam { get; set; }

        public int analiza_oblici { get; set; }

        public int analiza_ciljevi { get; set; }

        public string analiza_odnos { get; set; }

        public string analiza_pozornost { get; set; }

        public string analiza_nastup { get; set; }


        public string analiza_govor { get; set; }

        public string analiza_stil { get; set; }

        public string aktiv_samostalan { get; set; }

        public string aktiv_postignuca { get; set; }

        public string aktiv_dz { get; set; }

        public string aktiv_karakter { get; set; }

        public int aktiv_dz_provjerena { get; set; }

        public int aktiv_zapis { get; set; }

        public int aktiv_procjena { get; set; }

        public int aktiv_evaluacija { get; set; }


        public int aktiv_zapazanja { get; set; }

        public int dokument_vodi { get; set; }

        public int dokument_dnevnik { get; set; }

        public int dokument_priprema { get; set; }

        public int dokument_imenik { get; set; }

        public int dokument_ocjene { get; set; }

        public string poslovi { get; set; }

        public int procjena_vodenja { get; set; }

    }
}