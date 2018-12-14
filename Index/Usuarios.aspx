<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/masterPrincipal.Master" CodeBehind="Usuarios.aspx.vb" Inherits="Index.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="card-header">
        <h2>Usuarios</h2>
    </div>
  
    <div>
        <asp:GridView class="table table-striped table-light table-hover"  ID="grdUsers" runat="server" AutoGenerateColumns="False" DataKeyNames="id" AllowPaging="True">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="Id"  />
            <asp:BoundField DataField="nombre" HeaderText="Nombre"  />
            <asp:BoundField DataField="apellido" HeaderText="Apellido" />
            <asp:BoundField DataField="email" HeaderText="Email" />
            <asp:ButtonField CommandName="Select"  Text='<i class="fa fa-edit"></i>'/>
            <asp:ButtonField CommandName="Delete" Text='<i class="fa fa-trash"></i>' />
        </Columns>
    </asp:GridView>
    </div>

    <div class="row d-flex justify-contentcenter">
        <asp:Button CssClass="btn btn-primary mx-md-auto mt-1" runat="server" ID="btnNuevo" Text="Nuevo Usuario"/>
    
     </div>
            <div class="row mt-2 d-flex justify-content-center">
                <a class="d-block small mt-3" href="Home.aspx">Ir a inicio</a>
            </div>

</asp:Content>
