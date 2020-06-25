<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="slider_index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 

    <link rel="stylesheet" href="css/nivo-slider.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="css/style.css" type="text/css" media="screen" />
    <script type="text/javascript" src="scripts/jquery-1.4.3.min.js"></script>
    <script type="text/javascript" src="scripts/jquery.nivo.slider.pack.js"></script>
    <script type="text/javascript">
        $(window).load(function () {
            $('#slider').nivoSlider();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="slider" class="nivoSlider">
              
                  <asp:Repeater runat="server" ID="rcMobileImage">
                <ItemTemplate>
                 <img src='<%# String.Format("../Admin/banner/{0}", DataBinder.Eval(Container.DataItem, "ImageName")) %>' alt='<%# DataBinder.Eval(Container.DataItem,"BannerName") %>' />
                </ItemTemplate>
            </asp:Repeater>
    </div>
  
    </form>
</body>
</html>
