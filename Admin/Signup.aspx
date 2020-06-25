<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Signup.aspx.cs" Inherits="Signup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
                        <li class="active"><a href="Signup.aspx" class="ico8"><span>Create New User</span><em></em></a>
                            <span class="tooltip"><span>Create New User</span></span> </li>
                        <li><a href="ChangeEmailAddress.aspx" class="ico5"><span>Change Email</span><em></em></a>
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
                            Create User</h3>
                        <table style="float: none; left: 150px; width: 350px; background-color: #e1e1e1;
                            margin: 10px 30px 10px 35%; padding: 10px 0 0 40px;">
                            <tr>
                                <td>
                                    <h3>
                                        New User ? Sign Up</h3>
                                </td>
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
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="TxtFirstName" runat="server" MaxLength="70" Width="250px" CssClass="text_box"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtFirstName"
                                        EnableClientScript="true" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Last Name :
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="TxtLastName" runat="server" MaxLength="70" Width="250px" CssClass="text_box"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtLastName"
                                        EnableClientScript="true" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Login Type :
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlLoginType" runat="server" CssClass="select" AutoPostBack="true"
                                        Width="250px" OnSelectedIndexChanged="ddlLoginType_SelectedIndexChanged">
                                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Admin" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Theatres" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="Cateen" Value="4"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlLoginType"
                                        InitialValue="0" EnableClientScript="true" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr runat="server" id="trTheatresLbl" visible="false">
                                <td>
                                    Theatres name :
                                </td>
                            </tr>
                            <tr runat="server" id="trTheatresValues" visible="false">
                                <td>
                                    <asp:DropDownList ID="ddltheatres" runat="server" CssClass="select" Width="250px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="ddltheatres"
                                        InitialValue="0" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Mobile No :
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox runat="server" ID="TxtmobileNo" Width="250px" CssClass="text_box" MaxLength="15"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TxtmobileNo"
                                        EnableClientScript="true" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Email Address :
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox runat="server" ID="txtEmailAddress" Width="250px" CssClass="text_box"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEmailAddress"
                                        EnableClientScript="true" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Password :&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox runat="server" ID="TxtPassword" Width="250px" TextMode="Password" CssClass="text_box"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtPassword"
                                        EnableClientScript="true" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Retype Password :&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox runat="server" ID="TxtRepeat" Width="250px" TextMode="Password" CssClass="text_box"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtRepeat"
                                        EnableClientScript="true" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr style="margin-top: -20px;">
                                <td>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtEmailAddress"
                                        ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Enter Valid Email Address..."
                                        EnableClientScript="true" runat="server" />
                                    <br />
                                    <asp:CompareValidator ID="compval" Display="dynamic" ControlToValidate="TxtPassword"
                                        ControlToCompare="TxtRepeat" ForeColor="red" Type="String" Text="Password And Retype Password Not Match..."
                                        EnableClientScript="true" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button runat="server" ID="BtnSignUp" Text="Create Account" CssClass="save_button"
                                        OnClick="BtnSignUp_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
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
