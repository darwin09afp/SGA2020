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
    public class TIPOSController : Controller
    {
        private SIGADBEntities db = new SIGADBEntities();

        // GET: TIPOS
        public ActionResult Index()
        {
            return View(db.TBL_TIPOS.ToList());
        }

        // GET: TIPOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_TIPOS tBL_TIPOS = db.TBL_TIPOS.Find(id);
            if (tBL_TIPOS == null)
            {
                return HttpNotFound();
            }
            return View(tBL_TIPOS);
        }

        // GET: TIPOS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TIPOS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TIPO_DESCRIP")] TBL_TIPOS tBL_TIPOS)
        {
            if (ModelState.IsValid)
            {
                db.TBL_TIPOS.Add(tBL_TIPOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBL_TIPOS);
        }

        // GET: TIPOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_TIPOS tBL_TIPOS = db.TBL_TIPOS.Find(id);
            if (tBL_TIPOS == null)
            {
                return HttpNotFound();
            }
            return View(tBL_TIPOS);
        }

        // POST: TIPOS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TIPO_DESCRIP")] TBL_TIPOS tBL_TIPOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_TIPOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBL_TIPOS);
        }

        // GET: TIPOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_TIPOS tBL_TIPOS = db.TBL_TIPOS.Find(id);
            if (tBL_TIPOS == null)
            {
                return HttpNotFound();
            }
            return View(tBL_TIPOS);
        }

        // POST: TIPOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_TIPOS tBL_TIPOS = db.TBL_TIPOS.Find(id);
            db.TBL_TIPOS.Remove(tBL_TIPOS);
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
