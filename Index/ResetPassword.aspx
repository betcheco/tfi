<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/masterPrincipal.Master" CodeBehind="ResetPassword.aspx.vb" Inherits="Index.ResetPassword" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <body>
          <div class="container" id="divError" runat="server" visible="false">
            <p class="jumbotron">Error al intentar resetear la contraseña</p>
            <a href="Home.aspx">Ir al Inicio</a>
        </div>    
          <div class="container" id="divSuccess" runat="server" visible="false">
            <p class="jumbotron">Tu contraseña se reseteo con exito</p>
            <a href="Home.aspx">Ir al Inicio</a>
        </div>  
          <p class="alert-danger" id="errorPwd" runat="server" visible="false">Las contraseñas no coinciden</p> 
    <div class="container" id="container" runat="server" visible="false">
      <div class="card card-login mx-auto mt-5">
        <div class="card-header">Reestablecer contraseña</div>
        <div class="card-body">
          <div class="text-center mb-4">
            <h4>Ingresa tu nueva contraseña</h4>
            <p>Ingresa una contraseña nueva y confirmala</p>
          </div>
          
            <div class="form-group">
              <div class="form-label-group">
                <input runat="server" type="password" id="inputpassword" class="form-control" placeholder="Contraseña" required="required" autofocus="autofocus">
                <label for="inputPassword">Contraseña</label>
              </div>
            </div>
                  <div class="form-group">
              <div class="form-label-group">
                <input runat="server" type="password" id="inputConfirmPassword" class="form-control" placeholder="Confirmar Contraseña" required="required" >
                <label for="inputConfirmPassword">Confirmar Contraseña</label>
              </div>
            </div>
            <asp:button id="btnResetPwd" runat="server" class="btn btn-primary btn-block" Text="Cambiar contraseña"></asp:button>
          
          <div class="text-center">
            <a class="d-block small" href="Home.aspx">Volver al inicio</a>
          </div>
        </div>
      </div>
    </div>
        </body>
</asp:Content>
