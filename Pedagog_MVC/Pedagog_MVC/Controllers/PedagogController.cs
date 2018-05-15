using Pedagog_MVC.BazaPovezivanje;
using Pedagog_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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


        public ActionResult Public()
        {
            return View();
        }

        public ActionResult TablesRadni()
        {
            return View();
        }

        public ActionResult TablesRadni2()
        {
            return View();
        }

        public ActionResult TablesRadni3()
        {
            return View();
        }

        public ActionResult TablesRadniForma()
        {
            return View();
        }
    }
}