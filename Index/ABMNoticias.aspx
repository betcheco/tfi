<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/masterPrincipal.Master" CodeBehind="ABMNoticias.aspx.vb" Inherits="Index.ABMNoticias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card-header">
        <h2>Administrador de noticias</h2>
    </div>

    <div class="card-body">
    <asp:GridView  class="table table-striped table-light table-hover"  ID="grdNoticias" runat="server" AutoGenerateColumns="False" DataKeyNames="id" AllowPaging="True">
          <Columns>
            <asp:BoundField DataField="id" HeaderText="Id"  />
            <asp:BoundField DataField="titulo" HeaderText="Titulo"  />
            <asp:BoundField DataField="desc_corta" HeaderText="Descripcion" />
            <asp:BoundField DataField="fecha_desde" HeaderText="Fecha desde" />
              <asp:BoundField DataField="fecha_hasta" HeaderText="Fecha hasta" />
            <asp:ButtonField CommandName="Select"  Text='<i class="fa fa-edit"></i>'/>
            <asp:ButtonField CommandName="Delete" Text='<i class="fa fa-trash"></i>' />
        </Columns>
    </asp:GridView>
            <div class="row d-flex justify-contentcenter">
    <asp:Button ID="btnNuevo" runat="server" Text="Nueva noticia" CssClass="btn btn-primary mx-md-auto mt-1" />
                </div>
            <div class="row mt-2 d-flex justify-content-center">
                <a class="d-block small mt-3" href="Home.aspx">Ir a inicio</a>
            </div>
            
    </div>
</asp:Content>
