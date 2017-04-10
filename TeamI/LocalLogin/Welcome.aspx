<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="TeamI.Welcome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 126px">
    
        <table style="width:100%;">
            <tr>
                <td>
                    <asp:Label ID="lblWelcome" runat="server" Text="Welcome"></asp:Label>
                </td>
                <td style="text-align: right">
                    <asp:LinkButton ID="lnkLogout" runat="server" Visible="True" OnClick="lnkLogout_Click">Logout</asp:LinkButton>
                     &nbsp;|
                    <asp:LinkButton ID="lnkLogin" runat="server" Visible="True" OnClick="lnkLogin_Click">Login</asp:LinkButton>
                </td>
            </tr>
        </table>
    
        <br />
        <asp:Panel ID="Panel1" runat="server">
        </asp:Panel>
        <asp:Panel ID="pnlProtectedContent" runat="server" Visible="True">
            <asp:LinkButton ID="lnkMovie" runat="server">Movies</asp:LinkButton>
            <br />
            <asp:LinkButton ID="lnkRatings" runat="server">Ratings</asp:LinkButton>
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>
