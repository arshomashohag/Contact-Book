using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo_Application
{
    public partial class Demo : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["first_name"] != null && Session["last_name"] != null && Session["email"] != null)
            {
                SignupButton.Visible = false;
                LoginButton.Visible = false;
                NavbarDropdown.Visible = true;
                NavbarDropdown.Text = Session["first_name"] + " " + Session["last_name"];
            } else
            {
                NavbarDropdown.Visible = false;
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {

        }

        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("signin.aspx");
        }
    }
}