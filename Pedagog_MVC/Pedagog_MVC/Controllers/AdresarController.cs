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
    public class AdresarController : Controller
    {

        BazaDbContext baza = new BazaDbContext();

        public ActionResult TablesRadni()
        {
            return View(baza.Adresari);
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


            foreach (Adresar a in baza.Adresari)
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