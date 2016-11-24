<%@ Page Title="" Language="C#" MasterPageFile="~/MasterMapeos.Master" AutoEventWireup="true" CodeBehind="Estructura.aspx.cs" Inherits="Mapeos.Web.Estructura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style17 {
            width: 57px;
        }
        .auto-style18 {
            width: 77px;
        }
        .auto-style19 {
            width: 66px;
        }
        .auto-style21 {
            width: 92px;
        }
        .auto-style23 {
            width: 63px;
        }
        .auto-style26 {
            width: 96px;
        }
        .auto-style27 {
            width: 107px;
        }
        .auto-style28 {
            width: 57px;
            height: 21px;
        }
        .auto-style29 {
            width: 77px;
            height: 21px;
        }
        .auto-style30 {
            width: 66px;
            height: 21px;
        }
        .auto-style31 {
            width: 107px;
            height: 21px;
        }
        .auto-style32 {
            width: 92px;
            height: 21px;
        }
        .auto-style33 {
            width: 96px;
            height: 21px;
        }
        .auto-style34 {
            width: 63px;
            height: 21px;
        }
        .auto-style38 {
            width: 38px;
        }
        .auto-style39 {
            height: 21px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:Panel ID="pblEstructuras" runat="server">
        <br />
        <br />
        <table style="width:100%;">
            <tr>
                <td class="auto-style17">Id</td>
                <td class="auto-style18">Nombre</td>
                <td class="auto-style19">Tipo</td>
                <td class="auto-style27">Nullo</td>
                <td class="auto-style21">Descripcion</td>
                <td class="auto-style26">Usar</td>
                <td class="auto-style23">Estado</td>
                <td>Numero</td>
                <td class="auto-style26">Numero De Fuente</td>
            </tr>
            <tr>
                <td class="auto-style17">
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style18">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style19">
                    <asp:DropDownList ID="DropDownList1" runat="server">

                    </asp:DropDownList>
                </td>
                <td class="auto-style27">
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                </td>
                <td class="auto-style21">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style26">
                    <asp:CheckBox ID="CheckBox2" runat="server" />
                </td>
                <td class="auto-style23">
                    <asp:CheckBox ID="CheckBox3" runat="server" />
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style26">
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style28"></td>
                <td class="auto-style29"></td>
                <td class="auto-style30"></td>
                <td class="auto-style31"></td>
                <td class="auto-style32"></td>
                <td class="auto-style33"></td>
                <td class="auto-style34"></td>
                <td class="auto-style39"></td>
                <td class="auto-style33"></td>

            </tr>
        </table>
        <br />
        <br />
    </asp:Panel>
    
</asp:Content>
