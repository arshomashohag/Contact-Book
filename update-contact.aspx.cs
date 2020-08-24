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
    public partial class update_contact : System.Web.UI.Page
    {
        string conString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];

            if (Session["first_name"] == null || Session["last_name"] == null || Session["email"] == null || Session["user_id"] == null)
            {
                Response.Redirect("signin.aspx");
                return;
            }

            if (!IsPostBack)
            {
                try
                {
                    SqlConnection sqlCon = new SqlConnection(conString);
                    if (sqlCon.State == ConnectionState.Closed)
                    {
                        sqlCon.Open();
                    }


                    SqlCommand cmd = new SqlCommand("SELECT * FROM contacts WHERE id=@id", sqlCon);

                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            UpdateFirstNameTextBox.Text = dr.GetValue(2).ToString().Trim();
                            UpdateLastNameTextBox.Text = dr.GetValue(3).ToString().Trim();
                            UpdatePhoneNumberBox.Text = dr.GetValue(4).ToString().Trim();
                            UpdateEmailTextBox.Text = dr.GetValue(5).ToString().Trim();
                            UpdateAddressBox.Text = dr.GetValue(6).ToString().Trim();
                        }

                    } else
                    {
                        Response.Write("<script>alert('No contact found!')</script>");
                        // Response.Redirect("show-contacts.aspx");
                    }
                } catch(Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "')</script>");
                    // Response.Redirect("show-contacts.aspx");
                }
            }
           
        }

        protected void UpdateContactButton_Click(object sender, EventArgs e)
        {
            int id =  Convert.ToInt32(Request.QueryString["id"]);

            string first_name = UpdateFirstNameTextBox.Text.Trim();
            string last_name = UpdateLastNameTextBox.Text.Trim();
            string email = UpdateEmailTextBox.Text.Trim();
            string phone = UpdatePhoneNumberBox.Text.Trim();
            string address = UpdateAddressBox.Text.Trim();

            
            try
            {
                SqlConnection sqlCon = new SqlConnection(conString);
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                }


                
                SqlCommand cmd = new SqlCommand("UPDATE contacts SET " +
                    "first_name = @first_name, " +
                    "last_name = @last_name, " +
                    "email = @email, " +
                    "phone = @phone, " +
                    "address = @address" +
                    " WHERE id = @id", sqlCon);

                cmd.Parameters.AddWithValue("@first_name", first_name);
                cmd.Parameters.AddWithValue("@last_name", last_name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();

                cmd.Dispose();
                sqlCon.Close();
                

                Response.Write("<script>alert('Contact updated!')</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>"); 
            }
        }
    }
}