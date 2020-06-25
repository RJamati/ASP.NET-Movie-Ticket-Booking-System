<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MenuContral.ascx.cs" Inherits="UserControl_Menu" %>
<%@ Register src="~/UserControl/UserLogin.ascx" TagName="UserLogin" TagPrefix="UL" %>
<%@ Register src="~/UserControl/SignUpNewUser.ascx" TagName="SignUpNewUser" TagPrefix="UL" %>
    <link rel="Stylesheet" type="text/css" href="../css/style.css" />
    <!--- Slider --->
    <script type="text/javascript" src="../js/jquery-1.3.js"></script>
    <script type="text/javascript" src="../js/jquery.cycle.all.js"></script>
    <link href="../css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../js/Popup.js" type="text/javascript"></script>
    <script src="../js/jquery.min.js" type="text/javascript"></script>
<script src="../js/Popup.js" type="text/javascript"></script>
    <script src="../js/jquery-ui.min.js" type="text/javascript"></script>
    <link rel="shortcut icon" href="../images/favicon(1).ico" />

    <div style="background-color: Black; height: 33px;">
        <div class="login">
            24x7 Customer Support - <a href="../contact.aspx" class="login-window">Contact Us</a> &nbsp;|&nbsp; <a href="../Default.aspx" class="login-window">Home</a> 
            &nbsp;|&nbsp; <a href="../about.aspx" class="login-window">About Us</a> <asp:Label ID="Lbl" runat="server" Text="  |  "></asp:Label><a href="#login-box" id="ALogin" class="login-window" runat="server" >Login</a>  <asp:Label ID="Lbl2" runat="server" Text="  |  "></asp:Label> <a href="#login-box1"
                id="ASignup" class="login-window" runat="server">Signup</a>
                <div id="dropdown" class="ddmenu" runat="server">
                User Settings &nbsp; <img src="../images/down_arrow.png" />
                <ul>
                    <li><a href="../PersonalInformation.aspx" onclick="location.href='../PersonalInformation.aspx';">My Profile</a></li>
                    <li><a href="#">Friend Requests</a></li>
                    <li><a href="../PersonalInformation.aspx">Account Settings</a></li>
                    <li><a href="#">Support</a></li>
                    <li><a href="#">Log Out</a></li>
                </ul>

            </div>
            <script type="text/javascript">
                $("#dropdown").on("click", function (e) {
                    e.preventDefault();

                    if ($(this).hasClass("open")) {
                        $(this).removeClass("open");
                        $(this).children("ul").slideUp("fast");
                    } else {
                        $(this).addClass("open");
                        $(this).children("ul").slideDown("fast");
                    }
                });
</script>
        </div>
        <div id="login-box" class="login-popup">
        <UL:UserLogin id="ULUserLogin" runat="server" />
        </div>
        <div id="login-box1" class="login-popup">
         <UL:SignUpNewUser id="ULSignUp" runat="server" />
         </div>
    </div>
      