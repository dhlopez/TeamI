//PROG1210
//Vanscoy

//Welcome page

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeamI
{
    public partial class Welcome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)//boolean - true if user is logged in, false otherwise
            {
                lblWelcome.Text += " " + User.Identity.Name; //String - name of the current logged in user
                lnkLogout.Visible = true;
                lnkLogin.Visible = false;
                pnlProtectedContent.Visible = true;
            }
            else
            {
                lblWelcome.Text += " /n Please log in";
                lnkLogout.Visible = false;
                lnkLogin.Visible = true;
            }
            
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

            authenticationManager.SignOut();

            Response.Redirect("~/LocalLogin/Login.aspx");

        }

        protected void lnkLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/LocalLogin/Login.aspx");
        }

        protected void lnkMovie_Click(object sender, EventArgs e)
        {
            //example 1 for other pages (like bid)
        }

        protected void lnkRatings_Click(object sender, EventArgs e)
        {
            //example 2 for other pages
        }
    }
}