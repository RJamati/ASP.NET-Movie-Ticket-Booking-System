<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Booking.aspx.cs" Inherits="ProductAss" %>

<%@ Register Src="~/UserControl/UserLogin.ascx" TagName="UserLogin" TagPrefix="UL" %>
<%@ Register Src="~/UserControl/SignUpNewUser.ascx" TagName="SignUpNewUser" TagPrefix="UL" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Play Movies</title>
    <link rel="Stylesheet" type="text/css" href="css/style.css" />
    <!-- demo only -->
    <link href="http://fonts.googleapis.com/css?family=Merienda+One" rel="stylesheet">
    <link href="css/anythingzoomer.css" rel="stylesheet" type="text/css" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8/jquery.min.js"></script>
    <link rel="shortcut icon" href="images/favicon(1).ico" />
    <script src="js/Popup.js" type="text/javascript"></script>
    <link href="css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.min.js" type="text/javascript"></script>
    <script src="js/jquery-ui.min.js" type="text/javascript"></script>
    <style type="text/css">
        .login-popup .btn_close
        {
            margin: -28px 0 0 290px;
        }
    </style>
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
            width: 750px;
            height: 350px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
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
            <h1 style="height: 70px;">
                <a href="Default.aspx"></a>
            </h1>
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
        <div class="path_view">
            <a href="Default.aspx">Home</a> > <b>
                <asp:Label runat="server" ID="lblHomeHeader"></asp:Label></b>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <center>
                    <div runat="server" id="DivAssessoriesMain" style="height: 100%; width: 300px; float: left;"
                        class="client_table">
                        <asp:Image Width="300" runat="server" ID="ImgAss" />
                   
                        <div class="clr">
                        </div>
                        <br />
                        <table style="height: 100%; width: 300px; float: left; border: 2px solid #000">
                            <tr>
                                <td style="width: 130px; font-size: larger; text-align: right;">
                                    Movies Name :
                                </td>
                                <td style="font-size: larger; padding-left: 10px">
                                    <asp:Label ID="lblMovieName" runat="server"></asp:Label>
                                    <asp:HiddenField ID="hfMoviesId" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 130px; font-size: larger; text-align: right;">
                                    Screen :
                                </td>
                                <td style="font-size: larger; padding-left: 10px">
                                    <asp:Label ID="lblScreenName" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 130px; font-size: larger; text-align: right;">
                                    Class :
                                </td>
                                <td style="font-size: larger; padding-left: 10px">
                                    <asp:Label ID="lblClass" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 130px; font-size: larger; text-align: right;">
                                    Rate :
                                </td>
                                <td style="font-size: larger; padding-left: 10px">
                                    <asp:Label ID="lblRate" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <div class="clr">
                        </div>
                        <h1 class="head" style="display:none;">
                           
                             <asp:LinkButton ID="lnkCateen" runat="server" Text="Click to Booked Cateen"  CssClass="buttonkp"></asp:LinkButton>
                        </h1>
                        <table style="height: 100%; width: 300px; float: left; border: 2px solid #000; display:none;">
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
                                            <asp:Label runat="server" ID="lblTotal" Text='<%# DataBinder.Eval(Container.DataItem,"Total") %>'></asp:Label>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                </center>
                <div runat="server" id="Div1" style="height: 100%; width: 600px; margin-left: 50px;
                    float: left;" class="client_table">
                    <center>
                        <asp:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID="lnkCateen" 
                            CancelControlID="lbCross" BackgroundCssClass="modalBackground">
                        </asp:ModalPopupExtender>
                        <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" align="center" Style="display: none;">
                           
                                <asp:LinkButton runat="server" ID="lbCross" Text="X" Style="float:right; margin-right:10px;"></asp:LinkButton>
                            <div class="clr">
                                </div>
                            <div class="products">
                                <asp:Repeater runat="server" ID="RptCateen" OnItemCommand="RptCateen_ItemCommand">
                                    <ItemTemplate>
                                        <div class="Cateen_images    effect8">
                                            <asp:ImageButton CssClass="img" ID="ImageButton1" runat="server" ImageUrl='<%# String.Format("~/Admin/Cateen/{0}", DataBinder.Eval(Container.DataItem, "ProductImage1")) %>'
                                                alt='<%# DataBinder.Eval(Container.DataItem,"ProductName") %>' />
                                            <h3 style="bottom: 80px;">
                                                <asp:LinkButton runat="server" ID="ProductName" Text='<%# DataBinder.Eval(Container.DataItem,"ProductName") %>' /></h3>
                                            <br />
                                            <h3>
                                                Rate :
                                                <asp:LinkButton runat="server" ID="LinkButton1" Text='<%# DataBinder.Eval(Container.DataItem,"Rate") %>'></asp:LinkButton></h3>
                                            <br />
                                            <asp:LinkButton ID="LinkButton11" runat="server" class="view_product2" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"CateenId") %>'
                                                Text="Order"></asp:LinkButton>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <div class="clr">
                                </div>
                            </div>
                           
                        </asp:Panel>
                        <asp:LinkButton ID="LinkButtonPaltium" runat="server" Text="Paltium" CssClass="buttonkp"
                            OnClick="LinkButtonPaltium_Click"></asp:LinkButton>
                        <asp:LinkButton ID="LinkButtonGold" runat="server" Text="Gold" CssClass="buttonkp"
                            OnClick="LinkButtonGold_Click"></asp:LinkButton>
                        <asp:LinkButton ID="LinkButtonSilver" runat="server" Text="Silver" CssClass="buttonkp"
                            OnClick="LinkButtonSilver_Click"></asp:LinkButton>
                        <div class="clr">
                        </div>
                        <h1 class="head">
                            Date & Show time
                        </h1>
                        <asp:RadioButton ID="rdobtnD1" runat="server" Text="Frist" GroupName="abc1" AutoPostBack="true"
                            OnCheckedChanged="rdobtnD1_CheckedChanged" />
                        &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:RadioButton ID="rdobtnD2" runat="server" Text="Second" GroupName="abc1" AutoPostBack="true"
                            OnCheckedChanged="rdobtnD2_CheckedChanged" />
                        &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:RadioButton ID="rdobtnD3" runat="server" Text="Evening" GroupName="abc1" AutoPostBack="true"
                            OnCheckedChanged="rdobtnD3_CheckedChanged" />
                        <div class="clr">
                        </div>
                        <h1 class="head">
                           
                        </h1>
                        <div class="clr">
                        </div>
                        <asp:RadioButton ID="RadioButton1" runat="server" Text="Frist" GroupName="abc" AutoPostBack="True"
                            OnCheckedChanged="RadioButton1_CheckedChanged" />
                        &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:RadioButton ID="RadioButton2" runat="server" Text="Second" GroupName="abc" AutoPostBack="True"
                            OnCheckedChanged="RadioButton2_CheckedChanged" />
                        &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:RadioButton ID="RadioButton3" runat="server" Text="Evening" AutoPostBack="true"
                            GroupName="abc" OnCheckedChanged="RadioButton3_CheckedChanged" />
                        &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:RadioButton ID="RadioButton4" runat="server" Text="Night" GroupName="abc" AutoPostBack="true"
                            OnCheckedChanged="RadioButton4_CheckedChanged" />
                        <h1 class="head">
                            Book Seat
                        </h1>
                        <asp:Repeater ID="rpt" runat="server" OnItemCommand="rpt_ItemCommand">
                            <ItemTemplate>
                                <div style="float: left; vertical-align: text-top; padding: 2px; width: 25px;">
                                    <asp:Label runat="server" Text='<%#Container.ItemIndex+1 %>'></asp:Label>
                                    <asp:ImageButton ID="ImageButton0" runat="server" CommandName="book" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"SrNo") %>'
                                        ImageUrl="images/1_1.png" Visible='<%# (DataBinder.Eval(Container.DataItem, "Type").ToString() == "1") %>'
                                        alt="" />
                                    <asp:ImageButton ID="ImageButton1" runat="server" CommandName="booked" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"SrNo") %>'
                                        ImageUrl="images/1_2.png" Visible='<%# (DataBinder.Eval(Container.DataItem, "Type").ToString() == "2") %>'
                                        alt="Booked" />
                                    <asp:ImageButton ID="ImageButton2" runat="server" CommandName="Selectbook" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"SrNo") %>'
                                        ImageUrl="images/1_4.png" Visible='<%# (DataBinder.Eval(Container.DataItem, "Type").ToString() == "0") %>'
                                        alt="Select" />
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <div class="clr">
                        </div>
                       
                        <asp:LinkButton ID="btnSubmit" runat="server" Text="Booking" CssClass="buttonkp"
                            OnClick="btnSubmit_Click"></asp:LinkButton>
                    </center>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="clr">
        </div>
        <h1 class="head">
        </h1>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="clr">
        </div>
        <div class="developer">
            <div class="copy_rght">
                <p>
                    &copy; Copyright 2015 Play Movies</p>
            </div>
            <div class="softyoug_info">
                <p>
                    <a href="#" title="Website Design &amp; Developed">Website Design &amp; Developed</a>
                    : <a href="#" title="Website development, Software Development, SEO Service, ERP Development, Creative Design">
                    </a>
                </p>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
