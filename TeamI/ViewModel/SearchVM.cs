using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamI.Models;

namespace TeamI.ViewModel
{
    public class SearchVM
    {
        private NCSafteyInspectionEntities db = new NCSafteyInspectionEntities();
        public List<INSPECTION> inspection;
        public List<INSPECTIONDETAILS> inspectionDetails;
        public List<HAZARDOBSERVED> hazardsObserved;

        public SearchVM(List<INSPECTION> inspection, List<INSPECTIONDETAILS> inspectionDetails, List<HAZARDOBSERVED> hazardsObserved)
        {
            this.inspection = inspection;
            this.inspectionDetails = inspectionDetails;
            this.hazardsObserved = hazardsObserved;
        }

    }
}