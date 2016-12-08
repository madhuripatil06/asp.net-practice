<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="App.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Hello Enter Your Name:
        <asp:TextBox ID="TextName" runat="server"></asp:TextBox>
    
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="height: 26px" Text="Click me...." />
        <br />
        <br />
        <br />
        <br />
        <asp:Label ID="Output" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
