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
        .auto-style14 {
            width: 258px;
            text-align: left;
        }
        .auto-style16 {
            width: 362px;
            font-size: small;
            height: 63px;
            text-align: left;
        }
        .auto-style17 {
            width: 288px;
            font-size: x-large;
            height: 63px;
            text-align: left;
        }
        .auto-style18 {
            width: 212px;
            font-size: medium;
            text-align: left;
        }
        .auto-style19 {
            text-align: left;
        }
        .auto-style20 {
            height: 23px;
            font-weight: normal;
            text-align: left;
        }
        .auto-style21 {
            height: 27px;
            font-size: medium;
            font-weight: normal;
            text-align: left;
        }
        .auto-style22 {
            font-weight: bold;
            font-size: large;
            text-align: left;
        }
        .auto-style23 {
            text-align: left;
            font-size: large;
        }
        .auto-style24 {
            width: 288px;
            font-size: small;
            height: 16px;
            text-align: right;
        }
        .auto-style25 {
            width: 212px;
            font-size: medium;
            text-align: left;
            height: 16px;
        }
        .auto-style26 {
            height: 16px;
        }
        .auto-style27 {
            width: 288px;
            font-size: small;
            height: 21px;
            text-align: right;
        }
        .auto-style28 {
            width: 212px;
            font-size: medium;
            text-align: left;
            height: 21px;
        }
        .auto-style29 {
            height: 21px;
        }
        .auto-style30 {
            width: 288px;
        }
        .auto-style31 {
            width: 288px;
            font-size: small;
            height: 63px;
            text-align: right;
        }
        .auto-style32 {
            width: 288px;
            height: 33px;
        }
        .auto-style33 {
            width: 212px;
            font-size: medium;
            text-align: left;
            height: 33px;
        }
        .auto-style34 {
            height: 33px;
        }
        .auto-style35 {
            width: 288px;
            height: 35px;
        }
        .auto-style36 {
            width: 212px;
            font-size: medium;
            text-align: left;
            height: 35px;
        }
        .auto-style37 {
            height: 35px;
        }
        .auto-style38 {
            width: 288px;
            height: 29px;
        }
        .auto-style39 {
            width: 212px;
            font-size: medium;
            text-align: left;
            height: 29px;
        }
        .auto-style40 {
            height: 29px;
        }
        .auto-style41 {
            width: 288px;
            height: 32px;
        }
        .auto-style42 {
            width: 212px;
            font-size: medium;
            text-align: left;
            height: 32px;
        }
        .auto-style43 {
            height: 32px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel2" runat="server">
        <br />
        <table style="width:100%;">
            <tr>
                <td class="auto-style17"><strong>Descripción de la fuente</strong></td>
                <td class="auto-style18">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style30">Número de fuente</td>
                <td class="auto-style18">
                    <asp:TextBox ID="txtNumero" runat="server" MaxLength="5" CssClass="textBox" onkeypress="javascript:return solonumeros(event)" AutoPostBack="true" onpaste="return false" OnTextChanged="txtNumero_TextChanged"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblNumeroFuente" runat="server"></asp:Label>
                    <asp:Button ID="btnLimpiar" CssClass="button" runat="server" OnClick="btnLimpiar_Click" style="margin-bottom: 0px" Text="Limpiar" />
                </td>
            </tr>
            <tr>
                <td class="auto-style32">Archivo de fuente</td>
                <td class="auto-style33">
                    <asp:TextBox ID="txtArchivo" CssClass="textBox2" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style34"></td>
            </tr>
            <tr>
                <td class="auto-style35">Sistema fuente</td>
                <td class="auto-style36">
                    <asp:TextBox ID="txtSistema" CssClass="textBox2" runat="server" ToolTip="."></asp:TextBox>
                </td>
                <td class="auto-style37"></td>
            </tr>
            <tr>
                <td class="auto-style35">Contenido</td>
                <td class="auto-style36">
                    <asp:TextBox ID="txtContenido" CssClass="textBox2" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style37"></td>
            </tr>
            <tr>
                <td class="auto-style35">Cantidad de registros</td>
                <td class="auto-style36">
                    <asp:TextBox ID="txtCantidad" MaxLength="5" CssClass="textBox2" runat="server" onkeypress="javascript:return solonumeros(event)" ></asp:TextBox>
                </td>
                <td class="auto-style37"></td>
            </tr>
            <tr>
                <td class="auto-style38">Periodicidad</td>
                <td class="auto-style39">
                    <asp:DropDownList ID="ddlPeriodicidad" CssClass="dropDown" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="auto-style40"></td>
            </tr>
            <tr>
                <td class="auto-style41">Tipo extractor</td>
                <td class="auto-style42">
                    <asp:DropDownList ID="ddlExtractor" CssClass="dropDown" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="auto-style43"></td>
            </tr>
            <tr>
                <td class="auto-style24"></td>
                <td class="auto-style25"></td>
                <td class="auto-style26"></td>
            </tr>
            <tr>
                <td class="auto-style31">
                    <asp:Button ID="btnCreate" CssClass="button" runat="server" Text="Crear" OnClick="btnCreate_Click" />
                    <asp:Button ID="btnUpdate" CssClass="button" runat="server" Text="Actualizar" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnDelete" CssClass="button" runat="server" Text="Eliminar" OnClick="btnDelete_Click" OnClientClick="return confirm('¿Está seguro de eliminar la fuente?');" />
                </td>
                <td class="auto-style18">
                    <asp:Label ID="lblMensaje" runat="server" Font-Bold="True"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style27"></td>
                <td class="auto-style28"></td>
                <td class="auto-style29"></td>
            </tr>
        </table>
        <hr />
        <table style="width:100%;">
            <tr>
                <td class="auto-style22">
                    <b>Precedencias</b></td>
                <td class="auto-style23">
                    <b>Destinos</b></td>
                <td class="auto-style23">
                    <b>Minor autocompletadas</b></td>
            </tr>
            <tr>
                <td class="auto-style19">
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
                <td class="auto-style19">
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
                <td class="auto-style19">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style21">
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
                <td class="auto-style20">
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
                <td class="auto-style19">&nbsp;</td>
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
