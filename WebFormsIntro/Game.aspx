<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Game.aspx.cs" Inherits="WebFormsIntro.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Guess a number from 1-100!"></asp:Label>
        </div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <div>
            <asp:Button ID="guess" runat="server" Text="Guess" OnClick="Button1_Click" />
        </div>
        <p>
            <asp:Button ID="restart" runat="server" Text="Restart" Enabled="False" Visible="False" OnClick="restart_Click" />
            
                <asp:Button ID="bTL" runat="server" Height="26px" Text="Back to login" Enabled="False" Visible="False" OnClick="bTL_Click" />
        </p>
            
    </form>
</body>
</html>
