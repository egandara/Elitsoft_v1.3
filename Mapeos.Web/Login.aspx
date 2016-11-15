<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Mapeos.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Estilos/Estilos.css" rel="stylesheet" type="text/css" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 181px;
            height: 55px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="Panel1" runat="server" Width="100%" BackColor="#BDBDBD">
            &nbsp;
            <table style="width:100%;">
                <tr>
                    <td>
                        <img alt="Logo" class="auto-style1" src="Images/logo_elitsoft.jpg" />
                    </td>
                    <td>
                        <asp:Login ID="lgnMapeos" runat="server" DisplayRememberMe="false" CssClass="login" OnAuthenticate="lgnMapeos_Authenticate" Orientation="Horizontal" RememberMeSet="True" Width="100%" RememberMeText="Recordar." BackColor="#F7F7DE" BorderColor="#CCCC99" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="10pt" TextLayout="TextOnTop">
                            <TitleTextStyle BackColor="#6B696B" Font-Bold="True" ForeColor="#FFFFFF" />
                        </asp:Login>
                    </td>
                </tr>
                <tr>
                    <td id="2px">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <br />
        </asp:Panel>
    </div>
    </form>
</body>
</html>
