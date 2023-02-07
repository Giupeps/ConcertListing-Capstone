using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ConcertListing_Capstone.Models;

namespace ConcertListing_Capstone.Controllers
{
    public class PostiController : Controller
    {
        private ModelDBContext db = new ModelDBContext();

        // GET: Posti
        public ActionResult Index()
        {
            var posti = db.Posti.Include(p => p.Luogo);
            return View(posti.ToList());
        }

        // GET: Posti/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posti posti = db.Posti.Find(id);
            if (posti == null)
            {
                return HttpNotFound();
            }
            return View(posti);
        }

        // GET: Posti/Create
        public ActionResult Create()
        {
            ViewBag.IdLuogo = new SelectList(db.Luogo, "IdLuogo", "NomeStruttura");
            return View();
        }

        // POST: Posti/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPosti,Zona,PostiTotali,PostiVenduti,Prezzo,IdLuogo")] Posti posti)
        {
            if (ModelState.IsValid)
            {
                db.Posti.Add(posti);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdLuogo = new SelectList(db.Luogo, "IdLuogo", "NomeStruttura", posti.IdLuogo);
            return View(posti);
        }

        // GET: Posti/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posti posti = db.Posti.Find(id);
            if (posti == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdLuogo = new SelectList(db.Luogo, "IdLuogo", "NomeStruttura", posti.IdLuogo);
            return View(posti);
        }

        // POST: Posti/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPosti,Zona,PostiTotali,PostiVenduti,Prezzo,IdLuogo")] Posti posti)
        {
            if (ModelState.IsValid)
            {
                db.Entry(posti).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdLuogo = new SelectList(db.Luogo, "IdLuogo", "NomeStruttura", posti.IdLuogo);
            return View(posti);
        }

        // GET: Posti/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posti posti = db.Posti.Find(id);
            if (posti == null)
            {
                return HttpNotFound();
            }
            return View(posti);
        }

        // POST: Posti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Posti posti = db.Posti.Find(id);
            db.Posti.Remove(posti);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
