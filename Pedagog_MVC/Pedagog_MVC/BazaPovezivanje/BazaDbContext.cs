using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Pedagog_MVC.Models;
using ProjektIdio.Models;
using Pedagog_MVC.fonts;

namespace Pedagog_MVC.BazaPovezivanje
{
    public class BazaDbContext : DbContext
    {

        public DbSet<Pedagog> Pedagozi { get; set; }
        public DbSet<Ucenik> Ucenici { get; set; }

        public DbSet<Adresar> Adresari { get; set; }

        public DbSet<Razredni_odjel> Razredi { get; set; }

        public DbSet<Nastavnik> Nastavnici { get; set; }

        public DbSet<Ucenik_lista_pracenja> Liste_Pracenja { get; set; }

        public DbSet<Obitelj> Obitelji { get; set; }


        public DbSet<Ucenik_obrazovna_postignuca> Postignuca { get; set; }


        public DbSet<Ucenik_neposredni_rad> NeposredniRadoviUcenik { get; set; }

        public DbSet<Godina_ucenik> godineUc { get; set; }

    }
}