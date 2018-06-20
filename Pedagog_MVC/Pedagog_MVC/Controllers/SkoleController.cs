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
    public class SkoleController : Controller
    {
        // GET: Skole
        private BazaDbContext skola = new BazaDbContext();
        public ActionResult TablesSkole()
        {
            if (Sesija.Trenutni.PedagogId > 0)
            {
                return View(skola.skole);
            }
            else
                return RedirectToAction("Prijava", "Pedagog");
        }

        public ActionResult DodajSkolu()
        {
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("DodajSkolu");
            }
            else

                return View("DodajSkolu");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> DodajSkolu(Skola sk)
        {

            if (ModelState.IsValid)
            {
                skola.skole.Add(sk);
                skola.SaveChanges();
                return RedirectToAction("TablesSkole");
            }

            else
                return RedirectToAction("DodajSkolu");

        }

        [HttpGet]
        public ActionResult UrediSkolu(int id)
        {
            Skola sk = new Skola();


            foreach (Skola sk1 in skola.skole)
            {
                if (sk1.id_skola == id)
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
                return View("UrediSkolu", sk);
            }
            else

                return View("UrediSkolu", sk);
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult UrediSkolu([Bind(Include = "id_skola,naziv,adresa,grad,oib,mail,tel,opis")] Skola sk)
        {



            if (!ModelState.IsValid)
            {
                return PartialView("UrediSkolu", sk);
            }
            Skola S = skola.skole.Where(
              x => x.id_skola == sk.id_skola).SingleOrDefault();

            if (sk.id_skola != 0 && S != null)// update
            {
                skola.Entry(S).CurrentValues.SetValues(sk);
            }
            else
            {
                skola.skole.Add(sk);
            }
            skola.SaveChanges();
            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return RedirectToAction("TablesSkole");//zamjeni

        }

        public ActionResult ObrisiSkolu(int id)
        {
            Skola sk = skola.skole.Find(id);
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("ObrisiSkolu", sk);
            }
            else

                return View("ObrisiSkolu", sk);
        }

        [HttpPost, ActionName("ObrisiSkolu")]
        [ValidateAntiForgeryToken]
        public ActionResult ObrisiSkolu1(int id)
        {
            Skola S = skola.skole.Where(
              x => x.id_skola == id).SingleOrDefault();

            if (S != null)
            {
                skola.skole.Remove(S);
                skola.SaveChanges();
            }
            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return RedirectToAction("TablesSkole");//promjeni
        }

        [HttpGet]
        public ActionResult InfoSkola(int id)
        {
            Skola sk = skola.skole.Find(id);


            return View(sk);

        }
    }
}