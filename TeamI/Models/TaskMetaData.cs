using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamI.Models
{
    [MetadataType(typeof(TaskMetaData))]
    public partial class TASK
    {

    }

    public class TaskMetaData
    {
        [Display(Name = "Description")]
        public string description { get; set; }
        [Display(Name = "Date")]
        public Nullable<System.DateTime> date { get; set; }
        [Display(Name = "Status")]
        public Nullable<bool> status { get; set; }
        [Display(Name = "User")]
        public Nullable<int> userID { get; set; }
    }
}