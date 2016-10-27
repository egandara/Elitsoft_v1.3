<%@ Page Title="" Language="C#" MasterPageFile="~/MasterMapeos.Master" AutoEventWireup="true" CodeBehind="Mant_Severidades.aspx.cs" Inherits="Mapeos.Web.Mant_Severidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="Estilos/Estilos.css" rel="stylesheet" type="text/css" />
     <style type="text/css">
         .auto-style14 {
             font-size: medium;
             width: 278px;
         }
         .auto-style15 {
             width: 278px;
         }
         .auto-style17 {
             width: 278px;
             height: 35px;
         }
         .auto-style18 {
             height: 35px;
         }
         .auto-style19 {
             width: 280px;
         }
         .auto-style20 {
             width: 280px;
             height: 35px;
         }
     </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel2" runat="server">
        <table style="width:100%;">
            <tr>
                <td class="auto-style19"><strong>Severidades</strong></td>
                <td class="auto-style14">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>

                    <asp:Label ID="lblIdSeveridades" runat="server" Text="Id"></asp:Label>

                </td>
                <td>

                    <asp:TextBox ID="txtIdSeveridad" runat="server" CssClass="textBox" Enabled="False"></asp:TextBox>

                </td>
                <td>

                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style19">

                    <asp:Label ID="lblNumeroFuente" runat="server" Text="Número Fuente"></asp:Label>

                </td>
                <td>

                    <asp:TextBox ID="txtNumeroFuente" runat="server" MaxLength="5" CssClass="textBox" onkeypress="javascript:return solonumeros(event)" AutoPostBack="true" onpaste="return false"></asp:TextBox>

                </td>
                <td>

                    <asp:Label ID="lblMensaje" runat="server"></asp:Label>

                </td>
            </tr>
            <tr>
                <td class="auto-style19">
                    <asp:Label ID="lblData" runat="server" Text="Data" ></asp:Label>
                </td>
                <td class="auto-style15">
                    <asp:TextBox ID="txtData" runat="server"  MaxLength="5" CssClass="textBox2" onkeypress="javascript:return solonumeros(event)" AutoPostBack="true" onpaste="return false" ></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style19">
                    <asp:Label ID="lblDestinationTableName" runat="server" Text="Destination Table Name"></asp:Label>
                </td>
                <td class="auto-style15">
                    <asp:TextBox ID="txtDestionTableName" CssClass="textBox2" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style20">
                    <asp:Label ID="lblSourceColumnName" runat="server" Text="Source Column Name"></asp:Label>
                </td>
                <td class="auto-style17">
                    <asp:TextBox ID="txtSourceColumnName" CssClass="textBox2" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style18"></td>
            </tr>
            <tr>
                <td class="auto-style19">
                    <asp:Label ID="lblFuenteDestino" runat="server" Text="Fuente Destino"></asp:Label>
                </td>
                <td class="auto-style15">
                    <asp:TextBox ID="txtFuenteDestino" CssClass="textBox2" MaxLength="5" onkeypress="javascript:return solonumeros(event)" AutoPostBack="true" onpaste="return false" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style19">
                    <asp:Label ID="lblRefTableName" runat="server" Text="Ref Table Name"></asp:Label>
                </td>
                <td class="auto-style15">
                    <asp:TextBox ID="txtRefTableName" CssClass="textBox2" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style19">
                    <asp:Label ID="lblRefColumnName" runat="server" Text="Ref Column Name"></asp:Label>
                </td>
                <td class="auto-style15">
                    <asp:TextBox ID="txtRefColumnName" CssClass="textBox2" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style19">
                    <asp:Label ID="lblBusinessRuleCd" runat="server" Text="Business Rule Cd"></asp:Label>
                </td>
                <td class="auto-style15">
                    <asp:TextBox ID="txtBusinessRuleCd" CssClass="textBox2" MaxLength="5" onkeypress="javascript:return solonumeros(event)" AutoPostBack="true" onpaste="return false" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style19">
                    <asp:Label ID="lblBusinessRuleDescription" runat="server" Text="Business Rule Description"></asp:Label>
                </td>
                <td class="auto-style15">
                    <asp:TextBox ID="txtBusinessRuleDesc" CssClass="textBox2" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style19">
                    <asp:Label ID="lblQualityTypeCd" runat="server" Text="Quality Type Cd"></asp:Label>
                </td>
                <td class="auto-style15">
                    <asp:DropDownList ID="ddlQualityTypeCd" runat="server">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style19">
                    <asp:Label ID="lblEstado" runat="server" Text="Estado"></asp:Label>
                </td>
                <td class="auto-style15">
                    <asp:CheckBox ID="ChbEstado" runat="server" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style19">

                </td>
                <td>

                </td>
                <td>

                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style19">

                    <asp:Button ID="btAgregar" CssClass="button" runat="server" Text="Agregar" OnClick="btAgregar_Click" />
                    <asp:Button ID="btActualizar" CssClass="button"  runat="server" Text="Actualizar" OnClick="btActualizar_Click" />
                    <asp:Button ID="btEliminar" CssClass="button" runat="server" Text="Eliminar" OnClick="btEliminar_Click" />

                </td>
                <td>

                </td>
                <td>

                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
