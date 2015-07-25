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

namespace Assignment2.budget
{
    public partial class expense : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    getExpense();
                }
            }
        }

        protected void getExpense()
        {
            Int32 ExpenseID = Convert.ToInt32(Request.QueryString["ID"]);

            using (FinalEntities conn = new FinalEntities())
            {
                var exp = (from e in conn.Expenses
                           where e.Id == ExpenseID
                           select e).FirstOrDefault();

                txtName.Text = exp.Name;
                txtDescription.Text = exp.Description;
                txtCost.Text = Convert.ToString(exp.Cost);
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (FinalEntities conn = new FinalEntities())
            {
                var ex = new Expens();
                var userId = User.Identity.GetUserId();

                var user = (from u in conn.Users
                            where u.UserID == userId
                            select u).FirstOrDefault();

                if (!String.IsNullOrEmpty(Request.QueryString["ID"]))
                {

                    Int32 ExpenseID = Convert.ToInt32(Request.QueryString["ID"]);
                    ex = (from expen in conn.Expenses
                          where expen.Id == ExpenseID
                          select expen).FirstOrDefault();
                }

                ex.Name = txtName.Text;
                ex.Description = txtDescription.Text;
                ex.Cost = Convert.ToDecimal(txtCost.Text);
                ex.UserID = user.Id;

                if (String.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    conn.Expenses.Add(ex);
                }

                conn.SaveChanges();
                Response.Redirect("index.aspx");
            }
        }
    }
}