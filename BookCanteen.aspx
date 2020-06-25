<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BookCanteen.aspx.cs" Inherits="BookCanteen" %>

<%@ Register Src="~/UserControl/UserLogin.ascx" TagName="UserLogin" TagPrefix="UL" %>
<%@ Register Src="~/UserControl/SignUpNewUser.ascx" TagName="SignUpNewUser" TagPrefix="UL" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE aspx PUBLIC "-//W3C//DTD Xaspx 1.0 Transitional//EN" "http://www.w3.org/TR/xaspx1/DTD/xaspx1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="description" content="" />
    <link rel="Stylesheet" type="text/css" href="Admin/css/style.css" />
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
                <li class="select"><a href="about.aspx">About Us</a></li>
                <li><a href="contact.aspx">Contact Us</a></li>
            </ul>
        </div>
        <div class="path_view">
            <a href="Default.aspx">Home</a> > BookCanteen
        </div>
        <div class="container">
            <center>
                <asp:RadioButton ID="Rdbtn1" runat="server" Checked="true" Text="On Start Time" GroupName="Food"
                    AutoPostBack="true" />
                <asp:RadioButton ID="RdBtn2" runat="server" Text="Between Movies" GroupName="Food"
                    AutoPostBack="true" />
            &nbsp;
            <asp:HiddenField runat="server" Value="" ID="hfBookingId" />
            </center>
        </div>
        <div class="clr" style="height: 25px;">
        </div>
        <div class="container">
            <center>
                <table width="100%">
                    <tr>
                        <td align="right">
                            <asp:Label ID="LblFoodName" runat="server" Text="Food Name : "></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DrpFoodName" runat="server" Width="300px" 
                                onselectedindexchanged="DrpFoodName_SelectedIndexChanged" 
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lbl25" runat="server" Text="Rs : "></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="LblRs" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Lbl1" runat="server" Text="Qty : "></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TextBox1" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                    <tr>
                    <td>
                     <asp:Button ID="BtnSkip" runat="server" Text="SKIP" OnClick="BtnSkip_Click" 
                                CssClass="save_button1" /></td>
                        <td>
                           
                            <asp:Button ID="BtnSave" runat="server" Text="SAVE" OnClick="BtnSave_Click" CssClass="save_button" />
                            <asp:Button ID="BtnClear" CausesValidation="false" runat="server" Text="CLEAR" CssClass="clear_button"
                                OnClick="BtnClear_Click" />
                        </td>
                        <td>
                     <asp:Button ID="Button1" runat="server" Text="Next"  
                                CssClass="save_button1" onclick="Button1_Click" /></td>
                    </tr>
                </table>
            </center>
        </div>
          <div class="clr" style="height: 5px;">
        </div>
        <div class="grid">
                                        <asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="false" OnRowDeleting="GridView_RowDeleting"
                                            OnRowUpdating="GridView_RowUpdating" AllowPaging="True" PageSize="5" OnPageIndexChanging="GridView2_PageIndexChanging"
                                            AllowSorting="True" OnSorting="GridView1_Sorting">
                                            <PagerStyle CssClass="pstyle" />
                                            <PagerSettings Mode="NextPreviousFirstLast" FirstPageText="First" LastPageText="Last"
                                                NextPageText="Next" PreviousPageText="Prev" Position="TopAndBottom" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sr. No." SortExpression="BannerId">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Food Name" SortExpression="ProductName">
                                                    <ItemTemplate>
                                                        <asp:HiddenField runat="server" Value='<%#Bind("BookingCateend")%>' ID="hfBannerId" />
                                                        <asp:Label runat="server" ID="Label_Source1" Text='<%# Bind("ProductName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Rate" SortExpression="Rate">
                                                    <ItemTemplate>
                                                      
                                                        <asp:Label runat="server" ID="Label_Source2" Text='<%# Bind("Rate") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Qty" SortExpression="Qty">
                                                    <ItemTemplate>
                                                      
                                                        <asp:Label runat="server" ID="Label_Source3" Text='<%# Bind("Qty") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="Price">
                                                    <ItemTemplate>
                                                      
                                                        <asp:Label runat="server" ID="Label_Source4" Text='<%# Bind("price") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                              
                                                <asp:TemplateField HeaderText="Delete" HeaderStyle-Width="35px">
                                                 
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="Image3" runat="server" ImageUrl="~/Admin/images/cross.png" CommandName="delete"
                                                            ToolTip="Delete" CssClass="delete2" CausesValidation="false" OnClientClick="return confirm('Are you sure you want to delete this Record?');" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                             
                                            </Columns>
                                        </asp:GridView>
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
