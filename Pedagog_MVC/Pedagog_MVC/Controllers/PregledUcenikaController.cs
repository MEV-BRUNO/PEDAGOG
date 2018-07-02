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
    public class PregledUcenikaController : Controller
    {

        BazaDbContext baza = new BazaDbContext();


        public ActionResult TablesRadni3()
        {
            if (Sesija.Trenutni.PedagogId > 0)
            {

                List<SelectListItem> razredi = new List<SelectListItem>();

                razredi.Add(new SelectListItem
                {

                    Text = "---",
                    Value = "",
                    Selected = true

                });

                foreach (Razredni_odjel raz in baza.Razredi)
                {
                    razredi.Add(new SelectListItem
                    {
                        Text = raz.naziv,
                        Value = raz.naziv
                    });

                }

              


                ViewBag.razredi = razredi;

                ViewBag.baza = baza;
                return View(baza.Ucenici);
            }
            else
               return RedirectToAction("Prijava","Pedagog");
        }


        public PartialViewResult Partial(string razred, int? spol)
        {
            List<Godina_ucenik> lista = baza.godineUc.ToList();

            Razredni_odjel raz = new Razredni_odjel();


            List<Ucenik> popis = baza.Ucenici.ToList();


            // filtriranje popisa - naziv
            if (!String.IsNullOrEmpty(razred))
            {

                foreach (Godina_ucenik li in lista)
                {

                    Razredni_odjel pomoc = baza.Razredi.Find(li.id_odjel);

                    if (pomoc.naziv == razred)
                    {
                        raz = pomoc;
                        break;
                    }

                }

                lista = lista.Where(x => x.id_odjel == raz.id_odjel).ToList();


                popis.Clear();

                foreach (Godina_ucenik god in lista)
                {
                    popis.Add(baza.Ucenici.Find(god.id_ucenik));
                }

            }



            return PartialView(popis);
        }


        [HttpGet]
        public ActionResult UrediUcenika(int id)
        {
            Ucenik model = baza.Ucenici.Find(id);
        


            if (model == null)
            {
                return HttpNotFound();
            }
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("UrediUcenika", model);
            }
            else

                return View("UrediUcenika", model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult UrediUcenika(Ucenik uc)
        {


            if (ModelState.IsValid)
            {

               


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

                return RedirectToAction("TablesRadni3");
            }

            else
                return RedirectToAction("UrediUcenika", uc.id_ucenik);
        }


        public ActionResult ObrisiUcenika(int id)
        {
            Godina_ucenik ad = baza.godineUc.Find(id);

            ViewBag.ucenik = baza.Ucenici.Find(id);
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


            Ucenik_biljeska B = baza.UcBiljeske.Where(
              x => x.id_ucenik == id).SingleOrDefault();

            if (B != null)
            {
                baza.UcBiljeske.Remove(B);
                baza.SaveChanges();
            }

            Ucenik_lista_pracenja L = baza.Liste_Pracenja.Where(
              x => x.id_ucenik == id).SingleOrDefault();

            if (L != null)
            {
                baza.Liste_Pracenja.Remove(L);
                baza.SaveChanges();
            }


            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return RedirectToAction("TablesRadni3");
        }


        public ActionResult infoUcenik(long id)
        {
            Ucenik uc = baza.Ucenici.Find(id);


            return View(uc);


        }

    }
}