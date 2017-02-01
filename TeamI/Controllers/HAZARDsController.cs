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
    public class HAZARDsController : Controller
    {
        private NCSafteyInspectionEntities db = new NCSafteyInspectionEntities();

        // GET: HAZARDs
        public ActionResult Index()
        {
            return View(db.HAZARD.ToList());
        }

        // GET: HAZARDs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HAZARD hAZARD = db.HAZARD.Find(id);
            if (hAZARD == null)
            {
                return HttpNotFound();
            }
            return View(hAZARD);
        }

        // GET: HAZARDs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HAZARDs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Description")] HAZARD hAZARD)
        {
            if (ModelState.IsValid)
            {
                db.HAZARD.Add(hAZARD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hAZARD);
        }

        // GET: HAZARDs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HAZARD hAZARD = db.HAZARD.Find(id);
            if (hAZARD == null)
            {
                return HttpNotFound();
            }
            return View(hAZARD);
        }

        // POST: HAZARDs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Description")] HAZARD hAZARD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hAZARD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hAZARD);
        }

        // GET: HAZARDs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HAZARD hAZARD = db.HAZARD.Find(id);
            if (hAZARD == null)
            {
                return HttpNotFound();
            }
            return View(hAZARD);
        }

        // POST: HAZARDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HAZARD hAZARD = db.HAZARD.Find(id);
            db.HAZARD.Remove(hAZARD);
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
