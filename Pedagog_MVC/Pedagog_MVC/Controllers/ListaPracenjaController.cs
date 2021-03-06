﻿using Pedagog_MVC.BazaPovezivanje;
using Pedagog_MVC.fonts;
using Pedagog_MVC.Models;
using Pedagog_MVC.Models.PDF_Reports;
using Pedagog_MVC.Models.PomocniModelLista;
using ProjektIdio.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Pedagog_MVC.Controllers
{
    public class ListaPracenjaController : Controller
    {
        private BazaDbContext baza = new BazaDbContext();


        public PartialViewResult Partial(string razred, string s, string g, string m, string p)
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

        public ActionResult Tables_Ucenici_Lista()
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
        public ActionResult ListaPracenjaPartial(long id)
        {

            ModelLP model = new ModelLP();

            model.Init(id, baza);

            return View(model);

        }


        [HttpPost]
        public ActionResult ListaPracenjaPartial(ModelLP li)
        {
            if (ModelState.IsValid)
            {
                //spremanje promjena o modelu ucenik
                Ucenik uc = li.ucenik;

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
                Ucenik_lista_pracenja lista = li.listaPracenja;

                Ucenik_lista_pracenja L = baza.Liste_Pracenja.Where(
                  x => x.id_pracenje == lista.id_pracenje).SingleOrDefault();

                if (lista.id_pracenje != 0 && L != null)// update
                {
                    baza.Entry(L).CurrentValues.SetValues(lista);
                }
                else
                {
                    baza.Liste_Pracenja.Add(lista);
                }
                baza.SaveChanges();





                if (Request.IsAjaxRequest())
                {
                    return new HttpStatusCodeResult(HttpStatusCode.OK);
                }





                return RedirectToAction("Tables_Ucenici_Lista");
            }
            else
                return RedirectToAction("Tables_Ucenici_Lista");


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

                return RedirectToAction("Tables_Ucenici_Lista");
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

            return RedirectToAction("Tables_Ucenici_Lista");
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
                return RedirectToAction("Tables_Ucenici_Lista");
            }

            else
                return RedirectToAction("DodajClana");

        }


        public ActionResult DodajRad(long id)
        {

            ViewBag.id = id;
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("DodajRad");
            }
            else

                return View("DodajRad");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> DodajRad(Ucenik_neposredni_rad rad)
        {

            if (ModelState.IsValid)
            {
                baza.NeposredniRadoviUcenik.Add(rad);
                baza.SaveChanges();
                return RedirectToAction("Tables_Ucenici_Lista");
            }

            else
                return RedirectToAction("DodajRad");

        }


        [HttpGet]
        public ActionResult UrediRad(int id)
        {
            Ucenik_neposredni_rad obi = new Ucenik_neposredni_rad();


            foreach (Ucenik_neposredni_rad ob in baza.NeposredniRadoviUcenik)
            {
                if (ob.id_rad == id)
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
                return View("UrediRad", obi);
            }
            else

                return View("UrediRad", obi);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult UrediRad(Ucenik_neposredni_rad rad)
        {


            if (ModelState.IsValid)
            {

                Ucenik_neposredni_rad NR = baza.NeposredniRadoviUcenik.Where(
                  x => x.id_rad == rad.id_rad).SingleOrDefault();

                if (rad.id_rad != 0 && NR != null)// update
                {
                    baza.Entry(NR).CurrentValues.SetValues(rad);
                }
                else
                {
                    baza.NeposredniRadoviUcenik.Add(rad);
                }
                baza.SaveChanges();
                if (Request.IsAjaxRequest())
                {
                    return new HttpStatusCodeResult(HttpStatusCode.OK);
                }

                return RedirectToAction("Tables_Ucenici_Lista");
            }

            else
                return RedirectToAction("UrediRad", rad.id_rad);
        }

        public ActionResult ObrisiRad(int id)
        {
            Ucenik_neposredni_rad rad = baza.NeposredniRadoviUcenik.Find(id);
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("ObrisiRad", rad);
            }
            else

                return View("ObrisiRad", rad);
        }

        [HttpPost, ActionName("ObrisiRad")]
        [ValidateAntiForgeryToken]
        public ActionResult ObrisiRad1(int id)
        {
            Ucenik_neposredni_rad NR = baza.NeposredniRadoviUcenik.Where(
              x => x.id_rad == id).SingleOrDefault();

            if (NR != null)
            {
                baza.NeposredniRadoviUcenik.Remove(NR);
                baza.SaveChanges();
            }
            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return RedirectToAction("Tables_Ucenici_Lista");
        }


        public ActionResult DodajPostignuce(long id)
        {

            ViewBag.id = id;
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("DodajPostignuce");
            }
            else

                return View("DodajPostignuce");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> DodajPostignuce(Ucenik_obrazovna_postignuca post)
        {

            if (ModelState.IsValid)
            {
                baza.Postignuca.Add(post);
                baza.SaveChanges();
                return RedirectToAction("Tables_Ucenici_Lista");
            }

            else
                return RedirectToAction("DodajPostignuce");

        }


        [HttpGet]
        public ActionResult UrediPostignuce(int id)
        {
            Ucenik_obrazovna_postignuca post = new Ucenik_obrazovna_postignuca();


            foreach (Ucenik_obrazovna_postignuca po in baza.Postignuca)
            {
                if (po.id_postignuce == id)
                {
                    post = po;
                }
            }


            if (post == null)
            {
                return HttpNotFound();
            }
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("UrediPostignuce", post);
            }
            else

                return View("UrediPostignuce", post);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult UrediPostignuce(Ucenik_obrazovna_postignuca post)
        {


            if (ModelState.IsValid)
            {

                Ucenik_obrazovna_postignuca P = baza.Postignuca.Where(
                  x => x.id_postignuce == post.id_postignuce).SingleOrDefault();

                if (post.id_postignuce != 0 && P != null)// update
                {
                    baza.Entry(P).CurrentValues.SetValues(post);
                }
                else
                {
                    baza.Postignuca.Add(post);
                }
                baza.SaveChanges();
                if (Request.IsAjaxRequest())
                {
                    return new HttpStatusCodeResult(HttpStatusCode.OK);
                }

                return RedirectToAction("Tables_Ucenici_Lista");
            }

            else
                return RedirectToAction("UrediPostignuce", post.id_postignuce);
        }

        public ActionResult ObrisiPostignuce(long id)
        {
            Ucenik_obrazovna_postignuca post = baza.Postignuca.Find(id);
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("ObrisiPostignuce", post);
            }
            else

                return View("ObrisiPostignuce", post);
        }

        [HttpPost, ActionName("ObrisiPostignuce")]
        [ValidateAntiForgeryToken]
        public ActionResult ObrisiPostignuce1(long id)
        {
            Ucenik_obrazovna_postignuca P = baza.Postignuca.Where(
              x => x.id_postignuce == id).SingleOrDefault();

            if (P != null)
            {
                baza.Postignuca.Remove(P);
                baza.SaveChanges();
            }
            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return RedirectToAction("Tables_Ucenici_Lista");
        }


        [HttpGet]
        public ActionResult InfoPostignuce(int id)
        {
            Ucenik_obrazovna_postignuca post = baza.Postignuca.Find(id);


            return View(post);


        }


        public FileStreamResult Ispis(long id)
        {
            ModelLP ucenik = new ModelLP();



            ucenik.Init(id, baza);

            Skola sk = baza.skole.Find(ucenik.Razrednik.id_skola);


            ListaReport report = new ListaReport(ucenik, sk);

            return new FileStreamResult(new MemoryStream(report.Podaci), "application/pdf");
        }

    }
    }