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
    public class HAZARDOBSERVEDsController : Controller
    {
        private NCSafteyInspectionEntities db = new NCSafteyInspectionEntities();

        // GET: HAZARDOBSERVEDs
        public ActionResult Index()
        {
            var hAZARDOBSERVED = db.HAZARDOBSERVED.Include(h => h.INSPECTIONDETAILS).Include(h => h.HAZARD);
            return View(hAZARDOBSERVED.ToList());
        }

        // GET: HAZARDOBSERVEDs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HAZARDOBSERVED hAZARDOBSERVED = db.HAZARDOBSERVED.Find(id);
            if (hAZARDOBSERVED == null)
            {
                return HttpNotFound();
            }
            return View(hAZARDOBSERVED);
        }

        // GET: HAZARDOBSERVEDs/Create
        public ActionResult Create()
        {
            ViewBag.InspectionDetailID = new SelectList(db.INSPECTIONDETAILS, "ID", "AreaEquipment");
            ViewBag.HazardID = new SelectList(db.HAZARD, "ID", "Description");
            return View();
        }

        // POST: HAZARDOBSERVEDs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Comments,Status,ID,InspectionDetailID,HazardID")] HAZARDOBSERVED hAZARDOBSERVED)
        {
            if (ModelState.IsValid)
            {
                db.HAZARDOBSERVED.Add(hAZARDOBSERVED);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InspectionDetailID = new SelectList(db.INSPECTIONDETAILS, "ID", "AreaEquipment", hAZARDOBSERVED.InspectionDetailID);
            ViewBag.HazardID = new SelectList(db.HAZARD, "ID", "Description", hAZARDOBSERVED.HazardID);
            return View(hAZARDOBSERVED);
        }

        // GET: HAZARDOBSERVEDs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HAZARDOBSERVED hAZARDOBSERVED = db.HAZARDOBSERVED.Find(id);
            if (hAZARDOBSERVED == null)
            {
                return HttpNotFound();
            }
            ViewBag.InspectionDetailID = new SelectList(db.INSPECTIONDETAILS, "ID", "AreaEquipment", hAZARDOBSERVED.InspectionDetailID);
            ViewBag.HazardID = new SelectList(db.HAZARD, "ID", "Description", hAZARDOBSERVED.HazardID);
            return View(hAZARDOBSERVED);
        }

        // POST: HAZARDOBSERVEDs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Comments,Status,ID,InspectionDetailID,HazardID")] HAZARDOBSERVED hAZARDOBSERVED)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hAZARDOBSERVED).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InspectionDetailID = new SelectList(db.INSPECTIONDETAILS, "ID", "AreaEquipment", hAZARDOBSERVED.InspectionDetailID);
            ViewBag.HazardID = new SelectList(db.HAZARD, "ID", "Description", hAZARDOBSERVED.HazardID);
            return View(hAZARDOBSERVED);
        }

        // GET: HAZARDOBSERVEDs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HAZARDOBSERVED hAZARDOBSERVED = db.HAZARDOBSERVED.Find(id);
            if (hAZARDOBSERVED == null)
            {
                return HttpNotFound();
            }
            return View(hAZARDOBSERVED);
        }

        // POST: HAZARDOBSERVEDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HAZARDOBSERVED hAZARDOBSERVED = db.HAZARDOBSERVED.Find(id);
            db.HAZARDOBSERVED.Remove(hAZARDOBSERVED);
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
