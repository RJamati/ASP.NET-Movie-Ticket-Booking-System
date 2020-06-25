<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CateenTherates.aspx.cs" Inherits="Admin_Controls_feature_master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Play Movies | Admin Panel</title>
    <style type="text/css">
        .style3
        {
            width: 442px;
        }
        .style4
        {
            height: 32px;
        }
        .style5
        {
            width: 442px;
            height: 32px;
        }
    </style>
    <link rel="Stylesheet" type="text/css" href="css/style.css" />
    <link rel="shortcut icon" href="images/favicon(1).ico" />
    <script src="JS/Postback.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
   
         <asp:ScriptManager ID="sp" runat="server">
    </asp:ScriptManager>
    <div class="main">
        <div class="sidebar_pannel">
            <div class="company_logo">
                <a href="CateenDashboard.aspx" class="logo"></a>
            </div>
            <ul class="buttons">
               <li class="active"><a href="" class="ico10"><span>Cateen</span><em></em></a> <span class="tooltip"><span>Cateen</span></span> </li>
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
                    <a href="CateenTherates.aspx">Back to Dashboard</a></p>
                <h3>
                    Cateen</h3>
                <div class="clear">
                    <asp:Button runat="server" ID="BtnNew" Text="Create" OnClick="BtnNew_Click" CssClass="save_button" />
                    <table runat="server" visible="false" id="TableCellPhoneBrand">
                        <tr>
                            <td class="table_header">
                                Product Name
                                <asp:HiddenField runat="server" ID="hfScreenId" />
                            </td>
                            <td>
                                <asp:TextBox ID="TxtProductName" runat="server" CssClass="text_box name_box"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TxtProductName"
                                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="table_header">
                                Theatres Name
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlTheatresName" runat="server" CssClass="select" Enabled="true">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="ddlTheatresName"
                                    InitialValue="0" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="table_header">
                               Product Image
                            </td>
                            <td>
                                <asp:FileUpload ID="FUProductImage" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="FUProductImage"
                                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="table_header">
                               Description
                            </td>
                            <td>
                                <asp:TextBox ID="TxtDesc" runat="server" CssClass="text_box name_box" TextMode="MultiLine"></asp:TextBox>
                              
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="TxtDesc"
                                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="table_header">
                                Rate
                            </td>
                            <td>
                                <asp:TextBox ID="TxtRate" runat="server" CssClass="text_box name_box"></asp:TextBox>
                               
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="TxtRate"
                                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                      
                        <tr>
                            <td>
                                <asp:Button runat="server" ID="BtnSave" Text="SAVE" OnClick="BtnSave_Click" CssClass="save_button" />
                            </td>
                            <td>
                                <asp:Button runat="server" ID="Btn" Text="CLEAR" OnClick="Btn_Click" CssClass="clear_button"
                                    CausesValidation="false" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="message">
                    <asp:Label ID="LblMessage" runat="server"></asp:Label>
                </div>
                <div class="form_table">
                    <asp:TextBox runat="server" ID="txtSearchbox" CssClass="text_box"></asp:TextBox>
                    <asp:Button runat="server" ID="BtnSearch" Text="Search" CausesValidation="false"
                        CssClass="save_button" OnClick="BtnSearch_Click" />
                    <div class="grid">
                        <asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="false" OnRowDeleting="GridView_RowDeleting"
                            OnRowUpdating="GridView_RowUpdating" AllowPaging="True" PageSize="10" OnPageIndexChanging="GridView2_PageIndexChanging"
                            AllowSorting="True" OnSorting="GridView1_Sorting">
                            <PagerStyle CssClass="pstyle" />
                            <PagerSettings Mode="NextPreviousFirstLast" FirstPageText="First" LastPageText="Last"
                                NextPageText="Next" PreviousPageText="Prev" Position="TopAndBottom" />
                            <Columns>
                                <asp:TemplateField HeaderText="Sr. No.">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Product Name" SortExpression="ProductName">
                                    <ItemTemplate>
                                        <asp:HiddenField runat="server" Value='<%#Bind("CateenId")%>' ID="hfMobileBrandId" />
                                        <asp:Label runat="server" ID="Label_Source2" Text='<%# Bind("ProductName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Image" SortExpression="Image">
                                    <ItemTemplate>
                                        <asp:Image ID="GvImage" runat="server" Height="200px" ImageUrl='<%# String.Format("~/Admin/Cateen/{0}", DataBinder.Eval(Container.DataItem, "ProductImage1")) %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Theatres Name" SortExpression="TheatresName">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="Label_Source2TheatresName" Text='<%# Bind("TheatresName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="City" SortExpression="CityName">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="Label_Source2screenNamess" Text='<%# Bind("CityName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                             
                              
                                <asp:TemplateField HeaderText="Rate" SortExpression="Rate">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="Label_Source2GoldSeat" Text='<%# Bind("Rate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Desc" SortExpression="ProductDesc">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="Label_Source2GoldRate" Text='<%# Bind("ProductDesc") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit" HeaderStyle-Width="45px">
                                    <EditItemTemplate>
                                        <asp:ImageButton ID="Image2" runat="server" ImageUrl="~/Admin/Images/edit.png" CommandName="edit" />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="Image1" runat="server" ImageUrl="~/Admin/images/edit.png" ToolTip="Edit"
                                            CommandName="update" CssClass="delete2" CausesValidation="false" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete" HeaderStyle-Width="35px">
                                    <EditItemTemplate>
                                        <asp:ImageButton ID="Image2" runat="server" ImageUrl="~/Admin/Images/edit.png" CommandName="edit"
                                            ToolTip="Edit" />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="Image3" runat="server" ImageUrl="~/Admin/images/cross.png" ToolTip="Delete"
                                            CommandName="delete" CssClass="delete2" CausesValidation="false" OnClientClick="return confirm('Are you sure you want to delete this Record?');" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                              
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="clr">
                </div>
            </div>
        </div>
        <div class="footer">
          
        </div>
    </div>
   
    </form>
</body>
</html>
