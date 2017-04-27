using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            // Create the form generator class
            SubmitFormGenerator sfg = new SubmitFormGenerator("POST", this.ClientQueryString, true);

            // Render it to the screen
            sfg.renderTo(this.formarea);
        } else
        {
            // If we're receiving a form, let us know.
            string firstname = Request.Form.Get("firstname");
            string lastname = Request.Form.Get("lastname");
            string email = Request.Form.Get("email");

            // Had to return a string, due to potential responses: Inserted, Not inserted (Duplicate), or Fail
            string attempt = addUser(firstname, lastname, email);

            // Insert successful.
            if (attempt == "true")
            {
                this.formarea.InnerHtml = "<div class='text-center text-success'>You have been successfully signed up for our newsletter. Thank you, " + Request.Form.Get("firstname") + " " + Request.Form.Get("lastname") + ".</div>";
            } else if(attempt == "false") // Insert unsuccessful, found a duplicate email
            {
                this.formarea.InnerHtml = "<div class='text-center text-warning'>Someone has signed up for our newsletter with that email already.</div>";
            } else // Insert unsuccessful, for reasons.
            {
                formarea.InnerHtml = "<div class='text-center text-danger'>There was an error with the database: "+attempt+"</div>";
            }
        }
    }

    // addUser function
    // Connects to the database, and attempts to insert a new user with the inputted criteria.
    // Will not insert if the email already exists in our database. 
    protected string addUser(string firstname, string lastname, string email)
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["usersConnectionString"].ConnectionString;
        string emq = "SELECT id FROM [dbo].[users] WHERE email = @em";
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            using (SqlCommand comm = new SqlCommand())
            {
                comm.Connection = conn;
                comm.CommandText = emq;
                comm.Parameters.AddWithValue("@em", email);
                try
                {
                    conn.Open();
                    SqlDataReader res = comm.ExecuteReader();
                    if (res.HasRows)
                    {
                        res.Close();
                        return "false";
                    }
                    res.Close();
                }
                catch (SqlException e)
                {
                    return e.Message;
                }
            }
            string q = "INSERT INTO [dbo].[users] (first_name,last_name,email) VALUES (@fn, @ln, @em)";
            using (SqlCommand comm = new SqlCommand())
            {
                comm.Connection = conn;
                comm.CommandText = q;
                comm.Parameters.AddWithValue("@fn", firstname);
                comm.Parameters.AddWithValue("@ln", lastname);
                comm.Parameters.AddWithValue("@em", email);
                try
                {
                    comm.ExecuteNonQuery();
                    return "true";
                }
                catch (SqlException e)
                {
                    return e.Message;
                }
            }
        }
    }
}
