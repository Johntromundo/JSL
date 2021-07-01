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
    public class MotoristasController : Controller
    {
        private BDJSLEntities db = new BDJSLEntities();

        // GET: Motoristas
        public ActionResult Index()
        {
            var motorista = db.Motorista.Include(m => m.Endereco);
            return View(motorista.ToList());
        }

        // GET: Motoristas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motorista motorista = db.Motorista.Find(id);
            if (motorista == null)
            {
                return HttpNotFound();
            }
            return View(motorista);
        }

        // GET: Motoristas/Create
        public ActionResult Create()
        {
            ViewBag.id_end = new SelectList(db.Endereco, "id_end", "logradouro");
            return View();
        }

        // POST: Motoristas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_motorista,Nome,Sobrenome,id_end")] Motorista motorista)
        {
            if (ModelState.IsValid)
            {
                db.Motorista.Add(motorista);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_end = new SelectList(db.Endereco, "id_end", "logradouro", motorista.id_end);
            return View(motorista);
        }

        // GET: Motoristas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motorista motorista = db.Motorista.Find(id);
            if (motorista == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_end = new SelectList(db.Endereco, "id_end", "logradouro", motorista.id_end);
            return View(motorista);
        }

        // POST: Motoristas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_motorista,Nome,Sobrenome,id_end")] Motorista motorista)
        {
            if (ModelState.IsValid)
            {
                db.Entry(motorista).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_end = new SelectList(db.Endereco, "id_end", "logradouro", motorista.id_end);
            return View(motorista);
        }

        // GET: Motoristas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motorista motorista = db.Motorista.Find(id);
            if (motorista == null)
            {
                return HttpNotFound();
            }
            return View(motorista);
        }

        // POST: Motoristas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Motorista motorista = db.Motorista.Find(id);
            db.Motorista.Remove(motorista);
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
