using Pedagog_MVC.BazaPovezivanje;
using Pedagog_MVC.fonts;
using Pedagog_MVC.Models;
using ProjektIdio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Pedagog_MVC.Controllers
{
    public class NastavnikController : Controller
    {
        // GET: Nastavnik
        
        private BazaDbContext nastavnik = new BazaDbContext();
        public ActionResult TablesPopisNastavnika()
        {
            if (Sesija.Trenutni.PedagogId > 0)
            {
                return View(nastavnik.Nastavnici);
            }
            else
                return RedirectToAction("Prijava", "Pedagog");
        }

        public ActionResult DodajNastavnika()
        {

            List<SelectListItem> skole = new List<SelectListItem>();

            foreach (Skola skola in nastavnik.skole)
            {
                skole.Add(new SelectListItem { Selected = false, Text = skola.naziv, Value = skola.id_skola.ToString() });
            }

            ViewBag.skole = skole;



            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("DodajNastavnika");
            }
            else

                return View("DodajNastavnika");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> DodajNastavnika(Nastavnik na)
        {

            if (ModelState.IsValid)
            {
                nastavnik.Nastavnici.Add(na);
                nastavnik.SaveChanges();
                return RedirectToAction("TablesPopisNastavnika");
            }

            else
                return RedirectToAction("TablesPopisNastavnika");

        }

        [HttpGet]
        public ActionResult UrediNastavnika(int id)
        {
            Nastavnik na = new Nastavnik();


            foreach (Nastavnik na1 in nastavnik.Nastavnici)
            {
                if (na1.id_nastavnik == id)
                {
                    na = na1;
                }
            }


            if (na == null)
            {
                return HttpNotFound();
            }
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("UrediNastavnika", na);
            }
            else

                return View("UrediNastavnika", na);
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult UrediNastavnika([Bind(Include = "id_nastavnik,id_skola,ime_prezime,titula, adresa")] Nastavnik na)
        {



            if (!ModelState.IsValid)
            {
                return PartialView("UrediNastavnika", na);
            }
            Nastavnik N = nastavnik.Nastavnici.Where(
              x => x.id_nastavnik == na.id_nastavnik).SingleOrDefault();

            if (na.id_nastavnik != 0 && N != null)// update
            {
                nastavnik.Entry(N).CurrentValues.SetValues(na);
            }
            else
            {
                nastavnik.Nastavnici.Add(na);
            }
            nastavnik.SaveChanges();
            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return RedirectToAction("TablesPopisNastavnika");//zamjeni

        }

        public ActionResult ObrisiNastavnika(int id)
        {
            Nastavnik na = nastavnik.Nastavnici.Find(id);
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("ObrisiNastavnika", na);
            }
            else

                return View("ObrisiNastavnika", na);
        }

        [HttpPost, ActionName("ObrisiNastavnika")]
        [ValidateAntiForgeryToken]
        public ActionResult ObrisiNastavnika1(int id)
        {
            Nastavnik N = nastavnik.Nastavnici.Where(
              x => x.id_nastavnik == id).SingleOrDefault();

            if (N != null)
            {
                nastavnik.Nastavnici.Remove(N);
                nastavnik.SaveChanges();
            }
            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return RedirectToAction("TablesPopisNastavnika");//promjeni
        }
    }
}