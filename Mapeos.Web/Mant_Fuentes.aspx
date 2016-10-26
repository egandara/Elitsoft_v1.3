<%@ Page Title="" Language="C#" MasterPageFile="~/MasterMapeos.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="Mant_Fuentes.aspx.cs" Inherits="Mapeos.Web.Mant_Fuentes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Estilos/Estilos.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style7 {
            width: 258px;
            font-size: x-large;
        }
        .auto-style8 {
            width: 212px;
        }
        .auto-style10 {
        height: 27px;
    }
    .auto-style11 {
        height: 23px;
    }
        .auto-style12 {
            font-size: large;
            font-weight: bold;
        }
        .auto-style13 {
            height: 27px;
            text-align: left;
            font-size: medium;
        }
        .auto-style14 {
            width: 258px;
            text-align: left;
        }
        .auto-style15 {
            width: 258px;
            font-size: x-large;
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel2" runat="server">
        <br />
        <table style="width:100%;">
            <tr>
                <td class="auto-style15"><strong>Descripción de la fuente</strong></td>
                <td class="auto-style8">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style14">Número de fuente</td>
                <td class="auto-style8">
                    <asp:TextBox ID="txtNumero" runat="server" MaxLength="5" CssClass="textBox" onkeypress="javascript:return solonumeros(event)" AutoPostBack="true" onpaste="return false" OnTextChanged="txtNumero_TextChanged"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblNumeroFuente" runat="server"></asp:Label>
                    <asp:Button ID="btnLimpiar" runat="server" OnClick="btnLimpiar_Click" style="margin-bottom: 0px" Text="Limpiar" />
                </td>
            </tr>
            <tr>
                <td class="auto-style14">Archivo de fuente</td>
                <td class="auto-style8">
                    <asp:TextBox ID="txtArchivo" CssClass="textBox2" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style14">Sistema fuente</td>
                <td class="auto-style8">
                    <asp:TextBox ID="txtSistema" CssClass="textBox2" runat="server" ToolTip="."></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style14">Contenido</td>
                <td class="auto-style8">
                    <asp:TextBox ID="txtContenido" CssClass="textBox2" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style14">Cantidad de registros</td>
                <td class="auto-style8">
                    <asp:TextBox ID="txtCantidad" MaxLength="5" CssClass="textBox2" runat="server" onkeypress="javascript:return solonumeros(event)" ></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style14">Periodicidad</td>
                <td class="auto-style8">
                    <asp:DropDownList ID="ddlPeriodicidad" CssClass="dropDown" runat="server">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style14">Tipo extractor</td>
                <td class="auto-style8">
                    <asp:DropDownList ID="ddlExtractor" CssClass="dropDown" runat="server">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style14">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style14">
                    <asp:Button ID="btnCreate" CssClass="button" runat="server" Text="Crear" OnClick="btnCreate_Click" />
                    <asp:Button ID="btnUpdate" CssClass="button" runat="server" Text="Actualizar" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnDelete" CssClass="button" runat="server" Text="Eliminar" OnClick="btnDelete_Click" OnClientClick="return confirm('¿Está seguro de eliminar la fuente?');" />
                </td>
                <td class="auto-style8">
                    <asp:Label ID="lblMensaje" runat="server" Font-Bold="True"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style14">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <hr />
        <table style="width:100%;">
            <tr>
                <td class="auto-style12">
                    Precedencias</td>
                <td>
                    <b>Destinos</b></td>
                <td>
                    <b>Minor autocompletadas</b></td>
            </tr>
            <tr>
                <td>
                    <asp:ListBox ID="lbPrecedencias" runat="server" ondblclick="lbPrecedencias_DoubleClick()" CssClass="listBox" Rows="10"></asp:ListBox>
                    <input type="hidden" name="lbPrecedenciasHidden" />
                </td>
                <td>
                    <asp:ListBox ID="lbDestinos" runat="server" ondblclick="lbDestinos_DoubleClick()" CssClass="listBox" Rows="10"></asp:ListBox>
                    <input type="hidden" name="lbDestinosHidden" />
                </td>
                <td>
                    <asp:ListBox ID="lbMinors" runat="server" ondblclick="lbMinors_DoubleClick()" CssClass="listBox" Rows="10"></asp:ListBox>
                    <input type="hidden" name="lbMinorsHidden" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnCreatePrecedencia" CssClass="button" runat="server" Text="Agregar" OnClick="btnCreatePrecedencia_Click" />
                    <asp:Button ID="btnDeletePrecedencia" CssClass="button" runat="server" Text="Quitar" OnClick="btnDeletePrecedencia_Click" OnClientClick="return confirm('¿Está seguro de eliminar la precedencia?');" />
                </td>
                <td>
                    <asp:Button ID="btnCreateDestino" CssClass="button" runat="server" Text="Agregar" OnClick="btnCreateDestino_Click" />
                    <asp:Button ID="btnDeleteDestino" CssClass="button" runat="server" Text="Quitar" OnClick="btnDeleteDestino_Click" OnClientClick="return confirm('¿Está seguro de eliminar el destino?');" />
                </td>
                <td>
                    <asp:Button ID="btnCreateMinor" CssClass="button" runat="server" Text="Agregar" OnClick="btnCreateMinor_Click" />
                    <asp:Button ID="btnDeleteMinor" CssClass="button" runat="server" Text="Quitar" OnClick="btnDeleteMinor_Click" OnClientClick="return confirm('¿Está seguro de eliminar la minor?');" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style10">
                    <asp:DropDownList ID="ddlPrecedencias" CssClass="dropDown2" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="auto-style10">
                    <asp:DropDownList ID="ddlDestinos" CssClass="dropDown2" runat="server" >
                    </asp:DropDownList>
                </td>
                <td class="auto-style10">
                    <asp:DropDownList ID="ddlMinors" CssClass="dropDown2" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style11">
                    <asp:Label ID="lblPrecedencias" runat="server" Text=""></asp:Label>
                </td>
                <td class="auto-style11">
                    <asp:Label ID="lblDestinos" runat="server" Text=""></asp:Label>
                </td>
                <td class="auto-style11">
                    <asp:Label ID="lblMinors" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
        <br />
        <br />
    </asp:Panel>
</asp:Content>
