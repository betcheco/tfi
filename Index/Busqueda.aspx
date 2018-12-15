<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/masterPrincipal.Master" CodeBehind="Busqueda.aspx.vb" Inherits="Index.Busqueda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="divMensaje" runat="server">
        <h2 id="mensaje" runat="server"></h2>
    </div>
    <div id="divResultados" runat="server">
    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>

         <asp:LinkButton id="idpagina"  runat="server" Text='<%# Eval("pagina")%>' Visible="true" href='<%# Eval("url")%>'></asp:LinkButton>
            </ItemTemplate>
    </asp:Repeater>
        </div>

    <div>
        <asp:Button ID="btnVolver" CssClass="btn btn-primary" Text="Volver" runat="server" />
    </div>
</asp:Content>
