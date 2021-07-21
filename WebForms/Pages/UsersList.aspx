<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsersList.aspx.cs" Inherits="WebForms.Pages.UsersList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/UsersList.css" rel="stylesheet" />
    <script>
        function redirect(id) {
            window.location = "UserDetail.aspx?id="+id;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Kupci</h1>
            <div class="filters-conainer">
                <div class="single-filter">
                    <label>Drzava:</label>
                    <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="false"></asp:DropDownList>
                </div>
                
                <div class="single-filter">
                    <label>Grad:</label>
                    <asp:DropDownList ID="ddlCities" runat="server" AutoPostBack="false"></asp:DropDownList>
                </div>
                
                <div class="single-filter">
                    <label>Broj redova:</label>
                    <asp:TextBox ID="tbNumRows" runat="server"></asp:TextBox>
                    <asp:RangeValidator id="Range1"
                       ControlToValidate="tbNumRows"
                       MinimumValue="1"
                       MaximumValue="50"
                       Type="Integer"
                       EnableClientScript="false"
                       Text="Vrijednost mora biti između 1 i 50"
                       ForeColor="Red"
                       runat="server"/>
                </div>
                
                <div class="single-filter">
                    <label>Sortiraj po polju:</label>
                    <asp:DropDownList ID="dlSort" runat="server"  AutoPostBack="false"></asp:DropDownList>
                </div>
            </div>
            <div class="container">
                <asp:Button ID="btnFetchUsers" runat="server" Text="Dohvati kupce" OnClick="btnFetchUsers_Click" />
            </div>
            <asp:Panel ID="tblPanel" runat="server" CssClass="tablePanel"></asp:Panel>
        </div>
    </form>
</body>
</html>
