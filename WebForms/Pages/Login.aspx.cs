using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForms.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.Cookies["personalData"] != null)
            {
                Response.Redirect("UsersList.aspx");
            }
            TxtName.Focus();
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("personalData");
            cookie["fullName"] = HttpUtility.UrlEncode(TxtName.Text);
            cookie["address"] = HttpUtility.UrlEncode(TxtAddress.Text);
            cookie["email"] = HttpUtility.UrlEncode(TxtEmail.Text);
            cookie.Expires = DateTime.Now.AddDays(1);

            Response.Cookies.Add(cookie);
            Response.Redirect("UsersList.aspx");
        }
    }
}