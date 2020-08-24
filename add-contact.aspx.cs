using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo_Application
{
    public partial class add_contact : System.Web.UI.Page
    {
        string conString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["first_name"] == null || Session["last_name"] == null || Session["email"] == null || Session["user_id"] == null)
            {
                Response.Redirect("signin.aspx");
                return;
            }
        }

        protected void AddContactButton_Click(object sender, EventArgs e)
        {


            try
            {
                SqlConnection sqlCon = new SqlConnection(conString);
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                }

                string first_name = FirstNameTextBox.Text.Trim();
                string last_name = LastNameTextBox.Text.Trim();
                string email = EmailTextBox.Text.Trim();
                string phone = PhoneNumberBox.Text.Trim();
                string address = Request.Form["address"];

                if(phone == "" || phone == null)
                {
                    Response.Write("<script>alert('Phone number is required')</script>");
                    return;
                }



                SqlCommand cmd = new SqlCommand("INSERT INTO contacts(user_id, first_name, last_name, email, phone, address) " +
                    "VALUES(@user_id, @first_name, @last_name, @email, @phone, @address)", sqlCon);


                cmd.Parameters.AddWithValue("@user_id", Session["user_id"]);
                cmd.Parameters.AddWithValue("@first_name", first_name);
                cmd.Parameters.AddWithValue("@last_name", last_name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@address", address);

                cmd.ExecuteNonQuery();

                sqlCon.Close();

                Response.Write("<script>alert('Contact added!!')</script>");
                FirstNameTextBox.Text = "";
                LastNameTextBox.Text = "";
                EmailTextBox.Text = "";
                PhoneNumberBox.Text = "";

            } catch(Exception ex)
            {
                ErrorLabel.Text = ex.Message;
                Response.Write("<script>alert('Contact not added!!')</script>");
            }
            


        }
    }
}