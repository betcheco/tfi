<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/masterPrincipal.Master" CodeBehind="ForgotPassword.aspx.vb" Inherits="Index.ForgotPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>GolfTracking - Recupero de contraseña</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body runat="server">
        <div class="container jumbotron" id="success" runat="server" visible="false">
            <p>Se envio un mail a su casilla para completar el blanqueo de la password</p>
            <div>
             <asp:HyperLink ID="linkResetPwd" runat="server">Click aqui para resetear tu password</asp:HyperLink>
                </div>
            <div>
            <a href="Home.aspx">Ir al Inicio</a>
                </div>
        </div>
        <div class="alert-danger" id="error" runat="server" visible="false">
            <p>No es posible blanquear la contraseña de este usuario</p>
             <a href="Home.aspx">Ir al Inicio</a>
        </div>
        <div class="container" id="divMail" runat="server"> 
      <div class="card card-login mx-auto mt-5">
        <div class="card-header">Reestablecer contraseña</div>
        <div class="card-body">
          <div class="text-center mb-4">
            <h4>¿Olvidaste tu contraseña?</h4>
            <p>Ingresa tu direccion de email y te enviaremos un link para que puedas reestablecerla</p>
          </div>
         
            <div class="form-group">
              <div class="form-label-group">
                <input runat="server" type="email" id="inputEmail" class="form-control" placeholder="Email" required="required" autofocus="autofocus">
                <label for="inputEmail">Email</label>
              </div>
            </div>
            <asp:button id="btnResetPwd" runat="server" class="btn btn-primary btn-block" href="login.html" Text="Resetear contraseña"></asp:button>
       
          <div class="text-center">
            <a class="d-block small mt-3" href="Register.aspx">Registrar una cuenta</a>
            <a class="d-block small" href="Home.aspx">Volver al inicio</a>
          </div>
        </div>
      </div>
    </div>
        </body>
</asp:Content>
