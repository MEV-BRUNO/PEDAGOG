using Pedagog_MVC.BazaPovezivanje;
using Pedagog_MVC.Models;
using Pedagog_MVC.Models.PomocniModelOsobni;
using ProjektIdio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Pedagog_MVC.fonts;

namespace Pedagog_MVC.Controllers
{
    public class OsobniPodaciController : Controller
    {

        private BazaDbContext baza = new BazaDbContext();

        public PartialViewResult Partial(string razred)
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

                foreach(Godina_ucenik god in lista)
                {
                    popis.Add(baza.Ucenici.Find(god.id_ucenik));
                }

            }

           

            return PartialView(popis);
        }

        public ActionResult Tables_Ucenici_Popis_Osobni()
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

            Ucenik_lista_pracenja lst = baza.Liste_Pracenja.Where(x => x.id_ucenik == id).SingleOrDefault();

            ViewBag.razred = baza.Razredi.Find(lst.id_odjel);

            ModelOS model = new ModelOS();

            model.Init(id, baza);

            return View(model);
            
           
        }


        [HttpPost]
        public ActionResult OsobniPartial(ModelOS model)
        {

           
           

            if (ModelState.IsValid)
            {
                //spremanje promjena o modelu ucenik
                Ucenik uc = model.ucenik;

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


                //spremanje promjena o modelu lista pracenja
                Ucenik_biljeska biljeska = model.biljeska;

                Ucenik_biljeska L = baza.UcBiljeske.Where(
                  x => x.id_biljeska == biljeska.id_biljeska).SingleOrDefault();

                if (biljeska.id_biljeska != 0 && L != null)// update
                {
                    baza.Entry(L).CurrentValues.SetValues(biljeska);
                }
                else
                {
                    baza.UcBiljeske.Add(biljeska);
                }
                baza.SaveChanges();





                if (Request.IsAjaxRequest())
                {
                    return new HttpStatusCodeResult(HttpStatusCode.OK);
                }





                return RedirectToAction("Tables_Ucenici_Popis_Osobni");
            }
            else
                return RedirectToAction("Tables_Ucenici_Popis_Osobni");



        }


        [HttpGet]
        public ActionResult UrediClana(int id)
        {
            Obitelj obi = new Obitelj();


            foreach (Obitelj ob in baza.Obitelji)
            {
                if (ob.id_obitelj == id)
                {
                    obi = ob;
                }
            }


            if (obi == null)
            {
                return HttpNotFound();
            }
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("UrediClana", obi);
            }
            else

                return View("UrediClana", obi);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult UrediClana(Obitelj obi)
        {


            if (ModelState.IsValid)
            {

                Obitelj O = baza.Obitelji.Where(
                  x => x.id_obitelj == obi.id_obitelj).SingleOrDefault();

                if (obi.id_obitelj != 0 && O != null)// update
                {
                    baza.Entry(O).CurrentValues.SetValues(obi);
                }
                else
                {
                    baza.Obitelji.Add(obi);
                }
                baza.SaveChanges();
                if (Request.IsAjaxRequest())
                {
                    return new HttpStatusCodeResult(HttpStatusCode.OK);
                }

                return RedirectToAction("Tables_Ucenici_Popis_Osobni");
            }

            else
                return RedirectToAction("UrediClana", obi.id_ucenik);
        }

        public ActionResult ObrisiClana(int id)
        {
            Obitelj ad = baza.Obitelji.Find(id);
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("ObrisiClana", ad);
            }
            else

                return View("ObrisiClana", ad);
        }

        [HttpPost, ActionName("ObrisiClana")]
        [ValidateAntiForgeryToken]
        public ActionResult ObrisiClana1(int id)
        {
            Obitelj A = baza.Obitelji.Where(
              x => x.id_obitelj == id).SingleOrDefault();

            if (A != null)
            {
                baza.Obitelji.Remove(A);
                baza.SaveChanges();
            }
            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return RedirectToAction("Tables_Ucenici_Popis_Osobni");
        }


        [HttpGet]
        public ActionResult InfoClan(int id)
        {
            Obitelj ad = baza.Obitelji.Find(id);


            return View(ad);

        }

        public ActionResult DodajClana(long id)
        {

            ViewBag.id = id;
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("DodajClana");
            }
            else

                return View("DodajClana");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> DodajClana(Obitelj ad)
        {

            if (ModelState.IsValid)
            {
                baza.Obitelji.Add(ad);
                baza.SaveChanges();
                return RedirectToAction("Tables_Ucenici_Popis_Osobni");
            }

            else
                return RedirectToAction("DodajClana");

        }

    }
}