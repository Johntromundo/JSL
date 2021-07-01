using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JSLProject.Models;

namespace JSLProject.Controllers
{
    public class ViagemsController : Controller
    {
        private BDJSLEntities db = new BDJSLEntities();

        // GET: Viagems
        public ActionResult Index()
        {
            var viagem = db.Viagem.Include(v => v.Motorista).Include(v => v.Endereco).Include(v => v.Endereco1);
            return View(viagem.ToList());
        }

        // GET: Viagems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viagem viagem = db.Viagem.Find(id);
            if (viagem == null)
            {
                return HttpNotFound();
            }
            return View(viagem);
        }

        // GET: Viagems/Create
        public ActionResult Create()
        {
            ViewBag.id_motorista = new SelectList(db.Motorista, "id_motorista", "Nome");
            ViewBag.localEntrega = new SelectList(db.Endereco, "id_end", "logradouro");
            ViewBag.localSaida = new SelectList(db.Endereco, "id_end", "logradouro");
            return View();
        }

        // POST: Viagems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_viagem,dataHora,localEntrega,localSaida,distancia,pesoCarga,id_motorista")] Viagem viagem)
        {
            if (ModelState.IsValid)
            {
                db.Viagem.Add(viagem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_motorista = new SelectList(db.Motorista, "id_motorista", "Nome", viagem.id_motorista);
            ViewBag.localEntrega = new SelectList(db.Endereco, "id_end", "logradouro", viagem.localEntrega);
            ViewBag.localSaida = new SelectList(db.Endereco, "id_end", "logradouro", viagem.localSaida);
            return View(viagem);
        }

        // GET: Viagems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viagem viagem = db.Viagem.Find(id);
            if (viagem == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_motorista = new SelectList(db.Motorista, "id_motorista", "Nome", viagem.id_motorista);
            ViewBag.localEntrega = new SelectList(db.Endereco, "id_end", "logradouro", viagem.localEntrega);
            ViewBag.localSaida = new SelectList(db.Endereco, "id_end", "logradouro", viagem.localSaida);
            return View(viagem);
        }

        // POST: Viagems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_viagem,dataHora,localEntrega,localSaida,distancia,pesoCarga,id_motorista")] Viagem viagem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viagem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_motorista = new SelectList(db.Motorista, "id_motorista", "Nome", viagem.id_motorista);
            ViewBag.localEntrega = new SelectList(db.Endereco, "id_end", "logradouro", viagem.localEntrega);
            ViewBag.localSaida = new SelectList(db.Endereco, "id_end", "logradouro", viagem.localSaida);
            return View(viagem);
        }

        // GET: Viagems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viagem viagem = db.Viagem.Find(id);
            if (viagem == null)
            {
                return HttpNotFound();
            }
            return View(viagem);
        }

        // POST: Viagems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Viagem viagem = db.Viagem.Find(id);
            db.Viagem.Remove(viagem);
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
