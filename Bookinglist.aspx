<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Bookinglist.aspx.cs" Inherits="Bookinglist" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControl/UserLogin.ascx" TagName="UserLogin" TagPrefix="UL" %>
<%@ Register Src="~/UserControl/SignUpNewUser.ascx" TagName="SignUpNewUser" TagPrefix="UL" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Booking List</title>
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
                    runat="server" Text=""></asp:LinkButton>
                <asp:LinkButton ID="lbl4" runat="server" PostBackUrl="~/PersonalInformation.aspx"
                    CssClass="setting_image" Text="  ">&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton>
                <asp:Label ID="lbl3" runat="server" Text="|"></asp:Label>
                <asp:LinkButton runat="server" ID="ALogOut" CssClass="user_setting" OnClick="ALogOut_Click">Sign Out</asp:LinkButton>
                <asp:Label ID="Lbl5" runat="server" Text="  |  "></asp:Label>
                <a href="#" target="_blank" class="twitter"></a><a href="#" target="_blank" class="facebook">
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
                                    <asp:LinkButton ID="linkbuttonAddresses" runat="server" Text="Booking List" CausesValidation="false"
                                        PostBackUrl="~/Bookinglist.aspx" CssClass="profile_link"></asp:LinkButton>
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
                        </table>
                    </div>
                    <div class="right_sidebar1">
                        <table width="600px" style="float: right" class="admin">
                            <tr>
                                <td>
                                    <div runat="server" id="DivPersonalInformation">
                                        <asp:GridView AutoGenerateColumns="false" runat="server" ID="GridViewOrderProductDetailsHeader"
                                            OnRowDataBound="GridViewOrderProductDetailsHeader_RowDataBound" CssClass="admin"
                                            OnRowDeleting="GridViewOrderProductDetailsHeader_RowDeleting" OnRowUpdating="GridViewOrderProductDetailsHeader_RowUpdating1">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Sr. No.
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <center>
                                                            <%# Container.DataItemIndex + 1 %></center>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Booking Detail
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <itemstyle class="grid_title" />
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lbl_OrderNo" runat="server" Text="Booking No :- "></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblOrderNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"BookingId") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Lbl_OrderDate" runat="server" Text="Booking Date :- "></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="LblOrderDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"EntryDate") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                             <tr>
                                                                <td>
                                                                    <asp:Label ID="Label4" runat="server" Text="Show Date :- "></asp:Label>
                                                                </td>
                                                                <td>
                                                                  <asp:Label ID="LblEntryDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BookingDate", "{0:dddd,MMMM d, yyyy}") %>'></asp:Label>
 
                                                                   
                                                                  
                                                                   
                                                                </td>
                                                                  <td>
                                                                    <asp:Label ID="Label5" runat="server" Text="Time :- "></asp:Label>
                                                                </td>
                                                                <td>
                                                                 <asp:Label ID="Label6" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"BookingTime") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <asp:GridView runat="server" AutoGenerateColumns="false" ID="GridViewProductDetailsDetails"
                                                            ShowFooter="false" Width="500px">
                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        Sr No
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <center>
                                                                            <%# Container.DataItemIndex + 1 %></center>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        Grand Total :
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                                    <HeaderTemplate>
                                                                        Seat No
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblProductNsssme" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"SeatNo") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ControlStyle-Width="250px">
                                                                    <HeaderTemplate>
                                                                        Movies Name
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblProductName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"MoviesName") %>'></asp:Label>
                                                                        <br />
                                                                        <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ScreenName") %>'></asp:Label>
                                                                        <br />
                                                                        <asp:Label ID="Label2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"TheatresName") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        Grand Total :
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        City
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblProductNgggame" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"CityName") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        Amount
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="LblSubTotal" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Rate") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalSubTotal" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"TotalRate") %>' />
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <%--<asp:TemplateField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center">
                                                                    <HeaderTemplate>
                                                                        Cancel
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                    <asp:HiddenField ID="hfBookSessssatId" Value='<%# DataBinder.Eval(Container.DataItem,"BookingSeetId") %>' runat="server" />
                                                                        <asp:ImageButton CausesValidation="false" ID="Image1dd" runat="server" ImageUrl="~/Admin/images/cross.png"
                                                                            ToolTip="Save" CommandName="update" CssClass="edit" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>--%>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center">
                                                    <HeaderTemplate>
                                                        Cancel / Postpone
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="hfBosssokId" Value='<%# DataBinder.Eval(Container.DataItem,"BookingId") %>'
                                                            runat="server" />
                                                               <asp:HiddenField ID="HiddenFieldMovieId" Value='<%# DataBinder.Eval(Container.DataItem,"MovieId") %>'
                                                            runat="server" />
                                                              <asp:HiddenField ID="HiddenFieldMoviesCount" Value='<%# DataBinder.Eval(Container.DataItem,"MoviesCount") %>'
                                                            runat="server" />
                                                            <asp:Label ID="lblError" runat="server"  visible='<%# (DataBinder.Eval(Container.DataItem, "cancel").ToString() == "1") %>' Text='Ticket Cancel'></asp:Label>
                                                             <asp:Label ID="ddddd" runat="server"  visible='<%# (DataBinder.Eval(Container.DataItem, "cancel").ToString() == "2") %>' Text='Ticket Postphone'></asp:Label>
                                                         <asp:Label ID="Label3" runat="server"  visible='<%# (DataBinder.Eval(Container.DataItem, "cancel").ToString() == "5") %>' Text='Ticket Booking Date Over'></asp:Label>
                                               
                                                        <asp:ImageButton CausesValidation="false" ID="Imagssess1" runat="server" ImageUrl="~/Admin/images/cross.png"
                                                            ToolTip="Cancel"
                                                            visible='<%# (DataBinder.Eval(Container.DataItem, "cancel").ToString() == "0") %>'
                                                             CommandName="update" CssClass="edit" OnClientClick="return confirm('Are you sure you want to Cancel this event,Amount Refundable on 70% ?');" />
                                                        <br />
                                                        <br />
                                                        <asp:ImageButton CausesValidation="false" ID="ImageBusstton1" runat="server" ImageUrl="~/Admin/images/Postpone2.png"
                                                        visible='<%# (DataBinder.Eval(Container.DataItem, "cancel").ToString() == "0") %>'

                                                            ToolTip="Postpone" CommandName="delete" CssClass="edit" OnClientClick="return confirm('Are you sure you want to Postpone this event, Amount Refundable on 70%?');" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="#E9E9E9" CssClass="cart_footer" Font-Bold="True" ForeColor="Black"
                                                HorizontalAlign="Left" />
                                            <HeaderStyle BackColor="#F2F2F2" Font-Bold="True" ForeColor="Black" HorizontalAlign="Left"
                                                CssClass="cart_head" />
                                        </asp:GridView>
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
