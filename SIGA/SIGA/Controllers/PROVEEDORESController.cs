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
    public class PROVEEDORESController : Controller
    {
        private SIGADBEntities db = new SIGADBEntities();

        // GET: PROVEEDORES
        public ActionResult Index()
        {
            return View(db.TBL_PROVEEDORES.ToList());
        }

        // GET: PROVEEDORES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_PROVEEDORES tBL_PROVEEDORES = db.TBL_PROVEEDORES.Find(id);
            if (tBL_PROVEEDORES == null)
            {
                return HttpNotFound();
            }
            return View(tBL_PROVEEDORES);
        }

        // GET: PROVEEDORES/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PROVEEDORES/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PROV_DESCRIP,PROV_NUM_IDENT,PROV_TEL1,PROV_TEL2")] TBL_PROVEEDORES tBL_PROVEEDORES)
        {
            if (ModelState.IsValid)
            {
                db.TBL_PROVEEDORES.Add(tBL_PROVEEDORES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBL_PROVEEDORES);
        }

        // GET: PROVEEDORES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_PROVEEDORES tBL_PROVEEDORES = db.TBL_PROVEEDORES.Find(id);
            if (tBL_PROVEEDORES == null)
            {
                return HttpNotFound();
            }
            return View(tBL_PROVEEDORES);
        }

        // POST: PROVEEDORES/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PROV_DESCRIP,PROV_NUM_IDENT,PROV_TEL1,PROV_TEL2")] TBL_PROVEEDORES tBL_PROVEEDORES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_PROVEEDORES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBL_PROVEEDORES);
        }

        // GET: PROVEEDORES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_PROVEEDORES tBL_PROVEEDORES = db.TBL_PROVEEDORES.Find(id);
            if (tBL_PROVEEDORES == null)
            {
                return HttpNotFound();
            }
            return View(tBL_PROVEEDORES);
        }

        // POST: PROVEEDORES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_PROVEEDORES tBL_PROVEEDORES = db.TBL_PROVEEDORES.Find(id);
            db.TBL_PROVEEDORES.Remove(tBL_PROVEEDORES);
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
