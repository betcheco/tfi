<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/masterPrincipal.Master" CodeBehind="Restore.aspx.vb" Inherits="Index.Restore" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="loading" class="loader loader-default" runat="server"></div>
    <div class="justify-content-center">
        <div class="card text-center">
            <div class="card-header">
                <h5>Realizar restore</h5>
            </div>
            <div class="card-body">
                <div class=" card-text p-lg-1 mx-auto">
                    <p>Seleccione el archivo de backup para realizar el restore:</p>
                    <asp:FileUpload ID="FileUpload1" class="btn btn-primary" runat="server" />
                </div>

                <div class="center p-lg-1 mx-auto">
                    <asp:Button ID="btnRestore" class="btn btn-primary mt-4" runat="server" Text="Realizar Restore" />
                </div>
            </div>
        </div>

    </div>
      <div class="row mt-2 d-flex justify-content-center">
        <a class="d-block small mt-3" href="Home.aspx">Ir a inicio</a>
    </div>

</asp:Content>
