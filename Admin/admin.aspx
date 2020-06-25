<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin.aspx.cs" Inherits="Admin_admin" %>

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
       <asp:ScriptManager ID="sp" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="Upanel" runat="server">
    <ContentTemplate >
    <div class="main">
        <div class="sidebar_pannel">
            <div class="company_logo">
                <a href="dashboard.aspx" class="logo"></a>
            </div>
            <ul class="buttons">
                <li class="active"><a href="dashboard.aspx" class="ico11"><span>Admin</span><em></em></a>
                    <span class="tooltip"><span>Admin</span></span> </li>
                <li><a href="RegisterUserList.aspx" class="ico4"><span>User Information</span><em></em></a> <span class="tooltip">
                    <span>User Information</span></span> </li>
                <li><a href="Signup.aspx" class="ico8"><span>Create New User</span><em></em></a> <span class="tooltip">
                    <span>Create New User</span></span> </li>
     
                <li><a href="ChangeEmailAddress.aspx" class="ico5"><span>Change Email</span><em></em></a> <span class="tooltip">
                    <span>Change Email</span></span> </li>
                <li><a href="ChangePassword.aspx" class="ico6"><span>Change Password</span><em></em></a> <span class="tooltip">
                    <span>Change Password</span></span> </li>
                <li><a href="ProfileSetting.aspx" class="ico7"><span>Profile Setting</span><em></em></a> <span class="tooltip">
                    <span>Profile Setting</span></span> </li>
                
                
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
                    <a href="dashboard.aspx">Back to Dashboard</a></p>
                <h3>
                    Admin</h3>
            
                <div class="dashboard_icon">
                    <div class="icon_board" style="height: 140px;">
                        <a href="RegisterUserList.aspx">
                            <img src="images/user_info.jpg">
                            User Information</a>
                    </div>
                    <div class="icon_board" style="height: 140px;">
                        <a href="Signup.aspx">
                            <img src="images/create_new.jpg">
                            Create New User</a>
                    </div>                    
                    <div class="clr">
                    </div>
              
                    </div>
                    <div class="clr">
                    </div>
                    <div class="icon_board" style="height: 140px;">
                        <a href="ChangeEmailAddress.aspx">
                            <img src="images/change_email.jpg">
                            Change Email</a>
                    </div>

                     <div class="icon_board" style="height: 140px;">
                        <a href="ChangePassword.aspx">
                            <img src="images/change_password.jpg">
                            Change Password</a>
                    </div>                    
                   <div class="icon_board" style="height: 140px;">
                        <a href="ProfileSetting.aspx">
                            <img src="images/profile_setting.jpg">
                            Profile Setting</a>
                    </div>
                     
                       
                
                    <div class="clr">
                    </div>
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
