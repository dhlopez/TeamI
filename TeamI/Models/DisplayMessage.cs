using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamI.Models
{
    public class DisplayMessage
    {

        public string Subject { get; set; }
        public DateTimeOffset ReceivedDateTime { get; set; }

        public DisplayMessage(string subject, DateTimeOffset? dateTimeReceived)
        {
            this.Subject = subject;
            this.ReceivedDateTime = (DateTimeOffset)dateTimeReceived;
        }
    }
}