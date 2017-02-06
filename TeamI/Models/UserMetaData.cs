using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamI.Models
{
    [MetadataType(typeof(UserMetaData))]
    public partial class USER
    {
        private NCSafteyInspectionEntities db = new NCSafteyInspectionEntities();

        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", firstName, lastName);
            }
        }
    }

    public class UserMetaData
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