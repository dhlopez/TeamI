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
    public class EQUIPMENTsController : Controller
    {
        private NCSafteyInspectionEntities db = new NCSafteyInspectionEntities();

        // GET: EQUIPMENTs
        public ActionResult Index()
        {
            var eQUIPMENT = db.EQUIPMENT.Include(e => e.LAB);
            return View(eQUIPMENT.ToList());
        }

        // GET: EQUIPMENTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EQUIPMENT eQUIPMENT = db.EQUIPMENT.Find(id);
            if (eQUIPMENT == null)
            {
                return HttpNotFound();
            }
            return View(eQUIPMENT);
        }

        // GET: EQUIPMENTs/Create
        public ActionResult Create()
        {
            ViewBag.labID = new SelectList(db.LAB, "ID", "building");
            return View();
        }

        // POST: EQUIPMENTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,labID,name,type")] EQUIPMENT eQUIPMENT)
        {
            if (ModelState.IsValid)
            {
                db.EQUIPMENT.Add(eQUIPMENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.labID = new SelectList(db.LAB, "ID", "building", eQUIPMENT.labID);
            return View(eQUIPMENT);
        }

        // GET: EQUIPMENTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EQUIPMENT eQUIPMENT = db.EQUIPMENT.Find(id);
            if (eQUIPMENT == null)
            {
                return HttpNotFound();
            }
            ViewBag.labID = new SelectList(db.LAB, "ID", "building", eQUIPMENT.labID);
            return View(eQUIPMENT);
        }

        // POST: EQUIPMENTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,labID,name,type")] EQUIPMENT eQUIPMENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eQUIPMENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.labID = new SelectList(db.LAB, "ID", "building", eQUIPMENT.labID);
            return View(eQUIPMENT);
        }

        // GET: EQUIPMENTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EQUIPMENT eQUIPMENT = db.EQUIPMENT.Find(id);
            if (eQUIPMENT == null)
            {
                return HttpNotFound();
            }
            return View(eQUIPMENT);
        }

        // POST: EQUIPMENTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EQUIPMENT eQUIPMENT = db.EQUIPMENT.Find(id);
            db.EQUIPMENT.Remove(eQUIPMENT);
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
