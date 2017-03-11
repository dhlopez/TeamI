using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TeamI.Models;
using TeamI.ViewModel;

namespace TeamI.Controllers
{
    public class SearchController : Controller
    {
        private NCSafteyInspectionEntities db = new NCSafteyInspectionEntities();

        // GET: Search
        public ActionResult Index(string labSearch, string techSearch, string status, DateTime? startDate, DateTime? endDate)
        {
            
            var inspection = db.INSPECTION.Include(i => i.LAB).Include(i => i.USER);
            var inspectionDetails = db.INSPECTIONDETAILS;
            var hazardsObserved = db.HAZARDOBSERVED.Include(i => i.INSPECTIONDETAILS);
            if (startDate != null || endDate != null)
            { 
                    if (startDate == null)
                    {
                        inspection = inspection.Where(s => s.date <= endDate);
                    }
                    if (endDate == null)
                    {
                        inspection = inspection.Where(s => s.date >= startDate);
                    }
                if (startDate != null && endDate != null)
                {
                    inspection = inspection.Where(s => s.date <= endDate).Where(s => s.date >= startDate);
                }           
            }
            
            if (!String.IsNullOrEmpty(labSearch))
                inspection = inspection.Where(s => s.LAB.room.Contains(labSearch) || s.LAB.building.Contains(labSearch));

            if (!String.IsNullOrEmpty(techSearch))
                inspection = inspection.Where(s => s.USER.firstName.Contains(techSearch) || s.USER.lastName.Contains(techSearch));

            string searchType = Request["status"];
            if (!string.IsNullOrWhiteSpace(status))
            {
                if (searchType.Equals("Fail"))
                    inspection = inspection.Where(s => s.status == false);
                 else if (searchType.Equals("Pass"))
                    inspection = inspection.Where(s => s.status == true);
            }

            return View(new SearchVM(inspection.ToList(), inspectionDetails.ToList(), hazardsObserved.ToList()));
        }

        // GET: Search/Details/5
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
    }
}
