using Pedagog_MVC.BazaPovezivanje;
using Pedagog_MVC.fonts;
using ProjektIdio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models.PomocniModelLista
{
    public class ModelLP
    {

        BazaDbContext baza = new BazaDbContext();
             
        public Nastavnik Razrednik { get; set; }

        public Razredni_odjel Razred { get; set; }

        public Ucenik ucenik { get; set; }

        public Ucenik_lista_pracenja listaPracenja { get; set; }

        public List<Obitelj> Obitelj { get; set; }

        public List<Ucenik_obrazovna_postignuca> Postignuca { get; set; }

        public List<Ucenik_neposredni_rad> NeposredniRadovi { get; set; }

        public ModelLP()
        {

        }

        public void Init(long id, BazaDbContext baza)
        {
          

            Obitelj = new List<Obitelj>();

            NeposredniRadovi = new List<Ucenik_neposredni_rad>();

            Postignuca = new List<Ucenik_obrazovna_postignuca>();

            ucenik = baza.Ucenici.Find(id);

            listaPracenja = baza.Liste_Pracenja.Where(x => x.id_ucenik == id).SingleOrDefault();

            Razred = baza.Razredi.Find(listaPracenja.id_odjel);

            Razrednik = baza.Nastavnici.Find(Razred.id_razrednik);

           

            foreach(Obitelj ob in baza.Obitelji)
            {
                if (ob.id_ucenik == id)
                {
                    Obitelj.Add(ob);
                }
            }

            foreach (Ucenik_obrazovna_postignuca ob in baza.Postignuca)
            {
                if (ob.id_pracenje == listaPracenja.id_pracenje)
                {
                    Postignuca.Add(ob);
                }
            }

            foreach (Ucenik_neposredni_rad rad in baza.NeposredniRadoviUcenik)
            {
                if (rad.id_pracenje == listaPracenja.id_pracenje)
                {
                    NeposredniRadovi.Add(rad);
                }
            }

        }

    }
}