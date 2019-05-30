using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BDContext;

namespace Crucero.Areas.Administracion.Controllers
{
    public class PlatosController : Controller
    {
        private cruceroEntities db = new cruceroEntities();

        // GET: Administracion/Platos
        public ActionResult Index()
        {
            var plato = db.plato.Include(p => p.categoria1).Include(p => p.menu1);
            return View(plato.ToList());
        }

        // GET: Administracion/Platos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            plato plato = db.plato.Find(id);
            if (plato == null)
            {
                return HttpNotFound();
            }
            return View(plato);
        }

        // GET: Administracion/Platos/Create
        public ActionResult Create()
        {
            ViewBag.categoria = new SelectList(db.categoria, "id", "nombre");
            ViewBag.menu = new SelectList(db.menu, "id", "nombre");
            return View();
        }

        // POST: Administracion/Platos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,descripcion,menu,categoria")] plato plato)
        {
            if (ModelState.IsValid)
            {
                db.plato.Add(plato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categoria = new SelectList(db.categoria, "id", "nombre", plato.categoria);
            ViewBag.menu = new SelectList(db.menu, "id", "nombre", plato.menu);
            return View(plato);
        }

        // GET: Administracion/Platos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            plato plato = db.plato.Find(id);
            if (plato == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoria = new SelectList(db.categoria, "id", "nombre", plato.categoria);
            ViewBag.menu = new SelectList(db.menu, "id", "nombre", plato.menu);
            return View(plato);
        }

        // POST: Administracion/Platos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,descripcion,menu,categoria")] plato plato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoria = new SelectList(db.categoria, "id", "nombre", plato.categoria);
            ViewBag.menu = new SelectList(db.menu, "id", "nombre", plato.menu);
            return View(plato);
        }

        // GET: Administracion/Platos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            plato plato = db.plato.Find(id);
            if (plato == null)
            {
                return HttpNotFound();
            }
            return View(plato);
        }

        // POST: Administracion/Platos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            plato plato = db.plato.Find(id);
            db.plato.Remove(plato);
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
