using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamI.Models
{
    public class DisplayContact
    {
        public string DisplayName { get; set; }
        public string EmailAddress { get; set; }
        public string MobilePhone { get; set; }

        public DisplayContact(string displayName, IList<Microsoft.Office365.OutlookServices.EmailAddress> emailAddresses, string mobilePhone)
        {
            this.DisplayName = displayName;
            this.EmailAddress = emailAddresses[0] == null ? "" : emailAddresses[0].Address;
            this.MobilePhone = mobilePhone;
        }
    }
}