<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PersonalInformation.aspx.cs"
    Inherits="PersonalInformation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Src="~/UserControl/UserLogin.ascx" TagName="UserLogin" TagPrefix="UL" %>
<%@ Register Src="~/UserControl/SignUpNewUser.ascx" TagName="SignUpNewUser" TagPrefix="UL" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Account Setting</title>
    <meta   name="description" content=""/>
 
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
                    runat="server" Text=""></asp:LinkButton>
                <asp:LinkButton ID="lbl4" runat="server" PostBackUrl="~/PersonalInformation.aspx"
                    CssClass="setting_image" Text="  ">&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton>
                <asp:Label ID="lbl3" runat="server" Text="|"></asp:Label>
                <asp:LinkButton runat="server" ID="ALogOut" CssClass="user_setting" OnClick="ALogOut_Click">Sign Out</asp:LinkButton>
                <asp:Label ID="Lbl5" runat="server" Text="  |  "></asp:Label>
                <a href="#" target="_blank" class="twitter"></a>
                <a href="#" target="_blank" class="facebook">
                </a><a href="#b" class="google"></a><a href="#" class="feed"></a>
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
        <div class="clr"></div>
        <div class="navigation">
            <ul class="menu">
               <li class="select"><a href="Default.aspx">Home</a></li>
                <li><a href="Upcoming.aspx">Upcoming Movies</a></li>
                <li><a href="about.aspx">About Us</a></li>
                <li><a href="contact.aspx">Contact Us</a></li>
            </ul>
        </div>
        <div class="clr">
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
                                        runat="server" Text="Change Password" CausesValidation="false" CssClass="profile_link"></asp:LinkButton>
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
                                        runat="server" Text="Personal Information" CausesValidation="false" CssClass="profile_link_active"></asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td style="border: inherit;">
                                    <asp:LinkButton ID="linkbuttonUpdateEmail" PostBackUrl="~/ChangeEmail.aspx" runat="server"
                                        Text="Update Email" CausesValidation="false" CssClass="profile_link"></asp:LinkButton>
                                </td>
                            </tr>
                           <tr>
                        <td style="border:inherit;">
                            <asp:LinkButton ID="lbOrder" Visible="false" PostBackUrl="~/MyOrder.aspx" runat="server" Text="My Order" 
                                CausesValidation="false" CssClass="profile_link"></asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td style="border:inherit;">
                            <asp:LinkButton ID="lbCancelorder" Visible="false" PostBackUrl="~/MyCancelOrder.aspx" runat="server" Text="Cancel Order" 
                                CausesValidation="false" CssClass="profile_link_last"></asp:LinkButton>
                        </td>
                    </tr>
                        </table>
                    </div>
                    <div class="right_sidebar1">
                        <table width="600px" style="float: right">
                            <tr>
                                <td>
                                    <div runat="server" id="DivPersonalInformation">
                                        <table>
                                            <tr>
                                                <h1>
                                                    Personal Information</h1>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    First Name :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TxtFirstName" runat="server" MaxLength="70" CssClass="text_box"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Last Name :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TxtLastName" runat="server" MaxLength="70" CssClass="text_box"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Cell Phone Number :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TxtMobileNumber" runat="server" MaxLength="70" CssClass="text_box"></asp:TextBox>
                                                </td>
                                                <td>
                                                   <asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server"
                                                                ControlToValidate="TxtMobileNumber" ErrorMessage="Enter valid Cell number..." 
                                                                ValidationExpression="^[0-9]{10}">
                                                            </asp:RegularExpressionValidator> 
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Other Phone Number :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TxtLandlineNumber" runat="server" MaxLength="70" CssClass="text_box"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Gender :
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="DDlGender" runat="server" CssClass="drop_down">
                                                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnPersonalDetailSave" runat="server" Text="Save" CssClass="save_button"
                                                        OnClick="btnPersonalDetailSave_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
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
      
        <div class="developer">
         
        </div>
    </div>
    </form>
</body>
</html>
