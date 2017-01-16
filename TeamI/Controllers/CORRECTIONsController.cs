using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TeamI.Models;

namespace TeamI.Controllers
{
    public class CORRECTIONsController : Controller
    {
        private NCSafteyInspectionEntities db = new NCSafteyInspectionEntities();

        // GET: CORRECTIONs
        public ActionResult Index()
        {
            var cORRECTION = db.CORRECTION.Include(c => c.EQUIPMENT).Include(c => c.EQUIPMENT1).Include(c => c.EQUIPMENT2).Include(c => c.EQUIPMENT3).Include(c => c.HAZARD).Include(c => c.HAZARD1).Include(c => c.HAZARD2).Include(c => c.HAZARD3);
            return View(cORRECTION.ToList());
        }

        // GET: CORRECTIONs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CORRECTION cORRECTION = db.CORRECTION.Find(id);
            if (cORRECTION == null)
            {
                return HttpNotFound();
            }
            return View(cORRECTION);
        }

        // GET: CORRECTIONs/Create
        public ActionResult Create()
        {
            ViewBag.equipmentID = new SelectList(db.EQUIPMENT, "id", "name");
            ViewBag.equipmentID = new SelectList(db.EQUIPMENT, "id", "name");
            ViewBag.equipmentID = new SelectList(db.EQUIPMENT, "id", "name");
            ViewBag.equipmentID = new SelectList(db.EQUIPMENT, "id", "name");
            ViewBag.hazardID = new SelectList(db.HAZARD, "ID", "name");
            ViewBag.hazardID = new SelectList(db.HAZARD, "ID", "name");
            ViewBag.hazardID = new SelectList(db.HAZARD, "ID", "name");
            ViewBag.hazardID = new SelectList(db.HAZARD, "ID", "name");
            return View();
        }

        // POST: CORRECTIONs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,equipmentID,hazardID,action")] CORRECTION cORRECTION)
        {
            if (ModelState.IsValid)
            {
                db.CORRECTION.Add(cORRECTION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.equipmentID = new SelectList(db.EQUIPMENT, "id", "name", cORRECTION.equipmentID);
            ViewBag.equipmentID = new SelectList(db.EQUIPMENT, "id", "name", cORRECTION.equipmentID);
            ViewBag.equipmentID = new SelectList(db.EQUIPMENT, "id", "name", cORRECTION.equipmentID);
            ViewBag.equipmentID = new SelectList(db.EQUIPMENT, "id", "name", cORRECTION.equipmentID);
            ViewBag.hazardID = new SelectList(db.HAZARD, "ID", "name", cORRECTION.hazardID);
            ViewBag.hazardID = new SelectList(db.HAZARD, "ID", "name", cORRECTION.hazardID);
            ViewBag.hazardID = new SelectList(db.HAZARD, "ID", "name", cORRECTION.hazardID);
            ViewBag.hazardID = new SelectList(db.HAZARD, "ID", "name", cORRECTION.hazardID);
            return View(cORRECTION);
        }

        // GET: CORRECTIONs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CORRECTION cORRECTION = db.CORRECTION.Find(id);
            if (cORRECTION == null)
            {
                return HttpNotFound();
            }
            ViewBag.equipmentID = new SelectList(db.EQUIPMENT, "id", "name", cORRECTION.equipmentID);
            ViewBag.equipmentID = new SelectList(db.EQUIPMENT, "id", "name", cORRECTION.equipmentID);
            ViewBag.equipmentID = new SelectList(db.EQUIPMENT, "id", "name", cORRECTION.equipmentID);
            ViewBag.equipmentID = new SelectList(db.EQUIPMENT, "id", "name", cORRECTION.equipmentID);
            ViewBag.hazardID = new SelectList(db.HAZARD, "ID", "name", cORRECTION.hazardID);
            ViewBag.hazardID = new SelectList(db.HAZARD, "ID", "name", cORRECTION.hazardID);
            ViewBag.hazardID = new SelectList(db.HAZARD, "ID", "name", cORRECTION.hazardID);
            ViewBag.hazardID = new SelectList(db.HAZARD, "ID", "name", cORRECTION.hazardID);
            return View(cORRECTION);
        }

        // POST: CORRECTIONs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,equipmentID,hazardID,action")] CORRECTION cORRECTION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cORRECTION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.equipmentID = new SelectList(db.EQUIPMENT, "id", "name", cORRECTION.equipmentID);
            ViewBag.equipmentID = new SelectList(db.EQUIPMENT, "id", "name", cORRECTION.equipmentID);
            ViewBag.equipmentID = new SelectList(db.EQUIPMENT, "id", "name", cORRECTION.equipmentID);
            ViewBag.equipmentID = new SelectList(db.EQUIPMENT, "id", "name", cORRECTION.equipmentID);
            ViewBag.hazardID = new SelectList(db.HAZARD, "ID", "name", cORRECTION.hazardID);
            ViewBag.hazardID = new SelectList(db.HAZARD, "ID", "name", cORRECTION.hazardID);
            ViewBag.hazardID = new SelectList(db.HAZARD, "ID", "name", cORRECTION.hazardID);
            ViewBag.hazardID = new SelectList(db.HAZARD, "ID", "name", cORRECTION.hazardID);
            return View(cORRECTION);
        }

        // GET: CORRECTIONs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CORRECTION cORRECTION = db.CORRECTION.Find(id);
            if (cORRECTION == null)
            {
                return HttpNotFound();
            }
            return View(cORRECTION);
        }

        // POST: CORRECTIONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CORRECTION cORRECTION = db.CORRECTION.Find(id);
            db.CORRECTION.Remove(cORRECTION);
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
