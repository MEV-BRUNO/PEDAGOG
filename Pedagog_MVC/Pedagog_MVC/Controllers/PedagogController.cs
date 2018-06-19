using Pedagog_MVC.BazaPovezivanje;
using Pedagog_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Pedagog_MVC.Controllers
{
    public class PedagogController : Controller
    {

        private BazaDbContext baza = new BazaDbContext();

        [HttpGet]
        public ActionResult Prijava()
        {

            Sesija.Trenutni.PedagogId = 0;

            Pedagog ped = new Pedagog();

            return View(ped);
        }

        [HttpPost]
        public ActionResult Prijava(Pedagog p)
        {
            Pedagog pedagog = baza.Pedagozi.SingleOrDefault(ped => ped.mail == p.mail && ped.lozinka == p.lozinka);

            if (pedagog != null)
            {
                Sesija.Trenutni.PedagogId = pedagog.id_pedagog;
                return RedirectToAction("AdminIndex");
            }

            else
            {
                return View("Prijava");
            }
        }

        public ActionResult Popis()
        {

            return View(baza.Pedagozi);
        }

        [HttpGet]
        public ActionResult Registracija()
        {
            Pedagog p = new Pedagog();

            return View(p);

        }

        public ActionResult Registracija(Pedagog p)
        {
            if (ModelState.IsValid)
            {
                baza.Pedagozi.Add(p);
                baza.SaveChanges();
                return RedirectToAction("AdminIndex");
            }

            return RedirectToAction("Registracija");
        }


        public ActionResult ZaboravljenaLozinka()
        {
            return View();
        }

        public ActionResult AdminIndex()
        {
            if (Sesija.Trenutni.PedagogId > 0)
            {
                return View();
            }

            else
                return RedirectToAction("Prijava");
        }
		
        
		
        public ActionResult Public()
        {
            return View();
        }

        

        public ActionResult TablesRadni2()
        {
            if (Sesija.Trenutni.PedagogId > 0)
            {
                return View();
            }
            else
                return RedirectToAction("Prijava");
        }

        public ActionResult TablesRadni3()
        {
            if (Sesija.Trenutni.PedagogId > 0)
            {
                return View();
            }
            else
                return RedirectToAction("Prijava");
        }
        
        public ActionResult Tables_ucenici()
        {
            if (Sesija.Trenutni.PedagogId > 0)
            {
                return View();
            }
            else
                return RedirectToAction("Prijava");
        }
        
          public ActionResult TablesRadniForma()
        {
            if (Sesija.Trenutni.PedagogId > 0)
            {
                return View();
            }
            else
                return RedirectToAction("Prijava");
        }

		public ActionResult UceniciPopisUcenici()
        {
            if (Sesija.Trenutni.PedagogId > 0)
            {
                return View();
            }
            else
                return RedirectToAction("Prijava");
        }
		
        public ActionResult Tables_Ucenici_Popis()
		{
            if (Sesija.Trenutni.PedagogId > 0)
            {
                return View();
            }
            else
                return RedirectToAction("Prijava");
        }
		
		
        public ActionResult Tables_Ucenici_Popis_Detalji()
		{
            if (Sesija.Trenutni.PedagogId > 0)
            {
                return View();
            }
            else
                return RedirectToAction("Prijava");
        }

		public ActionResult UceniciPopisDetalji()
        {
            if (Sesija.Trenutni.PedagogId > 0)
            {
                return View();
            }
            else
                return RedirectToAction("Prijava");
        }
		
      

        public ActionResult Tables()
        {
            if (Sesija.Trenutni.PedagogId > 0)
            {
                return View();
            }
            else
                return RedirectToAction("Prijava");
        }

        public ActionResult Tables_Nastavnik_Razrednik_Profil_Detalji()
        {
            if (Sesija.Trenutni.PedagogId > 0)
            {
                return View();
            }
            else
                return RedirectToAction("Prijava");
        }

        public ActionResult Ucenici_Zapisnik_Napredovanje()
        {
            if (Sesija.Trenutni.PedagogId > 0)
            {
                return View();
            }
            else
                return RedirectToAction("Prijava");
        }

        public ActionResult Ucenici_Zapisnik_Pracenja()
        {
            if (Sesija.Trenutni.PedagogId > 0)
            {
                return View();
            }
            else
                return RedirectToAction("Prijava");
        }

        public ActionResult Ucenici_Zapisnik_Pracenja_02()
        {
            if (Sesija.Trenutni.PedagogId > 0)
            {
                return View();
            }
            else
                return RedirectToAction("Prijava");
        }


        public ActionResult Ucenici_Zapisnik_Pracenja_03_Edit()
        {
            if (Sesija.Trenutni.PedagogId > 0)
            {
                return View();
            }
            else
                return RedirectToAction("Prijava");
        }

        public ActionResult Ucenici_Zapisnik_Pracenja_Novi_02()
        {
            if (Sesija.Trenutni.PedagogId > 0)
            {
                return View();
            }
            else
                return RedirectToAction("Prijava");
        }

        public ActionResult Protokol_Promatranja_Uredi()
        {
            if (Sesija.Trenutni.PedagogId > 0)
            {
                return View();
            }
            else
                return RedirectToAction("Prijava");
        }

        public ActionResult Protokol_Promatranja()
        {
            if (Sesija.Trenutni.PedagogId > 0)
            {
                return View();
            }
            else
                return RedirectToAction("Prijava");
        }



       

    }
}
