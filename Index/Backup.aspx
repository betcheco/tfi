<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/masterPrincipal.Master" CodeBehind="Backup.aspx.vb" Inherits="Index.Backup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="justify-content-center">
    
        <p class="d-flex justify-content-center" >Para realizar el backup full de la base de datos, debe presionar el botón de abajo</p>
        <div class="d-flex justify-content-center align-content-center">
            <asp:Button ID="Button1" runat="server" class="btn btn-primary mx-auto" Text="Realizar backup" />
        </div>
        </div>
</asp:Content>
