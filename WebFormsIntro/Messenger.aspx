<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="Messenger.aspx.cs" Inherits="WebFormsIntro.Messenger" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <form id="form1" runat="server">
        <asp:ScriptManager ID="srptManager" runat="server">
                    </asp:ScriptManager>
        <div>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:ListBox ID="messageDisplay" runat="server" Height="82px" Width="457px"></asp:ListBox>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="timer" EventName="Tick" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
        <asp:TextBox ID="name" runat="server"></asp:TextBox>
                    
                    <asp:Timer ID="timer" runat="server" Interval="200" OnTick="timer_Tick">
                    </asp:Timer>
        <p>
            <asp:TextBox ID="msg" runat="server" Width="442px"></asp:TextBox>
        </p>
        <asp:Button ID="send" runat="server" Text="Send" Width="442px" OnClick="send_Click" />

    </form>
</body>
</html>
