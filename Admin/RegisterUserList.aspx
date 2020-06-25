<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegisterUserList.aspx.cs"
    Inherits="Admin_RegisterUserList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Play Movies | Admin Panel</title>
    <link rel="Stylesheet" type="text/css" href="css/style.css" />
    <link rel="shortcut icon" href="images/favicon(1).ico" />
    <script src="JS/Postback.js" type="text/javascript"></script>
    <style type="text/css">
        .select
        {
            width: 200px;
            padding: 5px;
            margin: 5px 0 5px 0;
            border: 1px solid #CCCCCC;
            border-radius: 1px;
            -moz-border-radius: 1px;
            -webkit-border-radius: 1px;
            background: url('../Images/select.png') no-repeat right 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
   <asp:ScriptManager ID="sp" runat="server" ></asp:ScriptManager>
     <asp:UpdatePanel ID="Upanel" runat="server">
    <ContentTemplate >
    <div class="main">
        <div class="sidebar_pannel">
            <div class="company_logo">
                <a href="dashboard.aspx" class="logo"></a>
            </div>
            <ul class="buttons">
                 <li><a href="admin.aspx" class="ico11"><span>Admin</span><em></em></a>
                    <span class="tooltip"><span>Admin</span></span> </li>
                <li class="active"><a href="RegisterUserList.aspx" class="ico4"><span>User Information</span><em></em></a> <span class="tooltip">
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
                    <a href="admin.aspx">Back to Dashboard</a></p>
                <h3>
                    Register User (<asp:Label ID="lblUserList" runat="server"></asp:Label>)</h3>
                  <div class="form_table" style="margin-top:20px;">
                
                <asp:DropDownList ID="ddlSearch" runat="server" CssClass="text_box">
                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                <asp:ListItem Text="Name" Value="1"></asp:ListItem>
                 <asp:ListItem Text="Address" Value="2"></asp:ListItem>
                <asp:ListItem Text="Cell number" Value="3"></asp:ListItem>
                <asp:ListItem Text="Email Address" Value="4"></asp:ListItem>
                 <asp:ListItem Text="Postal code" Value="5"></asp:ListItem>
                 <asp:ListItem Text="City" Value="6"></asp:ListItem>
                 <asp:ListItem Text="Province" Value="7"></asp:ListItem>
                </asp:DropDownList> <asp:TextBox runat="server" ID="txtSearchbox" CssClass="text_box"></asp:TextBox> 
                    <asp:Button runat="server" ID="BtnSearch" Text="Search" CausesValidation="false" onclick="BtnSearch_Click" CssClass="save_button"/>
                    <div class="clear"></div>
                    <div class="grid">
                        <asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="false" 
                            AllowPaging="True" PageSize="10"  onpageindexchanging="GridView1_PageIndexChanging">
                            <PagerStyle CssClass="pstyle" />
                            <pagersettings mode="NextPreviousFirstLast"
            firstpagetext="First" lastpagetext="Last" nextpagetext="Next" previouspagetext="Prev"   
            position= "TopAndBottom"/>
                            <Columns>
                                <asp:TemplateField HeaderText="Sr. No.">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name" SortExpression ="FirstName">
                                  
                                    <ItemTemplate>
                                     <%--   <asp:HiddenField runat="server" Value='<%#Bind("ProductId")%>' ID="hfProductId" />--%>
                                        <asp:Label runat="server" ID="Label_Source2" Text='<%# Bind("FirstName") %>'></asp:Label>
                                         <asp:Label runat="server" ID="Label10" Text='<%# Bind("LastName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" Address" SortExpression ="StreetAddress">
                                    
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="Label_Source4" Text='<%# Bind("StreetAddress") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="City & Postal Code :" SortExpression ="City">
                                    
                                    <ItemTemplate>
                                       <asp:Label runat="server" ID="Label3" Text='<%# DataBinder.Eval(Container.DataItem,"City") %>'></asp:Label>&nbsp&nbsp-&nbsp&nbsp
                                        <asp:Label runat="server" ID="Label8" Text='<%# DataBinder.Eval(Container.DataItem,"PostalCode") %>'></asp:Label>
                                    
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Province" SortExpression ="Province">
                                   
                                    <ItemTemplate>
                                        <h3>
                                        <asp:Label runat="server" ID="Label4" Text='<%# DataBinder.Eval(Container.DataItem,"Province") %>'></asp:Label>
                                  
                                        </h3>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Cell Number" SortExpression ="MobileNumber">
                                   
                                    <ItemTemplate>
                                        <h3>
                                          <asp:Label runat="server" ID="Label5" Text='<%# DataBinder.Eval(Container.DataItem,"MobileNumber") %>'></asp:Label>
                                        </h3>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Email Address" SortExpression ="EmailAddress">
                                   
                                    <ItemTemplate>
                                        <h3>
                                              <asp:Label runat="server" ID="Label6" Text='<%# DataBinder.Eval(Container.DataItem,"EmailAddress") %>'></asp:Label>
                               
                                        </h3>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText=" Register Date :" SortExpression ="Entrydate">
                                   
                                    <ItemTemplate>
                                        <h3>
                                        <asp:Label runat="server" ID="Label7" Text='<%# DataBinder.Eval(Container.DataItem,"Entrydate") %>'></asp:Label>
                                   
                                        </h3>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--<asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
              
                
            </div>
        </div>
        <div class="table_align" style="height: 77px;">
        </div>
    </div>
    <div class="footer">
    
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
   
    </form>
</body>
</html>
