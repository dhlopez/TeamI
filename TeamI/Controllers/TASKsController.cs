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
    public class TASKsController : Controller
    {
        private NCSafteyInspectionEntities db = new NCSafteyInspectionEntities();
        /*
        public string FullName {
            get {
                var fullName = db.TASK.Include(u => u.USER.firstName + u.USER.lastName);
                return fullName.ToString();
            }
        }
        */

        // GET: TASKs
        public ActionResult Index()
        {
            var tASK = db.TASK.Include(u => u.USER);
            //ViewBag.fullName = FullName;
            return View(tASK.ToList());
        }

        // GET: TASKs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TASK tASK = db.TASK.Find(id);
            if (tASK == null)
            {
                return HttpNotFound();
            }
            return View(tASK);
        }

        // GET: TASKs/Create
        public ActionResult Create()
        {
            ViewBag.userID = new SelectList(db.USER, "ID", "firstName");
            ViewBag.labID = new SelectList(db.LAB, "ID", "room");
            return View();
        }
        public static void SendSimpleMessage()
        {
            RestClient client = new RestClient();
            client.BaseUrl = new System.Uri("https://api.mailgun.net/v3");
            client.Authenticator =
            new HttpBasicAuthenticator("api",
                                      "key-88bcfda0bac089d6f861e5fa3f7d8a32");
            RestRequest request = new RestRequest();
            request.AddParameter("domain", "sandboxe5dae96553a54504b07b52d2804e9212.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            //request.AddParameter("from", "Mailgun Sandbox <postmaster@sandboxe5dae96553a54504b07b52d2804e9212.mailgun.org>");
            request.AddParameter("from", "NCSafetySystem <postmaster@sandboxe5dae96553a54504b07b52d2804e9212.mailgun.org>");
            request.AddParameter("to", "David <dhelaman@hotmail.com>");
            request.AddParameter("subject", "Hello Dave");
            request.AddParameter("text", "Congratulations, you just sent an email with Mailgun!");
            request.Method = Method.POST;
            client.Execute(request);
        }
        // POST: TASKs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,description,date,status")] TASK tASK)
        {
            if (ModelState.IsValid)
            {
                db.TASK.Add(tASK);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.userID = new SelectList(db.USER, "ID", "firstName", tASK.ID);
            ViewBag.labID = new SelectList(db.LAB, "ID", "building" + " - " +"room");
            return View(tASK);
        }

        // GET: TASKs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TASK tASK = db.TASK.Find(id);
            if (tASK == null)
            {
                return HttpNotFound();
            }
            ViewBag.userID = new SelectList(db.USER, "ID", "firstName", tASK.ID);
            return View(tASK);
        }

        // POST: TASKs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,description,date,status")] TASK tASK)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tASK).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.userID = new SelectList(db.USER, "ID", "firstName", tASK.ID);
            return View(tASK);
        }

        // GET: TASKs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TASK tASK = db.TASK.Find(id);
            if (tASK == null)
            {
                return HttpNotFound();
            }
            return View(tASK);
        }

        // POST: TASKs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TASK tASK = db.TASK.Find(id);
            db.TASK.Remove(tASK);
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
