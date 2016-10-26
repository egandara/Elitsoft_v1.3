<%@ Page Title="" Language="C#" MasterPageFile="~/MasterMapeos.Master" AutoEventWireup="true" CodeBehind="Severidades.aspx.cs" Inherits="Mapeos.Web.Severidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Estilos/Estilos.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style14 {
            width: 260px;
        }
        .auto-style15 {
            width: 275px;
        }
        .auto-style16 {
            width: 274px;
            height: 23px;
        }
        .auto-style17 {
            width: 275px;
            height: 23px;
        }
        .auto-style18 {
            height: 23px;
        }
        .auto-style19 {
            width: 296px;
        }
        .auto-style20 {
            width: 296px;
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel2" runat="server">
        <table style="width:100%;">
            <tr>
                <td class="auto-style19">
                    <asp:Label ID="lblListaSeveridades" runat="server" Text="Listar Severidad"></asp:Label>
                </td>
                <td class="auto-style15">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style19">
                    <asp:TextBox ID="txtBuscarSeveridades" CssClass="textBox2"  MaxLength="5" onkeypress="javascript:return solonumeros(event)" AutoPostBack="true" onpaste="return false"  runat="server"></asp:TextBox>
                    <asp:Button ID="btBuscarSeveridad" runat="server" CssClass="button" OnClick="txtBuscarSeveridad_Click" Text="Buscar" />
                </td>
                <td class="auto-style15">
                    <asp:Label ID="lblTesting" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style20"></td>
                <td class="auto-style17"></td>
                <td class="auto-style18"></td>
            </tr>
            <tr>
                <td class="auto-style19">
                    <asp:GridView ID="gvSeveridad" CssClass="gridView" runat="server" AllowPaging="True" OnSelectedIndexChanged="gvSeveridad_SelectedIndexChanged">
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:Button ID="Button1" runat="server" CausesValidation="false" CommandName="" Text="Seleccionar" OnClick="btnSeleccionar_onclick" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="auto-style19">&nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
