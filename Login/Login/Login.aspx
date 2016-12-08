<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Login.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-left: 240px">
            <br />
            <asp:Label ID="Label1" runat="server" Text="User Name: "></asp:Label>
            <asp:Button ID="Button1" runat="server" Text="Button" />
            <br />
            <br />
            <br />
            Pass word:
            <asp:Button ID="Button2" runat="server" Text="Button" />
            <br />
            
            
            br /><br />
&nbsp;<asp:Button ID="Button3" runat="server" OnClick="Button3_Click1" Text="Exit" Width="79px" />
            <asp:Button ID="Button4" runat="server" Text="Login" Width="70px" />
            <br />
&nbsp;<br />
        </div>
    <div style="margin-left: 240px">
    
    </div>
    </form>
</body>
</html>
