using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConcertListing_Capstone.Controllers
{
    public class AmministrazioneController : Controller
    {
        // GET: Amministrazione
        public ActionResult PannelloAmministrazione()
        {
            return View();
        }
    }
}