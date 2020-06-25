<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="Admin_login" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Pannel</title>
    <style type="text/css">
        *
        {
            margin: 0;
            padding: 0;
        }
        @font-face
        {
            font-family: myfont;
            src: url( 'fonts/Coda-Regular.eot' ); /* IE */
            src: local( 'Coda-Regular' ), url( 'fonts/Coda-Regular.ttf' ) format( 'truetype' ); /* OTHER */
        }
        h2
        {
            font-size: 24px;
        }
        body
        {
            width: 100%;
            background-color: #20242B;
            font: 12px/20px myfont;
        }
        .head
        {
            padding: 10px 0;
            background-color: #F2F2F5;
        }
        .head h1
        {
            width: 308px;
            height: 58px;
        }
        .head h1 a
        {
            background: url("images/logo1.png" ) no-repeat;
            width: 308px;
            height: 55px;
            position: absolute;
        }
        .main
        {
            width: 980px;
            margin: 0 auto;
        }
        .login_table
        {
            width: 600px;
            margin: 160px auto;
        }
        table
        {
            text-align: right;
            border: 1px solid #ebe8e8;
            background: rgb(238, 238, 238);
            margin: 0 0 10px 60px;
            padding: 10px;
            width: 419px;
            -moz-border-radius: 16px 16px 16px 16px;
            border-radius: 16px 16px 16px 16px;
            box-shadow: 4px 4px 5px #888888;
        }
        .footer
        {
            width: 100%;
            height: 40px;
            background-color: #609FD1;
            color: White;
        }
        .footer p
        {
            float: right;
            padding: 10px;
        }
        .footer a
        {
            color: White;
            text-decoration: none;
        }
        .style1
        {
            height: 23px;
        }
        .copy_rght
        {
            float: left;
            margin-left: 80px;
        }
        .softyoug_info
        {
            float: right;
        }
    </style>
    <link rel="shortcut icon" href="images/favicon(1).ico" />
</head>
<body>
    <form id="form1" runat="server">
      <asp:ScriptManager ID="sp" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="Upanel" runat="server">
    <ContentTemplate >
   <div class="header">
                <div class="links">
                    <a href="../Default.aspx"></a>
                </div>
                <div class="logout_btn">
                    <h3>
                        Logout</h3>
                    <a href="Default.aspx" class="logout"></a>
                </div>
                <div class="clr">
                </div>
            </div>
    <div class="main">
        <div class="login_table">
            <table>
                <tr>
                    <td rowspan="4">
                        <div style="background-image: url('images/lock_256.png'); height: 180px; width: 180px;">
                        </div>
                    </td>
                    <td rowspan="4">
                    </td>
                    <td colspan="3">
                        <h2 style="text-align: center;">
                            &nbsp;Quick Login
                        </h2>
                        <br />
                    </td>
                </tr>
                <tr style="vertical-align: top;">
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        User Id:
                    </td>
                    <td>
                        <%-- <asp:UpdatePanel ID="pnlTasks" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                        <ContentTemplate>--%>
                        <asp:TextBox runat="server" Width="170px" ID="txt_name" Height="28px" Font-Size="Large"
                            OnTextChanged="txt_name_TextChanged"></asp:TextBox>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_name"
                            ErrorMessage="Please Enter User Id." SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <%-- </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="txt_name" />
                        </Triggers>
                    </asp:UpdatePanel>--%>
                    </td>
                </tr>
                <tr style="vertical-align: top;">
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        Password:
                    </td>
                    <td>
                        <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                        <ContentTemplate>--%>
                        <asp:TextBox runat="server" Width="170px" ID="txtPassword" TextMode="Password" Height="28px"
                            Font-Size="Large" OnTextChanged="txtPassword_TextChanged"></asp:TextBox>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
                            ErrorMessage="Please Enter Password."></asp:RequiredFieldValidator>
                        <%-- </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="txtPassword" />
                        </Triggers>
                    </asp:UpdatePanel>--%>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td colspan="2" style="text-align: center;">
                        <asp:Button runat="server" ID="btnSubmit" OnClick="btnSubmit_OnClick" Text="Login" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center;" class="style1">
                        <asp:Label runat="server" ID="lblError" Font-Bold="true" Font-Size="16px" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="footer">
           
        </div>
         </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
