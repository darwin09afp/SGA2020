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
    public class PRODUCTOSController : Controller
    {
        private SIGADBEntities db = new SIGADBEntities();

        // GET: PRODUCTOS
        public ActionResult Index()
        {
            var tBL_PRODUCTOS = db.TBL_PRODUCTOS.Include(t => t.TBL_PROVEEDORES).Include(t => t.TBL_TIPOS).Include(t => t.TBL_UBICACIONES);
            return View(tBL_PRODUCTOS.ToList());
        }

        // GET: PRODUCTOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_PRODUCTOS tBL_PRODUCTOS = db.TBL_PRODUCTOS.Find(id);
            if (tBL_PRODUCTOS == null)
            {
                return HttpNotFound();
            }
            return View(tBL_PRODUCTOS);
        }

        // GET: PRODUCTOS/Create
        public ActionResult Create()
        {
            ViewBag.PROV_ID = new SelectList(db.TBL_PROVEEDORES, "ID", "PROV_DESCRIP");
            ViewBag.TIPO_ID = new SelectList(db.TBL_TIPOS, "ID", "TIPO_DESCRIP");
            ViewBag.UBIC_ID = new SelectList(db.TBL_UBICACIONES, "ID", "UBIC_PASILLO");
            return View();
        }

        // POST: PRODUCTOS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PROD_DESCRIP,TIPO_ID,PROD_MODELO,PROV_ID,UBIC_ID,PROD_PRECIO,PROD_COSTO,IMG")] TBL_PRODUCTOS tBL_PRODUCTOS)
        {
            if (ModelState.IsValid)
            {
                db.TBL_PRODUCTOS.Add(tBL_PRODUCTOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PROV_ID = new SelectList(db.TBL_PROVEEDORES, "ID", "PROV_DESCRIP", tBL_PRODUCTOS.PROV_ID);
            ViewBag.TIPO_ID = new SelectList(db.TBL_TIPOS, "ID", "TIPO_DESCRIP", tBL_PRODUCTOS.TIPO_ID);
            ViewBag.UBIC_ID = new SelectList(db.TBL_UBICACIONES, "ID", "UBIC_PASILLO", tBL_PRODUCTOS.UBIC_ID);
            return View(tBL_PRODUCTOS);
        }

        // GET: PRODUCTOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_PRODUCTOS tBL_PRODUCTOS = db.TBL_PRODUCTOS.Find(id);
            if (tBL_PRODUCTOS == null)
            {
                return HttpNotFound();
            }
            ViewBag.PROV_ID = new SelectList(db.TBL_PROVEEDORES, "ID", "PROV_DESCRIP", tBL_PRODUCTOS.PROV_ID);
            ViewBag.TIPO_ID = new SelectList(db.TBL_TIPOS, "ID", "TIPO_DESCRIP", tBL_PRODUCTOS.TIPO_ID);
            ViewBag.UBIC_ID = new SelectList(db.TBL_UBICACIONES, "ID", "UBIC_PASILLO", tBL_PRODUCTOS.UBIC_ID);
            return View(tBL_PRODUCTOS);
        }

        // POST: PRODUCTOS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PROD_DESCRIP,TIPO_ID,PROD_MODELO,PROV_ID,UBIC_ID,PROD_PRECIO,PROD_COSTO,IMG")] TBL_PRODUCTOS tBL_PRODUCTOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_PRODUCTOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PROV_ID = new SelectList(db.TBL_PROVEEDORES, "ID", "PROV_DESCRIP", tBL_PRODUCTOS.PROV_ID);
            ViewBag.TIPO_ID = new SelectList(db.TBL_TIPOS, "ID", "TIPO_DESCRIP", tBL_PRODUCTOS.TIPO_ID);
            ViewBag.UBIC_ID = new SelectList(db.TBL_UBICACIONES, "ID", "UBIC_PASILLO", tBL_PRODUCTOS.UBIC_ID);
            return View(tBL_PRODUCTOS);
        }

        // GET: PRODUCTOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_PRODUCTOS tBL_PRODUCTOS = db.TBL_PRODUCTOS.Find(id);
            if (tBL_PRODUCTOS == null)
            {
                return HttpNotFound();
            }
            return View(tBL_PRODUCTOS);
        }

        // POST: PRODUCTOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_PRODUCTOS tBL_PRODUCTOS = db.TBL_PRODUCTOS.Find(id);
            db.TBL_PRODUCTOS.Remove(tBL_PRODUCTOS);
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
