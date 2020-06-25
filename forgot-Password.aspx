<%@ Page Language="C#" AutoEventWireup="true" CodeFile="forgot-Password.aspx.cs" Inherits="forgot_Password" %>

<%@ Register Src="~/UserControl/UserLogin.ascx" TagName="UserLogin" TagPrefix="UL" %>
<%@ Register Src="~/UserControl/SignUpNewUser.ascx" TagName="SignUpNewUser" TagPrefix="UL" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <title></title>
   <meta   name="description" content=""/>
   
    <link rel="Stylesheet" type="text/css" href="css/style.css" />    
    <link href="css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .container
        {
            background-color: White;
            height: auto;
            border-radius: 10px;
            -webkit-border-radius: 10px;
            -mozila-border-radius: 10px;
            padding: 0 0 20px 0;
        }
    </style>
    <script src="js/jquery.min.js" type="text/javascript"></script>
    <script src="js/jquery-ui.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            SearchText();
        });
        function SearchText() {
            $(".search_box").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "Default.aspx/GetAutoCompleteData",
                        data: "{'username':'" + document.getElementById('TxtSearch').value + "'}",
                        dataType: "json",
                        success: function (data) {
                            response(data.d);
                        },
                        error: function (result) {
                            alert("Error");
                        }
                    });
                }
            });
        }
    </script>    
   <%-- <script type="text/javascript" src="http://code.jquery.com/jquery-1.6.4.min.js"></script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>--%>
    <script src="js/Popup.js" type="text/javascript"></script>
    
    <link rel="shortcut icon" href="images/favicon(1).ico" />
    
</head>
<body>
     <form id="Form1" runat="server">
    <asp:ScriptManager runat="server" ID="SmAcc">
    </asp:ScriptManager>
    
    <div class="main">
        <div style="background-color: Black; height: 33px;">
            <div class="login">
                <a href="contact.aspx" class="login-window">Contact Us</a>
                <asp:Label ID="Lbl" runat="server" Text="  |  "></asp:Label>
                <a href="#login-box1" id="ASignup" class="login-window" runat="server">Sign Up</a>
                <asp:Label ID="Lbl2" runat="server" Text="  |  "></asp:Label>
                <a href="#login-box" id="ALogin" class="login-window" runat="server">Log In</a>
                <asp:LinkButton ID="lblUserSettings" PostBackUrl="~/PersonalInformation.aspx" CssClass="user_setting"
                    runat="server" Text=""></asp:LinkButton>
                <asp:LinkButton ID="lbl4" runat="server" PostBackUrl="~/PersonalInformation.aspx"
                    CssClass="setting_image" Text="  ">&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton>
                <asp:Label ID="lbl3" runat="server" Text="|"></asp:Label>
                <asp:LinkButton runat="server" ID="ALogOut" CssClass="user_setting" OnClick="ALogOut_Click">Sign Out</asp:LinkButton>
                <asp:Label ID="Lbl5" runat="server" Text="  |  "></asp:Label>
                <a href="#" target="_blank" class="twitter"></a>
                <a href="#" target="_blank" class="facebook">
                </a><a href="#" class="google"></a><a href="#" class="feed"></a>
            </div>
            <div id="login-box" class="login-popup">
                <UL:UserLogin ID="ULUserLogin" runat="server" />
            </div>
            <div id="login-box1" class="login-popup">
                <UL:SignUpNewUser ID="ULSignUp" runat="server" />
            </div>
        </div>
        <div class="header">
            <h1>
                <a href="Default.aspx"></a>
            </h1>
            <!--<div class="cart">
                <a href=""><strong>Cart</strong><span>empty</span></a>
            </div>-->
            <form>
            <div style="width: 257px; float: right; padding:10px 0 10px 0">
                <div style="width: 165px; float: left; margin:5px 0 0 0;">
                    <div style="width:135px; float:left;">
                    <asp:TextBox ID="TxtSearch" runat="server" CssClass="search_box"></asp:TextBox>
                    </div>
                    <div style="width:25px; float:left;">
                    <asp:TextBoxWatermarkExtender ID="TBWE2" runat="server" TargetControlID="TxtSearch"
                        WatermarkText="Serch by Keyword" />
                    <asp:Button ID="Button" runat="server" CssClass="search_text1" Text="" OnClick="Button_Click" />
                    </div>
                </div>
                <div style="width: 92px; float: left;">
                    <asp:UpdatePanel runat="server" ID="upCartCount">
                        <ContentTemplate>
                          
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            </form>
        </div>
        <div class="clr"></div>
        <div class="navigation">
            <ul class="menu">
                <li class="select"><a href="Default.aspx">Home</a></li>
                <li><a href="Upcoming.aspx">Upcoming Movies</a></li>
                <li><a href="about.aspx">About Us</a></li>
                <li><a href="contact.aspx">Contact Us</a></li>
            </ul>
        </div>
        <div class="path_view">
            <a href="Default.aspx">Home</a> > <b>Forgot Password</b>
        </div>
        <div class="container">
            <div style="padding:20px 0 0 20px;">
            <h3>Forgot your Password? </h3>
            <p>Enter your Email Address here to receive a link to change password.</p>
            </div>
           <center>
           <table>
           <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
           </tr>
           <tr>
           <td>
          <asp:Label ID="lblEmailAddress" runat="server" Text="Email Address  :  " ></asp:Label>&nbsp;
           </td>
           <td>
            <asp:TextBox ID="TxtEmailAddress" runat="server" CssClass="text_box" ></asp:TextBox>
           </td>
           </tr>
            <tr>
           <td>
         
           </td>
           <td>
            <asp:Button ID="btnSumbit" runat="server" Text="Sumbit" CssClass="send_button"
                   onclick="btnSumbit_Click" />
           </td>
           </tr>
           </table>
           
           </center>
        </div>
        <div class="clr">
        </div>
        <div class="footer">
          
            <div class="clr">
            </div>
        </div>
    
        <div class="developer">
          
        </div>
    </div>
    </form>
</body>
</html>
