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
    public class INSPECTIONDETAILSController : Controller
    {
        private NCSafteyInspectionEntities db = new NCSafteyInspectionEntities();

        // GET: INSPECTIONDETAILS
        public ActionResult Index()
        {
            var iNSPECTIONDETAILS = db.INSPECTIONDETAILS.Include(i => i.INSPECTION).Include(i => i.USER);
            return View(iNSPECTIONDETAILS.ToList());
        }

        // GET: INSPECTIONDETAILS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INSPECTIONDETAILS iNSPECTIONDETAILS = db.INSPECTIONDETAILS.Find(id);
            if (iNSPECTIONDETAILS == null)
            {
                return HttpNotFound();
            }
            return View(iNSPECTIONDETAILS);
        }

        // GET: INSPECTIONDETAILS/Create
        public ActionResult Create()
        {
            ViewBag.InspectionID = new SelectList(db.INSPECTION, "ID", "ID");
            ViewBag.UserID = new SelectList(db.USER, "ID", "firstName");
            return View();
        }

        // POST: INSPECTIONDETAILS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,InspectionID,UserID,Date,AreaEquipment")] INSPECTIONDETAILS iNSPECTIONDETAILS)
        {
            if (ModelState.IsValid)
            {
                db.INSPECTIONDETAILS.Add(iNSPECTIONDETAILS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InspectionID = new SelectList(db.INSPECTION, "ID", "ID", iNSPECTIONDETAILS.InspectionID);
            ViewBag.UserID = new SelectList(db.USER, "ID", "firstName", iNSPECTIONDETAILS.UserID);
            return View(iNSPECTIONDETAILS);
        }

        // GET: INSPECTIONDETAILS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INSPECTIONDETAILS iNSPECTIONDETAILS = db.INSPECTIONDETAILS.Find(id);
            if (iNSPECTIONDETAILS == null)
            {
                return HttpNotFound();
            }
            ViewBag.InspectionID = new SelectList(db.INSPECTION, "ID", "ID", iNSPECTIONDETAILS.InspectionID);
            ViewBag.UserID = new SelectList(db.USER, "ID", "firstName", iNSPECTIONDETAILS.UserID);
            return View(iNSPECTIONDETAILS);
        }

        // POST: INSPECTIONDETAILS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,InspectionID,UserID,Date,AreaEquipment")] INSPECTIONDETAILS iNSPECTIONDETAILS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iNSPECTIONDETAILS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InspectionID = new SelectList(db.INSPECTION, "ID", "ID", iNSPECTIONDETAILS.InspectionID);
            ViewBag.UserID = new SelectList(db.USER, "ID", "firstName", iNSPECTIONDETAILS.UserID);
            return View(iNSPECTIONDETAILS);
        }

        // GET: INSPECTIONDETAILS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INSPECTIONDETAILS iNSPECTIONDETAILS = db.INSPECTIONDETAILS.Find(id);
            if (iNSPECTIONDETAILS == null)
            {
                return HttpNotFound();
            }
            return View(iNSPECTIONDETAILS);
        }

        // POST: INSPECTIONDETAILS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            INSPECTIONDETAILS iNSPECTIONDETAILS = db.INSPECTIONDETAILS.Find(id);
            db.INSPECTIONDETAILS.Remove(iNSPECTIONDETAILS);
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
