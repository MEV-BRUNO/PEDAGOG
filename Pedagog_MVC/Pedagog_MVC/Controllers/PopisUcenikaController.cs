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
           
            List<SelectListItem> razredi1 = new List<SelectListItem>();

            razredi1.Add(new SelectListItem
            {

                Text = "---",
                Value = "",
                Selected = true

            });

            foreach (Razredni_odjel raz in baza.Razredi)
            {
                razredi1.Add(new SelectListItem
                {
                    Text = raz.naziv,
                    Value = raz.naziv
                });

            }

            razredi1.Add(new SelectListItem
            {

                Text = "3.B",
                Value = "3.B",


            });


            ViewBag.razredi = razredi1;

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

                List<Godina_ucenik> godine = baza.godineUc.ToList();

                List<Ucenik_lista_pracenja> liste = baza.Liste_Pracenja.ToList();

                List<Ucenik_biljeska> biljeske = baza.UcBiljeske.ToList();

                Razredni_odjel razred = baza.Razredi.Find(id);


                foreach (Godina_ucenik uc in godine)
                {

                    foreach (Ucenik_lista_pracenja lista in liste)
                    {

                        foreach (Ucenik_biljeska biljeska in biljeske)
                        {

                            foreach (Ucenik uce in baza.Ucenici)
                            {
                                if (uc.id_odjel == razred.id_odjel && uce.id_ucenik == uc.id_ucenik && lista.id_ucenik==uce.id_ucenik && biljeska.id_ucenik==uce.id_ucenik)
                                {
                                    ModelPU model = new ModelPU();
                                    model.godUcenik = uc;
                                    model.ucenik = uce;
                                    model.lista = lista;
                                    model.biljeska = biljeska;
                                    ucenici.Add(model);
                                    break;
                                }
                            }
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


        public ActionResult DodajUcenika(long idRaz, long idOdjel, long idSkola)
        {

           

            ViewBag.IdRaz = idRaz;
            ViewBag.IdOdjel = idOdjel;
            ViewBag.IdSkola = idSkola;

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
            Ucenik_lista_pracenja lista = model.lista;
            Ucenik_biljeska biljeska = model.biljeska;


  
 

           
                baza.Ucenici.Add(uc);
                baza.godineUc.Add(god);
                
                baza.SaveChanges();


                biljeska.id_ucenik = uc.id_ucenik;
                lista.id_ucenik = god.id_ucenik;
                baza.UcBiljeske.Add(biljeska);
                baza.Liste_Pracenja.Add(lista);

                baza.SaveChanges();

                return RedirectToAction("UceniciPopisUcenici");
            

          

        }


        public ActionResult DodajPopis()
        {
            
            

            List<SelectListItem> nastavnici = new List<SelectListItem>();

            foreach(Nastavnik nast in baza.Nastavnici)
            {
                nastavnici.Add(new SelectListItem { Selected = false, Text = nast.ime_prezime, Value = nast.id_nastavnik.ToString() });
            }

            ViewBag.nastavnici = nastavnici;

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

            return RedirectToAction("UceniciPopisUcenici");
        }


        [HttpGet]
        public ActionResult UrediUcenika(int id)
        {
            ModelPU model = new ModelPU();


            foreach (Ucenik uc in baza.Ucenici)
            {
                if (uc.id_ucenik == id)
                {
                    model.ucenik = uc;
                }
            }


            foreach (Godina_ucenik god in baza.godineUc)
            {
                if (god.id_ucenik == id)
                {
                    model.godUcenik = god;
                }
            }


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
        public ActionResult UrediUcenika(ModelPU model)
        {


            if (ModelState.IsValid)
            {

                Ucenik uc = model.ucenik;
                Godina_ucenik god = model.godUcenik;

      
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

                Godina_ucenik G = baza.godineUc.Where(
                  x => x.id_ucenik == god.id_ucenik).SingleOrDefault();

                if (god.id_ucenik != 0 && G != null)// update
                {
                    baza.Entry(G).CurrentValues.SetValues(god);
                }
                else
                {
                    baza.godineUc.Add(god);
                }
                baza.SaveChanges();



                if (Request.IsAjaxRequest())
                {
                    return new HttpStatusCodeResult(HttpStatusCode.OK);
                }

                return RedirectToAction("UceniciPopisUcenici");
            }

            else
                return RedirectToAction("UrediUcenika", model.ucenik.id_ucenik);
        }

    }
}