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
            //get account information
            if(!IsPostBack)
            {
                getAccountInfo();
            }
        }

        protected void getAccountInfo()
        {

            using (FinalEntities conn = new FinalEntities())
            {
                //get current user id
                var userId = User.Identity.GetUserId();

                //pull information from database
                var account = (from acc in conn.Users
                               where acc.UserID == userId
                               select acc).FirstOrDefault();
                //populate editing form
                txtAccountName.Text = account.Name;
                txtBudget.Text = Convert.ToString(account.Budget);
            }
        }

        //save information
        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (FinalEntities conn = new FinalEntities())
            {
                //get current user id
                var userId = User.Identity.GetUserId();

                //pull information from database
                var account = (from acc in conn.Users
                               where acc.UserID == userId
                               select acc).FirstOrDefault();

                //set new information
                account.Name = txtAccountName.Text;
                account.Budget = Convert.ToDecimal(txtBudget.Text);

                //save changes
                conn.SaveChanges();

                //redirect to account information
                Response.Redirect("index.aspx");
            }
        }
    }
}