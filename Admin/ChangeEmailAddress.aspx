<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangeEmailAddress.aspx.cs"
    Inherits="Admin_ChangeEmailAddress" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Play Movies | Admin Panel</title>
    <link rel="Stylesheet" type="text/css" href="css/style.css" />
    <link rel="shortcut icon" href="images/favicon(1).ico" />
    <script src="JS/Postback.js" type="text/javascript"></script>
    <style type="text/css">
        .footer
        {
            width: 100%;
            position: fixed;
            bottom: 0;
            -webkit-user-select: none; /* Chrome all / Safari all */
            -moz-user-select: none; /* Firefox all */
            -ms-user-select: none; /* IE 10+ */
            -o-user-select: none;
            user-select: none;
        }
    </style>
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
                        <li class="active"><a href="ChangeEmailAddress.aspx" class="ico5"><span>Change Email</span><em></em></a>
                            <span class="tooltip"><span>Change Email</span></span> </li>
                        <li><a href="ChangePassword.aspx" class="ico6"><span>Change Password</span><em></em></a>
                            <span class="tooltip"><span>Change Password</span></span> </li>
                        <li><a href="ProfileSetting.aspx" class="ico7"><span>Profile Setting</span><em></em></a>
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
                            Change Email Address</h3>
                     
                        <div class="dashboard_icon">
                            <table>
                                <tr>
                                    <td style="width: 130px;" class="table_left_text">
                                        Old Email Address :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtOldEmailAddress" runat="server" Width="220px" CssClass="text_box"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtOldEmailAddress"
                                            EnableClientScript="true" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="TxtOldEmailAddress"
                                            ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Enter Valid Email Address..."
                                            EnableClientScript="true" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="table_left_text">
                                        New Email Address :
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="TxtNewEmailAddress" Width="220px" CssClass="text_box"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtNewEmailAddress"
                                            EnableClientScript="true" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="TxtNewEmailAddress"
                                            ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Enter Valid Email Address..."
                                            EnableClientScript="true" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="table_left_text">
                                        Retype Email Address :
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="TxtRepeat" Width="220px" CssClass="text_box"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtRepeat"
                                            EnableClientScript="true" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="compval" Display="dynamic" ControlToValidate="TxtNewEmailAddress"
                                            ControlToCompare="TxtRepeat" ForeColor="red" Type="String" Text="Email Address And Retype Email Address Not Match..."
                                            EnableClientScript="true" runat="server" />
                                        <br />
                                        &nbsp; &nbsp;
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="TxtRepeat"
                                            ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Enter Valid Email Address..."
                                            EnableClientScript="true" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:Button ID="BtnEmailAddress" runat="server" Text="Submit" OnClick="BtnEmailAddress_Click"
                                            CssClass="save_button" />
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                        <asp:Label ID="lblErrorMessage" Text="" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <div class="clr">
                            </div>
                        </div>
                        <div class="clr">
                        </div>
                    </div>
                </div>
                <div class="footer">
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
