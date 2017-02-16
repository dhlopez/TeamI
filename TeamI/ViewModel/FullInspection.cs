using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamI.Models;

namespace TeamI.ViewModel
{
    public class FullInspection
    {
        //Inspections
        public DateTime dateIns { get; set; }
        public int labID { get; set; }
        public int userIDIns { get; set; }
        public bool status { get; set; }

        //InspectionsDetails
        public int InspectionID { get; set; }
        public int UserIDInsDet { get; set; }
        public DateTime DateInsDet { get; set; }
        public string AreaEquipment { get; set; }

        //HazardsObserved
        public int InspectionDetailID { get; set; }
        public int HazardID { get; set; }
        public string Comments { get; set; }
        public bool statusHO { get; set; }

        /*V2
        INSPECTION = new INSPECTION();
        INSPECTIONDETAILS = new INSPECTIONDETAILS();
        HAZARDOBSERVED = new HAZARDOBSERVED();

        public INSPECTION INSPECTION { get; set; }
        public INSPECTIONDETAILS INSPECTIONDETAILS { get; set; }
        public HAZARDOBSERVED HAZARDOBSERVED { get; set; }
        */

        /*
        private NCSafteyInspectionEntities db = new NCSafteyInspectionEntities();

        public List<INSPECTION> inspection { get; set; }
        public List<INSPECTIONDETAILS> inspectionDetails { get; set; }
        public List<HAZARDOBSERVED> HazardsObserved { get; set; }

        public List<HAZARD> Hazards { get; set; }
        */

    }
}