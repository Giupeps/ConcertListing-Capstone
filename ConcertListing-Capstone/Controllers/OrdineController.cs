using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;
using ConcertListing_Capstone.Models;

namespace ConcertListing_Capstone.Controllers
{
    public class OrdineController : Controller
    {
        private ModelDBContext db = new ModelDBContext();

        // GET: Ordine
        public ActionResult Index()
        {
            var ordine = db.Ordine.Include(o => o.Concerto).Include(o => o.Posti).Include(o => o.Utenti);
            return View(ordine.ToList());
        }

        // GET: Ordine/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordine ordine = db.Ordine.Find(id);
            if (ordine == null)
            {
                return HttpNotFound();
            }
            return View(ordine);
        }

        // GET: Ordine/Create
       public JsonResult Compra(int iddata, string prezzodata, int postodata)
        {
            int idUtente = db.Utenti.Where(x => x.Username == User.Identity.Name).First().IdUtente;
            int idConcerto = Convert.ToInt32(TempData["IdConcerto"]);
            int IdLuogo = Convert.ToInt32(TempData["IdLuogo"]);
            Ordine ordine = new Ordine();
            Concerto concerto = new Concerto();
            Artista artista = new Artista();
            Luogo luogo = new Luogo();
            Posti posti = new Posti();
            ordine.Quantità = postodata;
            char[] charArray = { '\n', ' ', '€' };
            string prezzofinale = prezzodata.Trim(charArray);
            ordine.PrezzoTotale = Convert.ToDecimal(prezzofinale) * ordine.Quantità;
            ordine.IdPosto = iddata;
            ordine.IdConcerto = idConcerto;
            ordine.IdUtente = idUtente;

            posti.Zona = db.Posti.Find(iddata).Zona;
            ordine.Posti = posti;
            
            concerto.ImmagineCopertina = db.Concerto.Find(idConcerto).ImmagineCopertina;
            ordine.Concerto = concerto;

            luogo.Città = db.Luogo.Find(IdLuogo).Città;
            luogo.NomeStruttura = db.Luogo.Find(IdLuogo).NomeStruttura;
            ordine.Concerto.Luogo = luogo;
            
            artista.Nome = db.Concerto.Find(idConcerto).Artista.Nome;
            ordine.Concerto.Artista = artista;
            
            Ordine.ListaCarrello.Add(ordine);
            return Json("Prodotto aggiunto al carrello", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Conferma()
        {
            int count = 0;
            foreach (Ordine item in Ordine.ListaCarrello) { 

                
                Ordine ordine = new Ordine();
                ordine.Quantità = item.Quantità;
                ordine.PrezzoTotale = item.PrezzoTotale;
                ordine.IdConcerto = item.IdConcerto;
                ordine.IdPosto= item.IdPosto;
                ordine.IdUtente = item.IdUtente;
                
                db.Ordine.Add(ordine);
                db.SaveChanges();
                 count++;
        }
            TempData["count"] = count;
            Ordine.ListaCarrello.Clear();
            return RedirectToAction("VediOrdine");
        }

        public ActionResult VediOrdine()
        {
            int count = Convert.ToInt32(TempData["count"]);
            var ordine = db.Ordine.Where( x => x.Utenti.Username == User.Identity.Name).OrderByDescending(x => x.IdOrdine).Take(count).ToList();
            return View(ordine);
        }

        public ActionResult Carrello()
        {
          
            return View(Ordine.ListaCarrello);  
        }


        // GET: Ordine/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordine ordine = db.Ordine.Find(id);
            if (ordine == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdConcerto = new SelectList(db.Concerto, "IdConcerto", "ImmagineCopertina", ordine.IdConcerto);
            ViewBag.IdPosto = new SelectList(db.Posti, "IdPosti", "Zona", ordine.IdPosto);
            ViewBag.IdUtente = new SelectList(db.Utenti, "IdUtente", "Username", ordine.IdUtente);
            return View(ordine);
        }

        // POST: Ordine/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdOrdine,Quantità,PrezzoTotale,IdUtente,IdConcerto,IdPosto")] Ordine ordine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdConcerto = new SelectList(db.Concerto, "IdConcerto", "ImmagineCopertina", ordine.IdConcerto);
            ViewBag.IdPosto = new SelectList(db.Posti, "IdPosti", "Zona", ordine.IdPosto);
            ViewBag.IdUtente = new SelectList(db.Utenti, "IdUtente", "Username", ordine.IdUtente);
            return View(ordine);
        }

        // GET: Ordine/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordine ordine = db.Ordine.Find(id);
            if (ordine == null)
            {
                return HttpNotFound();
            }
            return View(ordine);
        }

        // POST: Ordine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ordine ordine = db.Ordine.Find(id);
            db.Ordine.Remove(ordine);
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
