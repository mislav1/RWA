using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForms.Pages
{
    public partial class UserDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["personalData"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                int id = int.Parse(Request.QueryString["id"]);
                User user = Repo.GetUserById(id)[0];

                Session["user"] = user;

                TxtName.Text = user.FirstName;
                txtLastName.Text = user.LastName;
                txtEmail.Text = user.Email;
                txtPhone.Text = user.Phone;

                dlCities.DataSource = Repo.GetAllCities();
                dlCities.DataTextField = "Name";
                dlCities.DataValueField = "Id";
                dlCities.SelectedValue = user.CityId.ToString();
                dlCities.DataBind();
            }
            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("UsersList.aspx");
            Session.Remove("user");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            User user = Session["user"] as User;
            Repo.UpdateUserById(
                user.Id, 
                TxtName.Text, 
                txtLastName.Text, 
                txtEmail.Text, 
                txtPhone.Text, 
                int.Parse(dlCities.SelectedValue));
            Response.Redirect("UsersList.aspx");
            Session.Remove("user");
        }
    }
}