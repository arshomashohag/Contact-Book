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
    public partial class signin : System.Web.UI.Page
    {
        string conString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["first_name"] != null && Session["last_name"] != null && Session["email"] != null && Session["user_id"] != null)
            {
                Response.Redirect("home.aspx");
                return;
            }
        }

        protected void SubmitButon_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection sqlCon = new SqlConnection(conString);
                if(sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE email=@email and password=@password", sqlCon);

                cmd.Parameters.AddWithValue("@email", EmailBox.Text.Trim());
                cmd.Parameters.AddWithValue("@password", PasswordBox.Text.Trim());

                SqlDataReader dr = cmd.ExecuteReader();

                

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Session["first_name"] = dr.GetValue(1).ToString();
                        Session["last_name"] = dr.GetValue(2).ToString();
                        Session["email"] = dr.GetValue(3).ToString();
                        Session["user_id"] = dr.GetValue(0).ToString();
                    }
                     
                    
                    Response.Redirect("home.aspx");

                } else
                {
                    Response.Write("<script> alert('No user found, check email/password !')");
                }

                if (!dr.IsClosed)
                {
                    dr.Close();
                }


                if (sqlCon.State != ConnectionState.Closed)
                {
                    sqlCon.Close();
                }

            } catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
            
        }
    }
}