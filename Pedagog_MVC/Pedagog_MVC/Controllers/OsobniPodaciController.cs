using Pedagog_MVC.BazaPovezivanje;
using ProjektIdio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Pedagog_MVC.Controllers
{
    public class OsobniPodaciController : Controller
    {

        private BazaDbContext baza = new BazaDbContext();

        public ActionResult Tables_Ucenici_Popis_Osobni()
        {
            if (Sesija.Trenutni.PedagogId > 0)
            {
                return View(baza.Ucenici);
            }
            else
                return RedirectToAction("Prijava", "Pedagog");
        }

        [HttpGet]
        public ActionResult OsobniPartial(long id)
        {
            
                Ucenik uc = baza.Ucenici.Find(id);

                return View(uc);
            
           
        }


        [HttpPost]
        public ActionResult OsobniPartial(Ucenik uc)
        {

            //if (!ModelState.IsValid)
            //{
            //    return PartialView("OsobniPartial");
            //}

            Ucenik U = baza.Ucenici.Where(
              x => x.id_ucenik == uc.id_ucenik).SingleOrDefault();

            if (uc.id_ucenik != 0 && U != null)// update
            {
                baza.Entry(U).CurrentValues.SetValues(uc);
            }
            else
            {
                baza.Ucenici.Add(uc);
            }
            baza.SaveChanges();

            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return RedirectToAction("Tables_Ucenici_Popis_Osobni");



        }

    }
}