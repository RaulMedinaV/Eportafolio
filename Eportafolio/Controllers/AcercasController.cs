using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Eportafolio.Models;

namespace Eportafolio.Controllers
{
    public class AcercasController : Controller
    {
        private rmedinaEntities db = new rmedinaEntities();

        // GET: Acercas
        public ActionResult Index()
        {
            return View(db.Acerca.ToList());
        }

        // GET: Acercas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acerca acerca = db.Acerca.Find(id);
            if (acerca == null)
            {
                return HttpNotFound();
            }
            return View(acerca);
        }

        // GET: Acercas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Acercas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Acerca1")] Acerca acerca)
        {
            if (ModelState.IsValid)
            {
                db.Acerca.Add(acerca);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(acerca);
        }

        // GET: Acercas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acerca acerca = db.Acerca.Find(id);
            if (acerca == null)
            {
                return HttpNotFound();
            }
            return View(acerca);
        }

        // POST: Acercas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Acerca1")] Acerca acerca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(acerca).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(acerca);
        }

        // GET: Acercas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acerca acerca = db.Acerca.Find(id);
            if (acerca == null)
            {
                return HttpNotFound();
            }
            return View(acerca);
        }

        // POST: Acercas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Acerca acerca = db.Acerca.Find(id);
            db.Acerca.Remove(acerca);
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
