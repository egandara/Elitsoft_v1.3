<%@ Page Title="" Language="C#" MasterPageFile="~/MasterMapeos.Master" AutoEventWireup="true" CodeBehind="Desc_Fuentes.aspx.cs" EnableEventValidation = "false" Inherits="Mapeos.Web.Desc_Fuentes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style10 {
            height: 23px;
        }
        .auto-style11 {
            width: 117px;
        }
        .auto-style14 {
            height: 23px;
            width: 317px;
            text-align: left;
        }
        .auto-style17 {
            width: 317px;
        }
        .auto-style18 {
            height: 23px;
            width: 456px;
            text-align: left;
        }
        .auto-style19 {
            height: 23px;
            width: 362px;
            text-align: right;
            font-size: small;
        }
        .auto-style20 {
            height: 23px;
            font-size: medium;
            font-weight: normal;
        }
        .auto-style21 {
            width: 117px;
            font-weight: normal;
            text-align: left;
        }
        .auto-style22 {
            width: 456px;
            font-weight: normal;
            text-align: left;
            height: 22px;
        }
        .auto-style23 {
            width: 317px;
            height: 22px;
        }
        .auto-style24 {
            height: 22px;
        }
        .auto-style25 {
            width: 456px;
            font-weight: normal;
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Estilos/Estilos.css" rel="stylesheet" type="text/css" />
    <asp:Panel ID="Panel2" runat="server">
            <table style="width:100%;">
                <tr>
                    <td class="auto-style22" style="font-weight: 700">Filtrar:</td>
                    <td class="auto-style23"></td>
                    <td class="auto-style24"></td>
                    <td class="auto-style24"></td>
                    <td class="auto-style24"></td>
                    <td class="auto-style24"></td>
                    <td class="auto-style24"></td>
                </tr>
                <tr>
                    <td class="auto-style18">Por sistema:<asp:CheckBox ID="chbSistemas" runat="server" />
                        <asp:DropDownList ID="ddlSistemas" runat="server" CssClass="dropDown">
                        </asp:DropDownList>
                        &nbsp; </td>
                    <td class="auto-style19">
                        &nbsp;</td>
                    <td class="auto-style20"></td>
                    <td class="auto-style20"></td>
                    <td class="auto-style20"></td>
                    <td class="auto-style20"></td>
                    <td class="auto-style20"></td>
                </tr>
                <tr>
                    <td class="auto-style25">
                        <asp:Button ID="btnFiltrar" CssClass="button" runat="server" OnClick="btnFiltrar_Click" Text="Filtrar" />
                    </td>
                    <td class="auto-style17">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style25">Ver:<asp:DropDownList ID="ddlPaginas" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        <asp:ListItem Value="20">--</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;por página</td>
                    <td class="auto-style17">&nbsp; &nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <asp:GridView ID="gvFuentes" CssClass="gridView2" RowStyle-CssClass="rows" HeaderStyle-CssClass="header" runat="server" AllowPaging="True" OnPageIndexChanging="gvFuentes_PageIndexChanging" OnSelectedIndexChanged="gvFuentes_SelectedIndexChanged" OnSorting="gvFuentes_Sorting" PageSize="20" BorderColor="Black" BorderStyle="Solid">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnSeleccionar" CssClass="button" runat="server" Text="Editar" 
                                        OnClick="btnSeleccionar_onclick" />
                            </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    No existen fuentes.
                </EmptyDataTemplate>
            </asp:GridView>
            <br />
            <br />
            <br />
    </asp:Panel>
</asp:Content>
