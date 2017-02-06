using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamI.Models;

namespace TeamI.ViewModel
{
    public class FullInspection
    {
        private NCSafteyInspectionEntities db = new NCSafteyInspectionEntities();

        public List<INSPECTION> inspection { get; set; }
        public List<INSPECTIONDETAILS> inspectionDetails { get; set; }
        public List<HAZARDOBSERVED> HazardsObserved { get; set; }

        public List<HAZARD> Hazards { get; set; }

    }
}