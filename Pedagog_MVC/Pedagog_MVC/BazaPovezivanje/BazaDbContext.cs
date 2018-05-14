using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Pedagog_MVC.Models;

namespace Pedagog_MVC.BazaPovezivanje
{
    public class BazaDbContext : DbContext
    {

        public DbSet<Pedagog> Pedagozi { get; set; }

    }
}