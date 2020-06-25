<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Src="~/UserControl/UserLogin.ascx" TagName="UserLogin" TagPrefix="UL" %>
<%@ Register Src="~/UserControl/SignUpNewUser.ascx" TagName="SignUpNewUser" TagPrefix="UL" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Gadgets-Plus | Account Setting</title>
    <meta name="description" content="" />

    <link rel="Stylesheet" type="text/css" href="css/style.css" />
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
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>
    <link rel="shortcut icon" href="images/favicon(1).ico" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
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
                    CausesValidation="false" runat="server" Text=""></asp:LinkButton>
                <asp:LinkButton ID="lbl4" runat="server" PostBackUrl="~/PersonalInformation.aspx"
                    CausesValidation="false" CssClass="setting_image" Text="  ">&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton>
                <asp:Label ID="lbl3" runat="server" Text="|"></asp:Label>
                <asp:LinkButton runat="server" ID="ALogOut" CssClass="user_setting" OnClick="ALogOut_Click"
                    CausesValidation="false">Sign Out</asp:LinkButton>
                <asp:Label ID="Lbl5" runat="server" Text="  |  "></asp:Label>
                <a href="https://twitter.com/gadgetsplus09" target="_blank" class="twitter"></a>
                <a href="https://www.facebook.com/gadgets.plus.12" target="_blank" class="facebook">
                </a><a href="https://plus.google.com/u/0/101262102881283188820/posts/p/pub" class="google"></a><a href="http://www.gadgets-plus.ca/rss.xml" class="feed">
                </a>
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
            <div style="width: 257px; float: right; padding: 10px 0 10px 0">
                <div style="width: 165px; float: left; margin: 5px 0 0 0;">
                    <div style="width: 135px; float: left;">
                        <asp:TextBox ID="TxtSearch" runat="server" CssClass="search_box"></asp:TextBox>
                    </div>
                    <div style="width: 25px; float: left;">
                        <asp:TextBoxWatermarkExtender ID="TBWE2" runat="server" TargetControlID="TxtSearch"
                            WatermarkText="Serch by Keyword" />
                        <asp:Button ID="Button" runat="server" CssClass="search_text1" Text="" OnClick="Button_Click" />
                    </div>
                </div>
                <div style="width: 92px; float: left;">
                    <asp:UpdatePanel runat="server" ID="upCartCount">
                        <ContentTemplate>
                            <a href="MyCart.aspx" class="cart-window">(<asp:Label runat="server" ID="lblCartItemCount"></asp:Label>)</a>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            </form>
        </div>
        <div class="clr">
        </div>
        <div class="navigation">
            <ul class="menu">
                <li class="select"><a href="Default.aspx">Home</a></li>
                <li><a href="Upcoming.aspx">Upcoming Movies</a></li>
                <li><a href="about.aspx">About Us</a></li>
                <li><a href="contact.aspx">Contact Us</a></li>
            </ul>
        </div>
        <div class="container">
            <div class="my_account">
                <div>
                    <div class="left_sidebar">
                        <h3>
                            My Account</h3>
                        <table width="200px" style="float: left">
                            <tr>
                                <td>
                                    <asp:LinkButton ID="linkbuttonChangePassword" PostBackUrl="~/ChangePassword.aspx"
                                        runat="server" Text="Change Password" CausesValidation="false" CssClass="profile_link_active"></asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                         <asp:LinkButton ID="linkbuttonAddresses" runat="server" Text="Booking List" CausesValidation="false" PostBackUrl="~/Bookinglist.aspx"
                                        CssClass="profile_link"></asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="linkbuttonPersonalInformation" PostBackUrl="~/PersonalInformation.aspx"
                                        runat="server" Text="Personal Information" CausesValidation="false" CssClass="profile_link"></asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td style="border: inherit;">
                                    <asp:LinkButton ID="linkbuttonUpdateEmail" PostBackUrl="~/ChangeEmail.aspx" runat="server"
                                        Text="Update Email" CausesValidation="false" CssClass="profile_link"></asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td style="border: inherit;">
                                    <asp:LinkButton ID="lbOrder" Visible="false" PostBackUrl="~/MyOrder.aspx" runat="server"
                                        Text="My Order" CausesValidation="false" CssClass="profile_link"></asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td style="border: inherit;">
                                    <asp:LinkButton ID="lbCancelorder" Visible="false" PostBackUrl="~/MyCancelOrder.aspx"
                                        runat="server" Text="Cancel Order" CausesValidation="false" CssClass="profile_link_last"></asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="right_sidebar1">
                        <table width="600px" style="float: right">
                            <tr>
                                <h1>
                                    Change Password</h1>
                            </tr>
                             <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                            <tr>
                                <td>
                                    Old Password :
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtOldPassword" runat="server" CssClass="text_box" TextMode="Password"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtOldPassword"
                                        EnableClientScript="true" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    New Password :
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="TxtNewPassword" CssClass="text_box" TextMode="Password"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtNewPassword"
                                        EnableClientScript="true" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Retype Password :
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="TxtRepeat" CssClass="text_box" TextMode="Password"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtRepeat"
                                        EnableClientScript="true" ErrorMessage="*"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="compval" Display="dynamic" ControlToValidate="TxtNewPassword"
                                        ControlToCompare="TxtRepeat" ForeColor="red" Type="String" Text="Password And Repeat Password Not Match..."
                                        EnableClientScript="true" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:Button ID="BtnChangePassword" runat="server" Text="Change Password" CssClass="save_button"
                                        OnClick="BtnChangePassword_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <div class="clr">
            </div>
        </div>
        <div class="clr">
        </div>
        <div class="footer">
            <div class="foot_cont">
                <h1>
                    Our Product
                </h1>
                <ul>
                    <li><a href="apple-products.aspx">Apple</a></li>
                    <li><a href="blackberry-products.aspx">Blackberry</a></li>
                    <li><a href="nokia-products.aspx">Nokia</a></li>
                    <li><a href="samsung-products.aspx">Samsung</a></li>
                    <li><a href="sony-Ericsson-products.aspx">Sony Ericsson</a></li>
                    <li><a href="motorola-products.aspx">Motorola</a></li>
                </ul>
            </div>
            <div class="foot_cont">
                <h1>
                    Our Offers
                </h1>
                <ul>
                    <li><a href="DealofTheDay.aspx">Deal of the Day</a></li>
                    <li><a href="PromotionalOffer.aspx">Promotional offers</a></li>
                    <li><a href="HotProducts.aspx">Hot product</a></li>
                </ul>
            </div>
            <div class="foot_cont">
                <h1>
                    Repair &amp; Unlock
                </h1>
                <ul>
                    <li><a href="unlocked-cell-phones-toronto.aspx">Unlock Cell Phones</a></li>
                    <li><a href="cell-phone-repair-toronto.aspx">Repair Cell Phones</a></li>
                    <li><a href="unlock-blackberry-phone.aspx" title="Unlock Blackberry Phone">Unlock Blackberry</a></li>
                    <li><a href="iPhone-unlock-toronto.aspx" title="iphone Unlock Toronto">iphone Unlock</a></li>
                    <li><a href="blackberry-repair-toronto.aspx" title="Blackberry Repair Toronto">Blackberry Repair</a></li>
                    <li><a href="iphone-repair-toronto.aspx" title="iphone Repair Toronto">iphone Repair</a></li>
                </ul>
            </div>
            <div class="foot_cont">
                <h1>
                    Contact Us
                </h1>
                <p>
                    Gadgets Plus,<br />
                    49 Orfus Rd, North York,<br />
                    Canada.<br />
                    ZIP - M6A 1L7.
                </p>
                <h2>
                    <a href="contact.aspx">contact@gadgets-plus.ca</a></h2>
            </div>
            <div class="clr">
            </div>
        </div>
        <div class="disclaimer">
           <b> Disclaimer : </b>&nbsp;We can not guarantee that the information on this page is 100% correct.
            Whilst every effort has been made to ensure that the information on this site is
            as accurate as possible, GADGETS-PLUS.ca  cannot be held responsible
            for any inaccuracies or consequences arising out of the use of this site.
        </div>
        <div class="disclaimer" style="margin:9px 0px 0px 0px;">
            GADGETS-PLUS is not affiliated with any product manufacturer. Products carry manufacturer's
            warranty only except the 15 Days GADGETS-PLUS DOA policy. Logos, trademarks, names,
            images, etc. are property of their respective companies. GADGETS-PLUS is not responsible
            for typographical errors. All prices, availability, offers are subject to change
            at anytime without further notice.
        </div>
        <div class="developer">
            <div class="copy_rght">
                <p>
                    &copy; Copyright 2013 GADGETS PLUS</p>
            </div>
            <div class="softyoug_info">
                <p>
                    <a href="http://softyoug.ca/service/website-development.html" title="Website Design &amp; Developed">
                        Website Design &amp; Developed</a> : <a href="http://www.softyoug.com" title="Website development, Software Development, SEO Service, ERP Development, Creative Design">
                            PlayMovieskp Solutions</a></p>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
