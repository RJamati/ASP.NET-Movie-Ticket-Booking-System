<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_login" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Play Movies | Admin Panel</title>
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
            background-color: #fff;
            font: 12px/20px myfont;
            font-weight:normal;
            -webkit-user-select: none;  /* Chrome all / Safari all */
            -moz-user-select: none;     /* Firefox all */
            -ms-user-select: none;      /* IE 10+ */
            -o-user-select: none;
            user-select: none;
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
            margin:0 0 0 10px;
        }
        .head h1 a
        {
            background: url("images/logo1.png" ) no-repeat;
            width: 308px;
            height: 55px;
            position: absolute;
            float:left;
        }
        .main
        {
            width: 980px;
            margin: 0 auto;
        }
        .login_table
        {
            width: 569px;
            height:405px;
            margin:0 auto;
            margin-top:30px;
            padding:100px 0 0 0;            
            background: url("images/login.jpg" ) no-repeat;
        }
        table
        {
            text-align: right;           
            margin: 5px 0 10px 40px;
            padding: 10px;
            width: 425px;
         
            
        }
        .footer
        {
            width: 100%;
            height: 40px;
            background-color: #609FD1;
            color: White;        
            position:absolute;
		    bottom:0;
		    -webkit-user-select: none;  /* Chrome all / Safari all */
            -moz-user-select: none;     /* Firefox all */
            -ms-user-select: none;      /* IE 10+ */
            -o-user-select: none;
            user-select: none;
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
            border: none;
            outline:none;     
            font-weight:normal;            
            font-family:Calibri;
            width:292px;
            background-color:transparent;            
        }

        .username_back
        {
            background: url("images/username.png" ) no-repeat;   
            padding:0 40px 0 31px;
            text-align:left;
            width:334px
        }
        .password
        {                 
            border:none;
            outline:none; 
            font-weight:normal;            
            font-family:Calibri;
            width:292px;                  
            background-color:transparent;  
        }
        .password_back
        {
            background: url("images/password.png" ) no-repeat;                  
            text-align:left;          
            padding:0 0 0 31px;
        }
        .login
        {
            background: url("images/login.png" ) no-repeat;           
            border:none;
            width:95px;
            height:31px;
            margin:0 30px 0 0;
        }
        .label
        {
            margin:0 35px 0 -30px;
        }
        .error
        {
            margin:0 0 0 -30px;
        }
    </style>
    <link rel="shortcut icon" href="images/favicon(1).ico" />
    <script>
        $.fn.extend({
            disableSelection: function () {
                this.each(function () {
                    if (typeof this.onselectstart != 'undefined') {
                        this.onselectstart = function () { return false; };
                    } else if (typeof this.style.MozUserSelect != 'undefined') {
                        this.style.MozUserSelect = 'none';
                    } else {
                        this.onmousedown = function () { return false; };
                    }
                });
            }
        });

        $(document).ready(function () {
            $('label').disableSelection();
        });
        </script>
</head>
<body>
    <form id="form1" runat="server">
   <asp:ScriptManager ID="sp" runat="server"></asp:ScriptManager>
   
    <div class="head">
        
            <h1>
                <a href="../Default.aspx" target="_blank"></a>
            </h1>
        
    </div>
    <div class="main" style="height:415px">
        <div class="login_table">
            <table>
                <tr>
                    <td></td>
                    <td>&nbsp;</td>
                </tr>
                <tr style="vertical-align: top;">                   
                   <td style="padding:5px 10px 0 0px; font-size:16px;">
                        Username
                    </td>
                    <td class="username_back">
                    
                        <asp:TextBox runat="server" CssClass="username" Height="32px" ID="txt_name" border="0" Font-Size="Large"
                            OnTextChanged="txt_name_TextChanged"></asp:TextBox>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_name"
                            ErrorMessage="Please Enter User Id." CssClass="label" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    
                    </td>
                     
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr style="vertical-align: top;">
                   
                  <td style="padding:5px 10px 0 0px; font-size:16px; text-align:left;">
                       Password
                    </td>
                    <td class="password_back">
                    
                        <asp:TextBox runat="server" CssClass="password"  ID="txtPassword" TextMode="Password" Height="32px"
                            Font-Size="Large" OnTextChanged="txtPassword_TextChanged"></asp:TextBox>
                       <br /> &nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="label" runat="server" ControlToValidate="txtPassword"
                            ErrorMessage="Please Enter Password."></asp:RequiredFieldValidator>
                  
                    </td>
                     
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td style="text-align: left;">                        
                        <asp:Button runat="server" CssClass="login" ID="btnSubmit" OnClick="btnSubmit_OnClick" Text="" />
                        <a href="forgot-password.aspx" style="color:Blue; text-decoration:none; font-size:14px;">Can't access your account? </a>  
                    
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
    <div class="footer" style="position:fixed; margin-bottom:0px;">
           
        </div>
     
    </form>
</body>
</html>
