<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserDetail.aspx.cs" Inherits="WebForms.Pages.UserDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/Login.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Detalji o kupcu</h1>
            <div class="input-container">
                <label class="lbl">Ime:</label>
                <asp:TextBox ID="TxtName" runat="server" AutoComplete="Disabled" CssClass="txtBox"></asp:TextBox>
                <asp:RequiredFieldValidator 
                    runat="server" 
                    ErrorMessage="Ime je obavezno polje"
                    Text="*"
                    Display="Dynamic"
                    ControlToValidate="TxtName"
                >
                </asp:RequiredFieldValidator>
            </div>

            <div class="input-container">
                <label class="lbl">Prezime:</label>
                <asp:TextBox ID="txtLastName" runat="server" AutoComplete="Disabled" CssClass="txtBox"></asp:TextBox>
                <asp:RequiredFieldValidator 
                    runat="server" 
                    ErrorMessage="Prezime je obavezno polje"
                    Text="*"
                    Display="Dynamic"
                    ControlToValidate="txtLastName"
                >
                </asp:RequiredFieldValidator>
            </div>

            <div class="input-container">
                <label class="lbl">Email:</label>
                <asp:TextBox ID="txtEmail" runat="server" AutoComplete="Disabled" CssClass="txtBox"></asp:TextBox>
                <asp:RequiredFieldValidator 
                    runat="server" 
                    ErrorMessage="Email je obavezno polje"
                    Text="*"
                    Display="Dynamic"
                    ControlToValidate="txtEmail"
                >
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator 
                    ID="regexEmailValid" 
                    runat="server" 
                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                    ControlToValidate="txtEmail" 
                    Display="Dynamic"
                    Text="*"
                    ErrorMessage="Email nije ispravan"
                    ForeColor="Red">
                </asp:RegularExpressionValidator>
            </div>

            <div class="input-container">
                <label class="lbl">Telefon:</label>
                <asp:TextBox ID="txtPhone" runat="server" AutoComplete="Disabled" CssClass="txtBox"></asp:TextBox>
                <asp:RequiredFieldValidator 
                    runat="server" 
                    ErrorMessage="Telefon je obavezno polje"
                    Text="*"
                    Display="Dynamic"
                    ControlToValidate="txtPhone"
                >
                </asp:RequiredFieldValidator>
            </div>

            <div class="input-container">
                <label class="lbl">Grad:</label>
                <asp:DropDownList ID="dlCities" runat="server" AutoPostBack="false"></asp:DropDownList>
                <asp:RequiredFieldValidator 
                    runat="server" 
                    ErrorMessage="Grad je obavezno polje"
                    Text="*"
                    Display="Dynamic"
                    ControlToValidate="dlCities"
                >
                </asp:RequiredFieldValidator>
            </div>

            <div class="buttons-container">
                <asp:Button ID="btnCancel" runat="server" Text="Odustani" OnClick="btnCancel_Click" CausesValidation="false"/>
                <asp:Button ID="btnUpdate" runat="server" Text="Ažuriraj" OnClick="btnUpdate_Click"/>
            </div>

            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red"/>
        </div>
    </form>
</body>
</html>
