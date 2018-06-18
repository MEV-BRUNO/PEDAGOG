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
    public class RazredniOdjeliController : Controller
    {
        // GET: RazredniOdjeli
        private BazaDbContext odjeli = new BazaDbContext();


        public ActionResult TablesRazredniOdjel()
        {
            return View(odjeli.Razredi);
        }



        public ActionResult DodajOdjel()
        {
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("DodajOdjel");
            }
            else

                return View("DodajOdjel");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> DodajOdjel(Razredni_odjel rz)
        {

            if (ModelState.IsValid)
            {
                odjeli.Razredi.Add(rz);
                odjeli.SaveChanges();
                return RedirectToAction("TablesRazredniOdjel");//zamjeni
            }

            else
                return RedirectToAction("DodajOdjel");

        }


        [HttpGet]
        public ActionResult UrediRazredni_odjel(int id)
        {
            Razredni_odjel rz = new Razredni_odjel();


            foreach (Razredni_odjel rz1 in odjeli.Razredi)
            {
                if (rz1.id_odjel == id)
                {
                    rz = rz1;
                }
            }


            if (rz == null)
            {
                return HttpNotFound();
            }
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("UrediRazredni_odjel", rz);
            }
            else

                return View("UrediRazredni_odjel", rz);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult UrediRazredni_odjel([Bind(Include = "id_odjel,godina,naziv,razred,id_razrednik,os_ss,program,usmjerenje,broj_z,broj_m")] Razredni_odjel rz)
        {



            if (!ModelState.IsValid)
            {
                return PartialView("UrediRazredni_odjel", rz);
            }
            Razredni_odjel R = odjeli.Razredi.Where(
              x => x.id_odjel == rz.id_odjel).SingleOrDefault();

            if (rz.id_odjel != 0 && R != null)// update
            {
                odjeli.Entry(R).CurrentValues.SetValues(rz);
            }
            else
            {
                odjeli.Razredi.Add(rz);
            }
            odjeli.SaveChanges();
            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return RedirectToAction("TablesRazredniOdjel");//zamjeni

        }

        public ActionResult ObrisiOdjel(int id)
        {
            Razredni_odjel rz = odjeli.Razredi.Find(id);
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("ObrisiOdjel", rz);
            }
            else

                return View("ObrisiOdjel", rz);
        }

        [HttpPost, ActionName("ObrisiOdjel")]
        [ValidateAntiForgeryToken]
        public ActionResult ObrisiOdjel1(int id)
        {
            Razredni_odjel R = odjeli.Razredi.Where(
              x => x.id_odjel == id).SingleOrDefault();

            if (R != null)
            {
                odjeli.Razredi.Remove(R);
                odjeli.SaveChanges();
            }
            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return RedirectToAction("TablesRazredniOdjel");//promjeni
        }

        [HttpGet]
        public ActionResult InfoOdjel(int id)
        {
            Razredni_odjel rz = odjeli.Razredi.Find(id);


            return View(rz);

        }


    }
}