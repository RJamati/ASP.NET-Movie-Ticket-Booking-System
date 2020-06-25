









<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Recipt.aspx.cs" Inherits="website_Default" %>

<%@ Register Src="~/UserControl/UserLogin.ascx" TagName="UserLogin" TagPrefix="UL" %>
<%@ Register Src="~/UserControl/SignUpNewUser.ascx" TagName="SignUpNewUser" TagPrefix="UL" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en-gb" lang="en-gb" dir="ltr">
<head id="Head1" runat="server">
    <title>Play Movies</title>
    <link rel="Stylesheet" type="text/css" href="css/style.css" />
    <link href="css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.min.js" type="text/javascript"></script>
    <script src="js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="js/Popup.js" type="text/javascript"></script>
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
    <link rel="shortcut icon" href="images/favicon(1).ico" />
    <script type="text/javascript">

        var _gaq = _gaq || [];
        _gaq.push(['_setAccount', 'UA-32713200-2']);
        _gaq.push(['_trackPageview']);

        (function () {
            var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
            ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
        })();

    </script>
    <script type="text/javascript" src="js/kp.js"></script>
    <script type="text/javascript" src="js/jquery.print.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#hrefPrint").click(function () {
                // Print the DIV.
                $("#printdiv").print();
                return (false);
            });
        });
    </script>
</head>
<body>
    <form id="Form1" runat="server">
    <asp:ScriptManager runat="server" ID="SmAcc">
    </asp:ScriptManager>
    <div class="main">
        <div style="background-color: Black; height: 33px;">
            <div class="web_counter">
                <linkbutton id="lnkbtnCityName" runat="server"></linkbutton>
            </div>
            <div class="login">
                <a href="contact.php" class="login-window">Contact Us</a>
                <asp:Label ID="Lbl" runat="server" CssClass="login-lable" Text="  |  "></asp:Label>
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
            <div>
                <div style="height: 50px; float: right; padding: 10px 0 10px 0">
                </div>
            </div>
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
        <div class="clr" style="height: 20px;">
        </div>
        <div style="float: right; margin-top: 10px">
            <a href="#" id="hrefPrint">
                <img src="images/Print.png" /></a></div>
        <div id="printdiv" class="printable">
            <h1 class="head">
                Booked Detail
            </h1>
            <table style="height: 500px; width: 100%; float: left; border: 2px solid #000">
                <tr>
                    <td style="font-size: larger; text-align: center;" colspan="2">
                        <asp:Image Width="300" runat="server" ID="ImgAss"  />
                    </td>
                </tr>
                <tr>
                    <td style="width: 50%; font-size: larger; text-align: right;">
                        Movies Name :
                    </td>
                    <td style="font-size: larger; padding-left: 10px">
                        <asp:Label ID="lblMovieName" runat="server"></asp:Label>
                        <asp:HiddenField ID="hfMoviesId" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 50%; font-size: larger; text-align: right;">
                        TheatresName :
                    </td>
                    <td style="font-size: larger; padding-left: 10px">
                        <asp:Label ID="lblTheatresName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 50%; font-size: larger; text-align: right;">
                        City Name :
                    </td>
                    <td style="font-size: larger; padding-left: 10px">
                        <asp:Label ID="lblCityName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 50%; font-size: larger; text-align: right;">
                        Screen :
                    </td>
                    <td style="font-size: larger; padding-left: 10px">
                        <asp:Label ID="lblScreenName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 50%; font-size: larger; text-align: right;">
                        Class :
                    </td>
                    <td style="font-size: larger; padding-left: 10px">
                        <asp:Label ID="lblClass" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 50%; font-size: larger; text-align: right;">
                        Rate :
                    </td>
                    <td style="font-size: larger; padding-left: 10px">
                        <asp:Label ID="lblRate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 50%; font-size: larger; text-align: right;">
                        Seat No :
                    </td>
                    <td style="font-size: larger; padding-left: 10px">
                        <asp:Label ID="lblSeatNo" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 50%; font-size: larger; text-align: right;">
                        Total Amt :
                    </td>
                    <td style="font-size: larger; padding-left: 10px">
                        <asp:Label ID="lblAmt" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 50%; font-size: larger; text-align: right;">
                        Book Date :
                    </td>
                    <td style="font-size: larger; padding-left: 10px">
                        <asp:Label ID="lblBookDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 50%; font-size: larger; text-align: right;">
                        Book Time :
                    </td>
                    <td style="font-size: larger; padding-left: 10px">
                        <asp:Label ID="lblBookTime" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <div class="clr" style="height: 10px;">
            </div>
            <div runat="server" id="H1">
                <h1 class="head">
                    Booked Food Detail
                </h1>
                <table style="height: 100%; width: 100%; float: left; border: 2px solid #000">
                    <tr>
                        <td>
                            Product Name
                        </td>
                        <td>
                            Rate
                        </td>
                        <td>
                            Qty
                        </td>
                        <td>
                            Price
                        </td>
                    </tr>
                    <tr>
                    <td colspan="4" style="border-bottom:1px solid #000" >
                  
                    </td>
                    </tr>
                    <asp:Repeater ID="rptBookedCatenlist" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblProductName" Text='<%# DataBinder.Eval(Container.DataItem,"ProductName") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblPrise" Text='<%# DataBinder.Eval(Container.DataItem,"Rate") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblQty" Text='<%# DataBinder.Eval(Container.DataItem,"Qty") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblTotal" Text='<%# DataBinder.Eval(Container.DataItem,"Rate") %>'></asp:Label>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                     <tr>
                    <td colspan="4" style="border-bottom:1px solid #000" >
                  
                    </td>
                    </tr>
                    <tr>
                        <td>
                           
                        </td>
                        <td>
                           
                        </td>
                        <td>
                           
                        </td>
                        <td>
                            <asp:Label runat="server" ID="lblTotal111" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="clr">
        </div>
        <div class="disclaimer">
        </div>
        <div class="developer">
            <div class="copy_rght">
                <p>
                    &copy; Copyright 2015 Play Movies</p>
            </div>
            <div class="softyoug_info">
                <p>
                    <a href="" title="Website Design &amp; Developed">Website Design &amp; Developed</a>
                    : <a href="" title="Website development, Software Development, SEO Service, ERP Development, Creative Design">
                    </a>
                </p>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
