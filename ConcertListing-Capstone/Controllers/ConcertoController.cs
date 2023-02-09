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
    public class ConcertoController : Controller
    {
        private ModelDBContext db = new ModelDBContext();

        // GET: Concerto
        public ActionResult Index()
        {
            var concerto = db.Concerto.Include(c => c.Artista).Include(c => c.Luogo);
            return View(concerto.ToList());
        }

        // GET: Concerto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Concerto concerto = db.Concerto.Find(id);
            if (concerto == null)
            {
                return HttpNotFound();
            }
            return View(concerto);
        }

        // GET: Concerto/Create
        public ActionResult Create()
        {
            ViewBag.IdArtistaBand = new SelectList(db.Artista, "IdArtista", "Nome");
            ViewBag.IdLuogo = new SelectList(db.Luogo, "IdLuogo", "NomeStruttura");
            return View();
        }

        // POST: Concerto/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdConcerto,Data,ImmagineCopertina,Durata,IdLuogo,IdArtistaBand")] Concerto concerto, HttpPostedFileBase FotoConcerto)
        {
            ModelState.Remove("ImmagineCopertina");
            if (ModelState.IsValid && FotoConcerto != null)
            {
                concerto.ImmagineCopertina = FotoConcerto.FileName;
                FotoConcerto.SaveAs(Server.MapPath("/Content/ConcertoImg/" + concerto.ImmagineCopertina));
                db.Concerto.Add(concerto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdArtistaBand = new SelectList(db.Artista, "IdArtista", "Nome", concerto.IdArtistaBand);
            ViewBag.IdLuogo = new SelectList(db.Luogo, "IdLuogo", "NomeStruttura", concerto.IdLuogo);
            return View(concerto);
        }

        // GET: Concerto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Concerto concerto = db.Concerto.Find(id);
            if (concerto == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdArtistaBand = new SelectList(db.Artista, "IdArtista", "Nome", concerto.IdArtistaBand);
            ViewBag.IdLuogo = new SelectList(db.Luogo, "IdLuogo", "NomeStruttura", concerto.IdLuogo); 
            return View(concerto);
        }

        // POST: Concerto/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdConcerto,Data,ImmagineCopertina,Durata,IdLuogo,IdArtistaBand")] Concerto concerto, HttpPostedFileBase FotoConcerto)
        {
            Concerto ConcertoDB = db.Concerto.Find(concerto.IdConcerto);
            concerto.Data = ConcertoDB.Data;
            ModelState.Remove("ImmagineCopertina");
            ModelState.Remove("Data");
            if (ModelState.IsValid)
            {
                ConcertoDB.Data = concerto.Data;
                ConcertoDB.Durata = concerto.Durata;
                ConcertoDB.IdArtistaBand = concerto.IdArtistaBand;
                ConcertoDB.IdLuogo = concerto.IdLuogo;

                if (FotoConcerto != null)
                {
                    ConcertoDB.ImmagineCopertina = FotoConcerto.FileName;
                    FotoConcerto.SaveAs(Server.MapPath("/Content/ConcertoImg/" + ConcertoDB.ImmagineCopertina));
                }
            }
            ViewBag.IdArtistaBand = new SelectList(db.Artista, "IdArtista", "Nome", concerto.IdArtistaBand);
            ViewBag.IdLuogo = new SelectList(db.Luogo, "IdLuogo", "NomeStruttura", concerto.IdLuogo);
            
                db.Entry(ConcertoDB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
        }

        // GET: Concerto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Concerto concerto = db.Concerto.Find(id);
            if (concerto == null)
            {
                return HttpNotFound();
            }
            return View(concerto);
        }

        // POST: Concerto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Concerto concerto = db.Concerto.Find(id);
            db.Concerto.Remove(concerto);
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
