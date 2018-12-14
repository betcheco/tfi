<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/masterPrincipal.Master" CodeBehind="NewUser.aspx.vb" Inherits="Index.NewUser" %>
<%@ Register Src="~/UserControls/usrCtrlTable.ascx" TagPrefix="WebUserControl" TagName="usrCtrlTable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
      <div class="card card-register mx-auto mt-5">
          
        <div class="card-header" runat="server" id="titulo">Crear usuario</div>
        <div class="card-body">
          
            <div class="form-group">
              <div class="form-row">
                <div class="col-md-6">
                  <div class="form-label-group">
                    <input runat="server" type="text" id="inputfirstName" class="form-control"  required="required" autofocus="autofocus"/>
                    <label for="firstName">Nombre</label>
                  </div>
                </div>
                <div class="col-md-6">
                  <div class="form-label-group">
                    <input runat="server" type="text" id="inputlastName" class="form-control" required="required" />
                    <label for="lastName">Apellido</label>
                  </div>
                </div>
              </div>
            </div>
            <div class="form-group">
              <div class="form-label-group">
                <input runat="server" type="email" id="inputEmail" class="form-control"  required="required"/>
                <label for="inputEmail">Email</label>
              </div>
            </div>
            <div class="form-group" id="divEstado" runat="server" visible="false">
                <label for="profileDropdownlist">Estado:</label>
                     <asp:DropDownList ID="stateDropdownlist" runat="server" Class="d-flex form-control-sm btn-primary btn-group-toggle" >
                                    <asp:ListItem>RESET</asp:ListItem>
                                    <asp:ListItem>CONFIRMADO</asp:ListItem>
                                    <asp:ListItem>BLOQUEADO</asp:ListItem>
                                    <asp:ListItem>SUSPENDIDO</asp:ListItem>
                                    </asp:DropDownList>
                    
                
            </div>
        
                <div class="form-group">
                    <div class="form-row">
                        <div class="col-md-6">
                            <div class="form-label-group">
                                <p class="justify-content-center">Seleccione el/los roles del usuario:</p>
                                </div>
                             </div>
                             <div class="form-label-group ">
                             <WebUserControl:usrCtrlTable id="grilla" runat="server"/>
                                  </div>
                        
                    </div>

                    
                    
                     
                     

            </div>
             <asp:button ID="btnCrear" runat="server" class="btn btn-primary btn-block" Text="Crear"/>
            
          <div class="alert-info" runat="server" id="divConfirm" visible="false"> 
              <asp:HyperLink ID="linkConfirm" runat="server">Click aqui para confirmar usuario</asp:HyperLink>
          </div>  
          
          <div class="text-center">
            <a class="d-block small mt-3" href="Usuarios.aspx">Volver</a>
            </div>
            </div>
          </div>
    
</asp:Content>
