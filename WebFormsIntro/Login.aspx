<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebFormsIntro.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Login"></asp:Label>
        </div>
        <asp:TextBox ID="usrName" runat="server">Username</asp:TextBox>        
        <div>      
            <asp:TextBox ID="pass" runat="server" style="margin-top: 0px; margin-bottom: 0px">Password</asp:TextBox>
        </div>        
        <div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Login" Height="26px" />
        </div>
    </form>
</body>
</html>
