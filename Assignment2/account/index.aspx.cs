using System;
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

namespace Assignment2.account
{
    public partial class edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getAccountInfo();
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("edit.aspx");
        }

        protected void getAccountInfo()
        {
            
            using (FinalEntities conn = new FinalEntities())
            {
                var userId = User.Identity.GetUserId();

                var account = (from acc in conn.Users
                               where acc.UserID == userId
                               select acc).FirstOrDefault();
                lblUsername.Text = User.Identity.GetUserName();
                lblName.Text = account.Name;
                lblBudget.Text = "$ " + Convert.ToString(account.Budget);
            } 
        }
    }
}