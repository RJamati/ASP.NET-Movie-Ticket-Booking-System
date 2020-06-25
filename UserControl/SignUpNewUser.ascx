<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SignUpNewUser.ascx.cs"
    Inherits="UserControl_SignUpNewUser" %>
<link rel="Stylesheet" type="text/css" href="../css/style.css" />
<!-- **************************Java Script start************************************** -->
<script language="javascript" type="text/javascript">
    function validate() {
        var summary = "";
        summary += isvalidfirstName();
        summary += isvalidLastName();
        summary += isvalidEmailAddress();
        summary += isvalidPassword();
        summary += isvalidRetypePassword();
        if (summary != "") {
            alert(summary);
            return false;
        }
        else {
            return true;
        }

    }
    function isvalidfirstName() {
        var uid;
        var temp = document.getElementById("<%=TxtFirstName.ClientID %>");
        uid = temp.value;
        if (uid == "") {
            return ("Please Enter FirstName" + "\n");
        }
        else {
            return "";
        }
    }
    function isvalidLastName() {
        var uid;
        var temp = document.getElementById("<%=TxtLastName.ClientID %>");
        uid = temp.value;
        if (uid == "") {
            return ("Please enter LastName" + "\n");
        }
        else {
            return "";
        }
    }
    function isvalidEmailAddress() {
        var uid;
        var temp = document.getElementById("<%=txtEmailAddress.ClientID %>");
        uid = temp.value;
        if (uid == "") {
            return ("Please enter Email Address" + "\n");
        }
        else {
            return "";
        }
    }
    function isvalidPassword() {
        var uid;
        var temp = document.getElementById("<%=TxtPassword.ClientID %>");
        uid = temp.value;
        if (uid == "") {
            return ("Please enter Password" + "\n");
        }
        else {
            return "";
        }
    }
    function isvalidRetypePassword() {
        var uid;
        var temp = document.getElementById("<%=TxtRepeat.ClientID %>");
        uid = temp.value;
        if (uid == "") {
            return ("Please enter Retype Password" + "\n");
        }
        else {
            return "";
        }
    }
</script>
<!-- **************************Java Script End**************************************** -->
<asp:UpdatePanel runat="server" ID="UpLogin">
    <ContentTemplate>
        <div class="login_content">
            <table style="margin: 0 0 0 30px;">
                <tr>
                    <td>
                        <h3>
                            New User ? Sign Up</h3>
                    </td>
                    <td>
                        <a href="Default.aspx" class="close">
                            <img src="images/close_pop.png" class="btn_close" title="Close Window" alt="Close" /></a>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        *First Name :
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="TxtFirstName" runat="server" MaxLength="70" Width="220px" CssClass="text_box"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        *Last Name :
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="TxtLastName" runat="server" MaxLength="70" Width="220px" CssClass="text_box"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        *Email Address :&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="txtEmailAddress" Width="220px" CssClass="text_box"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        *MobileNo :&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="TxtMobileNo" Width="220px" CssClass="text_box"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        *Password :&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="TxtPassword" Width="220px" CssClass="text_box" TextMode="Password"></asp:TextBox>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        *Retype Password :&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="TxtRepeat" CssClass="text_box" Width="220px" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>

                <td>

                    Enter Below Code :

                </td>
                                </tr>
                <tr>
                <td>

                    <asp:TextBox ID="txtCaptcha"  CssClass="text_box" runat="server" Width="200px"></asp:TextBox>

                </td>

            </tr>
                <tr>
                 <td valign="middle">

                    <asp:UpdatePanel ID="UP1" runat="server">

                        <ContentTemplate>

                            <table>

                                <tr>

                                    <td style="height: 50px; width:100px;">

                                        <asp:Image ID="imgCaptcha" runat="server" />

                                    </td>

                                    <td valign="middle">

                                        <asp:Button ID="btnRefresh" runat="server" Text="Refresh" 
                                            onclick="btnRefresh_Click"  />

                                    </td>

                                </tr>

                            </table>

                        </ContentTemplate>

                    </asp:UpdatePanel>

                </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button runat="server" ID="BtnSignUp" Text="Create Account" CssClass="create_account"
                            OnClick="BtnSignUp_Click" OnClientClick="javascript:validate()" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblerrormsg" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtEmailAddress"
                            ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Invalid Email Address..."
                            EnableClientScript="false" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:CompareValidator ID="compval" Display="dynamic" ControlToValidate="TxtPassword"
                            ControlToCompare="TxtRepeat" ForeColor="red" Type="String" Text="Password And Repeat Password Not Match..."
                            EnableClientScript="false" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
