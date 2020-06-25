<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Upcoming.aspx.cs" Inherits="website_Default" %>

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
    <style type="text/css">
        .modalBackground
        {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }
        .modalPopup
        {
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 450px;
            height: 50px;
        }
    </style>
</head>
<body>
    <form id="Form1" runat="server">
    <asp:ScriptManager runat="server" ID="SmAcc">
    </asp:ScriptManager>
    <div class="main">
        <asp:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID="lnkbtnCityName"
            CancelControlID="lBtnCity" BackgroundCssClass="modalBackground">
        </asp:ModalPopupExtender>
        <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" align="center" Style="display: none;">
            <asp:DropDownList ID="ddlCity" runat="server" CssClass="selectkp" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged"
                AutoPostBack="true">
            </asp:DropDownList>
            <asp:LinkButton runat="server" ID="lBtnCity" Text="Select" Style="display: none"
                OnClick="lBtnCity_Click"></asp:LinkButton>
        </asp:Panel>
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
                <li ><a href="Default.aspx">Home</a></li>
                <li class="select"><a href="Upcoming.aspx">Upcoming Movies</a></li>
                <li><a href="about.aspx">About Us</a></li>
                <li><a href="contact.aspx">Contact Us</a></li>
            </ul>
        </div>
        <div class="flash">
            <iframe src="slider/index.aspx" height="450px" width="960px" frameborder="0" scrolling="auto"
                marginheight="0" marginwidth="0" style="border: none;"></iframe>
        </div>
        <div class="clr" style="height: 20px;">
        </div>
        <asp:DataList ID="DlForDisplayAccessoricesHeader" runat="server" OnItemDataBound="DlForDisplayAccessoricesHeader_ItemDataBound">
            <ItemTemplate>
                <%--<a href="GadgetProductFilter.aspx?Id=<%# DataBinder.Eval(Container.DataItem,"TheatresNameId") %> &Name= <%# DataBinder.Eval(Container.DataItem,"TheatresName") %>">--%>
                <a href="#">
                    <div class="feature">
                        <h3>
                            <asp:Label runat="server" ID="lblDLAssCompanyProductNameId" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem,"TheatresNameId") %>'></asp:Label>
                            <asp:Label runat="server" ID="lblDLCompanyProductName" Text='<%# DataBinder.Eval(Container.DataItem,"TheatresName") %>'></asp:Label>
                        </h3>
                    </div>
                </a>
                <div class="products">
                    <asp:Repeater runat="server" ID="RptAccessories">
                        <ItemTemplate>
                            <div class="mobile_images effect8">
                                <asp:ImageButton CssClass="img" 
                                    ID="ImageButton1" runat="server" ImageUrl='<%# String.Format("~/Admin/MovieImage/{0}", DataBinder.Eval(Container.DataItem, "MoviesImage")) %>'
                                    alt='<%# DataBinder.Eval(Container.DataItem,"MoviesName") %>' />
                                <p>
                                    <b>
                                        <asp:LinkButton runat="server" 
                                            ID="ProductName" Text='<%# DataBinder.Eval(Container.DataItem,"MoviesName") %>' /></b>
                                    <b>
                                    <br />
                                        <asp:LinkButton runat="server" 
                                            ID="LinkButton1" Text='<%# DataBinder.Eval(Container.DataItem,"ScreenName") %>' /></b>
                                    <br />
                                  <br />
                                    
                                    <asp:Label runat="server" ID="Label1" Text="Paltium Seat Rs.  " Visible='<%# (DataBinder.Eval(Container.DataItem, "PaltiumRate").ToString() != "0") %>'></asp:Label>
                                    <asp:Label runat="server" ID="Label2" Text='<%# DataBinder.Eval(Container.DataItem,"PaltiumRate") %>'
                                        Visible='<%# (DataBinder.Eval(Container.DataItem, "PaltiumRate").ToString() != "0") %>'></asp:Label>
                                    <br />
                                    <asp:Label runat="server" ID="Label3" Text="Gold Seat Rs.  " Visible='<%# (DataBinder.Eval(Container.DataItem, "GoldRate").ToString() != "0") %>'></asp:Label>
                                    <asp:Label runat="server" ID="Label4" Text='<%# DataBinder.Eval(Container.DataItem,"GoldRate") %>'
                                        Visible='<%# (DataBinder.Eval(Container.DataItem, "GoldRate").ToString() != "0") %>'></asp:Label>
                                    <br />
                                    <asp:Label runat="server" ID="Label5" Text="Silver Seat Rs.  " Visible='<%# (DataBinder.Eval(Container.DataItem, "SilverRate").ToString() != "0") %>'></asp:Label>
                                    <asp:Label runat="server" ID="Label6" Text='<%# DataBinder.Eval(Container.DataItem,"SilverRate") %>'
                                        Visible='<%# (DataBinder.Eval(Container.DataItem, "SilverRate").ToString() != "0") %>'></asp:Label>
                                </p>
                                <h3>
                                    <%-- $<asp:Label runat="server" ID="Label1" Text='<%# DataBinder.Eval(Container.DataItem,"Prices") %>'></asp:Label>--%>
                                    <%--<asp:Label runat="server" ID="Label3" Text="$" Visible='<%# (DataBinder.Eval(Container.DataItem, "Prices").ToString() != "0.00") %>'></asp:Label>
                                    <asp:Label runat="server" ID="Label2" CssClass="product_head_name" Text='<%# DataBinder.Eval(Container.DataItem,"Prices") %>'
                                        Visible='<%# (DataBinder.Eval(Container.DataItem, "Prices").ToString() != "0.00") %>'></asp:Label>
                                    <asp:Label runat="server" ID="Label4" CssClass="product_head_name" Text="Call For price"
                                        Visible='<%# (DataBinder.Eval(Container.DataItem, "Prices").ToString() == "0.00") %>'></asp:Label>--%>
                                </h3>
                                <a id="A4" style="display: none" href='<%# String.Format("Booking.aspx?ID={0}", DataBinder.Eval(Container.DataItem, "MoviesId")) %>'
                                    runat="server" class="view_product">Book Now</a>
                                <%-- visible='<%# (DataBinder.Eval(Container.DataItem, "Prices").ToString() != "0.00") %>'>--%>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <div class="clr">
                    </div>
                </div>
            </ItemTemplate>
        </asp:DataList>
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
