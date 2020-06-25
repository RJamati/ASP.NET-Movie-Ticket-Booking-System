<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProfileSetting.aspx.cs" Inherits="Admin_ProfileSetting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Play Movies | Admin Panel</title>
    <link rel="Stylesheet" type="text/css" href="css/style.css" />
    <link rel="shortcut icon" href="images/favicon(1).ico" />
    <script src="JS/Postback.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sp" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="Upanel" runat="server">
        <ContentTemplate>
            <div class="main">
                <div class="sidebar_pannel">
                    <div class="company_logo">
                        <a href="dashboard.aspx" class="logo"></a>
                    </div>
                    <ul class="buttons">
                        <li><a href="admin.aspx" class="ico11"><span>Admin</span><em></em></a> <span class="tooltip">
                            <span>Admin</span></span> </li>
                        <li><a href="RegisterUserList.aspx" class="ico4"><span>User Information</span><em></em></a>
                            <span class="tooltip"><span>User Information</span></span> </li>
                        <li><a href="Signup.aspx" class="ico8"><span>Create New User</span><em></em></a> <span
                            class="tooltip"><span>Create New User</span></span> </li>
                        <li><a href="ChangeEmailAddress.aspx" class="ico5"><span>Change Email</span><em></em></a>
                            <span class="tooltip"><span>Change Email</span></span> </li>
                        <li><a href="ChangePassword.aspx" class="ico6"><span>Change Password</span><em></em></a>
                            <span class="tooltip"><span>Change Password</span></span> </li>
                        <li class="active"><a href="ProfileSetting.aspx" class="ico7"><span>Profile Setting</span><em></em></a>
                            <span class="tooltip"><span>Profile Setting</span></span> </li>
                    </ul>
                </div>
                <div class="container">
                    <div class="header">
                        <div class="links">
                            <a href="../Default.aspx"></a>
                        </div>
                        <div class="logout_btn">
                            <h3>
                                Logout</h3>
                            <a href="Default.aspx" class="logout"></a>
                        </div>
                        <div class="clr">
                        </div>
                    </div>
                    <div class="dashboard">
                        <p style="float: right; font-weight: bold; font-size: 16px; padding: 6px 0 0 0;">
                            <a href="admin.aspx">Back to Dashboard</a></p>
                        <h3>
                            Personal Information</h3>
                        <table>
                            <tr>
                                <td>
                                    <div runat="server" id="DivPersonalInformation">
                                        <table>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="table_left_text">
                                                    First Name :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TxtFirstName" runat="server" MaxLength="70" CssClass="text_box"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="TxtFirstName"
                                                        EnableClientScript="true" Text="*" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="table_left_text">
                                                    Last Name :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TxtLastName" runat="server" MaxLength="70" CssClass="text_box"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TxtLastName"
                                                        EnableClientScript="true" Text="*" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="table_left_text">
                                                    Gender :
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="DDlGender" runat="server" CssClass="text_box">
                                                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top;" class="table_left_text">
                                                    Street Address :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TxtStreetAddress" runat="server" CssClass="text_box" Width="200px"
                                                        TextMode="MultiLine"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr id="Tr1" runat="server" visible="false">
                                                <td class="table_left_text">
                                                    LandMark :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TxtLandMark" runat="server" CssClass="text_box" MaxLength="70"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="table_left_text">
                                                    Province :
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="txtState" runat="server" CssClass="text_box">
                                                        <asp:ListItem Value="0" Text="-- Select --"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Alberta"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="British Columbia"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text="Manitoba"></asp:ListItem>
                                                        <asp:ListItem Value="4" Text="New Brunswick"></asp:ListItem>
                                                        <asp:ListItem Value="5" Text="Newfoundland and Labrador"></asp:ListItem>
                                                        <asp:ListItem Value="6" Text="Nova Scotia"></asp:ListItem>
                                                        <asp:ListItem Value="7" Text="Northwest Territories"></asp:ListItem>
                                                        <asp:ListItem Value="8" Text="Nunavut"></asp:ListItem>
                                                        <asp:ListItem Value="9" Text="Ontario"></asp:ListItem>
                                                        <asp:ListItem Value="10" Text="Prince Edward Island"></asp:ListItem>
                                                        <asp:ListItem Value="11" Text="Quebec"></asp:ListItem>
                                                        <asp:ListItem Value="11" Text="Saskatchewan"></asp:ListItem>
                                                        <asp:ListItem Value="12" Text="Yukon"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="table_left_text">
                                                    City :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtCity" runat="server" CssClass="text_box" MaxLength="70"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="table_left_text">
                                                    Postal Code :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TxtPinCode" runat="server" CssClass="text_box" MaxLength="6" Style="text-transform: uppercase;"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorpost" runat="server"
                                                        ControlToValidate="TxtPinCode" ErrorMessage="Enter Valid Postal Code..." ValidationExpression="^[ABCEGHJKLMNPRSTVXYabceghjklmnprstvxy]{1}\d{1}[A-Za-z]{1} *\d{1}[A-Za-z]{1}\d{1}$"> </asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="table_left_text">
                                                    Cell Phone number :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TxtPhoneNumber" runat="server" CssClass="text_box" MaxLength="10"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TxtPhoneNumber"
                                                        ErrorMessage="Enter valid Cell number..." ValidationExpression="^[0-9]{10}">
                                                    </asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnPersonalDetailSave" runat="server" Text="Save Detail" CssClass="save_button"
                                                        OnClick="btnPersonalDetailSave_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="clr">
                    </div>
                </div>
            </div>
            <div class="footer">
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
