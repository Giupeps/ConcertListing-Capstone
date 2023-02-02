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
    public class LuogoController : Controller
    {
        private ModelDBContext db = new ModelDBContext();

        // GET: Luogo
        public ActionResult ListaLuoghi()
        {
            return View(db.Luogo.ToList());
        }

        // GET: Luogo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Luogo luogo = db.Luogo.Find(id);
            if (luogo == null)
            {
                return HttpNotFound();
            }
            return View(luogo);
        }

        // GET: Luogo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Luogo/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdLuogo,NomeStruttura,Città,Indirizzo")] Luogo luogo)
        {
            if (ModelState.IsValid)
            {
                db.Luogo.Add(luogo);
                db.SaveChanges();
                return RedirectToAction("ListaLuoghi");
            }

            return View(luogo);
        }

        // GET: Luogo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Luogo luogo = db.Luogo.Find(id);
            if (luogo == null)
            {
                return HttpNotFound();
            }
            return View(luogo);
        }

        // POST: Luogo/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdLuogo,NomeStruttura,Città,Indirizzo")] Luogo luogo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(luogo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListaLuoghi");
            }
            return View(luogo);
        }

        // GET: Luogo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Luogo luogo = db.Luogo.Find(id);
            if (luogo == null)
            {
                return HttpNotFound();
            }
            return View(luogo);
        }

        // POST: Luogo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Luogo luogo = db.Luogo.Find(id);
            db.Luogo.Remove(luogo);
            db.SaveChanges();
            return RedirectToAction("ListaLuoghi");
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
