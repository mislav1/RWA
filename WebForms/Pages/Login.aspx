<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebForms.Pages.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/Login.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        
        <div class="container">
            <h1>Prijavi se</h1>
            <div class="input-container">
                <label class="lbl">Ime i prezime:</label>
                <asp:TextBox ID="TxtName" runat="server" AutoComplete="Disabled" CssClass="txtBox"></asp:TextBox>
                <asp:RequiredFieldValidator 
                    runat="server" 
                    ErrorMessage="Ime i prezime je obavezno polje"
                    Text="*"
                    Display="Dynamic"
                    ControlToValidate="TxtName"
                >
                </asp:RequiredFieldValidator>
            </div>
            <div class="input-container">
                <label class="lbl">E-mail:</label>
                <asp:TextBox ID="TxtEmail" runat="server" AutoComplete="Disabled" CssClass="txtBox"></asp:TextBox>
                <asp:RequiredFieldValidator 
                    runat="server" 
                    ErrorMessage="Email je obavezno polje"
                    Text="*"
                    Display="Dynamic"
                    ControlToValidate="TxtEmail"
                >
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator 
                    ID="regexEmailValid" 
                    runat="server" 
                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                    ControlToValidate="TxtEmail" 
                    Display="Dynamic"
                    Text="*"
                    ErrorMessage="Email nije ispravan"
                    ForeColor="Red">
                </asp:RegularExpressionValidator>
            </div>
            <div class="input-container">
                <label class="lbl">Adresa:</label>
                <asp:TextBox ID="TxtAddress" runat="server" AutoComplete="Disabled" CssClass="txtBox"></asp:TextBox>
                <asp:RequiredFieldValidator 
                    runat="server" 
                    ErrorMessage="Adresa je obavezno polje"
                    Text="*"
                    Display="Dynamic"
                    ControlToValidate="TxtAddress"
                >
                </asp:RequiredFieldValidator>
            </div>
            <asp:Button ID="BtnLogin" runat="server" Text="Prijava" OnClick="BtnLogin_Click" CssClass="btnLogin"/>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red"/>
        </div>
    </form>
</body>
</html>
