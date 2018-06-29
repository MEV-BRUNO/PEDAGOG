using Pedagog_MVC.BazaPovezivanje;
using Pedagog_MVC.fonts;
using Pedagog_MVC.Models;
using Pedagog_MVC.Models.PomocniModelPopisUc;
using ProjektIdio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Pedagog_MVC.Controllers
{
    public class PregledPedagogaController : Controller
    {

        BazaDbContext baza = new BazaDbContext();


        public ActionResult PedagogTables()
        {
            List<Skola> skole = baza.skole.ToList();

            if (Sesija.Trenutni.PedagogId > 0)
            {
                ViewBag.skole = skole;
                return View(baza.Pedagozi);
            }

            else
                return RedirectToAction("Prijava", "Pedagog");

        }


        [HttpGet]
        public ActionResult UrediPedagoga(int id)
        {
            Pedagog model = baza.Pedagozi.Find(id);



            if (model == null)
            {
                return HttpNotFound();
            }
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("UrediPedagoga", model);
            }
            else

                return View("UrediPedagoga", model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult UrediPedagoga(Pedagog ped)
        {


            if (ModelState.IsValid)
            {




                Pedagog P = baza.Pedagozi.Where(
                  x => x.id_pedagog == ped.id_pedagog).SingleOrDefault();

                if (ped.id_pedagog != 0 && P != null)// update
                {
                    baza.Entry(P).CurrentValues.SetValues(ped);
                }
                else
                {
                    baza.Pedagozi.Add(ped);
                }
                baza.SaveChanges();




                if (Request.IsAjaxRequest())
                {
                    return new HttpStatusCodeResult(HttpStatusCode.OK);
                }

                return RedirectToAction("PedagogTables");
            }

            else
                return RedirectToAction("UrediPedagoga", ped.id_pedagog);
        }


        public ActionResult ObrisiPedagoga(int id)
        {
            Pedagog ad = baza.Pedagozi.Find(id);

            ViewBag.pedagog = baza.Pedagozi.Find(id);
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("ObrisiPedagoga", ad);
            }
            else

                return View("ObrisiPedagoga", ad);
        }

        [HttpPost, ActionName("ObrisiPedagoga")]
        [ValidateAntiForgeryToken]
        public ActionResult ObrisiPedagoga1(int id)
        {
            Pedagog A = baza.Pedagozi.Where(
              x => x.id_pedagog == id).SingleOrDefault();

            if (A != null)
            {
                baza.Pedagozi.Remove(A);
                baza.SaveChanges();
            }



            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return RedirectToAction("PedagogTables");
        }


        public ActionResult infoPedagog(long id)
        {
            Pedagog ped = baza.Pedagozi.Find(id);


            return View(ped);


        }


        public ActionResult DodajPedagoga()
        {


            List<SelectListItem> skole = new List<SelectListItem>();

            foreach (Skola skola in baza.skole)
            {
                skole.Add(new SelectListItem { Selected = false, Text = skola.naziv, Value = skola.id_skola.ToString() });
            }

            ViewBag.skole = skole;

            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("DodajPedagoga");
            }
            else

                return View("DodajPedagoga");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> DodajPedagoga(Pedagog ped)
        {

            if (ModelState.IsValid)
            {
                baza.Pedagozi.Add(ped);
                baza.SaveChanges();
                return RedirectToAction("PedagogTables");
            }

            else
                return RedirectToAction("DodajPedagoga");

        }


    }
}