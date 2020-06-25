<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dashboard.aspx.cs" Inherits="dashboard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dashboard</title>
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
                        <a href="" class="logo"></a>
                    </div>
                    <ul class="buttons">
                        
                        <li class="active"><a href="dashboard.aspx" class="ico1"><span>Dashboard</span><em></em></a>
                            <span class="tooltip"><span>Dashboard</span></span> </li>
                        <li><a href="admin.aspx" class="ico8"><span>Administration</span><em></em></a> <span
                            class="tooltip"><span>Administration</span></span> </li>
                        <li><a href="Theatres.aspx" class="ico2"><span>Theatres</span><em></em></a>
                            <span class="tooltip"><span>Theatres</span></span> </li>
                        <li><a href="Banner.aspx" class="ico1"><span>Banner</span><em></em></a> <span class="tooltip">
                    <span>Banner</span></span> </li>
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
                        <h3>
                            Dashboard</h3>
                   
                        <div class="dashboard_icon">
                            <div class="icon_board" style="height: 140px;">
                                <a href="admin.aspx">
                                    <img src="images/admin.png">
                                    Administration</a>
                            </div>                            
                         
                            <div class="icon_board" style="height: 140px;">
                                <a href="Theatres.aspx">
                                    <img src="images/accessorie_icon.jpg">
                                    Theatres...</a>
                            </div>
                     
                          
                             <div class="icon_board" style="height: 140px;">
                        <a href="Banner.aspx">
                            <img src="images/banner_icon.jpg">
                            Banner</a>
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
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
