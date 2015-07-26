using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.Owin.Security;

namespace Assignment2
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //show/hide different elements of the nav bar as necessary
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                plhPrivate.Visible = true;
                plhPublic.Visible = false;
                lblAccount.Text = "Welcome, " + HttpContext.Current.User.Identity.Name;
            }
            else
            {
                plhPublic.Visible = true;
                plhPrivate.Visible = false;
            }
        }
    }
}