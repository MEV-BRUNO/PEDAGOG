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
    public class SkolskaGodinaController : Controller
    {
        // GET: SkolskaGodina
        private BazaDbContext skolska_godina = new BazaDbContext();
        public ActionResult TablesSkolskaGodina()
        {
            if (Sesija.Trenutni.PedagogId > 0)
            {
                return View(skolska_godina.skolske_godine);
            }
            else
                return RedirectToAction("Prijava", "Pedagog");
        }

        public ActionResult DodajSkolskuGodinu()
        {
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("DodajSkolskuGodinu");
            }
            else

                return View("DodajSkolskuGodinu");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> DodajSkolskuGodinu(SkolskaGodina sk)
        {

            if (ModelState.IsValid)
            {
                skolska_godina.skolske_godine.Add(sk);
                skolska_godina.SaveChanges();
                return RedirectToAction("TablesSkolskaGodina");
            }

            else
                return RedirectToAction("DodajSkolskuGodinu");

        }

        [HttpGet]
        public ActionResult UrediSkolskuGodinu(int id)
        {
            SkolskaGodina sk = new SkolskaGodina();


            foreach (SkolskaGodina sk1 in skolska_godina.skolske_godine)
            {
                if (sk1.id_skolska_godina == id)
                {
                    sk = sk1;
                }
            }


            if (sk == null)
            {
                return HttpNotFound();
            }
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("UrediSkolskuGodinu", sk);
            }
            else

                return View("UrediSkolskuGodinu", sk);
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult UrediSkolskuGodinu([Bind(Include = "id_skolska_godina,godina")] SkolskaGodina sk)
        {



            if (!ModelState.IsValid)
            {
                return PartialView("UrediSkolskuGodinu", sk);
            }
            SkolskaGodina SK = skolska_godina.skolske_godine.Where(
              x => x.id_skolska_godina == sk.id_skolska_godina).SingleOrDefault();

            if (sk.id_skolska_godina != 0 && SK != null)// update
            {
                skolska_godina.Entry(SK).CurrentValues.SetValues(sk);
            }
            else
            {
                skolska_godina.skolske_godine.Add(sk);
            }
            skolska_godina.SaveChanges();
            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return RedirectToAction("TablesSkolskaGodina");//zamjeni

        }

        public ActionResult ObrisiSkolskuGodinu(int id)
        {
            SkolskaGodina sk = skolska_godina.skolske_godine.Find(id);
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("ObrisiSkolskuGodinu", sk);
            }
            else

                return View("ObrisiSkolskuGodinu", sk);
        }

        [HttpPost, ActionName("ObrisiSkolskuGodinu")]
        [ValidateAntiForgeryToken]
        public ActionResult ObrisiSkolskuGodinu1(int id)
        {
            SkolskaGodina SK = skolska_godina.skolske_godine.Where(
              x => x.id_skolska_godina == id).SingleOrDefault();

            if (SK != null)
            {
                skolska_godina.skolske_godine.Remove(SK);
                skolska_godina.SaveChanges();
            }
            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return RedirectToAction("TablesSkolskaGodina");//promjeni
        }
    }
}