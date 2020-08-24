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
    public partial class show_contacts : System.Web.UI.Page
    {
        string conString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["first_name"] == null || Session["last_name"] == null || Session["email"] == null || Session["user_id"] == null)
            {
                Response.Redirect("signin.aspx");
                return;
            }
            
             

            try
            {
                SqlConnection sqlCon = new SqlConnection(conString);
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                }
                  

                SqlCommand cmd = new SqlCommand("SELECT * FROM contacts WHERE user_id=@user_id", sqlCon);

                cmd.Parameters.AddWithValue("@user_id", Session["user_id"]);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        TableRow row = new TableRow();
                        TableCell name = new TableCell();
                        TableCell phone = new TableCell();
                        TableCell email = new TableCell();
                        TableCell address = new TableCell();
                        TableCell action = new TableCell();

                        name.Text = dr.GetValue(2).ToString() + " " + dr.GetValue(3).ToString();
                        phone.Text = dr.GetValue(4).ToString();
                        email.Text = dr.GetValue(5).ToString();
                        address.Text = dr.GetValue(6).ToString();
                        action.Text = "<a href='update-contact.aspx?id=" + dr.GetValue(0).ToString() + "' class='btn-edit mr-2'>" +
                                            "<i class='fa fa-pencil-square-o' aria-hidden='true'></i>" +
                                      "</a>" +
                                       "<a class='btn-delete' href='delete-contact.aspx?id=" + dr.GetValue(0).ToString() + "'>" +
                                            "<i class='fa fa-trash-o' aria-hidden='true'></i>" +
                                        "</a>";
                        row.Cells.Add(name);
                        row.Cells.Add(phone);
                        row.Cells.Add(email);
                        row.Cells.Add(address);
                        row.Cells.Add(action); 
                        ContactTable.Rows.Add(row);
                    }

                } else
                {

                    TableCell cell = new TableCell();
                    cell.Text = "No contacts found!";

                    TableRow row = new TableRow();
                    row.Cells.Add(cell);
                    ContactTable.Rows.Add(row);
                }

                sqlCon.Close();
                

            } catch(Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"')</script>");
            }
            }
    }
}