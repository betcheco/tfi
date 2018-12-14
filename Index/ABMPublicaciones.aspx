<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/masterPrincipal.Master" CodeBehind="ABMPublicaciones.aspx.vb" Inherits="Index.ABMPublicaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Administracion de publicaciones</h2>
    <asp:GridView ID="gridAnuncios" runat="server" AutoGenerateColumns="False" class="table table-striped table-light table-hover">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="Id"  />
            <asp:BoundField DataField="titulo" HeaderText="Titulo"  />
            <asp:BoundField DataField="desc_corta" HeaderText="Descripcion" />
            <asp:ButtonField CommandName="Select"  Text='<i class="fa fa-edit"></i>'/>
            <asp:ButtonField CommandName="Delete" Text='<i class="fa fa-trash"></i>' />
        </Columns>
    </asp:GridView>
    <div class="row d-flex justify-contentcenter">
    <asp:Button ID="btnPublicar" runat="server" Text="Publicar Anuncio" class="btn btn-primary mx-md-auto mt-1" />
        </div>
     <div class="row mt-2 d-flex justify-content-center">
                <a class="d-block small mt-3" href="Home.aspx">Ir a inicio</a>
            </div>
</asp:Content>
