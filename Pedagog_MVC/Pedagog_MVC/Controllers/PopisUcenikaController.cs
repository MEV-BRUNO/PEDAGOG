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
    public class PopisUcenikaController : Controller
    {
        private BazaDbContext baza = new BazaDbContext();

        public ActionResult UceniciPopisUcenici()
        {
            if (Sesija.Trenutni.PedagogId > 0)
            {
                ViewBag.baza = baza;

                List<Razredni_odjel> razredi = baza.Razredi.ToList();

                return View(razredi);
            }
            else return RedirectToAction("Prijava", "Pedagog");
        }


        public ActionResult UceniciPopisUceniciFormiranje(int id)
        {
            if (Sesija.Trenutni.PedagogId > 0)
            {
                List<ModelPU> ucenici = new List<ModelPU>();


                Razredni_odjel razred = baza.Razredi.Where(x => x.id_odjel == id).SingleOrDefault();




                foreach (Godina_ucenik uc in baza.godineUc)
                {
                    if (uc.id_odjel == razred.id_odjel)
                    {
                        ModelPU model = new ModelPU();
                        model.godUcenik = uc;
                        model.ucenik = new Ucenik();
                        ucenici.Add(model);
                    }
                }


                for (int i = 0; i < ucenici.Count(); i++)
                {

                    foreach (Ucenik uc in baza.Ucenici)
                    {
                        if (uc.id_ucenik == ucenici[i].godUcenik.id_ucenik)
                        {


                            ucenici[i].ucenik = uc;

                        }
                    }

                }



                ViewBag.razred = razred;
                ViewBag.razrednik = baza.Nastavnici.Where(x => x.id_nastavnik == razred.id_razrednik).SingleOrDefault();


                ViewBag.baza = baza;
                return View(ucenici);
            }
            else return RedirectToAction("Prijava", "Pedagog");
        }


        [HttpGet]
        public ActionResult UrediPopis(int id)
        {
            Razredni_odjel raz = new Razredni_odjel();

            ViewBag.baza = baza;

            foreach (Razredni_odjel a in baza.Razredi)
            {
                if (a.id_odjel == id)
                {
                    raz = a;
                }
            }


            if (raz == null)
            {
                return HttpNotFound();
            }
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("UrediPopis", raz);
            }
            else

                return View("UrediPopis", raz);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult UrediPopis(Razredni_odjel raz)
        {


            //if (!ModelState.IsValid)
            //{
            //    return PartialView("UrediPopis", raz);
            //}
            Razredni_odjel R = baza.Razredi.Where(
              x => x.id_odjel == raz.id_odjel).SingleOrDefault();

            if (raz.id_odjel != 0 && R != null)// update
            {
                baza.Entry(R).CurrentValues.SetValues(raz);
            }
            else
            {
                baza.Razredi.Add(raz);
            }

            baza.SaveChanges();



            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);

            }

            return RedirectToAction("UceniciPopisUcenici");

        }


        public ActionResult ObrisiPopis(int id)
        {
            Razredni_odjel raz = baza.Razredi.Find(id);
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("ObrisiPopis", raz);
            }
            else

                return View("ObrisiPopis", raz);
        }

        [HttpPost, ActionName("ObrisiPopis")]
        [ValidateAntiForgeryToken]
        public ActionResult ObrisiPopis1(int id)
        {
            Razredni_odjel R = baza.Razredi.Where(
              x => x.id_odjel == id).SingleOrDefault();

            if (R != null)
            {
                baza.Razredi.Remove(R);
                baza.SaveChanges();
            }
            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return RedirectToAction("UceniciPopisUcenici");
        }


        public ActionResult DodajUcenika(long id)
        {

            Godina_ucenik god = baza.godineUc.Find(id);

            ViewBag.IdRaz = god.id_razrednik;
            ViewBag.IdOdjel = god.id_odjel;
            ViewBag.IdSkola = god.id_skola;

            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("DodajUcenika");
            }
            else

                return View("DodajUcenika");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> DodajUcenika(ModelPU model)
        {

            Godina_ucenik god = model.godUcenik;
            Ucenik uc = model.ucenik;

            if (ModelState.IsValid)
            {
                baza.Ucenici.Add(uc);
                baza.godineUc.Add(god);
                baza.SaveChanges();
                return RedirectToAction("UceniciPopisUcenici");
            }

            else
                return RedirectToAction("DodajUcenika");

        }


        public ActionResult DodajPopis()
        {

            
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("DodajPopis");
            }
            else

                return View("DodajPopis");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> DodajPopis(Razredni_odjel raz)
        {

            if (ModelState.IsValid)
            {
                baza.Razredi.Add(raz);
                baza.SaveChanges();
                return RedirectToAction("UceniciPopisUcenici");
            }

            else
                return RedirectToAction("DodajPopis");

        }


        public ActionResult ObrisiUcenika(int id)
        {
            Godina_ucenik ad = baza.godineUc.Find(id);
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("ObrisiUcenika", ad);
            }
            else

                return View("ObrisiUcenika", ad);
        }

        [HttpPost, ActionName("ObrisiUcenika")]
        [ValidateAntiForgeryToken]
        public ActionResult ObrisiUcenika1(int id)
        {
            Godina_ucenik A = baza.godineUc.Where(
              x => x.id_ucenik == id).SingleOrDefault();

            if (A != null)
            {
                baza.godineUc.Remove(A);
                baza.SaveChanges();
            }

            Ucenik U = baza.Ucenici.Where(
              x => x.id_ucenik == id).SingleOrDefault();

            if (U != null)
            {
                baza.Ucenici.Remove(U);
                baza.SaveChanges();
            }


            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return RedirectToAction("TablesRadni");
        }
    }
}