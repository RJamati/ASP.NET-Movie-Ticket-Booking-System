<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProfileSetting.aspx.cs" Inherits="ProfileSetting" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControl/UserLogin.ascx" TagName="UserLogin" TagPrefix="UL" %>
<%@ Register Src="~/UserControl/SignUpNewUser.ascx" TagName="SignUpNewUser" TagPrefix="UL" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/Popup.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="background-color: Black; height: 33px;">
        <p class="login">
            <a href="contact.aspx" class="login-window">Contact Us</a> &nbsp;|&nbsp; <a href="Default.aspx"
                class="login-window">Home</a> &nbsp;|&nbsp; <a href="about.aspx" class="login-window">
                    About Us</a> &nbsp;<asp:Label ID="Lbl1" runat="server" Text="|">&nbsp;</asp:Label><a
                        href="#login-box" id="ALogin" class="login-window" runat="server">Login</a>
            &nbsp;
            <asp:Label ID="Lbl2" runat="server" Text="|"></asp:Label>&nbsp; <a href="#login-box1"
                id="ASignup" class="login-window" runat="server">Signup</a>
        </p>
        <div id="login-box" class="login-popup">
            <UL:UserLogin ID="ULUserLogin" runat="server" />
        </div>
        <div id="login-box1" class="login-popup">
            <UL:SignUpNewUser ID="ULSignUp" runat="server" />
        </div>
    </div>
    <div>
        <table width="200px" style="float: left">
            <tr>
                <td>
                    <asp:LinkButton ID="linkbuttonChangePassword" runat="server" Text="Change Password"
                        OnClick="linkbuttonChangePassword_Click" CausesValidation="false"></asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:LinkButton ID="linkbuttonAddresses" runat="server" Text="Addresses" OnClick="linkbuttonAddresses_Click"
                        CausesValidation="false"></asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:LinkButton ID="linkbuttonPersonalInformation" runat="server" Text="Personal Information"
                        OnClick="linkbuttonPersonalInformation_Click" CausesValidation="false"></asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:LinkButton ID="linkbuttonUpdateEmail" runat="server" Text="Update Email" OnClick="linkbuttonUpdateEmail_Click"
                        CausesValidation="false"></asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td style="border: inherit;">
                    <asp:LinkButton ID="linkbutton1" PostBackUrl="~/MyOrder.aspx" runat="server" Text="My Order"
                        CausesValidation="false" CssClass="profile_link_last"></asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td style="border: inherit;">
                    <asp:LinkButton ID="linkbutton2" PostBackUrl="~/MyCancelOrder.aspx" runat="server"
                        Text="Cancel Order" CausesValidation="false" CssClass="profile_link_last"></asp:LinkButton>
                </td>
            </tr>
        </table>
        <table width="700px" style="float: right">
            <tr>
                <td>
                    <div runat="server" id="DivPersonalInformation" visible="false">
                        <table>
                            <tr>
                                <h1>
                                    Personal Information</h1>
                            </tr>
                            <tr>
                                <td>
                                    First Name :-
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtFirstName" runat="server" MaxLength="70"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Last Name :-
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtLastName" runat="server" MaxLength="70"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Mobile Name :-
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtMobileNumber" runat="server" MaxLength="70"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    LandLine Number :-
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtLandlineNumber" runat="server" MaxLength="70"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Gender :-
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDlGender" runat="server">
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
                                    <asp:Button ID="btnPersonalDetailSave" runat="server" Text="Save" OnClick="btnPersonalDetailSave_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div runat="server" id="DivChangePassword" visible="false">
                        <table>
                            <tr>
                                <h1>
                                    Change Password</h1>
                            </tr>
                            <tr>
                                <td>
                                    Email Address :-
                                </td>
                                <td>
                                    <asp:Label ID="lblEmailAddress" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    New Password :-
                                </td>
                                <td>
                                    <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password" MaxLength="18"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Re-Enter Password :-
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtNewPassword" runat="server" TextMode="Password" MaxLength="18"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:CompareValidator ID="compval" Display="dynamic" ControlToValidate="txtOldPassword"
                                        ControlToCompare="TxtNewPassword" ForeColor="red" Type="String" EnableClientScript="false"
                                        Text="Password And Repeat Password Not Match..." runat="server" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" ControlToValidate="TxtNewPassword"
                                        Text="The Repeat Password field is required!" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:Button ID="btnChagePasswordSave" runat="server" Text="Save" OnClick="btnChagePasswordSave_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div runat="server" id="DivAddresses" visible="false">
                        <table>
                            <tr>
                                <h1>
                                    Add New Address</h1>
                            </tr>
                            <tr>
                                <td>
                                    Name :-
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtName" runat="server" MaxLength="150"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Street Address :-
                                </td>
                                <td>
                                    <cc1:Editor ID="TxtStreetAddress" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    LandMark :-
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtLandMark" runat="server" MaxLength="70"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    City :-
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCity" runat="server" MaxLength="70"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    State :-
                                </td>
                                <td>
                                    <asp:TextBox ID="txtState" runat="server" MaxLength="70"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Country :-
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCountry" runat="server" MaxLength="70"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Pin Code :-
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtPinCode" runat="server" MaxLength="70"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Phone number :-
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtPhoneNumber" runat="server" MaxLength="70"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:Button ID="BtnAddressSave" runat="server" Text="Save" OnClick="BtnAddressSave_Click" />
                                </td>
                            </tr>
                        </table>
                        <div class="sample_product">
                            <asp:DataList runat="server" ID="DlAddresses" RepeatLayout="Table" RepeatColumns="4">
                                <ItemTemplate>
                                    <center>
                                        <div class="sample_images effect8">
                                            <asp:Label runat="server" ID="ProductName" CssClass="product_name" Text='<%# DataBinder.Eval(Container.DataItem,"UserAddress") %>'></asp:Label></b>
                                            <br />
                                            <a id="A1" href='<%# String.Format("ProfileSetting.aspx?ID={0}", DataBinder.Eval(Container.DataItem, "UserAddressMasterId")) %>'
                                                runat="server" class="view_product">Delete</a>
                                        </div>
                                    </center>
                                </ItemTemplate>
                            </asp:DataList>
                            <div class="clr">
                            </div>
                        </div>
                    </div>
                    <div runat="server" id="DivUpdateEmail" visible="false">
                        <table>
                            <tr>
                                <h1>
                                    Change Email Address</h1>
                            </tr>
                            <tr>
                                <td>
                                    Email Address :-
                                </td>
                                <td>
                                    <asp:Label ID="lblOldEmailAddress" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    New Email Address :-
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNewEmailAddress" runat="server" MaxLength="255"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtEmailAddress"
                                        ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" EnableClientScript="false"
                                        ErrorMessage="Valid Email Address..." runat="server" /><asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator1" ControlToValidate="txtNewEmailAddress" Text="The Email Address field is required!"
                                            runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:Button ID="BtnEmailSave" runat="server" Text="Save" OnClick="BtnEmailSave_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
