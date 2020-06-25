<%@ Page Language="C#" AutoEventWireup="true" CodeFile="forgot-password.aspx.cs"
    Inherits="Admin_forgot_password" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forget Password</title>
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
            background-color: #F2F2F5;
            font: 12px/20px myfont;
            font-weight: normal;
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
            width: 550px;
            height: 381px;
            margin: 0 auto;
            margin-top: 30px;
            padding: 20px 0 0 0;
        }
        table
        {
            text-align: right;
            margin: 20px 0 10px 40px;
            padding: 10px;
            width: 425px;
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
        .username
        {
            background: url("images/username.png" ) no-repeat;
            border: none;
            padding: 0 0 0 30px;
            font-weight: normal;
            font-family: Calibri;
        }
        .password
        {
            background: url("images/password.png" ) no-repeat;
            border: none;
            padding: 0 0 0 30px;
            font-weight: normal;
            font-family: Calibri;
        }
        .login
        {
            background: url("images/login.png" ) no-repeat;
            border: none;
            width: 95px;
            height: 31px;
            margin: 0 30px 0 0;
        }
        .label
        {
            margin-right: 35px;
        }
        .msg_head
        {
            cursor: pointer;
            position: relative;
            color: Black;
            margin: 2px;
            font-size: 14px;
            -moz-border-radius: 5px;
            border-radius: 5px;
            height: 12px;
            width: 413px;
            margin: 15px 0 0 0;
        }
        .msg_body
        {
            margin: 15px 0 0 0;
            padding: 5px 5px 5px 5px;
            background-color: #fff;
            color: #000000;
            text-align: justify;
            font-size: 12px;
            border: 1px solid gray;
            border-radius: 5px;
            -moz-border-radius: 5px;
            -webkit-border-radius: 5px;
            width: 465px;
        }
        .save_button
        {
            color: #ffffff;
            display: inline;
            padding: 4px 10px;
            cursor: pointer;
            margin:20px 0 0 0;
            -webkit-border-radius: 2px;
            -moz-border-radius: 2px;
            border-radius: 2px;
            border-left: 1px solid #0055cc;
            border-right: 1px solid #0055cc;
            border-top: 1px solid #0055cc;
            border-bottom: 1px solid #003580;
            background-image: linear-gradient(top, #0088cc, #0055cc);
            background-image: -o-linear-gradient(top, #0088cc, #0055cc);
            background-image: -ms-linear-gradient(top, #0088cc, #0055cc);
            background-image: -moz-linear-gradient(top, #0088cc, #0055cc);
            background-image: -webkit-linear-gradient(top, #0088cc, #0055cc);
            background-color: #0074cc;
            background-repeat: repeat-x;
        }
    </style>
    <script type="text/javascript" src="js/jquery-1.4.2.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            //hide the all of the element with class msg_body
            $(".msg_body").hide();
            //toggle the componenet with class msg_body
            $(".msg_head").click(function () {
                $(this).next(".msg_body").slideToggle(550);
            });
        });
    </script>
    <link rel="shortcut icon" href="images/favicon(1).ico" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sp" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="Upanel" runat="server">
    <ContentTemplate >
    <div class="head">
        <div class="main">
            <h1>
                <a href="../Default.aspx"></a>
            </h1>
        </div>
    </div>
    <div class="main" style="height: 415px">
        <div class="login_table">
            <h2>Having trouble signing in?</h2>
            <p style="font: 16px;" class="msg_head">
                <asp:RadioButton runat="server" ID="RdbtnPassword" GroupName="a" />
                I don't know my password</p>
            <div class="msg_body">
             Email Address:-     <asp:TextBox ID="TxtEmailAddressForPassword" runat="server"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="TxtEmailAddressForPassword"
                            ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Enter Valid Email Address..."
                            EnableClientScript="true" runat="server" />
            </div>
            <p style="font: 16px;" class="msg_head">
                <asp:RadioButton runat="server" ID="RdbtnUserName" GroupName="a" />
                I don't know my username</p>
            <div class="msg_body">
              Email Address:-     <asp:TextBox ID="TxtEmailAddressForUserName" runat="server"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="TxtEmailAddressForUserName"
                            ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Enter Valid Email Address..."
                            EnableClientScript="true" runat="server" />
            </div>
            <p style="font: 16px;" class="msg_head">
                <asp:RadioButton runat="server" ID="RdbtnSignin" GroupName="a" />
                I'm having other problems signing in</p>
            <div class="msg_body">
                Email Address:-     <asp:TextBox ID="TxtEmailAddressForSignin" runat="server"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="TxtEmailAddressForSignin"
                            ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Enter Valid Email Address..."
                            EnableClientScript="true" runat="server" />
            </div>
            <div>
                <asp:Button runat="server" ID="ContBtn" Text="Continue" CssClass="save_button" 
                    onclick="ContBtn_Click" />
            </div>
        </div>
    </div>
    <div class="footer" style="position: fixed; margin-bottom: 0px;">
     
    </div>
      </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
