using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;
using RestSharp.Authenticators;

namespace TeamI.App_Start
{
    public static class SimpleEmail
    {
        public static void SendSimpleMessage(string emailFrom, string emailTo, string destName, string emailType)
        {
            string bodyEmail="There was an error sending this email, please contact your administrator";
            switch (emailType) {
                case "inspection":
                    bodyEmail = "Hi " + destName + Environment.NewLine + "A new inspection was created";
                    break;
                case "hazard":
                    bodyEmail = "Hi " + destName + Environment.NewLine + "A new hazard was created";
                    break;
                case "due":
                    bodyEmail = "Hi " + destName + Environment.NewLine + "A new inspection is coming up/is already due";
                    break;
                default: break;
            }
            RestClient client = new RestClient();
            client.BaseUrl = new System.Uri("https://api.mailgun.net/v3");
            client.Authenticator =
            new HttpBasicAuthenticator("api",
                                      "key-88bcfda0bac089d6f861e5fa3f7d8a32");
            RestRequest request = new RestRequest();
            request.AddParameter("domain", "sandboxe5dae96553a54504b07b52d2804e9212.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            //request.AddParameter("from", "Mailgun Sandbox <postmaster@sandboxe5dae96553a54504b07b52d2804e9212.mailgun.org>");
            request.AddParameter("from", "NCSafetySystem <postmaster@sandboxe5dae96553a54504b07b52d2804e9212.mailgun.org>");
            //request.AddParameter("to", "David <dhelaman@hotmail.com>");
            request.AddParameter("to", emailTo);
            request.AddParameter("subject", emailType);
            request.AddParameter("text", bodyEmail);
            request.Method = Method.POST;
            client.Execute(request);
        }
    }
}