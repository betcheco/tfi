<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/masterPrincipal.Master" CodeBehind="MiPerfil.aspx.vb" Inherits="Index.MiPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div class="card card-register mx-auto mt-5">
          
        <div class="card-header" runat="server" id="titulo">Mi perfil de usuario</div>
        <div class="card-body">
          
            <div class="form-group">
              <div class="form-row">
                <div class="col-md-6">
                  <div class="form-label-group">
                    <input runat="server" type="text" id="inputfirstName" class="form-control"  autofocus="autofocus"/>
                    <label for="firstName">Nombre</label>
                  </div>
                </div>
                <div class="col-md-6">
                  <div class="form-label-group">
                    <input runat="server" type="text" id="inputlastName" class="form-control"   />
                    <label for="lastName">Apellido</label>
                  </div>
                </div>
              </div>
            </div>
            <div class="form-group">
              <div class="form-label-group">
                <input runat="server" type="email" id="inputEmail" class="form-control" placeholder="Email" />
                <label for="inputEmail">Email</label>
              </div>
            </div>
         
        
            <asp:button ID="btnCrear" runat="server" class="btn btn-primary btn-block" Text="Guardar"/>
            
          <div class="text-center mt-3">
            <asp:button runat="server" ID="btnCambioPass" class="btn btn-primary btn-block" text="Cambiar Contraseña"></asp:button>
            </div>
          
          <div class="text-center">
            <a class="d-block small mt-3" href="Home.aspx">Volver</a>
            </div>
            </div>
          </div>
</asp:Content>
