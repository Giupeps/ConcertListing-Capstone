using ConcertListing_Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConcertListing_Capstone.Controllers
{
    public class HomeController : Controller
    {
        private ModelDBContext db = new ModelDBContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PWListaConcerti()
        {
            var concerto = db.Concerto.ToList();
            return PartialView("_PWListaConcerti", concerto);
        }

    }
}