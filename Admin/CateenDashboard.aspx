<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CateenDashboard.aspx.cs"
    Inherits="Admin_Controls_accessory" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
                        <a href="CateenDashboard.aspx" class="logo"></a>
                    </div>
                    <ul class="buttons">
                        <li class="active"><a href="" class="ico10"><span>Cateen</span><em></em></a> <span
                            class="tooltip"><span>Cateen</span></span> </li>
                        <li><a href="CateenTherates.aspx" class="ico3"><span>Cateen Master</span><em></em></a> <span
                            class="tooltip"><span>Cateen Master</span></span> </li>
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
                            <a href="CateenDashboard.aspx">Back to Dashboard</a></p>
                        <h3>
                            Cateen</h3>
                        <div class="dashboard_icon">
                            <div class="icon_board">
                                <a href="CateenTherates.aspx">
                                    <img src="images/accessories4.jpg">
                                    Cateen</a>
                            </div>
                            <div class="clr">
                            </div>
                        </div>
                        <div class="table_align">
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
