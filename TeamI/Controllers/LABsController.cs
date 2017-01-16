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
    public class LABsController : Controller
    {
        private NCSafteyInspectionEntities db = new NCSafteyInspectionEntities();

        // GET: LABs
        public ActionResult Index()
        {
            return View(db.LAB.ToList());
        }

        // GET: LABs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LAB lAB = db.LAB.Find(id);
            if (lAB == null)
            {
                return HttpNotFound();
            }
            return View(lAB);
        }

        // GET: LABs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LABs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,building,room,type")] LAB lAB)
        {
            if (ModelState.IsValid)
            {
                db.LAB.Add(lAB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lAB);
        }

        // GET: LABs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LAB lAB = db.LAB.Find(id);
            if (lAB == null)
            {
                return HttpNotFound();
            }
            return View(lAB);
        }

        // POST: LABs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,building,room,type")] LAB lAB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lAB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lAB);
        }

        // GET: LABs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LAB lAB = db.LAB.Find(id);
            if (lAB == null)
            {
                return HttpNotFound();
            }
            return View(lAB);
        }

        // POST: LABs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LAB lAB = db.LAB.Find(id);
            db.LAB.Remove(lAB);
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
