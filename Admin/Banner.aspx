<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Banner.aspx.cs" Inherits="Admin_Banner" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>banner</title>
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
    <form id="form1" runat="server" enctype="multipart/form-data" method="post">
    <asp:ScriptManager ID="sp" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="Up" runat="server">
        <ContentTemplate>
            <div class="main">
                <div class="sidebar_pannel">
                    <div class="company_logo">
                        <a href="dashboard.aspx" class="logo"></a>
                    </div>
                    <ul class="buttons">
                        <li class="active"><a href="Banner.aspx" class="ico1"><span>Banner</span><em></em></a>
                            <span class="tooltip"><span>Banner</span></span> </li>
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
                            Banner</h3>
                        <div class="dashboard_icon">
                            <div>
                                <table>
                                    <tr>
                                        <td>
                                            Banner Name :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBannerName" runat="server" CssClass="text_box"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtBannerName"
                                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align: top;">
                                            Banner upload :
                                        </td>
                                        <td>
                                            <asp:FileUpload ID="FUBanner" runat="server" />
                                            <asp:Button runat="server" ID="btnPhotoPreview" Text="Upload" OnClick="btnPhotoPreview_Click"
                                                CausesValidation="false" />
                                            <br />
                                            <br />
                                            <img id="img1" src="" alt="" height="200" runat="server" />
                                        </td>
                                        <td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Is Active :
                                        </td>
                                        <td>
                                            <asp:CheckBox runat="server" ID="ChkActive" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Button ID="BtnSave" runat="server" Text="SAVE" OnClick="BtnSave_Click" CssClass="save_button" />
                                            <asp:Button ID="BtnClear" CausesValidation="false" runat="server" Text="CLEAR" CssClass="clear_button"
                                                OnClick="BtnClear_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="LblMessage" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:HiddenField ID="hfMobileBrandId1" runat="server" />
                                            <asp:HiddenField ID="hfImadeName" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                                <div>
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
                                                <asp:TemplateField HeaderText="Banner Name" SortExpression="BannerName">
                                                    <ItemTemplate>
                                                        <asp:HiddenField runat="server" Value='<%#Bind("BannerId")%>' ID="hfBannerId" />
                                                        <asp:Label runat="server" ID="Label_Source2" Text='<%# Bind("BannerName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Image" SortExpression="Image">
                                                    <ItemTemplate>
                                                        <asp:Image ID="GvImage" runat="server" Height="200px" ImageUrl='<%# String.Format("~/Admin/banner/{0}", DataBinder.Eval(Container.DataItem, "ImageName")) %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Is Active" SortExpression="IsAcitve">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="Label_Source5" Text='<%# Bind("IsAcitve") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Edit" HeaderStyle-Width="45px">
                                                    <EditItemTemplate>
                                                        <asp:ImageButton ID="Image2" runat="server" ImageUrl="~/Admin/Images/edit.png" CommandName="edit" />
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="Image1" runat="server" ImageUrl="~/Admin/images/edit.png" CommandName="update"
                                                            ToolTip="Edit" CssClass="delete2" CausesValidation="false" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete" HeaderStyle-Width="35px">
                                                    <EditItemTemplate>
                                                        <asp:ImageButton ID="Image2" runat="server" ImageUrl="~/Admin/Images/edit.png" CommandName="edit" />
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="Image3" runat="server" ImageUrl="~/Admin/images/cross.png" CommandName="delete"
                                                            ToolTip="Delete" CssClass="delete2" CausesValidation="false" OnClientClick="return confirm('Are you sure you want to delete this Record?');" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                             
                                            </Columns>
                                        </asp:GridView>
                                    </div>
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
        <Triggers>
            <asp:PostBackTrigger ControlID="btnPhotoPreview" />
        </Triggers>
    </asp:UpdatePanel>
    </form>
</body>
</html>
