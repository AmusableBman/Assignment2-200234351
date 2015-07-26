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
using System.Linq.Dynamic;

namespace Assignment2.budget
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //pull expenses
            if (!IsPostBack)
            {
                //set sorting
                Session["SortDirection"] = "ASC";
                Session["SortColumn"] = "Name";
                getExpenses();
            }
        }

        protected void getExpenses()
        {
            using (FinalEntities conn = new FinalEntities())
            {
                //get user id
                var userId = User.Identity.GetUserId();
                
                //initialize expense total
                decimal expenses = 0;

                //get user and expense info
                var user = (from u in conn.Users
                            where u.UserID == userId
                            select u).FirstOrDefault();

                var exps = (from e in conn.Expenses
                            join u in conn.Users on e.UserID equals u.Id
                            where e.UserID == user.Id
                            select e);

                //set budget
                var budget = user.Budget;

                //sort entries
                String Sort = Session["SortColumn"].ToString() + " " + Session["SortDirection"].ToString();

                //display expenses in table
                grdExpenses.DataSource = exps.AsQueryable().OrderBy(Sort).ToList();
                grdExpenses.DataBind();

                //display budget
                lblBudgetStart.Text ="$" + Convert.ToString(user.Budget);
                lblBudgetMid.Text ="$" + Convert.ToString(user.Budget);

                //if there are expenses...
                if (exps.Count() > 0)
                {
                    //loop through expenses and total them up
                    foreach (Expens expense in exps)
                    {
                        expenses += expense.Cost;
                    }
                    //display expenses and final total
                    lblExpenses.Text = "$" + Convert.ToString(Math.Round(expenses, 2));
                    decimal final = Convert.ToDecimal(budget) - expenses;
                    lblFinal.Text = "$" + Convert.ToString(final);

                    //change color of final total depending on value
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
            //get specified expense
            using (FinalEntities conn = new FinalEntities())
            {
                Int32 ExpenseID = Convert.ToInt32(grdExpenses.DataKeys[e.RowIndex].Values["ID"]);

                var exp = (from ex in conn.Expenses
                           where ex.Id == ExpenseID
                           select ex).FirstOrDefault();
                //remove expense from database
                conn.Expenses.Remove(exp);
                conn.SaveChanges();
            }
            

        }

        protected void grdExpenses_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if sorting was clicked...
            if (IsPostBack)
            {
                //if we're at the header row...
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    //create new image variable
                    Image SortImage = new Image();

                    //loop through the columns
                    for (int i = 0; i <= grdExpenses.Columns.Count - 1; i++)
                    {
                        //if we find a column equal to the column we want to sort...
                        if (grdExpenses.Columns[i].SortExpression == Session["SortColumn"].ToString())
                        {
                            //check sorting direction
                            if (Session["SortDirection"].ToString() == "DESC")
                            {
                                //add appropriate image
                                SortImage.ImageUrl = "/images/desc.jpg";
                                SortImage.AlternateText = "Sort Descending";
                            }
                            else
                            {
                                //add appropriate image
                                SortImage.ImageUrl = "/images/asc.jpg";
                                SortImage.AlternateText = "Sort Ascending";
                            }

                            //add image to column header
                            e.Row.Cells[i].Controls.Add(SortImage);

                        }
                    }
                }

            }
        }

        protected void btnExpense_Click(object sender, EventArgs e)
        {
            //redirect to add expenses
            Response.Redirect("expense.aspx");
        }

        protected void grdExpenses_Sorting(object sender, GridViewSortEventArgs e)
        {
            //set sorting
            Session["SortColumn"] = e.SortExpression;
            getExpenses();

            if (Session["SortDirection"].ToString() == "ASC")
            {
                Session["SortDirection"] = "DESC";
            }
            else
            {
                Session["SortDirection"] = "ASC";
            }
        }
    }
}