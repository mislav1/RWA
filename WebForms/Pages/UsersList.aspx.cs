using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebForms.Pages
{
    public partial class UsersList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["personalData"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                IList<Country> countries = Repo.GetCountries();
                IList<City> cities = Repo.GetCitiesByCountry(1);
                

                ddlCountry.DataSource = Repo.GetCountries();
                ddlCountry.DataTextField = "Name";
                ddlCountry.DataValueField = "Id";
                ddlCountry.DataBind();

                ddlCities.DataSource = Repo.GetCitiesByCountry(1);
                ddlCities.DataTextField = "Name";
                ddlCities.DataValueField = "Id";
                ddlCities.DataBind();

                tbNumRows.Text = "40";

                dlSort.DataSource = new List<String> { "Id (uzlazno)", "Id (silazno)", "Ime (uzlazno)", "Ime (silazno)", "Prezime (uzlazno)", "Prezime (silazno)" };
                dlSort.DataBind();
            }  
        }

        private void CreateUsersTable(IList<User> users)
        {
            tblPanel.Controls.Clear();

            HtmlGenericControl divUserRowHeader = new HtmlGenericControl("div");
            divUserRowHeader.Attributes.Add("class", "userRow");

            HtmlGenericControl headerName = new HtmlGenericControl("div");
            headerName.Attributes.Add("class", "rowCellHeader");
            headerName.InnerText = "Ime";

            HtmlGenericControl headerLastName = new HtmlGenericControl("div");
            headerLastName.Attributes.Add("class", "rowCellHeader");
            headerLastName.InnerText = "Prezime";

            HtmlGenericControl headerEmail = new HtmlGenericControl("div");
            headerEmail.Attributes.Add("class", "rowCellHeader");
            headerEmail.InnerText = "Email";

            HtmlGenericControl headerPhone = new HtmlGenericControl("div");
            headerPhone.Attributes.Add("class", "rowCellHeader");
            headerPhone.InnerText = "Telefon";

            HtmlGenericControl emptyHeader = new HtmlGenericControl("div");
            emptyHeader.Attributes.Add("class", "rowCellHeader");
            emptyHeader.InnerText = "";

            divUserRowHeader.Controls.Add(headerName);
            divUserRowHeader.Controls.Add(headerLastName);
            divUserRowHeader.Controls.Add(headerEmail);
            divUserRowHeader.Controls.Add(headerPhone);
            divUserRowHeader.Controls.Add(emptyHeader);

            tblPanel.Controls.Add(divUserRowHeader);

            foreach (User user in users)
            {
                HtmlGenericControl divUserRow = new HtmlGenericControl("div");
                divUserRow.Attributes.Add("class", "userRow");

                HtmlGenericControl userFirstName = new HtmlGenericControl("div");
                userFirstName.Attributes.Add("class", "rowCell");
                userFirstName.InnerText = user.FirstName;

                HtmlGenericControl userLastName = new HtmlGenericControl("div");
                userLastName.Attributes.Add("class", "rowCell");
                userLastName.InnerText = user.LastName;

                HtmlGenericControl userEmail = new HtmlGenericControl("div");
                userEmail.Attributes.Add("class", "rowCell");
                userEmail.InnerText = user.Email;

                HtmlGenericControl userPhone = new HtmlGenericControl("div");
                userPhone.Attributes.Add("class", "rowCell");
                userPhone.InnerText = user.Phone;


                LinkButton userDetails = new LinkButton();
                userDetails.Text = "Detalji";
                userDetails.CssClass = "detailsButton";
                userDetails.CausesValidation = false;
                userDetails.Attributes.Add("onclick", "return false;");
                userDetails.OnClientClick = $"javascript:redirect({user.Id});";

                divUserRow.Controls.Add(userFirstName);
                divUserRow.Controls.Add(userLastName);
                divUserRow.Controls.Add(userEmail);
                divUserRow.Controls.Add(userPhone);
                divUserRow.Controls.Add(userDetails);

                tblPanel.Controls.Add(divUserRow);
            }
        }


        protected string UserDetails_Click(object sender, EventArgs e)
        {
            int userId = int.Parse(((LinkButton)sender).CommandArgument);
            Response.Redirect("UserDetail.aspx?id=" + userId);
            return "false";
        }

        protected void btnFetchUsers_Click(object sender, EventArgs e)
        {
            try
            {
                int numOfRows = int.Parse(tbNumRows.Text);
                if(numOfRows > 0 && numOfRows < 51)
                {
                    IList<User> users = Repo.GetUsersFromCity(0, int.Parse(tbNumRows.Text), int.Parse(ddlCities.SelectedValue), dlSort.SelectedValue);
                    CreateUsersTable(users);
                } else
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            
        }
    }
}