using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.Office365.OutlookServices;
using TeamI.Models;

namespace TeamI.ViewModel
{
    public class UserInformation
    {
        private NCSafteyInspectionEntities db = new NCSafteyInspectionEntities();
        public bool authenticated;
        private int id;
        private string name = "Unknown User";
        private string email = "";
        private string phone = "";
        private string postalCode = "";
        private string role = "";

        public UserInformation()
        {
        }

        public UserInformation(string username, string useremail)
        {
            try
            {
                if (username.Length > 0)
                {
                    var user = (from _user in db.USER
                                where _user.email == useremail
                                select _user).ToList();
                    if (user.Count() != 0)
                    {
                        authenticated = true;
                        foreach (var person in db.USER.Where(u => u.email == useremail))
                        {
                            id = person.ID;
                            name = person.firstName + " " + person.lastName;
                            email = person.email;
                            phone = person.phone;
                            postalCode = person.postalCode;
                            role = person.role;
                        }
                    }
                    else
                    {
                        authenticated = false;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public int ID { get { return id; } }
        public string Name { get { return name; } }
        public string Email { get { return email; } }
        public string Phone { get { return phone; } }
        public string PostalCode { get { return postalCode; } }
        public string Role { get { return role; } }

        
    }
}