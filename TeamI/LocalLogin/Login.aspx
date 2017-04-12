<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TeamI.Login" %>

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
                            <div class="section" style="padding: 30px; background-color:rgb(255, 255, 255)">
                                <form id="form1" runat="server">
                                    <div class="row">
                                        <h1 style="text-align:center;">MTT Safety Login</h1>
                                        <hr/>

                                    </div>
                                    <div class="row">
                                        <label for="txtUser">User:</label>
                                        <asp:TextBox ID="txtUser" runat="server" Class="form-control"></asp:TextBox>
                                        <span style="color: red;">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUser" ErrorMessage="Username is required"></asp:RequiredFieldValidator></span>
                                    </div>
                                    <div class="row">
                                        <label for="txtPass">Password:</label>
                                        <asp:TextBox ID="txtPass" runat="server" Class="form-control" TextMode="Password"></asp:TextBox>
                                        <span style="color: red;">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPass" ErrorMessage="Password is required"></asp:RequiredFieldValidator></span>

                                    </div>
                                    <div class="row" style="margin-bottom: 15px;">
                                        <asp:Button ID="btnLogin" runat="server" Text="Login" Class="btn btn-success form-control" OnClick="btnLogin_Click" />

                                    </div>
                                    <div class="row">
                                        <asp:Button ID="btnRegister" runat="server" CausesValidation="False" Text="Register" Class="btn btn-warning form-control" OnClick="btnRegister_Click" />
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
