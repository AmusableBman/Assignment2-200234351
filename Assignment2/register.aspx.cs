﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

using Assignment2.Models;
using System.Web.ModelBinding;

namespace Assignment2
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // Create variables to store user information, awaiting creation
            var userStore = new UserStore<IdentityUser>();
            var manager = new UserManager<IdentityUser>(userStore);

            //creating new user
            var user = new IdentityUser() { UserName = txtUsername.Text };
            IdentityResult result = manager.Create(user, txtPassword.Text);

            if (result.Succeeded)
            {
                //create new user
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenticationManager.SignIn(new AuthenticationProperties() { }, userIdentity);

                //Create new entry on budget table linked to user
                using (FinalEntities conn = new FinalEntities())
                {
                    User newUser = new User();
                    AspNetUser info = (from u in conn.AspNetUsers
                                       where u.UserName == txtUsername.Text
                                       select u).FirstOrDefault();
                    //default values for user
                    newUser.UserID = info.Id;
                    newUser.Name = "UPDATE ACCOUNT INFO";
                    newUser.Budget = Convert.ToDecimal(0.00);

                    //add new user to database
                    conn.Users.Add(newUser);
                    conn.SaveChanges();
                }

                Response.Redirect("/budget/index.aspx");
            }
            else
            {
                //display error in creating user
                lblStatus.Text = result.Errors.FirstOrDefault();
                lblStatus.CssClass = "label label-danger";
            }
        }
    }
}