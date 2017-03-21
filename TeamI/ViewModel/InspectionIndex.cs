using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamI.Models;

namespace TeamI.ViewModel
{
    public class InspectionIndexViewModel
    {
        public List<INSPECTION> inspection { get; set; }
        public List<HAZARDOBSERVED> hazardsobserved { get; set; }
        public List <HAZARD> hazard { get; set; }
    }
}