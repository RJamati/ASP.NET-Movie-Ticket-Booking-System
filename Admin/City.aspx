/<%@ Page Language="C#" AutoEventWireup="true" CodeFile="City.aspx.cs" Inherits="Admin_Controls_Accessory_brand" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>City</title>
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
                <li class="active"><a href="" class="ico10"><span>Theatres</span><em></em></a> <span
                    class="tooltip"><span>Theatres</span></span> </li>
                <li><a href="City.aspx" class="ico2"><span>City Master</span><em></em></a> <span class="tooltip">
                    <span>City Master</span></span> </li>
                         <li><a href="TheatresMaster.aspx" class="ico6"><span>Theatres Master</span><em></em></a> <span class="tooltip">
                    <span>Theatres Master</span></span> </li>
                <li  ><a href="Screen.aspx" class="ico3"><span>Screen Master</span><em></em></a> <span class="tooltip"><span>
                    Screen Master</span></span> </li>
                <li><a href="Movies.aspx" class="ico4"><span>Movies Master</span><em></em></a> <span class="tooltip">
                    <span>Movies Master</span></span> </li>
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
                <p style="float:right; font-weight:bold; font-size:16px;padding:6px 0 0 0;"><a href="Theatres.aspx">Back to Dashboard</a></p>
                <h3>
                    City Master</h3>
                <div>
                    <div class="clear">
                     <asp:Button runat="server" ID="BtnNew" Text="Create" OnClick="BtnNew_Click" CssClass="save_button" />
                            
                        <table runat="server" visible="false" id="TableCity">
                          <tr>
                                <td class="table_header">
                                    City Name
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtCityName" runat="server" CssClass="text_box name_box"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TxtCityName" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                  <asp:Button runat="server" ID="BtnSave" Text="SAVE" OnClick="BtnSave_Click" CssClass="save_button" />
                                </td>
                                <td>
                                 <asp:Button runat="server" ID="Btn" Text="CLEAR" OnClick="Btn_Click" CssClass="clear_button" CausesValidation="false" />
                                </td>
                            </tr>
                            </table>
                            <asp:HiddenField runat="server" ID="hfCityId" />
                    </div>

                    <div class="message">
                        <asp:Label ID="LblMessage" runat="server"></asp:Label>
                    </div>
                     
                    <div class="form_table">
                    <asp:TextBox runat="server" ID="txtSearchbox" CssClass="text_box"></asp:TextBox> 
                    <asp:Button runat="server" ID="BtnSearch" Text="Search" CausesValidation="false" onclick="BtnSearch_Click"  CssClass="save_button" />
                  
                        <div class="grid">
                            <asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="false" OnRowDeleting="GridView_RowDeleting"
                                OnRowUpdating="GridView_RowUpdating" AllowPaging="True" PageSize="15" 
                                OnPageIndexChanging="GridView2_PageIndexChanging" AllowSorting="True" 
                                onsorting="GridView1_Sorting">
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
                                    <asp:TemplateField HeaderText ="Company Name" SortExpression ="CityName">
                                      
                                        <ItemTemplate>
                                            <asp:HiddenField runat="server" Value='<%#Bind("CityId")%>' ID="hfMobileBrandId" />
                                            <asp:Label runat="server" ID="Label_Source2" Text='<%# Bind("CityName") %>'></asp:Label>
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
                                            <asp:ImageButton ID="Image2" runat="server" ImageUrl="~/Admin/Images/edit.png" CommandName="edit"  />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                              <asp:ImageButton ID="Image3" runat="server" ImageUrl="~/Admin/images/cross.png" ToolTip="Delete"
                                                CommandName="delete" CssClass="delete2" CausesValidation="false" OnClientClick="return confirm('Are you sure you want to delete this Record?');" />
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
                <div class="clr">
                </div>
            </div>
            
            <div class="clr">
            </div>
        </div>
          <div class="footer">
             <div class="copy_rght">
        <p>&copy; Copyright 2015 Play Movies</p>
        </div>
        <div class="softyoug_info">
            <p>
                <p>
                    <a href="" title="Website Design &amp; Developed">
                        Website Design &amp; Developed</a> : <a href="" title="Website development, Software Development, SEO Service, ERP Development, Creative Design">
                            </a></p>
            </div>
        </div>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
