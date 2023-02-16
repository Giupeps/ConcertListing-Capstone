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
    public class ArtistaController : Controller
    {
        private ModelDBContext db = new ModelDBContext();

        // GET: Artista
        public ActionResult ListaArtisti()
        {
            return View(db.Artista.ToList());
        }



        // GET: Artista/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artista artista = db.Artista.Find(id);
            if (artista == null)
            {
                return HttpNotFound();
            }
            return View(artista);
        }

        // GET: Artista/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Artista/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdArtista,Nome,Descrizione,Genere,Sottogenere")] Artista artista, HttpPostedFileBase FotoArtista)
        {
            if (ModelState.IsValid && FotoArtista != null)
            {
                artista.Foto = FotoArtista.FileName;
                FotoArtista.SaveAs(Server.MapPath("/Content/ArtistaImg/" + artista.Foto));
                db.Artista.Add(artista);
                db.SaveChanges();
                return RedirectToAction("ListaArtisti");
            }

            return View(artista);
        }

        // GET: Artista/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artista artista = db.Artista.Find(id);
            if (artista == null)
            {
                return HttpNotFound();
            }
            return View(artista);
        }

        // POST: Artista/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdArtista,Nome,Descrizione,Genere,Sottogenere,Foto")] Artista artista, HttpPostedFileBase FotoArtista)
        {
            Artista ArtistaDB = db.Artista.Find(artista.IdArtista);

            if (ModelState.IsValid)
            {
                ArtistaDB.Nome = artista.Nome;
                ArtistaDB.Descrizione = artista.Descrizione;
                ArtistaDB.Genere = artista.Genere;
                ArtistaDB.Sottogenere = artista.Sottogenere;
                if (FotoArtista != null)
                {
                    ArtistaDB.Foto = FotoArtista.FileName;
                    FotoArtista.SaveAs(Server.MapPath("/Content/ArtistaImg/" + ArtistaDB.Foto));
                }
            }
            db.Entry(ArtistaDB).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ListaArtisti");

        }

        // GET: Artista/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artista artista = db.Artista.Find(id);
            if (artista == null)
            {
                return HttpNotFound();
            }
            return View(artista);
        }

        // POST: Artista/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Artista artista = db.Artista.Find(id);
            db.Artista.Remove(artista);
            db.SaveChanges();
            return RedirectToAction("ListaArtisti");
        }


        public JsonResult ArtistBySearch(string search)
        {
            ArtistaJson aj = new ArtistaJson();

            Concerto a = db.Concerto.Where(x => x.Artista.Nome.Contains(search)).Include(x => x.Artista).FirstOrDefault();
            if (a != null)
            {

                aj.Nome = a.Artista.Nome;
                aj.IdArtista = a.Artista.IdArtista;
                aj.Foto = a.Artista.Foto;
                aj.IdConcerto = a.IdConcerto;
            }
            return Json(aj, JsonRequestBehavior.AllowGet);
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
