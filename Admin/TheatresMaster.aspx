<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TheatresMaster.aspx.cs" Inherits="Admin_Accessory_Companybrand" %>

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
                        <li class="active"><a href="" class="ico10"><span>Theatres</span><em></em></a> <span
                            class="tooltip"><span>Theatres</span></span> </li>
                        <li><a href="City.aspx" class="ico2"><span>City Master</span><em></em></a> <span
                            class="tooltip"><span>City Master</span></span> </li>
                        <li><a href="TheatresMaster.aspx" class="ico6"><span>Theatres Master</span><em></em></a>
                            <span class="tooltip"><span>Theatres Master</span></span> </li>
                        <li><a href="Screen.aspx" class="ico3"><span>Screen Master</span><em></em></a> <span
                            class="tooltip"><span>Screen Master</span></span> </li>
                        <li><a href="Movies.aspx" class="ico4"><span>Movies Master</span><em></em></a> <span
                            class="tooltip"><span>Movies Master</span></span> </li>
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
                            <a href="Theatres.aspx">Back to Dashboard</a></p>
                        <h3>
                            Theatres Master</h3>
                        <div>
                            <div class="clear">
                                <asp:Button runat="server" ID="BtnNew" Text="Create" OnClick="BtnNew_Click" CssClass="save_button"
                                    CausesValidation="false" />
                                <table runat="server" visible="false" id="TableAccessoriesBrand">
                                    <tr>
                                        <td class="table_header">
                                            Theatres
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtTheatreName" runat="server" CssClass="text_box name_box"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TxtTheatreName"
                                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="table_header">
                                            Address
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtAddress" runat="server" CssClass="text_box name_box"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TxtAddress"
                                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="table_header">
                                            City
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlCity" runat="server" CssClass="select">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="ddlCity"
                                                InitialValue="0" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="table_header">
                                            Location
                                        </td>
                                        <td>
                                           <asp:TextBox ID="TxtLoc" runat="server" CssClass="text_box name_box"></asp:TextBox>
                                            
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
                                <asp:HiddenField runat="server" ID="hfMobileBrandId1" />
                            </div>
                            <div class="message">
                                <asp:Label ID="LblMessage" runat="server"></asp:Label>
                            </div>
                            <div class="form_table">
                                <asp:TextBox runat="server" ID="txtSearchbox" CssClass="text_box"></asp:TextBox>
                                <asp:Button runat="server" ID="BtnSearch" Text="Search" CausesValidation="false"
                                    OnClick="BtnSearch_Click" CssClass="save_button" />
                                <div class="grid">
                                    <asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="false" OnRowDeleting="GridView_RowDeleting"
                                        OnRowUpdating="GridView_RowUpdating" AllowPaging="True" PageSize="15" OnPageIndexChanging="GridView2_PageIndexChanging"
                                        AllowSorting="True" OnSorting="GridView1_Sorting">
                                        <PagerStyle CssClass="pstyle" />
                                        <PagerSettings Mode="NextPreviousFirstLast" FirstPageText="First" LastPageText="Last"
                                            NextPageText="Next" PreviousPageText="Prev" Position="TopAndBottom" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr. No." SortExpression="AssCompanyProductNameId">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Theatres Name" SortExpression="TheatresName">
                                                <ItemTemplate>
                                                    <asp:HiddenField runat="server" Value='<%#Bind("TheatresNameId")%>' ID="hfMobileBrandId" />
                                                    <asp:Label runat="server" ID="Label_Source2" Text='<%# Bind("TheatresName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Address" SortExpression="Address">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="Label_Sourceq2" Text='<%# Bind("Address") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="City Name" SortExpression="CityName">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="Label_Sourceq21" Text='<%# Bind("CityName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Edit" HeaderStyle-Width="45px">
                                                <EditItemTemplate>
                                                    <asp:ImageButton ID="Image2" runat="server" ImageUrl="~/Admin/Images/edit.png" CommandName="edit"
                                                        ToolTip="Edit" />
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="Image1" runat="server" ImageUrl="~/Admin/images/edit.png" CommandName="update"
                                                        CssClass="delete2" CausesValidation="false" ToolTip="Edit" />
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
                        </div>
                        <div class="clr">
                        </div>
                    </div>
                    <div class="clr">
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
