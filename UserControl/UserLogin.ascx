<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserLogin.ascx.cs" Inherits="UserControl_UserLogin" %>
<link rel="Stylesheet" type="text/css" href="../css/style.css" />
<script language="javascript" type="text/javascript">
    function validateLogin() {
        var summary = "";
       // summary += isvaliduserName();
//        summary += isvalidPassword();
        if (summary != "") {
            alert(summary);
            return false;
        }
        else {
            return true;
        }

    }
    function isvaliduserName() {
        var uid;
        var temp = document.getElementById("<%=TxtEmailAddress.ClientID %>");
        uid = temp.value;
        if (uid == "") {
            return ("Please Enter Email Address" + "\n");
        }
        else {
            return "";
        }
    }
//    function isvalidPassword() {
//        var uid;
//        var temp = document.getElementById("<%=TxtPassword.ClientID %>");
//        uid = temp.value;
//        if (uid == "") {
//            return ("Please enter Password" + "\n");
//        }
//        else {
//            return "";
//        }
//    }
//   
</script>
<asp:UpdatePanel runat="server" ID="UpLogin">
    <ContentTemplate>
        
        <div class="login_content">
            
            <table style="margin:-10px 0 0 30px;">
                <tr>
                    <td>
                       <h3>
                Login</h3>
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
                        Email :
                    </td>                    
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="TxtEmailAddress" CssClass="text_box" Width="220px"></asp:TextBox>
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
                        Password :
                    </td>                    
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="TxtPassword" CssClass="text_box" Width="220px" TextMode="Password"></asp:TextBox>
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
                    <td colspan="2">
                        <asp:Button runat="server" ID="btnLogin" Text="Login" CssClass="login_button" OnClick="btnLogin_Click" OnClientClick ="javascript:validateLogin()" />
                        &nbsp; &nbsp;<a style="color: #004B91;" href="forgot-Password.aspx"  >Forgot your password?</a>
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
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
