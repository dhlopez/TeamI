//PROG1210
//David Lopez
//Registration Page for new users

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace TeamI
{
    public partial class Registration : System.Web.UI.Page
    {
        UserStore<IdentityUser> userStore;
        UserManager<IdentityUser> manager;

        protected void Page_Load(object sender, EventArgs e)
        {
        
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            userStore = new UserStore<IdentityUser>();
            manager = new UserManager<IdentityUser>(userStore);

            IdentityUser user = new IdentityUser(txtUser.Text);
            IdentityResult idResult = manager.Create(user, txtPass.Text);
           
            //await manager.CreateAsync(user, txtPass.Text);

            if (idResult.Succeeded)
            {
                manager.SetEmail(user.Id, txtEmail.Text);
                manager.AddToRole(user.Id, ddlRoles.SelectedValue);

                lblMessage.Text = "User " + user.UserName + " was created successfully!";
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

                var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenticationManager.SignIn(userIdentity);

                Response.Cookies["NCSafetyUser"]["username"] = user.UserName;
                Response.Cookies["NCSafetyUser"]["email"] = user.Email;
                Response.Cookies["NCSafetyUser"]["role"] = user.Roles.FirstOrDefault().RoleId;
                Response.Cookies["NCSafetyUser"].Expires = DateTime.Now.AddDays(1d);
                Response.Redirect("~/Home/Index");
                //Response.Redirect("~/LocalLogin/Welcome.aspx");
            }
            else
            {
                if (idResult.Errors.FirstOrDefault().Contains("taken"))
                {
                    lblMessage.Text = idResult.Errors.FirstOrDefault()+"\n Please go to the login page";
                    btnLogin.Visible = true;
                }
                else
                {
                    lblMessage.Text = idResult.Errors.FirstOrDefault();
                }
            }
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/LocalLogin/Login.aspx");
        }
    }
}