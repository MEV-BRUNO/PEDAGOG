using Pedagog_MVC.BazaPovezivanje;
using ProjektIdio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models.PomocniModelOsobni
{
    public class ModelOS
    {

        BazaDbContext baza = new BazaDbContext();

        public Ucenik ucenik { get; set; }

        public List<Obitelj> obitelj { get; set; }


        public Ucenik_biljeska biljeska { get; set; }


        public void Init(long id, BazaDbContext baza)
        {

            obitelj = new List<Obitelj>();

            ucenik = baza.Ucenici.Find(id);

            biljeska = baza.UcBiljeske.Where(x => x.id_ucenik == id).SingleOrDefault();


            foreach (Obitelj ob in baza.Obitelji)
            {
                if (ob.id_ucenik == id)
                {
                    obitelj.Add(ob);
                }
            }

        }

    }
}