<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewTrailer.ascx.cs" Inherits="ViewTrailer" %>
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
  
</script>
<asp:UpdatePanel runat="server" ID="UpLogin">
    <ContentTemplate>
        <div class="login_content">
           <table style="margin: 0 0 0 30px; width :100%">
                <tr>
                    <td>
                        <h3>
                            Trailer</h3>
                    </td>
                    <td align="right" >
                        <a href="Default.aspx" class="close">
                            <img src="images/close_pop.png" class="btn_close" title="Close Window" alt="Close" /></a>
                    </td>
                </tr>
                </table>

                <iframe width="500" height="500" src="https://www.youtube.com/embed/pAv48xBN2IQ?list=PL4D9E544EFE5866E0" frameborder="0" allowfullscreen></iframe>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
