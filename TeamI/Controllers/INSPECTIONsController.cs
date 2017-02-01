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
    public class INSPECTIONsController : Controller
    {
        private NCSafteyInspectionEntities db = new NCSafteyInspectionEntities();

        // GET: INSPECTIONs
        public ActionResult Index()
        {
            var iNSPECTION = db.INSPECTION.Include(i => i.LAB).Include(i => i.USER);
            return View(iNSPECTION.ToList());
        }

        // GET: INSPECTIONs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INSPECTION iNSPECTION = db.INSPECTION.Find(id);
            if (iNSPECTION == null)
            {
                return HttpNotFound();
            }
            return View(iNSPECTION);
        }

        // GET: INSPECTIONs/Create
        public ActionResult Create()
        {
            ViewBag.labID = new SelectList(db.LAB, "ID", "building");
            ViewBag.userID = new SelectList(db.USER, "ID", "firstName");
            return View();
        }

        // POST: INSPECTIONs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,date,labID,userID,status")] INSPECTION iNSPECTION)
        {
            if (ModelState.IsValid)
            {
                db.INSPECTION.Add(iNSPECTION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.labID = new SelectList(db.LAB, "ID", "building", iNSPECTION.labID);
            ViewBag.userID = new SelectList(db.USER, "ID", "firstName", iNSPECTION.userID);
            return View(iNSPECTION);
        }

        // GET: INSPECTIONs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INSPECTION iNSPECTION = db.INSPECTION.Find(id);
            if (iNSPECTION == null)
            {
                return HttpNotFound();
            }
            ViewBag.labID = new SelectList(db.LAB, "ID", "building", iNSPECTION.labID);
            ViewBag.userID = new SelectList(db.USER, "ID", "firstName", iNSPECTION.userID);
            return View(iNSPECTION);
        }

        // POST: INSPECTIONs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,date,labID,userID,status")] INSPECTION iNSPECTION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iNSPECTION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.labID = new SelectList(db.LAB, "ID", "building", iNSPECTION.labID);
            ViewBag.userID = new SelectList(db.USER, "ID", "firstName", iNSPECTION.userID);
            return View(iNSPECTION);
        }

        // GET: INSPECTIONs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INSPECTION iNSPECTION = db.INSPECTION.Find(id);
            if (iNSPECTION == null)
            {
                return HttpNotFound();
            }
            return View(iNSPECTION);
        }

        // POST: INSPECTIONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            INSPECTION iNSPECTION = db.INSPECTION.Find(id);
            db.INSPECTION.Remove(iNSPECTION);
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
