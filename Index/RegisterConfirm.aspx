<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/masterPrincipal.Master" CodeBehind="RegisterConfirm.aspx.vb" Inherits="Index.RegisterConfirm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="success" runat="server" visible="false"> 
    <p id="textSuccess" class="alert-success">Felicitaciones tu cuenta ya fue activada con exito!</p>
        <a href="Home.aspx">Ir al Inicio</a>
        </div>
    <div id="fail" runat="server" visible="false"> 
    <p id="textFail" class="alert-danger">Sucedio un error durante su activacion</p>
        <a href="Home.aspx">Ir al Inicio</a>
        </div>
   
     <div class="container" id="container" runat="server">
      <div class="card card-login mx-auto mt-5">
        <div class="card-header">Reestablecer contraseña</div>
        <div class="card-body">
          <div class="text-center mb-4">
            <h4>Ingresa tu contraseña</h4>
            <p>Ingresa una contraseña nueva y confirmala</p>
          </div>
             <div class="form-group">
              <div class="form-label-group">
                <input runat="server" type="password" id="inputPassword" class="form-control" placeholder="Contraseña" required="required" autofocus="autofocus">
                <label for="inputPassword">Contraseña</label>
              </div>
            </div>
          
            <div class="form-group">
              <div class="form-label-group">
                <input runat="server" type="password" id="inputNewpassword" class="form-control" placeholder="Nueva Contraseña" required="required" autofocus="autofocus">
                <label for="inputNewPassword">Nueva Contraseña</label>
              </div>
            </div>
                  <div class="form-group">
              <div class="form-label-group">
                <input runat="server" type="password" id="inputConfirmPassword" class="form-control" placeholder="Confirmar Nueva Contraseña" required="required" >
                <label for="inputConfirmPassword">Confirmar Nueva Contraseña</label>
              </div>
            </div>
            <asp:button id="btnResetPwd" runat="server" class="btn btn-primary btn-block" Text="Cambiar contraseña"></asp:button>
               <asp:button id="btnCancel" runat="server" class="btn btn-primary btn-block" Text="Cancelar"></asp:button>
          
          <div class="text-center">
            <a class="d-block small" href="Home.aspx">Volver al inicio</a>
          </div>
        </div>
      </div>
    </div>
</asp:Content>
