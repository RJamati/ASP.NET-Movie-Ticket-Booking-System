<%@ Page Language="C#" AutoEventWireup="true" CodeFile="contact.aspx.cs" Inherits="website_contact" %>

<%@ Register Src="~/UserControl/UserLogin.ascx" TagName="UserLogin" TagPrefix="UL" %>
<%@ Register Src="~/UserControl/SignUpNewUser.ascx" TagName="SignUpNewUser" TagPrefix="UL" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE aspx PUBLIC "-//W3C//DTD Xaspx 1.0 Transitional//EN" "http://www.w3.org/TR/xaspx1/DTD/xaspx1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Contact Us</title>
    <link rel="Stylesheet" type="text/css" href="css/style.css" />
    <link href="css/jquery-ui.css" rel="stylesheet" type="text/css" />
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
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>
    --%>
    <script src="js/Popup.js" type="text/javascript"></script>
    <link rel="shortcut icon" href="images/favicon(1).ico" />
    <style type="text/css">
        .style2
        {
            width: 268px;
            height: 30px;
        }
        .style3
        {
            width: 268px;
            height: 33px;
        }
        .style4
        {
            width: 268px;
            height: 34px;
        }
        .select
        {}
    </style>
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
                <a href="#" target="_blank" class="twitter"></a><a href="#" target="_blank" class="facebook">
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
            <div style="height: 50px; float: right; padding: 10px 0 10px 0">
            </div>
        </div>
        <div class="clr">
        </div>
        <div class="navigation">
            <ul class="menu">
                <li><a href="Default.aspx">Home</a></li>
                <li><a href="Upcoming.aspx">Upcoming Movies</a></li>
                <li><a href="about.aspx">About Us</a></li>
                <li class="select"><a href="#">Contact Us</a></li>
            </ul>
        </div>
        <div class="path_view">
            <a href="Default.aspx">Home</a> > <b>Contact Us</b>
        </div>
        <div class="container">
            <div style="padding: 0px 10px 0 0px; width: 950px;">
                <div class="reach_us">
                    <h1 style="color: #53C4E2;">
                        City &amp; Threatre</h1>
                    <hr style="margin: 3px 0 0 0; height: 2px; background: #53C4E2; width: 280px;" />
                    <br />
                    <table>
                        <tr>
                            <td class="style2">
                                City
                            </td>
                        </tr>
                        <tr>
                            <td class="style2">
                                <asp:DropDownList ID="ddlCity" runat="server" CssClass="select" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged"
                                    AutoPostBack="True" Height="38px" Width="260px">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="ddlCity"
                                    InitialValue="0" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style3">
                                Theatre
                            </td>
                        </tr>
                        <tr>
                            <td class="style4">
                                <asp:DropDownList ID="ddltheatre" runat="server" CssClass="select" OnSelectedIndexChanged="ddltheatre_SelectedIndexChanged"
                                    AutoPostBack="True" Height="21px" Width="260px">
                                    <asp:ListItem Selected="True" Text ="Selected" Value ="0" ></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddltheatre"
                                    InitialValue="0" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="map">
                    <h1 style="color: #89C53F;">
                        Map
                    </h1>
                    <hr style="margin: 3px 0 0 0; height: 2px; background: #89C53F; width: 580px;" />
                    <iframe class="location_map" frameborder="0" scrolling="no" id="StMap" marginheight="0"
                        marginwidth="0" src="" runat="server"></iframe>
                </div>
                <div class="clr">
                </div>
            </div>
        </div>
        <div class="footer">
        </div>
        <div class="developer">
        </div>
    </div>
    </form>
</body>
</html>
