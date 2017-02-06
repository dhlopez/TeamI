using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamI.Models
{
    [MetadataType(typeof(LabMetaData))]
    public partial class LAB
    {

    }

    public class LabMetaData
    {
        [Display(Name = "Building")]
        public string building { get; set; }
        [Display(Name = "Room")]
        public string room { get; set; }
        [Display(Name = "Type")]
        public string type { get; set; }
    }
}