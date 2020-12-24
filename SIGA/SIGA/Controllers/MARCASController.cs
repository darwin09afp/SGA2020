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
    public class MARCASController : Controller
    {
        private SIGADBEntities db = new SIGADBEntities();

        // GET: MARCAS
        public ActionResult Index()
        {
            return View(db.TBL_MARCAS.ToList());
        }

        // GET: MARCAS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_MARCAS tBL_MARCAS = db.TBL_MARCAS.Find(id);
            if (tBL_MARCAS == null)
            {
                return HttpNotFound();
            }
            return View(tBL_MARCAS);
        }

        // GET: MARCAS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MARCAS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MARCA_DESCRIP")] TBL_MARCAS tBL_MARCAS)
        {
            if (ModelState.IsValid)
            {
                db.TBL_MARCAS.Add(tBL_MARCAS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBL_MARCAS);
        }

        // GET: MARCAS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_MARCAS tBL_MARCAS = db.TBL_MARCAS.Find(id);
            if (tBL_MARCAS == null)
            {
                return HttpNotFound();
            }
            return View(tBL_MARCAS);
        }

        // POST: MARCAS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MARCA_DESCRIP")] TBL_MARCAS tBL_MARCAS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_MARCAS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBL_MARCAS);
        }

        // GET: MARCAS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_MARCAS tBL_MARCAS = db.TBL_MARCAS.Find(id);
            if (tBL_MARCAS == null)
            {
                return HttpNotFound();
            }
            return View(tBL_MARCAS);
        }

        // POST: MARCAS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_MARCAS tBL_MARCAS = db.TBL_MARCAS.Find(id);
            db.TBL_MARCAS.Remove(tBL_MARCAS);
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
