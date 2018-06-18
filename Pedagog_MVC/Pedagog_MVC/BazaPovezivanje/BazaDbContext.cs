using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Pedagog_MVC.Models;
using ProjektIdio.Models;

namespace Pedagog_MVC.BazaPovezivanje
{
    public class BazaDbContext : DbContext
    {

        public DbSet<Pedagog> Pedagozi { get; set; }
        public DbSet<Ucenik> Ucenici { get; set; }

        public DbSet<Adresar> Adresari { get; set; }

        public DbSet<Razredni_odjel> RazredniOdjeli { get; set; }    

    }
}