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
    public partial class signup : System.Web.UI.Page
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

        protected void SignupSubmitButon_Click(object sender, EventArgs e)
        {
            string currentDate = DateTime.Now.ToString();

            try
            {
                SqlConnection sqlCon = new SqlConnection(conString);

                if(sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                }


                SqlCommand checkCmd = new SqlCommand("SELECT * from users WHERE email=@email", sqlCon);

                checkCmd.Parameters.AddWithValue("@email", SignupEmailBox.Text.Trim());

                SqlDataReader dr = checkCmd.ExecuteReader();

                if (dr.HasRows)
                {
                    Response.Write("<script> alert('Email already exists!!!')</script>");
                    return ;
                }

                if (!dr.IsClosed)
                {
                    dr.Close();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO users(first_name, last_name, email, password, created_at)" +
                    " values(@first_name, @last_name, @email, @password, @created_at)", sqlCon);

                 
                if(SignupPasswordBox.Text.Trim() == SignupConfirmPassword.Text.Trim())
                {
                     
                    cmd.Parameters.AddWithValue("@first_name", SignupFirstNameBox.Text.Trim());
                    cmd.Parameters.AddWithValue("@last_name", SignupLastName.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", SignupEmailBox.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", SignupPasswordBox.Text.Trim());
                    cmd.Parameters.AddWithValue("@created_at", currentDate);

                    cmd.ExecuteNonQuery();
                    if (sqlCon.State != ConnectionState.Closed)
                    {
                        sqlCon.Close();
                    }

                    Response.Write("<script>alert('Signup successfull!')</script>");
                } else
                { 
                    Response.Write("<script>alert('Incorrect confirm password!!')</script>");
                }
                 



            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}