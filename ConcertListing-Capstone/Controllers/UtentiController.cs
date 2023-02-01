using ConcertListing_Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ConcertListing_Capstone.Controllers
{
    public class UtentiController : Controller
    {
        ModelDBContext db = new ModelDBContext();
        // GET: Utenti
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Utenti u) 
        {
            string username = u.Username;
            string password = u.Password;

            var user = db.Utenti.Where(x => x.Username == username && x.Password == password).FirstOrDefault();
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(u.Username, false);
                return Redirect(FormsAuthentication.DefaultUrl);
            }
            else
            {
                ViewBag.Errore = "Username e/o Password errati";
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect(FormsAuthentication.LoginUrl);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Exclude = "Ruolo")] Utenti u) 
        {
            ModelState.Remove("Ruolo");
            if(ModelState.IsValid)
            {
                u.Ruolo = "User";
                db.Utenti.Add(u);
                db.SaveChanges();
                TempData["RegistrazioneOk"] = "Registrazione Completata con successo";
                
                return RedirectToAction("Login");
            }

            return RedirectToAction("Login");
        }
    }
}