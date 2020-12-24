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
    public class MOVIMIENTOSController : Controller
    {
        private SIGADBEntities db = new SIGADBEntities();

        // GET: MOVIMIENTOS
        public ActionResult Index()
        {
            var tBL_MOVIMIENTOS = db.TBL_MOVIMIENTOS.Include(t => t.TBL_PRODUCTOS);
            return View(tBL_MOVIMIENTOS.ToList());
        }

        // GET: MOVIMIENTOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_MOVIMIENTOS tBL_MOVIMIENTOS = db.TBL_MOVIMIENTOS.Find(id);
            if (tBL_MOVIMIENTOS == null)
            {
                return HttpNotFound();
            }
            return View(tBL_MOVIMIENTOS);
        }

        // GET: MOVIMIENTOS/Create
        public ActionResult Create()
        {
            ViewBag.PROD_ID = new SelectList(db.TBL_PRODUCTOS, "ID", "PROD_DESCRIP");
            return View();
        }

        // POST: MOVIMIENTOS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PROD_ID,MOV_FEC_ENTRADA,MOV_USR_ENTRADA,MOV_FEC_SALIDA,MOV_USR_SALIDA")] TBL_MOVIMIENTOS tBL_MOVIMIENTOS)
        {
            if (ModelState.IsValid)
            {
                db.TBL_MOVIMIENTOS.Add(tBL_MOVIMIENTOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PROD_ID = new SelectList(db.TBL_PRODUCTOS, "ID", "PROD_DESCRIP", tBL_MOVIMIENTOS.PROD_ID);
            return View(tBL_MOVIMIENTOS);
        }

        // GET: MOVIMIENTOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_MOVIMIENTOS tBL_MOVIMIENTOS = db.TBL_MOVIMIENTOS.Find(id);
            if (tBL_MOVIMIENTOS == null)
            {
                return HttpNotFound();
            }
            ViewBag.PROD_ID = new SelectList(db.TBL_PRODUCTOS, "ID", "PROD_DESCRIP", tBL_MOVIMIENTOS.PROD_ID);
            return View(tBL_MOVIMIENTOS);
        }

        // POST: MOVIMIENTOS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PROD_ID,MOV_FEC_ENTRADA,MOV_USR_ENTRADA,MOV_FEC_SALIDA,MOV_USR_SALIDA")] TBL_MOVIMIENTOS tBL_MOVIMIENTOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_MOVIMIENTOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PROD_ID = new SelectList(db.TBL_PRODUCTOS, "ID", "PROD_DESCRIP", tBL_MOVIMIENTOS.PROD_ID);
            return View(tBL_MOVIMIENTOS);
        }

        // GET: MOVIMIENTOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_MOVIMIENTOS tBL_MOVIMIENTOS = db.TBL_MOVIMIENTOS.Find(id);
            if (tBL_MOVIMIENTOS == null)
            {
                return HttpNotFound();
            }
            return View(tBL_MOVIMIENTOS);
        }

        // POST: MOVIMIENTOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_MOVIMIENTOS tBL_MOVIMIENTOS = db.TBL_MOVIMIENTOS.Find(id);
            db.TBL_MOVIMIENTOS.Remove(tBL_MOVIMIENTOS);
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
