using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BDContext;

namespace Crucero.Areas.Restaurantes.Controllers
{
    public class PizzasController : Controller
    {
        private cruceroEntities db = new cruceroEntities();

        // GET: Restaurantes/Pizzas
        public ActionResult Index()
        {
            return View(db.restaurante.ToList());
        }

        // GET: Restaurantes/Pizzas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            restaurante restaurante = db.restaurante.Find(id);
            if (restaurante == null)
            {
                return HttpNotFound();
            }
            return View(restaurante);
        }

        // GET: Restaurantes/Pizzas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurantes/Pizzas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,horario,principal,capacidad")] restaurante restaurante)
        {
            if (ModelState.IsValid)
            {
                db.restaurante.Add(restaurante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurante);
        }

        // GET: Restaurantes/Pizzas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            restaurante restaurante = db.restaurante.Find(id);
            if (restaurante == null)
            {
                return HttpNotFound();
            }
            return View(restaurante);
        }

        // POST: Restaurantes/Pizzas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,horario,principal,capacidad")] restaurante restaurante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurante);
        }

        // GET: Restaurantes/Pizzas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            restaurante restaurante = db.restaurante.Find(id);
            if (restaurante == null)
            {
                return HttpNotFound();
            }
            return View(restaurante);
        }

        // POST: Restaurantes/Pizzas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            restaurante restaurante = db.restaurante.Find(id);
            db.restaurante.Remove(restaurante);
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
