<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Lab_1._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td><asp:Button ID="Button1" runat="server" Text="GET" OnClick="Button1_Click" /></td>
            </tr>
            <tr>
                <td><asp:Button ID="Button2" runat="server" Text="POST" OnClick="Button2_Click" /></td>
                <td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Button ID="Button5" runat="server" Text="PUT" OnClick="Button3_Click" /></td>
                <td><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Button ID="Button4" runat="server" Text="Delete" OnClick="Button4_Click" /></td>
            </tr>      
        </table>
    </form>
</body>
</html>