<%@ Page Title="" Language="C#" MasterPageFile="~/MasterMapeos.Master" AutoEventWireup="true" CodeBehind="Estructura.aspx.cs" Inherits="Mapeos.Web.Estructura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:Panel ID="pblEstructuras" runat="server">
        <asp:Table ID="miTabla" runat="server" BorderStyle="None">
            <asp:TableRow>
                <asp:TableHeaderCell>Nº</asp:TableHeaderCell>
                <asp:TableHeaderCell>Nombre</asp:TableHeaderCell>
                <asp:TableHeaderCell>Tipo</asp:TableHeaderCell>
                <asp:TableHeaderCell>Not Null</asp:TableHeaderCell>
                <asp:TableHeaderCell>Descripción</asp:TableHeaderCell>
                <asp:TableHeaderCell>_</asp:TableHeaderCell>
                <asp:TableHeaderCell>Add</asp:TableHeaderCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Button ID="btnAdd" runat="server" Text="+" OnClick="btnAdd_Click" Font-Bold="True" Font-Size="Medium" />
        <asp:Button ID="btnDel" runat="server" Font-Bold="True" Font-Size="Medium" OnClick="btnDel_Click" Text="-" />
        <br />
        <br />
        <br />
        <br />
        <table id="htmlTabla" style="width:100%;">
            <tr>
                <td>Nº</td>
                <td>Nombre</td>
                <td>Tipo</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <br />
    </asp:Panel>
    
</asp:Content>
