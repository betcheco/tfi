<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/masterPrincipal.Master" CodeBehind="Backup.aspx.vb" Inherits="Index.Backup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="loading" class="loader loader-default" runat="server"></div>
    <div class="justify-content-center">
        <div class="card text-center">
            <div class="card-header">
                    <h5>Realizar Backup</h5>
                </div>
            <div class="card-body">
                <p class="card-text">Para realizar el backup full de la base de datos, debe presionar el botón de abajo</p>
                <div class="d-flex justify-content-center align-content-center">
                    <asp:Button ID="Button1" runat="server" class="btn btn-primary mx-auto" Text="Realizar backup" />
                </div>
            </div>
        </div>

    </div>
      
</asp:Content>
