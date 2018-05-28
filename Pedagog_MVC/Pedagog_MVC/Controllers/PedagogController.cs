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
            Pedagog ped = new Pedagog();

            return View(ped);
        }

        [HttpPost]
        public ActionResult Prijava(Pedagog p)
        {
            foreach (Pedagog ped in baza.Pedagozi)
            {
                if (ped.lozinka == p.lozinka && ped.mail == p.mail)
                {
                    return RedirectToAction("AdminIndex");
                }
            }
            return RedirectToAction("Prijava");
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
            return View();
        }
		
        public ActionResult Tables_Ucenici_Lista()
		{
			return View();
		}
		
        public ActionResult Public()
        {
            return View();
        }

        public ActionResult TablesRadni()
        {
            return View(baza.Adresari);
        }

        public ActionResult TablesRadni2()
        {
            return View();
        }

        public ActionResult TablesRadni3()
        {
            return View();
        }
        
        public ActionResult Tables_ucenici()
        {
            return View();
        }
        
          public ActionResult TablesRadniForma()
        {
            return View();
        }

		public ActionResult UceniciPopisUcenici()
        {
            return View();
        }
		
        public ActionResult Tables_Ucenici_Popis()
		{
			return View();
		}
		public ActionResult UceniciPopisUceniciFormiranje()
        {
            return View();
        }
		
        public ActionResult Tables_Ucenici_Popis_Detalji()
		{
			return View();
		}

		public ActionResult UceniciPopisDetalji()
        {
            return View();
        }
		
        public ActionResult Tables_Ucenici_Popis_Osobni()
        {
            return View();
        }

        public ActionResult Tables()
        {
            return View();
        }



        public ActionResult DodajAdresar()
        {
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("DodajAdresar");
            }
            else

                return View("DodajAdresar");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> DodajAdresar(Adresar ad)
        {

            if (ModelState.IsValid)
            {
                baza.Adresari.Add(ad);
                baza.SaveChanges();
                return RedirectToAction("TablesRadni");
            }

            else
                return RedirectToAction("DodajAdresar");

        }

        [HttpGet]
        public ActionResult UrediAdresar(int id)
        {
            Adresar adr = new Adresar();
           
            
            foreach( Adresar a in baza.Adresari)
            {
                if (a.id_kontakt == id)
                {
                    adr = a;
                }
            }


            if (adr == null)
            {
                return HttpNotFound();
            }
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("UrediAdresar", adr);
            }
            else

                return View("UrediAdresar", adr);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult UrediAdresar([Bind(Include = "id_kontakt, id_pedagog, naziv, adresa, grad, tel, mail, opis")] Adresar ad)
        {



            if (!ModelState.IsValid)
            {
                return PartialView("UrediAdresar", ad);
            }
            Adresar G = baza.Adresari.Where(
              x => x.id_kontakt == ad.id_kontakt).SingleOrDefault();

            if (ad.id_kontakt != 0 && G != null)// update
            {
                baza.Entry(G).CurrentValues.SetValues(ad);
            }
            else
            {
                baza.Adresari.Add(ad);
            }
            baza.SaveChanges();
            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return RedirectToAction("TablesRadni");

        }


        public ActionResult ObrisiAdresar(int id)
        {
            Adresar ad = baza.Adresari.Find(id);
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("ObrisiAdresar", ad);
            }
            else

                return View("ObrisiAdresar", ad);
        }

        [HttpPost, ActionName("ObrisiAdresar")]
        [ValidateAntiForgeryToken]
        public ActionResult ObrisiAdresar1(int id)
        {
            Adresar A = baza.Adresari.Where(
              x => x.id_kontakt == id).SingleOrDefault();

            if (A != null)
            {
                baza.Adresari.Remove(A);
                baza.SaveChanges();
            }
            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return RedirectToAction("TablesRadni");
        }


        [HttpGet]
        public ActionResult InfoAdresar(int id)
        {
            Adresar ad = baza.Adresari.Find(id);


            return View(ad);

        }

    }
}
