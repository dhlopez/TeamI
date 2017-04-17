<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="TeamI.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: right;
            width: 156px;
        }

        .auto-style2 {
            font-size: xx-large;
        }
        .outer {
    display: table;
    position: absolute;
    height: 100%;
    width: 100%;
}

.middle {
    display: table-cell;
    vertical-align: middle;
}

.inner {
    margin-left: auto;
    margin-right: auto; 
    width: /*whatever width you want*/;
}
body{
    background-image:url("../Images/sparks-login.jpg");
    background-color:white;
      background-repeat: no-repeat;
    background-attachment: fixed;
    background-position: center; 
}
label{
    margin-bottom:10px;
}

    </style>
      <link rel="stylesheet" type="text/css" href="../Content/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="../Content/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="../Content/Custom.css" />
</head>
<body>
    <div class="outer">
        <div class="middle">
            <div class="inner">
                <div class="container">

                    <div class="row">
                        <div class="col-md-6 col-md-offset-3">
                            <div class="section" style="padding: 30px; background-color: rgb(255, 255, 255)">
                                <form id="form1" runat="server">
                                    <div class="row">
                                        <h1 style="text-align: center;">Register New user</h1>
                                        <hr/>
                                    </div>
                                    <div class="row">
                                        <label>Username:</label>
                                        <asp:TextBox ID="txtUser" runat="server" CssClass="form-control"></asp:TextBox>
                                              <span style="color: red;"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUser" ErrorMessage="Username is required" SetFocusOnError="True"></asp:RequiredFieldValidator></span>

                                    </div>
                                    <div class="row">
                                        <label>Password:</label>
                                        <asp:TextBox ID="txtPass" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                              <span style="color: red;"><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPass" ErrorMessage="Password is required" SetFocusOnError="True"></asp:RequiredFieldValidator></span>


                                    </div>
                                    <div class="row">
                                        <label>Confirm Password:</label>
                                        <asp:TextBox ID="txtConfirm" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                              <span style="color: red;"><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtConfirm" ErrorMessage="Must confirm password" SetFocusOnError="True"></asp:RequiredFieldValidator></span>

                                          <span style="color: red;"><asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPass" ControlToValidate="txtConfirm" ErrorMessage="Password does not match" SetFocusOnError="True"></asp:CompareValidator></span>
                                    </div>
                                    <div class="row">
                                        <label>Email:</label>
                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                                              <span style="color: red;"><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEmail" ErrorMessage="Please enter an Email" SetFocusOnError="True"></asp:RequiredFieldValidator></span>

                                    </div>
                                    <div class="row" style="margin-bottom:20px;">
                                        <label>Role:</label>
                                        <asp:DropDownList ID="ddlRoles" runat="server" CssClass="form-control">
                                            <asp:ListItem Value="Technician">Technician</asp:ListItem>
                                            <asp:ListItem Value="Dean">Dean</asp:ListItem>
                                            <asp:ListItem Value="Associate Dean">Associate Dean</asp:ListItem>
                                            <asp:ListItem Value="Administrator">Admin</asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                      <div class="row">
                                         <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn btn-success form-control"  OnClick="btnRegister_Click" />
                                    </div>
                                      <div class="row">
                                              <asp:Button ID="btnLogin" runat="server" CausesValidation="False" CssClass="btn btn-success form-control"  OnClick="btnLogin_Click" Text="Login Page" Visible="False" Width="80px" />

                                    </div>
                                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                                </form>
                            </div>
                        </div>
                    </div>

                </div>

            </div>
        </div>
    </div>
</body>
</html>
