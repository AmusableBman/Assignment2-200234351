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
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getExpenses();
            }
        }

        protected void getExpenses()
        {
            using (FinalEntities conn = new FinalEntities())
            {
                var userId = User.Identity.GetUserId();
                
                decimal expenses = 0;

                var user = (from u in conn.Users
                            where u.UserID == userId
                            select u).FirstOrDefault();

                var exps = (from e in conn.Expenses
                            join u in conn.Users on e.UserID equals u.Id
                            where e.UserID == user.Id
                            select e);

                var budget = user.Budget;

                grdExpenses.DataSource = exps.ToList();
                grdExpenses.DataBind();

                

                lblBudgetStart.Text ="$" + Convert.ToString(user.Budget);
                lblBudgetMid.Text ="$" + Convert.ToString(user.Budget);

                if (exps.Count() > 0)
                {
                    foreach (Expens expense in exps)
                    {
                        expenses += expense.Cost;
                    }
                    lblExpenses.Text = "$" + Convert.ToString(Math.Round(expenses, 2));
                    decimal final = Convert.ToDecimal(budget) - expenses;
                    lblFinal.Text = "$" + Convert.ToString(final);

                    if (final <= 0)
                    {
                        budgetFinal.Attributes["style"] = "background: red;";
                    }
                    else
                    {
                        budgetFinal.Attributes["style"] = "background: green;";
                    }
                }

            }
        }

        protected void grdExpenses_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            using (FinalEntities conn = new FinalEntities())
            {
                Int32 ExpenseID = Convert.ToInt32(grdExpenses.DataKeys[e.RowIndex].Values["ID"]);

                var exp = (from ex in conn.Expenses
                           where ex.Id == ExpenseID
                           select ex).FirstOrDefault();
                conn.Expenses.Remove(exp);
                conn.SaveChanges();
            }
            

        }

        protected void grdExpenses_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnExpense_Click(object sender, EventArgs e)
        {
            Response.Redirect("expense.aspx");
        }
    }
}