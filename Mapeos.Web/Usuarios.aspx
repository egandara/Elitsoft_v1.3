<%@ Page Title="" Language="C#" MasterPageFile="~/MasterMapeos.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="Mapeos.Web.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Estilos/Estilos.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style10 {
            font-size: x-large;
            width: 260px;
        }
        .auto-style11 {
            width: 260px;
        }
        .auto-style12 {
            font-size: xx-large;
        }
        .auto-style13 {
            width: 260px;
            height: 24px;
        }
        .auto-style14 {
            height: 24px;
        }
        .auto-style15 {
            width: 260px;
            height: 23px;
        }
        .auto-style16 {
            height: 23px;
        }
        .auto-style17 {
            width: 463px;
        }
        .auto-style18 {
            height: 24px;
            width: 463px;
        }
        .auto-style19 {
            height: 23px;
            width: 463px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Estilos/Estilos.css" rel="stylesheet" type="text/css" />
    <asp:Panel ID="Panel2" runat="server" style="margin-left: 0px">
        <table style="width:100%;">
            <tr>
                <td class="auto-style10"><strong>Mantenedor de usuarios</strong></td>
                <td class="auto-style17">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style11">Rut</td>
                <td class="auto-style17">
                    <asp:TextBox ID="txtRut" CssClass="textBox2" runat="server" onkeypress="javascript:return solonumeros(event)" MaxLength="8"></asp:TextBox>
                    <strong><span class="auto-style12">-</span><asp:TextBox ID="txtDv" CssClass="textBox3" runat="server" onkeypress="javascript:return solonumeros2(event)" Width="15px" MaxLength="1" AutoPostBack="true" OnTextChanged="txtDv_TextChanged" ></asp:TextBox>
                    </strong>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style11">Nombre</td>
                <td class="auto-style17">
                    <asp:TextBox ID="txtNombre" CssClass="textBox2" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style13">UserName</td>
                <td class="auto-style18">
                    <asp:TextBox ID="txtUsername" CssClass="textBox2" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style14"></td>
            </tr>
            <tr>
                <td class="auto-style11">Clave</td>
                <td class="auto-style17">
                    <asp:TextBox ID="txtClave" CssClass="textBox2" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style11">Repetir clave</td>
                <td class="auto-style17">
                    <asp:TextBox ID="txtClave2" CssClass="textBox2" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:CompareValidator ID="valClave" runat="server" ControlToCompare="txtClave" ControlToValidate="txtClave2" ErrorMessage="*Repetir clave debe coincidir con Clave"></asp:CompareValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style11">Perfil</td>
                <td class="auto-style17">
                    <asp:DropDownList ID="ddlPerfil" CssClass="dropDown" runat="server">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style15"></td>
                <td class="auto-style19"></td>
                <td class="auto-style16"></td>
            </tr>
            <tr>
                <td class="auto-style11">
                    <asp:Button ID="btnCreate" CssClass="button" runat="server" Text="Crear" OnClick="btnCreate_Click" />
                    <asp:Button ID="btnUpdate" CssClass="button" runat="server" Text="Actualizar" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnDesactivar" CssClass="button" runat="server" Text="Desactivar" OnClick="btnDesactivar_Click" OnClientClick="return confirm('¿Está seguro de cambiar estado de usuario?');" />
                </td>
                <td class="auto-style17">
                    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
    </asp:Panel>
</asp:Content>
