using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Controllers
{
    public class Sesija
    {
        public int PedagogId { get; set; }

        public static Sesija Trenutni
        {
            get
            {
                Sesija session = (Sesija)HttpContext.Current.Session["id_pedagog"];
                HttpContext.Current.Session.Timeout = 60;
                if (session == null)
                {
                    session = new Sesija();
                    HttpContext.Current.Session["id_pedagog"] = session;
                }
                return session;
            }
        }
    }
}