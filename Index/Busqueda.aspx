<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/masterPrincipal.Master" CodeBehind="Busqueda.aspx.vb" Inherits="Index.Busqueda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="divMensaje" runat="server" class="row mt-2 d-flex justify-content-center">
        <h4 id="mensaje" runat="server"></h4>
    </div>
    <div id="divResultados" runat="server" class="row mt-2 d-flex justify-content-center">
    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>

         <asp:LinkButton id="idpagina"  runat="server" Text='<%# Eval("pagina")%>' Visible="true" href='<%# Eval("url")%>'></asp:LinkButton>
            </ItemTemplate>
    </asp:Repeater>
        </div>

    <div class="row card-footer mt-5 d-flex justify-content-center">
        <asp:Button ID="btnVolver" CssClass="btn btn-primary btn-sm" Text="Volver" runat="server" />
    </div>
</asp:Content>
