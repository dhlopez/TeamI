﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamI.Models
{
    [MetadataType(typeof(InspectionMetaData))]
    public partial class ISNPECTION
    {

    }

    public class InspectionMetaData
    {
        [Display(Name = "First Name")]
        public string firstName { get; set; }
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        [Display(Name = "Email")]
        public string email { get; set; }
        [Display(Name = "Phone")]
        public string phone { get; set; }
        [Display(Name = "Postal Code")]
        public string postalCode { get; set; }
        [Display(Name = "Role")]
        public string role { get; set; }
    }
}