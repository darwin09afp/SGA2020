using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SIGA.Models;

namespace SIGA.Controllers
{
    public class UBICACIONESController : Controller
    {
        private SIGADBEntities db = new SIGADBEntities();

        // GET: UBICACIONES
        public ActionResult Index()
        {
            return View(db.TBL_UBICACIONES.ToList());
        }

        // GET: UBICACIONES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_UBICACIONES tBL_UBICACIONES = db.TBL_UBICACIONES.Find(id);
            if (tBL_UBICACIONES == null)
            {
                return HttpNotFound();
            }
            return View(tBL_UBICACIONES);
        }

        // GET: UBICACIONES/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UBICACIONES/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UBIC_PASILLO,UBIC_SECCION,UBIC_NIVEL")] TBL_UBICACIONES tBL_UBICACIONES)
        {
            if (ModelState.IsValid)
            {
                db.TBL_UBICACIONES.Add(tBL_UBICACIONES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBL_UBICACIONES);
        }

        // GET: UBICACIONES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_UBICACIONES tBL_UBICACIONES = db.TBL_UBICACIONES.Find(id);
            if (tBL_UBICACIONES == null)
            {
                return HttpNotFound();
            }
            return View(tBL_UBICACIONES);
        }

        // POST: UBICACIONES/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UBIC_PASILLO,UBIC_SECCION,UBIC_NIVEL")] TBL_UBICACIONES tBL_UBICACIONES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_UBICACIONES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBL_UBICACIONES);
        }

        // GET: UBICACIONES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_UBICACIONES tBL_UBICACIONES = db.TBL_UBICACIONES.Find(id);
            if (tBL_UBICACIONES == null)
            {
                return HttpNotFound();
            }
            return View(tBL_UBICACIONES);
        }

        // POST: UBICACIONES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_UBICACIONES tBL_UBICACIONES = db.TBL_UBICACIONES.Find(id);
            db.TBL_UBICACIONES.Remove(tBL_UBICACIONES);
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
