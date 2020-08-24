using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo_Application
{
    public partial class delete_contact : System.Web.UI.Page
    {
        string conString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["first_name"] == null || Session["last_name"] == null || Session["email"] == null || Session["user_id"] == null)
            {
                Response.Redirect("signin.aspx");
                return;
            }

            string id = Request.QueryString["id"];

            if(id != "" && id != null)
            {
                try
                {
                    SqlConnection sqlCon = new SqlConnection(conString);

                    if (sqlCon.State == ConnectionState.Closed)
                    {
                        sqlCon.Open();
                    }


                    SqlCommand cmd = new SqlCommand("DELETE FROM contacts WHERE id=@id", sqlCon);

                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();

                    cmd.Dispose();

                    sqlCon.Close();

                    Response.Write("<script>alert('Contact deleted!')</script>");
                    Response.Redirect("show-contacts.aspx");

                } catch(Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "')</script>");

                }
            }

            

            }
    }
}