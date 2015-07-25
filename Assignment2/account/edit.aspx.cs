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
    public partial class view : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                getAccountInfo();
            }
        }

        protected void getAccountInfo()
        {
            var AccountID = User.Identity.GetUserId();

            using (FinalEntities conn = new FinalEntities())
            {
                var userId = User.Identity.GetUserId();

                var account = (from acc in conn.Users
                               where acc.UserID == userId
                               select acc).FirstOrDefault();

                txtAccountName.Text = account.Name;
                txtBudget.Text = Convert.ToString(account.Budget);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (FinalEntities conn = new FinalEntities())
            {
                var userId = User.Identity.GetUserId();

                var account = (from acc in conn.Users
                               where acc.UserID == userId
                               select acc).FirstOrDefault();

                account.Name = txtAccountName.Text;
                account.Budget = Convert.ToDecimal(txtBudget.Text);

                conn.SaveChanges();

                Response.Redirect("index.aspx");
            }
        }
    }
}