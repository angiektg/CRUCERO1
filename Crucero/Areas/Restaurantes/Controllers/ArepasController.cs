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
    public class ArepasController : Controller
    {
        private cruceroEntities db = new cruceroEntities();

        // GET: Restaurantes/Arepas
        public ActionResult Index()
        {
            IEnumerable<menu> menu = db.menu.Where(x=> x.restaurante == 2).ToList();
            return View(menu);
        }

        public ActionResult IndexHorarios()
        {
            var Horario = db.restaurante.Where(x => x.nombre == "Arepa la concha del mar").ToList();
            return View(Horario);
        }

        //// GET: Restaurantes/Arepas/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    restaurante restaurante = db.restaurante.Find(id);
        //    if (restaurante == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(restaurante);
        //}

        // GET: Restaurantes/Arepas/Create
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Create_Menu()
        {
            ViewBag.jornada = new SelectList(db.jornada, "id", "nombre");
            return View();
        }
        // POST: Restaurantes/Arepas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(restaurante restaurant)
        {
            if (ModelState.IsValid)
            {

                restaurant.nombre = "Arepa la concha del mar";
                restaurant.principal = 0;
                db.restaurante.Add(restaurant);
                db.SaveChanges();
                return RedirectToAction("IndexHorarios");
            }

            return View(restaurant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create_Menu(menu menus)
        {
            ViewBag.jornada = new SelectList(db.jornada, "id", "nombre", menus.jornada);
            if (ModelState.IsValid)
            {
                menus.restaurante = 2;
                menus.tipo = "General";
                db.menu.Add(menus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(menus);
        }
        // GET: Restaurantes/Arepas/Edit/5
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

        // POST: Restaurantes/Arepas/Edit/5
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

        // GET: Restaurantes/Arepas/Delete/5
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

        // POST: Restaurantes/Arepas/Delete/5
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
