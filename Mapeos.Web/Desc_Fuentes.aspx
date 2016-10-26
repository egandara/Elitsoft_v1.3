<%@ Page Title="" Language="C#" MasterPageFile="~/MasterMapeos.Master" AutoEventWireup="true" CodeBehind="Desc_Fuentes.aspx.cs" EnableEventValidation = "false" Inherits="Mapeos.Web.Desc_Fuentes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style10 {
            height: 23px;
        }
        .auto-style11 {
            width: 117px;
        }
        .auto-style12 {
            height: 23px;
            width: 117px;
        }
        .auto-style14 {
            height: 23px;
            width: 317px;
        }
        .auto-style17 {
            width: 317px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Estilos/Estilos.css" rel="stylesheet" type="text/css" />
    <asp:Panel ID="Panel2" runat="server">
            <table style="width:100%;">
                <tr>
                    <td class="auto-style11" style="font-weight: 700">Filtrar:</td>
                    <td class="auto-style17">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style12">Por sistema</td>
                    <td class="auto-style14">
                        <asp:CheckBox ID="chbSistemas" runat="server" />
                        <asp:DropDownList ID="ddlSistemas" runat="server" CssClass="dropDown">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style10"></td>
                    <td class="auto-style10"></td>
                    <td class="auto-style10"></td>
                    <td class="auto-style10"></td>
                </tr>
                <tr>
                    <td class="auto-style11">
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
                    <td class="auto-style11">Ver:</td>
                    <td class="auto-style17">&nbsp;
                        <asp:DropDownList ID="ddlPaginas" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                            <asp:ListItem Value="20">--</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>15</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp; por página</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <asp:GridView ID="gvFuentes" CssClass="gridView" runat="server" AllowPaging="True" OnPageIndexChanging="gvFuentes_PageIndexChanging" OnSelectedIndexChanged="gvFuentes_SelectedIndexChanged" AllowSorting="True" OnSorting="gvFuentes_Sorting" PageSize="20">
                <AlternatingRowStyle BackColor="#999999" />
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
                <HeaderStyle BackColor="#333333" Font-Bold="True" Font-Names="Calibri" Font-Size="Medium" ForeColor="White" Height="30px" HorizontalAlign="Left" />
            </asp:GridView>
            <br />
            <br />
            <br />
    </asp:Panel>
</asp:Content>
