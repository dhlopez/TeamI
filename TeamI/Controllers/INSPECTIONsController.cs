using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TeamI.Models;
using TeamI.ViewModel;

namespace TeamI.Controllers
{
    public class INSPECTIONsController : Controller
    {

        private NCSafteyInspectionEntities db = new NCSafteyInspectionEntities();

        // POST: /INSPECTIONs/LoadIns
        //public JsonResult LoadIns()
        //{
        //    var transactions = from i in db.INSPECTION
        //                       where i.ID != 0
        //                       select i;
        //    return Json(transactions, JsonRequestBehavior.AllowGet);
        //}
        public JsonResult LoadIns()
        {
            var inspections = from i in db.INSPECTION
                              .Include(i => i.LAB)
                              .Include(i => i.USER).ToList()
                              select new InsDTO()
                        {
                            Id = i.ID,
                            date = i.date.GetValueOrDefault().ToString("dd.MM.yyyy"),
                            labDesc = i.LAB.room,
                            username = i.USER.firstName + " " + i.USER.lastName
                        };

            return Json(inspections, JsonRequestBehavior.AllowGet);
        }

        
        public JsonResult LoadInsDet(int id)
        {
            var ins = from t in db.INSPECTIONDETAILS.Where(t=>t.InspectionID==id).ToList()
                      //where t.InspectionID == id 
                      select new InsDetDTO()
                      {
                          Id = t.ID,
                          AreaEquip = t.AreaEquipment,
                          Inspectionid = t.InspectionID
                      };
            return Json(ins, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadLabs()
        {
            var labs = from l in db.LAB
                       select new { l.ID, l.room };
                       //.ToList();

            return Json(labs.ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult LoadUsers()
        {
            var users = from l in db.USER
                        select new { l.ID, l.firstName, l.lastName };
            return Json(users.ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult LoadHazards()
        {
            var hazards = from h in db.HAZARD
                       select new { h.ID, h.Description };
            //.ToList();

            return Json(hazards.ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult HazObs(int id)
        {
            var haz = from t in db.HAZARDOBSERVED.Where(t => t.InspectionDetailID == id).Include(i => i.HAZARD).ToList()
                          //where t.InspectionID == id 
                      select new HazObsDTO()
                      {
                          HazardDesc = t.HAZARD.Description,
                          Comm = t.Comments
                          //we need to change this status from bool to string
                          //Stats = t.Status
                      };
            return Json(haz, JsonRequestBehavior.AllowGet);
        }


        // GET: INSPECTIONs
        public ActionResult Index(string sortOrder)
        {
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";


            var viewmodel = new InspectionIndexViewModel();
            var INSPECTION = db.INSPECTION.Include(i => i.LAB).Include(i => i.USER);
            var HAZARDSOBSERVED = db.HAZARDOBSERVED;
            var HAZARD = db.HAZARD;

            switch (sortOrder)
            {
                case "date_desc":
                    INSPECTION = INSPECTION.OrderByDescending(i => i.date);
                    break;
                case "Date":
                    INSPECTION = INSPECTION.OrderBy(i => i.date);
                    break;
            }

            viewmodel.hazardsobserved = HAZARDSOBSERVED.ToList();
            viewmodel.inspection = INSPECTION.ToList();
            viewmodel.hazard = HAZARD.ToList();

            return View(viewmodel);
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
        public ActionResult CreateInsDet() {
            //return Create();
            return View("~/Views/INSPECTIONs/CreateInsDet.cshtml");
        }
        // GET: INSPECTIONs/Create
        public ActionResult Create()
        {
            /*
            FullInspection fullIns = new FullInspection();
            fullIns.inspection = (from i in  db.INSPECTION select i).ToList();
            fullIns.inspectionDetails = (from ins in db.INSPECTIONDETAILS select ins).ToList();
            fullIns.HazardsObserved = (from haz in db.HAZARDOBSERVED select haz).ToList();
            */

            ViewBag.hazardID = new SelectList(db.HAZARD, "ID", "Description");
            //ViewBag.AreaEquipment = db.INSPECTIONDETAILS;
            ViewBag.labID = new SelectList(db.LAB, "ID", "room");
            ViewBag.userIDIns = new SelectList(db.USER, "ID", "FullName");
            ViewBag.InspectionID = new SelectList(db.INSPECTIONDETAILS, "ID", "AreaEquipment");
            //return View(fullIns);
            return View();
        }

        [HttpPost]
        public ActionResult CreatePost(INSPECTION inspec)
        {
            if (ModelState.IsValid)
            {
                db.INSPECTION.Add(inspec);
                db.SaveChanges();
                int id = inspec.ID;
                //return View(id);

                var ins = new InsDTO()
                {
                    Id = inspec.ID,
                    labDesc = db.LAB.Find(inspec.labID).room,
                    username = db.USER.Find(inspec.userID).firstName + " " + db.USER.Find(inspec.userID).lastName,
                    date = inspec.date.ToString()
                    //inspec.USER.firstName + inspec.USER.lastName
                };
                
                return Json(ins);
            }
            return View(inspec);
        }
        [HttpPost]
        public ActionResult CreateDetailPost(INSPECTIONDETAILS insDetail)
        {
            if (ModelState.IsValid)
            {
                db.INSPECTIONDETAILS.Add(insDetail);
                db.SaveChanges();
                //int id = inspec.ID;
                //return View(id);

                if (insDetail.InspectionID.HasValue)
                {
                    var insDet = new InsDetDTO()
                    {
                        Id = insDetail.ID,
                        Inspectionid = (int)insDetail.InspectionID,
                        AreaEquip = insDetail.AreaEquipment
                        //inspec.USER.firstName + inspec.USER.lastName
                    };
                    return Json(insDet);
                }
                else {
                    var insDet = new InsDetDTO()
                    {
                        Id = insDetail.ID,
                        /*Inspectionid = (int)insDetail.InspectionID,*/
                        AreaEquip = insDetail.AreaEquipment
                        //inspec.USER.firstName + inspec.USER.lastName
                    };
                    return Json(insDet);
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult CreateHazardObsPost(HAZARDOBSERVED hazObs)
        {
            if (ModelState.IsValid)
            {
                db.HAZARDOBSERVED.Add(hazObs);
                db.SaveChanges();
                //int id = inspec.ID;
                //return View(id);
                
                var hazObserved = new HazObsDTO()
                {
                    Id = hazObs.ID,
                    HazardDesc = db.HAZARD.Find(hazObs.HazardID).Description,
                    Comm = hazObs.Comments
                };
                return Json(hazObserved);

            }
            return View();
        }

        // POST: INSPECTIONs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID,date,labID,userID,status")] INSPECTION iNSPECTION)
        //public ActionResult Create([Bind(Include = "ID,date,labID,userID,status")] FullInspection model)
        public ActionResult Create(FormCollection form,  FullInspection model)
        {
            if (ModelState.IsValid)
            {
                /*
                foreach (var key in form.AllKeys) {
                    //key is the name of the field
                    //value is the actual value for that field
                    var details = form[5].Split(',');
                    var hazards = form[6].Split(',');
                    var statusHO = form[7].Split(',');
                    var comments = form[8].Split(',');
                }
                
                var inspection = new INSPECTION();
                var inspectionDetails = new INSPECTIONDETAILS();
                var hazardObserved = new HAZARDOBSERVED();

                inspection.date = model.dateIns;
                inspection.labID = model.labID;
                inspection.userID = model.userIDIns;
                inspection.status = model.status;

                //inspectionDetails.InspectionID = model.InspectionID;
                inspectionDetails.AreaEquipment = model.AreaEquipment;
                inspectionDetails.UserID = model.userIDIns;
                inspectionDetails.Date = model.dateIns;

                hazardObserved.InspectionDetailID = model.InspectionDetailID;
                hazardObserved.HazardID = model.HazardID;
                hazardObserved.Comments = model.Comments;
                hazardObserved.Status = model.statusHO;

                hazardObserved.INSPECTIONDETAILS = inspectionDetails;
                inspectionDetails.INSPECTION = inspection;
                

                //add all the required fields
                db.INSPECTION.Add(inspection);
                db.INSPECTIONDETAILS.Add(inspectionDetails);
                db.HAZARDOBSERVED.Add(hazardObserved);
                */
                db.SaveChanges();

                //db.INSPECTION.Add(iNSPECTION);
                //return RedirectToAction("Create");
            }

            ViewBag.labID = new SelectList(db.LAB, "ID", "building", model.labID);
            ViewBag.userID = new SelectList(db.USER, "ID", "firstName", model.userIDIns);
            ViewBag.hazardID = new SelectList(db.HAZARD, "ID", "Description");
            ViewBag.InspectionID = new SelectList(db.INSPECTIONDETAILS, "ID", "AreaEquipment");
            //return View(iNSPECTION);
            return View();
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
