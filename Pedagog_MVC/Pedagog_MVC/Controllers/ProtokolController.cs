using Pedagog_MVC.BazaPovezivanje;
using Pedagog_MVC.fonts;
using Pedagog_MVC.Models;
using ProjektIdio.Models;
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
    public class ProtokolController : Controller
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



        [HttpGet]
        public ActionResult Protokol_Promatranja_Uredi(long id)
        {
            if (Sesija.Trenutni.PedagogId > 0)
            {
            
            Ucenik_protokol_pracenja protokol = baza.Protokoli.Find(id);
            Razredni_odjel razred = baza.Razredi.Find(protokol.id_odjel);
            Ucenik_lista_pracenja lista = baza.Liste_Pracenja.Where(x => x.id_ucenik == protokol.id_ucenik).SingleOrDefault();
            ViewBag.ucenik = baza.Ucenici.Find(protokol.id_ucenik);
            ViewBag.razrednik = baza.Nastavnici.Find(razred.id_razrednik);
            ViewBag.razred = razred;
            ViewBag.skGod = lista.godina;

                return View(protokol);
            }
            else
                return RedirectToAction("Prijava","Pedagog");
        }


        [HttpPost]
        public ActionResult Protokol_Promatranja_Uredi(Ucenik_protokol_pracenja protokol)
        {

            if (ModelState.IsValid)
            {

                Ucenik_protokol_pracenja PR = baza.Protokoli.Where(
                  x => x.id_protokol == protokol.id_protokol).SingleOrDefault();

                if (protokol.id_protokol != 0 && PR != null)// update
                {
                    baza.Entry(PR).CurrentValues.SetValues(protokol);
                }
                else
                {
                    baza.Protokoli.Add(protokol);
                }
                baza.SaveChanges();
                if (Request.IsAjaxRequest())
                {
                    return new HttpStatusCodeResult(HttpStatusCode.OK);
                }

                return RedirectToAction("Protokol_Promatranja");
            }

            else
                return RedirectToAction("Protokol_Promatranja_Uredi", protokol.id_protokol);

        }

        public ActionResult Protokol_Promatranja()
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

            razredi.Add(new SelectListItem
            {

                Text = "3.B",
                Value = "3.B",


            });


            ViewBag.razredi = razredi;


            if (Sesija.Trenutni.PedagogId > 0)
            {
                return View(baza.Ucenici);
            }
            else
                return RedirectToAction("Prijava","Pedagog");
        }

        public ActionResult ProtokolPartial(long id)
        {
            List<Ucenik_protokol_pracenja> protokoli = new List<Ucenik_protokol_pracenja>();

            foreach(Ucenik_protokol_pracenja prot in baza.Protokoli)
            {
                if (prot.id_ucenik == id)
                {
                    protokoli.Add(prot);
                }
            }

            ViewBag.baza = baza;
            ViewBag.idUcenik = id;
            
            return View(protokoli);
        }



        public ActionResult ObrisiProtokol(long id)
        {
            Ucenik_protokol_pracenja ad = baza.Protokoli.Find(id);
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("ObrisiProtokol", ad);
            }
            else

                return View("ObrisiProtokol", ad);
        }

        [HttpPost, ActionName("ObrisiProtokol")]
        [ValidateAntiForgeryToken]
        public ActionResult ObrisiProtokol1(int id)
        {
            Ucenik_protokol_pracenja P = baza.Protokoli.Where(
              x => x.id_protokol == id).SingleOrDefault();

            if (P != null)
            {
                baza.Protokoli.Remove(P);
                baza.SaveChanges();
            }
            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return RedirectToAction("Protokol_Promatranja");
        }


        [HttpGet]
        public ActionResult InfoProtokol(int id)
        {
            Ucenik_protokol_pracenja ad = baza.Protokoli.Find(id);


            return View(ad);

        }

        public ActionResult DodajProtokol(long id)
        {

            ViewBag.id = id;
            ViewBag.idPracenje = baza.Liste_Pracenja.Where(x => x.id_ucenik == id).SingleOrDefault().id_pracenje;
            ViewBag.idPedagog = baza.Liste_Pracenja.Where(x => x.id_ucenik == id).SingleOrDefault().id_pedagog;
            ViewBag.idOdjel= baza.Liste_Pracenja.Where(x => x.id_ucenik == id).SingleOrDefault().id_odjel;
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("DodajProtokol");
            }
            else

                return View("DodajProtokol");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> DodajProtokol(Ucenik_protokol_pracenja pro)
        {

            if (ModelState.IsValid)
            {
                baza.Protokoli.Add(pro);
                baza.SaveChanges();
                return RedirectToAction("Protokol_Promatranja");
            }

            else
                return RedirectToAction("DodajProtokol");

        }


    }
}